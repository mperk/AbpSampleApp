using SampleApp.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace SampleApp.Service_Tests
{
    public class BookAppService_Tests : SampleAppApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;

        public BookAppService_Tests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            var result = await _bookAppService.GetListAsync(
                    new PagedAndSortedResultRequestDto()
                    );

            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(x => x.Name == "Test Book 1");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Book()
        {
            var result = await _bookAppService.CreateAsync(
                new Books.CreateUpdateBookDto
                {
                    Name = "New Test Book 44",
                    Price = 44,
                    PublishDate = DateTime.Now,
                    Type = Books.BookType.ScienceFiction
                }
                );

            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("New Test Book 44");
        }

        [Fact]
        public async Task Should_Not_Craete_A_Book_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _bookAppService.CreateAsync(
                    new Books.CreateUpdateBookDto
                    {
                        Name = "",
                        Price = 1,
                        PublishDate = DateTime.Now,
                        Type = Books.BookType.ScienceFiction
                    }
                    );
            });

            exception.ValidationErrors.ShouldContain(x => x.MemberNames.Any(y => y == "Name"));
        }

        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Price()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _bookAppService.CreateAsync(
                        new Books.CreateUpdateBookDto
                        {
                            Name = "Test Book",
                            PublishDate = DateTime.Now,
                            Type = Books.BookType.Biography
                        }
                    );
            });
            exception.ValidationErrors.ShouldContain(x => x.MemberNames.Any(y => y == "Price"));
        }
    }
}
