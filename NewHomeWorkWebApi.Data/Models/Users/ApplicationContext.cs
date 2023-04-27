using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace NewHomeWorkWebApi.Data.Models.Users
{
    internal class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Data Source=localhost; Port=13306; Character Set=utf8mb4; User Id=root; Password=root; convertzerodatetime=true; Allow User Variables=True; Pooling=true; Max Pool Size=50;SSL Mode=Preferred; database=mydatabase;");
        }
    }
}
