#region Inbuilt DepencyInjection Conatiner Section(Add services to DI Container)
using DotNetCore8_MiddleWareExample;
using Serilog;
 var builder = WebApplication.CreateBuilder(args);
 // Add services to the container.
  builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISipDashboardService, Sip_DashboardService>();
builder.Services.AddScoped<ISipDashboardRepository, SIP_DashBoardRepository>();
//By using singleton service we can create only one object that object is SqlUserDefinedAggregateAttribute for all the places
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
//without these 2 lines serilog will not work.
var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Serilog-Logs.json")
                .Build();

builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(Configuration));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
#endregion 

#region middlewaresConfigurationSection
var app = builder.Build();
                            //app is requtest pipeline
                          //all middleware we need to configure/register /adding to this request pipeline
                          //whenever if you add any middleware to request pipeleine order wise it will exceute.
                          // middleware naming convention starts with use keyword.                         
                          //we must register the middle wares to reuest pipleline.based on order you register.same order it will excute.
                          //app.Use(async (context, next) => {//app.Use for Inline middlewares
                          //    await context.Response.WriteAsync("Hello I am From use1");
                          //    await next.Invoke();
                          //});
                          //app.Use(async (context, next) => {//app.Use for Inline middlewares
                          //    await context.Response.WriteAsync("Hello I am From use2");
                          //    await next.Invoke();
                          //});
/*
 * synatx:Adds a middleware type to the application request Pipeline.
  app.UseMiddleWare<CustomMiddlewareClassName>();
*/
app.UseMiddleware<ErrorHandlerMiddleware>();//Created Custom Middleware like this way.
//synatx: app.UseMiddleWare<CustomMiddlewareClassName>();we must register like this way.
//<>   we called its as placeholder  .or AngleBracktes
//In that PlaceHolder (<Custommiddlware classname>)Write here
//app.UseMiddleware<RequestLoggingMiddleware>();//Created Custom Middleware like this way.
// Register the middlewares in  HTTP request pipeline.
if (app.Environment.IsDevelopment())
{/*Middlwares are 2 types.
  * 1.Inbuilt Middlewares/Predefined middlewares.
  * 2.custom Middlewares(as per requirment we will write a custom logic in newly created class.)
  * 
  * 
  * 
  */

    app.UseSwagger();//Predefined Middlewares
    app.UseSwaggerUI();
}
app.UseCors();


app.UseAuthorization();

app.MapControllers();

app.Run();//always it should be ending only.
          //After app.run () method if you write any code it will not exceute.because app.run() does not having next.due to that exceution is stopped in this line.
#endregion