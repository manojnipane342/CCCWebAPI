using CCCWebAPI.Models.ViewModels;

namespace CCCWebAPI.Repository.Abstract
{
    public interface IIndividualInfoRepository
    {
        public IList<IndividualInfoVM> GetIndividualInfo(int searchcriteria);
        public int AddUpdateIndividualInfo(IndividualInfoVM individualInfoDetailsVM);
        public int DelIndividualInfo(int id);
    }
}
