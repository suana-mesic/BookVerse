import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { OrderStatusType } from '../../../api-services/orders/orders-api.models';

export interface OrderNotification {
  orderId: number;
  orderNumber: string;
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

  // Private Subject
  private newPaidOrderSubject = new Subject<OrderNotification>();
  private orderStatusChangedSubject = new Subject<OrderStatusNotification>();

  // Public Observable - components can subscribe to this to receive notifications, but cannot emit values
  newPaidOrder$ = this.newPaidOrderSubject.asObservable();
  orderStatusChanged$ = this.orderStatusChangedSubject.asObservable();

  startConnection(token: string) {
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
