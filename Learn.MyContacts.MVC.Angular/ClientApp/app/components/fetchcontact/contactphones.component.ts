import { Component } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { ContactPhoneModel } from '../models/contactphonemodel';
import { ContactPhoneModalModel } from '../models/contactphonemodalmodel';


@Component({  
    selector: 'confirm',
    templateUrl: './contactphone.component.html',
   
})
export class ContactPhonesComponent extends DialogComponent<ContactPhoneModalModel, boolean> implements ContactPhoneModalModel {
  title: string;
  message: string;
  cp: ContactPhoneModel[];
  constructor(dialogService: DialogService) {
    super(dialogService);
  }
  confirm() {
    // we set dialog result as true on click on confirm button, 
    // then we can get dialog result from caller code 
    this.result = true;
    this.close();
  }
}