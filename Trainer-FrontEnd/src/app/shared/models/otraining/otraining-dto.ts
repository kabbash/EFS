export class OTrainingDto {
    details: OTrainingDetailsDto;
    programs: OTrainingProgramDto[];
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