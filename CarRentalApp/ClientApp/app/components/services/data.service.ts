import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../orders/order';
 
@Injectable()
export class DataService {
 
    private urlUsers = "https://localhost:44364/api/users";
    private urlCars = "https://localhost:44364/api/cars";
    private urlOrders = "https://localhost:44364/api/orders";
 
    constructor(private http: HttpClient) {
    }
 
    getUsers() {
        return this.http.get(this.urlUsers);
    }

    getCars() {
        return this.http.get(this.urlCars);
    }

    getOrders() {
        return this.http.get(this.urlOrders);
    }

    getOrder(id: number) {
        return this.http.get(this.urlOrders + '/' + id);
    }

    createOrder(order: Order) {
        return this.http.post(this.urlOrders, order);
    }

    updateOrder(order: Order) {
        return this.http.put(this.urlOrders + '/' + order.id, order);
    }

    deleteOrder(id: number) {
        return this.http.delete(this.urlOrders + '/' + id);
    }

    getOrdersFiltered(type: string, key: string) {
        switch (type) {
            case "model":
                return this.getOrdersByCarModel(key);
            case "vendor":
                return this.getOrdersByCarVendor(key);
            case "name":
                return this.getOrdersByUserName(key);
            case "start":
                return this.getOrdersByStartDate(key);
            case "end":
                return this.getOrdersByEndDate(key);
        }
    }
    getOrdersByCarModel(model: string) {
        return this.http.get(this.urlOrders + '/model/' + model);
    }
    getOrdersByCarVendor(vendor: string) {
        return this.http.get(this.urlOrders + '/vendor/' + vendor);
    }
    getOrdersByUserName(name: string) {
        return this.http.get(this.urlOrders + '/name/' + name);
    }
    getOrdersByStartDate(date: string) {
        return this.http.get(this.urlOrders + '/start/' + date);
    }
    getOrdersByEndDate(date: string) {
        return this.http.get(this.urlOrders + '/end/' + date);
    }
}