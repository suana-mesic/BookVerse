import { Injectable, signal } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { OrderStatusType } from '../../../api-services/orders/orders-api.models';

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
  private adminHubConnection: signalR.HubConnection | null = null;
  private userHubConnection: signalR.HubConnection | null = null;

  private newPaidOrderSubject = new Subject<OrderNotification>();
  private orderStatusChangedSubject = new Subject<OrderStatusNotification>();

  newPaidOrder$ = this.newPaidOrderSubject.asObservable();
  orderStatusChanged$ = this.orderStatusChangedSubject.asObservable();

  userNotifications = signal<UserNotification[]>([]);
  userUnreadCount = signal(0);

  adminNotifications = signal<OrderNotification[]>([]);
  adminUnreadCount = signal(0);

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

  addAdminNotification(notif: OrderNotification): void {
    this.adminNotifications.update((list) => [notif, ...list]);
    this.adminUnreadCount.update((c) => c + 1);
  }

  clearAdminNotifications(): void {
    this.adminNotifications.set([]);
    this.adminUnreadCount.set(0);
  }

  markAdminNotificationsRead(): void {
    this.adminUnreadCount.set(0);
  }

  startAdminConnection(token: string) {
    this.adminHubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7260/hubs/orders', {
        accessTokenFactory: () => token,
      })
      .withAutomaticReconnect()
      .build();

    this.adminHubConnection
      .start() // Starts the connection to the backend hub
      .then(() => console.log('SignalR connected'))
      .catch((err) => console.error('SignalR connection error:', err));

    // Listens for 'NewPaidOrder' events sent from the backend
    // When received, pushes the notification to all subscribers via the Subject
    this.adminHubConnection.on('NewPaidOrder', (notification: OrderNotification) => {
      this.newPaidOrderSubject.next(notification);
    });
  }

  stopConnection(): void {
    this.adminHubConnection?.stop();
    this.adminHubConnection = null;
  }

  stopUserConnection() {
    this.userHubConnection?.stop();
    this.userHubConnection = null;
  }

  startUserConnection(token: string) {
    this.userHubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7260/hubs/user-orders', {
        accessTokenFactory: () => token,
      })
      .withAutomaticReconnect()
      .build();

    this.userHubConnection
      .start()
      .then(() => console.log('SignalR User connected'))
      .catch((err) => console.error('SignalR User connection error:', err));

    this.userHubConnection.on('OrderStatusChanged', (notification: OrderStatusNotification) => {
      this.orderStatusChangedSubject.next(notification);
    });
  }
}
