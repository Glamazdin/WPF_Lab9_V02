using AutoMapper;
using Lab9_V02.Domain.Managers;
using Lab9_V02_Business.DTO;
using Lab9_V02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_V02_Business.Services
{
    public class GroupService
    {
        private readonly GroupManager groupManager;
        private readonly IMapper mapper;

        public GroupService(GroupManager groupManager, IMapper mapper)
        {
            this.groupManager = groupManager;
            this.mapper = mapper;
        }

        #region bacic CRUD operations
        public GroupDTO CreateGroup(GroupDTO groupDto)
        {
            var group = mapper.Map<Group>(groupDto);
            group = groupManager.CreateGroup(group);
            return mapper.Map<GroupDTO>(group);

        }
        public bool DeleteGroup(int id)
        {
            return groupManager.DeleteGroup(id);
        }


        public GroupDTO GetGroupById(int id)
        {
            var group = groupManager.GetGroupById(id);
            return mapper.Map<GroupDTO>(group);
        }

        public List<GroupDTO> GetAllGroups()
        {
            var groups = groupManager.GetAllGroups();
            return mapper.Map<List<GroupDTO>>(groups);
        }

        public void UpdateGroup(GroupDTO groupDTO)
        {
            var group = mapper.Map<Group>(groupDTO);
            groupManager.UpdateGroup(group);
        }
        #endregion      

        public IEnumerable<StudentDTO> GetStudentsByGroup(int id)
        {
            var students = groupManager.GetStudentsOfGroup(id);
            return mapper.Map<IEnumerable<StudentDTO>>(students);
        }

    }
}
