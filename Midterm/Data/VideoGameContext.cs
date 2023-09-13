using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Midterm.Models;

namespace Midterm.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext (DbContextOptions<VideoGameContext> options)
            : base(options)
        {
        }

        public DbSet<Midterm.Models.VideoGame> VideoGame { get; set; } = default!;
    }
}
