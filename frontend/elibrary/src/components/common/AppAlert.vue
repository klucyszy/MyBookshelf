<template>
  <div class="app-alert pa-2">
    <v-alert 
      transition="slide-y-transition"
      :value="visible"
      dense
      border="left"
      :type="alertType">
      {{alertMessage}}
    </v-alert>
    </div>
</template>

<script>
export default {
    name: 'AppAlert',
    data() {
      return {
        visible: false
      };
    },
    computed: {
      alertMessage() {
        return this.$store.state.alert.alert.message;
      },
      alertType() {
        return this.$store.state.alert.alert.type;
      },
      autoDispose() {
        return this.$store.state.alert.alert.autoDispose;
      }
    },
    watch: {
      alertMessage: function() {
        this.visible = true;
        setTimeout(() => {
          this.visible = false;
       }, 2000);        
      }
    }
  };


</script>

<style scoped>
 .app-alert {
   position: absolute;
   right: 20px;
   top: 70px;
 }
</style>
