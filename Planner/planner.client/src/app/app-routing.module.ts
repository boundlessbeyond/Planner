import { provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './page/auth/components/login/login.component';
import { RegisterComponent } from './page/auth/components/register/register.component';
import { HomeComponent } from './page/home/components/home/home.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  {
    // TODO: AuthGuard to get the auth state from the Auth Store
    path: '', component: HomeComponent, children: [
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [
    provideHttpClient()
  ]
})
export class AppRoutingModule { }
