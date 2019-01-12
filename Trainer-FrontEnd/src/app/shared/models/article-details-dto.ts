import { imageWithTextDto } from "./image-with-text-dto";

export class articleDetialsDto{

    id: number;
    name: string;
    profilePicture: string;
    description: string;
    images:imageWithTextDto[];
    isActive:boolean;
    categoryId : number;
}