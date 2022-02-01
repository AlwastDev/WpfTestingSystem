using Microsoft.AspNetCore.Mvc;
using MethodsDataBaseLibrary;
using DataBaseLibrary.Models;
namespace TestingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly CrudOperation _crudOperation;
        public TestController(CrudOperation crud)
        {
            _crudOperation = crud;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var test = await _crudOperation.SelectOperationTestByIdAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            return new ObjectResult(test);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> Get()
        {
            return new ActionResult<IEnumerable<Test>>(await _crudOperation.SelectOperationTestAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Test? test)
        {
            if (test == null)
            {
                return BadRequest();
            }
            await _crudOperation.InsertOperationTestAsync(test);
            return Ok(test);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Test? test)
        {
            var testUpdate = await _crudOperation.UpdateOperationTestAsync(test);
            if (test == null)
            {
                return BadRequest();
            }
            if (testUpdate == null)
            {
                return NotFound();
            }
            return Ok(test);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var test = await _crudOperation.SelectOperationTestByIdAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            await _crudOperation.DeleteOperationTestAsync(id);
            return Ok(test);
        }
    }
}

