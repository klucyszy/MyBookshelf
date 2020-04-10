import Vue from 'vue';
import GAuth from 'vue-google-oauth2'
import App from './App.vue';
import axios from 'axios'
import VueAxios from 'vue-axios'
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


axios.defaults.baseURL = 'https://localhost:44354/';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = true;
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
Vue.use(VueAxios, axios);

new Vue({
  vuetify,
  router,
  store,
  render: h => h(App)
}).$mount('#app')
