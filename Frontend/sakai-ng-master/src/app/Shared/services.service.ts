import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  private apiUrl="https://localhost:7237/api";
  constructor(private http:HttpClient) { }

  // Error handling
  private handleError(error: any): Observable<never> {
    console.error('An error occurred:', error);
    throw error;
  }

  create<T>(endpoint: string, data: T): Observable<T> {
    return this.http.post<T>(`${this.apiUrl}/${endpoint}`, data
    );
  }

  
  // Read - GET request
  getAll<T>(endpoint: string): Observable<T[]> {
    return this.http.get<T[]>(`${this.apiUrl}/${endpoint}`);
    
  }

  // Read single item - GET request
  getById<T>(endpoint: string, id: string): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}/${endpoint}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  // Update - PUT request
  update<T>(endpoint: string, id: string, data: T): Observable<T> {
    debugger;
    return this.http.put<T>(`${this.apiUrl}/${endpoint}/${id}`, data
    );
  }

  // Delete - DELETE request
  delete(endpoint: string, id: string): Observable<{}> {
    return this.http.delete(`${this.apiUrl}/${endpoint}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

}
