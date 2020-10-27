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
using System.IO;

namespace Lab9_V02.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        ManagersFactory factory;
        GroupManager groupManager;
        StudentManager studentManager;
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

        #region Выбранный студент
        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                Set(ref _selectedStudent, value);
            }
        }
        #endregion
        #endregion

        #region Commands
        #region Получение списка студентов группы
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

        #region Добавление студента
        private ICommand _newStudentCommand;
        public ICommand NewStudentCommand =>
            _newStudentCommand??new RelayCommand(OnNewStudentExecuted);

        private void OnNewStudentExecuted(object id)
        {
            var dialog = new EditStudentWindow {                
                DateOfBirth=DateTime.Now
            };
            
            if (dialog.ShowDialog() != true) return;
            var student = new Student
            {
                FullName = dialog.FullName,
                DateOfBirth = dialog.DateOfBirth                
            };
            var fileName = Path.GetFileName(dialog.ImagePass);
            student.ImageFileName= fileName;
            groupManager.AddStudentToGroup(student, _selectedGroup.GroupId, dialog.HasDiscount);
            
            var target = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            File.Copy(dialog.ImagePass, target);
            
            Students.Add(student);
        }
        #endregion

        #region Редактирование студента
        private ICommand _editStudentCommand;
        public ICommand EditStudentCommand =>
            _editStudentCommand ?? 
                new RelayCommand(OnEditStudentExecuted, EditStudentCanExecute);
        // Проверка возможности редактирования
        private bool EditStudentCanExecute(object p) =>
            _selectedStudent != null;
        
        private void OnEditStudentExecuted(object id)
        {
            var dialog = new EditStudentWindow
            {
                FullName=_selectedStudent.FullName,
                DateOfBirth = _selectedStudent.DateOfBirth,
                ImagePass = _selectedStudent.ImageFileName,
                HasDiscount=_selectedGroup.BasePrice>_selectedStudent.IndividualPrice
            };

            if (dialog.ShowDialog() != true) return;
            
            // Путь к папке Images
            var imageFolderPass = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            // Если выбрано новое изображение
            if(!_selectedStudent.ImageFileName.Equals(dialog.ImagePass))
            {
                // Удалить старое изображение
                File.Delete(Path.Combine(imageFolderPass, _selectedStudent.ImageFileName));
                // Получить имя нового файла изображения
                var newImage = Path.GetFileName(dialog.ImagePass);
                // Скопировать файл в папку Images
                File.Copy(dialog.ImagePass, Path.Combine(imageFolderPass, newImage));
                _selectedStudent.ImageFileName = newImage;
            }
            // Вычисление индивидуальной стоимости обучения
            _selectedStudent.IndividualPrice=dialog.HasDiscount
                ?_selectedGroup.BasePrice*0.8m
                :_selectedGroup.BasePrice;
            _selectedStudent.FullName = dialog.FullName;
            _selectedStudent.DateOfBirth = dialog.DateOfBirth;
            studentManager.UpdateStudent(_selectedStudent);
            // Обновить список студентов
            OnGetStudentExecuted(_selectedGroup.GroupId); 
        }

        #endregion

        #endregion

        private string title = "Groups Window";
        public MainWindowViewModel()
        {
            factory = new ManagersFactory("DefaultConnection");
            groupManager = factory.GetGroupManager();
            studentManager = factory.GetSudentManager();
            //Инициализация базы данных
            if (groupManager.Groups.Count() == 0)
                DbTestData.SetupData(groupManager);
            Groups = new ObservableCollection<Group>(groupManager.Groups);
            Students = new ObservableCollection<Student>();
            //Получение списка студентов для первой группы
            if (Groups.Count > 0)
                OnGetStudentExecuted(Groups[0].GroupId);

            //factory = new ManagersFactory();
            //groupManager = factory.GetGroupManager();
            //Groups = new ObservableCollection<Group>(groupManager.Groups);
            //Students = new ObservableCollection<Student>();
        }
    }
}
