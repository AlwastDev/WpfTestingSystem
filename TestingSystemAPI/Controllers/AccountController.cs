using Microsoft.AspNetCore.Mvc;
using MethodsDataBaseLibrary;
using DataBaseLibrary.Models;

namespace TestingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly CrudOperation _crudOperation;
        public AccountController(CrudOperation crud)
        {
            _crudOperation = crud;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var account = await _crudOperation.SelectOperationAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return new ObjectResult(account);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> Get()
        {
            return new ActionResult<IEnumerable<Account>>(await _crudOperation.SelectOperationAccountAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Account? account)
        {
            await _crudOperation.InsertOperationAccountAsync(account);
            return Ok(account);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Account? account)
        {
            var accountUpdate = await _crudOperation.UpdateOperationAccountAsync(account);
            if (accountUpdate == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _crudOperation.SelectOperationAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            await _crudOperation.DeleteOperationAccountAsync(id);
            return Ok(account);
        }
    }
}
