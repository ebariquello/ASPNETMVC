import { ContactPhoneModel } from "./contactphonemodel";

export class ContactModel {
    contactID: number;
    name: string;
    address: string
    company: string;
    phone: string;
    email: string;
    contactPhones: ContactPhoneModel[];
}  