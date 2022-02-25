using System;
using System.IO;
using System.Xml;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; 
using SeguridadCiudadana.Domain.Entities;
using SC.Infrastructure.Repositories;
using SeguridadCiudadana.Domain.Dtos;


namespace SeguridadCiudadana.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        public UsuariosController(IHttpContextAccessor httpContext)
        {
            this._httpContext = httpContext;
        }

        [HttpGet]
        [Route("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var _context = new RepoSql();
            var respuesta = await _context.GetAllUsuarios();
            var respuesta2 = respuesta.Select(x => CreateDTOFromObjects(x));
            return Ok(respuesta2);

        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var _context = new RepoSql();

            var usuario = await _context.GetById2(id);


            var respuesta2 = CreateDTOFromObjects2(usuario);

            return Ok(respuesta2);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UsuariosCreateRequest usuario)
        {


            var entity = CreateObjctFromDTO(usuario);
            var _context = new RepoSql();
            var id = await _context.Create(entity);

            var urlresult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/person/{id}";
            return Created(urlresult, id);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuariosCreateRequest usuario)
        {
            var _context = new RepoSql();
            if (id <= 0)
                return NotFound("El registro no fué encontrado, veifica tu información...");
            usuario.Idusuario = id;
            var entity = CreateObjctFromDTO(usuario);
            var update = await _context.Update(id, entity);
            if (!update)
                return Conflict("Ocurrió un fallo al intentar realizar la modificación...");
            return NoContent();
        }


        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var _repo = new RepoSql();
            var _context = await _repo.Delete(id);

            if (_context == false)
                return NotFound("no se encontraron valores");

            return NoContent();
        }



        private UsuarioResponse CreateDTOFromObjects(Usuario usuario)
        {
            var dtos = new UsuarioResponse
            {
                Idusuario = usuario.Idusuario,

                NombreCompleto = usuario.IdpersonaNavigation == null ? string.Empty : $"{usuario.IdpersonaNavigation.Nombre} {usuario.IdpersonaNavigation.Apellidos}",
                Edad = usuario.IdpersonaNavigation == null ? null : usuario.IdpersonaNavigation.Edad,
                Direccion = usuario.IddireccionNavigation == null ? string.Empty : $"{usuario.IddireccionNavigation.Estado} {usuario.IddireccionNavigation.Municipio} {usuario.IddireccionNavigation.Colonia} {usuario.IddireccionNavigation.Calle} {usuario.IddireccionNavigation.Cruzamientos}"
            };
            return dtos;
        }

        private UsuarioResponse CreateDTOFromObjects2(Usuario usuario)
        {
            var dtos = new PoliciaResponse
            {
                Idusuario = usuario.Idusuario,

                NombreCompleto = usuario.IdpersonaNavigation == null ? string.Empty : $"{usuario.IdpersonaNavigation.Nombre} {usuario.IdpersonaNavigation.Apellidos}",
                Edad = usuario.IdpersonaNavigation == null ? null : usuario.IdpersonaNavigation.Edad,
                Direccion = usuario.IddireccionNavigation == null ? string.Empty : $"{usuario.IddireccionNavigation.Estado} {usuario.IddireccionNavigation.Municipio} {usuario.IddireccionNavigation.Colonia} {usuario.IddireccionNavigation.Calle} {usuario.IddireccionNavigation.Cruzamientos}"
            

        };

            return dtos;
        }






        private Usuario CreateObjctFromDTO(UsuariosCreateRequest dto)
        {
            var usuario = new Usuario
            {
                Idusuario = dto.Idusuario,
                IdpersonaNavigation = new Persona
                {
                    Nombre = dto.Nombre,
                    Apellidos = dto.Apellidos,
                    Edad = dto.Edad
                },
               
               /* {
                    
                    Correo = dto.Correo,
                    Contraseña = dto.Contraseña
                },*/
            };

            return usuario;
        }

    }
}