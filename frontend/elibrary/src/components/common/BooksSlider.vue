<template>
    <v-sheet class="mx-auto my-auto pb-4 grey lighten-3" max-width="1366">
        <v-slide-group class="pa-4"
            v-model="Book"
            center-active
            show-arrows
        >
            <v-slide-item v-for="(book, index) in FavoriteBooks"
                :key="index"
            >
                <book-card :book="book"></book-card>
            </v-slide-item>            
        </v-slide-group>
    </v-sheet>
</template>

<script>
import BookCard from '@/components/common/BookCard';

export default {
    name: 'BooksSlider',
    components: {
        BookCard
    },
    methods: {
        rateUpdated: function(value){
            this.Book.Rate = value;
        },
        toggleFavorite: function() {
            this.Book.IsFavorite = !this.Book.IsFavorite;
        }
    },
    data() {
        return {
            FavoriteBooks: [
                {
                    Rate: 4,
                    Author: "David Allen",
                    Title: "Gettings Things Done",
                    Category: "Psychology",
                    IsFavorite: true,
                    ImageUrl: require('./../../assets/getting-things-done-czyli-sztuka-bezstresowej-efektywnosci-wydanie-ii-srednie.jpg'),
                    Bookshelfs: [
                        {
                            Name: "My books",
                            IsChecked: true
                        },
                        {
                            Name: "To read",
                            IsChecked: false
                        }
                    ]
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
        };
    },
    computed: {
    }
};
</script>

<style scoped>
    .card-size {
        max-width: 200px;
    }
</style>