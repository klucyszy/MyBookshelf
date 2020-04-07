import Vue from 'vue';
import Vuex from 'vuex';

import signin from "./modules/signin.module";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    signin
  }
})