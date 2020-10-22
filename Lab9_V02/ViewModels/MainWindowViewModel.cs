using Lab9_V02_Business.Infrastructure;
using Lab9_V02.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab9_V02_Business.Managers;
using Lab9_V02.Domain.Entities;
using System.Windows;
using System.Linq;

namespace Lab9_V02.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        ManagersFactory factory;
        GroupManager groupManager;
        #region Public properties
        /// <summary>
        /// Список групп
        /// </summary>
        public ObservableCollection<Group> Groups { get; set; }
        /// <summary>
        /// Список студентов группы
        /// </summary>
        public ObservableCollection<Student> Students { get; set; }
        public string Title { get => title; set => title = value; }

        #region Выбранная группа
        private Group _selectedGroup;
        public Group SelectedGroup
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
        private ICommand _getStudentsCommand;
        public ICommand GetStudentsCommand =>
            _getStudentsCommand ?? new RelayCommand(OnGetStudentExecuted);

        /// <summary>
        /// делегат для метода Execute команды GetStudentsCommand
        /// </summary>
        /// <param name="id">Id группы</param>
        private void OnGetStudentExecuted(object id)
        {                  
            Students.Clear();
            var students = groupManager.GetStudentsOfGroup((int)id);
            foreach (var student in students)
                Students.Add(student);
        }
        #endregion
        #endregion

        private string title = "Groups Window";
        public MainWindowViewModel()
        {
            //factory = new ManagersFactory("DefaultConnection");
            //groupManager = factory.GetGroupManager();
            ////Инициализация базы данных
            //if (groupManager.Groups.Count() == 0) 
            //    DbTestData.SetupData(groupManager);
            //Groups = new ObservableCollection<Group>(groupManager.Groups);
            //Students = new ObservableCollection<Student>();
            ////Получение списка студентов для первой группы
            //if (Groups.Count > 0)
            //    OnGetStudentExecuted(Groups[0].GroupId);

            factory = new ManagersFactory();
            groupManager = factory.GetGroupManager();
            Groups = new ObservableCollection<Group>(groupManager.Groups);
            Students = new ObservableCollection<Student>();
        }
    }
}
