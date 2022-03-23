import { Injectable } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { LoginComponent } from "../components/login/login.component";
import { AuthService } from "../services/auth.service";

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(
    private router: Router,
    private authService: AuthService,
    public dialog: MatDialog,
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    //check some condition
    if (!this.authService.userIsLogged()) {
      return false;
    }
    return true;
  }
}
