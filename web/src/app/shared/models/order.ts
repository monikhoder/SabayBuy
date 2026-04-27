export interface Order {
  id: string;
  orderDate: string;
  buyerEmail: string;
  shippingAddress: ShippingAddress;
  deliveryMethod: string;
  deliveryPrice: number;
  orderItems: OrderItem[];
  subtotal: number;
  total: number;
  status: string;
  paymentMethod: string;
  paymentIntentId: string;
}

export interface ShippingAddress {
  fullName: string;
  line1: string;
  line2: string;
  phoneNumber: string;
  city: string;
  state: string;
  zipCode: string;
  country: string;
  latitude: number;
  longitude: number;
}

export interface OrderItem {
  productId: string;
  productName: string;
  productVariantId: string;
  variantName: string;
  price: number;
  quantity: number;
}

export interface CreateOrder {
  cartId: string;
  deliveryMethodId: string;
  shippingAddress: ShippingAddress;
  paymentMethod: number;
  paymentIntentId?: string;
}

export interface AbaCheckoutResponse {
  order: Order;
  payment: AbaPaymentResponse;
}

export interface AbaPaymentResponse {
  qrImage?: string;
  status?: {
    tran_id?: string;
  };
}
