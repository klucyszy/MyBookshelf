<template>
    <v-sheet :max-width="maxWidth">
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
        maxWidth: {
            type: Number,
            default: 1920
        },
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