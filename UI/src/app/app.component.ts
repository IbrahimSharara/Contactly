import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Contact } from 'src/Models/Contact.Model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  contact: Contact[] = [];

  contactsForm = new FormGroup({
    name: new FormControl<string>(''),
    email: new FormControl<string | null>(null),
    favourit: new FormControl<boolean>(false),
    phoneNumber: new FormControl<string>(''),
  });
  onFormSubmit() {
    const addContact = {
      name: this.contactsForm.value.name,
      email: this.contactsForm.value.email,
      favourit: this.contactsForm.value.favourit,
      phoneNumber: this.contactsForm.value.phoneNumber,
    };

    this.http
      .post('https://localhost:7285/api/Contacts', addContact)
      .subscribe({
        next: (val) => {
          this.GetContact().subscribe({
            next: (result) => (this.contact = result),
            error: (err) => console.log(err),
          });
          this.contactsForm.reset();
        },
      });
  }
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.GetContact().subscribe({
      next: (result) => (this.contact = result),
      error: (err) => console.log(err),
    });
  }

  Delete(id: number) {
    this.http.delete(`https://localhost:7285/api/Contacts/${id}`).subscribe({
      next: (val) => {
        this.GetContact().subscribe({
          next: (result) => (this.contact = result),
          error: (err) => console.log(err),
        });
        this.contactsForm.reset();
      },
    });
  }
  private GetContact(): Observable<Contact[]> {
    return this.http.get<Contact[]>('https://localhost:7285/api/Contacts');
  }
}
