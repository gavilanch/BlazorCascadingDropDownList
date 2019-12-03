using BlazorCRUDApp.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUDApp.Server
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            var countries = new List<Country>()
            {
                new Country(){Id = 1, Name = "Dominican Republic"},
                new Country(){Id = 2, Name = "United States" }
            };

            builder.Entity<Country>().HasData(countries);

            var states = new List<State>() {
              new State {Id = 1, Name = "Santo Domingo", CountryId = 1},
              new State {Id = 2, Name = "San Cristobal", CountryId = 1},
              new State {Id = 3, Name = "Vermont", CountryId = 2},
              new State {Id = 4, Name = "New York", CountryId = 2}
            };

            builder.Entity<State>().HasData(states);

            var people = new List<Person>();
            for (int i = 6; i < 15; i++)
            {
                people.Add(new Person() { Id = i, Name = $"Person {i}", StateId = 1 });
            }

            builder.Entity<Person>().HasData(people);

            base.OnModelCreating(builder);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
    }
}
