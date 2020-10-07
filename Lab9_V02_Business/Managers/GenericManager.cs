using AutoMapper;
using Lab9_V02.Domain.Entities;
using Lab9_V02.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lab9_V02_Business.Managers
{
    public class BasicManager
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IRepository<Student> studentRepository;
        protected readonly IRepository<Group> groupRepository;       
        public BasicManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;           
            studentRepository = unitOfWork.StudentsRepository;
            groupRepository = unitOfWork.GroupsRepository;
        }

        //#region bacic CRUD operations
        //public Student CreateStudent(Student student)
        //{
        //    studentRepository.Create(student);
        //    unitOfWork.SaveChanges();
        //    return student;
        //}
        //public bool DeleteStudent(int id)
        //{
        //    var result = studentRepository.Delete(id);
        //    if (!result) return false;
        //    unitOfWork.SaveChanges();
        //    return true;
        //}
        //public IQueryable<T> FindStudent(Expression<Func<T, bool>> predicate) =>
        //    studentRepository.Find(predicate);

        //public Student GetStudentById(int id) =>
        //    studentRepository.Get(id);

        //public IQueryable<Student> GetAllStudents() =>
        //    studentRepository.GetAll();
        //public void UpdateStudent(Student student)
        //{
        //    studentRepository.Update(student);
        //    unitOfWork.SaveChanges();
        //}
        //#endregion


    }
}
