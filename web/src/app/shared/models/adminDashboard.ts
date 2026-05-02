export interface AdminDashboard {
  summary: DashboardSummary;
  revenueByDay: RevenueByDay[];
  ordersByStatus: NameValue[];
  ordersBySource: NameValue[];
  recentOrders: RecentOrder[];
  topProducts: TopProduct[];
  lowStockProducts: LowStockProduct[];
}

export interface DashboardSummary {
  totalRevenue: number;
  todayRevenue: number;
  totalOrders: number;
  pendingOrders: number;
  webOrders: number;
  posOrders: number;
  totalProducts: number;
  lowStockItems: number;
  totalUsers: number;
}

export interface RevenueByDay {
  date: string;
  revenue: number;
  orders: number;
}

export interface NameValue {
  name: string;
  value: number;
}

export interface RecentOrder {
  id: string;
  orderDate: string;
  buyerEmail: string;
  customerName: string;
  status: string;
  source: string;
  paymentMethod: string;
  itemsCount: number;
  total: number;
}

export interface TopProduct {
  productId: string;
  productVariantId: string;
  productName: string;
  variantName: string;
  quantitySold: number;
  revenue: number;
}

export interface LowStockProduct {
  productId: string;
  productVariantId: string;
  productName: string;
  sku: string;
  price: number;
  stockQuantity: number;
}
