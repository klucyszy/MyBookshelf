<template>
  <div class="home">
    <h1>Home</h1>
    <v-btn @click="copyToken">Copy token</v-btn>
  </div>
</template>

<script>
export default {
  name: 'Home',
  components: {
  },
  computed: {
    token() {
      return this.$store.state.signin.id_token;
    },
    user() {
      return this.$store.state.signin.user;
    }
  },
  methods: {
    copyToken: function() {
      let textToCopy = "Bearer " + this.token;
      this.$copyText(textToCopy).then(function (e) {
          alert('Copied')
          console.log(e)
        }, function (e) {
          alert('Can not copy')
          console.log(e)
        });
    }

  }
}
</script>

<style scoped>

.token-style {
    color: #e20e60 !important;
    background-color: transparent !important;
    max-width: 200px !important;
}
</style>