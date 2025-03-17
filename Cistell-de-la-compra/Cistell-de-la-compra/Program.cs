using Cistell_de_la_compra.Repository;
using Cistell_de_la_compra.Repository.interfaces;

namespace Cistell_de_la_compra
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configuración para habilitar sesiones
            builder.Services.AddDistributedMemoryCache(); // Cache per la sessio
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // la sessio dura 30min
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddTransient<IUsuarisRepository, UsuarisRepository>();
            builder.Services.AddTransient<IProductesRepository, ProductesRepository>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            // Habilitar el middleware de sesión
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
