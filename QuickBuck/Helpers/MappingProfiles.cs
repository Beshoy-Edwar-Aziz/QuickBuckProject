﻿using AutoMapper;
using QuickBuck.Core.Models;
using QuickBuck.DTOs;

namespace QuickBuck.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<JobSeeker, JobSeekerToReturnDTO>()
                .ForMember(d => d.Photo, O => O.MapFrom<ResolveImage>())
                .ForMember(d=>d.UserFName,O=>O.MapFrom(s=>s.AppUser.FirstName))
                .ForMember(d=>d.UserLName,o=>o.MapFrom(s=>s.AppUser.LastName))
                .ForMember(d=>d.UserName,o=>o.MapFrom(s=>s.AppUser.UserName))
                .ForMember(d=>d.Address,o=>o.MapFrom(s=>s.AppUser.Address));
            CreateMap<JobProvider, JobProviderToReturnDTO>()
                .ForMember(d => d.Logo, o => o.MapFrom<ResolveImageJobProvider>()).ReverseMap();
            CreateMap<JobPost, JobPostToReturnDTO>();
            CreateMap<JobApplication, JobApplicationToReturnDTO>()
                .ForMember(d=>d.JobSeekerName,o=>o.MapFrom(JA => JA.JobSeeker.AppUser.UserName))
                .ForMember(d=>d.CV,o=>o.MapFrom<ResolveFiles>());
            CreateMap<Messages, MessageToReturnDTO>();
        }
    }
}
