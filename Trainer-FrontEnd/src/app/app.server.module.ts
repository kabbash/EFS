import { NgModule } from "@angular/core";
import { AppModule } from "../app/app.module";
import { AppComponent } from "../app/app.component";
import {ServerModule} from "@angular/platform-server";
import {ModuleMapLoaderModule} from "@nguniversal/module-map-ngfactory-loader";
import { BrowserModule } from "@angular/platform-browser";

@NgModule({
    imports: [
        AppModule,
        BrowserModule.withServerTransition({ appId: 'Trainer-FrontEnd' }),
        ServerModule,
        ModuleMapLoaderModule
    ],
    bootstrap: [AppComponent]
    
})
export class AppServerModule {

}