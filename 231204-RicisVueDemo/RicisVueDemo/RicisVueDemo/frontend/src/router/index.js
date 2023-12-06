import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ImportUebersichtView from '../views/ImportUebersichtView.vue'
import InhalteView from '../views/InhalteView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
      },
      {
          path: '/importuebersicht',
          name: 'importuebersicht',
          component: ImportUebersichtView
      },
      {
          path: '/inhalte/:useCase/:ricisInstance/:betrachtungstag',
          name: 'inhalte',
          component: InhalteView
      },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
    }

  ]
})

export default router
