import Vue from 'vue'
import App from './App.vue'
import '@mdi/font/css/materialdesignicons.css' 
import vuetify from './plugins/vuetify';
import router from './router'

Vue.config.productionTip = false;
Vue.config.devtools = true;

Vue.use(vuetify, {
  iconfont: 'mdi'
})

new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')
