﻿using Syntheseopdracht2.Model;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Syntheseopdracht2.DA
{
    public interface IBoekenDatabase
    {
        DbSet<Boek> Boeken { get; set; }
        DbSet<Genre> Genres { get; set; }

        Task<Int32> SaveChangesAsync();
    }
}
