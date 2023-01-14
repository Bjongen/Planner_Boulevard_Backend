using Accounts.Interfaces;

namespace Accounts.Containers;

public class AccountContainer : IAccountContainer
{
    public List<AccountDto> _accounts;
    private IAccountDal _accountDal;

    public AccountContainer(IAccountDal accountDal)
    {
        _accounts = new List<AccountDto>();
        _accountDal = accountDal;
    }

    public List<AccountDto> GetAccounts()
    {
        return _accounts;
    }

    public List<AccountDto> GetAllAccounts()
    {
        return _accountDal.GetAll();
    }

    public AccountDto GetById(int accountId)
    {
        return _accountDal.GetById(accountId);
    }

    public int CreateAccount(AccountDto accountDto)
    {
        _accountDal.CreatePlanning(accountDto);
        return 1;
    }

    public void UpdateAccount(AccountDto accountDto)
    {
        _accountDal.UpdatePlanning(accountDto);
    }

    public void DeleteAccount(int accountId)
    {
        _accountDal.DeletePlanning(accountId);
    }
}