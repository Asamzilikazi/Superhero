using Microsoft.EntityFrameworkCore;
using Superheroes.DataAccess;
using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superheroes.Repository
{
    public class SuperheroRepository
    {
        private readonly SuperheroDbContext _context;

        public SuperheroRepository(SuperheroDbContext context)
        {
            _context = context;
        }

        public void AddFavoriteSuperhero(Superhero superhero)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    superhero.biography.SuperheroId = superhero.id;
                    superhero.appearance.SuperheroId = superhero.id;
                    superhero.connections.SuperheroId = superhero.id;
                    superhero.image.SuperheroId = superhero.id;
                    superhero.powerstats.SuperheroId = superhero.id;
                    superhero.work.SuperheroId = superhero.id;


                    _context.Superheroes.Add(superhero);
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Log the exception or handle it accordingly
                    throw;
                }
            }
        }

        public void RemoveFavoriteSuperhero(string superheroId)
        {
            try
            {
                var superhero = _context.Superheroes
                    .Include(s => s.powerstats)
                    .Include(s => s.biography)
                    .Include(s => s.appearance)
                    .Include(s => s.work)
                    .Include(s => s.connections)
                    .Include(s => s.image)
                    .FirstOrDefault(s => s.id == superheroId);

                if (superhero != null)
                {
                    // Remove related entities
                    _context.RemoveRange(superhero.powerstats);
                    _context.RemoveRange(superhero.biography);
                    _context.RemoveRange(superhero.appearance);
                    _context.RemoveRange(superhero.work);
                    _context.RemoveRange(superhero.connections);
                    _context.RemoveRange(superhero.image);

                    // Remove the superhero itself
                    _context.Superheroes.Remove(superhero);

                    _context.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException($"Superhero with ID {superheroId} not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw;
            }
        }

        public IEnumerable<Superhero> GetFavoriteSuperheroes()
        {
            return _context.Superheroes
                   .Include(s => s.powerstats)
                   .Include(s => s.biography)
                   .Include(s => s.appearance)
                   .Include(s => s.work)
                   .Include(s => s.connections)
                   .Include(s => s.image)
                   .ToList();

        }

    }

}
