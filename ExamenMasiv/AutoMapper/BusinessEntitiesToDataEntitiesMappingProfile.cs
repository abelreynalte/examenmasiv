using AutoMapper;
using ExamenMasiv.DTOs;
using ExamenMasiv.Models;

namespace ExamenMasiv.AutoMapper
{
    public class BusinessEntitiesToDataEntitiesMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "BusinessEntitiesToDataEntitiesMappingProfile"; }
        }

        public BusinessEntitiesToDataEntitiesMappingProfile()
        {
            CreateMap<Ruleta, RuletaDTO>();
        }
    }
}
