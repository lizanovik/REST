using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_APISample.Models
{
    public class FakeUserStorage
    {
        private static List<User> books = new List<User>();
        
        /// <summary>
        /// The method that loads book list.
        /// </summary>
        /// <returns>Book list</returns>
        public IEnumerable<User> Load()
        {
            return books;
        }

        /// <summary>
        /// The method that saves books into a fake storage.
        /// </summary>
        /// <param name="books">Source.</param>
        public void Save(IEnumerable<User> book)
        {
            books = (List<User>)book;
        }
    }
}