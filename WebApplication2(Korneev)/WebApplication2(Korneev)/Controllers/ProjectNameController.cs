using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class ProjectNameController : ControllerBase
    {
        private static readonly string[] prefixes = { "Neo", "Inno", "Tech", "Pro", "Eco", "Meta", "Hyper", "Aero" };
        private static readonly string[] roots = { "gen", "form", "lab", "sys", "path", "node", "flow", "graph", "net" };
        private static readonly string[] suffixes = { "ify", "ium", "or", "ex", "ix", "a", "is", "os", "al" };

        /// <summary>
        /// GET-запрос: Генерация осмысленных названий для проектов.
        /// </summary>
        /// <param name="quantity">Количество названий (по умолчанию 5).</param>
        /// <returns>Список уникальных названий.</returns>
        [HttpGet("GenerateNames")]
        public ActionResult<IEnumerable<string>> GenerateNames(int quantity = 5)
        {
            if (quantity < 0) return BadRequest("Quantity must be at least 1.");

            return Ok(GenerateUniqueNames(quantity));
        }

        /// <summary>
        /// POST-запрос: Генерация осмысленных названий для проектов.
        /// </summary>
        /// <param name="request">Объект с количеством названий.</param>
        /// <returns>Список уникальных названий.</returns>
        [HttpPost("GenerateNames")]
        public ActionResult<IEnumerable<string>> GenerateNames([FromBody] GenerateNamesRequest request)
        {
            if (request.Quantity < 0) return BadRequest("Quantity must be at least 1.");

            return Ok(GenerateUniqueNames(request.Quantity));
        }

        /// <summary>
        /// Вспомогательный метод для генерации уникальных названий.
        /// </summary>
        private List<string> GenerateUniqueNames(int quantity)
        {
            List<string> projectNames = new List<string>();
            Random rand = new Random();

            while (projectNames.Count < quantity)
            {
                string projectName = prefixes[rand.Next(prefixes.Length)] +
                                     roots[rand.Next(roots.Length)] +
                                     suffixes[rand.Next(suffixes.Length)];

                if (!projectNames.Contains(projectName))
                {
                    projectNames.Add(projectName);
                }
            }
            return projectNames;
        }
    }

    public class GenerateNamesRequest
    {
        public int Quantity { get; set; }
    }
}
