using System.Reflection.Metadata;
using SeguridadCiudadana.Infrastructure.Context;
using SeguridadCiudadana.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace SC.Infrastructure.Repositories
{
    public class RepoSql
    {
        public async Task<IQueryable<Policia>> GetAll()
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = await  _context.Policias.Include(x => x.IdpersonaNavigation).Include(x=>x.IdrangoNavigation).Include(x=>x.IdestacionNavigation).Include(x=> x.IdestacionNavigation.IddireccionNavigation).Include(x => x.IdtipousuarioNavigation).ToListAsync();
            return query.AsQueryable();
        }

         public async Task<IQueryable<Estacion>> GetAllEstacion()
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = await  _context.Estacions.Include(x => x.IddireccionNavigation).ToListAsync();
            return query.AsQueryable();
        }

         public async Task<IQueryable<Rango>> GetAllRangos()
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = await  _context.Rangos.Select(Rango => Rango).ToListAsync();
            return query.AsQueryable();
        }

         public async Task<IQueryable<Genero>> GetAllGeneros()
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = await  _context.Generos.Select(Genero => Genero).ToListAsync();
            return query.AsQueryable();
        }


        public async Task<IQueryable<Direccionessegura>> GetAllRutas()
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = await  _context.Direccionesseguras.Select(Direccionessegura => Direccionessegura).ToListAsync();
            return query.AsQueryable();
        }
         public async Task<IQueryable<Usuario>> GetAllUsuarios()
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = await  _context.Usuarios.Select(Usuario => Usuario).ToListAsync();
            return query.AsQueryable();
        }
         public Policia GetById(int id)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = _context.Policias.FirstOrDefault(Policia => Policia.Idpolicias ==id);
            return query;
        }

         public async Task<Policia> GetById2(int id)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = await _context.Policias.Include(x => x.IdpersonaNavigation).Include(x=>x.IdrangoNavigation).Include(x=>x.IdestacionNavigation).Include(x=> x.IdestacionNavigation.IddireccionNavigation).Include(x => x.IdtipousuarioNavigation).FirstOrDefaultAsync(x => x.Idpolicias == id);
            return query;
        }


          public async Task<Estacion> GetByIdEstacion2(int id)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query =  _context.Estacions.Include(x => x.IddireccionNavigation).FirstOrDefault(Estacion => Estacion.Idestacion ==id);
            return query;
        }

         public Estacion GetByIdEstacion(int id)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query =  _context.Estacions.FirstOrDefault(Estacion => Estacion.Idestacion ==id);
            return query;
        }



        public Usuario GetByIdUsuarios(int id)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = _context.Usuarios.FirstOrDefault(Usuario => Usuario.Idpolicias == id);
            return query;
        }

        public async Task<Usuario> GetByIdUsuarios2(int id)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var query = await _context.Usuarios.Include(x => x.IdpersonaNavigation).Include(x => x.IdtipousuarioNavigation).FirstOrDefaultAsync(x => x.Idusuario == id);
            return query;
        }

        public async Task<int> Create(Policia policia)
        {
            var entity = policia;
            var _context = new SEGURIDADCIUDADANAContext();
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("No fue posible realizar el registro...");

            return entity.Idpolicias;
        }


        public async Task<int> CreateEstacion(Estacion estacion)
        {
            var entity = estacion;
            var _context = new SEGURIDADCIUDADANAContext();
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("No fue posible realizar el registro...");

            return entity.Idestacion;
        }

        public async Task<int> CreateUsuario(Usuario usuario)
        {
            var entity = usuario;
            var _context = new SEGURIDADCIUDADANAContext();
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if (rows <= 0)
                throw new Exception("No fue posible realizar el registro...");

            return entity.Idusuario;
        }

        public async Task<bool> Update(int id, Policia policia)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            if(id <= 0 || policia == null)
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");
            var entity =  GetById(id);
            entity = policia;
            _context.Update(entity);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> UpdateEstacion(int id, Estacion estacion)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            if(id <= 0 || estacion == null)
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");
           var entity =  GetByIdEstacion(id);
                entity = estacion;
           _context.Update(entity);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }


        public async Task<bool> UpdateUsuarios(int id, Usuario usuario)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            if (id <= 0 || usuario == null)
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");
            var entity = GetByIdUsuarios(id);
            entity = usuario;
            _context.Update(entity);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var entity = GetById(id);
            _context.Remove(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
        }


        public async Task<bool> DeleteEstacion(int id)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var entity = GetByIdEstacion(id);
            _context.Remove(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var _context = new SEGURIDADCIUDADANAContext();
            var entity = GetByIdUsuarios(id);
            _context.Remove(entity);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}