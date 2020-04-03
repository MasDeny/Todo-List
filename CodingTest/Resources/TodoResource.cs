using CodingTest.Domain.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Resources
{
    public class TodoResource
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Complete { get; set; }

        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TimeExpired { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EStatus Status { get; set; }
    }
}
