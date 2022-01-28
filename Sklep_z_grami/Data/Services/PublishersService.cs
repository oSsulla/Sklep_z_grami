using Microsoft.EntityFrameworkCore;
using Sklep_z_grami.Data.Base;
using Sklep_z_grami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Data.Services
{
    public class PublishersService : EntityBaseRepository<Publisher>, IPublishersService
    {
       public PublishersService(AppDbContext context) : base(context) { }
    }
}
