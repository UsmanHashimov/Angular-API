import { Component, OnInit } from '@angular/core';
import { CrudService } from '../../services/crud.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-getall',
  templateUrl: './getall.component.html',
  styleUrl: './getall.component.css'
})
export class GetallComponent implements OnInit {

  users! : User[]

  constructor(private crudService: CrudService) { }

  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers() {
    this.crudService.getAll().subscribe({
      next: (data) => {
        this.users = data;

        console.log(data);
      },

      error: (err) => {
        console.log(err)
      }
    })
  }
}
