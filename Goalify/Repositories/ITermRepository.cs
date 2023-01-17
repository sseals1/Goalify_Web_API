using Goalify.Models;
using System.Collections.Generic;

namespace Goalify.Repositories
{
    public interface ITermRepository
    {
        Terms Get(Terms term);
        List<Terms> GetAll();
    }
}