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
    public class GroupManager:BaseManager
    {
        public GroupManager(IUnitOfWork untOfWork) : base(untOfWork)
        {
        }
        /// <summary>
        /// Общий список групп
        /// </summary>
        public IEnumerable<Group> Groups
        {
            get => groupRepository.GetAll();
        }


        public Group GetById(int id) => groupRepository.Get(id);
           
        // Создание группы
        public Group CreateGroup(Group group)
        {            
            groupRepository.Create(group);
            unitOfWork.SaveChanges();
            return group;
        }
        /// <summary>
        /// Добавление групп из списка
        /// </summary>
        /// <param name="groups"></param>
        public void AddRange(List<Group> groups)
        {
            groups.ForEach(g => groupRepository.Create(g));
            unitOfWork.SaveChanges();            
        }
        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="id">Id удаляемой группы</param>
        /// <returns></returns>
        public bool DeleteGroup(int id)
        {
            var result = groupRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }  
        /// <summary>
        /// Редактирование группы
        /// </summary>
        /// <param name="group">Обновленный объект группы</param>
        public void UpdateGroup(Group group)
        {
            groupRepository.Update(group);
            unitOfWork.SaveChanges();            
        }
        /// <summary>
        /// Добавление студента в группу
        /// </summary>
        /// <param name="student">Добавляемый объект</param>
        /// <param name="groupId">Id группы</param>
        /// <param name="hasDiscount">Наличие скидки у студента</param>
        /// <returns></returns>
        public void AddStudentToGroup(Student student, int groupId, bool hasDiscount)
        {            
            var group = groupRepository.Get(groupId);
            student.IndividualPrice = hasDiscount
                ? group.BasePrice * (decimal)0.8
                : group.BasePrice;
            //group.Students.Add(student);
            student.GroupId = groupId;
            if (student.StudentId <= 0)
                studentRepository.Create(student);
            else studentRepository.Update(student);
            unitOfWork.SaveChanges();            
        }
        /// <summary>
        /// Удаление студента из группы
        /// </summary>
        /// <param name="student">Удаляемый объект</param>
        /// <param name="groupId">Id группы</param>
        public void RemoveStudentFromGroup(Student student, int groupId)
        {
            var group = groupRepository.Get(groupId, "Students");
            group.Students.Remove(student);
            student.IndividualPrice = 0;
            groupRepository.Update(group);
            studentRepository.Update(student);
            unitOfWork.SaveChanges();            
        }
        /// <summary>
        /// Получение списка студентов группы
        /// </summary>
        /// <param name="groupId">Id группы</param>
        /// <returns></returns>
        public ICollection<Student> GetStudentsOfGroup(int groupId)
        {
            var group = groupRepository.Get(groupId, "Students");
            return group.Students;
        }
    }
}
