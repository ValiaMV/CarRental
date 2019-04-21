import { User } from '../users/user';
import { Car } from '../cars/car';
export class Order {
    constructor(
        public id?: number,
        public User?: User,
        public userId?: number,
        public Car?: Car,
        public carId?: number,
        public beginDate?: string,
        public endDate?: string,
        public comment?: string
    ) { }
}