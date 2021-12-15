using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Author> Authors { get; }
        IRepository<Book> Books { get; }
        IRepository<Genre> Genres { get; }
        IRepository<User> Users { get; }
        IRepository<Order> Orders { get; }

        void Save();

    }
}
