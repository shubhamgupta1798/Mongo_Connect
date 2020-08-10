using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace connect_mongo_data
{
    public interface data_transactions
    {
        Boolean AddStudentdata(Student student);
        Boolean DeleteStudentdata(String _id);
    }
    public class Data_trans : data_transactions
    {
        public Data_trans(){
        }
        public Boolean AddStudentdata(Student student)
        {
            var connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var student_coll = database.GetCollection<BsonDocument>("student");
            student_coll.InsertOneAsync(student.ToBsonDocument());
            return true;
        }
        public Boolean DeleteStudentdata(String _id)
        {
          var deleteFilter = Builders<BsonDocument>.Filter.Eq("name", _id);
            var connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            var student_coll = database.GetCollection<BsonDocument>("student");
            student_coll.DeleteOne(deleteFilter);
            return true;
        }
    }
    
}
