using Goalify.Models;
using System.Collections.Generic;

namespace Goalify.Repositories
{
    public interface IGoalsRepository
    {
        void Add(Goals goal);
        void Delete(int id);
        Goals Get(int id);
        List<Goals> GetAll();
        void Update(Goals goal);
    }
}