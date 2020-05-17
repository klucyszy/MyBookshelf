<template>
  <v-overlay :value="isLoading">
    <v-progress-circular indeterminate size="64"></v-progress-circular>
  </v-overlay>
</template>

<script>
export default {
    name: "LoadingIndicator",
    computed: {
        isLoading() {
            return this.$store.state.loading.isLoading;
        }
    }
}
</script>