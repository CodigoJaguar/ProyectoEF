# ProyectoEF
 
 ## Database
 **This proyect creates and connects an sqlite file when running named "mydatabase.db" and you'd be able to store information there
 
 ## Models
 * **Categorias
 * **Tareas

## How to handle the requests
**GET    to_http://localhost:port/api/tareas 
***you will receive a Json file with all information set by default from the API (2 objects "Tareas")
[
	{
		"tareaId": "cfbe8bcb-d964-4c0e-a214-3af988c878b2",
		"categoriaId": "cfbe8bcb-d964-4c0e-a214-3af988c8781d",
		"titulo": "Pago de servicios públicos",
		"descripcion": null,
		"prioridadTarea": 1,
		"fechaCreacion": "2023-04-11T16:40:42.110617",
		"categoria": null,
		"resumen": null
	},
	{
		"tareaId": "fe2de405-c38e-4c90-ac52-da0540dfb411",
		"categoriaId": "fe2de405-c38e-4c90-ac52-da0540dfb402",
		"titulo": "Terminar de ver pelicula en netflix",
		"descripcion": null,
		"prioridadTarea": 0,
		"fechaCreacion": "2023-04-11T16:40:42.1106198",
		"categoria": null,
		"resumen": null
	},
	{
		"tareaId": "400dfebd-6632-43d7-916c-9bb1bdff2776",
		"categoriaId": "fe2de405-c38e-4c90-ac52-da0540dfb402",
		"titulo": "Visitar a mi tia",
		"descripcion": null,
		"prioridadTarea": 2,
		"fechaCreacion": "2023-04-11T17:05:17.329566",
		"categoria": null,
		"resumen": null
	}
]
**POST    to_http://localhost:port/api/tareas 
***you will be able to add in your data base another "tarea" using Json data like following the example below:
{
		"categoriaId": "fe2de405-c38e-4c90-ac52-da0540dfb402",
		"titulo": "Default Title",
		"descripcion": null,
		"prioridadTarea": 2
	}
  
**PUT    to_http://localhost:port/api/tareas 
***you will be able to update using string ids "tarea" and using Json data like following the example below:
{
		"categoriaId": "fe2de405-c38e-4c90-ac52-da0540dfb402",
		"titulo": "Terminar de ver pelicula en netflix",
		"descripcion": "Debo de seguir estudiando y terminando cursos alv",
		"prioridadTarea": 1,
		"fechaCreacion": "2023-04-11T16:40:42.1106198"
	}
  
**DELETE    to_http://localhost:port/api/tareas/fe2de405-c38e-4c90-ac52-da0540dfb402
***you will be able to delete any "tarea" using the string id on the parameters like the path above:
  
  
  
  

