using AutoMapper;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashbord.ViewModels;

namespace Landing.PL.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<BuildingFormVM, Building>();
            CreateMap<Building,BuildingFormVM>();
            CreateMap<Building,BuildingVM >();
            CreateMap<Building, BuildingDetailsVM>();


        }
    }
}
