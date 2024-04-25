using ApiPruebaEliminar.Models;
using ApiPruebaEliminar.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaEliminar.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctores()
        {
            return await this.repo.GetDoctoresAsync();
        }
        [Authorize]
        [HttpGet("{iddoctor}")]
        public async Task<ActionResult<Doctor>>FindDoctor(int iddoctor)
        {
            return await this.repo.FindDoctorAsync(iddoctor);
        }

        [HttpPost]
        public async Task<ActionResult> PostDoctor(Doctor doctor)
        {
            await this.repo.InsertDoctorAsync(doctor.IdHospital, doctor.Apellido, doctor.Especialidad, doctor.Salario);
            return Ok();
        }
        [HttpDelete("{iddoctor}")]
        public async Task<ActionResult> Delete(int iddoctor)
        {
            await this.repo.DeleteDoctorAsync(iddoctor);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult>PutDoctor(Doctor doctor)
        {
            await this.repo.UpdateDoctorAsync(doctor.IdDoctor, doctor.IdHospital, doctor.Apellido, doctor.Especialidad, doctor.Salario);
            return Ok();
        }
    }
}
