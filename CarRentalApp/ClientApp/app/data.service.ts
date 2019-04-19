import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { User } from './user';
 
@Injectable()
export class DataService {
 
    private url = "https://localhost:44364/api/users";
 
    constructor(private http: HttpClient) {
    }
 
    getUsers() {
        return this.http.get(this.url);
    }
}