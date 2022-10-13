import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService
    ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
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
      this.userService.login(this.form.value)
      .pipe(first())
      .subscribe({
          next: () => {
            console.log('elo');
            this.router.navigate(['/contacts']);
          },
          error: error => {
            this.loading = false;
            alert("Failed to login. Check console for more details.");
            this.loading = false;
          }
      });
    }

}
