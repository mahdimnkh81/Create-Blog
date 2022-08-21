using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Blog.Models;

namespace Razor_Blog.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleViewModel> articleViewModel{ get; set; }
        public  BlogContext _Context{ get; set; }

        public IndexModel(BlogContext context)
        {
            _Context = context;
        }

        public void OnGet()
        {
            articleViewModel = _Context.Articles.Where(x => x.IsDeleted == false)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ShortDescription = x.ShortDescription,
                }).OrderByDescending(x => x.Id).ToList();
        }

        public IActionResult OnGetDelete(int id)
        {
            var article = _Context.Articles.First(x => x.Id == id);
            article.IsDeleted = true;
            _Context.SaveChanges();
            return RedirectToPage("./Index");
        }
        
    }
}