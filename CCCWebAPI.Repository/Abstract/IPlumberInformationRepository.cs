using CCCWebAPI.Models.ViewModels;
namespace CCCWebAPI.Repository.Abstract
{
    public interface IPlumberInformationRepository
    {
        public IList<PlumberInfoVM> GetPlumbInfo(int searchcriteria);
        int AddUpdatePlumberInfo(IndividualInfoVM addCustomerVM);
        int DelPlumberInfo(int houseNumber);
    }
}
