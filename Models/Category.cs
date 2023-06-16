﻿using System.ComponentModel.DataAnnotations;

namespace KsiegarniaProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookCategory> BookCategories { get; set;}
    }
}
