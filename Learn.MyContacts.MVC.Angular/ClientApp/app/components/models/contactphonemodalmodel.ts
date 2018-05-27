import { ContactPhoneModel } from "./contactphonemodel";

export interface ContactPhoneModalModel {
    title: string;
    message: string; 
    cp: ContactPhoneModel[];
}