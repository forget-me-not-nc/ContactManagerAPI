import { Component, EventEmitter, Input, Output } from "@angular/core";
import { SelectItem } from "primeng/api";
import { ContactInfoModel } from "src/app/models/contact-info.model";

@Component({
  selector: 'app-table-component',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent{

  statuses!: SelectItem[];

  @Input() contacts: ContactInfoModel[] = [];
  editingContacts: { [s: number]: ContactInfoModel } = {};


  @Output() deleteContact = new EventEmitter<number>();

  delete(id: number) {
    this.deleteContact.emit(id);
  }

  onRowEditInit(contact: ContactInfoModel) {
    this.editingContacts[contact.id] = { ...contact };
  }

  onRowEditSave(contact: ContactInfoModel) {
    
  }

  onRowEditCancel(contact: ContactInfoModel, index: number) {
    this.contacts[index] = this.editingContacts[contact.id];
    delete this.editingContacts[contact.id];
  }
}