import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { ContactInfoModel } from 'src/app/models/contact-info.model';
import { CSVImportService } from 'src/app/services/csv-import.service';

@Component({
  selector: 'app-csv-import',
  templateUrl: './csv-import.component.html',
  styleUrls: ['./csv-import.component.css']
})
export class CsvImportComponent {
  uploadUrl = 'https://www.primefaces.org/cdn/api/upload.php';
  maxFileSize = 10000;
  fileName = '';
  file: File;

  @Output() updateList = new EventEmitter<ContactInfoModel[]>();

  constructor(private csvImportService: CSVImportService) {}

  onFileUpload(event: any) {
    this.file = event.files[0];
    var formData: FormData = new FormData();
    formData.append("file", this.file);
    formData.append("fileName", this.file.name);

    this.csvImportService.import(formData).subscribe(
      (resp) => {
        this.updateList.emit(resp.body);
      },
      () => { location.reload();}
     );
  }

  onFileSelect(event: any) {
    this.fileName = event.files[0].name;
  }
}