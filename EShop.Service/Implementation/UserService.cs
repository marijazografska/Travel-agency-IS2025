using EShop.Domain.Identity;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Constructor to inject the IUserRepository dependency
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<EShopApplicationUser> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public EShopApplicationUser GetUserById(string id)
        {
            return _userRepository.Get(id);
        }

        public void AddUser(EShopApplicationUser user)
        {
            _userRepository.Insert(user);
        }

        public void UpdateUser(EShopApplicationUser user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(EShopApplicationUser user)
        {
            _userRepository.Delete(user);
        }
    }
}
