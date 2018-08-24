using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MECCHAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MECCHAN.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly MECCHANDbContext _context;
        private Random _random = new Random();
        private string[] mockupMessages = {
            "The recent feast in Newthorpe was disrupted by a unicorn.",
            "The town of Kedwick is suffering a whale infestation.",
            "The hiding place of The Rantghost Gang can be found in the the ruins.",
            "There's a reward of 5 gold for duck skins.",
            "The recent gala in Inkchester was disrupted by a centaur.",
            "There's a reward of 2 gold for donkey skins.",
            "The recent fete in Latchpool was disrupted by a eagle.",
            "Bishop Dwafur is visiting town very soon.",
            "The local masons are planning a strike.",
            "The recent pageant in Innsborough was disrupted by a unicorn.",
            "Leprosy has struck the town of Aldden.",
            "Marquis K'mtar, a local wizard needs the heart of a centaur for research purposes.",
            "Emma Heath has discovered the location of The Illuminated Tower of The Eldritch Cult.",
            "Nolin Copperaxe the gladiator has inherited a fortune.",
            "The hiding place of The Bonestalker Band can be found in the the mountains.",
            "The town of Marksthorpe is suffering a roc infestation.",
            "The ship The Jolly Delight has docked nearby.",
            "The port is off.",
            "A monster guards The Numinous Depths of Iron.",
            "A number of people have been complaining of stomach ache and nausea"
        };
        private string[] mockupAuthors = {
            "Boris",
            "Philip",
            "Sebastian",
            "Oskar",
            "Kalle",
            "Henrietta",
            "Melvin",
            "Jonas",
            "Patrik",
            "Andreas"
        };
        private string[] colorPalette = {
            "8c13b6",
            "ee7b07",
            "bd2020",
            "13b69d",
            "ffaa07",
            "3864db",
            "67b22d"
        };

        public CreateModel(MECCHANDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            int loops = 100;
            for (int i = 0; i < loops; i++)
            {
                Message message = new Message();

                message.Author = mockupAuthors[_random.Next(0, mockupAuthors.Length)];
                message.Text = mockupMessages[_random.Next(0, mockupMessages.Length)];
                message.Color = colorPalette[_random.Next(0, colorPalette.Length)];
                message.Date = DateTime.Now;
                message.Rating = 0;
                _context.Message.Add(message);


                
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}