using AutoMapper;
using CCCWebAPI.Models.EF_Models;
using CCCWebAPI.Models.ViewModels;
using CCCWebAPI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
namespace CCCWebAPI.Repository.Repository
{
    public class PlumberInformationRepository : IPlumberInformationRepository
    {
        private CCCWebAPIEntities _context;
        private readonly IMapper _mapper;
        public PlumberInformationRepository(CCCWebAPIEntities context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IList<PlumberInfoVM> GetPlumbInfo(int searchcriteria)
        {
            IList<TblPlumber> info;

            if (searchcriteria == null || searchcriteria == 0)
            {
                info = _context.TblPlumber.ToList();
            }
            else
            {
                info = _context.TblPlumber.Where(y => (y.Id == searchcriteria)).ToList();
            }
            var infoLocalDetails = _mapper.Map<IList<PlumberInfoVM>>(info);

            return infoLocalDetails;
        }
        public int AddUpdatePlumberInfo(IndividualInfoVM addInfoDetailsVM)
        {
            int result = 0;

            try
            {
                // Check to ensure Customer Doesn't already exist in DB
                TblPlumber _info = _context.TblPlumber.Where(c => c.Id == addInfoDetailsVM.Id).SingleOrDefault();

                if (_info != null)
                {
                    //_info.HouseNo = addInfoDetailsVM.HouseNo;
                    _info.FName = addInfoDetailsVM.Fname;
                    _info.LName = addInfoDetailsVM.Lname;
                    _info.MiddleInital = addInfoDetailsVM.MiddleIntial;
                    _info.BusinessFax = addInfoDetailsVM.BusinessTax;
                    _info.BusinessName = addInfoDetailsVM.BusinessName;
                    _info.BusinessTelephone = addInfoDetailsVM.BusinessTelephone;
                    _info.Address = addInfoDetailsVM.Address;
                    _info.City = addInfoDetailsVM.City;
                    _info.State = addInfoDetailsVM.State;
                    _info.ZipCode = addInfoDetailsVM.ZipCode;
                    _info.Mobile = addInfoDetailsVM.MobileTelephone;
                    _info.Email = addInfoDetailsVM.Email;
                    //_info.EmployerName = addInfoDetailsVM.EmployerName;
                    _context.Update(_info);

                    _context.SaveChanges();
                }
                else
                {
                    TblPlumber _infoAdd = new TblPlumber();

                    _infoAdd.FName = addInfoDetailsVM.Fname;
                    _infoAdd.LName = addInfoDetailsVM.Lname;
                    _infoAdd.MiddleInital = addInfoDetailsVM.MiddleIntial;
                    _infoAdd.BusinessFax = addInfoDetailsVM.BusinessTax;
                    _infoAdd.BusinessName = addInfoDetailsVM.BusinessName;
                    _infoAdd.BusinessTelephone = addInfoDetailsVM.BusinessTelephone;
                    _infoAdd.Address = addInfoDetailsVM.Address;
                    _infoAdd.City = addInfoDetailsVM.City;
                    _infoAdd.State = addInfoDetailsVM.State;
                    _infoAdd.ZipCode = addInfoDetailsVM.ZipCode;
                    _infoAdd.Mobile = addInfoDetailsVM.MobileTelephone;
                    _infoAdd.Email = addInfoDetailsVM.Email;
                    _infoAdd.LicenceNumber = addInfoDetailsVM.LicenceNumber;

                    _context.TblPlumber.Add(_infoAdd);

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
        public int DelPlumberInfo(int houseNumber)
        {
            int result = 0;
            TblPlumber orderDetailDelete = _context.TblPlumber.FirstOrDefault(s => s.Id == houseNumber);
            _context.Entry(orderDetailDelete).State = EntityState.Deleted;
            _context.SaveChanges();
            result = 1;

            return result;
        }
    }
}
