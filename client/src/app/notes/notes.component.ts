import { Component } from '@angular/core';
import { Note } from '../models/Note';
import { BackendService } from '../shared/backend.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css'],
})
export class NotesComponent {
  loading = true;
  notes: Note[] = [];

  constructor(private backend: BackendService) {}

  ngOnInit() {
    this.backend.getNotesByUserId('string').subscribe((data) => {
      this.notes = data;
      this.loading = false;
    });
  }
}
