using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SitorApi.Core;
using SitorApi.Core.Database;
using SitorApi.Security;
using SitorApi.Services.ApiServices.Classes;
using SitorApi.Services.ApiServices.Interfaces;
using SitorApi.Services.DbServices.Classes;
using SitorApi.Services.DbServices.Interfaces;


namespace SitorApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var database = new Database();
            database.Initialize();
            services.AddSingleton<IDatabase>(database);

            //DbConnections
            var connectionString = Configuration.GetConnectionString("SitorDbContext");
            services.AddDbContext<SitorDbContext>(options => { options.UseSqlServer(connectionString);
            });

            
            //Services for db 
            services.AddScoped<IBackgroundService, Services.DbServices.Classes.BackgroundService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IEffectService, EffectService>();
            services.AddScoped<IEffectlistService, EffectListService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryItemsService, InventoryItemsService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IRewardService, RewardService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IStageService, StageService>();
            services.AddScoped<IStatsService, StatsService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ITypeService, TypeService>();

            //Services for Api
            services.AddScoped<IBackgroundApiService, BackgroundApiService>();
            services.AddScoped<ICategoryApiService, CategoryApiService>();
            services.AddScoped<ICategoryTypeApiService, CategoryTypeApiService>();
            services.AddScoped<ICharacterApiService, CharacterApiService>();
            services.AddScoped<IEffectApiService, EffectApiService>();
            services.AddScoped<IEffectlistApiService, EffectlistApiService>();
            services.AddScoped<IEquipmentApiService, EquipmentApiService>();
            services.AddScoped<IEquipmentItemsApiService, EquipmentItemsApiService>();
            services.AddScoped<IInventoryApiService, InventoryApiService>();
            services.AddScoped<IInventoryItemsApiService, InventoryItemsApiService>();
            services.AddScoped<IItemApiService, ItemApiService>();
            services.AddScoped<IPlayerApiService, PlayerApiService>();
            services.AddScoped<IRewardApiService, RewardApiService>();
            services.AddScoped<IShopApiService, ShopApiService>();
            services.AddScoped<IStageApiService, StageApiService>();
            services.AddScoped<IStatsApiService, StatsApiService>();
            services.AddScoped<IStockApiService, StockApiService>();
            services.AddScoped<ITypeApiService, TypeApiService>();
            services.AddScoped<ITypeItemApiService, TypeItemApiService>();

            //add swagger
            services.AddSwaggerGen();

            //Security
            const string key = "This is my test key";
            var jwtSettings = new JwtAuthenticationManager(key);
            services.AddSingleton<IJwtAuthenticationManger>(jwtSettings);
            //Configuration.Bind(nameof(jwtSettings), jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;

                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                }
            );

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseCors(cors => cors
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
