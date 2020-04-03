using CodingTest.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Resources
{
    public class SaveTodoResource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title must to fill")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description must to fill")]
        public string Description { get; set; }

        [Required]
        public int Complete { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TimeExpired { get; set; }

        public EStatus Status { get; set; }
    }
}
