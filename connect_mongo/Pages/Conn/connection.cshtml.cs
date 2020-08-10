using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using connect_mongo_data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Driver;

namespace connect_mongo.Pages.Shared.Conn
{
  //  private readonly GetAll m1;
  
    public class connectionModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
     
        public IEnumerable<Student> Students { get; set; }
        private readonly Student_data student_data;
        private readonly data_transactions delete_data;
        [BindProperty]
        public string NAME { get; set; }

        public connectionModel(Student_data student_data,data_transactions delete_data)
        {          
            this.student_data = student_data;
            this.delete_data = delete_data;
        }
        public void OnGet()
        {
             Students = student_data.GetStudentByName(SearchTerm);
        }
        public void OnPost()
        {
            delete_data.DeleteStudentdata(NAME);
            Students = student_data.GetStudentByName(SearchTerm);
            Response.Redirect("connection",true);
        }

    }
}
