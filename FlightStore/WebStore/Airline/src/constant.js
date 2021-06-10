const STAGES = { SEARCHING: 0, BOOKING: 1, CONFIRMING: 2 };
const SERVICES =
{
    STATIONS: "https://flightstore-station-api.azurewebsites.net/api/stations",
    SCHEDULED_FLIGHTS: "https://flightstore-schedule-api.azurewebsites.net/api/values",
    SCHEDULED_FLIGHT: "https://flightstore-schedule-api.azurewebsites.net/api/values/{flightId}",
};

export { STAGES, SERVICES };