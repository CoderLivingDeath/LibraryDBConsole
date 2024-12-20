using LibraryApp.Models.Data;
using LibraryApp.Repositories;

namespace LibraryApp.Interfaces
{
    public interface ILibraryService
    {
        void AddBook(Book book);
        void AddCatalog(Catalog catalog);
        void AddClient(Client client);
        void AddCompany(Company company);
        void AddEmployee(Employee employee);
        void DeleteBookById(int id);
        void DeleteCatalogById(int id);
        void DeleteClientById(int id);
        void DeleteCompanyById(int id);
        void DeleteEmployeeById(int id);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Catalog> GetAllCatalog();
        IEnumerable<Client> GetAllClients();
        IEnumerable<Company> GetAllCompanies();
        IEnumerable<Employee> GetAllEmployees();
        Book GetBookById(int id);
        Catalog GetCatalogById(int id);
        Client GetClientById(int id);
        Company GetCompanyById(int id);
        Employee GetEmployeeById(int id);
        void AddOrderForm(OrderForm form);
        void DeleteOrderFormById(int id);
        OrderForm GetOrderFormById(int id);
        IEnumerable<OrderForm> GetAllOrderForm();
    }
}