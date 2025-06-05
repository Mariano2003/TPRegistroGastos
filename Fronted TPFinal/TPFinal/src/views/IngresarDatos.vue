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