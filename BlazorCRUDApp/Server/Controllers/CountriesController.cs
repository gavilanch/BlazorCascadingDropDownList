using BlazorCRUDApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUDApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CountriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> Get()
        {
            return await context.Countries.OrderBy(x => x.Name).ToListAsync();
        }

        [HttpGet("{countryId}/states")]
        public async Task<List<State>> GetStates(int countryId)
        {
            return await context.States.Where(x => x.CountryId == countryId)
                .OrderBy(x => x.Name).ToListAsync();
        }
    }
}
