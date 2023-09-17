import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AlertService } from "../../core/services/alert.service";
import { AuthenticationService } from "../../core/services/authentication.service";
import { BaseHttpClientService } from "../../core/services/base-http-client.service";
import { AuthRoutingModule } from "./auth-routing.module";
import { AuthComponent } from "./auth.component";
import { AlertComponent } from "./components/alert.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from './register/register.component';
import { RegisterfirmComponent } from './registerfirm/registerfirm.component';

@NgModule({
  declarations: [
    LoginComponent,
    AlertComponent,
    AuthComponent,
    RegisterComponent,
    RegisterfirmComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AuthRoutingModule
  ],
  providers: [AuthenticationService, BaseHttpClientService, AlertService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AuthModule { }
