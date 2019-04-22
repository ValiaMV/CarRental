import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../services/data.service';
import { Order } from './order';
import { Car } from '../cars/car';

@Component({
    templateUrl: './order-edit.component.html',
    providers: [DataService]
})
export class OrderEditComponent implements OnInit {

    id: number;
    order: Order;
    cars: Car[];
    loaded: boolean = false;

    constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getOrder(this.id)
                .subscribe((data: Order) => {
                    this.order = data;
                    if (this.order != null) this.loaded = true;
                    this.dataService.getFreeCarsEdit(this.order.id)
                        .subscribe((data: Car[]) => { this.cars = data; });
                });
    }

    save() {
        this.dataService.updateOrder(this.order).subscribe(data => this.router.navigateByUrl("/"));
    }
}