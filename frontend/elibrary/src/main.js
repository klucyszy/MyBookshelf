import Vue from 'vue';
import GAuth from 'vue-google-oauth2'
import App from './App.vue';
import '@mdi/font/css/materialdesignicons.css' ;
import vuetify from './plugins/vuetify';
import googleAuth from './plugins/googleAuth';
import router from './router';
import store from './store';

Vue.config.productionTip = false;
Vue.config.devtools = true;

Vue.use(vuetify, {
  iconfont: 'mdi'
});

Vue.use(GAuth, googleAuth.gauthOptions);

new Vue({
  vuetify,
  router,
  store,
  render: h => h(App)
}).$mount('#app')
