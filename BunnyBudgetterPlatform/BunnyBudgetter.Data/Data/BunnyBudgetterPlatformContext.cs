using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BunnyBudgetter.Data;

namespace BunnyBudgetterPlatform.Data.Models
{
    public class BunnyBudgetterPlatformContext : DbContext
    {
        public BunnyBudgetterPlatformContext (DbContextOptions<BunnyBudgetterPlatformContext> options)
            : base(options)
        {
        }

        public DbSet<BunnyBudgetter.Data.User> User { get; set; }
    }
}
