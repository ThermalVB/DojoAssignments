using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace restaurantreviews.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        [MinLength(2)]
        public string UserName { get; set; }

        [Required]
        [MinLength(2)]
        public string RestoName { get; set; }

        [Required]
        [MinLength(2)]
        public string ReviewText { get; set; }

        [Required]
        public DateTime DateOfVisit { get; set; }

        [Required]
        public rRating Rating { get; set; }
    }
    
    public enum rRating : int { One = 1, Two = 2, Three = 3, Four = 4, Five = 5 };

}