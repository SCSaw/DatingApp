import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { Toast, ToastrService } from 'ngx-toastr';
import { MembersService } from '../_services/members.service';
import { Member } from '../_models/member';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  members: Member | undefined;
  // currentUser$: Observable<User | null> = of(null);

  constructor(public accountService: AccountService, private router: Router, 
    private toastr: ToastrService){ }

  ngOnInit(): void {
    // this.currentUser$ = this.accountService.currentUser$;
  }

  login(){
    this.accountService.login(this.model).subscribe({
      next: () => this.router.navigateByUrl('/members'),
      //can set userparam here to reset filter after relogin with other gender
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
