<template>
<v-card>
  <v-card-title  class="headline" >
  <v-label> Day {{this.forecastDay.day}} :  {{this.forecastDateString}} </v-label>
  </v-card-title>
  <v-card-text>
    <v-text-field
              v-model="this.minTemperatureString"
              label="Minimum Temperature"
              disabled
            ></v-text-field>
                <v-text-field
              v-model="this.maxTemperatureString"
              label="Maximum Temperature"
              disabled
            ></v-text-field>
                <v-text-field
              v-model="this.humidityString"
              label="Average humidity"
              disabled
            ></v-text-field>
                <v-text-field
              v-model="this.windspeedString"
              label="Average windspeed"
              disabled
            ></v-text-field>
  </v-card-text>
</v-card>

</template>
<script>
import moment from 'moment';
export default {
  props: {
    forecastDay:{
      day:Number,
      forecastDate: Date,
      minimumTemperature: Number,
      maximumTemperature: Number,
      humidity: Number,
      windspeed : Number
    }
  },
  computed:{
    forecastDateString(){
      if(this.forecastDay && this.forecastDay.forecastDate){
        return moment(String(this.forecastDay.forecastDate)).format('DD MMM YYYY')

      }
      return ""
    },
    minTemperatureString:function() {
       return `${this.forecastDay.minimumTemperature.toFixed(0)} C`
    },
    maxTemperatureString:function() {
       return `${this.forecastDay.maximumTemperature.toFixed(0)} C`
    },
    humidityString:function() {
       return `${this.forecastDay.humidity.toFixed(2)} %`
    },
    windspeedString:function() {
       return `${this.forecastDay.windspeed.toFixed(2)} km/h`
    }
  }

}
  </script>
