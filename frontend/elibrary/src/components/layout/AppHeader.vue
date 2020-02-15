<template>
    <span>
        <v-navigation-drawer
            app
            v-model="drawer"
            class="brown lighten-2"
            dark
            disable-resize-watcher
        >
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
        <v-toolbar color="brown darken-4" dark>
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
            <v-btn
                text
                class="hidden-sm-and-down nav-menu"
                to="/about"
                data-cy="menuBtn"
                >About</v-btn
            >            
        </v-toolbar>
    </span>
</template>

<script>
export default {
    name: 'AppHeader',
    data() {
        return {
            appTitle: 'E-Library',
            drawer: false,
            items: [
                { title: 'About', url: '/about' },
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
    color: white;
    text-decoration: none;
}
</style>