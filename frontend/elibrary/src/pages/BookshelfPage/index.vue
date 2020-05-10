<template>
<v-container class="container-style">
  <v-row>
    <v-col cols="12">
      <v-row justify="center" mb-6>
        <v-col cols="8">
          <search-field :max-width="1440"></search-field>
        </v-col>
      </v-row>
      <v-row justify="center">
        <v-col :xs="12" :md="4" :lg="3">
          <category-selector></category-selector>
        </v-col>
        <v-col :xs="12" :md="8" :lg="9">
          <books-list></books-list>
        </v-col>
      </v-row>
    </v-col>
  </v-row>
  



</v-container>
</template>

<script>
import SearchField from './../../components/common/SearchField';
import CategorySelector from './../../components/ui/CategorySelector';
import BooksList from './../../components/ui/BooksList';

export default {
    name: 'Bookshelf',
    components: {
      SearchField,
      CategorySelector,
      BooksList
    }
};
</script>

<style scoped>
  .container-style {
    max-width: 1920px;
  }
</style>
