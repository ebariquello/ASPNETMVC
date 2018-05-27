import { Component, Inject, ContentChild, ViewEncapsulation } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ContactService } from '../../services/contactService'
import { ContactModel } from '../models/contactmodel';
import { ContactPhonesComponent } from './contactphones.component';
import { DialogService } from 'ng2-bootstrap-modal';






@Component({
    selector: 'fetchcontact',
    templateUrl: './fetchcontact.component.html',
})

export class FetchContactComponent {
    public contactList: ContactModel[] | undefined;

    constructor(public http: Http, private _router: Router, private _contactService: ContactService, private dialogService: DialogService) {
        this.getContacts();
    }

    getContacts() {
        this._contactService.getContacts().subscribe(
            data => {
                var resultArray: Array<ContactModel> = [] //empty array which we are going to push our selected items, always define types 

                data.forEach(i => {
                    let ct = new ContactModel();

                    if (i.contactPhones != null && i.contactPhones.length > 0) {
                        var filterPrincipalPhone = i.contactPhones.filter(cp => cp.IsPrincipal);
                        if (filterPrincipalPhone.length > 0) {
                            ct.phone = filterPrincipalPhone[0].phone;
                        }
                        else {
                            ct.phone = i.contactPhones[0].phone;
                        }
                    }
                    else
                        ct.phone = "";

                    ct.contactPhones = i.contactPhones;
                    if (i.contactEmails != null && i.contactEmails.length > 0) {
                        var filterPrincipalEmail = i.contactEmails.filter(cp => cp.IsPrincipal);
                        if (filterPrincipalEmail.length > 0) {
                            ct.email = filterPrincipalEmail[0].email;
                        }
                        else {
                            ct.email = i.contactEmails[0].email;
                        }
                    }
                    else
                        ct.email = "";

                    ct.contactID = +i.contactID;
                    ct.name = i.name;
                    ct.address = i.address;
                    ct.company = i.company;
                   
                    
                    resultArray.push(ct);
                });
                this.contactList = resultArray;

            }
        )
    }

   
    showContactPhones(contactPhones) {
        let disposable = this.dialogService.addDialog(ContactPhonesComponent, {
            title: 'Confirm title',
            message: 'Confirm message',
            cp: contactPhones
        })
            .subscribe((isConfirmed) => {
                ////We get dialog result
                //if (isConfirmed) {
                //    alert('accepted');
                //}
                //else {
                //    alert('declined');
                //}
            });
        //We can close dialog calling disposable.unsubscribe();
        //If dialog was not closed manually close it by timeout
        setTimeout(() => {
            disposable.unsubscribe();
        }, 10000);
    }

    delete(contactID) {
        var ans = confirm("Você deseja deletar o contato selecionado ?");
        if (ans) {
            this._contactService.deleteContact(contactID).subscribe((data) => {
                this.getContacts();
            }, error => console.error(error))
        }
    }
}

