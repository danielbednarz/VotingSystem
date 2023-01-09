import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Candidate } from '../models/candidate';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {
  baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  getCandidates() {
    return this.httpClient.get<Candidate[]>(this.baseUrl + 'Candidate');
  }
}
