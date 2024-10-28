using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EGuerrero_ExamenP1.Models;

namespace EGuerrero_ExamenP1.Data
{
    public class EGuerrero_ExamenP1Context : DbContext
    {
        public EGuerrero_ExamenP1Context (DbContextOptions<EGuerrero_ExamenP1Context> options)
            : base(options)
        {
        }

        public DbSet<EGuerrero_ExamenP1.Models.GuerreroEmilio> GuerreroEmilio { get; set; } = default!;
        public DbSet<EGuerrero_ExamenP1.Models.Celular> Celular { get; set; } = default!;
    }
}
