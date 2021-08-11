import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TicTacToeComponent} from './tic-tac-toe/tic-tac-toe.component';
import {LoginComponent} from './login/login.component';

const routes: Routes = [
  {path: '', redirectTo: 'login/login.component', pathMatch: 'full'},
  {path: 'login/login.component', component: LoginComponent},
  {path: 'tictactoe', component: TicTacToeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
