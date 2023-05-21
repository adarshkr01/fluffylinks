import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BackendService } from '../shared/backend.service';
import { Note } from '../models/Note';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.css'],
})
export class AddNoteComponent {
  btnLoading = false;

  addNoteForm = new FormGroup({
    url: new FormControl('', [Validators.required]),
    title: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    highlightedText: new FormControl('', [Validators.required]),
  });

  constructor(
    private backend: BackendService,
    private _snackBar: MatSnackBar
  ) {}

  onSubmit() {
    this.btnLoading = true;

    if (this.addNoteForm.valid) {
      let note: Note = {
        id: null,
        url: this.url!.value!,
        title: this.title!.value!,
        description: this.description!.value!,
        highlightedText: this.highlightedText!.value!,
        userId: 'string',
      };

      this.backend.postNote(note).subscribe({
        next: () => {
          this.btnLoading = false;
          this.openSnackbar('Note saved successfully!');
        },
        error: (error) => {
          this.btnLoading = false;
          this.openSnackbar(error.message);
        },
      });
    }
  }

  openSnackbar(message: string) {
    this._snackBar.open(message, 'Close', {
      duration: 5000,
    });
  }

  get url() {
    return this.addNoteForm.get('url');
  }

  get title() {
    return this.addNoteForm.get('title');
  }

  get description() {
    return this.addNoteForm.get('description');
  }

  get highlightedText() {
    return this.addNoteForm.get('highlightedText');
  }
}
