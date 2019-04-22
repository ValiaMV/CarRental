import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { Order } from './order';
import { Car } from '../cars/car';

@Component({
    templateUrl: './order-create.component.html',
    providers: [DataService]
})
export class OrderCreateComponent implements OnInit {

    cars: Car[];
    order: Order = new Order();
    constructor(private dataService: DataService, private router: Router) {

    }
    ngOnInit() {
        this.dataService.getFreeCars()
            .subscribe((data: Car[]) => { this.cars = data; });
    }
    save() {
        this.dataService.createOrder(this.order).subscribe(data => this.router.navigateByUrl("/"));
    }
}