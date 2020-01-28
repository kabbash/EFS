export class User {
    id: string;
    fullName: string;
    username: string;
    token: string;
    roles: string[];
    emailConfirmed: boolean;
    isBlocked: boolean;
    email: string;
    phoneNumber: string = "";
}
