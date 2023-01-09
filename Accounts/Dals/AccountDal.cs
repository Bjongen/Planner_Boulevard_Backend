using System.Data;
using System.Data.SqlClient;
using Accounts.Interfaces;
using Dapper;

namespace Accounts;

public class AccountDal : IAccountDal
{
    private IDbConnection _dbConnection =
            new SqlConnection("Server=mssqlstud.fhict.local;Uid=dbi488751;Database=dbi488751;Pwd=Bjongen2003;");


        public List<AccountDto> GetAll()
        {
            const string sql = "Select * From Account;";
            try
            {
                using (_dbConnection)
                {
                    return _dbConnection.Query<AccountDto>(sql).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public AccountDto GetById(int AccountId)
        {
            const string sql = "Select * From Account Where AccountId = @AccountId;";
            try
            {
                using (_dbConnection)
                {
                    return _dbConnection.QuerySingle<AccountDto>(sql, new
                    {
                        AccountId
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void CreatePlanning(AccountDto accountDto)
        {
            const string sql = "Insert Into Account values (@Name, @EmployeeCode, @Password);";
            try
            {
                using (_dbConnection)
                {
                    _dbConnection.Execute(sql, new
                    {
                        accountDto.Name,
                        accountDto.EmployeeCode,
                        accountDto.Password
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdatePlanning(AccountDto accountDto)
        {
            const string sql =
                "Update Account Set Name = @Name, EmployeeCode = @EmployeeCode, Password = @Password where AccountId = @AccountId;";
            try
            {
                using (_dbConnection)
                {
                    _dbConnection.Execute(sql, new
                    {
                        accountDto.Name,
                        accountDto.EmployeeCode,
                        accountDto.Password,
                        accountDto.AccountId
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeletePlanning(int AccountId)
        {
            const string sql = "Delete From Account Where AccountId = @AccountId;";
            try
            {
                using (_dbConnection)
                {
                    _dbConnection.Execute(sql, new
                    {
                        AccountId
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
}