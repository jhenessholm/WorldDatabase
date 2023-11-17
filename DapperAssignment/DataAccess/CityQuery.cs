
using Dapper;
using DapperAssignment.Models;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;

namespace DapperAssignment.DataAccess
{
    public class CityQuery
    {
        private readonly string _connectionString;
        public CityQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<City> GetCitiesWithLifeExpectancy(string continent = "Europe", string orderBy = "LifeExpectancy")
        {
            string orderClause = orderBy == "LifeExpectancy" ? "ORDER BY country.LifeExpectancy DESC" : "";

            string sql = $"SELECT city.id, city.name, city.countrycode, city.population, city.district, country.Lifeexpectancy " +
                         $"FROM city " +
                         $"JOIN country ON city.countrycode = country.Code " +
                         $"WHERE country.Continent = @Continent " +
                         $"{orderClause}";

            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<City>(sql, new { Continent = continent }).ToList();
            }
        }

        public List<Country> GetAllCountries()
        {
            string sql = "SELECT * FROM country ORDER BY Code";
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Country>(sql).ToList();
            }
        }
    }
}



