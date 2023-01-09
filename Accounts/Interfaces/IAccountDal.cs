namespace Accounts.Interfaces;

public interface IAccountDal
{
    public List<AccountDto> GetAll();
    public AccountDto GetById(int accountId);
    public void CreatePlanning(AccountDto accountDto);
    public void UpdatePlanning(AccountDto accountDto);
    public void DeletePlanning(int accountId);
}