//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Employee.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class yazcity_EmployeeEntities : DbContext
    {
        public yazcity_EmployeeEntities()
            : base("name=yazcity_EmployeeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_EMPLOYEE> TBL_EMPLOYEE { get; set; }
    
        public virtual int SP_EMPLOYEE_CU(Nullable<long> eMPLOYEEID, string eMPLOYEENAME, string pLACE)
        {
            var eMPLOYEEIDParameter = eMPLOYEEID.HasValue ?
                new ObjectParameter("EMPLOYEEID", eMPLOYEEID) :
                new ObjectParameter("EMPLOYEEID", typeof(long));
    
            var eMPLOYEENAMEParameter = eMPLOYEENAME != null ?
                new ObjectParameter("EMPLOYEENAME", eMPLOYEENAME) :
                new ObjectParameter("EMPLOYEENAME", typeof(string));
    
            var pLACEParameter = pLACE != null ?
                new ObjectParameter("PLACE", pLACE) :
                new ObjectParameter("PLACE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_EMPLOYEE_CU", eMPLOYEEIDParameter, eMPLOYEENAMEParameter, pLACEParameter);
        }
    
        public virtual int SP_EMPLOYEE_DELETE(Nullable<long> eMPLOYEEID)
        {
            var eMPLOYEEIDParameter = eMPLOYEEID.HasValue ?
                new ObjectParameter("EMPLOYEEID", eMPLOYEEID) :
                new ObjectParameter("EMPLOYEEID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_EMPLOYEE_DELETE", eMPLOYEEIDParameter);
        }
    
        public virtual ObjectResult<SP_EMPLOYEE_SELECT_Result> SP_EMPLOYEE_SELECT()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_EMPLOYEE_SELECT_Result>("SP_EMPLOYEE_SELECT");
        }
    }
}
