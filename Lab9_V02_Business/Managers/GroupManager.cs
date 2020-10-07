using AutoMapper;
using Lab9_V02.Domain.Entities;
using Lab9_V02.Domain.Interfaces;
using Lab9_V02_Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_V02_Business.Managers
{
    public class GroupManager:BasicManager
    {
        public GroupManager(IUnitOfWork untOfWork) : base(untOfWork)
        {
        }
        
        public IEnumerable<Group> Groups
        {
            get => groupRepository.GetAll();
        }


        public Group GetById(int id) => groupRepository.Get(id);
           

        public Group CreateGroup(Group group)
        {            
            groupRepository.Create(group);
            unitOfWork.SaveChanges();
            return group;
        }
        public bool DeleteGroup(int id)
        {
            var result = groupRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }      
        public void UpdateGroup(Group group)
        {
            groupRepository.Update(group);
            unitOfWork.SaveChanges();            
        }

        public ICollection<Student> AddStudentToGroup(Student student, int groupId)
        {
            var group = groupRepository.Get(groupId, "Students");
            group.Students.Add(student);
            groupRepository.Update(group);
            unitOfWork.SaveChanges();
            return group.Students;
        }
        public ICollection<Student> RemoveStudentFromGroup(Student student, int groupId)
        {
            var group = groupRepository.Get(groupId, "Students");
            group.Students.Remove(student);
            groupRepository.Update(group);
            unitOfWork.SaveChanges();
            return group.Students;
        }
        public ICollection<Student> GetStudentsOfGroup(int groupId)
        {
            var group = groupRepository.Get(groupId, "Students");
            return group.Students;
        }
    }
}
