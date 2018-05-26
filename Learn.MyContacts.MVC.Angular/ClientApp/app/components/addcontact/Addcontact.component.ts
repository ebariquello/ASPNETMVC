import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchContactComponent } from '../fetchcontact/fetchcontact.component';
import { ContactService } from '../../services/contactService';

@Component({
    selector: 'createcontact',
    templateUrl: './Addcontact.component.html'
})

export class CreateContactComponent implements OnInit{
    form: FormGroup;
    title: string = "Criar";
    contactID: number ;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _contactService: ContactService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.contactID = this._avRoute.snapshot.params["id"];
          
        }

        this.form = this._fb.group({
            contactID: 0,
            name: ['', [Validators.required]],
            address: [''],
            company: [''],
         
        })
    }

    ngOnInit() {
        this.fillForm();
    }

    fillForm() {
        if (this.contactID > 0) {
            this.title = "Editar";
            this._contactService.getContactByID(this.contactID)
                .subscribe((resp) => {
                  
                    this.form.setValue(resp)
                }
                    , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.form.valid) {
            return;
        }

        if (this.title == "Criar") {
            this._contactService.saveContact(this.form.value)
                .subscribe((data) => {
                    this._router.navigate(['/list-contacts']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Editar") {
            this._contactService.updateContact(this.form.value)
                .subscribe((data) => {
                    this._router.navigate(['/list-contacts']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/list-contacts']);
    }

    get name() {
        return this.form.get('name');
    }
    get address() {
        return this.form.get('address');
    }
    get company() {
        return this.form.get('company');
    }
}
   