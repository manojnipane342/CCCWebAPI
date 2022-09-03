using Common.Models;
using AutoMapper;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels.PaginationModel;

namespace Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoleModel, RoleModelVM>().ReverseMap();
            CreateMap<UserModel, UserModelVM>().ReverseMap();
            CreateMap<BoroughModel, BoroughModelVM>().ReverseMap();
            CreateMap<CertificationModel, CertificationModelVM>().ReverseMap();
            CreateMap<QuestionModel, QuestionModelVM>().ReverseMap();
            CreateMap<ReportModel, ReportModelVM>().ReverseMap();
            CreateMap<ReportQuestionModel, ReportQuestionModelVM>().ReverseMap();
        }
    }
}
