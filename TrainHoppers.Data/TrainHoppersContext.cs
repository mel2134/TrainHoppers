using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Domain;

namespace TrainHoppers.Data
{
    public class TrainHoppersContext : DbContext
    {
        public TrainHoppersContext(DbContextOptions<TrainHoppersContext> options) : base(options) {

        }
        public DbSet<Ability> Abilities { get; set; }
    }
}
