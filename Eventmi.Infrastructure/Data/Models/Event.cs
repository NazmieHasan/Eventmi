﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Eventmi.Infrastructure.Data.Models
{

    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [Required]
        [StringLength(100)]
        public string Place { get; set; } = null!;
    }
}
