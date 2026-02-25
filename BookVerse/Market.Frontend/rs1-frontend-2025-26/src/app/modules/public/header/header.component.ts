import { Component, ElementRef, inject, OnInit, viewChild, ViewChild } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CurrentUserService } from '../../core/services/auth/current-user.service';
import { AuthFacadeService } from '../../core/services/auth/auth-facade.service';

@Component({
  selector: 'app-header',
  imports: [RouterLink],
  templateUrl: './header.component.html',
  styleUrl: 'header.component.css',
})
export class HeaderComponent{
  @ViewChild('dropMenu') dropMenu!: ElementRef;
  @ViewChild('userName') userName!:ElementRef;

  router = inject(Router);
  dropMenuOpened = false;
  authFacadeService = inject(AuthFacadeService);

  showDropMenu() {
    console.log(this.dropMenu);
    if (!this.dropMenuOpened) {
      this.dropMenu.nativeElement.style.height = '455px';
    } else {
      this.dropMenu.nativeElement.style.height = '0px';
    }
    this.dropMenuOpened = !this.dropMenuOpened;
  }

  // ngOnInit(): void {
  //   if(this.userService.isAuthenticated()){
  //     this.userName.nativeElement.innerText=this.userService.currentUser()?.email??'';
  //   }
  // }

  prijavaIliDropDown(){
    
    console.log(this.authFacadeService.isAuthenticated());
    if(!this.authFacadeService.isAuthenticated())
      this.router.navigate(["/auth/login"]);
    else {
      this.showDropMenu();
    }
  }

}
