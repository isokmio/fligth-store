<template>
    <div class="reservation-form row" v-show="isVisible">
        <booking-info class="col-xs-12 col-md-6"></booking-info>
        <form @submit.prevent="submit" class="col-xs-12 col-md-6">
            <h5>Informacion del usuario</h5>
            <p class="card-text">Complete la informacion para el registro.</p>
            <div class="form-group">
                <label>Nombre completo:</label>
                <input type="text" v-model="fullname" class="form-control" />
            </div>
            <div class="form-group">
                <label>Numero de contacto:</label>
                <input type="text" class="form-control" v-model="phone" />
            </div>
            <div class="form-group">
                <label>Correo electronico:</label>
                <input type="email" class="form-control" v-model="email" />
            </div>
            <button type="button" class="btn btn-primary">Generar reserva</button>
        </form>
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    import { STAGES } from '../constant';
    const { BOOKING } = STAGES;

    export default {
        name: 'BookingForm',
        props: {
            fligth: Object,
        },
        data: function () {
            return {
                fullname: "",
                phone: "",
                email: ""
            };
        },
        components: {
            BookingInfo: () => import(/* webpackChunkName: "BookingInfo" */ './BookingInfo.vue'),
        },
        computed: {
            ...mapState(['step']),
            isVisible: function () {
                return this.step == BOOKING;
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

