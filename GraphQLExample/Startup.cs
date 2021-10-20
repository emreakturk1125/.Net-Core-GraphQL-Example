using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLExample.Data;
using GraphQLExample.GraphQL;
using GraphQLExample.GraphQL.Commands;
using GraphQLExample.GraphQL.Platforms;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GraphQLExample
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
   
        public void ConfigureServices(IServiceCollection services)
        {

             services.AddPooledDbContextFactory<Context>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("CommandConStr")));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddType<PlatformType>()
                .AddType<AddPlatformInputType>()
                .AddType<AddPlatformPayloadType>()
                .AddType<CommandType>()
                .AddType<AddCommandInputType>()
                .AddType<AddCommandPayloadType>()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLExample", Version = "v1" });
            });
        }
 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });
        }
    }
}
