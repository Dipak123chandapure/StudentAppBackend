using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccessAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Form1Entity1 { get; set; }
        public string Form1Entity2 { get; set; }
        public string Form1Entity3 { get; set; }
        public string Form1Entity4 { get; set; }

        public int? Form2Entity1Id { get; set; }
        public int? Form2Entity2Id { get; set; }
        public int? Form2Entity3Id { get; set; }
        public int? Form2Entity4Id { get; set; }

        public int? Form3Entity1Id { get; set; }
        public int? Form3Entity2Id { get; set; }
        public int? Form3Entity3Id { get; set; }
        public int? Form3Entity4Id { get; set; }
        public string Form3Entity5 { get; set; }
        public string Form3Entity6 { get; set; }
        public string Form3Entity7 { get; set; }
        public int? Form4Entity1Id { get; set; }
        public int? Form4Entity2Id { get; set; }
        public int? Form4Entity3Id { get; set; }
        public int? Form4Entity4Id { get; set; }
        public string Form4Entity5 { get; set; }
        public string Form4Entity6 { get; set; }
        public string Form4Entity7 { get; set; }
        public bool IsVirtuallyDeleted { get; set; }

    }
}
