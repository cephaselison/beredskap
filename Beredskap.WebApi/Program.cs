using Beredskap.WebApi.Helper;
using Beredskap.WebApi.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "AllowReactApp";


//Calling Helper method to Register services
builder.Services.ConfigureApplicationServices(builder.Configuration);

//Registering the Logger
builder.Logging.ConfigureLogging(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("https://localhost:44418")
                .AllowAnyHeader().AllowAnyMethod();
        });
});

// Start of Configure Services
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
//app.UseMiddleware();
app.MapControllers();
// In production, the React files will be served from this directory

app.Run();
