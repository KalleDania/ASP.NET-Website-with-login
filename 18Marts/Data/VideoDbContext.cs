using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _18Marts.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _18Marts.Data
{
    public class VideoDbContext : IdentityDbContext<User>
    {
        public DbSet<Video> Videos { get; set; }

        public VideoDbContext(DbContextOptions<VideoDbContext> _options) : base(_options)
        {

        }

        protected override void OnModelCreating(ModelBuilder _builder)
        {
            base.OnModelCreating(_builder);
        }
    }
}
