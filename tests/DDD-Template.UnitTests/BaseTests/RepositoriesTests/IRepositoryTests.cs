using Bogus;
using DDD_Template.Domain.Base.DomainEvents;
using DDD_Template.Domain.Base.Entities;
using DDD_Template.Domain.Base.Repositories;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace DDD_Template.UnitTests.BaseTests.RepositoriesTests
{
    public class IRepositoryTests
    {
        private class Customer : IAggregateRoot
        {
            public IReadOnlyList<IDomainEvent> DomainEvents => throw new NotImplementedException();

            public Guid Id { get; set; }

            public void AddDomainEvent(IDomainEvent domainEvent)
            {
                throw new NotImplementedException();
            }

            public void ClearDomainEvents()
            {
                throw new NotImplementedException();
            }
        }

        private class CustomersRepository : IRepository<Customer>
        {
            public List<Customer> Customers = new List<Customer>();

            public Customer Find(Guid id)
            {
                return this.Customers.SingleOrDefault(c => c.Id == id);
            }

            public IImmutableList<Customer> GetAll()
            {
                return this.Customers.ToImmutableList();
            }

            public IImmutableList<Customer> Where(Expression<Func<Customer, bool>> predicate)
            {
                return this.Customers.Where(predicate.Compile()).ToImmutableList();
            }
        }

        private Customer GenerateFakeCustomer()
        {
            return this.GenerateFakeCustomer(Guid.NewGuid());
        }
        private Customer GenerateFakeCustomer(Guid id)
        {
            var faker = new Faker<Customer>();

            var customer = faker.RuleFor(c => c.Id, f => id);

            return customer;
        }

        [Fact]
        public void Expected_Get_All_Customers()
        {
            // Arrange
            var customer = this.GenerateFakeCustomer();
            var repository = new CustomersRepository();
            repository.Customers.Add(customer);

            // Act
            var customers = repository.GetAll();

            // Assert
            customers.Count.Should().Be(1);
        }

        [Fact]
        public void Expected_Get_Customers_By_Id()
        {
            // Arrange
            var id = Guid.NewGuid();
            var customer = this.GenerateFakeCustomer(id);
            var repository = new CustomersRepository();
            repository.Customers.Add(customer);

            // Act
            var customerFound = repository.Find(id);

            // Assert
            customerFound.Should().Be(customer);
            customerFound.Id.Should().Be(id);
        }

        [Fact]
        public void Expected_Get_Customers_By_Id_Not_Found()
        {
            // Arrange
            var repository = new CustomersRepository();

            // Act
            var customerFound = repository.Find(Guid.NewGuid());

            // Assert
            customerFound.Should().BeNull();
        }

        [Fact]
        public void Expected_Where_Customers()
        {
            // Arrange
            var id = Guid.NewGuid();
            var customer = this.GenerateFakeCustomer(id);
            var repository = new CustomersRepository();
            repository.Customers.Add(customer);

            // Act
            var customers = repository.Where(c => c.Id.Equals(id));

            // Assert
            customers.Count.Should().Be(1);
        }
    }
}