using Figura.SpeedwayRider.Model.DAO;

namespace Figura.Speedway.Model.Parameters
{
    public class EventParameter
    {
        public Rider Rider { get; set; } = new Rider();
        public int RiderStartingNumber { get; set; }
        public string RiderResults { get; set; } = String.Empty;
        public string RiderHomeAway { get; set; } = String.Empty;

    }
}
