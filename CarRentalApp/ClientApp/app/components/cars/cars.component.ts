import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { Car } from './car';

@Component({
    templateUrl: './cars.component.html',
    providers: [DataService]
})
export class CarsComponent implements OnInit {

    cars: Car[];
    loaded: boolean = false;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.dataService.getCars()
            .subscribe((data: Car[]) => { this.cars = data; this.loaded = true; });
    }
}