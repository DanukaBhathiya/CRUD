import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Books } from 'src/app/model/books.model';
import { BooksService } from 'src/app/service/books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})

export class BooksComponent implements OnInit {

  bookList: any;
  constructor(public books_service:BooksService, public toasre:ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
    this.LoadAllBooks();
  }

  resetForm(form?:NgForm){
    if(form!=null)
    form.resetForm();
    this.books_service.formData={
      Id:0,
      BookCode:'',
      BookName:'',
      BookCount:0
    }
  }

  OnSubmit(form:NgForm){
    console.log("clicked")
    if(this.books_service.formData.Id==0){
      //---Id==0-->Insert
      this.InsertBooks();
    }else{
      //---Id!=0-->Update
      this.UpdateBooks();
    }
    this.resetForm();
  }

  LoadAllBooks(){
    this.books_service.loadBooks().subscribe(
      data=>{
        this.bookList=data as Books[];
        console.log(this.bookList);
      }
    )
  }

  InsertBooks(){
    this.books_service.insertBooks().subscribe(
      (res:any)=>{
        console.log("success");
        this.toasre.success("Record Inserted Successfully","Books Registration");
        this.LoadAllBooks();
      },
      err=>{
        console.log("failed");
        this.toasre.warning("Record Inserted Failed","Books Registration");
        console.log(err);
      }
    )
  }

  UpdateBooks(){
    this.books_service.updateBooks().subscribe(
      (res:any)=>{
        this.toasre.info("Record Update Successfully","Books Registration");
        this.LoadAllBooks();
      },
      err=>{
        this.toasre.warning("Record Update Failed","Books Registration");
        console.log(err);
      }
    )
  }

  populateForm(book:Books){
    this.books_service.formData = Object.assign({},book);
  }

  DeleteBook(Id: any){
    console.log(Id)
    if(confirm('Are You Sure'))
    this.books_service.deleteBook(Id).subscribe(
      (res:any)=>{
        this.toasre.success("Record Delete Successfully","Books Registration");
        this.LoadAllBooks();
      },
      err=>{
        this.toasre.warning("Record Delete Failed","Books Registration");
        console.log(err);
      }
    )
  }

}
