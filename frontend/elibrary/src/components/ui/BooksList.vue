<template>
    <div v-if="isAnyBook">
        <v-row>
            <v-col v-for="(book, index) in books"
                :key="index"
                cols="12"
                md="3">
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
    data: function() {
        return {
            //books: []
            books: [
                                {
                    Rate: 4,
                    Author: "David Allen",
                    Title: "Gettings Things Done",
                    Category: "Psychology",
                    IsFavorite: true,
                    ImageUrl: require('./../../assets/getting-things-done-czyli-sztuka-bezstresowej-efektywnosci-wydanie-ii-srednie.jpg')
                },
                {
                    Rate: 3,
                    Author: "Daniel Kahneman",
                    Title: "Pułapki Myślenia",
                    Category: "Psychology",
                    IsFavorite: false,
                    ImageUrl: require('./../../assets/pulapki-myslenia-srednie.jpg')
                },
                {
                    Rate: 4,
                    Author: "Charles Duhigg",
                    Title: "Siła nawyku",
                    Category: "Psychology",
                    IsFavorite: true,
                    ImageUrl: require('./../../assets/sila-nawyku-srednie.jpg')
                },
                {
                    Rate: 5,
                    Author: "Name Surname",
                    Title: "Book Title 1",
                    Category: "Category 3",
                    IsFavorite: false,
                    ImageUrl: "https://via.placeholder.com/165"
                },
                {
                    Rate: 5,
                    Author: "Name Surname",
                    Title: "Book Title 2",
                    Category: "Category 2",
                    IsFavorite: false,
                    ImageUrl: "https://via.placeholder.com/165"
                },
                {
                    Rate: 5,
                    Author: "Name Surname",
                    Title: "Book Title 3 long book name",
                    Category: "Category 1",
                    IsFavorite: false,
                    ImageUrl: "https://via.placeholder.com/165"
                }
            ]
        }
    },
    computed: {
        isAnyBook: function() {
            return this.books.length > 0;
        }
    }
};
</script>

<style scoped>
</style>
