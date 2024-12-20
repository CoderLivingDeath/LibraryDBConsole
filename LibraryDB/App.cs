﻿using LibraryApp.Controllers;
using LibraryApp.Infrastructure;
using LibraryApp.Interfaces;
using LibraryApp.Models.Data;
using LibraryApp.Repositories;
using LibraryApp.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace LibraryDB
{
    public class App
    {
        private IServiceCollection _services;

        private string _connectionString;

        private bool _appIsStarting;

        private IServiceProvider _serviceProvider;

        public class AppConfiguration
        {
            private readonly string _connectionString;

            public AppConfiguration(string connectionString)
            {
                _connectionString = connectionString;
            }

            public string GetConnectionString() => _connectionString;
        }

        public App(AppConfiguration configuration)
        {
            _services = new ServiceCollection();
            _connectionString = configuration.GetConnectionString();
        }

        public void Start()
        {
            ConfigureServiceCollections(_services);
            ConfigureControllers(_services);
            _serviceProvider = _services.BuildServiceProvider();
            _appIsStarting = true;
        }

        public bool IsStarting()
        {
            return _appIsStarting;
        }

        public IServiceProvider GetServiceProvider()
        {
            if (IsStarting()) return _serviceProvider;
            else throw new InvalidOperationException();
        }

        private void ConfigureServiceCollections(IServiceCollection services)
        {
            services.AddSingleton<ILogService, LogService>();

            var dbConntection = new DbConnectionService(_connectionString);
            services.AddSingleton<IDbConnectionService, DbConnectionService>(h => dbConntection);

            services.AddSingleton<IRepository<Client>, ClientRepository>();
            services.AddSingleton<IRepository<Employee>, EmployeeRepository>();
            services.AddSingleton<IRepository<Book>, BookRepository>();
            services.AddSingleton<IRepository<Catalog>, CatalogRepository>();
            services.AddSingleton<IRepository<Company>, CompanyRepository>();
            services.AddSingleton<IRepository<OrderForm>, OrderFormRepository>();

            services.AddSingleton<ILibraryService, LibraryService>();
        }

        private void ConfigureControllers(IServiceCollection services)
        {
            services.AddSingleton<DbController>();
            services.AddSingleton<LibraryController>();
        }
    }
}


