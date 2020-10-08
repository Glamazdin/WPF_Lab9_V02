using Lab9_V02.Domain.Entities;
using Lab9_V02.Domain.Interfaces;
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
        public void CreateGroup(List<Group> groups)
        {
            groups.ForEach(g => groupRepository.Create(g));  //groups. f groupRepository.Create(group);
            unitOfWork.SaveChanges();            
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

        public ICollection<Student> AddStudentToGroup(Student student, int groupId, bool hasDiscount)
        {            
            var group = groupRepository.Get(groupId, "Students");
            student.IndividualPrice = hasDiscount
                ? group.BasePrice * (decimal)0.8
                : group.BasePrice;
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
