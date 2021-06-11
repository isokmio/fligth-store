<template>
    <div class="confirmation-display" v-show="isVisible">
        <div class="card col-xs-12 col-md-8">
            <div class="card-body">
                <h5 class="card-title">Informacion de la reserva</h5>
            </div>
            <ul class="list-group list-group-flush">
                <li class="list-group-item">
                    <span href="#" class="badge badge-info">Nombre cliente</span>
                    {{booking.fullName}}
                </li>
                <li class="list-group-item">
                    <span href="#" class="badge badge-info">Correo electronico</span>
                    {{booking.email}}
                </li>
                <li class="list-group-item">
                    <span href="#" class="badge badge-info">Numero de reserva</span>
                    {{booking.reservationCode }}
                </li>         
            </ul>
            <div class="card-body">
                <button type="button" class="btn btn-primary" @click="printTicket">Imprimir</button>
                <button type="button" class="btn btn-link" @click="searchFlight">Buscar vuelo</button>
            </div>
        </div>
    </div>
</template>

<script>
    import { STAGES } from '../constant';
    import { mapGetters, mapState } from 'vuex';

    const { CONFIRMING, SEARCHING } = STAGES;

    export default {
        name: 'ConfirmationDisplay',
        computed: {
            ...mapState(['step']),
            ...mapGetters(['booking']),
            isVisible: function () {
                return this.step == CONFIRMING;
            },
        },
        methods: {
            printTicket: function () {
                window.print();
            },
            searchFlight: function () {
                this.$store.commit('setFlight', {});
                this.$store.commit('setConfirmation', {});

                this.$store.commit("setStep", SEARCHING);
            }
        }
    };
</script>

<style scoped>
    .badge-info {
        background-color: silver;
        color: black;
    }
</style>

