using Syntheseopdracht2._4.Model;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Syntheseopdracht2._3.DA
{
    public interface IBoekenDatabase
    {
        DbSet<Boek> Boeken { get; set; }
        DbSet<Genre> Genres { get; set; }

        Task<Int32> SaveChangesAsync();
    }
}
