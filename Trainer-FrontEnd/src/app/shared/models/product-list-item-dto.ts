export class productListItemDto{

    id: Number;
    name: string;
    profilePicture: string;
    description: string;
    expDate: string;
    prodDate: string;
    price: number;
    categoryId: number;
    rate: number;
    seller: Seller;
}
export class Seller {
  name: string;
  phoneNumber: string;
}
