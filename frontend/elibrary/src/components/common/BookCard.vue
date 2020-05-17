<template>
    <v-card outlined class="mx-3"
            min-width="200" 
            max-width="200">
        
        <v-img :src=Book.ImageUrl
            height="165px">
        </v-img>

        <div align="left" class="pl-4">
            <v-card-title class="pt-1 pb-0 pl-0">{{bookTitle}}</v-card-title>
            <div class="subtitle-1"> {{authors}} </div>
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
            <v-btn dense text icon class="mx-0 px-0" v-on:click="toggleFavorite()">
                <v-icon v-if="Book.IsFavorite" color="red">mdi-heart</v-icon>
                <v-icon v-else color="red">mdi-heart-outline</v-icon>
            </v-btn>
            <v-menu icon open-on-hover class="mx-0 px-0">
                <template v-slot:activator="{on}">
                    <v-btn icon v-on="on">
                        <v-icon>mdi-dots-vertical</v-icon>
                    </v-btn>
                </template>
                <v-list dense min-width="150px">
                    <v-list-item v-for="(shelf, index) in userBookshelfs"
                        v-on:click="toggleBookshelf(shelf)"
                        :key="index">
                        <v-list-item-title>{{shelf.title}}</v-list-item-title>
                        <v-spacer></v-spacer>
                        <v-icon v-if="shelf.isChecked">mdi-check</v-icon>
                    </v-list-item>
                </v-list>
            </v-menu>
        </v-card-actions>
    </v-card>
</template>

<script>
const clonedeep = require('lodash.clonedeep');

export default {
    name: 'BookCard',
    props: {
        Book: {
            type: Object,
            default: function() {
                return {
                    Rate: 1,
                    IsFavorite: false,
                    authors: [],
                    title: "",
                    Category: "",
                    ImageUrl: "#",
                    userBookshelfs: [
                        {
                            id: "",
                            title: "",
                            IsChecked: false,
                        }
                    ]
                }            
            }
        }
    },
    methods: {
        rateUpdated: function(value){
            this.Book.Rate = value;
            if (this.loadedBook.Rate !== this.Book.Rate){
                this.updatedBook.Rate = value;
            }
            else{
                delete this.updatedBook.Rate;
            }
        },
        toggleFavorite: function() {
            this.Book.IsFavorite = !this.Book.IsFavorite;
            if (this.loadedBook.IsFavorite !== this.Book.IsFavorite){
                this.updatedBook.IsFavorite = this.Book.IsFavorite;
            }
            else{
                delete this.updatedBook.IsFavorite;
            }
        },
        toggleBookshelf: function(bookshelf) {
            bookshelf.isChecked = !bookshelf.isChecked;
            //TODO: Fix tracking changes
            // let loadedBookshelf = this.loadedBook.userBookshelfs.find(el => el.id === bookshelf.id);
            // if (loadedBookshelf.isChecked !== bookshelf.isChecked ){
            //     this.updatedBook.userBookshelfs.push(bookshelf);
            // }
            // else {
            //     let bookshelfs = this.updatedBook.userBookshelfs;
            //     for (let i = 0; i < bookshelfs.length; i++)
            //         if (bookshelfs[i].title === bookshelf.title) {
            //             bookshelfs.splice(i,1);
            //             break;
            //     }
            // }

        }
    },
    data() {
        return {
            updatedBook: {
                Bookshelfs: [],
            },
            loadedBook: {},
        };
    },
    computed: {
        bookTitle: function(){
            if (this.Book.title.length > 14)
                return this.Book.title.substring(0, 14) + "..";
            else 
                return this.Book.title;
        },
        authors: function() {
            let authors = "";
            for(var i = 0; i < this.Book.authors.length; i++) {
                authors = authors + " " + this.Book.authors[i];
            }

            if (authors.length > 20)
                return authors.substring(0, 20) + "..";
            else 
                return authors;
        },
        userBookshelfs: function() {
            let allBookshelfs = this.$store.state.search.categories;
            let result = [];
            for (var item of allBookshelfs) {
                let inBookshelf = this.Book.userBookshelfs.filter(b => b.id === item.id).length > 0;
                result.push({id: item.id, title: item.title, isChecked: inBookshelf});
            }
            return result;
        }
    },
    mounted() {
        this.loadedBook = clonedeep(this.Book);
    }
};
</script>

<style scoped>
    .card-size {
        max-width: 200px;
    }
</style>