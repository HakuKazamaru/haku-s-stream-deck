import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';// この行を追加

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ModalComponent } from './modal/modal.component';
import { HomeComponent } from './home/home.component';
import { HsdComponent } from './hsd/hsd.component';
import { HsdXlComponent } from './hsd-xl/hsd-xl.component';
import { HsdMiniComponent } from './hsd-mini/hsd-mini.component';
import { PlaySoundComponent } from './test-sound/test-sound.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ModalComponent,
    PlaySoundComponent,
    HomeComponent,
    HsdComponent,
    HsdXlComponent,
    HsdMiniComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'test-sound', component: PlaySoundComponent, canActivate: [AuthorizeGuard] },
    ],
    )
  ],
  entryComponents: [ModalComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
