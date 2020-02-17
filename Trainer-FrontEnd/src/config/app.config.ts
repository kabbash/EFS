// import { Injectable } from '@angular/core';
// import { IAppConfig } from './app-config.model';
// import { HttpClient } from '@angular/common/http';
// import { environment } from '../environments/environment';


// @Injectable()
// export class AppConfig {
//     static settings: IAppConfig;
//     constructor(private http: HttpClient) {}
//     load() {
//         const jsonFile = `${environment.frontEndBaseUrl}/assets/config/config.json`;
//         return new Promise<void>((resolve, reject) => {
//             this.http.get(jsonFile).toPromise().then((response : IAppConfig) => {
//                AppConfig.settings = <IAppConfig>response;
//                resolve();
//             }).catch((response: any) => {
//                reject(`Could not load file '${jsonFile}': ${JSON.stringify(response)}`);
//             });
//         });
//     }
// }
