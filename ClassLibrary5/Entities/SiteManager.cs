﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_Domain.Entities
{
    public class SiteManager : Person, IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }

        [NotMapped]
        public IFormFile UploadPath { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

    }
}
