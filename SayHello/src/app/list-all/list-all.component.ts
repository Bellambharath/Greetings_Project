import { Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { GreetingService } from '../greeting.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-list-all',
  templateUrl: './list-all.component.html',
  styleUrls: ['./list-all.component.css']
})
export class ListAllComponent implements OnInit {
  Data: any;
  id: any;
  FirstName: string = "";
  LastName: string = "";


  constructor(private greetingservice: GreetingService, private snackBar: MatSnackBar,
    private elementRef: ElementRef, private renderer: Renderer2) { }
  ngOnInit(): void {
    this.GetGreetings();
  }

  GetGreetings() {
    this.greetingservice.GetGreetings().subscribe((result) => {
      this.Data = result

    })
  }
  EditDetails(details: any) {
    this.id = details.id;
    this.FirstName = details.firstName;
    this.LastName = details.lastName;
  }
  SaveChanges() {
    const data = {
      firstName: this.FirstName,
      lastName: this.LastName,
      id: this.id
    }
    this.greetingservice.EditGreetings(data).subscribe((result) => {
      console.log(result);
      this.greetingservice.GetGreetings().subscribe((result) => {
        this.Data = result;

        const closeButton = this.elementRef.nativeElement.querySelector('#myModal');


        closeButton.click();
      })
    })

  }
  DeleteGreetings(id: any) {
    this.greetingservice.DeleteGreetings(id).subscribe((result) => {
      console.log(result)
      this.greetingservice.GetGreetings().subscribe((res) => {
        this.Data = res;
        this.openSnackBar(result, "ok")

      })
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
