import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GreetingService } from '../greeting.service';

@Component({
  selector: 'app-add-data',
  templateUrl: './add-data.component.html',
  styleUrls: ['./add-data.component.css']
})
export class AddDataComponent {

  constructor(private greetingservice: GreetingService, private snackBar: MatSnackBar) { }
  id:any;
  FirstName: string = "";
  LastName: string = "";
 
  postgreetings() {
    if (this.FirstName.length ==0 || this.LastName.length ==0 ) {
      this.openSnackBar("Enter Details", "ok")
    }
    else {

      const data = {
        greetingsId:this.id,
        firstName: this.FirstName,
        lastName: this.LastName
      }
      this.greetingservice.PostGreetings(data).subscribe((result) => {
        
        this.openSnackBar(result, "ok")
      })
    }
  }
  GetGreetings() {
    this.greetingservice.GetGreetings().subscribe((result) => {
     
      this.openSnackBar(result, "ok")
    })
  }
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
      verticalPosition: 'bottom',
      horizontalPosition: 'center'
    });
  }

}
