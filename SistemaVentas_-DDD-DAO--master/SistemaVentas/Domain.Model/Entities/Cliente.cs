﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Cliente
    {
        public Usuario Usuario { get; set; }
        public int ID_Cliente { get; set; }
    }
}
