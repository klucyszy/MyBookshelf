<template>
    <v-app>
        <app-header></app-header>
        <v-content transition="slide-x-transition" class="grey lighten-5 my-5" justify="center" align="center">
            <book-card></book-card>
            <router-view></router-view>
        </v-content>
    </v-app>
</template>

<script>
import AppHeader from '@/components/layout/AppHeader';
import BookCard from '@/components/common/BookCard';

export default {
    name: 'App',
    components: {
      AppHeader,
      BookCard
    }
};
</script>

<style>
</style>
