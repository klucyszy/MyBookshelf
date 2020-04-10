import Vue from 'vue';
import Vuex from 'vuex';
import createPersistedState from "vuex-persistedstate";

import signin from "./modules/signin.module";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    signin
  },
  plugins: [createPersistedState({
    paths: ['signin']
  })],
})
