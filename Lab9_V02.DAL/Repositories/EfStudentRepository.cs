using Lab9_V02.DAL.Data;
using Lab9_V02.Domain.Entities;
using Lab9_V02.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_V02.DAL.Repositories
{
    class EfStudentRepository : IRepository<Student>
    {
        private readonly CourcesContext context;
        private readonly DbSet<Student> students;

        public EfStudentRepository(CourcesContext context)
        {
            this.context = context;
            students = this.context.Students;
        }
        public void Create(Student student)
        {
            students.AddAsync(student);
        }

        public bool Delete(int id)
        {
            var student = students.Find(id);
            if (student == null) return false;
            if (student.GroupId > 0)
            {
                context.Groups
                      .Find(student.GroupId)
                      .Students
                      .Remove(student);
            };
            students.Remove(student);
            return true;
        }

        public IQueryable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            return students.Where(predicate);
        }

        public Student Get(int id, params string[] includes)
        {
            var include = includes.Aggregate((a,b)=>$"{a}.{b}");
            return students
                            .Include(include)
                            .First(s => s.StudentId == id);                                                    
        }

        public IQueryable<Student> GetAll()
        {
            return students.AsQueryable();                                              
        }

        public void Update(Student student)
        {
            context.Entry<Student>(student).State=EntityState.Modified;            
        }
    }
}
