using SampleApp.Books;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Threading;

namespace SampleApp
{
    public class SampleAppTestDataBuilder : ITransientDependency
    {
        private readonly IIdentityDataSeeder _identityDataSeeder;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Author, Guid> _authorRepository;

        public SampleAppTestDataBuilder(
            IIdentityDataSeeder identityDataSeeder,
            IRepository<Book, Guid> bookRepository,
            IRepository<Author, Guid> authorRepository)
        {
            _identityDataSeeder = identityDataSeeder;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public void Build()
        {
            AsyncHelper.RunSync(BuildInternalAsync);
        }

        public async Task BuildInternalAsync()
        {
            await _identityDataSeeder.SeedAsync("1q2w3E*");

            await _bookRepository.InsertAsync(
                new Book
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Book 1",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1989, 05, 26),
                    Price = 29
                }
                );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Book 2",
                    Type = BookType.Horror,
                    PublishDate = new DateTime(2016, 09, 07),
                    Price = 11
                });

            await _authorRepository.InsertAsync(
                    new Author
                    {
                        FirstName = "Mehmet",
                        LastName = "Perk"
                    }
                );

            await _authorRepository.InsertAsync(
                    new Author
                    {
                        FirstName = "Yılmaz",
                        LastName = "Perk"
                    }
                );
        }
    }
}