using Figura.Speedway.Model.Parameters;
using Figura.SpeedwayRider.Model.DAO;

namespace Figura.Speedway.Service
{
    public interface ISpeedwayService
    {
        public Task<List<Rider>> GetAllRiders();

        public Task<List<EventParameter>> BuildSpeedwayEventBasedOnApiData(string link);
    }
}
