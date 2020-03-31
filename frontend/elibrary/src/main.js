import Vue from 'vue';
import App from './App.vue';
import '@mdi/font/css/materialdesignicons.css' ;
import GAuth from 'vue-google-oauth2';
import vuetify from './plugins/vuetify';
import router from './router';

const gauthOptions = {
  clientId: '920200399874-ph38c06nsdv3sskcjjsiinna3uh5ojo7.apps.googleusercontent.com',
  scope: 'profile email',
  prompt: 'select_account'
}

Vue.config.productionTip = false;
Vue.config.devtools = true;

Vue.use(vuetify, {
  iconfont: 'mdi'
});
Vue.use(GAuth, gauthOptions);

new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')
