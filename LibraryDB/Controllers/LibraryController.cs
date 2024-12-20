using LibraryApp.Interfaces;
using LibraryApp.Models.Data;

namespace LibraryApp.Controllers
{
    public class LibraryController
    {
        private ILibraryService _libraryService;
        private ILogService _logService;

        public LibraryController(ILibraryService libraryService, ILogService logService)
        {
            _libraryService = libraryService;
            _logService = logService;
        }

        public Result AddEmployee(Employee employee)
        {
            try
            {
                _libraryService.AddEmployee(employee);

                _logService.LogMessage("Database: add new employee.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError("Database: error on add new employee.", typeof(LibraryController), ex);
                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result DeleteEmployeeById(int id)
        {
            try
            {
                _logService.LogMessage($"Database: detele employee by id {id}.", typeof(LibraryController));
                _libraryService.DeleteEmployeeById(id);

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on delete employee by id {id}.", typeof(LibraryController), ex);
                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                var employies = _libraryService.GetAllEmployees();

                _logService.LogMessage($"Database: get all employies.", typeof(LibraryController));

                Result<IEnumerable<Employee>> result = new Result<IEnumerable<Employee>>()
                {
                    Value = employies,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get all employies.", typeof(LibraryController), ex);
                Result<IEnumerable<Employee>> result = new Result<IEnumerable<Employee>>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<Employee> GetEmployeeById(int id)
        {
            try
            {
                var employe = _libraryService.GetEmployeeById(id);

                _logService.LogMessage($"Database: get employee by id {id}.", typeof(LibraryController));

                Result<Employee> result = new Result<Employee>()
                {
                    Value = employe,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get employee by id {id}.", typeof(LibraryController), ex);
                Result<Employee> result = new Result<Employee>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result AddClient(Client client)
        {
            try
            {
                _libraryService.AddClient(client);

                _logService.LogMessage($"Database: add new client.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on add new client.", typeof(LibraryController), ex);
                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result DeleteClientById(int id)
        {
            try
            {
                _libraryService.DeleteClientById(id);

                _logService.LogMessage($"Database: delete clien by id {id}.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on delete client by id {id}.", typeof(LibraryController), ex);
                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<IEnumerable<Client>> GetAllClients()
        {
            try
            {
                var clients = _libraryService.GetAllClients();

                _logService.LogMessage($"Database: get all clients.", typeof(LibraryController));

                Result<IEnumerable<Client>> result = new Result<IEnumerable<Client>>()
                {
                    Value = clients,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get all clients.", typeof(LibraryController), ex);

                Result<IEnumerable<Client>> result = new Result<IEnumerable<Client>>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<Client> GetClientById(int id)
        {
            try
            {
                var client = _libraryService.GetClientById(id);

                _logService.LogMessage($"Database: get client by id {id}.", typeof(LibraryController));

                Result<Client> result = new Result<Client>()
                {
                    Value = client,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get client by id {id}.", typeof(LibraryController), ex);

                Result<Client> result = new Result<Client>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result AddBook(Book book)
        {
            try
            {
                _libraryService.AddBook(book);

                _logService.LogMessage($"Database: add new book.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on add new book.", typeof(LibraryController), ex);

                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result DeleteBookById(int id)
        {
            try
            {
                _libraryService.DeleteBookById(id);

                _logService.LogMessage($"Database: delete book by id {id}.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on delete book by id {id}.", typeof(LibraryController), ex);

                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<IEnumerable<Book>> GetAllBooks()
        {
            try
            {
                var books = _libraryService.GetAllBooks();

                _logService.LogMessage($"Database: get all books.", typeof(LibraryController));

                Result<IEnumerable<Book>> result = new Result<IEnumerable<Book>>()
                {
                    Value = books,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get all books.", typeof(LibraryController), ex);

                Result<IEnumerable<Book>> result = new Result<IEnumerable<Book>>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<Book> GetBookById(int id)
        {
            try
            {
                var book = _libraryService.GetBookById(id);

                _logService.LogMessage($"Database: get book by id {id}", typeof(LibraryController));

                Result<Book> result = new Result<Book>()
                {
                    Value = book,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get book by id {id}.", typeof(LibraryController), ex);

                Result<Book> result = new Result<Book>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result AddCatalog(Catalog catalog)
        {
            try
            {
                _libraryService.AddCatalog(catalog);

                _logService.LogMessage($"Database: add new catalog.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on add new catalog.", typeof(LibraryController), ex);

                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result DeleteCatalogById(int id)
        {
            try
            {
                _libraryService.DeleteCatalogById(id);

                _logService.LogMessage($"Database: delete catalog by id {id}.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on delete catalog by id {id}.", typeof(LibraryController), ex);

                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<Catalog> GetCatalogById(int id)
        {
            try
            {
                var catalog = _libraryService.GetCatalogById(id);

                _logService.LogMessage($"Database: get catalog by id {id}.", typeof(LibraryController));

                Result<Catalog> result = new Result<Catalog>()
                {
                    Value = catalog,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get catalog by id {id}.", typeof(LibraryController), ex);

                Result<Catalog> result = new Result<Catalog>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result AddCompany(Company company)
        {
            try
            {
                _libraryService.AddCompany(company);

                _logService.LogMessage($"Database: add new company.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on add new company.", typeof(LibraryController), ex);

                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result DeleteCompanyById(int id)
        {
            try
            {
                _libraryService.DeleteCompanyById(id);

                _logService.LogMessage($"Database: delete company by id {id}.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on delete compny by id {id}.", typeof(LibraryController), ex);

                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<Company> GetCompanyById(int id)
        {
            try
            {
                var company = _libraryService.GetCompanyById(id);

                _logService.LogMessage($"Database: get company by id {id}.", typeof(LibraryController));

                Result<Company> result = new Result<Company>()
                {
                    Value = company,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get compny by id {id}.", typeof(LibraryController), ex);

                Result<Company> result = new Result<Company>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<IEnumerable<Company>> GetAllCompanies()
        {
            try
            {
                var companies = _libraryService.GetAllCompanies();

                _logService.LogMessage($"Database: get all companies.", typeof(LibraryController));

                Result<IEnumerable<Company>> result = new Result<IEnumerable<Company>>()
                {
                    Value = companies,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get all companies.", typeof(LibraryController), ex);

                Result<IEnumerable<Company>> result = new Result<IEnumerable<Company>>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result AddOrder(OrderForm form)
        {
            try
            {
                _libraryService.AddOrderForm(form);

                _logService.LogMessage($"Database: add new order.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: on add new order.", typeof(LibraryController), ex);

                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result deleteOrderById(int id)
        {
            try
            {
                _libraryService.DeleteOrderFormById(id);

                _logService.LogMessage($"Database: delete order by id {id}.", typeof(LibraryController));

                Result result = new Result()
                {
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on delete order by id {id}.", typeof(LibraryController), ex);

                Result result = new Result()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<OrderForm> GetOrderFormById(int id)
        {
            try
            {
                var order = _libraryService.GetOrderFormById(id);

                _logService.LogMessage($"Database: get order by id {id}.", typeof(LibraryController));

                Result<OrderForm> result = new Result<OrderForm>()
                {
                    Value = order,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get order by id {id}.", typeof(LibraryController), ex);

                Result<OrderForm> result = new Result<OrderForm>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }

        public Result<IEnumerable<OrderForm>> GetAllOrderForms()
        {
            try
            {
                var orders = _libraryService.GetAllOrderForm();

                _logService.LogMessage($"Database: get all orders.", typeof(LibraryController));

                Result<IEnumerable<OrderForm>> result = new Result<IEnumerable<OrderForm>>()
                {
                    Value = orders,
                    Status = ResultStatus.Success,
                    ErrorMessage = null
                };

                return result;
            }
            catch (Exception ex)
            {
                _logService.LogError($"Database: error on get all orders.", typeof(LibraryController), ex);

                Result<IEnumerable<OrderForm>> result = new Result<IEnumerable<OrderForm>>()
                {
                    ErrorMessage = ex.Message,
                    Status = ResultStatus.Error
                };

                return result;
            }
        }
    }
}
