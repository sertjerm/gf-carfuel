using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarFuel.Data
{
    public class ResositoryBase<T>
    {
        private System.Data.Entity.DbContext context;

        public ResositoryBase(System.Data.Entity.DbContext context)
        {
            // TODO: Complete member initialization
            this.context = context;
        }
    }
}
