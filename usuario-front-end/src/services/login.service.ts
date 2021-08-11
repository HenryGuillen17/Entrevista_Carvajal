import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {LoginModel} from '../models/loginModel';
import {Observable} from 'rxjs';
import {TokenModel} from '../models/TokenModel';

@Injectable()
export class LoginService {
  private serviceMainRoute = 'https://localhost:44387/Login';

  constructor(private httClient: HttpClient) {
  }

  login(credential: LoginModel): Observable<TokenModel> {
    return this.httClient.post(this.serviceMainRoute, credential).pipe(map(res => res as TokenModel));
  }
}
