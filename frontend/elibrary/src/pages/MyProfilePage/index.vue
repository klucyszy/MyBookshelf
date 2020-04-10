<template>
  <div class="my-profile">
    <h1>My Profile</h1>
    <p>{{user}}</p>
  </div>
</template>


<script>
export default {
  name: 'MyProfile',
  components: {
  },
  computed: {
    user() {
      return this.$store.state.signin.user;
    }
  }
}
</script>
