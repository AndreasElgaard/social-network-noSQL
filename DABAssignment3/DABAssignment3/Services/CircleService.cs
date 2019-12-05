using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using MongoDB.Driver;

namespace DABAssignment3.Services
{
    public class CircleService : ICircleService
    {
        private readonly IMongoCollection<Circle> _circles;
        public CircleService()
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _circles = database.GetCollection<Circle>(settings.BooksCollectionName);

        }

        public List<Circle> GetAll() =>
            _circles.Find(book => true).ToList();

        public Circle Get(string Id) =>
            _circles.Find<Circle>(circle => circle.CircleId == Id).FirstOrDefault();

        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }

        public void Update(string id, Circle circle) =>
            _circles.ReplaceOne(circle => circle.CircleId == id, circle);

        public void Remove(Circle circleIn) =>
            _circles.DeleteOne(circle => circle.CircleId == circleIn.CircleId);

        public void Remove(string id) =>
            _circles.DeleteOne(circle => circle.CircleId == id);
    }
}
