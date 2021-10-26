using System.Collections.Generic;
using System.Data;
using Dapper;
using fall21Collabs.Models;

namespace fall21Collabs.Repositories
{
    public class AccountProjectRepository
    {
        private readonly IDbConnection _db;
        public AccountProjectRepository(IDbConnection db)
        {
            _db = db;
        }
        
        internal int createAccountProject(AccountProject newAccProj){
            string sql = @"
            INSERT INTO accountProject
            (accountId, projectId)
            VALUES
            (@accountId, @projectId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newAccProj);
        }
        //NOTE this is the same thing as list, you just need to convert it to a list (.toList())
        internal IEnumerable<AccountProjectViewModel> getAccountByProjectId(int id){
            string sql = @"
            SELECT acc.*,
            proj.id AS accountProjectId
            FROM accountProject accProj
            JOIN account acc ON acc.id = accProj.id
            WHERE projectId = @id;";
            return _db.Query<AccountProjectViewModel>(sql, new { id });
        }

        internal AccountProject getById(int id)
        {
            string sql = "SELECT accProj.* FROM accountProject accProj WHERE accProj.Id = @id;";
            return _db.QueryFirstOrDefault<AccountProject>(sql, new {id});
    }
    }
}