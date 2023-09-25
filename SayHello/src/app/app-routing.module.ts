import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListAllComponent } from './list-all/list-all.component';
import { AddDataComponent } from './add-data/add-data.component';

const routes: Routes = [ 
  {path:'',redirectTo:'/adddata',pathMatch:'full'},
  { path: 'listall', component: ListAllComponent },
  { path: 'adddata', component: AddDataComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})



export class AppRoutingModule { }
