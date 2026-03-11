export interface GetMonthlyRevenueQueryDto {
  month: number;
  monthName: string;
  totalRevenue: number;
}

export interface GetMonthlyOrdersCountQueryDto {
  month: number;
  monthName: string;
  ordersCount: number;
}

export interface GetTopFiveBooksQueryDto {
  bookTitle: string;
  totalSold: number;
}

export interface GetShippersOrdersQueryDto {
  shipperName: string;
  ordersCount: number;
}

export interface GetCategoriesPopularityQueryDto {
  genreName: string;
  totalSold: number;
}

export interface GetRevenueByMonthAndCategoryQueryDto {
  month: number;
  monthName: string;
  categoryName: string;
  revenue: number;
}

export interface GetDashboardCardSummaryDto {
  totalRevenue: number;
  totalOrders: number;
  totalUsers: number;
  totalBooksSold: number;
  generatedAt: Date;

  revenueChangePercent: number;
  ordersChangePercent: number;
  usersChangePercent: number;
  booksSoldChangePercent: number;
}
