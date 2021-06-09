<template>
    <div class="container">
        <h1>{{ airline }}</h1>
        <filter-options></filter-options>
        <flight-list></flight-list>
        <booking-form></booking-form>
    </div>
</template>

<script>
    export default {
        name: 'Home',
        props: {
            airline: String
        },
        data: function () {
            return {
                showBooking: false
            };
        },
        components: {
            FilterOptions: () => import(/* webpackChunkName: "FilterOptions" */ './FilterOptions.vue'),
            FlightList: () => import(/* webpackChunkName: "FlightList" */ './FlightList.vue'),
            BookingForm: () => import(/* webpackChunkName: "BookingForm" */ './BookingForm.vue'),
        },
        methods: {

        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

