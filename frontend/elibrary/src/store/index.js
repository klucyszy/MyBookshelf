import Vue from 'vue';
import Vuex from 'vuex';
import createPersistedState from "vuex-persistedstate";

import signin from "./modules/signin.module";
import alert from "./modules/alert.module";
import loading from "./modules/loading.module";
import search from "./modules/search.module";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    signin,
    alert,
    loading,
    search
  },
  plugins: [createPersistedState({
    paths: ['signin'],
    
  })],
})
