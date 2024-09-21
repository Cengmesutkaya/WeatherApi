namespace WeatherApi.Helpers
{
    public static class UserNameHelper
    {
        public static string GenerateUsername(string firstName, string lastName)
        {
            return $"{firstName.Substring(0, 2).ToLower()}{lastName.Substring(0, 2).ToLower()}{new Random().Next(10000, 99999)}";
        }
    }
}
