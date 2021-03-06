import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  loggedIn: any = false;
  model: any = {};
  constructor(public accountService: AccountService, private router: Router, private toaster: ToastrService) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }
  login() {
    this.accountService.login(this.model).subscribe(res => {
      this.router.navigateByUrl("/members")
      this.loggedIn = true
    })
  }

  logout() {
    this.accountService.logout()
    this.router.navigateByUrl("/");
  }


  getCurrentUser() {
    this.accountService.currentUser$.subscribe(user => {
      this.loggedIn = !!user
    }, error => {
      console.log(error);
    })
  }

}
