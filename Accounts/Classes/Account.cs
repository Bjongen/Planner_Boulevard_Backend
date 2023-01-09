namespace Accounts;

public class Account
{
    public int? AccountId { get; set; }
    public string? Name { get; set; }
    public string? EmployeeCode { get; set; }
    public string? Password { get; set; }

    public Account()
    {
        
    }
    public Account(int accountId, string name, string employeeCode, string password)
    {
        AccountId = accountId;
        Name = name;
        EmployeeCode = employeeCode;
        Password = password;
    }

    public Account(AccountDto accountDto)
    {
        AccountId = accountDto.AccountId;
        Name = accountDto.Name;
        EmployeeCode = accountDto.EmployeeCode;
        Password = accountDto.Password;
    }
    
    public AccountDto ToDto()
    {
        return new AccountDto
        {
            AccountId = AccountId,
            Name = Name,
            EmployeeCode = EmployeeCode,
            Password = Password,
        };
    }
}