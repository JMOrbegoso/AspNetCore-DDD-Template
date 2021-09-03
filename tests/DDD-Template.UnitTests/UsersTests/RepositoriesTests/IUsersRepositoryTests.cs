using Bogus;
using DDD_Template.Domain.Users.Entities;
using DDD_Template.Domain.Users.Repositories;
using DDD_Template.Domain.Users.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace DDD_Template.UnitTests.UsersTests.RepositoriesTests
{
    public class IUsersRepositoryTests
    {
        private class UsersRepository : IUsersRepository
        {
            public List<User> Users = new List<User>();

            public User Find(Guid id)
            {
                return this.Users.SingleOrDefault(c => c.Id == id);
            }

            public IImmutableList<User> GetAll()
            {
                return this.Users.ToImmutableList();
            }

            public IImmutableList<User> Where(Expression<Func<User, bool>> predicate)
            {
                return this.Users.Where(predicate.Compile()).ToImmutableList();
            }

            public void Add(User user)
            {
                this.Users.Add(user);
            }

            public void Remove(User user)
            {
                this.Users.Remove(user);
            }
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
            var user = this.GenerateFakeUser();
            var repository = new UsersRepository();
            repository.Users.Add(user);

            // Act
            var users = repository.GetAll();

            // Assert
            users.Count.Should().Be(1);
        }

        [Fact]
        public void Expected_Get_Users_By_Id()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user = this.GenerateFakeUser(id);
            var repository = new UsersRepository();
            repository.Users.Add(user);

            // Act
            var userFound = repository.Find(id);

            // Assert
            userFound.Should().Be(user);
            userFound.Id.Should().Be(id);
        }

        [Fact]
        public void Expected_Get_User_By_Id_Not_Found()
        {
            // Arrange
            var repository = new UsersRepository();

            // Act
            var userFound = repository.Find(Guid.NewGuid());

            // Assert
            userFound.Should().BeNull();
        }

        [Fact]
        public void Expected_Where_Users()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user = this.GenerateFakeUser(id);
            var repository = new UsersRepository();
            repository.Users.Add(user);

            // Act
            var users = repository.Where(c => c.Id.Equals(id));

            // Assert
            users.Count.Should().Be(1);
        }

        [Fact]
        public void Expected_Add_User()
        {
            // Arrange
            var user = this.GenerateFakeUser();
            var repository = new UsersRepository();

            // Act
            repository.Add(user);

            // Assert
            repository.Users.Count.Should().Be(1);
        }

        [Fact]
        public void Expected_Remove_User()
        {
            // Arrange
            var user = this.GenerateFakeUser();
            var repository = new UsersRepository();
            repository.Users.Add(user);

            // Act
            repository.Remove(user);

            // Assert
            repository.Users.Count.Should().Be(0);
        }
    }
}