<template>
    <v-card outlined class="mx-3"
            min-width="200" 
            max-width="200">
        
        <v-img :src=Book.ImageUrl
            height="165px">
        </v-img>

        <div align="left" class="pl-4">
            <v-card-title class="pt-1 pb-0 pl-0">{{bookTitle}}</v-card-title>
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
    name: 'BookCard',
    props: {
        Book: {
            type: Object,
            default: function() {
                return {
                    Rate: 1,
                    IsFavorite: false,
                    Author: "",
                    Title: "",
                    Category: "",
                    ImageUrl: "#"   
                }            
            }
        }
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
        };
    },
    computed: {
        bookTitle: function(){
            if (this.Book.Title.length > 16)
                return this.Book.Title.substring(0, 16) + "..";
            else 
                return this.Book.Title;
        }
    }
};
</script>

<style scoped>
    .card-size {
        max-width: 200px;
    }
</style>