using Lab9_V02_Business.DTO;
using Lab9_V02_Business.Infrastructure;
using Lab9_V02_Business.Services;
using Lab9_V02.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab9_V02.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        ServiceFactory factory;
        GroupService groupService;
        #region Public properties
        public ObservableCollection<GroupDTO> Groups { get; set; }
        public ObservableCollection<StudentDTO> Students { get; set; }
        public string Title { get => title; set => title = value; }

        #region Выбранная группа
        private GroupDTO _selectedGroup;
        public GroupDTO SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                Set(ref _selectedGroup, value);
            }
        }
        #endregion
        #endregion

        #region Commands

        #region Выбор группы в списке
        private ICommand _selectGroupCommand;
        public ICommand SelectGroupCommand =>
            _selectGroupCommand ?? new RelayCommand(OnGroupSelectedExecuted);

        private void OnGroupSelectedExecuted(object id)
        {                  
            Students.Clear();
            var students = groupService.GetStudentsByGroup((int)id);
            foreach (var student in students)
            Students.Add(student);  
        }
        #endregion





        #endregion

        private string title = "Groups Window";
        public MainWindowViewModel()
        {
            factory = new ServiceFactory("DefaultConnection");
            groupService = factory.GetGroupService();
            Groups = new ObservableCollection<GroupDTO>(groupService.GetAllGroups());
            Students = new ObservableCollection<StudentDTO>();
            if(Groups.Count>0)
                OnGroupSelectedExecuted(Groups[0].GroupId);
        }
    }
}
