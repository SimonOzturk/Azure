var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<Microsoft.Data.SqlClient.SqlConnection>(
    new Microsoft.Data.SqlClient.SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2019;Trusted_Connection=True;TrustServerCertificate=false;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;")
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
