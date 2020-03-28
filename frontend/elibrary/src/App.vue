<template>
    <v-app>
        <app-header></app-header>
        <v-content transition="slide-x-transition" class="grey lighten-5 my-5" justify="center" align="center">
            <books-slider></books-slider>         
            <router-view></router-view>
        </v-content>
    </v-app>
</template>

<script>
import AppHeader from '@/components/layout/AppHeader';
import BooksSlider from '@/components/common/BooksSlider';

export default {
    name: 'App',
    components: {
      AppHeader,
      BooksSlider,
    }
};
</script>

<style>
</style>
