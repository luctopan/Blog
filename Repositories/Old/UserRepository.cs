// using Blog.Models;
// using Dapper.Contrib.Extensions;
// using Microsoft.Data.SqlClient;

// namespace Blog.Repositories
// {
//     public class UserRepository
//     {
//         private readonly SqlConnection _connection;

//         public UserRepository(SqlConnection connection)
//             => _connection = connection;

//         public IEnumerable<User> Get() // não precisa ser static, pois será instanciada (classe static sobe junto com a aplicação)
//             => _connection.GetAll<User>(); // SELECT * FROM [User]

//         public User Get(int id) // não precisa ser static, pois será instanciada (classe static sobe junto com a aplicação)
//             => _connection.Get<User>(id); // SELECT * FROM [User] WHERE [Id] = 1

//         public void Create(User user) // não precisa ser static, pois será instanciada (classe static sobe junto com a aplicação)
//         {
//             user.Id = 0;
//             _connection.Insert<User>(user); // SELECT * FROM [User] WHERE [Id] = 1       
//         }

//         public void Update(User user)
//         {
//             if (user.Id != 0)
//                 _connection.Update<User>(user);
//         }

//         public void Delete(User user)
//         {
//             if (user.Id != 0)
//                 _connection.Delete<User>(user);
//         }

//         public void Delete(int id)
//         {
//             if (id != 0)
//                 return;

//             var user = _connection.Get<User>(id);
//             _connection.Delete<User>(user);
//         }

//     }
// }