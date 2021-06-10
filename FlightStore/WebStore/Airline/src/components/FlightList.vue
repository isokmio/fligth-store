<template>
    <div class="flight-list" v-show="isVisible">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Origen</th>
                    <th scope="col">Destino</th>
                    <th scope="col">Fecha</th>
                    <th scope="col">Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(flight, index) in flights" :key="index">
                    <th scope="row">{{flight.departureStation}}</th>
                    <td>{{flight.arrivalStation}}</td>
                    <td>{{flight.departureDate}}</td>
                    <td><button type="button" class="btn btn-link" @click="bookFlight(flight.flightId)">Continuar</button></td>
                </tr>
            </tbody>
        </table>
    </div>    
</template>

<script>
    import { mapState } from 'vuex';
    import { STAGES } from '../constant';
    const { SEARCHING, BOOKING } = STAGES;

    export default {
        name: 'FlightList',
        computed: {
            ...mapState(['step', 'flights']),
            isVisible: function () {
                return this.step == SEARCHING;
            }
        },
        methods: {
            bookFlight: async function (flightId) {
                await this.$store.dispatch('bookFlight', flightId);

                this.$store.commit('setStep', BOOKING);
            }
        }
    };
</script>

<style scoped>
</style>

