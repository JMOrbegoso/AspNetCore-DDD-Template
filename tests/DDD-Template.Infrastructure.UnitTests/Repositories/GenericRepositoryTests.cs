using DDD_Template.Domain.Base.Entities;
using DDD_Template.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using Xunit;

namespace DDD_Template.Infrastructure.UnitTests.Repositories
{
    public class GenericRepositoryTests : IDisposable
    {
        private CustomerDbContext _context { get; }

        private class Customer : IEntity
        {
            public Guid Id { get; }

            private Customer(Guid id)
            {
                this.Id = id;
            }

            public static Customer Create(Guid guid)
            {
                return new Customer(guid);
            }
        }

        private class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.ToTable(nameof(Customer), nameof(Customer));

                builder.HasKey(user => user.Id);
                builder.Property(user => user.Id)
                       .IsRequired();
            }
        }

        private class CustomerDbContext : DbContext
        {
            public CustomerDbContext(DbContextOptions options) : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

                builder.ApplyConfiguration(new CustomerTypeConfiguration());
            }
        }

        private class CustomerGenericRepository : GenericRepository<Customer>
        {
            public CustomerGenericRepository(CustomerDbContext context) : base(context)
            {
            }
        }

        public GenericRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: nameof(GenericRepositoryTests))
                .Options;

            this._context = new CustomerDbContext(options);
        }

        [Fact]
        public void Expected_Get_All_Customers()
        {
            // Arrange
            var id = Guid.NewGuid();
            var customer = Customer.Create(id);
            this._context.Add(customer);
            this._context.SaveChanges();

            var repository = new CustomerGenericRepository(this._context);

            // Act
            var customers = repository.GetAll();

            // Assert
            customers.Count().Should().Be(1);
            customers[0].Id.Should().Be(id);
        }

        [Fact]
        public void Expected_Get_Customer_by_Id()
        {
            // Arrange
            var id = Guid.NewGuid();
            var customer = Customer.Create(id);
            this._context.Add(customer);
            this._context.SaveChanges();

            var repository = new CustomerGenericRepository(this._context);

            // Act
            var customerById = repository.GetById(id);

            // Assert
            customerById.Id.Should().Be(id);
        }

        [Fact]
        public void Expected_FindAll_Customer()
        {
            // Arrange
            var id = Guid.NewGuid();
            var customer = Customer.Create(id);
            this._context.Add(customer);
            this._context.SaveChanges();

            var repository = new CustomerGenericRepository(this._context);

            // Act
            var customersFound = repository.FindAll(c => c.Id.Equals(id));

            // Assert
            customersFound.Count().Should().Be(1);
            customersFound[0].Id.Should().Be(id);
        }

        [Fact]
        public void Expected_Add_Customer()
        {
            // Arrange            
            var id = Guid.NewGuid();
            var newCustomer = Customer.Create(id);

            // Act
            var repository = new CustomerGenericRepository(this._context);
            repository.Add(newCustomer);

            this._context.SaveChanges();
            var customers = this._context.Set<Customer>().ToList();

            //Assert
            customers.Count().Should().Be(1);
            customers[0].Id.Should().Be(id);
        }

        [Fact]
        public void Expected_Remove_Customer()
        {
            // Arrange
            var id = Guid.NewGuid();
            var customer = Customer.Create(id);
            this._context.Add(customer);
            this._context.SaveChanges();

            var repository = new CustomerGenericRepository(this._context);

            // Act
            repository.Remove(customer);

            this._context.SaveChanges();
            var customers = this._context.Set<Customer>().ToList();

            //Assert
            customers.Count().Should().Be(0);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            this._context.Set<Customer>().RemoveRange(this._context.Set<Customer>());
            this._context.SaveChanges();
            this._context.Dispose();
        }
    }
}