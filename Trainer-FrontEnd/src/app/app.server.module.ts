import { NgModule } from "@angular/core";
import { AppModule } from "../app/app.module";
import { AppComponent } from "../app/app.component";
import {ServerModule} from "@angular/platform-server";
import {ModuleMapLoaderModule} from "@nguniversal/module-map-ngfactory-loader";

@NgModule({
    imports: [
        AppModule,
        ServerModule,
        ModuleMapLoaderModule
    ],
    bootstrap: [AppComponent]
    
})
export class AppServerModule {

}