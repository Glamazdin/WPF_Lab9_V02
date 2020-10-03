﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9_V02_Business.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal IndividualPrice { get; set; }
        public string FileName { get; set; }
        public bool HasDiscount { get; set; }
    }
}
