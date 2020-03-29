<template>
    <span>
        <v-navigation-drawer app v-model="drawer" class="grey lighten-5" disable-resize-watcher ex>
            <v-list>
                <template v-for="(item, index) in items">
                    <v-list-item :key="index" :to="item.url">
                        <v-list-item-content>
                            {{ item.title }}
                        </v-list-item-content>
                    </v-list-item>
                    <v-divider :key="`divider-${index}`"></v-divider>
                </template>
            </v-list>
        </v-navigation-drawer>
        <v-toolbar color="grey lighten-5">
            <v-app-bar-nav-icon
                class="hidden-md-and-up"
                @click="drawer = !drawer"
            ></v-app-bar-nav-icon>
            <v-spacer class="hidden-md-and-up"></v-spacer>
            <router-link class="router-link-color" to="/">
                <v-toolbar-title data-cy="titleBtn">
                    {{appTitle}}
                </v-toolbar-title>
            </router-link>
            <v-spacer class="hidden-sm-and-down"></v-spacer>
            <search-field></search-field>
            <template v-for="(item, index) in items">
                <v-btn :key="index" icon class="ma-2 hidden-sm-and-down nav-menu router-link-color" :to="item.url" data-cy="menuBtn">
                    <v-icon>{{item.icon}}</v-icon>
                </v-btn>
            </template>
        </v-toolbar>
    </span>
</template>

<script>
import SearchField from './../../components/common/SearchField'

export default {
    name: 'AppHeader',
    components: {
        SearchField
    },
    data() {
        return {
            appTitle: 'Bookshelf',
            drawer: false,
            items: [
                { title: 'Bookshelf', url: '/bookshelf', icon: 'mdi-bookshelf'},
                { title: 'About', url: '/about', icon: 'mdi-information-variant' },
                { title: 'SignIn', url: '/sign-in', icon: 'mdi-account-outline' },                
            ]
        };
    },
    computed: {
    },
    methods: {
    }
};
</script>

<style scoped>

.router-link-color {
    color: #263238 !important;
    background-color: transparent !important;
    text-decoration: none;
}
</style>