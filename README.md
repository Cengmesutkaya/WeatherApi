Weather API Documentation
Overview
The Weather API provides users with real-time weather information based on their registered location. The API includes user registration, authentication, and weather data retrieval for a specific username.
Base URL
https://localhost:7260/api/weather
Repository URL
https://github.com/Cengmesutkaya/WeatherApi
Authentication
The API uses Basic Authentication to secure its endpoints. All requests to protected endpoints must include the Authorization header containing the user's username and password encoded in base64.
Authorization Header Format
Authorization: Basic <base64encoded(username:password)>
Endpoints
1. User Registration
URL: /api/registration
Method: POST
Authentication: Not required
Request Body:
{
   "firstname": "Mesut",
   "lastname": "Kaya",
   "Username": "",
   "email": "mesut.kaya@gmail.com",
   "password": "StrongPassword123",
   "address": "Eskişehir Turkey",
   "birthdate": "1990-02-15",
   "phoneNumber": "+134567890",
   "livingCountry": "USA",
   "citizenCountry": "USA"
}

Response:
•	201 Created – Successfully registered the user.
•	400 Bad Request – Validation error (e.g., missing required fields or invalid format).
Example Response (Success):
{
    "message": "User registered: ",
    "username": "meka12117"
}

2. User Login
URL: /api/login
Method: POST

Request Body:
{
  "username": "meka71900",
  "password": "StrongPassword123"
}

Response:
•	200 OK – Login successful.
•	401 Unauthorized – Invalid username or password.
Example Response (Success):
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1la2E3MTkwMCIsImVtYWlsIjoibWVzdXQua2F5YUBnbWFpbC5jb20iLCJuYmYiOjE3MjY4OTI0MjcsImV4cCI6MTcyNjg5NjAyNywiaWF0IjoxNzI2ODkyNDI3LCJpc3MiOiJXZWF0aGVyQXBpIiwiYXVkIjoiV2VhdGhlckFwaVVzZXJzIn0.6s5EI-c48UwnoTIOPHNEUet3vwM5vTbGMholgUSHVqQ








3. Get Weather Data by Username
URL: /api/weather/{username}
Method: GET
Authentication: Required
Path Parameters:
•	{username}: The username for which to retrieve the weather information.
•	https://localhost:7260/api/weather/meka71900
Response:
•	200 OK – Returns weather data for the requested location.
•	401 Unauthorized – Invalid authentication or missing credentials.
•	404 Not Found – If the user or their associated location is not found.
Example Response:
{
  "coord": {
    "lon": 36.85,
    "lat": -3.3667
  },
  "weather": [
    {
      "id": 500,
      "main": "Rain",
      "description": "light rain",
      "icon": "10d"
    }
  ],
  "base": "stations",
  "main": {
    "temp": 291.44,
    "feels_like": 291.65,
    "temp_min": 291.44,
    "temp_max": 291.44,
    "pressure": 1018,
    "humidity": 89,
    "sea_level": 1018,
    "grnd_level": 887
  },
  "visibility": 10000,
  "wind": {
    "speed": 2.46,
    "deg": 111,
    "gust": 3.72
  },
  "rain": {
    "1h": 0.12
  },
  "clouds": {
    "all": 100
  },
  "dt": 1726893280,
  "sys": {
    "country": "TZ",
    "sunrise": 1726888947,
    "sunset": 1726932530
  },
  "timezone": 10800,
  "id": 149155,
  "name": "Usa River",
  "cod": 200
}



