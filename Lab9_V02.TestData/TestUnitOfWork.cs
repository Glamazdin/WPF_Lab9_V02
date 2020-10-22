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
        private List<Group> groups;
        private List<Student> students;

        public TestUnitOfWork()
        {
            groups = new List<Group>();
            students = new List<Student>();
            groupsRepository = new GroupTestRepo(groups);
            foreach (var group in groups)
                students.AddRange(group.Students);
            studentsRepository = new StudentTestRepo(students);
        }

        public IRepository<Student> StudentsRepository =>
            studentsRepository;

        public IRepository<Group> GroupsRepository =>
            groupsRepository;

        public void SaveChanges()
        {
            
        }
    }
}
