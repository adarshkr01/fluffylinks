import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Note } from '../models/Note';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css'],
})
export class NotesComponent {
  loading = true;
  notes: Note[] = [];

  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    this.httpClient
      .get<Note[]>('https://fluffylinks.onrender.com/api/notes/user/string')
      .subscribe((data) => {
        this.notes = data;
      });

    this.loading = false;
  }
}
