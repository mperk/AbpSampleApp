using SampleApp.Books;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SampleApp.Services
{
    public interface IAuthorService : IAsyncCrudAppService<
            AuthorDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAuthorDto,
            CreateUpdateAuthorDto>
    {
    }
}
