using AutoMapper;
using CvApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CvApp.Models.DTO;
using CvApp.Models.DTO.CvApp.Data.Entities;

namespace CvApp.Business.MapProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CertificateEntity, CertificateDTO>().ReverseMap();
            CreateMap<EducationEntity, EducationDTO>().ReverseMap();
            CreateMap<JobInformationEntity, JobInformationDTO>().ReverseMap();
            CreateMap<KnownProgramEntity, KnownProgramDTO>().ReverseMap();
            CreateMap<LanguageEntity, LanguageDTO>().ReverseMap();
            CreateMap<PersonEntity, PersonDTO>().ReverseMap();
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<ServiceEntity, ServiceDTO>().ReverseMap();
            CreateMap<MessageEntity, MessageDTO>().ReverseMap();
            CreateMap<ReferanceEntity, ReferanceDTO>().ReverseMap();
            CreateMap<FactEntity, FactDTO>().ReverseMap();
        }
    }
}
