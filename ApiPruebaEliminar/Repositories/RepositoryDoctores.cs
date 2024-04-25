using ApiPruebaEliminar.Data;
using ApiPruebaEliminar.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaEliminar.Repositories
{
    public class RepositoryDoctores
    {
        private DoctorContext context; 

        public RepositoryDoctores(DoctorContext context)
        {
            this.context = context;
        }

        //Get doctores
        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            return await this.context.Doctores.ToListAsync();
        }

        public async Task<Doctor> FindDoctorAsync(int iddoctor)
        {
            return await this.context.Doctores.FirstOrDefaultAsync(x => x.IdDoctor == iddoctor);
        }

        //insert
        public async Task InsertDoctorAsync(int idhospital, string apellido,string especialidad,int salario)
        {
            int maxid = await this.context.Doctores.MaxAsync(z => z.IdDoctor) + 1; ;
            Doctor doctor = new Doctor();

            doctor.IdDoctor = maxid;
            doctor.IdHospital = idhospital;
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.Salario = salario;
            
            this.context.Doctores.Add(doctor);
            await this.context.SaveChangesAsync();
        }
        //update
        public async Task UpdateDoctorAsync(int iddoctor, int idhospital, string apellido, string especialidad, int salario)
        {
            Doctor doctor = await this.FindDoctorAsync(iddoctor);
            doctor.IdHospital = idhospital;
            doctor.Apellido = apellido;
            doctor.Especialidad= especialidad;
            doctor.Salario= salario;
            await this.context.SaveChangesAsync();
        }

        //delete 
        public async Task DeleteDoctorAsync(int iddoctor)
        {
            Doctor doctor = await this.FindDoctorAsync(iddoctor);
            this.context.Remove(doctor);
            await this.context.SaveChangesAsync();  
        }

        public async Task <Doctor> LogInDoctorAsync(string apellido)
        {
            return await this.context.Doctores.Where(x=> x.Apellido ==apellido).FirstOrDefaultAsync();
        }
    }
}
