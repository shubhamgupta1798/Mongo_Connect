using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace connect_mongo_data
{
    public interface Student_data
    {
        IEnumerable<Student> GetStudentByName(String name);
    }
    public class GetData1 : Student_data
    {
        List<Student> students;
        public GetData1()
        {
            var connectionString = new Conn_String().mongo_conn;
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var student = database.GetCollection<BsonDocument>("student");
            var documents = student.Find(new BsonDocument()).ToList();
           
            students = new List<Student>() {};
            foreach (BsonDocument doc in documents)
            {
                Student temp = new Student ( doc["name"].ToString(), doc["roll_number"].ToString() );
                students.Add(temp);
            }
           
             
        }
        
        public IEnumerable<Student> GetStudentByName(String name=null)
        {
            Console.WriteLine(name);
            return from r in students where string.IsNullOrEmpty(name)||r.name.StartsWith(name) select r;
        }
    }
}

