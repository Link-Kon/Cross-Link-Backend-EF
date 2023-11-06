using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Domain.Services.Communication.List;
using Link_Backend_EF.Persistence.Context;
using Link_Backend_EF.Persistence.Repositories;
using Link_Backend_EF.Resources;
using Link_Backend_EF.Services;
using Link_Backend_EF.Services.Base;
using Link_Backend_Google_Services.PushNotifications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Repositories init
builder.Services.AddScoped<IFriendshipRepository, FriendshipRepository>();
builder.Services.AddScoped<IHealthRecordRepository<FallRecord>, FallRecordRepository>();
builder.Services.AddScoped<IHealthRecordRepository<HeartIssuesRecord>, HeartIssuesRecordRepository>();
builder.Services.AddScoped<IHealthRecordRepository<HeartRhythmRecord>, HeartRhythmRecordRepository>();
builder.Services.AddScoped<IUserInfoRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDataRepository, UserDataRepository>();
builder.Services.AddScoped<IUserInfoRepository<UserData>, UserDataRepository>();
builder.Services.AddScoped<IUserInfoRepository<Patient>, PatientRepository>();
builder.Services.AddScoped<IUserInfoRepository<Device>, DeviceRepository>();
builder.Services.AddScoped<IIllnessRepository, IllnessRepository>();
builder.Services.AddScoped<IListRelationRepository<IllnessesList>, IllnessesListRepository>();
builder.Services.AddScoped<IListRelationRepository<UserDevice>, UserDeviceRepository>();

// Services init
builder.Services.AddScoped<IFriendshipService, FriendshipService>();
builder.Services.AddScoped<IHealthRecordService<FallRecord, FallRecordResponse>, FallRecordService>();
builder.Services.AddScoped<IHealthRecordService<HeartIssuesRecord, HeartIssuesRecordResponse>, HeartIssuesRecordService>();
builder.Services.AddScoped<IHealthRecordService<HeartRhythmRecord, HeartRhythmRecordResponse>, HeartRhythmRecordService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDataService, UserDataService>();
builder.Services.AddScoped<IUserInfoService<User,UserResponse>, UserService>();
builder.Services.AddScoped<IUserInfoService<UserData, UserDataResponse>, UserDataService>();
builder.Services.AddScoped<IUserInfoService<Patient, PatientResponse>, PatientService>();
builder.Services.AddScoped<IUserInfoService<Device, DeviceResponse>, DeviceService>();
builder.Services.AddScoped<IIllnessService, IllnessService>();
builder.Services.AddScoped<IListRelationService<IllnessesList, IllnessesListResponse, IllnessesListListResponse>, IllnessesListService>();
builder.Services.AddScoped<IListRelationService<UserDevice, UserDeviceResponse, UserDeviceListResponse>, UserDeviceService>();

builder.Services.AddScoped<BasePuhNotification>();
builder.Services.AddScoped<ExtrasService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpClient();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Token authentication view
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cross Link Rest API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

try
{
    FirebaseApp.Create(new AppOptions
    {
        Credential = GoogleCredential.FromFile("cross-link-firebase-token.json"),
    });

    // Firebase SDK initialization successful
    // Proceed with your Firebase operations here
}
catch (Exception ex)
{
    // Firebase SDK initialization failed
    // Handle the exception or log an error message
    Console.WriteLine("Firebase initialization error: " + ex.Message);
}

// Authentication init service
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
