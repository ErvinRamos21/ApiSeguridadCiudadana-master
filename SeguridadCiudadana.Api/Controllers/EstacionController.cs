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


namespace SeguridadCiudadana.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EstacionController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContext;

    public EstacionController(IHttpContextAccessor httpContext)
    {           
         this._httpContext = httpContext;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var _context = new RepoSql();
        var respuesta = await _context.GetAllEstacion();
        var respuesta2 = respuesta.Select(x => CreateDTOFromObjects(x));
        return Ok(respuesta2);
    }
        [HttpGet]
        [Route("GetById2/{id:int}")]
        public async Task<IActionResult> GetById2(int id)
        {
            var pelis = new RepoSql();
            var pelicula = pelis.GetByIdEstacion(id);
            if(pelicula==null)
                return NotFound("no se encontraron valores");
            return Ok(pelicula);
        } 


    [HttpGet]
    [Route("GetById/{id:int}")]
      public async Task<IActionResult> GetById(int id)
       {
            var _context = new RepoSql();
            var estacion = await _context.GetByIdEstacion2(id);
            //if(respuesta==null)
             //   return NotFound("no se encontraron valores");
            var respuesta2 = CreateDTOFromObjects2(estacion);
            
            return Ok(respuesta2);
       } 

     [HttpPost]
     [Route("Create")]
        public async Task<IActionResult> Create([FromBody]EstacionCreateRequest estacion)
        {
            

            var entity = CreateObjctFromDTO(estacion);
             var _context = new RepoSql();
             var id = await _context.CreateEstacion(entity);

            var urlresult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/person/{id}";
            return Created(urlresult, id);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstacionCreateRequest estacion)
        {
            var _context = new RepoSql();
            if(id <= 0)
                return NotFound("El registro no fué encontrado, veifica tu información...");

            estacion.idestacion = id;

            var entity = CreateObjctFromDTO(estacion);
            var update = await _context.UpdateEstacion(id, entity);

            if(!update)
                return Conflict("Ocurrió un fallo al intentar realizar la modificación...");

            return NoContent();            
        }


        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var _repo = new RepoSql();
            var _context =await _repo.DeleteEstacion(id);
           
            if(_context==false)
                return NotFound("no se encontraron valores");
            
            return NoContent();
        } 


    private EstacionResponse CreateDTOFromObjects(Estacion estacion)
    {
         var dtos = new EstacionResponse{
             Idestacion =estacion.Idestacion,
             Nombreestacion = estacion.Nombreestacion,
             Direccion = estacion.IddireccionNavigation == null ? string.Empty: $"{estacion.IddireccionNavigation.Estado} {estacion.IddireccionNavigation.Municipio} {estacion.IddireccionNavigation.Colonia} {estacion.IddireccionNavigation.Calle} {estacion.IddireccionNavigation.Cruzamientos}"
            };

         return dtos;
    }


       private EstacionResponse CreateDTOFromObjects2(Estacion estacion)
    {
         var dtos = new EstacionResponse{
             Idestacion =estacion.Idestacion,
             Nombreestacion = estacion.Nombreestacion,
             Estado = estacion.IddireccionNavigation.Estado,
             Municipio = estacion.IddireccionNavigation.Municipio,
             Colonia = estacion.IddireccionNavigation.Colonia,
             Calle = estacion.IddireccionNavigation.Calle,
             Cruzamientos = estacion.IddireccionNavigation.Cruzamientos
            };

         return dtos;
    }

    private Estacion CreateObjctFromDTO(EstacionCreateRequest dto)
        {
            var estacion = new Estacion{
                Idestacion = dto.idestacion,
                Nombreestacion = dto.Nombreestacion,
                IddireccionNavigation = new Direccione{
                    Estado = dto.Estado,
                    Municipio = dto.Municipio,
                    Colonia = dto.Colonia,
                    Calle = dto.Calle,
                    Cruzamientos= dto.Cruzamientos
                    }
            };

            return estacion;
        }


  
    

}
