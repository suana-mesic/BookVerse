import { Component, inject, OnInit } from '@angular/core';
import { Chart } from 'chart.js/auto';
import { StatisticsApiService } from '../../../api-services/statistics/statistics-api.service';
import { ToasterService } from '../../core/services/toaster.service';

@Component({
  selector: 'app-admin-settings',
  standalone: false,
  templateUrl: './statistics.component.html',
  styleUrl: './statistics.component.scss',
})
export class StatisticsComponent implements OnInit {
  private statisticsApi = inject(StatisticsApiService);
  private toaster = inject(ToasterService);

  ngOnInit(): void {
    this.getMonthlyRevenue();
    this.getMonthlyOrdersCount();
    this.getTop5Books();
    this.getShippersOrdersCount();
    this.getCategoriesPopularity();
    this.getRevenueByMonthAndCategory();
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
    new Chart(chartName, {
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
          legend: { position: 'top' },
          title: {
            display: true,
            text: label2,
          },
        },
        scales: {
          y: {
            ticks: {
              stepSize: 1,
            },
          },
          x: {
            ticks: {
              stepSize: 1,
              //callback: (value) => (Number.isInteger(value) ? value : null),
            },
          },
        },
      },
    });
  }

  getMonthlyRevenue() {
    this.statisticsApi.getMonthlyRevenue().subscribe({
      next: (data) => {
        const labels = data.map((x) => x.monthName);
        const values = data.map((x) => x.totalRevenue);
        const label1 = 'Prihod po mjesecima (KM)';
        const label2 = 'Mjesečni prihod';
        this.makeChart(labels, values, 'revenueChart', label1, label2, 'bar', 'x');
      },
      error: (err) => {
        this.toaster.error('Greška prilikom dohvatanja podataka o mjesečnoj zaradi');
      },
    });
  }

  getMonthlyOrdersCount() {
    this.statisticsApi.getMonthlyOrdersCount().subscribe({
      next: (data) => {
        const labels = data.map((x) => x.monthName);
        const values = data.map((x) => x.ordersCount);
        const label1 = 'Broj narudžbi po mjesecima';
        this.makeChart(labels, values, 'ordersChart', label1, label1, 'line', 'x');
      },
      error: (err) => {
        this.toaster.error('Greška prilikom dohvatanja podataka o mjesečnoj zaradi');
      },
    });
  }

  getTop5Books() {
    this.statisticsApi.getTop5Books().subscribe({
      next: (data) => {
        const labels = data.map((x) => x.bookTitle);
        const values = data.map((x) => x.totalSold);
        const label1 = 'Broj prodanih knjiga';
        const label2 = 'Top 5 najprodavanijih knjiga';
        this.makeChart(labels, values, 'topBooksChart', label1, label2, 'bar', 'y');
      },
      error: () => {
        this.toaster.error('Greška prilikom dohvatanja top 5 knjiga');
      },
    });
  }

  getShippersOrdersCount() {
    this.statisticsApi.getShippersOrdersQuery().subscribe({
      next: (data) => {
        const labels = data.map((x) => x.shipperName);
        const values = data.map((x) => x.ordersCount);

        new Chart('shippersChart', {
          type: 'doughnut',
          data: {
            labels: labels,
            datasets: [
              {
                label: 'Broj narudžbi',
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
            aspectRatio: 16 / 9,
            plugins: {
              legend: { position: 'top' },
              title: { display: true, text: 'Narudžbe po dostavljačima' },
            },
          },
        });
      },
      error: () => {
        this.toaster.error('Greška prilikom dohvatanja podataka o dostavljačima');
      },
    });
  }
  getCategoriesPopularity() {
    this.statisticsApi.getCategoriesPopularity().subscribe({
      next: (data) => {
        const labels = data.map((x) => x.genreName);
        const values = data.map((x) => x.totalSold);

        new Chart('categoriesChart', {
          type: 'radar',
          data: {
            labels: labels,
            datasets: [
              {
                label: 'Prodaja po kategorijama',
                data: values,
                backgroundColor: 'rgba(255, 140, 165, 0.2)',
                borderColor: 'rgba(255, 140, 165, 1)',
                borderWidth: 2,
                pointBackgroundColor: 'rgba(255, 140, 165, 0)',
              },
            ],
          },
          options: {
            responsive: true,
            maintainAspectRatio: true,
            aspectRatio: 16 / 9,
            plugins: {
              legend: { position: 'top' },
              title: {
                display: true,
                text: 'Popularnost kategorija knjiga',
              },
            },
            scales: {
              r: {
                beginAtZero: true,
                ticks: {
                  stepSize: 1,
                  callback: (value) => (Number.isInteger(value) ? value : null), // isto kao u makeChart()
                },
              },
            },
          },
        });
      },
      error: () => {
        this.toaster.error('Greška prilikom dohvatanja statistike kategorija');
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
    this.statisticsApi.getRevenueByMonthAndCategory().subscribe({
      next: (data) => {
        const months = [...new Set(data.map((x) => x.monthName))];
        const categories = [...new Set(data.map((x) => x.categoryName))];
        console.log(data);
        const datasets = categories.map((category, index) => ({
          label: category,
          data: months.map((month) => {
            const record = data.find((x) => x.monthName === month && x.categoryName === category);
            return record ? record.revenue : 0;
          }),
          backgroundColor: colors[index % colors.length],
        }));

        new Chart('monthlyCategoryRevenueChart', {
          type: 'bar',
          data: {
            labels: months,
            datasets: datasets,
          },
          options: {
            responsive: true,
            maintainAspectRatio: true,
            aspectRatio: 16 / 9,
            plugins: {
              title: {
                display: true,
                text: 'Prihod po mjesecima i kategorijama',
              },
            },
            scales: {
              x: {
                stacked: true,
              },
              y: {
                stacked: true,
              },
            },
          },
        });
      },
      error: () => {
        this.toaster.error('Greška prilikom dohvatanja prihoda po kategorijama');
      },
    });
  }
}
