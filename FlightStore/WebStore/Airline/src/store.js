import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';
import { STAGES, SERVICES } from './constant';

const { SCHEDULED_FLIGHTS, SCHEDULED_FLIGHT } = SERVICES;

const base = {
    state:
    {
        step: STAGES.SEARCHING,
        flights: [],
        book: {
            flight: {},
            user: {}
        }
    },
    getters: {
        flight: (state) => state.book.flight,
        user: (state) => state.book.user
    },
    mutations: {
        setStep(state, step) {
            state.step = step;
        },
        setFlights(state, flights) {
            state.flights = (!!flights) ? flights : [];
        },
        setFlight(state, flight) {
            state.book.flight = (!!flight) ? flight : {};
        }
    },
    actions: {
        async searchFlights({ commit }, options) {
            if (!options) return;

            axios.post(SCHEDULED_FLIGHTS, JSON.stringify(options))
                .then(response => {
                    let data = response.data;
                    if (data.hasItems) {
                        commit('setFlights', data.items);
                    }
                });
        },
        async searchFlights({ commit }, flightId) {
            if (!flightId) return;

            axios.post(SCHEDULED_FLIGHT.replace("{flightId}", flightId), JSON.stringify(options))
                .then(response => {
                    alert(response);
                    commit('setFlight', response);
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
});