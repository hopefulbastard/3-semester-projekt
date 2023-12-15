using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _3_Semester_Class_Library
{
    public class SikkerhedsLogDBContext : DbContext
    {
        public SikkerhedsLogDBContext(DbContextOptions<SikkerhedsLogDBContext> options) : base(options) { }
        public DbSet<SikkerhedsLog> SikkerhedsLog { get; set; }
    }
}
