export type User = {
  firstName: string;
  lastName: string;
  email: string;
  role: string;
  addresses: Address[];
};

export type Address = {
  id: string;
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
  isDefault: boolean;
};
