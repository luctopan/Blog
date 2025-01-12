using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        // connection
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
            => _connection = connection;

        // CRUD genérico
        public IEnumerable<T> Get() // não precisa ser static, pois será instanciada (classe static sobe junto com a aplicação)
            => _connection.GetAll<T>(); // SELECT * FROM [User]

        public T Get(int id) // não precisa ser static, pois será instanciada (classe static sobe junto com a aplicação)
            => _connection.Get<T>(id); // SELECT * FROM [Role] WHERE [Id] = 1

        public void Create(T model) // não precisa ser static, pois será instanciada (classe static sobe junto com a aplicação)        
            => _connection.Insert<T>(model); // SELECT * FROM [Role] WHERE [Id] = 1        

        public void Update(T model)
            => _connection.Update<T>(model);

        public void Delete(T model)
            => _connection.Delete<T>(model);

        public void Delete(int id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }

    }
}