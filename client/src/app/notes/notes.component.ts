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
  hasError = false;
  errorMessage = '';
  notes: Note[] = [];

  constructor(private backend: BackendService) {}

  ngOnInit() {
    this.backend.getNotesByUserId('string').subscribe({
      next: (data) => {
        this.notes = data;
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        this.hasError = true;
        this.errorMessage = `Something went wrong! ${error.message}`;
      },
    });
  }
}
