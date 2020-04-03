using CodingTest.Domain.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Domain.Models
{
    // data model can used for migration table
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Complete { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TimeExpired { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EStatus Status { get; set; }
    }
}
