﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BebemundiWebAPI.Entities
{
    public class Alias
    {        
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string IdMedicamento { get; set; }
    }
}