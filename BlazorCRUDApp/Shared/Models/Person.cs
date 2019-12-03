using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorCRUDApp.Shared.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "You must select a state")]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
