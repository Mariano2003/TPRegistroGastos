<template>
  <div class="container">
    <h1>Registro de gastos</h1>
    <p>________________________</p>
    <ul>
      <li v-for="item in items" :key="item.id">
        <strong>Id:</strong> {{ item.id }} ||
        <strong>Descripción:</strong> {{ item.descripcion }} ||
        <strong>Fecha:</strong> {{ item.fecha }} ||
        <strong>Monto: $</strong> {{ item.monto }} ||
        <strong>Nombre del Comercio:</strong> {{ item.nombreComercio }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      items: []
    }
  },
  mounted() {
    fetch('https://localhost:7055/api/Gasto') 
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
      })
      .then(data => {
        console.log("Datos recibidos:", data);
        this.items = data;
      })
      .catch(error => {
        console.error('Error al obtener los datos:', error);
      });
  }
}
</script>


<style>
</style>
