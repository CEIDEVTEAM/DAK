using BusinessLogic.DataModel.Mappers;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Repository
{
    public class DeliveryAreaRepository
    {
        private DeliveyAreaMapper _DeliveryAreaMapper;
        private readonly DAKContext _Context;
        public DeliveryAreaRepository(DAKContext context)
        {

            this._DeliveryAreaMapper = new DeliveyAreaMapper();
            this._Context = context;
        }


        public void AddArea(DeliveryAreaDto dto)
        {
            DeliveryArea newArea = this._DeliveryAreaMapper.MapToEntity(dto);

            _Context.DeliveryArea.Add(newArea);
            _Context.SaveChanges();

            foreach (CoordinateDto item in dto.ColVexels)
            {
                Coordinate vexel = this._DeliveryAreaMapper.MaptoEntity(item);
                vexel.IdDeliveryArea = newArea.Id;
                _Context.Coordinate.Add(vexel);
            }

            _Context.SaveChanges();

            //TODO: HACER TRANSACCION
        }

        //public DtoZona GetZonaByNombre(string nombreZona)
        //{
        //    using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
        //        return this._zonaMapper.MapToDto(context.Zona.AsNoTracking().FirstOrDefault(f => f.nombre == nombreZona));
        //}

        //public void ModifyZona(DtoZona dto)
        //{
        //    using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
        //    {
        //        using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
        //        {
        //            try
        //            {
        //                Zona currZona = context.Zona.FirstOrDefault(f => f.id == dto.id);

        //                if (currZona != null)
        //                {
        //                    currZona.nombre = dto.nombre;
        //                    currZona.color = dto.color;
        //                }

        //                context.SaveChanges();
        //                trann.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trann.Rollback();
        //            }
        //        }
        //    }
        //}



        //public void DeleteZona(int idZona)
        //{
        //    using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
        //    {
        //        using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
        //        {
        //            try
        //            {
        //                Zona currZona = context.Zona.FirstOrDefault(f => f.id == idZona);
        //                currZona.situacion = CGlobals.ESTADO_INACTIVO;

        //                context.SaveChanges();
        //                trann.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trann.Rollback();
        //            }
        //        }
        //    }
        //}

        public List<DeliveryAreaDto> GetAllAreas()
        {
            return this._DeliveryAreaMapper.MapToDto(_Context.DeliveryArea.Include("Coordinates").AsNoTracking().ToList());
        }

        //public DtoZona GetZonaById(int idZona)
        //{
        //    using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
        //        return this._zonaMapper.MapToDto(context.Zona.AsNoTracking().FirstOrDefault(f => f.id == idZona));
        //}

        //public bool ExistZonaByNombre(string nombre)
        //{
        //    using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
        //        return context.Zona.AsNoTracking().Any(a => a.nombre == nombre);
        //}

        //public bool ExistZonaById(int idZona)
        //{
        //    using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
        //        return context.Zona.AsNoTracking().Any(a => a.id == idZona && a.situacion == CGlobals.ESTADO_ACTIVO);
        //}

        //public int GetReclamosActivosZona(int idZona)
        //{
        //    int cantidad = 0;
        //    V_ReclamosAbiertosPorCuadrilla entity = new V_ReclamosAbiertosPorCuadrilla();
        //    using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
        //    {
        //        entity = context.V_ReclamosAbiertosPorCuadrilla.AsNoTracking().FirstOrDefault(w => w.idZona == idZona);
        //        if (entity != null)
        //            cantidad = (int)entity.cantidad;
        //    }

        //    return cantidad;
        //}
    }
}
