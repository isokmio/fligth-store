import Vue from 'vue';
import App from './App.vue';
import store from './store';
import VeeValidate, { Validator } from 'vee-validate';
import moment from 'moment';

Vue.config.productionTip = true;
Vue.use(VeeValidate);
Vue.filter('formatDate', function (value) {
    if (value) {
        return moment(String(value)).format('YYYY-MM-DD hh:mm')
    }
});

Vue.filter('formatCurrency', function (value) {
    if (value) {
        let val = (value / 1).toFixed(2).replace('.', ',')
        return "$" + val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
    }
});

const dict = {
    custom: {
        email: {
            required: () => 'Tu campo de correo electronico esta vacio',
            email:() => 'El correo electronico no tiene el formato adecuado'
        },
        fullname: {
            required: () => 'Tu campo de nombre esta vacio',
            alpha: () => 'El campo nombre solo debe contener caracteres alfabeticos'
        },
        phone: {
            required: () => 'Tu campo de numero de contacto esta vacio',
            numeric: () => 'El campo telefono solo puede contener digitos'
        }
    }
};

Validator.localize('en', dict);

new Vue({
    render: h => h(App),
    store
}).$mount('#app');
