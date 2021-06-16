import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeroCardComponent } from './heroes/hero-card/hero-card.component';
import { HeroScreenComponent } from './heroes/hero-screen/hero-screen.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './registration/login/login.component';
import { SignupComponent } from './registration/signup/signup.component';
import { HeaderComponent } from './header/header.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AboutComponent } from './about/about.component';
import { CreateHeroComponent } from './heroes/create-hero/create-hero.component';
import { SpinnerComponent } from './shared/spinner/spinner.component';
import { ModalComponent } from './shared/modal/modal.component';
import { CookieService } from 'ngx-cookie-service';
import { HttpErrorInterceptor } from './shared/fetch/http-error-interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HeroCardComponent,
    HeroScreenComponent,
    HomeComponent,
    LoginComponent,
    SignupComponent,
    HeaderComponent,
    AboutComponent,
    CreateHeroComponent,
    SpinnerComponent,
    ModalComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    CookieService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
