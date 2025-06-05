<template>
<div>   
    <h1>Ingresar gasto</h1>
    <form @submit.prevent="enviarFormulario">
        <div>
            <label>Fecha:</label>
            <input v-model="nuevoGasto.fecha" type="date" :max="hoy" required>
        </div>
        <div>
            <label>Nombre del comercio:</label>
            <input v-model="nuevoGasto.nombreComercio" type="text" required>
        </div>
        <div>
            <label>Descripcion:</label>
            <input v-model="nuevoGasto.descripcion" type="text" required>
        </div>
        <div>
            <label>Monto:</label>
            <input v-model="nuevoGasto.monto" type="number" required>
        </div>
        <button type="submit">Guardar gasto</button>
    </form>
    <p v-if="mensaje">{{ mensaje }}</p>
</div>
</template>


<script>
    export default {
    data() {
        return {
            nuevoGasto: {
            descripcion: '',
            monto: 0,
            fecha: '',
            nombreComercio: ''
            },
            mensaje: '',
            hoy: new Date().toISOString().split('T')[0]
            };
        },
        methods: {
        async enviarFormulario() {
            try {
            const response = await fetch('https://localhost:7055/api/Gasto', {
                method: 'POST',
                headers: {
                'Content-Type': 'application/json'
                },
                body: JSON.stringify(this.nuevoGasto)
            });
            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(`Error al guardar: ${errorText}`);
            }
            const resultado = await response.json();
            this.mensaje = 'Gasto guardado exitosamente';
            console.log('Gasto guardado:', resultado);
            // Limpiar el formulario
            this.nuevoGasto = {
                descripcion: '',
                monto: 0,
                fecha: '',
                nombreComercio: ''
            };
            } catch (error) {
            console.error('Error al enviar el formulario:', error);
            this.mensaje = 'Error al guardar el gasto';
            }
        }
    }
}
</script>

<style scoped>
div {
  max-width: 500px;
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
  margin-bottom: 1.5rem;
  color: #2c3e50;
}

form > div {
  display: flex;
  flex-direction: column;
  margin-bottom: 1.2rem;
}

label {
  font-weight: 600;
  margin-bottom: 0.4rem;
  color: #34495e;
}

input[type="text"],
input[type="date"],
input[type="number"] {
  padding: 0.6rem 1rem;
  font-size: 1rem;
  border: 1.8px solid #ddd;
  border-radius: 8px;
  transition: border-color 0.3s ease;
  outline-offset: 2px;
}

input[type="text"]:focus,
input[type="date"]:focus,
input[type="number"]:focus {
  border-color: #3498db;
  outline: none;
}

button {
  background-color: #27ae60;
  color: white;
  border: none;
  padding: 0.75rem 1.2rem;
  font-size: 1.1rem;
  border-radius: 10px;
  cursor: pointer;
  font-weight: 700;
  transition: background-color 0.25s ease;
  width: 100%;
  margin-top: 1rem;
  box-shadow: 0 4px 8px rgba(39, 174, 96, 0.3);
}

button:hover {
  background-color: #2ecc71;
}

p {
  margin-top: 1rem;
  font-weight: 600;
  text-align: center;
  color: #27ae60;
}

p.error {
  color: #e74c3c;
}


@media (max-width: 600px) {
  div {
    padding: 1rem;
  }
}
</style>