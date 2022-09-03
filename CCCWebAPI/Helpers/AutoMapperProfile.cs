using AutoMapper;
using CCCWebAPI.Models.EF_Models;
using CCCWebAPI.Models.ViewModels;
using System.Reflection;

namespace CCCWebAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TblIndividualInfo, IndividualInfoVM>();
            CreateMap<IndividualInfoVM, TblInformationloc>();
            CreateMap<TblIndividualInfo, IndividualInfoVM>();
            //CreateMap<List<IndividualInfoVM>(),<List >< TblIndividualInfo > ();

            CreateMap<LocalVariableInfo, LocalInfoDetailsVM>();
            //CreateMap<LocalInfoDetailsVM, LocalVariableInfo>();

            CreateMap<TblPlumber, PlumberInfoVM>();
            CreateMap<TblUsers, UsersSignupVM>();
            //CreateMap<PlumberInfoVM, TblPlumber>();


        }
    }
}
