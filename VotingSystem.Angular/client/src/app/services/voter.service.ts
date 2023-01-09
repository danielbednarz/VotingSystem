import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Voter } from '../models/voter';

@Injectable({
  providedIn: 'root'
})
export class VoterService {
  baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  getVoters() {
    return this.httpClient.get<Voter[]>(this.baseUrl + 'Voter');
  }

}
