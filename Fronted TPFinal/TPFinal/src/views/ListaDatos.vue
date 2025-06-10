<template>
  <div class="container">
    <h1>Registro de gastos</h1>
    <p>Tabla</p>
    <div class="tabla-wrapper">
      <table>
        <thead>
          <tr>
            <th>Fecha</th>
            <th>Nombre del Comercio</th>
            <th>Descripción</th>
            <th>Monto</th>
          </tr>
        </thead>
      </table>
    </div>
      <div class="tabla-scroll">
        <table>
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

<style scoped>
.tabla-wrapper {
  width: 100%;
}

.tabla-scroll {
  max-height: 400px;
  overflow-y: auto;
  overflow-x: hidden;
}

.tabla-scroll table {
  width: 100%;
  background: white;
}

thead tr {
  background-color: #2c3e50;
  color: white;
  text-align: left;
  font-weight: 700;
}

thead th, .tabla-scroll td {
  padding: 12px 16px;
}

.tabla-scroll tr {
  background: #fff;
  transition: background-color 0.3s ease;
  cursor: default;
  box-shadow: 0 1px 3px rgba(0,0,0,0.08);
}

.tabla-scroll tr:hover {
  background-color: #f1f4f8;
}

.tabla-scroll td {
  white-space: nowrap;
  border-bottom: 1px solid #eee;
}

.tabla-scroll tr:last-child td {
  border-bottom: none;
}

.tabla-scroll td:nth-child(4) {
  font-weight: 600;
  color: #27ae60; 
}

.tabla-scroll td:nth-child(3) {
  white-space: normal;
  word-break: break-word;
  min-width: 300px;
  max-width: 500px;
}


.tabla-scroll {
  max-height: 400px;
  overflow-x: auto;
  overflow-y: auo;
}
.container {
  max-width: 900px;
  margin: 2rem auto;
  padding: 2rem;
  background: #f8f9fa;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.1);
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  color: #333;
}

h1 {
  text-align: center;
  margin-bottom: 1rem;
  color: #2c3e50;
}

p {
  text-align: center;
  font-weight: 600;
  margin-bottom: 1.5rem;
  color: #34495e;
}

table {
  width: 100%;
  border-collapse: separate;
  border-spacing: 0 8px;
  box-shadow: 0 2px 8px rgba(0,0,0,0.05);
  background: white;
  
  overflow: hidden;
}

thead tr {
  background-color: #2c3e50;
  color: white;
  text-align: left;
  font-weight: 700;
}

thead th {
  padding: 12px 16px;
}

tbody tr {
  background: #fff;
  transition: background-color 0.3s ease;
  cursor: default;
  box-shadow: 0 1px 3px rgba(0,0,0,0.08);
}

tbody tr:hover {
  background-color: #f1f4f8;
}

tbody td {
  white-space: nowrap;
  padding: 12px 16px;
  border-bottom: 1px solid #eee;
}

tbody tr:last-child td {
  border-bottom: none;
}

tbody td:nth-child(4) {
  font-weight: 600;
  color: #27ae60; 
}

@media (max-width: 600px) {
  .container {
    padding: 1rem;
  }
  table, thead, tbody, tr, th, td {
    display: block;
    width: 100%;
  }
  thead tr {
    display: none;
  }
  tbody tr {
    margin-bottom: 1rem;
    box-shadow: none;
    background: #f9f9f9;
    border-radius: 8px;
    padding: 1rem;
  }
  tbody td {
    border: none;
    padding: 6px 0;
    position: relative;
    padding-left: 50%;
    text-align: left;
  }
  tbody td::before {
    content: attr(data-label);
    position: absolute;
    left: 1rem;
    top: 6px;
    font-weight: 700;
    color: #555;
  }
}
</style>
