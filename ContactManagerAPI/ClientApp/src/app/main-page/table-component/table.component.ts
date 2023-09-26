import { Component, EventEmitter, Input, Output } from "@angular/core";
import { SelectItem } from "primeng/api";
import { ContactInfoModel } from "src/app/models/contact-info.model";
import { UpdateContactInfoModel } from "src/app/models/update-contact-info.model";
import { ContactInfoService } from "src/app/services/contact-info.service";

@Component({
  selector: 'app-table-component',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent{
  constructor(private contactInfoService: ContactInfoService) {}

  @Input() contacts: ContactInfoModel[] = [];
  @Output() deleteContact = new EventEmitter<number>();

  delete(id: number) {
    this.deleteContact.emit(id);
  }

  onRowEditSave(contact: ContactInfoModel) {
    var model: UpdateContactInfoModel = {
      id: contact.id,
      dateOfBirth: contact.dateOfBirth,
      phone: contact.phone,
      isMarried: contact.isMarried,
      name: contact.name,
      salary: contact.salary
    };
    this.contactInfoService.update(model).subscribe();
  }
}