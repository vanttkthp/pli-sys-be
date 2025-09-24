using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PLI.System.API.Common;
using PLI.System.API.Data;
using PLI.System.API.Extensions;
using PLI.System.API.Middlewares;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Add caching services
builder.Services.AddMemoryCache();

// Register ILogger service
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSeq(builder.Configuration.GetSection("SeqConfig"));
});

// Register Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
// Register Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthServices, AuthService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
//builder.Services.RegisterSecurityService(builder.Configuration);
builder.Services.RegisterService();
builder.Services.RegisterMapperService();
builder.Services.AddAuthorization();

// API Versioning
//builder.Services
//    .AddApiVersioning()
//    .AddApiExplorer(options =>
//    {
//        options.GroupNameFormat = "'v'VVV";
//        options.SubstituteApiVersionInUrl = true;
//        options.DefaultApiVersion = new ApiVersion(1, 0);
//    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // FE port
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

// Swagger Settings
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<SwaggerDefaultValues>();

    // Define Bearer token security scheme
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer 12345abcdef'",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    // Add Bearer token as a requirement for all operations
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
//builder.Services.AddIdentity<PLI.System.API.Entities.General.User, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

// Or if you're using IdentityCore:
//builder.Services.AddIdentityCore<PLI.System.API.Entities.General.User>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddScoped<UserManager<PLI.System.API.Entities.General.User>>();
//builder.Services.AddScoped<SignInManager<PLI.System.API.Entities.General.User>>();
// Add API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new QueryStringApiVersionReader("version")
    );
})
.AddApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Database seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelsExpandDepth(-1);
        var descriptions = app.DescribeApiVersions();

        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}
app.UseCors("AllowFrontend");

app.UseStaticFiles();
app.UseRouting(); // Add this line to configure routing

app.UseAuthentication();
app.UseAuthorization();

#region Custom Middleware
app.UseMiddleware<RequestResponseLoggingMiddleware>();

#endregion

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Map your regular API controllers
});

app.Run();
