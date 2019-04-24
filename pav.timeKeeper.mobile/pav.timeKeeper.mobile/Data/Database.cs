using pav.timeKeeper.mobile.Models;
using pav.timeKeeper.mobile.Models.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pav.timeKeeper.mobile.Data
{
    class Database : IDataRepository
    {
        static object collisionLock = new object();
        SQLiteAsyncConnection connection;


        public Database(string databasePath)
        {
            connection = new SQLiteAsyncConnection(databasePath); 
        }

        public async Task<bool> CreateProjectAsync(IProject project)
        {
           
            await connection.CreateTableAsync<Project>();
            return await connection.InsertAsync(project, typeof(Project)) == 1;
        }
     

        public async Task<IProject> ReadProjectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> TableExistsAsync(string tableName) {
            string queryString = $"SELECT name FROM sqlite_master WHERE type='table' AND name=?;";
            var result = (await connection.QueryAsync<TableName>(queryString, tableName));

            return result.FirstOrDefault()?.name == tableName;
        }


        public async Task<IEnumerable<IProject>> ReadProjectsAsync()
        {
            if(await TableExistsAsync("table_project"))
             return await connection.Table<Project>().ToListAsync();
            return null;
        }

        public Task<bool> UpdateProjectAsync(IProject project)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IProjectTask>> ReadProjectTasks(Guid projectId)
        {
            if (await TableExistsAsync("table_tasks"))
                return await connection.QueryAsync<ProjectTask>("SELECT * FROM table_tasks WHERE projectId =?", projectId);
            return null;
        }

        public async Task<bool> CreateProjectTasksAsync(IEnumerable<IProjectTask> Tasks)
        {
            await connection.CreateTableAsync<ProjectTask>();
            return await connection.InsertAllAsync(Tasks, typeof(ProjectTask)) == Tasks.Count();
        }
    }
}
