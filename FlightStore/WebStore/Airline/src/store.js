import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';
import { STAGES, SERVICES } from './constant';

const { SCHEDULED_FLIGHTS, SCHEDULED_FLIGHT_BY, BOOKING_CREATE } = SERVICES;

const base = {
    state:
    {
        step: STAGES.SEARCHING,
        flights: [],
        book: {
            flight: {},
        }
    },
    getters: {
        flight: (state) => state.book.flight,
    },
    mutations: {
        setStep(state, step) {
            state.step = step;
        },
        setFlights(state, flights) {
            state.flights = (flights != null) ? flights : [];
        },
        setFlight(state, flight) {
            state.book.flight = (flight != null) ? flight : {};
        }
    },
    actions: {
        async searchFlights({ commit }, options) {
            if (!options) return;

            const requestOptions = {
                headers: { "Content-Type": "application/json" },
            };

            axios.post(SCHEDULED_FLIGHTS, JSON.stringify(options), requestOptions)
                .then(response => {
                    let data = response.data;
                    if (data.hasItems) {
                        commit('setFlights', data.items);
                    }
                });
        },
        async bookFlight({ commit }, flightId) {
            axios.get(SCHEDULED_FLIGHT_BY.replace("{flightId}", flightId))
                .then(response => {
                    commit('setFlight', response.data);
                });
        },
        async createBooking({ getters }, customer) {
            let formData = Object.assign(customer, getters.flight);

            const requestOptions = {
                headers: { "Content-Type": "application/json" },
            };

            axios.post(BOOKING_CREATE, JSON.stringify(formData), requestOptions)
                .then(response => {
                    alert(response);
                });
        }
    }
}

const VuexStore = (store = {}) => {
    Vue.use(Vuex);

    return new Vuex.Store({
        state: { ...base.state, ...store.state },
        getters: { ...base.getters, ...store.getters },
        mutations: { ...base.mutations, ...store.mutations },
        actions: { ...base.actions, ...store.actions },
    });
}

export { VuexStore };

export default VuexStore({
    state: {},
    getters: {},
    mutations: {},
    actions: {},
});