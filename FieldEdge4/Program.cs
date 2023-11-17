var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ConnectionStringsOption>(
    builder.Configuration.GetSection("ConnectionStrings")
);
builder.Services.AddCors((options)=>{
    options.AddPolicy("AllowOrigin", builder =>
            {
               builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            });
});
builder.Services.AddMvc();
builder.Services.AddHttpClient();


var app = builder.Build();
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
app.MapControllerRoute(name:"default",pattern:"{controller}/{action=Index}/{id?}");
// Console.WriteLine("Inside program.cs");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
// app.UseStaticFiles();
app.UseRouting();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller}/{action=Index}/{id?}"
//     );
// app.MapFallbackToFile("index.html");

app.Run();

public class ConnectionStringsOption
{
      public  string ApiUrl {get;set;} = "";
}