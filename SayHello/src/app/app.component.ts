import { Component } from '@angular/core';
import { GreetingService } from './greeting.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SayHello';
  constructor(private greetingservice: GreetingService, private snackBar: MatSnackBar) { }
  FirstName: string = "";
  LastName: string = "";
  // GreetingForm = new FormGroup({
  //   FirstName: new FormControl('', [Validators.required]),
  //   LastName: new FormControl('', [Validators.required]),
  // })

  postgreetings() {
    if (this.FirstName.length ==0 || this.LastName.length ==0 ) {
      this.openSnackBar("Enter Details", "ok")
    }
    else {



      const data = {
        firstName: this.FirstName,
        lastName: this.LastName
      }
      this.greetingservice.PostGreetings(data).subscribe((result) => {
        alert(result);
      })
    }
  }
  GetGreetings() {
    this.greetingservice.GetGreetings().subscribe((result) => {
      // alert(result
      this.openSnackBar(result, "ok")
    })
  }
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'top',
      horizontalPosition: 'center'
    });
  }

}
