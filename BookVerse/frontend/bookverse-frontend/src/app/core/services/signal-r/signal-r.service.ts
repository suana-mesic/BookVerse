import { inject, Injectable, NgZone, signal } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { TranslateService } from '@ngx-translate/core';
import { Subject } from 'rxjs';
import { OrderStatusType } from '../../../api-services/orders/orders-api.models';
import { environment } from '../../../../environments/environment';

export interface UserNotification {
  message: string;
  orderNumber: string;
  receivedAt: Date;
}

export interface OrderNotification {
  orderId: number;
  orderNumber: string;
  customerName: string;
  paidAt: string;
}

export interface OrderStatusNotification {
  orderId: number;
  orderNumber: string;
  newStatus: OrderStatusType;
  updatedAt: string;
}
@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  private translate = inject(TranslateService);
  private ngZone = inject(NgZone);
  private staffHubConnection: signalR.HubConnection | null = null;
  private userHubConnection: signalR.HubConnection | null = null;

  // Private Subject – only the service can emit the value
  private newPaidOrderSubject = new Subject<OrderNotification>();
  private orderStatusChangedSubject = new Subject<OrderStatusNotification>();

  // Public Observable - components are subscribed to, but cannot emit
  newPaidOrder$ = this.newPaidOrderSubject.asObservable();
  orderStatusChanged$ = this.orderStatusChangedSubject.asObservable();

  userNotifications = signal<UserNotification[]>([]);
  userUnreadCount = signal(0);

  staffNotifications = signal<OrderNotification[]>([]);
  staffUnreadCount = signal(0);

  addUserNotification(notif: UserNotification): void {
    this.userNotifications.update((list) => [notif, ...list]);
    this.userUnreadCount.update((c) => c + 1);
  }

  clearUserNotifications(): void {
    this.userNotifications.set([]);
    this.userUnreadCount.set(0);
  }

  markUserNotificationsRead(): void {
    this.userUnreadCount.set(0);
  }

  addStaffNotification(notif: OrderNotification): void {
    this.staffNotifications.update((list) => [notif, ...list]);
    this.staffUnreadCount.update((c) => c + 1);
  }

  clearStaffNotifications(): void {
    this.staffNotifications.set([]);
    this.staffUnreadCount.set(0);
  }

  markStaffNotificationsRead(): void {
    this.staffUnreadCount.set(0);
  }

  startStaffConnection(token: string) {
    this.staffHubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/hubs/orders`, {
        accessTokenFactory: () => token,
      })
      .withAutomaticReconnect()
      .build();

    this.staffHubConnection
      .start()
      .then(() => console.log(this.translate.instant('DEBUG.SIGNALR_CONNECTED')))
      .catch((err) => console.error(this.translate.instant('DEBUG.SIGNALR_CONNECTION_ERROR'), err));

    this.staffHubConnection.on('NewPaidOrder', (notification: OrderNotification) => {
      //signalR callbacks run outside Angular zone
      //they must be wrapped in ngZone.run() so that subscribed components
      //(for example orders component)
      //can detect changes and reload their content
      this.ngZone.run(() => this.newPaidOrderSubject.next(notification));
    });
  }

  stopConnection(): void {
    this.staffHubConnection?.stop();
    this.staffHubConnection = null;
  }

  stopUserConnection() {
    this.userHubConnection?.stop();
    this.userHubConnection = null;
  }

  startUserConnection(token: string) {
    this.userHubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/hubs/user-orders`, {
        accessTokenFactory: () => token,
      })
      .withAutomaticReconnect()
      .build();

    this.userHubConnection
      .start()
      .then(() => console.log(this.translate.instant('DEBUG.SIGNALR_USER_CONNECTED')))
      .catch((err) =>
        console.error(this.translate.instant('DEBUG.SIGNALR_USER_CONNECTION_ERROR'), err),
      );

    this.userHubConnection.on('OrderStatusChanged', (notification: OrderStatusNotification) => {
      //signalR callbacks run outside Angular zone
      //they must be wrapped in ngZone.run() so that subscribed components
      //(for example user-orders, user-books)
      //can detect changes and reload their content
      this.ngZone.run(() => this.orderStatusChangedSubject.next(notification));
    });
  }
}
