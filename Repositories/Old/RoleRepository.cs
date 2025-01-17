// using Blog.Models;
// using Dapper.Contrib.Extensions;
// using Microsoft.Data.SqlClient;

// namespace Blog.Repositories
// {
//     public class RoleRepository
//     {
//         private readonly SqlConnection _connection;

//         public RoleRepository(SqlConnection connection)
//             => _connection = connection;

//         public IEnumerable<Role> Get() // não precisa ser static, pois será instanciada (classe static sobe junto com a aplicação)
//             => _connection.GetAll<Role>(); // SELECT * FROM [Role]

//         public Role Get(int id) // não precisa ser static, pois será instanciada (classe static sobe junto com a aplicação)
//             => _connection.Get<Role>(id); // SELECT * FROM [Role] WHERE [Id] = 1

//         public void Create(Role role) // não precisa ser static, pois será instanciada (classe static sobe junto com a aplicação)
//         {
//             role.Id = 0;
//             _connection.Insert<Role>(role); // SELECT * FROM [Role] WHERE [Id] = 1    
//         }

//         public void Update(Role role)
//         {
//             if (role.Id != 0)
//                 _connection.Update<Role>(role);
//         }

//         public void Delete(Role role)
//         {
//             if (role.Id != 0)
//                 _connection.Delete<Role>(role);
//         }

//         public void Delete(int id)
//         {
//             if (id != 0)
//                 return;

//             var role = _connection.Get<Role>(id);
//             _connection.Delete<Role>(role);
//         }

//     }
// }