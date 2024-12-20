using LibraryApp.Interfaces;
using LibraryApp.Models.Data;
using LibraryApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Services
{
    public class LibraryService : ILibraryService
    {
        public record class LibraryRepositories(IRepository<Client> ClientRepository, IRepository<Employee> EmployeeRepository, IRepository<Company> CompanyRepository,
            IRepository<Book> BookRepository, IRepository<Catalog> CatalogRepository, IRepository<OrderForm> OrderFormRepository);

        private IRepository<Client> _clientRepository;
        private IRepository<Employee> _employeeRepository;
        private IRepository<Company> _companyRepository;
        private IRepository<Book> _bookRepository;
        private IRepository<Catalog> _catalogRepository;
        private IRepository<OrderForm> _orderFormRepository;

        public LibraryService(LibraryService.LibraryRepositories repositories)
        {
            _clientRepository = repositories.ClientRepository;
            _employeeRepository = repositories.EmployeeRepository;
            _companyRepository = repositories.CompanyRepository;
            _bookRepository = repositories.BookRepository;
            _catalogRepository = repositories.CatalogRepository;
            _orderFormRepository = repositories.OrderFormRepository;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Create(employee);
        }

        public void DeleteEmployeeById(int id)
        {
            _employeeRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.ReadAll();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.ReadById(id);
        }

        public void AddClient(Client client)
        {
            _clientRepository.Create(client);
        }

        public void DeleteClientById(int id)
        {
            _clientRepository.Delete(id);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.ReadAll();
        }

        public Client GetClientById(int id)
        {
            return _clientRepository.ReadById(id);
        }

        public void AddBook(Book book)
        {
            _bookRepository.Create(book);
        }

        public void DeleteBookById(int id)
        {
            _bookRepository.Delete(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.ReadAll();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.ReadById(id);
        }

        public void AddCatalog(Catalog catalog)
        {
            _catalogRepository.Create(catalog);
        }

        public void DeleteCatalogById(int id)
        {
            _catalogRepository.Delete(id);
        }

        public Catalog GetCatalogById(int id)
        {
            return _catalogRepository.ReadById(id);
        }

        public IEnumerable<Catalog> GetAllCatalog()
        {
            return _catalogRepository.ReadAll();
        }
        public void AddCompany(Company company)
        {
            _companyRepository.Create(company);
        }

        public void DeleteCompanyById(int id)
        {
            _companyRepository.ReadById(id);
        }

        public Company GetCompanyById(int id)
        {
            return _companyRepository.ReadById(id);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _companyRepository.ReadAll();
        }

        public void AddOrderForm(OrderForm form)
        {
            _orderFormRepository.Create(form);
        }

        public void DeleteOrderFormById(int id)
        {
            _orderFormRepository.ReadById(id);
        }

        public OrderForm GetOrderFormById(int id)
        {
            return _orderFormRepository.ReadById(id);
        }

        public IEnumerable<OrderForm> GetAllOrderForm()
        {
            return _orderFormRepository.ReadAll();
        }
    }
}
