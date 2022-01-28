using Microsoft.EntityFrameworkCore;
using Sklep_z_grami.Data.Base;
using Sklep_z_grami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Data.Services
{
    public class ShopsService : EntityBaseRepository<Shop>, IShopsService
    {
        public ShopsService(AppDbContext context) : base(context) { }
    }
}
