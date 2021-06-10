const STAGES = { SEARCHING: 0, BOOKING: 1, CONFIRMING: 2 };
const SERVICES =
{
    STATIONS: "https://flightstore-station-api.azurewebsites.net/api/stations",
    SCHEDULED_FLIGHTS: "https://flightstore-schedule-api.azurewebsites.net/api/flights",
    SCHEDULED_FLIGHT_BY: "https://flightstore-schedule-api.azurewebsites.net/api/flights/{flightId}",
    BOOKING_CREATE: "https://flightstore-booking-api.azurewebsites.net/api/books",
};

export { STAGES, SERVICES };