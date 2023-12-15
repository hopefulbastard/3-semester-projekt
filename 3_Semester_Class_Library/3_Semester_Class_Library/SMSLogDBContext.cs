using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Semester_Class_Library
{
    //Magnus + Milo

    public class SMSLogDBContext : DbContext
    {
        public SMSLogDBContext(DbContextOptions<SMSLogDBContext> options) : base(options) { }
        public DbSet<SMSLog> SMSLog { get; set; }
    }
}
