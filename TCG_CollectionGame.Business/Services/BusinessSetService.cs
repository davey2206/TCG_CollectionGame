using System;
using System.Collections.Generic;
using System.Text;
using TCG_CollectionGame.Business.Interfaces;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Business.Services
{
    public class BusinessSetService : IBusinessSetService
    {
        private readonly IDataSetService _setService;
        public BusinessSetService(IDataSetService setService)
        {
            _setService = setService;
        }

        public List<Pokeset> GetAllSets()
        {
            return _setService.GetSets();
        }
    }
}
