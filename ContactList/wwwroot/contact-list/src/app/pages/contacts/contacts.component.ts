import { Component, OnInit } from '@angular/core';
import { first, map } from 'rxjs';
import { Contact } from 'src/app/models/contact';
import { ContactsService } from 'src/app/services/contacts.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.scss']
})
export class ContactsComponent implements OnInit {
  public contacts!: Contact[];

  constructor(
    private contactsService:ContactsService
  ) { }

  ngOnInit(): void {
    console.log("siema");

    let data = this.contactsService.getAll();
    let output = data.pipe(map((c: Contact[]) => this.contacts = c ));

    output.subscribe(data => console.log(data));
  }

}
