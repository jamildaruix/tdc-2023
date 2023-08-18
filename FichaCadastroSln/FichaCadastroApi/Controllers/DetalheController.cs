using FichaCadastroApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FichaCadastroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalheController : ControllerBase
    {
        /// <summary>
        /// Declaração da ILogger privado e leitura injectado pelo construtor
        /// </summary>
        private readonly ILogger<DetalheController> _logger;


        /// <summary>
        /// Injeção do ILogger como parametro via construtor
        /// </summary>
        /// <param name="logger"></param>
        public DetalheController(ILogger<DetalheController> logger)
        {
            _logger = logger;

        }

    }
}