<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
</script>

<template>
  <header>
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Registro de gastos</RouterLink>
        <RouterLink to="/ingresar">Ingresar gastos</RouterLink>
      </nav>
    </div>
  </header>

  <RouterView />
</template>

<style scoped>
header {
  background: #f8f9fa;
  padding: 1rem 0;
  box-shadow: 0 2px 8px rgba(0,0,0,0.1);
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.wrapper {
  max-width: 700px;
  margin: 0 auto;
  padding: 0 1rem;
  display: flex;
  justify-content: center;
}

nav {
  width: 100%;
  font-size: 1rem;
  text-align: center;
}

nav a {
  display: inline-block;
  padding: 0.6rem 1.2rem;
  margin: 0 0.6rem;
  border-radius: 8px;
  text-decoration: none;
  color: #34495e;
  font-weight: 600;
  border: 1.8px solid transparent;
  transition: 
    background-color 0.3s ease, 
    color 0.3s ease,
    border-color 0.3s ease;
}

nav a:hover {
  background-color: #3498db;
  color: #fff;
  border-color: #2980b9;
}

nav a.router-link-exact-active {
  background-color: #27ae60;
  color: white;
  border-color: #219150;
  cursor: default;
}

nav a.router-link-exact-active:hover {
  background-color: #2ecc71;
  border-color: #27ae60;
}

@media (min-width: 1024px) {
  .wrapper {
    justify-content: flex-start;
  }

  nav {
    text-align: left;
  }
}
</style>