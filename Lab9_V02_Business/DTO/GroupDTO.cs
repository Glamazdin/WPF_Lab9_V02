using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9_V02_Business.DTO
{
    public class GroupDTO
    {
        public int GroupId { get; set; }
        public string CourseName { get; set; }
        public DateTime Commence { get; set; }
        public decimal BasePrice { get; set; }
    }
}
