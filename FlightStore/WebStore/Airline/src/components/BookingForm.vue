<template>
    <div class="reservation-form row" v-show="isVisible">
        <flight-info class="col-xs-12 col-md-6"></flight-info>
        <div class="card col-xs-12 col-md-6">
            <div class="card-body">
                <form @submit.prevent="submit">
                    <h5>Informacion del usuario</h5>
                    <p class="card-text">Complete la informacion para el registro.</p>
                    <div class="form-group">
                        <label>Nombre completo:</label>
                        <input type="text"
                               name="fullname"
                               v-model="customer.fullname"
                               class="form-control"
                               v-validate="'required|alpha'" 
                               :class="{'has-errors': errors.has('fullname')}" />

                        <span v-show="errors.has('fullname')" class="help brand-color">{{ errors.first("fullname") }}</span>
                    </div>
                    <div class="form-group">
                        <label>Numero de contacto:</label>
                        <input type="text"
                               name="phone"
                               class="form-control"
                               v-model="customer.phone"
                               v-validate="'required|numeric'" 
                               :class="{'has-errors': errors.has('phone')}" />

                        <span v-show="errors.has('phone')" class="help brand-color">{{ errors.first("phone") }}</span>
                    </div>
                    <div class="form-group">
                        <label>Correo electronico:</label>
                        <input type="email"
                               class="form-control"
                               v-model="customer.email"
                               v-validate="'required'"
                               name="email"
                               :error="errors.first('email')" 
                               :class="{'has-errors': errors.has('email')}" />

                        <span v-show="errors.has('email')" class="help brand-color">{{ errors.first("email") }}</span>
                    </div>
                    <button type="button" class="btn btn-primary" @click="generate" :disabled="isDisabled">
                        <img v-show="loading" height="30" src="../../public/loading.gif" />
                        Generar reserva
                    </button>
                </form>
            </div>
        </div>        
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    import { STAGES } from '../constant';
    const { BOOKING } = STAGES;

    export default {
        name: 'BookingForm',
        data: function () {
            return {
                responseErrors: [],
                customer: {
                    fullname: "",
                    phone: "",
                    email: ""
                }                
            };
        },
        components: {
            FlightInfo: () => import(/* webpackChunkName: "FlightInfo" */ './FlightInfo.vue'),
        },
        computed: {
            ...mapState(['step', 'loading']),
            isVisible: function () {
                return this.step == BOOKING;
            },
            isDisabled: function () {
                return this.loading;
            }
        },
        watch: {
            step(before) {
                if (before == BOOKING) {
                    this.$validator.reset();

                    this.clean();
                }
            },
        },
        methods: {
            clean: function () {
                this.customer = { fullname: "", phone: "", email: "" };
            },
            generate: async function () {
                const isValid = await this.$validator.validate();

                if (isValid) {
                    this.$store.dispatch('createBooking', this.customer);
                }
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .help {
        font-size: 0.8em;
    }

    .brand-color {
        color: firebrick;
    }

    .has-errors {
        border-color: firebrick;

    }
</style>

