<template>
  <div class="home">
    <h1>Home</h1>
    <v-btn @click="copyToken">Copy token</v-btn>
    <v-btn @click="showSuccessAlert">Show success alert</v-btn>
    <v-btn @click="showErrorAlert">Show error alert</v-btn>
    <books-slider></books-slider>
  </div>
</template>

<script>
import BooksSlider from '../components/common/BooksSlider';

export default {
  name: 'Home',
  components: {
    BooksSlider
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
    showErrorAlert: function() {
      this.$store.commit('alert/alertError', "Error alert is working!");
    },
    showSuccessAlert: function() {
      this.$store.commit('alert/alertSuccess', "Success alert is working!");
    },
    copyToken: function() {
      let textToCopy = this.token;
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