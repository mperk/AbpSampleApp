using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.AutoMapper;

namespace SampleApp.Books
{
    [AutoMapTo(typeof(Author))]
    [AutoMapFrom(typeof(AuthorDto))]
    public class CreateUpdateAuthorDto
    {
        [Required]
        [StringLength(128)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        [MinLength(3)]
        public string LastName { get; set; }
    }
}
