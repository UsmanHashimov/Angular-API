import { NgModule, createComponent } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetallComponent } from './components/getall/getall.component';
import { GetByIdComponent } from './components/get-by-id/get-by-id.component';
import { UpdateComponent } from './components/update/update.component';
import { DeleteComponent } from './components/delete/delete.component';
import { CreateComponent } from './components/create/create.component';

const routes: Routes = [
  { path: 'home', redirectTo: 'getall', pathMatch: 'full' },
  { path: '', redirectTo: 'getall', pathMatch: 'full' },
  { path: 'getall', component: GetallComponent },
  { path: 'get-by-id', component: GetByIdComponent },
  { path: 'create', component: CreateComponent },
  { path: 'update', component: UpdateComponent },
  { path: 'delete', component: DeleteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
