import { environment } from "../environments/environment";

export const apiUrl = {
    "test": {
        "get": environment.baseUrl + 'values'
    },
    "repository": {
        "base": environment.baseUrl
    }
}