<template>
  <div class="home">
    <v-btn class="primary" v-on:click="handleSignIn()">
      Sign In
    </v-btn>
    <p>GoogleUser: {{user}}</p>
  </div>
</template>

<script>
export default {
  name: 'Home',
  components: {
  },
  data() {
    return {
      user: {}
    }
  }
}
</script>
