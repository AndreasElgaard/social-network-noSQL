using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using DABAssignment3.Models.SocialnetworkSettings;
using MongoDB.Driver;

namespace DABAssignment3.Services
{
    public class CircleService : ICircleService
    {
        private readonly IMongoCollection<Circle> _circles;
        public CircleService(ISocialnetworkDBsettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _circles = database.GetCollection<Circle>(settings.CircleCollectionName);

        }

        public List<Circle> GetAll() =>
            _circles.Find(circle => true).ToList();

        public Circle Get(string Id) =>
            _circles.Find<Circle>(circle => circle.CircleId.ToString() == Id).FirstOrDefault();

        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }

        public void Update(string id, Circle circle) =>
            _circles.ReplaceOne(circle => circle.CircleId.ToString() == id, circle);

        public void Remove(Circle circleIn) =>
            _circles.DeleteOne(circle => circle.CircleId == circleIn.CircleId);

        public void Remove(string id) =>
            _circles.DeleteOne(circle => circle.CircleId.ToString() == id);

        public void AddUserToCircle(string userId, string CircleId)
        {
           var result = _circles.Find(s => s.CircleId.ToString() == CircleId).SingleOrDefault();

           result.UserId.Add(userId);

           Update(CircleId, result);
        }

        public void RemoveUserFromCicrle(string userId, string circleId)
        {
            var result = _circles.Find(s => s.CircleId.ToString() == circleId).SingleOrDefault();

            result.UserId.Remove(userId);

            Update(circleId, result);
        }
    }
}
