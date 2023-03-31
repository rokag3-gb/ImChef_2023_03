using System.Net;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DNS cache ���� �ֱ�
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
                $"Hello World! {name}. Minimal API�� �̷��� ���°̴ϴ�.\r\n{Secret.conn_str_sqlmi_public_primary}"
            );
            
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            // ���� ȯ���� �ƴϾ Swagger UI ��� (������� ����)
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}