//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFMockingTestbed
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee
    {
        public long employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long department_id { get; set; }
    
        public virtual department department { get; set; }
    }
}