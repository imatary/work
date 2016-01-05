using System.Collections.Generic;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class PermissionService
    {
        private readonly StockDataEntities _context;
        public PermissionService()
        {
            _context = new StockDataEntities();
        }

        public List<UserPermission> GetPermissionsByUserName(string userName)
        {
            var context = new StockDataEntities();

            var permissionsByUsername = (from perUser in context.UserPermissions
                join permission in context.Permissions on perUser.ObjectID equals permission.ObjectID
                where perUser.Username == userName
                select perUser

                ).ToList();

            return permissionsByUsername;
        } 
    }
}
