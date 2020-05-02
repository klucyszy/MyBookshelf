<template>
    <v-card outlined>
      <v-card-title class="mb-0 pb-2">Bookshelfs</v-card-title>
      <v-checkbox class="mx-6 my-0 py-0" v-model="isAllCheckboxChecked" label="All"></v-checkbox>
      <v-checkbox class="mx-6 my-0 py-0" v-for="bshf in bookshelfs" 
                  :key="bshf.id" 
                  :label="`${bshf.name} (${bshf.items})`"
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
    this.selectedBookshelfs = this.bookshelfs;
  },
  data: function() {
    return {
      isAllCheckboxChecked: true,
      selectedBookshelfs: [],
      bookshelfs: [
        {
          id: "1",
          name: "Reading",
          items: 7,
        },
        {
          id: "2",
          name: "Favorites",
          items: 3,
        },
        {
          id: "3",
          name: "Audiobooks",
          items: 2
        },
        {
          id: "4",
          name: "To be read",
          items: 12
        }
      ]
  };
},
  methods: {
  }
}
</script>

<style scoped>

</style>