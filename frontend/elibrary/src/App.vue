<template>
    <v-app>
        <app-header></app-header>
        <v-content transition="slide-x-transition" class="grey lighten-5 my-5" justify="center" align="center">      
            <router-view></router-view>
        </v-content>
    </v-app>
</template>

<script>
import AppHeader from '@/components/layout/AppHeader';

export default {
    name: 'App',
    components: {
      AppHeader,
    }
};
</script>

<style>
</style>
