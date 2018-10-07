using Microsoft.AspNetCore.Mvc;
using SampleApp.Books;
using SampleApp.Services;
using System.Threading.Tasks;

namespace SampleApp.Pages.Authors
{
    public class CreateModalModel : SampleAppPageModelBase
    {
        [BindProperty]
        public CreateUpdateAuthorDto Author { get; set; }

        private readonly IAuthorService _authorService;

        public CreateModalModel(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _authorService.CreateAsync(Author);
            return NoContent();
        }
    }
}