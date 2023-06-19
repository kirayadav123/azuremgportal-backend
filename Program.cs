using ctrlspec;

using ctrlspec.Repository;
using Microsoft.EntityFrameworkCore;
using ctrlspec.Data;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ctrlspec.Repository.ILogin;
using ctrlspec.Repos;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.




builder.Services.AddControllers();

builder.Services.AddDbContext<CtrlSpecDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<ILogin, LoginRepository>();
builder.Services.AddScoped<IClient, ClientRepository>();
builder.Services.AddScoped<IAdmin, AdminRepository>();
builder.Services.AddScoped<ITokenHandler, ctrlspec.Repository.TokenHandler>();


//builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

                });
                builder.Services.AddSwaggerGen(options =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter a valid JWT bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { } }
                });
            });
        

builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>




{




 builder.WithOrigins("http://localhost:4200/", "http://localhost:5078/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();




}));




var app = builder.Build();




// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}





app.UseCors("corsapp");


app.UseRouting();

app.UseHttpsRedirection();


          


app.UseAuthorization();

//app.UseEndpoints(endpoints =>

            //{

                // endpoints.MapControllers();

            // });


app.MapControllers();


//app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.Run();