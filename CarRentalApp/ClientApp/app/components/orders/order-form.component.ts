import { Component, Input, OnInit } from '@angular/core';
import { Order } from './order';
import { User } from '../users/user';
import { Car } from '../cars/car';
import { DataService } from '../services/data.service';

@Component({
    selector: "order-form",
    templateUrl: './order-form.component.html',
    providers: [DataService]
})
export class OrderFormComponent implements OnInit {
    @Input() order: Order;
    cars: Car[];
    users: User[];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.dataService.getCars()
            .subscribe((data: Car[]) => { this.cars = data; });
        this.dataService.getUsers()
            .subscribe((data: User[]) => { this.users = data; });
    }
}