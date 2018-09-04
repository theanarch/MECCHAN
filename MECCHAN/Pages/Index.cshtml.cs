using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MECCHAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MECCHAN.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MECCHANDbContext _context;
        public List<Message> Messages { get; set; }
        private string[] ColorPalette { get; } = {
            "8c13b6", "ee7b07", "bd2020", "13b69d", "ffaa07", "3864db", "67b22d" };
        private Random Random { get; set; }

        public IndexModel(MECCHANDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            //Messages = _context.Message.Where(m => m.Id > 0).ToList();
            Messages = _context.Message.OrderByDescending(m => m.Date).Take(5).ToList();
        }

        public JsonResult OnGetPagination(int id)
        {
            //string preText = "messageId-";
            //string id = textId.Substring(preText.Length);
            //int lastId = Convert.ToInt32(id);
            //int numberOfNewMessages = 20;
            var totalCount = _context.Message.ToArray().Length;

            //if (totalCount - id > -1)
            //{
                var result = _context.Message.OrderByDescending(m => m.Date).Skip(totalCount - id).Take(5).ToList();
            //}
            //else
            //{
            //    var result = " ";
            //}

            return new JsonResult(result);
        }

        [BindProperty]
        public Message Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Random = new Random();
            Message.Color = ColorPalette[Random.Next(0, ColorPalette.Length)];
            Message.Date = DateTime.Now;
            _context.Message.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
