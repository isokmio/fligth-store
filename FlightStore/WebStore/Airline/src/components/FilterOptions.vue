<template>
    <div class="filter" v-show="isVisible">
        <form @submit.prevent="submit" class="row">
            <div class="form-group col-xs-12 col-md-4">
                <label>Origen:</label>
                <select class="form-control" v-model="departure">
                    <option v-for="(from, index) in fromList" :key="index" :value="from.value">{{from.city}}</option>
                </select>
            </div>
            <div class="form-group col-xs-12 col-md-4">
                <label>Destino:</label>
                <select class="form-control" v-model="destination">
                    <option v-for="(to, index) in toList" :key="index" :value="to.value">{{to.city}}</option>
                </select>
            </div>            
            <div class="form-group col-xs-12 col-md-4">
                <label>Fecha:</label>
                <input type="date" class="form-control" v-model="date" />
            </div>   
            <div class="form-group col-xs-12 col-md-4">
                <button type="button" class="btn btn-primary">Buscar vuelos</button>
            </div>
        </form>
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    import { STAGES } from '../constant'

    const { SEARCHING } = STAGES;

    export default {
        name: 'FilterOptions',
        props: {
            
        },
        data: function () {
            return {
                fromList: Object,
                toList: Object,
                departure: "",
                destination: "",
                date: new Date,
                show: false
            };
        },
        created: function () {
            this.fromList = [
                { "value": "BOG", "city": "Bogota" },
                { "value": "PEI", "city": "Pereira" },
            ];
        },
        computed: {
            ...mapState(['step']),
            isVisible: function() {
                return this.step == SEARCHING;
            }
        }

    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

