using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Data.Services
{
    public interface ISetService
    {
        List<Pokeset> getSets();
    }
}