using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSong.Models;

namespace MvcSong.Data
{
    public class MvcSongContext : DbContext
    {
        public MvcSongContext (DbContextOptions<MvcSongContext> options)
            : base(options)
        {
        }

        public DbSet<MvcSong.Models.Song> Song { get; set; }
    }
}