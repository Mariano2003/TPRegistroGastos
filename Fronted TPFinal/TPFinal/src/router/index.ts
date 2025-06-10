import { createRouter, createWebHistory } from 'vue-router'
import Blank from '@/views/Blank.vue';
import ListaDatos from '../views/ListaDatos.vue'
import IngresarDatos from '../views/IngresarDatos.vue'

const routes = [
  { path: '/blank', component: Blank },
  { path: '/', component: ListaDatos },
  { path: '/ingresar', component: IngresarDatos },
];

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
