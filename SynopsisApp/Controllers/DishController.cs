using Microsoft.AspNetCore.Mvc;
using SynopsisApp.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SynopsisApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly DishService _dishService;
        private readonly IngredientService _ingredientService;

        public DishController(DishService dishService, IngredientService ingredientService)
        {
            this._dishService = dishService;
            this._ingredientService = ingredientService;
        }

        // GET: api/<DishController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._dishService.GetDishes());
        }

        // GET api/<DishController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredients(int id)
        {
            return Ok(await this._ingredientService.GetIngredientsFromDish(id));
        }

        // POST api/<DishController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DishController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DishController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
