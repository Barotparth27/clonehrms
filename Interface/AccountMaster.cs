using hrmscloneapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrmscloneapi.Interface
{
   public interface AccountMaster
    {
        Account Login(string Emailid, string password);
        List<GetUserPageAccessListModel> GetUserPageAccessList(usermageaccessreq objReq);
    }
}
