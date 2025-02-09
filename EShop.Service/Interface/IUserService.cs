using EShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Interface
{
    public interface IUserService
    {
        IEnumerable<EShopApplicationUser> GetAllUsers();
        EShopApplicationUser GetUserById(string id);
        void AddUser(EShopApplicationUser user);
        void UpdateUser(EShopApplicationUser user);
        void DeleteUser(EShopApplicationUser user);
    }
}
