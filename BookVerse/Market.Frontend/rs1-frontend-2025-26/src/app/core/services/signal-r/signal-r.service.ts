import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';

export interface OrderNotification {
  orderId: number;
  orderNumber: string;
  paidAt: string;
}

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  private hubConnection: signalR.HubConnection | null = null;

  // Private Subject
  private newPaidOrderSubject = new Subject<OrderNotification>();
  // Public Observable - components can subscribe to this to receive notifications, but cannot emit values
  newPaidOrder$ = this.newPaidOrderSubject.asObservable();

  startConnection(token: string) {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7260/hubs/orders', {
        accessTokenFactory: () => token,
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start() // Starts the connection to the backend hub
      .then(() => console.log('SignalR connected'))
      .catch((err) => console.error('SignalR connection error:', err));

    // Listens for 'NewPaidOrder' events sent from the backend
    // When received, pushes the notification to all subscribers via the Subject
    this.hubConnection.on('NewPaidOrder', (notification: OrderNotification) => {
      this.newPaidOrderSubject.next(notification);
    });
  }
  stopConnection(): void {
    this.hubConnection?.stop();
    this.hubConnection = null;
  }
}
