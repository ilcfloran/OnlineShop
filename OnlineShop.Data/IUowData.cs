using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public interface IUowData : IDisposable
    {
        

        IRepository<CellPhone> CellPhones { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}
