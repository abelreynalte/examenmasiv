using ExamenMasiv.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using NLog.Config;
using NLog.Common;
using NLog;
using NLog.AWS.Logger;
using ExamenMasiv.AutoMapper;

namespace ExamenMasiv
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
            services.AddDbContext<CodingBlastDbContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("DevConnection"))
                );
            services.AddAutoMapper(typeof(BusinessEntitiesToDataEntitiesMappingProfile).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            ConfigureLogger();
        }
        private void ConfigureLogger()
        {
            var config = new LoggingConfiguration();

            var awsTarget = CreateAwsTarget(Configuration["InformationAWS:LogGroup"],
                                            Configuration["InformationAWS:Region"],
                                            Configuration["InformationAWS:AccessKey"],
                                            Configuration["InformationAWS:SecretKey"]);


            config.AddTarget("AWSTarget", awsTarget);

            config.AddRuleForAllLevels(awsTarget);

            InternalLogger.LogFile = Configuration["Logging:InternalLog"];
            LogManager.Configuration = config;
        }

        private AWSTarget CreateAwsTarget(string logGroup, string region, string accessKey, string secretKey)
        {
            var target = new AWSTarget();
            target.Credentials = new Amazon.Runtime.BasicAWSCredentials(accessKey, secretKey);
            target.LogGroup = logGroup;
            target.Region = region;

            var format = "{ " +
                                 "Id=" + "${event-properties:item=idlog}" + '\'' +
                                 ", LogTimeStamp='" + "${longdate}" + '\'' +
                                 ", MachineName='" + "${aspnet-request-ip}" + '\'' +
                                 ", Level='" + "${level}" + '\'' +
                                 ", Message=" + "${message}" +
                                 ", Exception=" + "${stacktrace}" +
                                 ", Payload='" + "${when:when='${aspnet-request-method}' == 'GET':inner='${aspnet-request-querystring}':else='${aspnet-request-posted-body}'}" + '\'' +
                                 ", CallSite='" + "${aspnet-request-url:IncludePort=true:IncludeQueryString=true}" + '\'' +
                                 ", Action='" + "${aspnet-request-method}" + '\'' +
                                 ", Username='" + "${aspnet-sessionid}" + '\'' +
                                 ", MethodName='" + "${event-properties:item=methodName}" + '\'' +
                                 ", ApplicationName=" + "Test" +
                             " }";

            target.LogStreamNameSuffix = "Demo";
            target.LogStreamNamePrefix = "Logger";
            target.Layout = format;

            return target;
        }
    }
}
