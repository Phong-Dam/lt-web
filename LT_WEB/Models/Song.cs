using System;
using System.ComponentModel.DataAnnotations;

namespace DoAN_WEB.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Artist { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Link { get; set; }
        
        public int Views { get; set; }
    }
} 