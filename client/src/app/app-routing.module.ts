import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNoteComponent } from './add-note/add-note.component';
import { NotesComponent } from './notes/notes.component';

const routes: Routes = [
  { path: 'notes', component: NotesComponent },
  { path: 'addNote', component: AddNoteComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
