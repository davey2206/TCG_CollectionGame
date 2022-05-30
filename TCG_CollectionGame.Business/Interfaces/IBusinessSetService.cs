using System;
using System.Collections.Generic;
using System.Text;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Business.Interfaces
{
    public interface IBusinessSetService
    {
        public List<Pokeset> GetAllSets();
    }
}
