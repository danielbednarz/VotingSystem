import { Component, OnInit } from '@angular/core';
import { Candidate } from '../models/candidate';
import { Voter } from '../models/voter';
import { CandidateService } from '../services/candidate.service';
import { VoterService } from '../services/voter.service';
import { VotingService } from '../services/voting.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  voters: Voter[];
  candidates: Candidate[];
  votingCount: number;
  selectedVoter: number = 0;
  selectedCandidate: number = 0;
  alreadyVotedException: boolean = false;
  voterAlreadyExistsException: boolean = false;
  candidateAlreadyExistsException: boolean = false;
  voterNameToAdd: string = '';
  candidateNameToAdd: string = '';

  constructor(
    private voterService: VoterService,
    private candidateService: CandidateService,
    private votingService: VotingService
  ) {}

  ngOnInit(): void {
    this.getVoters();
    this.getCandidates();
  }

  getVoters() {
    this.voterService.getVoters().subscribe(
      (data: any) => {
        this.voters = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getCandidates() {
    this.candidateService.getCandidates().subscribe(
      (data: any) => {
        this.candidates = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  addVote() {
    this.votingService
      .addVote(this.selectedVoter, this.selectedCandidate)
      .subscribe(
        () => {
          this.getVoters();
          this.getCandidates();
          this.alreadyVotedException = false;
        },
        (error) => {
          this.alreadyVotedException = true;
        }
      );
  }

  addVoter() {
    this.voterService.addVoter(this.voterNameToAdd).subscribe(
      () => {
        this.getVoters();
        this.voterAlreadyExistsException = false;
        this.voterNameToAdd = '';
      },
      (error) => {
        console.log(error.error);
        this.voterAlreadyExistsException = true;
      }
    );
  }

  addCandidate() {
    this.candidateService.addCandidate(this.candidateNameToAdd).subscribe(
      () => {
        this.getCandidates();
        this.candidateAlreadyExistsException = false;
        this.candidateNameToAdd = '';
      },
      (error) => {
        console.log(error.error);
        this.candidateAlreadyExistsException = true;
      }
    );
  }
}
