using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTestBertoni.Model;

namespace TaskTestBertoni.Data
{
    public class DB
    {
        readonly SQLiteAsyncConnection database;
        public DB(string DbPath)
        {
            database = new SQLiteAsyncConnection(DbPath);
            database.CreateTableAsync<TaskBertoni>().Wait();
        }

        public Task<int> AddTaskBertoni(TaskBertoni item)
        {
            if (item.IdTaskBertoni != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> DeleteTaskBertoni(TaskBertoni taskBertoni)
        {
            return database.DeleteAsync(taskBertoni);
        }
        public Task<List<TaskBertoni>> GetTaskBertoni()
        {
            return database.Table<TaskBertoni>().ToListAsync();
        }
    }
}
