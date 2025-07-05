using Figura.Speedway.Model;
using Figura.Speedway.Model.Parameters;
using Figura.Speedway.ResultsApiReader;
using Figura.SpeedwayRider.DataContract;
using Figura.SpeedwayRider.Model.DAO;

namespace Figura.Speedway.Service
{
    public class SpeedwayService : ISpeedwayService
    {
        private readonly SpeedwayDb _context;

        private readonly IRiderDataService _riderDataService;
        private readonly IApiReaderManager _apiReaderManager;

        public SpeedwayService(SpeedwayDb context, IRiderDataService riderDataService, IApiReaderManager apiReaderManager)
        {
            _context = context;
            _riderDataService = riderDataService;
            _apiReaderManager = apiReaderManager;
        }

        public async Task<List<EventParameter>> BuildSpeedwayEventBasedOnApiData(string link)
        {
            link = "http://www.speedwayw.pl/dmp/1993/towr_1.htm";

            //get paired initials of riders from third part api link
            List<EventParameter> speedwayEvent = await _apiReaderManager.GetSpeedwayApiResults(link);

            List<Rider> ridersToFetch = speedwayEvent.Select(x => x.Rider).ToList();
            //get db riders records based on paired initials

            List<Rider> riders = await _riderDataService.FetchByInitials(ridersToFetch);

            foreach (var rider in riders)
            {
                for (int i = 0; i < speedwayEvent.Count; i++)
                {
                    if (speedwayEvent[i].Rider.Surname.Equals(rider.Surname.ToUpper()) && rider.Name.Contains(speedwayEvent[i].Rider.Name))
                    {
                        speedwayEvent[i].Rider = rider;
                        break;
                    }
                }
            }

            return speedwayEvent;
        }

        public async Task<List<Rider>> GetAllRiders()
        {
            string link2 = "http://localhost:5001/Rider/AllRiders";

            var res = await _riderDataService.GetAllRiders(link2);

            return res;
        }
    }
}
