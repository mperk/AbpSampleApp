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
    public class AuthorService_Tests : SampleAppApplicationTestBase
    {
        private readonly IAuthorService _authorService;

        public AuthorService_Tests()
        {
            _authorService = GetRequiredService<IAuthorService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Authors()
        {
            var result = await _authorService.GetListAsync(new PagedAndSortedResultRequestDto());
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(x => x.FirstName == "Mehmet");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Author()
        {
            var result = await _authorService.CreateAsync(
                    new Books.CreateUpdateAuthorDto
                    {
                        FirstName = "Üneys",
                        LastName = "Perk"
                    }
                );

            result.Id.ShouldNotBe(Guid.Empty);
            result.FirstName.ShouldBe("Üneys");
        }

        [Fact]
        public async Task Should_Not_Create_A_Author_Without_FirstName()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _authorService.CreateAsync(new Books.CreateUpdateAuthorDto
                {
                    LastName = "Perk"
                });
            });
            exception.ValidationErrors.ShouldContain(x => x.MemberNames.Any(y => y == "FirstName"));
        }

        [Fact]
        public async Task Should_Not_Create_A_Author_Without_LastName()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _authorService.CreateAsync(new Books.CreateUpdateAuthorDto
                {
                    FirstName = "Mücahid"
                });
            });
            exception.ValidationErrors.ShouldContain(x => x.MemberNames.Any(y => y == "LastName"));
        }

    }
}
