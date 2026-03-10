export type User = {
  firstName: string;
  lastName: string;
  email: string;
  address: Address;
}

export type Address = {
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
}
