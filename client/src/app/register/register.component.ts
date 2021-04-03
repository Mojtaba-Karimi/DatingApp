import { AccountService } from './../_services/account.service';
import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister =  new EventEmitter();
  model: any = {};
  users:any;
  constructor(private http:HttpClient,private account:AccountService,private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  register(){
    this.account.register(this.model).subscribe((res)=>{
      this.cancel();
    },err => {
      this.toastr.error(err.error);
    })
  }

  cancel(){
    this.cancelRegister.emit(false);
  }

}
