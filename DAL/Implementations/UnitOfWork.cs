using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implementations
{
    public class UnitOfWork:IUnitOfWork
    {
        private LibraryContext db;
        private Repository<Author> authorRepository;
        private Repository<Book> bookRepository;
        private Repository<Genre> genreRepository;
        private Repository<User> userRepository;
        private Repository<Order> orderRepository;

        public UnitOfWork()
        {
            db = new LibraryContext();
        }

        public IRepository<Author> Authors
        {
            get
            {
                if (authorRepository == null) authorRepository = new Repository<Author>(db);
                return authorRepository;
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null) bookRepository = new Repository<Book>(db);
                return bookRepository;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (genreRepository == null) genreRepository = new Repository<Genre>(db);
                return genreRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null) orderRepository = new Repository<Order>(db);
                return orderRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null) userRepository = new Repository<User>(db);
                return userRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
