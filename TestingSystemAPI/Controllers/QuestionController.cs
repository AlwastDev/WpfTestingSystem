using Microsoft.AspNetCore.Mvc;
using DataBaseLibrary.Models;
using MethodsDataBaseLibrary.Interfaces;

namespace TestingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ICrudOperation _crudOperation;
        public QuestionController(ICrudOperation crud)
        {
            _crudOperation = crud;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var question = await _crudOperation.SelectOperationQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return new ObjectResult(question);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            return new ActionResult<IEnumerable<Question>>(await _crudOperation.SelectOperationQuestionAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question? question)
        {
            await _crudOperation.InsertOperationQuestionAsync(question);
            return Ok(question);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Question? question)
        {
            var questionUpdate = await _crudOperation.UpdateOperationQuestionAsync(question);
            if (questionUpdate == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var question = await _crudOperation.SelectOperationQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            await _crudOperation.DeleteOperationQuestionAsync(id);
            return Ok(question);
        }
    }
}

