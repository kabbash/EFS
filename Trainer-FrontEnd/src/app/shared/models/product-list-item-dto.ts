export class productListItemDto {

  id: number = 0;
  name: string = '';
  profilePicture: string = null;
  profilePictureFile: File;
  description: string = '';
  expDate: string = '';
  price: number = null;
  categoryId: number = null;
  categoryName: string = '';
  rate: number = 0;
  seller: Seller = new Seller();
  reviews: any;
  isSpecial: boolean = null;
  isActive: boolean = null;
}
export class Seller {
  name: string;
  phoneNumber: string;
}
