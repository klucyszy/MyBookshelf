<template>
    <v-card outlined>
      <v-card-title class="mb-0 pb-2">Bookshelfs</v-card-title>
      <v-checkbox dense class="mx-6 my-0 py-0" v-model="isAllCheckboxChecked" label="All"></v-checkbox>
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
  computed: {
    isAnyCategoryChecked() {
      return this.selectedBookshelfs.length > 0;
    }
  },
  watch: {
    isAllCheckboxChecked: function(newValue) {
      if (newValue) {
        this.selectedBookshelfs = this.bookshelfs;
      }
      else {
        this.selectedBookshelfs = [];
      }
    }
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
    loadCategories: function() {
      this.axios.get('/api/bookshelfs', {
        headers: {
          Authorization: this.$store.state.signin.id_token
        }
      })
      .then(res => {
        if (res && res.data && Array.isArray(res.data.items)){
          this.bookshelfs = res.data.items;
          this.selectedBookshelfs = this.bookshelfs;
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

</style>