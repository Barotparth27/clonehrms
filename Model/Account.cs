using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrmscloneapi.Model
{
    public class Account
    {
        public string EmailId { get; set; }
        public string password { get; set; }
        public string EmpId { get; set; }
        public string CompanyId { get; set; }
        public string DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string Emp_PhotoPath { get; set; }
        public string EmployeeName { get; set; }
        public string Emp_PersonalEmailId { get; set; }
        
    public string Gender { get; set; }
        public string RoleName { get; set; }

        public string LocationId { get; set; }
        public string RoleId { get; set; }
        public string Token { get; set; }
 }

    public class usermageaccessreq
    {
   public int RoleId { get; set; }
   public int Compid { get; set; }

    }
    public class GetUserPageAccessListModel
    {

        public long ModuleId { get; set; }
        public string Module { get; set; }
        public string ModuleClass { get; set; }
        public int IsVisible { get; set; }

    }
}
