fetch('https://localhost:7055/api/WeatherForecast')
    .then(response => response.json())
    .then(data => {
        const lista = document.getElementById('lista-gastos');
        data.forEach(item => {
            const li = document.createElement('li');
            li.textContent = `${gasto.monto} - ${gasto.descripcion}`;
            lista.appendChild(li);
        });
    });