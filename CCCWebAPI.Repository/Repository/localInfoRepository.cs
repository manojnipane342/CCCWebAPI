using AutoMapper;
using CCCWebAPI.Models.EF_Models;
using CCCWebAPI.Models.ViewModels;
using CCCWebAPI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
namespace CCCWebAPI.Repository.Repository
{
    public class localInfoRepository : IlocalInfoRepository
    {
        private CCCWebAPIEntities _context;
        private readonly IMapper _mapper;

        public localInfoRepository(CCCWebAPIEntities context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // Get List of Customers
        public IList<LocalInfoDetailsVM> GetLocalInfo(int searchcriteria)
        {
            IList<TblInformationloc> info;

            if (searchcriteria == null || searchcriteria == 0)
            {
                info = _context.TblInformationloc.ToList();
            }
            else
            {
                info = _context.TblInformationloc.Where(y => (y.House_No == searchcriteria)).ToList();
            }
            var infoLocalDetails = _mapper.Map<IList<LocalInfoDetailsVM>>(info);

            return infoLocalDetails;
        }
        public int AddUpdateLocalInfo(LocalInfoDetailsVM addInfoDetailsVM)
        {
            int result = 0;

            try
            {
                // Check to ensure Customer Doesn't already exist in DB
                TblInformationloc _info = _context.TblInformationloc.Where(c => c.House_No == addInfoDetailsVM.House_No).SingleOrDefault();

                if (_info != null)
                {
                    _info.BIN = addInfoDetailsVM.BIN;
                    _info.Street_name = addInfoDetailsVM.Street_name;
                    _info.Owner_name = addInfoDetailsVM.Owner_name;
                    _info.Borough = addInfoDetailsVM.Borough;
                    _info.Block = addInfoDetailsVM.Block;
                    _info.LOT = addInfoDetailsVM.LOT;
                    _info.Community_Board = addInfoDetailsVM.Community_Board;
                    _info.No_meters = addInfoDetailsVM.No_meters;
                    _info.No_stories = addInfoDetailsVM.No_stories;
                    _info.Active_meters = addInfoDetailsVM.Active_meters;
                    _context.Update(_info);

                    _context.SaveChanges();
                }
                else
                {
                    TblInformationloc _infoAdd = new TblInformationloc();

                    _infoAdd.Street_name = addInfoDetailsVM.Street_name;
                    _infoAdd.Owner_name = addInfoDetailsVM.Owner_name;
                    _infoAdd.Borough = addInfoDetailsVM.Borough;
                    _infoAdd.Block = addInfoDetailsVM.Block;
                    _infoAdd.LOT = addInfoDetailsVM.LOT;
                    _infoAdd.BIN = addInfoDetailsVM.BIN;
                    _infoAdd.Community_Board = addInfoDetailsVM.Community_Board;
                    _infoAdd.No_stories = addInfoDetailsVM.No_stories;
                    _infoAdd.No_meters = addInfoDetailsVM.No_meters;
                    _infoAdd.Active_meters = addInfoDetailsVM.Active_meters;

                    _context.TblInformationloc.Add(_infoAdd);

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
        public int DelLocalInfo(int houseNumber)
        {
            int result = 0;
            TblInformationloc orderDetailDelete = _context.TblInformationloc.FirstOrDefault(s => s.House_No == houseNumber);
            _context.Entry(orderDetailDelete).State = EntityState.Deleted;
            _context.SaveChanges();
            result = 1;

            return result;
        }
    }
}
