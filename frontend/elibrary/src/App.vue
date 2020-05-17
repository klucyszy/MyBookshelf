<template>
    <v-app>
        <app-header></app-header>
        <app-alert></app-alert>
        <loading-indicator></loading-indicator>
        <v-content transition="slide-x-transition" class="grey lighten-5 my-5" justify="center" align="center">      
            <router-view></router-view>
        </v-content>
    </v-app>
</template>

<script>
import AppHeader from '@/components/layout/AppHeader';
import AppAlert from '@/components/common/AppAlert';
import LoadingIndicator from '@/components/common/LoadingIndicator';

export default {
    name: 'App',
    components: {
      AppHeader,
      AppAlert,
      LoadingIndicator
    }
};
</script>

<style scoped>
</style>
