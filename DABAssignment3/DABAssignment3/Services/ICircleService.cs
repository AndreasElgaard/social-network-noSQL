using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using MongoDB.Bson;

namespace DABAssignment3.Services
{
    public interface ICircleService
    {
        List<Circle> GetAll();
        Circle Get(ObjectId Id);

        Circle Create(Circle circle);

        void Update(ObjectId id, Circle circle);

        void Remove(Circle circle);
        void Remove(ObjectId id);

        void AddUserToCircle(ObjectId userId, ObjectId CircleId);
        void RemoveUserFromCicrle(ObjectId userId, ObjectId circleId);

    }
}
