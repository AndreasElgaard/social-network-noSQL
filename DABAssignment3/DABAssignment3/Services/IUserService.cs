using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;

namespace DABAssignment3.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        User Get(string Id);

        User Create(User User);

        void Update(string id, User User);

        void Remove(User User);
        void Remove(string id);
    }
}
