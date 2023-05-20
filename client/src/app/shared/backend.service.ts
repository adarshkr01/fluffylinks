import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Note } from '../models/Note';

@Injectable({
  providedIn: 'root',
})
export class BackendService {
  baseUrl = 'https://fluffylinks.onrender.com';
  notesByUserId = '/api/notes/user/';
  postNotes = '/api/notes';

  constructor(private httpClient: HttpClient) {}

  getNotesByUserId(userId: string) {
    return this.httpClient.get<Note[]>(
      `${this.baseUrl}${this.notesByUserId}${userId}`
    );
  }

  postNote(note: Note) {
    return this.httpClient.post<Note>(`${this.baseUrl}${this.postNotes}`, note);
  }
}
