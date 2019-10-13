<template>
  <v-app>



      <WeatherHome/>

  </v-app>
</template>

<script>
// import HelloWorld from './components/HelloWorld'
import WeatherHome from './components/WeatherHome'
import ForecastCard from './components/ForecastCard'

export default {
  name: 'App',
  components: {
    WeatherHome,
    ForecastCard
  },
  data: () => ({
    //
  })
}

</script>
