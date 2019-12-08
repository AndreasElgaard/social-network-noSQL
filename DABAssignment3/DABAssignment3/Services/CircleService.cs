using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using DABAssignment3.Models.SocialnetworkSettings;
using MongoDB.Bson;
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
            _circles.Find<Circle>(circle => circle.CircleId == Id).FirstOrDefault();

        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }

        public void Update(string id, Circle circle)
        {
            _circles.ReplaceOne(circle => circle.CircleId.Equals(id), circle);
        }

        public void Remove(Circle circleIn) =>
            _circles.DeleteOne(circle => circle.CircleId == circleIn.CircleId);

        public void Remove(string id) =>
            _circles.DeleteOne(circle => circle.CircleId == id);

        public void AddUserToCircle(string userId, string CircleId)
        {
           var result = _circles.Find(s => s.CircleId == CircleId).SingleOrDefault();

           result.UserId.Add(userId);

           Update(CircleId, result);
        }

        public void RemoveUserFromCicrle(string userId, string circleId)
        {
            var result = _circles.Find(s => s.CircleId == circleId).SingleOrDefault();

            result.UserId.Remove(userId);

            Update(circleId, result);
        }

        private ObjectId GetInternalId(string Id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(Id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
    }
}
