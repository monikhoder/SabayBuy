export type User = {
  firstName: string;
  lastName: string;
  email: string;
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
  latitued: number;
  longitude: number;
  isDefault: boolean;
};
