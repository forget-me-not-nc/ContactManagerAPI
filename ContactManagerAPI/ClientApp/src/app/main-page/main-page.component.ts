import { Component } from '@angular/core';
import { ContactInfoModel } from '../models/contact-info.model';
import { ContactInfoService } from '../services/contact-info.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent {
  contacts: ContactInfoModel[] = [];
  showDialog: boolean = false;


  constructor(private contactInfoService: ContactInfoService) {
    this.retrieveContactInfos();
  }

  retrieveContactInfos() {
    this.contactInfoService.getAll().subscribe((resp) => {
      this.contacts = resp.map(el => {
        el.dateOfBirth = new Date(el.dateOfBirth)
        return el;
      });
    });
  }

  updateListMany(newContacts: ContactInfoModel[]) {
    this.contacts = [...this.contacts, ...newContacts];
  }

  deleteContact(id: number) {
    this.contactInfoService.delete(id).subscribe((resp) => {
      if(resp.ok)
        this.contacts = this.contacts.filter(el => el.id != id);
    })
  }
}
