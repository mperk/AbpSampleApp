using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AutoMapper;

namespace SampleApp.Books
{
    [AutoMapFrom(typeof(Author))]
    public class AuthorDto : AuditedEntityDto<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
