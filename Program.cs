using System.Net;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DNS cache 갱신 주기
            ServicePointManager.DnsRefreshTimeout = 0;

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<DapperContext>();
            builder.WebHost.ConfigureKestrel(opt => {
                opt.ListenAnyIP(5000);
            });
            
            var app = builder.Build();
            
            // Minimal API test
            app.MapGet("/HelloWorld", (string name) =>
                $"Hello World! {name}. Minimal API는 이렇게 쓰는겁니다.\r\n{Secret.conn_str_sqlmi_public_primary}"
            );
            
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            // 개발 환경이 아니어도 Swagger UI 사용 (권장되지 않음)
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}