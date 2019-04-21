import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { UsersComponent } from './components/users/users.component';
import { CarsComponent } from './components/cars/cars.component';
import { OrderListComponent } from './components/orders/order-list.component';
import { OrderCreateComponent } from './components/orders/order-create.component';
import { OrderEditComponent } from './components/orders/order-edit.component';
import { OrderFormComponent } from './components/orders/order-form.component';
import { SearchComponent } from './components/search/search.component';
import { DataService } from './components/services/data.service';

// определение маршрутов
const appRoutes: Routes = [
    { path: 'users', component: UsersComponent },
    { path: 'cars', component: CarsComponent },
    { path: 'orders', component: OrderListComponent },
    { path: 'orders/create', component: OrderCreateComponent },
    { path: 'orders/edit/:id', component: OrderEditComponent },
    { path: '**', redirectTo: 'orders' }
];
@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, UsersComponent, CarsComponent, OrderListComponent, OrderCreateComponent, OrderFormComponent, OrderEditComponent, SearchComponent],
    providers: [DataService],
    bootstrap: [AppComponent]
})
export class AppModule { }