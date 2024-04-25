using ApiPruebaEliminar.Helpers;
using ApiPruebaEliminar.Models;
using ApiPruebaEliminar.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiPruebaEliminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryDoctores repo;
        private HelperActionServicesOAuth helper;
        public AuthController(RepositoryDoctores repo,HelperActionServicesOAuth helper)
        {
            this.helper = helper;
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            //BUSCO AL USUARIO
            Doctor doctor = await this.repo.LogInDoctorAsync(model.UserName);
            if (doctor == null)
            {
                return Unauthorized();
            }
            else
            {
                SigningCredentials credentials = new SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256);

                string jsonUsuario = JsonConvert.SerializeObject(doctor);
                Claim[] info = new[]
                {
                    new Claim("UserData", jsonUsuario)
                };

                JwtSecurityToken token = new JwtSecurityToken(
                    claims: info,
                        issuer: this.helper.Issuer,
                        audience: this.helper.Audience,
                        signingCredentials: credentials,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        notBefore: DateTime.UtcNow
                    );
                return Ok(
                  new
                  {
                      response = new JwtSecurityTokenHandler().WriteToken(token)
                  });
            }
        }
    }
}
