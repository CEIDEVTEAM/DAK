using BusinessLogic.DataModel.Mappers;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Repository
{
    public class PaymentRecordRepository
    {
        private PaymentRecordMapper _PaymentRecordMapper;
        private readonly DAKContext _Context;
        public PaymentRecordRepository(DAKContext context)
        {
            this._PaymentRecordMapper = new PaymentRecordMapper();
            this._Context = context;
        }

        public void Add(IDto dto)
        {
            using (var trann = _Context.Database.BeginTransaction())
            {
                try
                {
                    PaymentRecord clientEntity = this._PaymentRecordMapper.MapToEntity(dto);
                    _Context.PaymentRecord.Add(clientEntity);
                    _Context.SaveChanges();

                    trann.Commit();

                }
                catch (Exception ex)
                {
                    trann.Rollback();
                }
            }
        }
    }
}
