using System.Data;
using Dapper;
using fall21Collabs.Models;

namespace fall21Collabs.Repositories
{
    public class ProjectRepository
    {
        private readonly IDbConnection _db;
        public ProjectRepository(IDbConnection db)
        {
            _db = db;
        }
        public int Create(Project newProj)
        {
            string sql = @"
            INSERT INTO project 
            (name)
            VALUES
            (@name)
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newProj);
        }
        public Project getById(int id)
        {
            string sql = @"
            SELECT
            p.*,
            FROM project p
            WHERE p.Id = @id;";
            return _db.QueryFirstOrDefault<Project>(sql, new {id});
        }
    }
}