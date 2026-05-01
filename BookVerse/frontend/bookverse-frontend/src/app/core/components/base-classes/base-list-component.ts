// src/app/core/components/base-list.component.ts

import {BaseComponent} from './base-component';

export abstract class BaseListComponent<TItem> extends BaseComponent{
  items: TItem[] = [];

  /**
   * The concrete data-loading implementation is left to child classes.
   */
  protected abstract loadData(): void;

  /**
   * Helper that can be called from a child component's ngOnInit.
   */
  protected initList(): void {
    this.loadData();
  }
}
