using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{

    public class SqlQueryBuilder
    {
        private StringBuilder query;

        public SqlQueryBuilder()
        {
            query = new StringBuilder();
        }

        public SqlQueryBuilder Select(string columns)
        {
            query.Append($"SELECT {columns} ");
            return this;
        }

        public SqlQueryBuilder From(string table)
        {
            query.Append($"FROM {table} ");
            return this;
        }

        public SqlQueryBuilder Where(string condition)
        {
            query.Append($"WHERE {condition} ");
            return this;
        }

        public SqlQueryBuilder OrderBy(string column, string order = "ASC")
        {
            query.Append($"ORDER BY {column} {order} ");
            return this;
        }

        public string Build()
        {
            return query.ToString().Trim();
        }
    }

    class Program
    {
        static void Main()
        {
            string query = new SqlQueryBuilder()
                .Select("*")
                .From("Users")
                .Where("Age > 18")
                .OrderBy("Name")
                .Build();

            Console.WriteLine(query);
        }
    }
}
