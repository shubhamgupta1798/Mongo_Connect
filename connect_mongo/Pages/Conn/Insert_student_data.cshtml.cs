using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connect_mongo_data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace connect_mongo
{
    public class Insert_student_dataModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Roll_number { get; set; }
        private readonly data_transactions insert_Data;
        public Insert_student_dataModel(data_transactions insert_Data)
        {
            this.insert_Data = insert_Data;
        }
        public void OnPost()
        {
            if (String.IsNullOrEmpty(Name)|| String.IsNullOrEmpty(Roll_number))
            {
              //  return;
            }
            else
            {
                Student data = new Student(Name, Roll_number);
                Boolean temp = insert_Data.AddStudentdata(data);
                Response.Redirect("connection");
                }
          }
        public void OnGet()
        {          
           
        }
        
    }
}
