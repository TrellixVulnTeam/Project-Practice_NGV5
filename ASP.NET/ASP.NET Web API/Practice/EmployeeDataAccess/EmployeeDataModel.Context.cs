﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ASP_NETWebAPI : DbContext
    {
        public ASP_NETWebAPI()
            : base("name=ASP_NETWebAPI")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ASP_NETWebAPI_Employees> ASP_NETWebAPI_Employees { get; set; }
        public virtual DbSet<ASP_NETWebAPI_Users> ASP_NETWebAPI_Users { get; set; }
    }
}