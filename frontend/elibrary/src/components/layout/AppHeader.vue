<template>
    <span>
        <v-navigation-drawer app v-model="drawer" class="grey lighten-5" disable-resize-watcher ex>
            <v-list>
                <template v-for="(item, index) in pageItems">
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
            <template v-for="(item, index) in pageItems">
                <v-btn :key="index" icon class="mr-2 hidden-sm-and-down nav-menu router-link-color" :to="item.url" data-cy="menuBtn">
                    <v-icon>{{item.icon}}</v-icon>
                </v-btn>
            </template>
            <v-menu icon open-on-hover offset-y>
                <template v-slot:activator="{on}">
                    <v-btn icon v-on="on" class="ml-2 mr-2 router-link-color">
                        <v-icon>mdi-account-outline</v-icon>
                        <v-icon>mdi-menu-down</v-icon>
                    </v-btn>
                </template>
                <v-list>
                    <v-list-item v-if="signedIn" :to="{path: '/profile'}">
                        <v-list-item-title>My Profile</v-list-item-title>
                    </v-list-item>
                    <v-list-item v-if="signedIn" v-on:click="handleSignOut()">
                        <v-list-item-title>Sign Out</v-list-item-title>
                    </v-list-item>
                    <v-list-item v-if="!signedIn" v-on:click="handleSignIn()">
                        <v-list-item-title>Sign In</v-list-item-title>
                    </v-list-item>
                </v-list>
            </v-menu>
        </v-toolbar>
    </span>
</template>

<script>
import SearchField from './../../components/common/SearchField'
import  { mapGetters } from 'vuex'

export default {
    name: 'AppHeader',
    components: {
        SearchField
    },
    computed: mapGetters('signin', ['signedIn']),
    data() {
        return {
            appTitle: 'Bookshelf',
            drawer: false,
            pageItems: [
                { title: 'Bookshelf', url: '/bookshelf', icon: 'mdi-bookshelf'},
                { title: 'About', url: '/about', icon: 'mdi-information-variant' },           
            ],
        };
    },
    methods: {
        handleSignIn: function() {
            this.$store.dispatch('signin/logIn', null, { root: true });
        },
        handleSignOut: function() {
            this.$store.dispatch('signin/logOut', null, { root: true });
        }
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