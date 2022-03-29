﻿using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Activo
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public double Valor { get; set; }
        public int VidaUtil { get; set; }
        public double ValorResidual { get; set; }       
        public Empleado Empleado { get; set; }
        public EstadoActivo EstadoActivo { get; set; }
        public Guid Codigo { get; set; }

    }
}
