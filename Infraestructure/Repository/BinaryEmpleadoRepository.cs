using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BinaryEmpleadoRepository
    {
        public RAFContext context;
        public const int SIZE = 568;
        public BinaryEmpleadoRepository()
        {
            context = new RAFContext("empleado", SIZE);
        }
        public void Add(Empleado t)
        {
            try
            {
                context.Create<Empleado>(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Empleado t)
        {
            context.Delete(t.Id);
        }

        public Empleado GetById(int id)
        {

            try
            {
                return context.Get<Empleado>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Empleado> Read()
        {

            try
            {
                return context.GetAll<Empleado>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Empleado empleado)
        {
            context.Update<Empleado>(empleado);
        }
    }
}
