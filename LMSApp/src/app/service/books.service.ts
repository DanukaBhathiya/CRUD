import { Injectable } from '@angular/core';
import { Books } from '../model/books.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  readonly rootURL='https://localhost:44369/api/';
  formData: Books;
  constructor(private http:HttpClient) { }

  //---------Insert------------
  insertBooks(){
    console.log(this.formData)
    return this.http.post(this.rootURL+'Books/Books',this.formData);
  }

  //---------Update------------
  updateBooks(){
    //------UpdateURL ==> https://localhost:44369/api/Books/Books/id
    console.log(this.formData)
    return this.http.put(this.rootURL+'Books/Books/'+this.formData.Id,this.formData);
  }

  //---------Read/View----------
  loadBooks(){
    return this.http.get(this.rootURL+'Books/Books');
  }

  //---------Delete------------
  deleteBook(Id: string){
    return this.http.delete(this.rootURL+'Books/Books/'+Id)
  }
}


