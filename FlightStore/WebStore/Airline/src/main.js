import Vue from 'vue';
import App from './App.vue';
import store from './store';
import VeeValidate, { Validator } from 'vee-validate';

Vue.config.productionTip = true;
Vue.use(VeeValidate);

const dict = {
    custom: {
        email: {
            required: () => 'Tu campo de correo electronico esta vacio'
        },
        fullname: {
            required: () => 'Tu campo de nombre esta vacio'
        },
        phone: {
            required: () => 'Tu campo de numero de contacto esta vacio'
        }
    }
};

Validator.localize('en', dict);

new Vue({
    render: h => h(App),
    store
}).$mount('#app');
