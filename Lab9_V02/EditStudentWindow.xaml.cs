using Lab9_V02.Commands;
using Lab9_V02.Domain.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab9_V02
{
    /// <summary>
    /// Interaction logic for EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        #region Properties        
        public string FullName
        {
            get { return (string)GetValue(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FullName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FullNameProperty =
            DependencyProperty.Register("FullName", typeof(string), 
                typeof(EditStudentWindow), new PropertyMetadata(default(string)));

        public DateTime DateOfBirth
        {
            get { return (DateTime)GetValue(DateOfBirthProperty); }
            set { SetValue(DateOfBirthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DateOfBirth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateOfBirthProperty =
            DependencyProperty.Register("DateOfBirth", typeof(DateTime), 
                typeof(EditStudentWindow), new PropertyMetadata(default(DateTime)));


        public bool HasDiscount
        {
            get { return (bool)GetValue(HasDiscountProperty); }
            set { SetValue(HasDiscountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasDiscount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasDiscountProperty =
            DependencyProperty.Register("HasDiscount", typeof(bool), 
                typeof(EditStudentWindow), new PropertyMetadata(false));


        public string ImagePass
        {
            get { return (string)GetValue(ImagePassProperty); }
            set { SetValue(ImagePassProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePass.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePassProperty =
            DependencyProperty.Register("ImagePass", typeof(string), 
                typeof(EditStudentWindow), new PropertyMetadata(default(string)));
        #endregion

        #region Commands
        private ICommand _selectImageCommand;
        public ICommand SelectImageCommand =>
            _selectImageCommand ?? new RelayCommand(OnSelectImageExecuted);

        public void OnSelectImageExecuted(object param)
        {
            var dialog = new OpenFileDialog();
            if(dialog.ShowDialog()==true)
            {
                ImagePass = dialog.FileName;
            }
        }

        private ICommand _okCommand;
        public ICommand OkCommand =>
            _okCommand?? new RelayCommand(OnOkExecuted);

        public void OnOkExecuted(object param)
        {
            this.DialogResult = true;
            this.Close();
        }

        #endregion

        public EditStudentWindow()
        {
            InitializeComponent();
        }
    }
}
