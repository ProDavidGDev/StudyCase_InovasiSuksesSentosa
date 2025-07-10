using System.ComponentModel.DataAnnotations;

namespace Study_Case_4.Models
{
    public class ListNama
    {
        [Key]
        public string NIK { get; set; }
        public string Nama { get; set; }
    }
}
