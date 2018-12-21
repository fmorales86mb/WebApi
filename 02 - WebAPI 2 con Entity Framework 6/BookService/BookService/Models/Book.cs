﻿using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string  Title { get; set; }
        public int year { get; set; }
        public decimal Price { get; set; }        
        public string Genre { get; set; }

        // Clave foranea
        public int AuthorId { get; set; }
        // Navigation property
        public Author Author { get; set; }
    }
}