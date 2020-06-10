using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoard.Client.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field Job is Required")]
        public string JobName { get; set; }
        public string Description { get; set; }
       [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy }",
            ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Field  is Required")]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy }",
            ApplyFormatInEditMode = true)]
        public DateTime? ExpiresAt { get; set; }
    }
}