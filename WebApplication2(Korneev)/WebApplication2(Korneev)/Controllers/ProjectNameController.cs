using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectNameController : ControllerBase
    {
        // Списки приставок, корней и суффиксов
        private static readonly string[] prefixes = { "Neo", "Inno", "Tech", "Pro", "Eco", "Meta", "Hyper", "Aero" };
        private static readonly string[] roots = { "gen", "form", "lab", "sys", "path", "node", "flow", "graph", "net" };
        private static readonly string[] suffixes = { "ify", "ium", "or", "ex", "ix", "a", "is", "os", "al" };

        /// <summary>
        /// Генерация осмысленных названий для проектов.
        /// </summary>
        /// <param name="quantity">Количество названий.</param>
        /// <returns>Список уникальных названий.</returns>
        [HttpGet("GenerateNames")]
        public ActionResult<IEnumerable<string>> GenerateNames(int quantity = 5)
        {
            if (quantity < 1)
            {
                return BadRequest("Quantity must be at least 1.");
            }

            List<string> projectNames = new List<string>();
            Random rand = new Random();

            while (projectNames.Count < quantity)
            {
                // Формируем название из приставки, корня и суффикса
                string prefix = prefixes[rand.Next(prefixes.Length)];
                string root = roots[rand.Next(roots.Length)];
                string suffix = suffixes[rand.Next(suffixes.Length)];

                string projectName = prefix + root + suffix;

                // Убираем дубликаты
                if (!projectNames.Contains(projectName))
                {
                    projectNames.Add(projectName);
                }
            }

            return Ok(projectNames);
        }
    }
}
