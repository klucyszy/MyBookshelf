<template>
    <v-card outlined>
      <v-row>
        <v-col>
          <v-card-text class="card-title mb-0 pb-2">Bookshelfs</v-card-text>
        </v-col>
        <v-col class= "d-flex align-end justify-center">
          <v-btn text x-small 
            v-on:click=clearFilters()
            class="card-button my-4">Clear</v-btn>
        </v-col>
      </v-row>
      <v-checkbox dense class="mx-6 my-0 py-0" v-for="bshf in bookshelfs" 
                  :key="bshf.id" 
                  :label="`${bshf.title} (${bshf.volumeCount})`"
                  :value="bshf"
                  v-model="selectedBookshelfs">
      </v-checkbox>
    </v-card>
</template>

<script>
export default {
  name: 'CategorySelector',
  components: {
  },
  created: function() {
    this.loadCategories();
  },
  data: function() {
    return {
      isAllCheckboxChecked: true,
      selectedBookshelfs: [],
      bookshelfs: []
  };
},
  methods: {
    clearFilters: function() {
      this.selectedBookshelfs = [];
    },
    loadCategories: function() {
      this.axios.get('/api/bookshelfs', {
        headers: {
          Authorization: this.$store.state.signin.id_token
        }
      })
      .then(res => {
        if (res && res.data && Array.isArray(res.data.items)){
          this.bookshelfs = res.data.items;
        }
      })
      .catch(err => {
        console.log(err);
      })
    }
  }
}
</script>

<style scoped>
  .card-title {
    font-weight: bold;
    font-size: larger;
  }

  .card-button {
    color: grey;
    text-decoration: underline;
  }
</style>