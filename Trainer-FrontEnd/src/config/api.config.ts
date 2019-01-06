import { environment } from "../environments/environment";

export const apiUrl = {
    "test": {
        "get": environment.baseUrl + 'values'
    },
    "repository": {
        "base": environment.baseUrl
    },
    'userAccount': {
        'login': 'authentication/login',
        'register': 'authentication/Register',
        'verifyEmail': 'authentication/VerifyEmail',
        'resetPassword': 'authentication/ResetPassword',
        'setResetedPassword': 'authentication/SetResetedPassword',
        'changePassword': 'authentication/ChangePassword'
    }
}