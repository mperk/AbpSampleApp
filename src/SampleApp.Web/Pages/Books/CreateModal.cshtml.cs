using Microsoft.AspNetCore.Mvc;
using SampleApp.Books;
using SampleApp.Services;
using System.Threading.Tasks;

namespace SampleApp.Pages.Books
{
    public class CreateModalModel : SampleAppPageModelBase
    {
        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }

        private readonly IBookAppService _bookAppService;

        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.CreateAsync(Book);
            return NoContent();
        }
    }
}