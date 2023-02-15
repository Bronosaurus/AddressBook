using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AddressBook.Models
{
    
    public class Item
    {
        [Key]
        public string Name { get; set; }
        public string? Street1 { get; set; }
        public string? Street2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }

    
}
