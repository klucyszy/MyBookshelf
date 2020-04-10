import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import GAuth from 'vue-google-oauth2'

const gauthOptions = {
  clientId: '920200399874-4qmdqvfdgt4mq5i8jsqfdf8it3j68sjl.apps.googleusercontent.com',
  scope: 'profile email',
  prompt: 'select_account'
}

Vue.use(VueRouter)
Vue.use(GAuth, gauthOptions)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    component: () => import('../views/About.vue')
  },
  {
    path: '/profile',
    name: 'MyProfile',
    component: () => import('../pages/MyProfilePage/index.vue')
  },
  {
    path: '/bookshelf',
    name: 'Bookshelf',
    component: () => import('../pages/BookshelfPage/index.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
