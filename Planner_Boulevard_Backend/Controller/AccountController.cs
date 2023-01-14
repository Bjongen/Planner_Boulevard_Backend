using Microsoft.AspNetCore.Mvc;
using Accounts;
using Accounts.Containers;
using Accounts.Interfaces;

namespace Planner_Boulevard_Backend.Controller;

[ApiController]
[Route("[action]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private IAccountContainer _accountContainer = new AccountContainer(new AccountDal());

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    [ActionName("AccountsGet")]
    public List<AccountDto> Get()
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _accountContainer.GetAllAccounts();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }

    [HttpPost]
    [ActionName("AccountPost")]
    public int Post(AccountDto accountDto)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _accountContainer.CreateAccount(accountDto);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return 0;
        }
    }

    [HttpPut]
    [ActionName("AccountPut")]
    public bool Put(AccountDto accountDto)
    {
        try
        {
            _accountContainer.UpdateAccount(accountDto);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }

    [HttpDelete]
    [ActionName("AccountDelete")]
    public bool Delete([FromQuery] int accountId)
    {
        try
        {
            _accountContainer.DeleteAccount(accountId);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }
}