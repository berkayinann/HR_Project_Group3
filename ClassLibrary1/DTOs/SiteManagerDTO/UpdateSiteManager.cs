using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_App.DTOs.SiteManagerDTO
{
    public class UpdateSiteManager
    {
        public string? ImagePath { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressDetail { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile UploadPath { get; set; }
    }
}
