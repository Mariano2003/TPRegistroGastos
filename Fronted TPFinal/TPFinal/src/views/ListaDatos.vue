<template>
  <div class="container">
    <h1>Registro de gastos</h1>
    <p>Tabla</p>
    <table border="1">
      <thead>
        <tr>
          <th>Fecha</th>
          <th>Nombre del Comercio</th>
          <th>Descripción</th>
          <th>Monto</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in items" :key="item.id">
          <td>{{ item.fecha }}</td>
          <td>{{ item.nombreComercio }}</td>
          <td>{{ item.descripcion }}</td>
          <td>${{ item.monto }}</td>
        </tr>
      </tbody>
    </table>
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
