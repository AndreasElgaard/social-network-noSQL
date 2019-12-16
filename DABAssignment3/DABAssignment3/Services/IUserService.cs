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
        User Get(string Id);

        User FindByName(string Name);

        User Create(User User);

        void Update(string id, User User);

        void Remove(User User);
        void Remove(string id);

        string BlockUser(string UserName, string BlockUser);
        string SubsribeToUser(string UserName, string subscribeName);
        string UnSubsribeToUser(string UserName, string subscribeName);
        string UnBlockUser(string UserName, string BlockUser);

    }
}
