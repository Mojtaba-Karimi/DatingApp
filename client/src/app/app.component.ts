import { User } from './_models/users';
import { AccountService } from './_services/account.service';
import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  user:any
  constructor(private http: HttpClient, private accountService: AccountService){
  }
  ngOnInit(){
    this.getUsers();
    this.setCurrentUser();
  }

  setCurrentUser(){
    const user: User = JSON.parse(localStorage.getItem('user') || 'null');
    this.accountService.setCurrentUser(user);
  }
  getUsers(){
    this.http.get("https://localhost:5001/api/users").subscribe(res =>{
    },err =>{
      console.log(err);
    })
  }
}
