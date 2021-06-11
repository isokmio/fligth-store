const STAGES = { SEARCHING: 0, BOOKING: 1, CONFIRMING: 2 };
const SERVICES =
{
    STATIONS: "https://flightstore-station-api.azurewebsites.net/api/stations",
    SCHEDULED_FLIGHTS: "https://flightstore-schedule-api.azurewebsites.net/api/flights",
    SCHEDULED_FLIGHT_BY_ID: "https://flightstore-schedule-api.azurewebsites.net/api/flights/{flightId}",
    SCHEDULED_FLIGHT_BY_FN: "https://flightstore-schedule-api.azurewebsites.net/api/flights/fn/{flightNumber}",
    BOOKING_CREATE: "https://flightstore-booking-api.azurewebsites.net/api/books",
};

//const AIRLINE =
//{
//    SCHEDULED_FLIGHTS: "http://testapi.vivaair.com/otatest/api/values",
//};

//const SERVICES = Object.assign(BASEAPI, AIRLINE);

export { STAGES, SERVICES };