using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;

namespace DABAssignment3.Services
{
    public interface ICircleService
    {
        List<Circle> GetAll();
        Circle Get(string Id);

        Circle Create(Circle circle);

        void Update(string id, Circle circle);

        void Remove(Circle circle);
        void Remove(string id);
    }
}
