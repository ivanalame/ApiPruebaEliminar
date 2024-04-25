using ApiPruebaEliminar.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaEliminar.Data
{
    public class DoctorContext: DbContext
    {
        public DoctorContext(DbContextOptions<DoctorContext>options):base(options) { }

        public DbSet<Doctor> Doctores { get; set; }
    }
}
