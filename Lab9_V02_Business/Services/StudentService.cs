using AutoMapper;
using Lab9_V02.Domain.Entities;
using Lab9_V02.Domain.Managers;
using Lab9_V02_Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_V02_Business.Services
{
    public class StudentService
    {
        private readonly StudentManager studentManager;
        private readonly IMapper mapper;

        public StudentService(StudentManager studentManager, IMapper mapper)
        {
            this.studentManager = studentManager;
            this.mapper = mapper;
        }

        #region bacic CRUD operations
        public StudentDTO CreateStudent(StudentDTO studentDto)        {
            var student = mapper.Map<Student>(studentDto);            
            student = studentManager.CreateStudent(student);
            return mapper.Map<StudentDTO>(student);
            
        }
        public bool DeleteStudent(int id)
        {
            return studentManager.DeleteStudent(id);            
        }       
           

        public StudentDTO GetStudentById(int id)
        {
            var student = studentManager.GetStudentById(id);
            return mapper.Map<StudentDTO>(student);
        }
            
        public IQueryable<StudentDTO> GetAllStudents()
        {
            var students = studentManager.GetAllStudents();
            return mapper.Map<IQueryable<StudentDTO>>(students);
        }
            
        public void UpdateStudent(StudentDTO studentDTO)
        {
            var student = mapper.Map<Student>(studentDTO);
            studentManager.UpdateStudent(student);            
        }
        #endregion      

    }
}
