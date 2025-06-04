

use Gastos;

Create table Gastos(
Id int identity (1, 1) primary key,
Monto decimal(10, 2) not null,
Descripcion varchar(250) not null, 
Fecha date not null,
NombreComercio varchar(250) not null
);