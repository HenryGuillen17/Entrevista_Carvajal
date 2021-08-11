import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {LoginService} from '../../services/login.service';
import {Router} from '@angular/router';
import {LoginModel} from '../../models/loginModel';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {


  public usersForm: FormGroup;
  public formSubmitted = false;

  get userFormControls(): any {
    return this.usersForm.controls;
  }

  constructor(
    private fBuilder: FormBuilder,
    private loginService: LoginService,
    private route: Router
  ) {
  }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.usersForm = this.fBuilder.group({
      email: ['hola@example.com',
        [
          Validators.required,
          Validators.maxLength(50)
        ]],
      password: ['Hola$123', [Validators.maxLength(20)]],
    });
  }

  public onSubmit(): void {
    this.formSubmitted = true;
    if (this.usersForm.valid) {
      this.formSubmitted = false;
      const user = new LoginModel();
      user.email = this.userFormControls.email.value;
      user.password = this.userFormControls.password.value;
      this.login(user);
    }
  }

  private login(userModel: LoginModel): void {
    this.loginService.login( userModel ).subscribe( res => {
      if (!res) {
        this.clearModels();
        this.showErrorMessage('Error', 'Login Error').then();
      } else {
        this.showSuccessMessage('Success', 'Login Success')
          .then(() => this.route.navigate(['tictactoe']));
        console.log(res);
      }
    });
  }

  private clearModels(): void {
    this.usersForm.reset();
    this.initForm();
  }

  private showSuccessMessage(title: string, msg: string): Promise<any> {
    return Swal.fire({
      title,
      text: msg,
      icon: 'success',
      showCancelButton: false,
      confirmButtonColor: '#28a745'
    });
  }

  private showErrorMessage(title: string, msg: string): Promise<any> {
    return Swal.fire({
      title,
      text: msg,
      icon: 'error',
      showCancelButton: false,
      confirmButtonColor: '#d33'
    });
  }

}
