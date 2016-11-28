using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsMix.Framework
{
    public class CountryRepository
    {
        public static IList<Country> GetAll(String area)
        {
            var countries = GetAll();
            return (from c in countries
                    where String.Equals(c.Area, area, StringComparison.InvariantCultureIgnoreCase)
                    select c).ToList();
        }

        public static IList<Country> GetAll()
        {
            var countries = new List<Country>();
            var c1 = new Country() { Area = "EMEA", Capital = "Rome", Name = "Italy", Code = "IT" };
            countries.Add(c1);
            var c2 = new Country() { Area = "EMEA", Capital = "London", Name = "UK", Code = "UK" };
            countries.Add(c2);
            var c3 = new Country() { Area = "NA", Capital = "Washington", Name = "USA", Code = "US" };
            countries.Add(c3);
            var c4 = new Country() { Area = "EMEA", Capital = "Amsterdam", Name = "Netherlands", Code = "NL" };
            countries.Add(c4);
            var c5 = new Country() { Area = "Asia", Capital = "Beijing", Name = "China", Code = "CC" };
            countries.Add(c5);
            var c6 = new Country() { Area = "Asia", Capital = "Tokyo", Name = "Japan", Code = "JP" };
            countries.Add(c6);
            var c7 = new Country() { Area = "NA", Capital = "Ottawa", Name = "Canada", Code = "CA" };
            countries.Add(c7);
            return countries;
        }
    }
}