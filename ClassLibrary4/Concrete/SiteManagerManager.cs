using AutoMapper;
using HR_Project_Group3_App.DTOs.SiteManagerDTO;
using HR_Project_Group3_App.IRepositories;
using HR_Project_Group3_App.Services;
using HR_Project_Group3_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_Persistence.Concrete
{
    public class SiteManagerManager : ISiteManagerService
    {
        private readonly ISiteManagerRepository siteOwnerRepository;
        private readonly IMapper mapper;

        public SiteManagerManager(ISiteManagerRepository siteOwnerRepository, IMapper mapper)
        {
            this.siteOwnerRepository = siteOwnerRepository;
            this.mapper = mapper;
        }

        public async Task<DetailsSiteManager> GetDetailSiteOwner(int id)
        {
            if (id > 0)
            {
                DetailsSiteManager resultSum = await siteOwnerRepository.GetFilteredFirstOrDefault(select: x => new DetailsSiteManager
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SecondLastName = x.SecondLastName,
                    SecondName = x.SecondName,
                    Address = x.Address,
                    Email = x.AppUser.Email,
                    PhoneNumber = x.PhoneNumber,
                    BirthDate = x.BirthDate,
                    BirthPlace = x.BirthPlace,
                    HireDate = x.HireDate,
                    ImagePath = x.ImagePath,
                    LeavingDate = x.LeavingDate,
                    TCNO = x.TCNO,
                }, where: x => x.Id == id && x.Status != Status.Passive, include: q => q.Include(x => x.AppUser).Include(x => x.Job));

                return resultSum;
            }
            else
            {
                return null;
            }
        }


        public async Task<UpdateSiteManager> GetUpdateSiteOwner(int id)
        {
            if (id > 0)
            {
                UpdateSiteManager resultSum = await siteOwnerRepository.GetFilteredFirstOrDefault(select: x => new UpdateSiteManager
                {
                    AddressDetail = x.AddressDetail,
                    City = x.City,
                    District = x.District,
                    ImagePath = x.ImagePath,
                    PhoneNumber = x.PhoneNumber

                }, where: x => x.Id == id && x.Status != Status.Passive);

                return resultSum;
            }
            else
            {
                return null;
            }
        }
    }
}

