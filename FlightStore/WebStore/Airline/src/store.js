import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';
import { STAGES, SERVICES } from './constant';

const { SCHEDULED_FLIGHTS, SCHEDULED_FLIGHT_BY_ID, SCHEDULED_FLIGHT_BY_FN, BOOKING_CREATE } = SERVICES;

const base = {
    state:
    {
        loading: false,
        step: STAGES.SEARCHING,
        flights: [],
        book: {
            flight: {},
            confirmation: {}
        }
    },
    getters: {
        flight: (state) => state.book.flight,
        booking: (state) => state.book.confirmation,
    },
    mutations: {
        setStep(state, step) {
            state.step = step;
        },
        setLoading(state, loading) {
            state.loading = loading;
        },
        setFlights(state, flights) {
            state.flights = (flights != null) ? flights : [];
        },
        setFlight(state, flight) {
            state.book.flight = (flight != null) ? flight : {};
        },
        setConfirmation(state, confirmation) {
            state.book.confirmation = (confirmation != null) ? confirmation : {};
        },
        cleanState(state) {
            state.flights = [];
            state.book.flight = {};
        }
    },
    actions: {
        async searchFlights({ commit }, options) {
            if (!options) return;

            const requestOptions = {
                headers: { "Content-Type": "application/json" },
            };

            commit("setLoading", true);
            axios.post(SCHEDULED_FLIGHTS, JSON.stringify(options), requestOptions)
                .then(response => {
                    let data = response.data;
                    if (data.hasItems) {
                        commit('setFlights', data.items);
                    }
                    commit("setLoading", false);
                });
        },
        async bookFlight({ commit }, flightId) {
            commit("setLoading", true);
            axios.get(SCHEDULED_FLIGHT_BY_ID.replace("{flightId}", flightId))
                .then(response => {
                    commit('setFlight', response.data);
                    commit("setLoading", false);
                });
        },
        async bookFlighByFn({ commit }, flightNumber) {
            commit("setLoading", true);
            axios.get(SCHEDULED_FLIGHT_BY_FN.replace("{flightNumber}", flightNumber))
                .then(response => {
                    commit('setFlight', response.data);
                    commit("setLoading", false);
                });
        },
        async createBooking({ commit, getters }, customer) {
            let formData = Object.assign(customer, getters.flight);

            const requestOptions = {
                headers: { "Content-Type": "application/json" },
            };

            commit("setLoading", true);
            axios.post(BOOKING_CREATE, JSON.stringify(formData), requestOptions)
                .then(response => {
                    let data = response.data;

                    commit('setConfirmation', data);
                    commit('cleanState');
                    commit('setStep', STAGES.CONFIRMING);
                    commit("setLoading", false);
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