using AutoMapper;
using VideogiochiAppApi.Dto;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Videogioco, VideogiocoDto>().ReverseMap();
            CreateMap<Proprietario, ProprietarioDto>().ReverseMap();
            CreateMap<Paese, PaeseDto>().ReverseMap();


        }


    }
}
