using LMSWebAPI.DataAccess;
using LMSWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        [HttpGet]
        [Route("Books")]
        public List<Books> LoadBooks()
        {
            List<Books> books = BooksManage.GetAllBooks();
            return books;
        }

        [HttpPost]
        [Route("Books")]
        public IActionResult AddBooks(Books books)
        {
            try
            {
                if (BooksManage.InsertBooks(books) == true)
                {
                    return Ok(new { message = "Inserted" });
                }
                else
                {
                    return BadRequest(new { message = "Error" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        [Route("Books/{id}")]
        public IActionResult UpdateBooks(int id,Books book)
        {
            try
            {
                if (BooksManage.UpdateBooks(id, book) == true)
                {
                    return Ok(new { message = "Updated" });
                }
                else
                {
                    return BadRequest(new { message = "Not Update" });
                }
            }
            catch (Exception ex)
            {

                //throw ex;
                return BadRequest(new { message = "Error" });
            }
        }

        [HttpDelete]
        [Route("Books/{id}")]
        public IActionResult DeleteBooks(int id)
        {
            try
            {
                if (BooksManage.DeleteBooka(id) == true)
                {
                    return Ok(new { message = "Deleted" });
                }
                else
                {
                    return BadRequest(new { message = "Not Delete" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error" });
                throw ex;
            }
        }
    }
}
