using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_APISample.Models
{
    public class UserService
    {
        private FakeUserStorage storage;

        private List<User> books = new List<User>();

        /// <summary>
        /// The constructor that initializes the book storage.
        /// </summary>
        /// <param name="storage">Book storage</param>
        public UserService(FakeUserStorage storage)
        {
            if (storage is null)
            {
                throw new ArgumentNullException($"{nameof(storage)} cannot be null!");
            }
            this.storage = storage;
        }

        /// <summary>
        /// The method that returns current book list.
        /// </summary>
        /// <returns>Book list.</returns>
        public IEnumerable<User> GetAllBooks()
        {
            return storage.Load();
        }

        public void AddUser(User book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"{nameof(book)} cannot be null!");
            }

            List<User> books = new List<User>(storage.Load());

            if (books.Contains(book))
            {
                throw new ArgumentException($"{nameof(book)} is already exist.");
            }

            books.Add(book);
            storage.Save(books);
        }
        public void UpdateBook(int id, User user)
        {
            var user2 = FindByTag(user1 => user1.Id == user.Id);
            user2.Age = user.Age;
            user2.Name = user.Name;
        }

        /// <summary>
        /// The method that removes book from the book list.
        /// </summary>
        /// <param name="book">Book.</param>
        public void RemoveBook(User book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"{nameof(book)} cannot be null!");
            }

            List<User> books = new List<User>(GetAllBooks());

            if (!books.Contains(book))
            {
                throw new ArgumentException($"{nameof(book)} is not in a storage!");
            }

            books.Remove(book);
            storage.Save(books);
        }


        public User FindByTag(Predicate<User> predicate)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} cannot be null!");
            }

            List<User> books = new List<User>(GetAllBooks());
            foreach (var book in books)
            {
                if (predicate(book))
                {
                    return book;
                }
            }

            return null;
        }
    }
}