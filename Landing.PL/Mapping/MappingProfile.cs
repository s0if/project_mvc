using AutoMapper;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashbord.ViewModels;

namespace Landing.PL.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<BuildingFormVM, Building>().ReverseMap();
            CreateMap<Building,BuildingVM >();
            CreateMap<Building, BuildingDetailsVM>();

            CreateMap<ItemsFormVM,Item>().ReverseMap();
            CreateMap<Item, ItemsVM>();
            CreateMap<Item, ItemsDetailsVM>();
                             

        }
    }          
}                          
