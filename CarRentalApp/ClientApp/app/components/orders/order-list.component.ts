import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { Order } from './order';

import { forEach } from '@angular/router/src/utils/collection';

@Component({
    templateUrl: './order-list.component.html',
    providers: [DataService]

})
export class OrderListComponent implements OnInit {

    orders: Order[];
    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.load();
    }
    load() {
        this.dataService.getOrders().subscribe((data: Order[]) => this.orders = data);
    }
    delete(id: number) {
        this.dataService.deleteOrder(id).subscribe(data => this.load());
    }
    onFilter(filteredOrders: Order[]) {
        this.orders = filteredOrders;
        console.log(filteredOrders);
    }
}