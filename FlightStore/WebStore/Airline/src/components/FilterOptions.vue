<template>
    <div class="filter" v-show="isVisible">
        <form @submit.prevent="submit" class="row">
            <div class="form-group col-xs-12 col-md-4">
                <label>Origen:</label>
                <select class="form-control" v-model="filter.departure">
                    <option v-for="(from, index) in fromList" :key="index" :value="from.code">{{from.name}}</option>
                </select>
            </div>
            <div class="form-group col-xs-12 col-md-4">
                <label>Destino:</label>
                <select class="form-control" v-model="filter.destination">
                    <option v-for="(to, index) in toList" :key="index" :value="to.code">{{to.name}}</option>
                </select>
            </div>            
            <div class="form-group col-xs-12 col-md-4">
                <label>Fecha:</label>
                <input type="date" class="form-control" v-model="filter.date" />
            </div>   
            <div class="form-group col-xs-12 col-md-4">
                <button type="button" class="btn btn-primary" @click="search">Buscar vuelos</button>
            </div>
        </form>
    </div>
</template>

<script>
    import { mapState } from 'vuex';
    import axios from 'axios';
    import { STAGES, SERVICES } from '../constant'

    const { SEARCHING } = STAGES;
    const { STATIONS } = SERVICES;

    export default {
        name: 'FilterOptions',
        props: {
            
        },
        data: function () {
            return {
                fromList: Object,
                toList: Object,
                filter: {
                    departure: "",
                    destination: "",
                    date: new Date,
                },
                show: false
            };
        },
        mounted: async function () {
            await axios.get(STATIONS)
                .then(response => {
                    let data = response.data;
                    if (data.hasItems) {
                        this.fromList = Object.assign({}, data.items);
                        this.toList = Object.assign({}, data.items);
                    }
                });
        },
        computed: {
            ...mapState(['step']),
            isVisible: function() {
                return this.step == SEARCHING;
            }
        },
        methods: {            
            search: async function () {
                let options = Object.assign(this.filter, { date: this.filter.date + "T00:00:00.000Z" });

                await this.$store.dispatch('searchFlights', options);
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

