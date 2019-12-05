using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABAssignment3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace DABAssignment3
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
            // requires using Microsoft.Extensions.Options
            //User
            services.Configure<User>(Configuration.GetSection(nameof(User)));
            services.AddSingleton<User>(sp => sp.GetRequiredService<IOptions<User>>().Value);
            services.AddSingleton<UserService>();

            //Post
            services.Configure<Post>(Configuration.GetSection(nameof(Post)));
            services.AddSingleton<Post>(sp => sp.GetRequiredService<IOptions<Post>>().Value);
            services.AddSingleton<PostService>();

            //Circle
            services.Configure<Circle>(Configuration.GetSection(nameof(Circle)));
            services.AddSingleton<Circle>(sp => sp.GetRequiredService<IOptions<Circle>>().Value);
            services.AddSingleton<CircleService>();

            //Comment
            services.Configure<Comment>(Configuration.GetSection(nameof(Comment)));
            services.AddSingleton<Comment>(sp => sp.GetRequiredService<IOptions<Comment>>().Value);
            services.AddSingleton<CommentService>();

            services.AddControllersWithViews().AddNewtonsoftJson(options => options.UseMemberCasing()); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
