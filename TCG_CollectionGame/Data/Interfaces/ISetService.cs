using System.Collections.Generic;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface ISetService
    {
        List<Pokeset> GetSets();
    }
}