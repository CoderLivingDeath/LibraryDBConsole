using LibraryApp.Models.Data;
using LibraryApp.Repositories;
using LibraryApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure
{
    public class LibraryRepositoriesProvider
    {
        public IRepository<Client> ClientRepository { get; }
        public IRepository<Employee> EmployeeRepository { get; }
        public IRepository<Company> CompanyRepository { get; }
        public IRepository<Book> BookRepository { get; }
        public IRepository<Catalog> CatalogRepository { get; }
        public IRepository<OrderForm> OrderFormRepository { get; }

        public LibraryRepositoriesProvider(IRepository<Client> clientRepository, IRepository<Employee> employeeRepository, IRepository<Company> companyRepository, IRepository<Book> bookRepository, IRepository<Catalog> catalogRepository, IRepository<OrderForm> orderFormRepository)
        {
            ClientRepository = clientRepository;
            EmployeeRepository = employeeRepository;
            CompanyRepository = companyRepository;
            BookRepository = bookRepository;
            CatalogRepository = catalogRepository;
            OrderFormRepository = orderFormRepository;
        }

        public LibraryRepositoriesProvider(LibraryService.LibraryRepositories repositories)
        {
            ClientRepository = repositories.ClientRepository;
            EmployeeRepository = repositories.EmployeeRepository;
            CompanyRepository = repositories.CompanyRepository;
            BookRepository = repositories.BookRepository;
            CatalogRepository = repositories.CatalogRepository;
            OrderFormRepository = repositories.OrderFormRepository;
        }
    }
}
