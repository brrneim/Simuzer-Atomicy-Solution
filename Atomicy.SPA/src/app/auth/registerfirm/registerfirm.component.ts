import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AlertService } from '../../../core/services/alert.service';
import { AuthenticationService } from '../../../core/services/authentication.service';


@Component({ templateUrl: 'registerfirm.component.html' })
export class RegisterfirmComponent implements OnInit {
    registerForm!: any;
    loading = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
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
        this.registerForm = this.formBuilder.group({
            firmName: ['', Validators.required],            
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            username: ['', Validators.required],
            email: ['', [Validators.email, Validators.required]],
            password: ['', [Validators.required, Validators.minLength(6)]]
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }

    onSubmit() {
        this.submitted = true;
        // stop here if form is invalid
        debugger;
        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;
        this.authenticationService.register(this.registerForm.value,true)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate(['/auth/login']);
                },
                error => {
                  if (error.error.errors && error.error.errors.UserName) {
                        this.alertService.error(error.error.errors.UserName);
                  }
                  else if(error.error){
                    this.alertService.error("Invalid Password!");
                  }
                    this.loading = false;
                });
    }
}
