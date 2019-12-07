using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using DABAssignment3.Models.Dto;
using MongoDB.Bson;

namespace DABAssignment3.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        User Get(ObjectId Id);

        User FindByName(string Name);

        User Create(User User);

        void Update(ObjectId id, User User);

        void Remove(User User);
        void Remove(ObjectId id);

        string BlockUser(string UserName, string BlockUser);
        string SubsribeToUser(string UserName, string subscribeName);
        string UnSubsribeToUser(string UserName, string subscribeName);
        string UnBlockUser(string UserName, string BlockUser);

    }
}
