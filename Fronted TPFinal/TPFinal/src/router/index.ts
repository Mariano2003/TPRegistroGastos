import { createRouter, createWebHistory } from 'vue-router'
import ListaDatos from '../views/ListaDatos.vue'
import IngresarDatos from '../views/IngresarDatos.vue'

const routes = [
  { path: '/', component: ListaDatos },
  { path: '/ingresar', component: IngresarDatos },
];

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
