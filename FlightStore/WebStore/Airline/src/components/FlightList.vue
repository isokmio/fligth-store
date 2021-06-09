<template>
    <div class="fligth-list" v-show="isVisible">
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
                <tr v-for="(flight, index) in flightList" :key="index">
                    <th scope="row">{{flight.DepartureStation}}</th>
                    <td>{{flight.ArrivalStation}}</td>
                    <td>{{flight.DepartureDate}}</td>
                    <td><button type="button" class="btn btn-link" :data-flight-id="flight.FlightId" @click="changeState">Continuar</button></td>
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
        props: {
            
        },
        data: function () {
            return {
                flightList: Object
            };
        },
        created: function () {
            this.flightList = [{ "DepartureStation": "BOG", "ArrivalStation": "BOG", "DepartureDate": new Date(), "FlightId": 12 }];
        },
        computed: {
            ...mapState(['step']),
            isVisible: function () {
                return this.step == SEARCHING;
            }
        },
        methods: {
            changeState: function () {
                this.$store.commit('setStep', BOOKING);
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

