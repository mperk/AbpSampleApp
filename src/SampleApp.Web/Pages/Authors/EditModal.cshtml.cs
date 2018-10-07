using Microsoft.AspNetCore.Mvc;
using SampleApp.Books;
using SampleApp.Services;
using System;
using System.Threading.Tasks;

namespace SampleApp.Pages.Authors
{
    public class EditModalModel : SampleAppPageModelBase
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateAuthorDto Author { get; set; }

        private readonly IAuthorService _authorService;

        public EditModalModel(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task OnGetAsync()
        {
            var authorDto = await _authorService.GetAsync(Id);
            Author = ObjectMapper.Map<AuthorDto, CreateUpdateAuthorDto>(authorDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _authorService.UpdateAsync(Id, Author);
            return NoContent();
        }
    }
}