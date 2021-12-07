using System;
using System.Data.SqlClient;
using Dapper;
using Interests.DbModels;

namespace Interests
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InterestDb;Integrated Security=True";
            var conn = new SqlConnection(connStr);
            //var people = conn.Query<Person>("select id, name from person");
            //foreach (var person in people)
            //{
            //    Console.WriteLine($"{person.Name} ({person.Id})");
            //}

            var id = new Guid("139913d1-3bd7-4016-974a-054e0f9a9151");
            var sql = @"select p.Name Person, i.Name Interest
                        from PersonInterest 
                        join Interest i on InterestId = i.Id
                        join Person p on PersonId = p.Id
                        where PersonId = @Id";
            var people = conn.Query<PersonInterest>(sql, new { Id = id });
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Person} ({person.Interest})");
            }
        }
    }
}
