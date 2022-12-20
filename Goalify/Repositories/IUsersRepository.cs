using Goalify.Models;
using System.Collections.Generic;

namespace Goalify.Repositories
{
    public interface IUsersRepository
    {
        void Add(Users user);
        void Delete(int Id);
        void Update(Users user);
        Users Get(Users email);
        List<Users> GetAll();
       
    }
    
}