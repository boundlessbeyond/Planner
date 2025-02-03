import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RootStateModule } from './state/root-state.module';
import { AuthModule } from './page/auth/auth.module';
import { AuthStateModule } from './state/auth-store/auth-state.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    RootStateModule,
    AuthStateModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
