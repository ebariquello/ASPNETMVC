import { NgModule } from '@angular/core';
import { ContactService } from './services/contactService';

import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchContactComponent } from './components/fetchcontact/FetchContact.component'
import { CreateContactComponent } from './components/addcontact/AddContact.component'  
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { ContactPhonesComponent } from './components/fetchcontact/contactphones.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchContactComponent,
        CreateContactComponent,
        HomeComponent,
        ContactPhonesComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        BootstrapModalModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'list-contacts', component: FetchContactComponent },
            { path: 'create-contact', component: CreateContactComponent },
            { path: 'edit-contact/:id', component: CreateContactComponent }, 
            { path: '**', redirectTo: 'home' }
        ])
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [ContactService],
    entryComponents: [
        ContactPhonesComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}
