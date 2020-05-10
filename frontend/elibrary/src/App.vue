<template>
    <v-app>
        <app-header></app-header>
        <app-alert></app-alert>
        <v-content transition="slide-x-transition" class="grey lighten-5 my-5" justify="center" align="center">      
            <router-view></router-view>
        </v-content>
    </v-app>
</template>

<script>
import AppHeader from '@/components/layout/AppHeader';
import AppAlert from '@/components/common/AppAlert';

export default {
    name: 'App',
    components: {
      AppHeader,
      AppAlert
    }
};
</script>

<style scoped>
</style>
