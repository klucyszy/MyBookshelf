<template>
    <v-card shaped class="mx-auto" 
            max-width="250">
        
        <v-img :src=Book.ImageUrl
            height="200px">
        </v-img>

        <div align="left" class="pl-4">
            <v-card-title class="pt-1 pb-0 pl-0">{{Book.Title}}</v-card-title>
            <div class="subtitle-1"> {{Book.Author}} </div>
        </div>
        <v-card-actions class="pt-0">
            <v-rating :value="Book.Rate"
                v-on:input="rateUpdated($event)"
                color="amber"
                background-color="amber"
                dense
                size="18">
            </v-rating>
            <v-spacer></v-spacer>
            <v-btn text icon v-on:click="toggleFavorite()">
                <v-icon v-if="Book.IsFavorite" color="red">mdi-heart</v-icon>
                <v-icon v-else color="red">mdi-heart-outline</v-icon>
            </v-btn>
        </v-card-actions>
    </v-card>
</template>

<script>


export default {
    name: 'ProductCard',
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
            Book: {
                    Rate: 4,
                    IsFavorite: true,
                    Author: "David Allen",
                    Title: "Gettings Things Done",
                    Category: "Psychology",
                    ImageUrl: require('./../../assets/getting-things-done-czyli-sztuka-bezstresowej-efektywnosci-wydanie-ii-srednie.jpg')
                
            },
            FavoriteBooks: [
                {
                    Rate: 4,
                    Author: "David Allen",
                    Title: "Gettings Things Done",
                    Category: "Psychology",
                    ImageUrl: require('./../../assets/getting-things-done-czyli-sztuka-bezstresowej-efektywnosci-wydanie-ii-srednie.jpg')
                },
                {
                    Rate: 8,
                    Author: "Daniel Kahneman",
                    Title: "Pułapki Myślenia",
                    Category: "Psychology",
                    ImageUrl: require('./../../assets/getting-things-done-czyli-sztuka-bezstresowej-efektywnosci-wydanie-ii-srednie.jpg')
                },
                {
                    Rate: 8.5,
                    Author: "Charles Duhigg",
                    Title: "Siła nawyku",
                    Category: "Psychology",
                    ImageUrl: require('./../../assets/getting-things-done-czyli-sztuka-bezstresowej-efektywnosci-wydanie-ii-srednie.jpg')
                },
                {
                    Rate: 5,
                    Author: "Name Surname",
                    Title: "Book Title 1",
                    Category: "Category 3",
                    ImageUrl: require('./../../assets/getting-things-done-czyli-sztuka-bezstresowej-efektywnosci-wydanie-ii-srednie.jpg')
                },
                {
                    Rate: 5,
                    Author: "Name Surname",
                    Title: "Book Title 2",
                    Category: "Category 2",
                    ImageUrl: require('./../../assets/getting-things-done-czyli-sztuka-bezstresowej-efektywnosci-wydanie-ii-srednie.jpg')
                },
                {
                    Rate: 5,
                    Author: "Name Surname",
                    Title: "Book Title 3",
                    Category: "Category 1",
                    ImageUrl: require('./../../assets/getting-things-done-czyli-sztuka-bezstresowej-efektywnosci-wydanie-ii-srednie.jpg')
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