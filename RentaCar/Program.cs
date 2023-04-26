using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
                 .AddJwtBearer(options =>
                   {
                       options.SaveToken = true;
                       options.RequireHttpsMetadata = false;

                       options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                       {
                           ValidateIssuer = false,
                           ValidateAudience = false,
                           ValidAudience = "https://localhost:5001",
                           ValidIssuer = "https://localhost:5001",

                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RENTACAR2023!!!!"))
                       };
                   });

    builder.Services.AddSwaggerGen(c =>
    {
        // Include 'SecurityScheme' to use JWT Authentication
        var jwtSecurityScheme = new OpenApiSecurityScheme
        {
            BearerFormat = "JWT",
            Name = "JWT Authentication",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };

        c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { jwtSecurityScheme, Array.Empty<string>() }
                    });
    });
      

builder.Services.AddAuthorization(options =>
    {
        // options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("Admin"));
        options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            .Build();

    });

    var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));//


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
builder.Services.AddCors();//

app.UseHttpsRedirection();
    

    app.UseAuthorization();

    app.MapControllers();


    app.Run();


