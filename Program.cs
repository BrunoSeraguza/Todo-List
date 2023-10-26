using todoList.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//injetando o DBCONTEXT para que possa usar em toda minha aplicação..(sem a necessidade  de ficar usando aquele using )
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
app.MapControllers();

app.Run();
