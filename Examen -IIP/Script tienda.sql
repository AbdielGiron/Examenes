 --drop database  TiendaMessi
create database TiendaMessi
go

use TiendaMessi
go

create schema facturacion
go

create table facturacion.cliente (
	idCliente int primary key not null,
	nombre varchar(25),
	apellido varchar(25),
	direccion varchar(50),
)

create table facturacion.producto(
	idProducto int primary key not null,
	nombreProducto varchar(40),
	descripcion varchar(50)
)

insert into facturacion.producto(idProducto,nombreProducto,descripcion) values
(1000,'Coca','1.5 Lts'),
(1100,'Pepsi','1.5 Lts'),
(1110,'Banana','1.5 Lts'),
(1111,'Fresca','1.5 Lts')

select *from facturacion.producto

create table facturacion.Venta (
	idVenta int primary key not null,
	fechaVenta date,
	precio int,
	cantidad int,
	idCliente int foreign key references facturacion.cliente(idCliente) on delete cascade,
	idProducto int foreign key references facturacion.producto(idProducto) on delete cascade
)

--CRUD DE LA TABLA CIENTES
create procedure ingresarClientes 
@idCliente int,
@nombre varchar(25),
@apellido varchar(25),
@direccion varchar(50)
AS
BEGIN
insert into facturacion.cliente (idCliente,nombre,apellido,direccion) values
(@idCliente, @nombre, @apellido, @direccion)
END
exec ingresarClientes 1000,'Abdiel','Giron','San Jose'
exec ingresarClientes 1100,'Jesus','Garcia','Siguatepeque'
exec ingresarClientes 1110,'Marcos','Garcia','Comayagua'
exec ingresarClientes 1111,'Juan','Garcia','Siguatepeque'
select *from facturacion.cliente

create procedure consultarTablaClientes 
AS 
BEGIN
select cl.idCliente,CONCAT(cl.nombre ,' ',cl.apellido) as 'Nombre Completo',cl.direccion from facturacion.cliente as cl 
END
exec consultarTablaClientes

create procedure consultarClienteIndividual(@idCliente int)
AS 
BEGIN
select cl.idCliente,CONCAT(cl.nombre ,' ',cl.apellido) as 'Nombre Completo',cl.direccion from facturacion.cliente as cl 
where cl.idCliente = @idCliente
END
exec consultarClienteIndividual 0

create procedure actualizarTablaClientes(
@idCliente int,
@nombre varchar(25),
@apellido varchar(25),
@direccion varchar(50)
)
AS
BEGIN
update facturacion.cliente set nombre = @nombre, apellido=@apellido, direccion=@direccion  
where idCliente = @idCliente
End
exec actualizarTablaClientes 1,'Elmer','Chandia','Sigua,Comayagua'

create procedure eliminarCliente(@idcliente int)
AS
BEGIN
delete from facturacion.cliente where idCliente = @idcliente
END

exec eliminarCliente 0

--CRUD DE LA TABLA PRODUCTO
create procedure ingresarProducto 
@idProducto int,
@nombreProducto varchar(40),
@descripcion varchar(50)
AS
BEGIN
insert into facturacion.producto(idProducto,nombreProducto,descripcion) values
(@idProducto,@nombreProducto,@descripcion)
END
exec ingresarProducto 3,'Fanta','medio'

create procedure consultarTablaProductos 
AS 
BEGIN
select pr.idProducto,pr.nombreProducto as 'Nombre Producto',pr.descripcion from facturacion.producto as pr
END
exec consultarTablaProductos

create procedure consultarProductoIndividual(@idproducto int)
AS 
BEGIN
select pr.idProducto,pr.nombreProducto as 'Nombre Producto',pr.descripcion from facturacion.producto as pr
where pr.idProducto = @idproducto
END
exec consultarProductoIndividual 1000


create procedure actualizarProducto (
@idProducto int,
@nombreProducto varchar(40),
@descripcion varchar(50)
)
AS
BEGIN
update facturacion.producto set nombreProducto=@nombreProducto, descripcion = @descripcion 
where idProducto = @idProducto
End
exec actualizarProducto 2,'Pecsi','Buenona'

create procedure eliminarProducto(@idproducto int)
AS
BEGIN
delete from facturacion.producto where idProducto = @idproducto
END
exec eliminarProducto 1000

--CRUD DE LA TABLA VENTAS
create procedure ingresarVenta 
@idventa int,
@fechaVenta date,
@precio int,
@cantidad int,
@idCliente int,
@idProducto int
AS
BEGIN
insert into facturacion.Venta(idVenta,fechaVenta,precio,cantidad,idCliente,idProducto) values
(@idVenta,@fechaVenta,@precio,@cantidad,@idCliente,@idProducto)
END
exec ingresarVenta 1000,'2020-07-10',100,10,1000,1000
exec ingresarVenta 1100,'2021-08-11',200,10,1100,1100
exec ingresarVenta 1110,'2022-09-13',300,10,1110,1110
exec ingresarVenta 1111,'2023-10-14',400,10,1111,1111
select *from facturacion.Venta

create procedure consultarTablaVentas 
AS 
BEGIN
select CONCAT(cl.nombre ,' ',cl.apellido) as 'Nombre Completo', pr.nombreProducto, v.cantidad, v.precio,v.fechaVenta from facturacion.Venta as v
inner join facturacion.cliente as cl on v.idCliente= cl.idCliente  
inner join facturacion.producto as pr on v.idProducto =  pr.idProducto 
END
exec consultarTablaVentas 


create procedure consultarVentaIndividual (@nombre varchar(25))
AS 
BEGIN
select CONCAT(cl.nombre ,' ',cl.apellido) as 'Nombre Completo', pr.nombreProducto, v.cantidad, v.precio,v.fechaVenta from facturacion.Venta as v
inner join facturacion.cliente as cl on cl.idCliente = v.idCliente
inner join facturacion.producto as pr on pr.idProducto = v.idProducto
where cl.nombre = @nombre
END
exec consultarVentaIndividual 'Marcos'


create procedure actualizarTablaVentas (
@idventa int,
@precio int,
@cantidad int,
@idProducto int
)
AS
BEGIN
update facturacion.Venta set precio = @precio, cantidad=@cantidad, idProducto=@idProducto  
where idVenta = @idventa
End
exec actualizarTablaVentas 1,100,4,2

create procedure eliminarVenta(@idventa int)
AS
BEGIN
delete from facturacion.Venta where idVenta = @idventa
END

exec eliminarVenta 3
