using hrmscloneapi.Interface;
using hrmscloneapi.Model;
using hrmscloneapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrmscloneapi.Provider
{
    public class AccountCaller
    {
        public AccountMaster adminMaster;
        public Account Login(AccountMaster _adminMaster, string EmailId, string Password)
        {
            adminMaster = _adminMaster;
            return adminMaster.Login(EmailId, Password);
        }
        public List<GetUserPageAccessListModel> GetUserPageAccessList(AccountMaster _adminMaster, usermageaccessreq obj)
        {
            adminMaster = _adminMaster;
            return adminMaster.GetUserPageAccessList(obj);
        }
        
    }
}
