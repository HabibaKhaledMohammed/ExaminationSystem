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
    using System.Collections.Generic;
    
    public partial class Stud_Course_Exam
    {
        public int Stud_ID { get; set; }
        public int Course_ID { get; set; }
        public int Exam_ID { get; set; }
        public Nullable<double> grade { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
    }
}
