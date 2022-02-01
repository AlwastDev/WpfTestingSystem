using Microsoft.AspNetCore.Mvc;
using MethodsDataBaseLibrary;
using DataBaseLibrary.Models;
namespace TestingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly CrudOperation _crudOperation;
        public AnswerController(CrudOperation crud)
        {
            _crudOperation = crud;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var answer = await _crudOperation.SelectOperationAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            return new ObjectResult(answer);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> Get()
        {
            return new ActionResult<IEnumerable<Answer>>(await _crudOperation.SelectOperationAnswerAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Answer? answer)
        {
            await _crudOperation.InsertOperationAnswerAsync(answer);
            return Ok(answer);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Answer? answer)
        {
            var answerUpdate = await _crudOperation.UpdateOperationAnswerAsync(answer);
            if (answerUpdate == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var answer = await _crudOperation.SelectOperationAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            await _crudOperation.DeleteOperationAnswerAsync(id);
            return Ok(answer);
        }
    }
}

