using AutoMapper;
using CCCWebAPI.Models.EF_Models;
using CCCWebAPI.Models.ViewModels;
using CCCWebAPI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCCWebAPI.Repository.Repository
{
    public class IndividualInfoRepository : IIndividualInfoRepository
    {
        private CCCWebAPIEntities _context;
        private readonly IMapper _mapper;

        public IndividualInfoRepository(CCCWebAPIEntities context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IList<IndividualInfoVM> GetIndividualInfo(int searchcriteria)
        {
            IList<TblIndividualInfo> info;

            if (searchcriteria == null || searchcriteria == 0)
            {
                info = _context.TblIndividualInfo.ToList();
            }
            else
            {
                info = _context.TblIndividualInfo.Where(y => (y.Id == searchcriteria)).ToList();
            }
            var infoLocalDetails = _mapper.Map<IList<IndividualInfoVM>>(info);

            return infoLocalDetails;
        }
        public int AddUpdateIndividualInfo(IndividualInfoVM individualInfoDetailsVM)
        {
            int result = 0;

            try
            {
                // Check to ensure Customer Doesn't already exist in DB
                TblIndividualInfo _info = _context.TblIndividualInfo.Where(c => c.Id == individualInfoDetailsVM.Id).SingleOrDefault();

                if (_info != null)
                {
                    _info.Fname = individualInfoDetailsVM.Fname;
                    _info.Lname = individualInfoDetailsVM.Lname;
                    _info.BusinessName = individualInfoDetailsVM.BusinessName;
                    _info.MiddleIntial = individualInfoDetailsVM.MiddleIntial;
                    _info.BusinessName = individualInfoDetailsVM.BusinessName;
                    _info.BusinessTelephone = individualInfoDetailsVM.BusinessTelephone;
                    _info.BusinessTax = individualInfoDetailsVM.BusinessTax;
                    _info.Address = individualInfoDetailsVM.Address;
                    _info.City = individualInfoDetailsVM.City;
                    _info.State = individualInfoDetailsVM.State;
                    _info.ZipCode = individualInfoDetailsVM.ZipCode;
                    _info.MobileTelephone = individualInfoDetailsVM.MobileTelephone;
                    _info.Email = individualInfoDetailsVM.Email;
                    _info.EmployerName = individualInfoDetailsVM.EmployerName;
                    _context.Update(_info);

                    _context.SaveChanges();
                }
                else
                {
                    TblIndividualInfo _infoAdd = new TblIndividualInfo();

                    _infoAdd.Fname = individualInfoDetailsVM.Fname;
                    _infoAdd.Lname = individualInfoDetailsVM.Lname;
                    _infoAdd.BusinessName = individualInfoDetailsVM.BusinessName;
                    _infoAdd.MiddleIntial = individualInfoDetailsVM.MiddleIntial;
                    _infoAdd.BusinessName = individualInfoDetailsVM.BusinessName;
                    _infoAdd.BusinessTelephone = individualInfoDetailsVM.BusinessTelephone;
                    _infoAdd.BusinessTax = individualInfoDetailsVM.BusinessTax;
                    _infoAdd.Address = individualInfoDetailsVM.Address;
                    _infoAdd.City = individualInfoDetailsVM.City;
                    _infoAdd.State = individualInfoDetailsVM.State;
                    _infoAdd.ZipCode = individualInfoDetailsVM.ZipCode;
                    _infoAdd.MobileTelephone = individualInfoDetailsVM.MobileTelephone;
                    _infoAdd.Email = individualInfoDetailsVM.Email;
                    _infoAdd.EmployerName = individualInfoDetailsVM.EmployerName;

                    _context.TblIndividualInfo.Add(_infoAdd);

                    _context.SaveChanges();
                }
                // Create Candidate Course Exam Record

                result = 1;

            }
            catch (Exception e)
            {

                result = 0;
            }

            return result;
        }
        public int DelIndividualInfo(int id)
        {
            int result = 0;
            TblIndividualInfo orderDetailDelete = _context.TblIndividualInfo.FirstOrDefault(s => s.Id == id);
            _context.Entry(orderDetailDelete).State = EntityState.Deleted;
            _context.SaveChanges();
            result = 1;

            return result;
        }
    }
}
