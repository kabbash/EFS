export class OTrainingDto {
    detailsDto: OTrainingDetailsDto;
    programsDto: OTrainingProgramDto[];
}

export class OTrainingDetailsDto {
    description: string = "";
    forJoin: string = "";
}

export class OTrainingProgramDto {
    id: number = 0;
    name: string = "";
    features: string = "";
    profilePicture: string ="";
    profilePictureFile: File;
}