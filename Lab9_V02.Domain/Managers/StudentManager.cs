using Lab9_V02.Domain.Entities;
using Lab9_V02.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_V02.Domain.Managers
{
    public class StudentManager : BasicManager
    {
        public StudentManager(IUnitOfWork untOfWork) : base(untOfWork)
        {
        }
        #region bacic CRUD operations
        public Student CreateStudent(Student student)
        {
            studentRepository.Create(student);
            unitOfWork.SaveChanges();
            return student;
        }
        public bool DeleteStudent(int id)
        {                      
            var result = studentRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }
        public IQueryable<Student> FindStudent(Expression<Func<Student, bool>> predicate) =>
            studentRepository.Find(predicate);

        public Student GetStudentById(int id) =>
            studentRepository.Get(id);

        public IQueryable<Student> GetAllStudents() =>
            studentRepository.GetAll();
        public void UpdateStudent(Student student)
        {
            studentRepository.Update(student);
            unitOfWork.SaveChanges();
        }
        #endregion      

    }
}
