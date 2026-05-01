import { AfterViewInit, Component, inject, OnDestroy, OnInit } from '@angular/core';
import { Chart } from 'chart.js/auto';
import { StatisticsApiService } from '../../../api-services/statistics/statistics-api.service';
import { ToasterService } from '../../../core/services/toaster.service';
import { GetDashboardCardSummaryDto } from '../../../api-services/statistics/statistics-api.model';
import { ReportsApiServices } from '../../../api-services/reports/reports-api.service';
import { UsersApiService } from '../../../api-services/users/users-api.service';
import { AbstractControl, FormBuilder, FormControl, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { map, Observable, startWith, Subscription } from 'rxjs';
import { ListUsersQueryDto } from '../../../api-services/users/users-api.model';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { BooksApiService } from '../../../api-services/books/books-api.service';
import { ListBooksForAutocompleteQueryDto } from '../../../api-services/books/books-api.models';
import { TranslateService } from '@ngx-translate/core';
import { AuthFacadeService } from '../../../core/services/auth/auth-facade.service';

@Component({
  selector: 'app-admin-settings',
  standalone: false,
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent extends BaseComponent implements OnInit, AfterViewInit, OnDestroy {
  private statisticsApi = inject(StatisticsApiService);
  private usersApi = inject(UsersApiService);
  private booksApi = inject(BooksApiService);
  private reportsApi = inject(ReportsApiServices);
  private toaster = inject(ToasterService);
  private translate = inject(TranslateService);
  private authFacade = inject(AuthFacadeService);
  private fb = inject(FormBuilder);

  summary: GetDashboardCardSummaryDto | null = null;

  reportFiltersForm = this.fb.group({
    dateFrom: this.fb.control<Date | null>(
      new Date(new Date().getFullYear(), 0, 1),
      Validators.required,
    ),
    dateTo: this.fb.control<Date | null>(new Date(), Validators.required),
  });

  get dateFrom(): Date | null {
    return this.reportFiltersForm.controls.dateFrom.value;
  }
  set dateFrom(value: Date | null) {
    this.reportFiltersForm.controls.dateFrom.setValue(value);
  }

  get dateTo(): Date | null {
    return this.reportFiltersForm.controls.dateTo.value;
  }
  set dateTo(value: Date | null) {
    this.reportFiltersForm.controls.dateTo.setValue(value);
  }

  selectedUserId: number | undefined = 0;
  selectedBookId: number | undefined = 0;

  usersAutocompleteInput = new FormControl('', [this.userSelectionValidator()]);
  booksAutocompleteInput = new FormControl('', [this.bookSelectionValidator()]);

  filteredUsersOptions!: Observable<ListUsersQueryDto[]>;
  filteredBooksOptions!: Observable<ListBooksForAutocompleteQueryDto[]>;

  allUsers: ListUsersQueryDto[] = [];
  allBooks: ListBooksForAutocompleteQueryDto[] = [];

  private langChangeSub: Subscription | null = null;

  constructor() {
    super();
    this.setUsersFiltering();
    this.setBooksFiltering();
  }

  ngOnInit(): void {
    this.startLoading();
    this.getDashboardCardSummary();
    this.getAllUsers();
    this.getAllBooks();

    this.langChangeSub = this.translate.onLangChange.subscribe(() => {
      if (this.authFacade.isAuthenticated()) {
        this.loadAllCharts();
      }
    });
  }

  ngAfterViewInit(): void {
    this.loadAllCharts();
  }

  ngOnDestroy(): void {
    this.langChangeSub?.unsubscribe();
    this.langChangeSub = null;
    Object.values(this.chartInstances).forEach((c) => c.destroy());
    this.chartInstances = {};
  }

  private loadAllCharts(): void {
    this.getMonthlyRevenue();
    this.getMonthlyOrdersCount();
    this.getTop5Books();
    this.getShippersOrdersCount();
    this.getCategoriesPopularity();
    this.getRevenueByMonthAndCategory();
  }

  private get currentLang(): string {
    return this.translate.currentLang || this.translate.defaultLang || 'bs';
  }

  setUsersFiltering() {
    this.filteredUsersOptions = this.usersAutocompleteInput.valueChanges.pipe(
      startWith(''),
      map((value) => {
        const userId = this.allUsers.find((x) => x.fullName == value)?.id;
        this.selectedUserId = userId ?? undefined;
        return this._filterUsers(value || '');
      }),
    );
  }

  private _filterUsers(value: string): ListUsersQueryDto[] {
    const filterValue = value.toLowerCase();
    return this.allUsers.filter((x) => x.fullName.toLowerCase().includes(filterValue));
  }

  setBooksFiltering() {
    this.filteredBooksOptions = this.booksAutocompleteInput.valueChanges.pipe(
      startWith(''),
      map((value) => {
        const bookId = this.allBooks.find((x) => x.title == value)?.id;
        this.selectedBookId = bookId ?? undefined;
        return this._filterBooks(value || '');
      }),
    );
  }

  private _filterBooks(value: string): ListBooksForAutocompleteQueryDto[] {
    const filterValue = value.toLowerCase();
    return this.allBooks.filter((x) => x.title.toLowerCase().includes(filterValue));
  }

  private userSelectionValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;
      if (!value || !this.allUsers.find((u) => u.fullName === value))
        return { required: true };
      return null;
    };
  }

  private bookSelectionValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;
      if (!value || !this.allBooks.find((b) => b.title === value))
        return { required: true };
      return null;
    };
  }

  private getAllUsers() {
    this.usersApi.getAllUserNames().subscribe({
      next: (response) => {
        this.allUsers = response;
        this.usersAutocompleteInput.updateValueAndValidity();
      },
      error: (err) =>
        this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_LOAD_USERS')),
    });
  }

  private getAllBooks() {
    this.booksApi.listBooksForAutocomplete().subscribe({
      next: (response) => {
        this.allBooks = response;
        this.booksAutocompleteInput.updateValueAndValidity();
        this.stopLoading();
        this.stopLoading();
      },
      error: (err) =>
        this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_LOAD_BOOKS')),
    });
  }

  get darkMode(): boolean {
    return document.body.classList.contains('dark-theme');
  }

  private chartInstances: { [key: string]: Chart } = {};

  private getNumberLocale(): string {
    const lang = this.translate.currentLang || this.translate.defaultLang || 'bs';
    return lang === 'en' ? 'en-US' : 'bs';
  }

  private translateMonth(monthNumber: number): string {
    return this.translate.instant(`MONTHS.${monthNumber}`);
  }

  makeChart(
    labels: string[],
    values: number[],
    chartName: string,
    label1: string,
    label2: string,
    type: 'bar' | 'line' = 'bar',
    axis: 'x' | 'y' = 'x',
  ) {
    const labelColor = this.darkMode ? '#D8D8D8' : undefined;
    const locale = this.getNumberLocale();
    if (!document.getElementById(chartName)) return;
    if (this.chartInstances[chartName]) this.chartInstances[chartName].destroy();
    this.chartInstances[chartName] = new Chart(chartName, {
      type: type,
      data: {
        labels: labels,
        datasets: [
          {
            label: label1,
            data: values,
            backgroundColor: 'rgba(54, 162, 235, 0.6)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1,
          },
        ],
      },
      options: {
        indexAxis: axis,
        responsive: true,
        plugins: {
          legend: { position: 'top', labels: { color: labelColor } },
          title: {
            display: true,
            text: label2,
            color: labelColor,
          },
          tooltip: {
            callbacks: {
              label: (ctx) => {
                const v = ctx.parsed[axis === 'x' ? 'y' : 'x'];
                return `${ctx.dataset.label}: ${typeof v === 'number' ? v.toLocaleString(locale) : v}`;
              },
            },
          },
        },
        scales: {
          y: {
            ticks: {
              color: labelColor,
              precision: 0,
              callback: (value) =>
                typeof value === 'number' ? value.toLocaleString(locale) : value,
            },
          },
          x: {
            ticks: {
              color: labelColor,
            },
          },
        },
      },
    });
  }

  getMonthlyRevenue() {
    this.statisticsApi.getMonthlyRevenue().subscribe({
      next: (data) => {
        const labels = data.map((x) => this.translateMonth(x.month));
        const values = data.map((x) => x.totalRevenue);
        const label1 = this.translate.instant('STATISTICS.CHARTS.MONTHLY_REVENUE_LABEL');
        const label2 = this.translate.instant('STATISTICS.CHARTS.MONTHLY_REVENUE_TITLE');
        this.makeChart(labels, values, 'revenueChart', label1, label2, 'bar', 'x');
      },
      error: (err) => {
        this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_MONTHLY_REVENUE'));
      },
    });
  }

  getMonthlyOrdersCount() {
    this.statisticsApi.getMonthlyOrdersCount().subscribe({
      next: (data) => {
        const labels = data.map((x) => this.translateMonth(x.month));
        const values = data.map((x) => x.ordersCount);
        const label1 = this.translate.instant('STATISTICS.CHARTS.MONTHLY_ORDERS_LABEL');
        this.makeChart(labels, values, 'ordersChart', label1, label1, 'line', 'x');
      },
      error: (err) => {
        this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_MONTHLY_ORDERS'));
      },
    });
  }

  getTop5Books() {
    this.statisticsApi.getTop5Books().subscribe({
      next: (data) => {
        const labels = data.map((x) => x.bookTitle);
        const values = data.map((x) => x.totalSold);
        const label1 = this.translate.instant('STATISTICS.CHARTS.TOP5_BOOKS_LABEL');
        const label2 = this.translate.instant('STATISTICS.CHARTS.TOP5_BOOKS_TITLE');
        this.makeChart(labels, values, 'topBooksChart', label1, label2, 'bar', 'y');
      },
      error: () => {
        this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_TOP5_BOOKS'));
      },
    });
  }

  getShippersOrdersCount() {
    this.statisticsApi.getShippersOrdersQuery().subscribe({
      next: (data) => {
        const labels = data.map((x) => x.shipperName);
        const values = data.map((x) => x.ordersCount);

        if (!document.getElementById('shippersChart')) return;
        if (this.chartInstances['shippersChart']) this.chartInstances['shippersChart'].destroy();
        this.chartInstances['shippersChart'] = new Chart('shippersChart', {
          type: 'doughnut',
          data: {
            labels: labels,
            datasets: [
              {
                label: this.translate.instant('STATISTICS.CHARTS.ORDERS_COUNT_LABEL'),
                data: values,
                backgroundColor: [
                  'rgba(54, 162, 235, 0.6)',
                  'rgba(255, 99, 132, 0.6)',
                  'rgba(255, 206, 86, 0.6)',
                  'rgba(75, 192, 192, 0.6)',
                  'rgba(153, 102, 255, 0.6)',
                ],
              },
            ],
          },
          options: {
            responsive: true,
            maintainAspectRatio: true,
            aspectRatio: 5 / 3,
            plugins: {
              legend: { position: 'top' },
              title: {
                display: true,
                text: this.translate.instant('STATISTICS.CHARTS.SHIPPERS_TITLE'),
              },
            },
          },
        });
      },
      error: () => {
        this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_SHIPPERS'));
      },
    });
  }
  getCategoriesPopularity() {
    this.statisticsApi.getCategoriesPopularity(this.currentLang).subscribe({
      next: (data) => {
        const labels = data.map((x) => x.genreName);
        const values = data.map((x) => x.totalSold);

        const catLabelColor = this.darkMode ? '#D8D8D8' : undefined;
        if (!document.getElementById('categoriesChart')) return;
        if (this.chartInstances['categoriesChart']) this.chartInstances['categoriesChart'].destroy();
        this.chartInstances['categoriesChart'] = new Chart('categoriesChart', {
          type: 'radar',
          data: {
            labels: labels,
            datasets: [
              {
                label: this.translate.instant('STATISTICS.CHARTS.CATEGORIES_LABEL'),
                data: values,
                backgroundColor: 'rgba(54, 162, 235, 0.6)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 2,
                pointBackgroundColor: 'rgba(54, 162, 235, 0.2)',
              },
            ],
          },
          options: {
            responsive: true,
            maintainAspectRatio: true,
            aspectRatio: 5 / 3,
            plugins: {
              legend: { position: 'top', labels: { color: catLabelColor } },
              title: {
                display: true,
                text: this.translate.instant('STATISTICS.CHARTS.CATEGORIES_TITLE'),
                color: catLabelColor,
              },
            },
            scales: {
              r: {
                beginAtZero: true,
                ticks: {
                  stepSize: 1,
                  color: catLabelColor,
                  callback: (value) => (Number.isInteger(value) ? value : null),
                },
                pointLabels: { color: catLabelColor },
              },
            },
          },
        });
      },
      error: () => {
        this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_CATEGORIES'));
      },
    });
  }

  getRevenueByMonthAndCategory() {
    const colors = [
      'rgba(54, 162, 235, 0.6)',
      'rgba(255, 99, 132, 0.6)',
      'rgba(255, 206, 86, 0.6)',
      'rgba(75, 192, 192, 0.6)',
      'rgba(153, 102, 255, 0.6)',
    ];
    this.statisticsApi.getRevenueByMonthAndCategory(this.currentLang).subscribe({
      next: (data) => {
        const monthNumbers = [...new Set(data.map((x) => x.month))];
        const months = monthNumbers.map((m) => this.translateMonth(m));
        const categories = [...new Set(data.map((x) => x.categoryName))];
        const datasets = categories.map((category, index) => ({
          label: category,
          data: monthNumbers.map((month) => {
            const record = data.find((x) => x.month === month && x.categoryName === category);
            return record ? record.revenue : 0;
          }),
          backgroundColor: colors[index % colors.length],
        }));

        const revLabelColor = this.darkMode ? '#D8D8D8' : undefined;
        if (!document.getElementById('monthlyCategoryRevenueChart')) return;
        if (this.chartInstances['monthlyCategoryRevenueChart'])
          this.chartInstances['monthlyCategoryRevenueChart'].destroy();
        this.chartInstances['monthlyCategoryRevenueChart'] = new Chart('monthlyCategoryRevenueChart', {
          type: 'bar',
          data: {
            labels: months,
            datasets: datasets,
          },
          options: {
            responsive: true,
            maintainAspectRatio: true,
            aspectRatio: 5 / 3,
            plugins: {
              legend: { position: 'top', labels: { color: revLabelColor } },
              title: {
                display: true,
                text: this.translate.instant('STATISTICS.CHARTS.MONTHLY_CATEGORY_TITLE'),
                color: revLabelColor,
              },
            },
            scales: {
              x: {
                stacked: true,
                ticks: { color: revLabelColor },
              },
              y: {
                stacked: true,
                ticks: { color: revLabelColor },
              },
            },
          },
        });
      },
      error: () => {
        this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_CATEGORY_REVENUE'));
      },
    });
  }

  getDashboardCardSummary() {
    this.statisticsApi.getDashboardCardSummary().subscribe({
      next: (data) => (this.summary = data),
      error: () => this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_SUMMARY')),
    });
  }

  downloadOrdersReport(): void {
    this.usersAutocompleteInput.markAsTouched();
    if (!this.dateFrom || !this.dateTo || this.usersAutocompleteInput.invalid) return;
    const lang = this.translate.currentLang || this.translate.defaultLang || 'bs';
    this.reportsApi
      .generateOrdersReport(this.dateFrom, this.dateTo, this.selectedUserId, lang)
      .subscribe({
        next: (blob) => {
          const url = window.URL.createObjectURL(blob);
          const a = document.createElement('a');
          a.href = url;
          a.download = this.translate.instant('STATISTICS.REPORTS.ORDERS_FILENAME');
          a.click();
          window.URL.revokeObjectURL(url);
        },
        error: () =>
          this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_ORDERS_REPORT')),
      });
  }

  downloadBooksReport(): void {
    this.booksAutocompleteInput.markAsTouched();
    if (!this.dateFrom || !this.dateTo || this.booksAutocompleteInput.invalid) return;
    const lang = this.translate.currentLang || this.translate.defaultLang || 'bs';
    this.reportsApi
      .generateBooksReport(this.dateFrom, this.dateTo, this.selectedBookId, lang)
      .subscribe({
        next: (blob) => {
          const url = window.URL.createObjectURL(blob);
          const a = document.createElement('a');
          a.href = url;
          a.download = this.translate.instant('STATISTICS.REPORTS.BOOKS_FILENAME');
          a.click();
          window.URL.revokeObjectURL(url);
        },
        error: () =>
          this.toaster.error(this.translate.instant('STATISTICS.DIALOGS.ERROR_BOOKS_REPORT')),
      });
  }
}
