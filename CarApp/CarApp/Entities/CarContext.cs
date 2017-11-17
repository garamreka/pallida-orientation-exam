using CarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Entities
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }

        public DbSet<Licence_plates> Licence_plates { get; set; }
    }
}
