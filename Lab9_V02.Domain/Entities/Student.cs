using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9_V02.Domain.Entities
{
    public class Student
    {

        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal IndividualPrice { get; set; }
        public string ImageFileName { get; set; }
        // Навигационные свойства
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
