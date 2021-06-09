<template>
    <div class="booking-info card col-xs-12 col-md-6">
        <div class="card-body">
            <h5 class="card-title">Informacion del vuelo</h5>
            <p class="card-text">Su reserva se realizara para el siguiente vuelo.</p>
        </div>
        <ul class="list-group list-group-flush">
            <li class="list-group-item">
                <span href="#" class="badge badge-info">Origen</span>
                {{booking.DepartureStation}}
            </li>
            <li class="list-group-item">
                <span href="#" class="badge badge-info">Destino</span>
                {{booking.ArrivalStation}}
            </li>
            <li class="list-group-item">
                <span href="#" class="badge badge-info">Fecha</span>
                {{booking.DepartureDate}}
            </li>
        </ul>
        <div class="card-body">
            <button type="button" class="btn btn-link" @click="changeFlight">Cambiar vuelo</button>
        </div>
    </div>
</template>

<script>
    import { STAGES } from '../constant';
    const { SEARCHING } = STAGES;

    export default {
        name: 'FilterOptions',
        data: function () {
            return {
                booking: {}
            };
        },
        created: function () {
            this.booking = { "DepartureStation": "BOG", "ArrivalStation": "BOG", "DepartureDate": new Date(), "FlightId": 12 };
        },
        methods: {
            changeFlight: function () {
                this.$store.commit("setStep", SEARCHING);
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

