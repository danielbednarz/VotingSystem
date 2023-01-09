import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VotingService {
  baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  addVote(voterId: number, candidateId: number) {
    return this.httpClient.post(this.baseUrl + 'Voting', { voterId, candidateId});
  }
}
