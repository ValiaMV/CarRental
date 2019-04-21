import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DataService } from '../services/data.service';
import { Order } from '../orders/order';

@Component({
    selector: 'search',
    templateUrl: './search.component.html',
    providers: [DataService]
})
export class SearchComponent implements OnInit {

    @Input() orders: Order[];
    key: string;
    type: string;
    inputType: string;
    
    @Output() filtered: EventEmitter<any> = new EventEmitter();

    constructor(private dataService: DataService) { }

    ngOnInit() {
    }
    search() {
        this.dataService.getOrdersFiltered(this.type, this.key).subscribe((data: Order[]) => { this.orders = data; this.filtered.emit(this.orders);});
    }
    getType() {
        if (this.type == "start" || this.type == "end") {
            return "date";
        } else {
            return "text";
        }
    }
    reset() {
        this.dataService.getOrders().subscribe((data: Order[]) => { this.orders = data; this.filtered.emit(this.orders);});
    }
}
