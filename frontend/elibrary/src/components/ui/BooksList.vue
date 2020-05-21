<template>
    <div v-if="isAnyBook">
        <v-row>
            <v-col v-for="(book, index) in books"
                :key="index"
                cols="12"
                sm="12"
                md="5"
                lg="3"
                xl="2">
                <book-card :book="book"></book-card>
            </v-col>
        </v-row>
    </div>
    <div v-else>
        <v-card-subtitle>Nothing found..</v-card-subtitle>
    </div>
</template>

<script>
import BookCard from './../common/BookCard';
export default {
    name: 'BooksList',
    components: {
        BookCard
    },
    computed: {
        books: function() {
            return this.$store.state.search.books;
        },
        isAnyBook: function() {
            return this.books.length > 0;
        }
    },
    mounted() {
        this.$store.dispatch('search/getBooks');
    }
};
</script>

<style scoped>
</style>
