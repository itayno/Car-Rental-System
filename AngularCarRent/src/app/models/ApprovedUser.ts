import { UserTypeEnum } from './userTypeEnum';

export class approvedUser {
    constructor(
        public userName?: string,
        public userPassword?: string,
        public userType?: UserTypeEnum,
        public userId?: number
    ) {}
        


    
}