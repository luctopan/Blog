using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            Console.Clear();

            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            // ReadUser(connection, 1);
            // ReadUsers(connection);
            ReadUsersWithRoles(connection);
            // CreateUser(connection);
            // UpdateUser(connection);
            // DeleteUser(connection, 3);

            // ReadRoles(connection);
            // ReadTags(connection);


            // MÉTODOS ANTIGOS
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();

            connection.Close();
        }

        // user methods
        public static void ReadUser(SqlConnection connection, int id)
        {
            var repository = new Repository<User>(connection);
            var user = repository.Get(id);

            Console.WriteLine(user.Name);
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Bio = "Dev",
                Email = "bruno@gmail.com",
                Image = "https://...",
                Name = "Bruno Dev",
                PasswordHash = "HASH",
                Slug = "bruno-dev"
            };

            var repository = new Repository<User>(connection);
            repository.Create(user);
        }

        public static void UpdateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Id = 3,
                Bio = "Student",
                Email = "alex@outlook.com",
                Image = "https://...",
                Name = "Alex L. Topan",
                PasswordHash = "HASH",
                Slug = "xluctopan"
            };

            var repository = new Repository<User>(connection);
            repository.Update(user);
        }

        public static void DeleteUser(SqlConnection connection, int id)
        {
            var repository = new Repository<User>(connection);
            repository.Delete(id);
        }

        // role methods
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        // tag methods
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        // public static void ReadUser()
        // {
        //     using (var connection = new SqlConnection())
        //     {
        //         var user = connection.Get<User>(1); // SELECT * FROM [User] WHERE [Id] = 1

        //         Console.WriteLine(user.Name);
        //     }
        // }

        // public static void CreateUser()
        // {
        //     var user = new User()
        //     {
        //         Bio = "Home",
        //         Email = "topan@gmail.com",
        //         Image = "https://...",
        //         Name = "Luciano Topan",
        //         PasswordHash = "HASH",
        //         Slug = "topan-luciano"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Insert<User>(user);
        //         Console.WriteLine("Cadastro realizado com sucesso.");
        //     }
        // }

        // public static void UpdateUser()
        // {
        //     var user = new User()
        //     {
        //         Id = 2,
        //         Bio = "Developer",
        //         Email = "topan.luciano@gmail.com",
        //         Image = "https://...",
        //         Name = "Luciano Topan Topan",
        //         PasswordHash = "HASH",
        //         Slug = "topan-luciano-alex"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Update<User>(user);
        //         Console.WriteLine("Atualização realizada com sucesso.");
        //     }
        // }

        // public static void DeleteUser()
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(2);
        //         connection.Delete<User>(user);
        //         Console.WriteLine("Exclusão realizada com sucesso.");
        //     }
        // }

    }
}