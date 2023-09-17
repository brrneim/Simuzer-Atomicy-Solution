import { Component, OnInit ,Input, ChangeDetectionStrategy, EventEmitter, Output} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../../../core/services/authentication.service';
import { AlertService } from '../../../core/services/alert.service';

@Component({ templateUrl: 'login.component.html',
changeDetection: ChangeDetectionStrategy.OnPush })
export class LoginComponent implements OnInit {
  loginForm: any ;
  loading = false;
  submitted = false;
  returnUrl: string | undefined;



  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private alertService: AlertService
  ) {

    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue && this.authenticationService.currentUserValue.username) {
      this.router.navigate(['/']);
    }
  }
 
  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/demand/demands';
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }
 
  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    debugger;
    this.authenticationService.login(this.f.username.value, this.f.password.value)
      .pipe(first())
      .subscribe(
        data => {
          debugger;
          this.router.navigate([this.returnUrl]);         
        },
        error => {
          if (error && error.error && error.error.error) {
            this.alertService.error(error.error.error);
          }
          this.loading = false;
        });
  }
}
