import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { User } from './user';
 
@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {
 
    users: User[];                // массив товаров
    tableMode: boolean = true;          // табличный режим
 
    constructor(private dataService: DataService) { }
 
    ngOnInit() {
        this.loadProducts();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadProducts() {
        this.dataService.getUsers()
            .subscribe((data: User[]) => this.users = data);
    }
}