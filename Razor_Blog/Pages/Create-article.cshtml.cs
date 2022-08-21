using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Blog.Models;

namespace Razor_Blog.Pages
{
    public class Create_articleModel : PageModel
    {
        public CreateArticle CreateArticle{ get; set; }
        public BlogContext _Context;
        [TempData]
        public string SuccessMessage{ get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public Create_articleModel(BlogContext context)
        {
            _Context = context;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateArticle createArticle)
        {
            if (ModelState.IsValid)
            {
                var article = new Article(createArticle.Title, createArticle.Picture, createArticle.PictureAlt,
                    createArticle.PictureTitle, createArticle.ShortDescription, createArticle.Body);
                _Context.Add(article);
                _Context.SaveChanges();
                SuccessMessage = "عملیات با موفقیت انجام شد";
                return RedirectToPage("./Index");
            }
            else
            {
                ErrorMessage = "اصلاعات را کامل وارد کنید";
                return Page();
            }
        }
    }
}
