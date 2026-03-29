export interface DeliveryMethod {
    id: string;
    shortName: string;
    deliveryTime: string;
    description: string;
    icon: string;
    price: number;
    availableZipcodes: string[];
  }
