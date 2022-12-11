using System.Collections.Generic;
using System.Linq;
using WorldCup.SharedKernel.Enuns.UserPermissions;

namespace WorldCup.SharedKernel.UserLoggedData
{
    public class UserLoggedData
    {
        private readonly List<DataToken> _data;

        public UserLoggedData()
        {
            _data = new List<DataToken>();
        }

        public void Add(int idUser, UserPermissions Permission)
        {
            _data.Add(new DataToken
            {
                UserId = idUser,
                UserPermission = Permission
            });
        }

        public DataToken GetData()
        {
            return _data.FirstOrDefault();
        }
    }
    public class DataToken
    {
        public int UserId { get; set; }
        public UserPermissions UserPermission { get; set; }
    }
}
