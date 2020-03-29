<template>
    <v-sheet max-width="250">
        <v-text-field class="white"
          prepend-inner-icon="mdi-magnify"
          max-width="300"
          placeholder="Search.."
          hide-details
          outlined rounded
          clearable
          single-line
          dense
      ></v-text-field>
    </v-sheet>
</template>

<script>
export default {
    name: 'SearchField',
    props: {
    },
    methods: {
    },
    data() {
        return {
        };
    },
};
</script>

<style scoped>
</style>