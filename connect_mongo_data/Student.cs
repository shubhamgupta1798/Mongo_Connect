using System;
namespace connect_mongo_data
{
    public class Student
    {
        
            public Student(String name,String roll_number)
        {
            this.name = name;
            this.roll_number = roll_number;
        }
       

        public string name { get; set; }
            public string roll_number { get; set; }
        
    }
}
