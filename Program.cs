using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

var builder = WebApplication.CreateBuilder(args);
// Configurar Entity framework  --- antes de build()     Conecta a base de datos en memoria
//builder.Services.AddDbContext<TareasContext>(p=> p.UseInMemoryDatabase("TareasDB"));
//   Conecta a base de datos de SQL Server              Servidor                    Base de datos           usuario         contraseña
//builder.Services.AddSqlServer<TareasContext>("Data Soure=Mysql@localhost:3306; Initial Catalog=TareasDb; user id=root; password=toor");
//                                               builder.Configuration.GetConnectionString("cnTareas")  para sacar la strin de appsettings
// Conecta a sqlite3  y crea base de datos al entrar a /dbconexion
builder.Services.AddDbContext<TareasContext>();


var app = builder.Build();



app.MapGet("/", () => "Hello World!");


app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext)=>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "+ dbContext.Database.CanConnect());
});

// app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext)=>
// {
//     dbContext.Database.EnsureCreated();
//     return Results.Ok("Base de datos en memoria: "+ dbContext.Database.IsInMemory());
// });

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tarea); // Toda la tabla tarea 
    // Consulta como en el ejercicio
    //return Results.Ok(dbContext.Tarea.Include(p => p.Categoria).Where(p=> p.PrioridadTarea == proyectoef.Models.Prioridad.Baja) );
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tarea.AddAsync(tarea);  manera 2
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea,[FromRoute] Guid id)=>
{
    var tareaActual = dbContext.Tarea.Find(id);

    if(tareaActual!=null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();

        return Results.Ok();

    }

    return Results.NotFound();   
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{                             // Nombre tabla (Tarea)
     var tareaActual = dbContext.Tarea.Find(id);

     if(tareaActual!=null)
     {
         dbContext.Remove(tareaActual);
         await dbContext.SaveChangesAsync();

         return Results.Ok();
     }

     return Results.NotFound();
});

app.Run();
