using Lab9_V02.Domain.Entities;
using Lab9_V02.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_V02.TestData
{
    public class TestUnitOfWork : IUnitOfWork
    {
        private IRepository<Student> studentsRepository;
        private IRepository<Group> groupsRepository;

        public IRepository<Student> StudentsRepository =>
            studentsRepository ?? new StudentTestRepo();

        public IRepository<Group> GroupsRepository =>
            groupsRepository ?? new GroupTestRepo();

        public void SaveChanges()
        {
            
        }
    }
}
