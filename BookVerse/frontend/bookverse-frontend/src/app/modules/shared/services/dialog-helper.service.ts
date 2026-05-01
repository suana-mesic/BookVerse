// src/app/modules/shared/services/dialog-helper.service.ts

import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import {
  DialogConfig,
  DialogType,
  DialogButton,
  DialogResult,
} from '../models/dialog-config.model';
import { BookverseConfirmDialogComponent } from '../components/bookverse-confirm-dialog/bookverse-confirm-dialog.component';

@Injectable({
  providedIn: 'root',
})
export class DialogHelperService {
  constructor(
    private dialog: MatDialog,
    private translate: TranslateService,
  ) {}

  /**
   * Opens a custom dialog with full configuration
   */
  open(config: DialogConfig): Observable<DialogResult | undefined> {
    const dialogRef = this.dialog.open(BookverseConfirmDialogComponent, {
      width: config.width || '450px',
      disableClose: config.disableClose || false,
      data: config,
      panelClass: 'custom-dialog-container',
    });

    return dialogRef.afterClosed();
  }

  /**
   * Shows a simple info dialog with OK button
   */
  showInfo(
    titleKey: string,
    messageKey: string,
    params?: any,
    icon?: string,
  ): Observable<DialogResult | undefined> {
    return this.open({
      type: DialogType.INFO,
      titleKey,
      messageKey,
      titleParams: params,
      messageParams: params,
      icon,
      buttons: [{ type: DialogButton.OK, color: 'primary' }],
    });
  }

  /**
   * Shows a success dialog with OK button
   */
  showSuccess(
    titleKey: string,
    messageKey: string,
    params?: any,
    icon?: string,
  ): Observable<DialogResult | undefined> {
    return this.open({
      type: DialogType.SUCCESS,
      titleKey,
      messageKey,
      titleParams: params,
      messageParams: params,
      icon,
      buttons: [{ type: DialogButton.OK, color: 'primary' }],
    });
  }

  /**
   * Shows an error dialog with OK button
   */
  showError(
    titleKey: string,
    messageKey: string,
    params?: any,
    icon?: string,
  ): Observable<DialogResult | undefined> {
    return this.open({
      type: DialogType.ERROR,
      titleKey,
      messageKey,
      titleParams: params,
      messageParams: params,
      icon,
      buttons: [{ type: DialogButton.OK, color: 'warn' }],
    });
  }

  /**
   * Shows a warning dialog with OK button
   */
  showWarning(
    titleKey: string,
    messageKey: string,
    params?: any,
    icon?: string,
  ): Observable<DialogResult | undefined> {
    return this.open({
      type: DialogType.WARNING,
      titleKey,
      messageKey,
      titleParams: params,
      messageParams: params,
      icon,
      buttons: [{ type: DialogButton.OK, color: 'primary' }],
    });
  }

  /**
   * Shows a confirmation dialog with Yes/No buttons
   */
  confirm(
    titleKey: string,
    messageKey: string,
    params?: any,
    icon?: string,
  ): Observable<DialogResult | undefined> {
    return this.open({
      type: DialogType.QUESTION,
      titleKey,
      messageKey,
      titleParams: params,
      messageParams: params,
      icon,
      buttons: [{ type: DialogButton.NO }, { type: DialogButton.YES, color: 'primary' }],
    });
  }

  /**
   * Shows a confirmation dialog with OK/Cancel buttons
   */
  confirmOkCancel(
    titleKey: string,
    messageKey: string,
    params?: any,
    icon?: string,
  ): Observable<DialogResult | undefined> {
    return this.open({
      type: DialogType.QUESTION,
      titleKey,
      messageKey,
      titleParams: params,
      messageParams: params,
      icon,
      buttons: [{ type: DialogButton.CANCEL }, { type: DialogButton.OK, color: 'primary' }],
    });
  }

  /**
   * Shows a delete confirmation dialog
   */
  confirmDelete(itemName: string, messageKey?: string): Observable<DialogResult | undefined> {
    return this.open({
      type: DialogType.WARNING,
      titleKey: 'DIALOGS.TITLES.CONFIRM_DELETE',
      messageKey: messageKey || 'DIALOGS.MESSAGES.DELETE_CONFIRM',
      messageParams: { name: itemName },
      icon: 'delete_forever',
      buttons: [{ type: DialogButton.CANCEL }, { type: DialogButton.DELETE, color: 'warn' }],
    });
  }

  /**
   * Shows unsaved changes confirmation
   */
  confirmUnsavedChanges(): Observable<DialogResult | undefined> {
    return this.open({
      type: DialogType.WARNING,
      titleKey: 'DIALOGS.TITLES.UNSAVED_CHANGES',
      messageKey: 'DIALOGS.MESSAGES.UNSAVED_CHANGES',
      icon: 'warning',
      buttons: [{ type: DialogButton.NO }, { type: DialogButton.YES, color: 'primary' }],
    });
  }

  /**
   * Shows a custom dialog with custom buttons
   */
  showCustom(config: DialogConfig): Observable<DialogResult | undefined> {
    return this.open(config);
  }

  // Convenience methods for common scenarios

  /**
   * Product Category specific dialogs
   */
  productCategory = {
    confirmDelete: (categoryName: string) => {
      return this.confirmDelete(categoryName, 'GENRES.DIALOGS.DELETE_MESSAGE');
    },

    showCreateSuccess: () => {
      return this.showSuccess('DIALOGS.TITLES.SUCCESS', 'GENRES.DIALOGS.SUCCESS_CREATE');
    },

    showUpdateSuccess: () => {
      return this.showSuccess('DIALOGS.TITLES.SUCCESS', 'GENRES.DIALOGS.SUCCESS_UPDATE');
    },

    showDeleteSuccess: () => {
      return this.showSuccess('DIALOGS.TITLES.SUCCESS', 'GENRES.DIALOGS.SUCCESS_DELETE');
    },

    showCreateError: () => {
      return this.showError('DIALOGS.TITLES.ERROR', 'GENRES.DIALOGS.ERROR_CREATE');
    },

    showUpdateError: () => {
      return this.showError('DIALOGS.TITLES.ERROR', 'GENRES.DIALOGS.ERROR_UPDATE');
    },

    showDeleteError: () => {
      return this.showError('DIALOGS.TITLES.ERROR', 'GENRES.DIALOGS.ERROR_DELETE');
    },
  };

  /**
   * Product specific dialogs
   */
  product = {
    confirmDelete: (productName: string) => {
      return this.confirmDelete(productName, 'BOOKS.DIALOGS.DELETE_MESSAGE');
    },

    confirmCancel: () => {
      return this.confirm('BOOKS.DIALOGS.UNSAVED_CHANGES', 'BOOKS.DIALOGS.CONFIRM_CANCEL');
    },

    showCreateSuccess: () => {
      return this.showSuccess('DIALOGS.TITLES.SUCCESS', 'BOOKS.DIALOGS.SUCCESS_CREATE');
    },

    showUpdateSuccess: () => {
      return this.showSuccess('DIALOGS.TITLES.SUCCESS', 'BOOKS.DIALOGS.SUCCESS_UPDATE');
    },

    showDeleteSuccess: () => {
      return this.showSuccess('DIALOGS.TITLES.SUCCESS', 'BOOKS.DIALOGS.SUCCESS_DELETE');
    },

    showCreateError: () => {
      return this.showError('DIALOGS.TITLES.ERROR', 'BOOKS.DIALOGS.ERROR_CREATE');
    },

    showUpdateError: () => {
      return this.showError('DIALOGS.TITLES.ERROR', 'BOOKS.DIALOGS.ERROR_UPDATE');
    },

    showDeleteError: () => {
      return this.showError('DIALOGS.TITLES.ERROR', 'BOOKS.DIALOGS.ERROR_DELETE');
    },
  };

  user = {
    confirmGrantAdmin: (fullName: string) => {
      return this.confirm('DIALOGS.TITLES.CONFIRM_ACTION', 'USERS.DIALOGS.CONFIRM_GRANT_ADMIN', { name: fullName });
    },
  };

  checkout = {
    confirmPayment: (amount: string) => {
      return this.open({
        type: DialogType.QUESTION,
        titleKey: 'CLIENT.CHECKOUT.CONFIRM_PAYMENT_TITLE',
        messageKey: 'CLIENT.CHECKOUT.CONFIRM_PAYMENT_MESSAGE',
        messageParams: { amount },
        icon: 'shopping_cart_checkout',
        buttons: [{ type: DialogButton.CANCEL }, { type: DialogButton.YES, color: 'primary' }],
      });
    },
  };

  order = {
    confirmComplete: (orderNumber: string) => {
      return this.open({
        type: DialogType.WARNING,
        titleKey: 'ORDERS.DIALOGS.CONFIRM_COMPLETE_TITLE',
        messageKey: 'ORDERS.DIALOGS.CONFIRM_COMPLETE_MESSAGE',
        messageParams: { orderNumber },
        icon: 'done_all',
        buttons: [{ type: DialogButton.CANCEL }, { type: DialogButton.YES, color: 'primary' }],
      });
    },
  };

  inventory = {
    confirmDelete: (storeName: string, title: string) => {
      return this.open({
        type: DialogType.WARNING,
        titleKey: 'DIALOGS.TITLES.CONFIRM_DELETE',
        messageKey: 'INVENTORY.DIALOGS.DELETE_MESSAGE',
        messageParams: { storeName, title },
        icon: 'delete_forever',
        buttons: [{ type: DialogButton.CANCEL }, { type: DialogButton.DELETE, color: 'warn' }],
      });
    },
    showDeleteSuccess: () => {
      return this.showSuccess('DIALOGS.TITLES.SUCCESS', 'INVENTORY.DIALOGS.SUCCESS_DELETE');
    },
  };
}
