<template>
    <div class="filter" v-show="isVisible">
        <form @submit.prevent="submit" class="row">
            <div class="form-group col-xs-12 col-md-4">
                <label>Origen:</label>
                <select class="form-control" v-model="filter.departure">
                    <option value="">Seleccione...</option>
                    <option v-for="(from, index) in fromList" :key="index" :value="from.code">{{from.name}}</option>
                </select>
            </div>
            <div class="form-group col-xs-12 col-md-4">
                <label>Destino:</label>
                <select class="form-control" v-model="filter.destination">
                    <option value="">Seleccione...</option>
                    <option v-for="(to, index) in toList" :key="index" :value="to.code">{{to.name}}</option>
                </select>
            </div>            
            <div class="form-group col-xs-12 col-md-4">
                <label>Fecha:</label>
                <input type="date" class="form-control" v-model="filter.from" />
            </div>   
            <div class="form-group col-xs-12 col-md-4">
                <button type="button" class="btn btn-primary" @click="search" :disabled="isDisabled">Buscar vuelos</button>
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
                    from: null,
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
            },
            isDisabled: function () {
                return (!this.filter.departure || !this.filter.destination || !this.filter.from)
            }
        },
        methods: {
            cleanFilter: function () {
                this.filter = { departure: "", destination: "", from: null };
            },
            search: async function () {
                let options = Object.assign(this.filter, { from: this.filter.from + "T00:00:00.000Z" });

                await this.$store.dispatch('searchFlights', options);

                this.cleanFilter();
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

