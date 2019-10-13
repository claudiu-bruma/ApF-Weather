<template>
  <v-app id="inspire">
    <v-app-bar app>
      <v-toolbar-title class="headline text-uppercase">
        <span>Apps Factory</span>
        <span class="font-weight-light">Weather App</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>

    </v-app-bar>

    <v-content>
      <v-container>
      <v-row>
        <v-col cols="9" sm="6">
          <v-text-field id="forecastCity" aria-placeholder="name/postcode for location in Germany" label="city" v-model="forecastCity" />
        </v-col>
             <v-col cols="3" sm="6">
              <v-btn text tile color="blue" @click="getForecast" class="button-search">
                 Search
              </v-btn>
            </v-col>
      </v-row>
      <v-row>
        <v-col   v-for="forecast in forecasts" class="col-lg-2 col-md-3 col-sm-6 col-xs-12" v-bind:key="forecast.day" >
            <ForecastCard v-bind:forecastDay="forecast" />

          </v-col>

      </v-row>
      <v-row>
          <v-col v-if="resultsNotFound">
             <v-alert
                     border="top"
                     color="red lighten-2"
                     dark
                    >
              Unable to retrieve resurts for your desired location
             </v-alert>
          </v-col>
        </v-row>
      </v-container>
    </v-content>

    <v-footer app>
      <span>&copy; 2019</span>
    </v-footer>
  </v-app>
</template>

<script>
import axios from 'axios'
import ForecastCard from '../components/ForecastCard';
import * as configuration from '../plugins/configurations.js'
export default {
  components:{
    ForecastCard
  },
  props: {
    source: String
  },
  data: () => ({
    drawer: null,
    forecastCity : "",
    forecasts:null,
    resultsNotFound: false
  }),
  created () {
    this.$vuetify.theme.dark = true
  },
  methods:{
    getForecast:function(){


        let _this = this;
          axios.get(`${configuration.apiUrl}${this.forecastCity}`).then(function (response) {
            // handle success
            console.log(response);
            _this.$data.forecasts = response.data;
            _this.$data.resultsNotFound =false;

      }).catch(function (error) {
          // handle error
          _this.$data.forecasts = [];
          _this.$data.resultsNotFound =true;
      })
    }


  }
}
</script>
<style scoped>
  .button-search{
    padding-top: 25px;
  }
</style>
