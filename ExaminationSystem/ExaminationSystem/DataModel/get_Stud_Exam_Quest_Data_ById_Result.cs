//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExaminationSystem.DataModel
{
    using System;
    
    public partial class get_Stud_Exam_Quest_Data_ById_Result
    {
        public int Stud_ID { get; set; }
        public string Stud_Fname { get; set; }
        public string Stud_Lname { get; set; }
        public string Address { get; set; }
        public Nullable<double> GPA { get; set; }
        public string Password { get; set; }
        public int Exam_ID { get; set; }
        public Nullable<int> Question_Num_MCQ { get; set; }
        public Nullable<int> Question_Num_TF { get; set; }
        public Nullable<int> Course_ID { get; set; }
        public int Quest_ID { get; set; }
        public string Quest_Description { get; set; }
        public Nullable<int> Quest_Answer { get; set; }
        public Nullable<bool> Quest_Type { get; set; }
        public Nullable<double> grade { get; set; }
    }
}
