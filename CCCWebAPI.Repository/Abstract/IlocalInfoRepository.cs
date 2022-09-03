using CCCWebAPI.Models.ViewModels;
namespace CCCWebAPI.Repository.Abstract
{
    public interface IlocalInfoRepository
    {
        public IList<LocalInfoDetailsVM> GetLocalInfo(int searchcriteria);
        public int AddUpdateLocalInfo(LocalInfoDetailsVM addInfoDetailsVM);
        public int DelLocalInfo(int houseNumber);
    }
}
