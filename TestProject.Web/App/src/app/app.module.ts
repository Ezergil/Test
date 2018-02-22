import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';


import { AppComponent } from './app.component';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';

const appRoutes: Routes = [
  {
    path: ':type/details/:id',
    component: DetailsComponent,
    data: { title: 'Details' }
  },
  {
    path: ':type',
    component: ListComponent,
    data: { title: 'List' }
  },
  {
    path: ':type/list',
    component: ListComponent,
    data: { title: 'List' }
  }
];

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    DetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(
      appRoutes
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
