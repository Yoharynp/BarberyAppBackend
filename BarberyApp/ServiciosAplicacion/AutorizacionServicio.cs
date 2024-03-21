using BappDominio.Entidades;
using BappDominio.ObjetosValor.Barbero;
using BarberyApp.Comandos;
using BarberyApp.Infraestructura;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BarberyApp.ServiciosAplicacion
{
    public class AutorizacionServicio : IAutorizacionServicio
    {
        private readonly ContextoBarberyApp _contextoBaseDeDatos;
        private readonly IConfiguration configuration;

        public AutorizacionServicio(ContextoBarberyApp contextoBaseDeDatos, IConfiguration configuration)
        {
            _contextoBaseDeDatos = contextoBaseDeDatos;
            this.configuration = configuration;
        }

        private string GenerarToken(string idUsuario)
        {
            var key = configuration.GetValue<string>("JwtConfiguracion:Secret");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUsuario));

            var credencialesToken = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(token);
            return tokenCreado;
        }

        public async Task<AutorizacionRespuesta> DevolverTokenBarbero(AutorizacionPeticion peticion)
        {
            var usuario_encontrado = _contextoBaseDeDatos.Barberos.FirstOrDefault(x => x.Email == peticion.Email && x.Contraseña == peticion.Contraseña);
            if (usuario_encontrado == null)
            {
                return await Task.FromResult<AutorizacionRespuesta>(null);
            }

            string token = GenerarToken(usuario_encontrado.Id.ToString());
            return new AutorizacionRespuesta
            {
                NombreUsuario = usuario_encontrado.Nombre,
                Resultado = true,
                Token = token,
                Mensaje = "Autenticación exitosa",
                Rol = usuario_encontrado.Rol
            };
        }

        public async Task<AutorizacionRespuesta> DevolverTokenCliente(AutorizacionPeticion peticion)
        {
            var usuario_encontrado = _contextoBaseDeDatos.Clientes.FirstOrDefault(x => x.Email == peticion.Email && x.Contraseña == peticion.Contraseña);
            if (usuario_encontrado == null)
            {
                return await Task.FromResult<AutorizacionRespuesta>(null);
            }

            string token = GenerarToken(usuario_encontrado.Id.ToString());
            return new AutorizacionRespuesta
            {
                NombreUsuario = usuario_encontrado.Nombre,
                Resultado = true,
                Token = token,
                Mensaje = "Autenticación exitosa"
            };
        }


    }
}
