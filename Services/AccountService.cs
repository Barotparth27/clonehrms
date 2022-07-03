using hrmscloneapi.Interface;
using hrmscloneapi.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hrmscloneapi.Services
{
    public class AccountService : AccountMaster
    {
        #region Constructor
        private readonly string _appSettingskey;
        public AccountService(string _connectionString, string _appSettKey)
        {
            conn.ConnectionString = _connectionString;
            _appSettingskey = _appSettKey;
        }



        public AccountService()
        {

        }
        #endregion
        SqlConnection conn = new SqlConnection();
        public Account Login(string EmailId, string Password)
        {

            DataSet ds = new DataSet();
            DataSet dsMenu = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spValidateUserTestDNNTesting", conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@UserName", EmailId);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                Account SuperAdmin = new Account();
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {

                    SuperAdmin.EmpId = Convert.ToString(ds.Tables[0].Rows[0]["EmpId"]);
                    SuperAdmin.CompanyId = Convert.ToString(ds.Tables[0].Rows[0]["CompanyId"]);
                    SuperAdmin.DesignationId = Convert.ToString(ds.Tables[0].Rows[0]["DesignationId"]);
                    SuperAdmin.DesignationName = Convert.ToString(ds.Tables[0].Rows[0]["DesignationName"]);
                    SuperAdmin.Emp_PhotoPath = Convert.ToString(ds.Tables[0].Rows[0]["Emp_PhotoPath"]);
                    SuperAdmin.EmployeeName = Convert.ToString(ds.Tables[0].Rows[0]["Emp_PhotoPath"]);
                    SuperAdmin.Emp_PersonalEmailId = Convert.ToString(ds.Tables[0].Rows[0]["Emp_PersonalEmailId"]);
                    SuperAdmin.Gender = Convert.ToString(ds.Tables[0].Rows[0]["Gender"]);
                    SuperAdmin.RoleName = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
                    SuperAdmin.LocationId = Convert.ToString(ds.Tables[0].Rows[0]["LocationId"]);
                    SuperAdmin.RoleId = Convert.ToString(ds.Tables[0].Rows[0]["RoleId"]);

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettingskey);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, SuperAdmin.EmpId.ToString()),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.Version, "V3.1")

                    }),
                        Expires = DateTime.UtcNow.AddDays(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    SuperAdmin.Token = tokenHandler.WriteToken(token);
                }
                return SuperAdmin;


            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<GetUserPageAccessListModel> GetUserPageAccessList(usermageaccessreq objReq){

            List<GetUserPageAccessListModel> objResp = new List<GetUserPageAccessListModel>();
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetUserPageAccessListTest", conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@roleid", objReq.RoleId);
                cmd.Parameters.AddWithValue("@CompanyId", objReq.Compid);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                
                if (ds != null && ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        GetUserPageAccessListModel Resp = new GetUserPageAccessListModel();
                        Resp.ModuleId = Convert.ToInt32(ds.Tables[0].Rows[i]["ModuleId"]);
                        Resp.Module = Convert.ToString(ds.Tables[0].Rows[i]["Module"]);

                        Resp.ModuleClass = Convert.ToString(ds.Tables[0].Rows[i]["ModuleClass"]);

                        Resp.IsVisible = Convert.ToInt32(ds.Tables[0].Rows[i]["IsVisible"]);
                        objResp.Add(Resp);
                    }
                }
                return objResp;

            }
            catch(Exception ex)
            {
                throw ex;
            }




        }

    }
}
