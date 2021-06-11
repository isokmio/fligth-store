<template>
    <div class="flight-list" v-show="isVisible">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Origen</th>
                    <th scope="col">Destino</th>
                    <th scope="col">Fecha</th>
                    <th scope="col">Numero de vuelo</th>
                    <th scope="col">Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(flight, index) in flights" :key="index">
                    <th scope="row">{{flight.departureStation}}</th>
                    <td>{{flight.arrivalStation}}</td>
                    <td>{{flight.departureDate | formatDate}}</td>
                    <td>{{flight.flightNumber}}</td>
                    <td><button type="button" class="btn btn-link" @click="bookFlight(flight.flightNumber)">Continuar</button></td>
                </tr>
            </tbody>
        </table>
        <div class="center" v-show="loading"><img height="60" src="../../public/loading.gif" /></div>
        
    </div>    
</template>

<script>
    import { mapState } from 'vuex';
    import { STAGES } from '../constant';
    const { SEARCHING, BOOKING } = STAGES;

    export default {
        name: 'FlightList',
        computed: {
            ...mapState(['step', 'flights', 'loading']),
            isVisible: function () {
                return this.step == SEARCHING;
            }
        },
        methods: {
            bookFlight: async function (flightNumber) {
                await this.$store.dispatch('bookFlighByFn', flightNumber);

                this.$store.commit('setStep', BOOKING);
            }
        }
    };
</script>

<style scoped>
    .center {
        text-align: center;
    }
</style>

