using Goalify.Models;
using System.Collections.Generic;

namespace Goalify.Repositories
{
    public interface IUsersRepository
    {
        void Add(Users user);
            void Delete(int Id);
        Users Get(int id);
        List<Users> GetAll();
       
    }
    
}