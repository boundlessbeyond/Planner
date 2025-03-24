import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    AuthService
  ]
})
export class AuthStateModule {
  static forRoot(): ModuleWithProviders<AuthStateModule> {
    return {
      ngModule: AuthStateModule,
      providers: [
        AuthService
      ]
      // TODO: export the AuthInterceptor and the AuthGuard here
    }
  }
 }
