import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form!: FormGroup;
  submitted = false;
  loading = false;

  constructor(
    private userService: UserService,
    private router: Router,
    private formBuilder: FormBuilder
    ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      roles:[["User"]]
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {

    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;

    this.userService.register(this.form.value)
    .pipe(first())
    .subscribe({
        next: () => {
            this.router.navigate(['../login']);
        },
        error: error => {
            this.loading = false;
            alert("Failed to register. Check console for more details.");
            console.log(error);
        }
    });

  }
}
