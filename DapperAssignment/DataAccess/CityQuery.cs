
using Dapper;
using DapperAssignment.Models;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
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
        public List<City> GetCitiesWithLifeExpectancy(string continent = "Europe")
        {
            string sql = "SELECT city.id, city.name, city.countrycode, city.population, city.district, " +
                         "country.lifeexpectancy " +
                         "FROM city " +
                         "JOIN country ON city.countrycode = country.Code " +
                         "WHERE country.Continent = @Continent " +
                         "ORDER BY country.LifeExpectancy DESC";

            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<City>(sql, new
                {
                    Continent =
                continent
                }).ToList();
            }
        }
    }
}