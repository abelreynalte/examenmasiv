using AutoMapper;

namespace ExamenMasiv.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapper;
        public static void Configure()
        {
            //Mapper.Initialize(x =>
            //{
            //    x.AddProfile<DataEntitiesToBusinessEntitiesMappingProfile>();
            //    x.AddProfile<BusinessEntitiesToDataEntitiesMappingProfile>();
            //});
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BusinessEntitiesToDataEntitiesMappingProfile());
            });
            Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }
}
