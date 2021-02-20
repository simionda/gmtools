import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { HeaderComponent } from './header/header.component';
import { NpcListComponent } from './npc-list/npc-list.component';
import { NpcComponent } from './npc/npc.component';
import { StatBlockComponent } from './stat-block/stat-block.component';
import { PlacesListComponent } from './places-list/places-list.component';
import { PlaceDetailComponent } from './place-detail/place-detail.component';
import { ShopDetailComponent } from './shop-detail/shop-detail.component';
import { TavernDetailComponent } from './tavern-detail/tavern-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HeaderComponent,
    NpcListComponent,
    NpcComponent,
    StatBlockComponent,
    PlacesListComponent,
    PlaceDetailComponent,
    ShopDetailComponent,
    TavernDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'npcs', component: NpcListComponent },
      { path: 'npcs/:npcName', component: NpcComponent },
      { path: 'places', component: PlacesListComponent },
      { path: 'places/:placeName', component: PlaceDetailComponent }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
