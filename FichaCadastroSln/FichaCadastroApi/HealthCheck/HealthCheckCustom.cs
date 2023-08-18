using FichaCadastroApi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FichaCadastroApi.HealhCheck
{
    public class HealthCheckCustom : IHealthCheck
    {
        private readonly FichaCadastroDbContext _fichaCadastroDbContext;
        private readonly IWebHostEnvironment _environment;

        public HealthCheckCustom(FichaCadastroDbContext fichaCadastroDbContext, IWebHostEnvironment environment)
        {
            _fichaCadastroDbContext = fichaCadastroDbContext;
            _environment = environment;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            bool comunicaoSQL = false;
            bool healthStatus = false;
            Exception? exMessage = null;

            var objeto = new Dictionary<string, object>()
            {
                { "detalhe_app", new { ambiente = _environment.EnvironmentName } },
                { "ultima_consulta", DateTime.Now }
            };

            try
            {
                var returns = _fichaCadastroDbContext.Database.SqlQueryRaw<int>("SELECT 1 AS HealthCheck").ToList().FirstOrDefault();
                comunicaoSQL = returns == 1;
                var dados = new { intanciaId = _fichaCadastroDbContext.ContextId.InstanceId, sqlSucesso = comunicaoSQL, connectionString = _fichaCadastroDbContext.Database.GetConnectionString() };
                objeto.Add("informacao_db", dados);
                healthStatus = true;
            }
            catch (Exception ex)
            {
                exMessage = ex;
            }
            
            if (healthStatus)
            {
                return await Task.FromResult(HealthCheckResult.Healthy("Tudo certo com a aplicação", data: objeto));
            }

            return await Task.FromResult(HealthCheckResult.Unhealthy("Serviço indisponível.", data: objeto, exception: exMessage));

        }
    }
}
