using Goalify.Models;
using System.Collections.Generic;

namespace Goalify.Repositories
{
    public interface IUsersRepository
    {
        Users Get(int id);
        List<Users> GetAll();
    }
}