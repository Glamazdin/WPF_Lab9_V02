using Lab9_V02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_V02.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Student> StudentsRepository { get;}
        IRepository<Group> GroupsRepository { get; }   
        

        void SaveChanges();

    }
}
