using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Superheroes.Models;
using Superheroes.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Superheroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SuperheroRepository _superheroRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDistributedCache _cache;

        public SuperheroesController(IConfiguration configuration, IHttpClientFactory httpClientFactory, SuperheroRepository superheroRepository, IDistributedCache cache)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _superheroRepository = superheroRepository;
            _cache = cache;
        }

        [HttpGet("search/{accessToken}/{name}")]
        public async Task<IActionResult> SearchSuperhero(string accessToken, string name)
        {
            // Check if data exists in cache
            var cachedData = await _cache.GetStringAsync($"superhero_{name}");
            if (cachedData != null)
            {
                return Ok(cachedData);
            }

            var baseUrl = _configuration["SuperheroApiBaseUrl"];
            var requestUri = $"{baseUrl}/{accessToken}/search/{name}";

            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync(requestUri);
                    response.EnsureSuccessStatusCode(); // Throws if HTTP response status is unsuccessful

                    var content = await response.Content.ReadAsStringAsync();

                    // Store data in cache
                    await _cache.SetStringAsync($"superhero_{name}", content, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Set cache expiration time
                    });

                    return Ok(content);
                }
            }
            catch (HttpRequestException)
            {
                return StatusCode(500, "Error searching superhero.");
            }
        }


        [HttpPost("addFavorites")]
        public async Task<IActionResult> AddFavorite([FromBody] Superhero superhero)
        {
            try
            {
                if (superhero != null)
                {
                    _superheroRepository.AddFavoriteSuperhero(superhero);
                    return Ok($"Superhero with ID {superhero.id} added to favorites successfully.");
                }
                else
                {
                    return BadRequest("Invalid superhero data.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "An error occurred while adding the superhero to favorites.");
            }
        }

        // New method to get favorite superheroes
        [HttpGet("getFavorites")]
        public IActionResult GetFavoriteSuperheroes()
        {
            try
            {
                var favoriteSuperheroes = _superheroRepository.GetFavoriteSuperheroes();
                return Ok(favoriteSuperheroes);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "An error occurred while retrieving favorite superheroes.");
            }
        }

        // Define a method to clear specific cache keys
        private void ClearCacheEntries(IEnumerable<string> cacheKeys)
        {
            foreach (var key in cacheKeys)
            {
                _cache.Remove(key);
            }
        }

        // Usage in your action
        [HttpDelete("removeFavorites/{superheroId}")]
        public IActionResult RemoveFavorite(string superheroId)
        {
            try
            {
                _superheroRepository.RemoveFavoriteSuperhero(superheroId);

                // Clear specific cache entries associated with the removed superhero
                ClearCacheEntries(new[] { $"superhero_{superheroId}" });

                return Ok($"Superhero with ID {superheroId} removed from favorites successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "An error occurred while removing the superhero from favorites.");
            }
        }


    }
}
