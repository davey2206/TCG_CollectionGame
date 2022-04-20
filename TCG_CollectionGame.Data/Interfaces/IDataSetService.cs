using System.Collections.Generic;
using TCG_CollectionGame.Enities.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface IDataSetService
    {
        List<Pokeset> GetSets();
    }
}