using ATframework3demo.BaseFramework.BitrixCPinterraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.TestEntities
{
    public class User
    {
        public User() { }

        public User(string loginAkaEmail, string password, string name, string lastName)
        {
            LoginAkaEmail = loginAkaEmail;
            Password = password;
            Name = name;
            LastName = lastName;
        }

        public string LoginAkaEmail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NameLastName => Name + " " + LastName;

        public string GetDBid(Uri portalUri, User adminUser)
        {
            var result = PortalDatabaseExecutor.ExecuteQuery("select ID from b_user where EMAIL = '" + LoginAkaEmail + "'", portalUri, adminUser);
            return result.Count == 0 ? null : result[0].ID;
        }
    }
}
