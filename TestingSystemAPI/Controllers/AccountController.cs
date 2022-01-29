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
        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger)
        {
            _crudOperation = new CrudOperation();
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Account>> Get()
        {
            return await _crudOperation.SelectOperationAccountAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> Get(int id)
        {
            Account account = await _crudOperation.SelectOperationAccountIDApiAsync(id);
            if (account == null)
                return NotFound();
            return new ObjectResult(account);
        }
        [HttpPost]
        public async Task<ActionResult<Account>> Post(Account? account)
        {
            if (account == null)
            {
                return BadRequest();
            }

            await _crudOperation.InsertOperationAccountApiAsync(account);
            return Ok(account);
        }

        [HttpPut]
        public async Task<ActionResult<Account>> Put(Account? account)
        {
            if (account == null)
            {
                return BadRequest();
            }
            if (!await _crudOperation.IsIdAccount(account))
            {
                return NotFound();
            }
            await _crudOperation.UpdateOperationAccountApiAsync(account);
            return Ok(account);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> Delete(int id)
        {
            Account account = await _crudOperation.SelectOperationAccountIDApiAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            await _crudOperation.DeleteOperationAccountAsync(id);
            return Ok(account);
        }
    }
}
