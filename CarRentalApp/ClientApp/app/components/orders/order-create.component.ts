import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { Order } from './order';

@Component({
    templateUrl: './order-create.component.html',
    providers: [DataService]
})
export class OrderCreateComponent {

    order: Order = new Order();
    constructor(private dataService: DataService, private router: Router) { }
    save() {
        this.dataService.createOrder(this.order).subscribe(data => this.router.navigateByUrl("/"));
    }
}