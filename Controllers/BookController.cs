using BooksAndAuthors.Classes;
using BooksAndAuthors.Data;
using BooksAndAuthors.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BooksAndAuthors.Controllers
{
    public class BookController : Controller
    {
        private readonly IGenericRepository<BookViewModel> _repo;
        private readonly IGenericRepository<Author> Authors;

        public BookController(IGenericRepository<BookViewModel> book, IGenericRepository<Author> authors)
        {

            _repo = book;
            Authors = authors;
        }
        // GET: BookController
        public ActionResult Index()
        {
            return View(_repo.GetAllIncluding(b => b.Author));
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetIncluding(id, a => a.Author));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewBag.Authors = new SelectList(Authors.GetAll(), "Id", "DisplayName");
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("AuthorId, Id, Title, Description, Release")] BookViewModel book)
        {
            try
            {
                book.Author = Authors.Get(book.AuthorId);

                if (ModelState.IsValid)
                {
                    _repo.Add(book);
                    return RedirectToAction(nameof(Index));

                }
                return View(book);

            }
            catch
            {
                return View(book);
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Authors = new SelectList(Authors.GetAll(),"Id", "DisplayName");
            return View(_repo.GetIncluding(id, book => book.Author));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken] //Vad ska man få ändra här? Titel, Författare, Beskrivning, Releasedate
        public ActionResult Edit(int id, [Bind("AuthorId, Id, Title, Description, Release")] BookViewModel book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    _repo.Update(book);
                    return RedirectToAction(nameof(Index));

                }
                return View(book);
            }
            catch
            {
                return View(book);
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.Get(id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BookViewModel book)
        {
            try
            {
                _repo.Delete(_repo.Get(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
