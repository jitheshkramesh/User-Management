using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagementSystem.Models
{
    public class tblUserDetails
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string FilePath { get; set; }
        public string ImagePath { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
    }
}