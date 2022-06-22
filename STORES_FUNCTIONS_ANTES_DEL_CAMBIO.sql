USE [CarritoCompras_1]
GO
/****** Object:  UserDefinedFunction [dbo].[Calcular_Coeficiente_Familia]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Calcular_Coeficiente_Familia]    
(    
	@id_tabla_familia int    
)    
RETURNS decimal(18, 8)
as    
begin    
Declare @Coeficiente decimal(18, 8)





	Select @Coeficiente = 
							(
								case when algoritmo_1 = '0.0000' then 1 else algoritmo_1 end  * 
								case when algoritmo_2 = '0.0000' then 1 else algoritmo_2 end * 
								case when algoritmo_3 = '0.0000' then 1 else algoritmo_3 end * 
								case when algoritmo_4 = '0.0000' then 1 else algoritmo_4 end * 
								case when algoritmo_5 = '0.0000' then 1 else algoritmo_5 end * 
								case when algoritmo_6 = '0.0000' then 1 else algoritmo_6 end * 
								case when algoritmo_7 = '0.0000' then 1 else algoritmo_7 end * 
								case when algoritmo_8 = '0.0000' then 1 else algoritmo_8 end * 
								case when algoritmo_9 = '0.0000' then 1 else algoritmo_9 end
							) 
	From     
		familia 
	Where    
		familia.id_tabla_familia = @id_tabla_familia

return @Coeficiente    

end
GO
/****** Object:  StoredProcedure [dbo].[ABM_articulos]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ABM_articulos]

as

delete from articulo_tmp_errores
delete from articulo_tmp_duplicados

begin --borro de tabla articulo_tmp -> las filas con TODOS los campos nulos o vacios
	delete from 
		articulo_tmp  
	where	
		(codigo_articulo_marca is null or codigo_articulo_marca =  '')  and 
		(codigo_articulo is null or codigo_articulo =  '') and 
		(descripcion_articulo is null or descripcion_articulo =  '') and 
		(precio_lista is null) and  
		(precio_final is null) and 
		(id_tabla_familia is null) and 
		(sn_oferta is null) and 
		(path_img is null or path_img =  '') and  --ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB 
		(id_articulo is null) and
		(id_orden is null)
end


begin --vuelco los errores en articulo_tmp_errores

	insert into articulo_tmp_errores --inserto en tabla articulo_tmp_errores -> las filas que tengan celdas nulas o vacias
	select distinct 
		codigo_articulo_marca,
		codigo_articulo,
		descripcion_articulo,
		precio_lista,
		precio_final,
		id_tabla_familia,
		sn_oferta, 
		path_img,  --ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB 
		id_articulo, 
		stock,
		id_orden,
		case 
			when (codigo_articulo_marca is null or codigo_articulo_marca = '')  then 'Falta codigo_articulo_marca'
			when (codigo_articulo is null or codigo_articulo = '')   then 'Falta codigo_articulo'
			when (descripcion_articulo is null or  descripcion_articulo = '')   then 'Falta descripcion_articulo'
			when (precio_lista is null)   then 'Falta precio_lista'
			when (precio_final is null)   then 'Falta precio_final'
			when (id_tabla_familia is null)   then 'Falta id_tabla_familia'    
			when (id_orden is null)   then 'Falta id_orden'
			else ''
		end observacion
	from 
		articulo_tmp (nolock)
	where	
		codigo_articulo_marca is null or codigo_articulo_marca = '' or
		codigo_articulo is null or codigo_articulo = '' or
		descripcion_articulo is null or  descripcion_articulo = '' or
		precio_lista is null  or 
		precio_final is null or
		id_tabla_familia is null or
		id_orden is null   
		

	insert into articulo_tmp_duplicados --guardo en articulo_tmp_duplicados donde se repita mas de una vez la conjuncion (codigo_articulo_marca - codigo_articulo)
	select 
		codigo_articulo_marca,
		codigo_articulo,
		COUNT(*) cantidad	
	from 
		articulo_tmp 
	group by 
		codigo_articulo_marca,
		codigo_articulo
	having count (*) > 1


	insert into articulo_tmp_errores --inserto en tabla articulo_tmp_errores : donde se repita mas de una vez la conjuncion (codigo_articulo_marca - codigo_articulo)
	select 
		articulo_tmp.codigo_articulo_marca,
		articulo_tmp.codigo_articulo,
		descripcion_articulo,
		precio_lista,
		precio_final,
		id_tabla_familia,
		sn_oferta, 
		path_img,  --ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB 
		id_articulo, 
		stock,
		id_orden,
		'articulo duplicado' observacion
		
	from
		articulo_tmp (nolock)
		inner join articulo_tmp_duplicados (nolock) on 
												articulo_tmp_duplicados.codigo_articulo_marca = articulo_tmp.codigo_articulo_marca 
												and articulo_tmp_duplicados.codigo_articulo = articulo_tmp.codigo_articulo
				
	delete 
		ta
	from 
		articulo_tmp ta (nolock)
		inner join articulo_tmp_errores te (nolock) on 
														(
															ta.codigo_articulo_marca = te.codigo_articulo_marca 
															and ta.codigo_articulo = te.codigo_articulo 
														) --elimino en tabla articulo_tmp -> los articulos de articulo_tmp_errores
end

begin --modifico de tabla articulo -> las filas que machean con articulo_tmp por el campo id_articulo

	update
		a
	set
		a.codigo_articulo_marca = ta.codigo_articulo_marca,
		a.codigo_articulo = ta.codigo_articulo,
		a.descripcion_articulo = ta.descripcion_articulo,
		a.precio_lista = ta.precio_lista,
		a.id_tabla_familia = ta.id_tabla_familia,
		a.sn_oferta = ta.sn_oferta,
		a.path_img = ta.path_img, --ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB 
		a.fecha_ult_modif = getdate(),
		a.accion = 'MODIFICACION',
		a.id_orden = ta.id_orden,
		a.stock = ta.stock
	from	
		articulo a (nolock)
		inner join articulo_tmp ta (nolock) on a.id_articulo = ta.id_articulo
	where
		a.codigo_articulo_marca <> ta.codigo_articulo_marca or
		a.codigo_articulo <> ta.codigo_articulo or
		a.descripcion_articulo <> ta.descripcion_articulo or
		convert(numeric(18, 4),a.precio_lista) <> convert(numeric(18, 4),ta.precio_lista) or
		convert(int,a.id_tabla_familia) <> convert(int,ta.id_tabla_familia) or
		convert(int,a.sn_oferta) <> convert(int,ta.sn_oferta) or
		a.path_img <> ta.path_img or --ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB 
		a.id_orden <> ta.id_orden or
		a.stock <> ta.stock 
end

begin --modifico de tabla articulo -> las filas que NO machean con articulo_tmp y con articulo_tmp_errores
	update
		a
	set
		a.fec_baja = getdate(),
		a.accion = 'ELIMINACION',
		a.fecha_ult_modif = getdate()
	from	
		articulo a (nolock)
		left join articulo_tmp ta (nolock) on a.id_articulo = ta.id_articulo
		left join articulo_tmp_errores te (nolock) on a.id_articulo = te.id_articulo
	where
		ta.id_articulo is null 
		and te.id_articulo is null
		and a.accion <> 'ELIMINACION'
end 

begin --inserto en tabla "articulo" las filas que existen en "articulo_tmp" y no en "articulo" , osea son productos nuevos
	insert into articulo 
	select 
		ta.codigo_articulo_marca,
		ta.codigo_articulo,
		ta.descripcion_articulo,
		ta.precio_lista,
		ta.id_tabla_familia,
		ISNULL(ta.sn_oferta,0),
		isnull(ta.path_img,''), --ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB 
		getdate(),
		null,
		'ALTA',
		ta.stock,
		ta.id_orden
		
	from
		articulo_tmp ta (nolock)
		left join articulo a (nolock) on a.id_articulo = ta.id_articulo
	where
		a.id_articulo is null 
end

delete from articulo_tmp


exec dbo.alta_articulo_historico

select * from articulo_tmp_errores (nolock)
GO
/****** Object:  StoredProcedure [dbo].[alta_articulo_historico]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[alta_articulo_historico]

as

Declare @id_lista as int
set @id_lista = (select isnull(max(id_lista),0) from articulo_historico  ) + 1

delete from articulo_historico where id_lista < (@id_lista-2)


insert into articulo_historico
select
	@id_lista,
	id_articulo,
	codigo_articulo_marca,
	codigo_articulo,
	descripcion_articulo,
	precio_lista,
	id_tabla_familia,
	sn_oferta,
	path_img, --ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB
	fecha_ult_modif,
	fec_baja,
	accion,
	stock,
	id_orden
	
from
	articulo (nolock)
GO
/****** Object:  StoredProcedure [dbo].[buscar_articulos_con_path_img]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_articulos_con_path_img]

as

--ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB
SELECT * FROM articulo WHERE path_img IS NOT NULL AND path_img <> ''
GO
/****** Object:  StoredProcedure [dbo].[buscar_articulos_en_relacion_a_dataTable]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[buscar_articulos_en_relacion_a_dataTable]
(
	@busqueda int, --SI ES 1 -> BUSCO LOS ARTICULOS EXISTENTES EN LA BASE DE DATOS EN RELACION A LA TABLA #tmp_lista_precios_proveedor
				  --SI ES 2 -> BUSCO LOS ARTICULOS INEEXISTENTES EN LA BASE DE DATOS EN RELACION A LA TABLA #tmp_lista_precios_proveedor
	@id_proveedor int 

)				  
as

if(@busqueda = 1) --BUSCO LOS ARTICULOS ACTIVOS EXISTENTES EN LA BASE DE DATOS EN RELACION A LA TABLA #tmp_lista_precios_proveedor
begin
	select 
		a.codigo_articulo,
		case 
			when (tmp.descripcion_articulo is null or tmp.descripcion_articulo = '') then  a.descripcion_articulo
			when (tmp.descripcion_articulo is not null or tmp.descripcion_articulo <> '') and (tmp.descripcion_articulo <> a.descripcion_articulo) then  tmp.descripcion_articulo
			else  a.descripcion_articulo
		end descripcion_articulo,
		case 
			when (tmp.precio_lista is null or tmp.precio_lista = '') then  a.precio_lista
			when (tmp.precio_lista is not null or tmp.precio_lista <> '') and (tmp.precio_lista <> a.precio_lista) then tmp.precio_lista
			else  a.precio_lista
		end precio_lista,
		a.id_articulo
	from
		#tmp_lista_precios_proveedor tmp (nolock)
		inner join articulo a (nolock) on a.codigo_articulo = tmp.codigo_articulo
		inner join familia f (nolock) on f.id_tabla_familia = a.id_tabla_familia
		inner join marca m (nolock) on m.id_tabla_marca  = f.id_tabla_marca
		inner join proveedor p (nolock) on p.id_proveedor = m.id_proveedor
	where
		p.id_proveedor = @id_proveedor
		and tmp.codigo_articulo is not null and tmp.codigo_articulo <> ''
		and a.fec_baja is null --articulo activo
end

if(@busqueda = 2) --BUSCO LOS ARTICULOS ACTIVOS INEXISTENTES EN LA BASE DE DATOS EN RELACION A LA TABLA #tmp_lista_precios_proveedor
begin
	select 
		tmp.*,
		'' id_tabla_familia,
		0 id_articulo
	from
		#tmp_lista_precios_proveedor tmp (nolock)
		left join articulo a (nolock) on a.codigo_articulo = tmp.codigo_articulo
		left join familia f (nolock) on f.id_tabla_familia = a.id_tabla_familia
		left join marca m (nolock) on m.id_tabla_marca  = f.id_tabla_marca
		left join proveedor p (nolock) on p.id_proveedor = m.id_proveedor and p.id_proveedor = @id_proveedor
	where
		p.id_proveedor is null  
		and tmp.codigo_articulo is not null and tmp.codigo_articulo <> ''
		and tmp.descripcion_articulo is not null and tmp.descripcion_articulo <> ''
		and tmp.precio_lista is not null and tmp.precio_lista <> ''
		and a.fec_baja is null --articulo activo
end
if(@busqueda = 3) --BUSCO LOS DATOS CON ALGUN PROBLEMA
begin
	select 
		tmp.*,
		'una o varias celdas de la fila estan vacias' error
	from
		#tmp_lista_precios_proveedor tmp (nolock)
	where
		tmp.codigo_articulo is null or tmp.codigo_articulo = ''
		or tmp.descripcion_articulo is null or tmp.descripcion_articulo = ''
		or tmp.precio_lista is  null or tmp.precio_lista = ''
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_articulos_por_codigo_articulo_marca_y_codigo_articulo]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [buscar_articulos_por_codigo_articulo_marca_y_codigo_articulo] 'GENOUD','4050'
CREATE procedure [dbo].[buscar_articulos_por_codigo_articulo_marca_y_codigo_articulo]
(
	@codigo_articulo_marca nvarchar(100),
	@codigo_articulo nvarchar(100)
)

as

select top 1
	descripcion_articulo,
	precio_lista,
	id_tabla_familia,
	a.id_articulo,
	dbo.[Calcular_Coeficiente_Familia] (a.id_tabla_familia) coeficiente
from
	articulo a (nolock)
where
	codigo_articulo_marca = @codigo_articulo_marca
	and codigo_articulo = @codigo_articulo
	and a.fec_baja is null --articulos activos
GO
/****** Object:  StoredProcedure [dbo].[buscar_articulos_por_idProveedor_idTablaMarca_idTablaFamilia_codArticulo_descripcionArticulo]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [buscar_articulos_por_idProveedor_idTablaMarca_idTablaFamilia_codArticulo_descripcionArticulo] 1,-999,-999,'',''
CREATE procedure [dbo].[buscar_articulos_por_idProveedor_idTablaMarca_idTablaFamilia_codArticulo_descripcionArticulo]
(
	@id_proveedor int,
	@id_tabla_marca int,
	@id_tabla_familia int,
	@cod_articulo nvarchar(100),
	@descripcion nvarchar(700)
)

as

select 
	a.id_articulo,
	a.codigo_articulo_marca,
	a.codigo_articulo [Cod Artículo],
	a.descripcion_articulo [Descripcíon Artículo],
	a.precio_lista [Precio Lista],
	dbo.Calcular_Coeficiente_Familia (a.id_tabla_familia) [Coeficiente],
	(a.precio_lista * dbo.Calcular_Coeficiente_Familia (a.id_tabla_familia)) [Precio Final],
    p.razon_social [Proveedor],
    m.txt_desc_marca [Marca],
    f.txt_desc_familia [Familia]
from
	articulo a (nolock)
	inner join familia f (nolock) on f.id_tabla_familia = a.id_tabla_familia
	inner join marca m (nolock) on m.id_tabla_marca = f.id_tabla_marca
	inner join proveedor p (nolock) on p.id_proveedor = m.id_proveedor
	
where
	(p.id_proveedor = @id_proveedor or @id_proveedor = -999)
	and (m.id_tabla_marca = @id_tabla_marca or @id_tabla_marca = -999)
	and (f.id_tabla_familia = @id_tabla_familia or @id_tabla_familia = -999)
	and (a.codigo_articulo like '%' + @cod_articulo + '%' or @cod_articulo = '')
	and (a.descripcion_articulo like '%' + @descripcion + '%' or @descripcion = '')
	and a.fec_baja is null --articulos activo
GO
/****** Object:  StoredProcedure [dbo].[buscar_articulos_todos]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--OJO este store se usa en los proyectos de Modulo_Administracion y ListaX
CREATE procedure [dbo].[buscar_articulos_todos]

as


select
	codigo_articulo_marca,
	codigo_articulo,
	descripcion_articulo,	
	precio_lista,
	dbo.Calcular_Coeficiente_Familia (articulo.id_tabla_familia) coeficiente,
	(precio_lista * dbo.Calcular_Coeficiente_Familia (articulo.id_tabla_familia)) precio_final,
	articulo.id_tabla_familia,	
	sn_oferta,	
	articulo.path_img,	--ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB
	articulo.id_articulo,
	id_orden
from
	articulo (nolock)
	inner join familia (nolock) on articulo.id_tabla_familia = familia.id_tabla_familia
	
where
	fec_baja is null --articulos activos
order by
	id_orden asc
GO
/****** Object:  StoredProcedure [dbo].[buscar_calle]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[buscar_calle]
@txt_desc as varchar(60)
as
begin
		select 
			cod_calle as Codigo_calle,
			txt_desc as Calle 
		from 
			tcalle  (nolock)
		where
			txt_desc like '%' + @txt_desc + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_cliente]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[buscar_cliente]
	@nombre as varchar(60)
as
begin
		select 
			id_cliente as [Codigo Cliente],
			nombre_fantasia as [Nombre],
			id_condicion_factura [Id Condicion Factura]
		from 
			cliente (nolock)
		where
			nombre_fantasia like '%' + @nombre + '%'
			and accion <> 'ELIMINACION'
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_cuenta_corriente_por_id_cliente]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [buscar_cuenta_corriente_por_id_cliente] 14,2
CREATE procedure [dbo].[buscar_cuenta_corriente_por_id_cliente]
(
	@id_cliente int,
	@tipo int --si es 1 muestro solamente las boletas que tienen deuda , si es 2 muestro todo lo de ese cliente
)

as

    
select 
	s1.[Id],
	s1.[Id_factura],
	s1.[Fecha],
	s1.[Tipo Factura],
	s1.[Nro Factura],
	s1.[Imp Factura],
	s1.[Pago 1],
	s1.[Fecha Pago 1],
	s1.[Pago 2],
	s1.[Fecha Pago 2],
	s1.[Pago 3],
	s1.[Fecha Pago 3],
	s1.[Pago 4],
	s1.[Fecha Pago 4],
	s1.[Saldo],
	SUM(+isnull(ccc.imp_factura,0) - isnull(ccc.pago_1,0) - isnull(ccc.pago_2,0) - isnull(ccc.pago_3,0) - isnull(ccc.pago_4,0)) [S.Acum],  
	s1.[Condicion Factura],
	s1.[Observacion Factura],
	s1.[Observacion Movimiento Cta Cte]
from
(
	select 
		ccc.id_cliente_cuenta_corriente Id,
		ccc.id_factura Id_factura,
		f.fecha [Fecha],
		ttf.txt_desc [Tipo Factura],
		f.nro_factura [Nro Factura],
		ccc.imp_factura [Imp Factura],
		ccc.pago_1 [Pago 1],
		ccc.pago_1_fecha [Fecha Pago 1],
		ccc.pago_2 [Pago 2],
		ccc.pago_2_fecha [Fecha Pago 2],
		ccc.pago_3 [Pago 3],
		ccc.pago_3_fecha [Fecha Pago 3],
		ccc.pago_4 [Pago 4],
		ccc.pago_4_fecha [Fecha Pago 4],
		+isnull(ccc.imp_factura,0) - isnull(ccc.pago_1,0) - isnull(ccc.pago_2,0) - isnull(ccc.pago_3,0) - isnull(ccc.pago_4,0)[Saldo],
		isnull(ttcf.txt_desc,'') [Condicion Factura],
		f.observacion [Observacion Factura],
		ccc.observacion [Observacion Movimiento Cta Cte],
		ccc.id_cliente
	from	
		cliente_cuenta_corriente ccc (nolock)
		inner join cliente c (nolock) on c.id_cliente = ccc.id_cliente
		inner join factura f (nolock) on f.id_factura = ccc.id_factura
		inner join ttipo_factura ttf (nolock) on ttf.cod_tipo_factura = f.cod_tipo_factura
		left join ttipo_condicion_factura ttcf on ttcf.id_condicion_factura = f.id_condicion_factura
	where
		f.sn_emitida = -1 --que este emitida
		and ccc.id_cliente = @id_cliente
		and ((isnull(imp_factura,0) - isnull(pago_1,0) - isnull(pago_2,0) - isnull(pago_3,0) - isnull(pago_4,0) > 0 and @tipo = 1) or (@tipo = 2))

	union all


	select 
		ccc.id_cliente_cuenta_corriente Id,
		ccc.id_factura Id_factura,
		ccc.fecha_factura_vieja [Fecha],
		ttf.txt_desc [Tipo Factura],
		ccc.nro_factura_vieja [Nro Factura],
		ccc.imp_factura [Imp Factura],
		ccc.pago_1 [Pago 1],
		ccc.pago_1_fecha [Fecha Pago 1],
		ccc.pago_2 [Pago 2],
		ccc.pago_2_fecha [Fecha Pago 2],
		ccc.pago_3 [Pago 3],
		ccc.pago_3_fecha [Fecha Pago 3],
		ccc.pago_4 [Pago 4],
		ccc.pago_4_fecha [Fecha Pago 4],     
		+isnull(ccc.imp_factura,0) - isnull(ccc.pago_1,0) - isnull(ccc.pago_2,0) - isnull(ccc.pago_3,0) - isnull(ccc.pago_4,0)[Saldo],
		'' [Condicion Factura],
		'' [Observacion Factura],
		ccc.observacion [Observacion Movimiento Cta Cte],
		ccc.id_cliente
	from	
		cliente_cuenta_corriente ccc (nolock)
		inner join cliente c (nolock) on c.id_cliente = ccc.id_cliente
		inner join ttipo_factura ttf (nolock) on ttf.cod_tipo_factura = ccc.cod_tipo_factura_vieja

	where
		ccc.id_cliente = @id_cliente
		and ((isnull(imp_factura,0) - isnull(pago_1,0) - isnull(pago_2,0) - isnull(pago_3,0) - isnull(pago_4,0) > 0 and @tipo = 1) or (@tipo = 2))
) as s1
inner join cliente_cuenta_corriente ccc on 
											ccc.id_cliente = s1.id_cliente
											and ccc.id_cliente_cuenta_corriente <= s1.id
											and ((isnull(ccc.imp_factura,0) - isnull(ccc.pago_1,0) - isnull(ccc.pago_2,0) - isnull(ccc.pago_3,0) - isnull(ccc.pago_4,0) > 0 and @tipo = 1) or (@tipo = 2))	
group by
	s1.[Id],
	s1.[Id_factura],
	s1.[Fecha],
	s1.[Tipo Factura],
	s1.[Nro Factura],
	s1.[Imp Factura],
	s1.[Pago 1],
	s1.[Fecha Pago 1],
	s1.[Pago 2],
	s1.[Fecha Pago 2],
	s1.[Pago 3],
	s1.[Fecha Pago 3],
	s1.[Pago 4],
	s1.[Fecha Pago 4],   
	s1.[Saldo],
	s1.[Condicion Factura],
	s1.[Observacion Factura],
	s1.[Observacion Movimiento Cta Cte]
order by 
	s1.[Fecha],
	s1.[Nro Factura] asc
GO
/****** Object:  StoredProcedure [dbo].[buscar_factura_por_nro_tipo_cliente]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[buscar_factura_por_nro_tipo_cliente]
(
		@nro_factura bigint,
		@cod_tipo_factura numeric(2, 0)
)

as

select
	count(*)
from
	cliente_cuenta_corriente ccc
	left join factura f on f.id_factura = ccc.id_factura
where
	(nro_factura_vieja = @nro_factura and cod_tipo_factura_vieja = @cod_tipo_factura)  
	or (f.nro_factura = @nro_factura and cod_tipo_factura = @cod_tipo_factura)
GO
/****** Object:  StoredProcedure [dbo].[buscar_municipio]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [buscarMunicipio] 1,1,'capital'
CREATE      procedure [dbo].[buscar_municipio]
	@Cod_Pais 	as int,
	@Cod_Provincia 	as int,
	@Municipio 	as varchar (80)

as
begin
	select 
		distinct 
		tm.cod_municipio, 
		tm.txt_desc as Municipio,
		tm.cod_divipola as Codigo_Postal
	From  
		tmunicipio as tm (nolock)	 	
	where
		tm.cod_pais = @Cod_Pais
		and tm.cod_provincia = @Cod_Provincia
		and tm.txt_desc like '%' + @Municipio + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_pais]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[buscar_pais]
@txt_desc as varchar(60)
as
begin
		select cod_pais as Codigo_Pais,
			txt_desc as Pais 
		from tpais  (nolock)
		where
		txt_desc like @txt_desc + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_provincia]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [buscarProvincia] 1,'cordo'
CREATE     procedure [dbo].[buscar_provincia]
	@Cod_Pais	int,
	@Provincia 	as varchar (80)

as
begin
	select 
		cod_provincia, 
		tp.txt_desc as Provincia
		
	from 
		tprovincia as tp (nolock)		
	where
		tp.Cod_pais = @Cod_Pais
		and tp.txt_desc like @Provincia + '%'

end
GO
/****** Object:  StoredProcedure [dbo].[buscar_registros_hoja_Articulo_ListaX]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_registros_hoja_Articulo_ListaX]


AS

select 
  codigo_articulo_marca,
  codigo_articulo,
  descripcion_articulo,
  precio_lista,
  dbo.Calcular_Coeficiente_Familia (a.id_tabla_familia) coeficiente,
  (precio_lista * dbo.Calcular_Coeficiente_Familia (a.id_tabla_familia)) precio_final,
  a.id_tabla_familia id_tabla_familia,
  ISNULL(sn_oferta,0) sn_oferta,
  isnull(a.path_img,'') path_img, --ESTE DATO SOLAMENTE EXISTE EN LA BD DE LA WEB
  a.id_articulo,
  stock,
  id_orden
 from 
  articulo a 
  inner join familia f on f.id_tabla_familia = a.id_tabla_familia

 where 
  fec_baja is null
order by
  id_orden asc
GO
/****** Object:  StoredProcedure [dbo].[buscar_registros_hoja_Familia_ListaX]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_registros_hoja_Familia_ListaX]


AS

select 
	id_tabla_familia,
	id_tabla_marca,
	txt_desc_familia,
	id_familia 
from 
	familia 
where 
	sn_activo = -1 
order by 
	txt_desc_familia
GO
/****** Object:  StoredProcedure [dbo].[buscar_registros_hoja_Marca_ListaX]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_registros_hoja_Marca_ListaX]


AS

select 
	id_tabla_marca,
	id_proveedor,
	txt_desc_marca,
	id_marca 
from  
	marca 
where 
	sn_activo = -1 
order by 
	txt_desc_marca
GO
/****** Object:  StoredProcedure [dbo].[buscar_registros_hoja_Proveedor_ListaX]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscar_registros_hoja_Proveedor_ListaX]


AS

select 
	id_proveedor,
	razon_social 
from 
	proveedor 
where 
	sn_activo = -1 
order by 
	razon_social
GO
/****** Object:  StoredProcedure [dbo].[buscar_tipo_dato]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[buscar_tipo_dato]
as

	select cod_tipo_dato, txt_desc from ttipo_dato (nolock)
GO
/****** Object:  StoredProcedure [dbo].[buscar_tipo_telefono]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[buscar_tipo_telefono]
as

	select cod_tipo_telef, txt_desc from ttipo_telef (nolock)
GO
/****** Object:  StoredProcedure [dbo].[cargar_combo_box]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create         proc [dbo].[cargar_combo_box]
(    
	@Tabla		VARCHAR(100),
	@Where		VARCHAR(200),
	@OrderBy	VARCHAR(100)
)
as

set nocount on

BEGIN
	exec ('Select * From ' + @Tabla + ' WHERE ' + @WHERE + ' Order by ' + @OrderBy )
end

return 0
GO
/****** Object:  StoredProcedure [dbo].[delete_factura]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[delete_factura]
(
	@id_factura int
)

as

delete from factura_detalle where id_factura = @id_factura
delete from cliente_cuenta_corriente where id_factura = @id_factura
delete from factura where id_factura = @id_factura
GO
/****** Object:  StoredProcedure [dbo].[imprimir_factura]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [imprimir_factura] 2 
CREATE procedure [dbo].[imprimir_factura]
(
	@id_factura int
)

as

select
	(select nombre_fantasia from empresa where id_empresa = 1) empresa_nombre_fantasia,
	(select direccion from empresa where id_empresa = 1) empresa_direccion,
	(select 'Tel : ' + telefono from empresa where id_empresa = 1) empresa_telefono,
	(select  email from empresa where id_empresa = 1) empresa_email,
	cliente.nombre_fantasia cliente_nombre_fantasia,
	ttipo_factura.letra +  REPLICATE('0',7-LEN(factura.nro_factura)) +  CAST(factura.nro_factura as varchar(max)) factura_nro,
	factura.fecha factura_fecha,
	factura.observacion,
	precio_final,
	factura.precio_final_con_pago_mayor_a_30_dias factura_precio_final_con_pago_mayor_a_30_dias,
	factura.precio_final_con_pago_menor_a_30_dias factura_precio_final_con_pago_menor_a_30_dias,
	factura.precio_final_con_pago_menor_a_7_dias factura_precio_final_con_pago_menor_a_7_dias,
	ttipo_factura.txt_desc factura_tipo,
	cliente.razon_social cliente_razon_social,
	cliente_dir.txt_direccion + ' ' + cliente_dir.txt_numero + ',' + tmunicipio.txt_desc cliente_direccion,
	(select txt_dato_cliente from cliente_datos where id_cliente = cliente.id_cliente and cod_tipo_dato = 4) cliente_telefono,
	(select txt_dato_cliente from cliente_datos where id_cliente = cliente.id_cliente and cod_tipo_dato = 12) cliente_cuit,
	cantidad detalle_cantidad, 
	factura_detalle.codigo_articulo_marca detalle_marca,
	factura_detalle.codigo_articulo detalle_codigo,
	convert(varchar(45),factura_detalle.descripcion_articulo) detalle_descripcion,
	(
		((factura_detalle.precio_lista_x_coeficiente * iva) / 100) 
		+ factura_detalle.precio_lista_x_coeficiente
	) detalle_precio,
   (
		(
			((factura_detalle.precio_lista_x_coeficiente * iva) / 100) 
			+ factura_detalle.precio_lista_x_coeficiente
		)
		* cantidad
	) detalle_importe,
	sn_mostrar_pago_mayor_30_dias,
	sn_mostrar_pago_menor_7_dias,
	sn_mostrar_pago_menor_30_dias
	
from
	factura (nolock)
	inner join ttipo_factura (nolock) on factura.cod_tipo_factura = ttipo_factura.cod_tipo_factura
	inner join cliente (nolock) on cliente.id_cliente = factura.id_cliente
	left join cliente_dir (nolock) on cliente_dir.id_cliente = factura.id_cliente
	left join tmunicipio (nolock) on tmunicipio.cod_pais = cliente_dir.cod_pais and tmunicipio.cod_provincia = cliente_dir.cod_provincia and tmunicipio.cod_municipio = cliente_dir.cod_municipio 
	inner join factura_detalle (nolock) on factura_detalle.id_factura = factura.id_factura
where
	factura_detalle.id_factura = @id_factura
	and factura_detalle.fec_baja is null
order by
	id_factura_detalle asc
GO
/****** Object:  StoredProcedure [dbo].[nro_facturas_diferenciadas_por_nuevas_y_viejas]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[nro_facturas_diferenciadas_por_nuevas_y_viejas]

as


SELECT
	*
FROM
(
select 
	nro_factura_vieja nro_factura_original ,
	convert(nvarchar,nro_factura_vieja + '-' + cod_tipo_factura_vieja) nro_factura,
	'SI' Es_factura_vieja
from 
	cliente_cuenta_corriente 
where 
	nro_factura_vieja is not null

union all

select
	nro_factura nro_factura_original,
	convert(nvarchar,nro_factura) nro_factura,
	'NO' Es_factura_vieja
from
	factura
) AS nro_factura
order by nro_factura_original desc
GO
/****** Object:  StoredProcedure [dbo].[ult_nro_factura_no_usado_en_tipo_factura]    Script Date: 20/06/2022 03:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from ttipo_factura
-- ult_nro_factura_no_usado_en_tipo_factura 7
CREATE PROCEDURE [dbo].[ult_nro_factura_no_usado_en_tipo_factura]
(
	@cod_tipo_factura numeric(2, 0)
)

as


DECLARE @NumeroInicial int;
DECLARE @NumeroFinal int;



SELECT 
	@NumeroInicial = MIN(nro_factura),
	@NumeroFinal = MAX(nro_factura) + 1
FROM 
	factura 
where cod_tipo_factura = @cod_tipo_factura;



WITH Secuencia AS
(
    SELECT @NumeroInicial AS [Numero]
    UNION ALL
    SELECT Numero + 1 FROM Secuencia WHERE Numero < @NumeroFinal
)

SELECT TOP 1
    ISNULL(s.Numero,1)
FROM
    Secuencia s
WHERE
    NOT EXISTS (SELECT 1 FROM factura WHERE (nro_factura = s.Numero) AND cod_tipo_factura = @cod_tipo_factura)
order by 
	s.Numero asc

OPTION(MAXRECURSION 0)
GO
