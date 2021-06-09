import Vue from 'vue';
import Vuex from 'vuex';
import { STAGES } from './constant';

const base = {
    state:
    {
        step: STAGES.SEARCHING
    },
    getters: {},
    mutations: {
        setStep(state, step) {
            state.step = step;
        }
    },
    actions: {}
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