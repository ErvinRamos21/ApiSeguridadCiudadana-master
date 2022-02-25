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
public class LugaresController : ControllerBase
{

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var _context = new RepoSql();
        var respuesta = await _context.GetAllRutas();
        var respuesta2 = respuesta.Select(x => CreateDTOFromObjects(x));
        return Ok(respuesta2);

    }

         private DireccionessegurasResponse CreateDTOFromObjects(Direccionessegura direccion)
    {
         var dtos = new DireccionessegurasResponse{ 
         Latitud = direccion.Latitud == null ? null : direccion.Latitud,
         Longitud = direccion.Latitud == null ? null : direccion.Latitud,
         Tipopeligro = direccion.IdpeligroNavigation == null ? string.Empty : direccion.IdpeligroNavigation.Tipopeligro,
         Descripcion = direccion.IdpeligroNavigation == null ? string.Empty : direccion.IdpeligroNavigation.Descripcion
            };
         return dtos;
    }
}