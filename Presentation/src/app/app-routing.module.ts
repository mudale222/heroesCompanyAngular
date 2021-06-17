import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { CreateHeroComponent } from './heroes/create-hero/create-hero.component';
import { HeroScreenComponent } from './heroes/hero-screen/hero-screen.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './registration/login/login.component';
import { AuthGuard } from './shared/auth/auth.guard';
import { SignupComponent } from './registration/signup/signup.component';
import { HeroesFetchResolver } from './heroes/hero-screen/heroes-fetch.resolver';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  {
    path: 'heroScreen', component: HeroScreenComponent, canActivate: [AuthGuard], resolve: { HeroesFetchResolver }
  },
  {
    path: 'heroScreen/createHero', component: CreateHeroComponent, canActivate: [AuthGuard]
  },
  { path: 'about', component: AboutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
