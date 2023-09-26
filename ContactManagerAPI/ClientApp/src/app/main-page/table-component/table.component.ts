import { Component, EventEmitter, Input, Output } from "@angular/core";
import { ContactInfoModel } from "src/app/models/contact-info.model";

@Component({
  selector: 'app-table-component',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent{

  @Input() contacts: ContactInfoModel[] = [];

  @Output() deleteContact = new EventEmitter<number>();

  delete(id: number) {
    this.deleteContact.emit(id);
  }
}