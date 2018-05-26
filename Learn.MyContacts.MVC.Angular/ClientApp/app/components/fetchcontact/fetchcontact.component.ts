import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ContactService } from '../../services/contactService'
import { ContactModel } from '../models/contactmodel';

@Component({
    selector: 'fetchcontact',
    templateUrl: './fetchcontact.component.html'
}) 

export class FetchContactComponent {
    public contactList: ContactModel[] | undefined;

    constructor(public http: Http, private _router: Router, private _contactService: ContactService) {
        this.getContacts();
    }

    getContacts() {
        this._contactService.getContacts().subscribe(
            data => this.contactList = data
        )
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

