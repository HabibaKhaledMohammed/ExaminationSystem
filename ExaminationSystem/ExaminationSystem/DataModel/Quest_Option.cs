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
    
    public partial class Quest_Option
    {
        public int Quest_ID { get; set; }
        public string Option_Name { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
