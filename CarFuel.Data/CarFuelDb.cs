﻿using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Data
{
    public class CarFuelDb
    {
        public DbSet<Car> Cars { get; set; }
    }
}
