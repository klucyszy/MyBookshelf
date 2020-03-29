<template>
  <div class="home">
    <v-btn class="primary" v-on:click="handleSignIn()">
      Sign In
    </v-btn>
    <p>IsSignedIn: {{signedIn}}</p>
    <p>IsInit: {{isInit}}</p>
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
      signedIn: false,
      isInit: false,
      user: {}
    }
  },
  mounted() {
    this.signedIn = this.$gAuth.isSignedIn;
    this.isInit = this.$gAuth.isInit;
  },
  methods: {
    handleSignIn: function() {
      this.$gAuth
        .signIn()
        .then(GoogleUser => {
          //on success do something
          this.user = GoogleUser;
          console.log("GoogleUser", GoogleUser);
          console.log("getId", GoogleUser.getId());
          console.log("getBasicProfile", GoogleUser.getBasicProfile());
          console.log("getAuthResponse", GoogleUser.getAuthResponse());
          console.log(
            "getAuthResponse",
            this.$gAuth.GoogleAuth.currentUser.get().getAuthResponse()
          );
          this.signedIn = this.$gAuth.isAuthorized;
        })
        .catch();
      }
    }
  }
</script>
