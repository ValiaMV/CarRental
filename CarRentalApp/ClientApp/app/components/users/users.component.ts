import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { User } from './user';

@Component({
    templateUrl: './users.component.html',
    providers: [DataService]
})
export class UsersComponent implements OnInit {

    users: User[];                
    loaded: boolean = false;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.dataService.getUsers()
            .subscribe((data: User[]) => { this.users = data; this.loaded = true; });  
    }
}