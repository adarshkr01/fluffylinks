import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
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
    return this.httpClient
      .get<Note[]>(`${this.baseUrl}${this.notesByUserId}${userId}`)
      .pipe(catchError(this.handleError));
  }

  postNote(note: Note) {
    return this.httpClient
      .post<Note>(`${this.baseUrl}${this.postNotes}`, note)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage: string = '';

    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      (errorMessage = 'An error occurred:'), error.error;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      errorMessage = `Backend returned code ${error.status}, body was: ${error.error}`;
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error(errorMessage));
  }
}
