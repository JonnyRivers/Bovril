//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bovril.EntityFramework.Sakila
{
    using System;
    using System.Collections.Generic;
    
    public partial class film_category
    {
        public int film_id { get; set; }
        public byte category_id { get; set; }
        public System.DateTime last_update { get; set; }
    
        public virtual category category { get; set; }
        public virtual film film { get; set; }
    }
}
