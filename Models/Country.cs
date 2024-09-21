namespace WeatherApi.Models
{
    public class Country
    {
        public string Name { get; set; }
        public IDictionary<string, object> Idd { get; set; } // For phone code info
        public List<double> Latlng { get; set; }

    }
}
