import { imageWithTextDto } from "./image-with-text-dto";

export class articleDetialsDto{

    id: Number;
    name: string;
    profilePicture: string;
    description: string;
    images:imageWithTextDto[];
    isActive:boolean;
}