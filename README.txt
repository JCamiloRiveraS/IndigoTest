__________________________________________________________________________________________________

		
			Presentación prueba técnica Índigo (IndigoTest)

__________________________________________________________________________________________________

Plantilla: ASP.NET Core Web API - Plantilla para una API web RESTfull utilizando controladores ASP.NET Core o API mínimas

Ejecutar:

 Puede probarse por 2 modos, por medio de consola:


GET /api/productos	->Mostrar Productos en memoria

	curl -X 'GET' \
  		'https://localhost:7254/api/productos' \
		  -H 'accept: */*'

--------------------------------------------------------------------------------------------------

POST /api/productos	->Agregar un producto (nombre, descripción y cantidad)

	curl -X 'POST' \
	  'https://localhost:7254/api/productos' \
	  -H 'accept: */*' \
	  -H 'Content-Type: application/json' \
	  -d '{
	  "id": 0,
	  "nombre": "string",
	  "descripcion": "string",
	  "cantidadEnStock": 0
	}'

---------------------------------------------------------------------------------------------------

GET /api/productos/{id}		->Buscar un producto por su id

	curl -X 'GET' \
	  'https://localhost:7254/api/productos/1' \
	  -H 'accept: */*'

---------------------------------------------------------------------------------------------------

POST /api/stock/entrada/{productoId}		->Agregar cantidad de productos en stock	

	curl -X 'POST' \
 	 'https://localhost:7254/api/stock/entrada/1' \
	  -H 'accept: */*' \
	  -H 'Content-Type: application/json' \
	  -d '5'

---------------------------------------------------------------------------------------------------

POST /api/stock/salida/{productoId}		->Sacar o disminuir cantidad de productos en stock

	curl -X 'POST' \
	  'https://localhost:7254/api/stock/salida/1' \
	  -H 'accept: */*' \
	  -H 'Content-Type: application/json' \
 	  -d '3'

---------------------------------------------------------------------------------------------------

o bien, para ejecutar se puede utilizar directamente en el navegador utilizando "Swagger" [7254] para una interfaz grafica del proyecto.

