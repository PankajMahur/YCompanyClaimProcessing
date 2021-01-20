import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services/user.service';
import { TokenStorageService } from '../_services/token-storage.service';
import {Router} from '@angular/router';
import { PolicyUser } from '../models/PolicyUser'
@Component({
  selector: 'app-claim',
  templateUrl: './claim.component.html',
  styleUrls: ['./claim.component.css']
})
export class ClaimComponent implements OnInit {

  form: any = {};
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  user : PolicyUser;
  claim: any ={};
  //roles: string[] = [];

  constructor(private userService: UserService, private tokenStorage: TokenStorageService, private router: Router) { }

  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
      this.user = this.tokenStorage.getUser();
      this.loadUserClaims(this.user.customerId);
    }
  }

  onSubmit(): void {
    
  }

  loadUserClaims(customerId: string): void {
    this.userService.getUserClaims(customerId).subscribe(
      data => {
        this.claim = JSON.stringify(data);
      },
      err => {
        this.errorMessage = err.error.message;       
      }
    );
  }

}
