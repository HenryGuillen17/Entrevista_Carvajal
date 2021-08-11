import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-tic-tac-toe',
  templateUrl: './tic-tac-toe.component.html',
  styleUrls: ['./tic-tac-toe.component.scss']
})
export class TicTacToeComponent implements OnInit {

  public table = ['', '', '', '', '', '', '', '', ''];
  public player1 = 'X';
  public player2 = '0';
  public shift = 'X';
  public viewWin = false;
  public viewWinPlayer = '';
  public goodCombination = [[1, 2, 3], [4, 5, 6], [7, 8, 9], [1, 4, 7], [2, 5, 8], [3, 6, 9], [3, 5, 7], [1, 5, 9]];
  public cellsAvailable = 0;

  constructor() {
  }

  ngOnInit(): void {
    this.clear();
  }

  public clickTable(index): void {
    if (this.table[index] === '' && !this.viewWin) {
      this.table[index] = this.shift;
      this.changeShift();
      this.whoIsWin();
    }
  }

  public changeShift(): void {
    if (this.shift === this.player1) {
      this.shift = this.player2;
    } else {
      this.shift = this.player1;
    }
    this.cellsAvailable++;
  }

  public clear(): void {
    this.table = ['', '', '', '', '', '', '', '', ''];
    this.shift = 'X';
    this.viewWin = false;
    this.viewWinPlayer = '';
    this.cellsAvailable = 0;
  }

  private whoIsWin(): void {
    if (this.winSamePlayer(this.player1)) {
      this.viewWinHtml(this.player1);
    } else if (this.winSamePlayer(this.player2)) {
      this.viewWinHtml(this.player2);
    } else if (this.cellsAvailable < 9) {
      return;
    } else {
      this.viewWinHtml('Nothing');
    }
  }

  private winSamePlayer(player: string): boolean {
    for (const item of this.goodCombination) {
      let b = true;
      for (let j = 0; j < 3; j++) {
        if (this.table[item[j] - 1] !== player) {
          b = false;
          break;
        }
      }
      if (b) {
        return true;
      }
    }
    return false;
  }

  private viewWinHtml(player: string): void {
    this.viewWin = true;
    this.viewWinPlayer = player;
  }
}
