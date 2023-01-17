using Goalify.Models;
using System.Collections.Generic;

namespace Goalify.Repositories
{
    public interface ITermsRepository
    {
        Terms Get(Terms term);
        List<Terms> GetAll();
    }
}