using BusinessLogic.DataModel.Mappers;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Repository
{
    public class TradingParametersRepository
    {
        private TradingParametersMapper _TradingParametersMapper;
        private readonly LocalLogDBContext _Context;
        public TradingParametersRepository(LocalLogDBContext context)
        {

            this._TradingParametersMapper = new TradingParametersMapper();
            this._Context = context;
        }

        public double? GetPriceByCodeName(string codeName) 
        {
            return this._Context.TradingParameters.FirstOrDefault(x => x.CodeName == codeName).Price;
        }
    }
}
