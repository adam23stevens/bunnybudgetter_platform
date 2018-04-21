using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BunnyBudgetter.Data.Entities;

namespace BunnyBudgetterPlatform.Data.Model
{
    public class BunnyBudgetterPlatformContext : DbContext
    {
        public BunnyBudgetterPlatformContext (DbContextOptions<BunnyBudgetterPlatformContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MonthPayment> MonthPayments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PlannedPayment> PlannedPayments { get; set; }
    }
}
