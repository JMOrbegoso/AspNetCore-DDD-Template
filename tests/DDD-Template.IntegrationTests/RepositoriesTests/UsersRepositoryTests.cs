using Bogus;
using DDD_Template.Domain.Users.Entities;
using DDD_Template.Domain.Users.ValueObjects;
using DDD_Template.Infrastructure.Persistence.Contexts;
using DDD_Template.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace DDD_Template.IntegrationTests.RepositoriesTests
{
    public class UsersRepositoryTests
    {
        private ApplicationDbContext GenerateApplicationDbContext()
        {
            var databaseName = $"{nameof(UsersRepositoryTests)}-{Guid.NewGuid()}";
            return this.GenerateApplicationDbContext(databaseName);
        }
        private ApplicationDbContext GenerateApplicationDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new ApplicationDbContext(options);

            return context;
        }

        private User GenerateFakeUser()
        {
            return this.GenerateFakeUser(Guid.NewGuid());
        }
        private User GenerateFakeUser(Guid id)
        {
            var faker = new Faker();

            var firstName = FirstName.Create(faker.Name.FirstName());
            var lastName = LastName.Create(faker.Name.LastName());
            var birthDate = BirthDate.Create(faker.Date.Past());

            var user = User.Create(id, firstName, lastName, birthDate);

            return user;
        }

        [Fact]
        public void Expected_Get_All_Users()
        {
            // Arrange
            var context = this.GenerateApplicationDbContext();
            var user = this.GenerateFakeUser();
            context.Add(user);
            context.SaveChanges();

            var repository = new UsersRepository(context);

            // Act
            var users = repository.GetAll();

            // Assert
            users.Count.Should().Be(1);
        }

        [Fact]
        public void Expected_Get_User_by_Id()
        {
            // Arrange
            var context = this.GenerateApplicationDbContext();
            var id = Guid.NewGuid();
            var user = this.GenerateFakeUser(id);
            context.Add(user);
            context.SaveChanges();

            var repository = new UsersRepository(context);

            // Act
            var customerById = repository.Find(id);

            // Assert
            customerById.Id.Should().Be(id);
        }

        [Fact]
        public void Expected_Where_User()
        {
            // Arrange
            var context = this.GenerateApplicationDbContext();
            var id = Guid.NewGuid();
            var user = this.GenerateFakeUser(id);
            context.Add(user);
            context.SaveChanges();

            var repository = new UsersRepository(context);

            // Act
            var customersFound = repository.Where(c => c.Id.Equals(id));

            // Assert
            customersFound.Count.Should().Be(1);
        }

        [Fact]
        public void Expected_Add_User()
        {
            // Arrange
            var context = this.GenerateApplicationDbContext();
            var id = Guid.NewGuid();
            var newUser = this.GenerateFakeUser(id);

            // Act
            var repository = new UsersRepository(context);
            repository.Add(newUser);

            context.SaveChanges();
            var users = context.Set<User>().ToList();

            //Assert
            users.Count.Should().Be(1);
            users[0].Id.Should().Be(id);
        }

        [Fact]
        public void Expected_Remove_User()
        {
            // Arrange
            var context = this.GenerateApplicationDbContext();
            var user = this.GenerateFakeUser();
            context.Add(user);
            context.SaveChanges();

            var repository = new UsersRepository(context);

            // Act
            repository.Remove(user);

            context.SaveChanges();
            var users = context.Set<User>().ToList();

            //Assert
            users.Count.Should().Be(0);
        }
    }
}