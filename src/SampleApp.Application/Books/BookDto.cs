﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AutoMapper;

namespace SampleApp.Books
{
    [AutoMapFrom(typeof(Book))]
    public class BookDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        public Guid? AuthorId { get; set; }

    }
}
