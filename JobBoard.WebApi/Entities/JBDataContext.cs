using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.WebApi.Entities
{
    public class JBDataContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public JBDataContext()
        {

        }
        public JBDataContext(DbContextOptions<JBDataContext> options) :
            base(options)
        {

        }
    }
}
