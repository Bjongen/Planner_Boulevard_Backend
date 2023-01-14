namespace Accounts.Interfaces;

public interface IAccountContainer
{
    public List<AccountDto> GetAccounts();
    public List<AccountDto> GetAllAccounts();
    public AccountDto GetById(int accountId);
    public int CreateAccount(AccountDto accountDto);
    public void UpdateAccount(AccountDto accountDto);
    public void DeleteAccount(int accountId);
}