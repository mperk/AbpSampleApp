using SampleApp.Books;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SampleApp.Services
{
    public class AuthorService : AsyncCrudAppService<Author, AuthorDto, Guid, PagedAndSortedResultRequestDto,
                            CreateUpdateAuthorDto, CreateUpdateAuthorDto>, IAuthorService
    {
        public AuthorService(IRepository<Author, Guid> repository)
              : base(repository)
        {

        }
    }
}

