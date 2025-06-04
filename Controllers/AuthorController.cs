using AutoMapper;
using BooksAndAuthors.Classes;
using BooksAndAuthors.Data;
using BooksAndAuthors.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BooksAndAuthors.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IGenericRepository<Author> _repo;
        private readonly IMapper _mapper;
        public AuthorController(IGenericRepository<Author> genericRepository, IMapper mapper)
        {
            _repo = genericRepository;
            _mapper = mapper;
        }

        // GET: AuthorController
        public ActionResult Index()
        {
            
            return View(_mapper.Map<List<AuthorViewModel>>(_repo.GetAll()));
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {

            var authorWithBooks = _repo.GetIncluding(id, a => a.Books);
            ViewBag.Titles = string.Join(", ", authorWithBooks.Books);

            AuthorViewModel author = _mapper.Map<AuthorViewModel>(authorWithBooks);
            return View(author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id", "FirstName", "LastName")] AuthorViewModel author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Add(_mapper.Map<Author>(author));
                    return RedirectToAction(nameof(Index));
                }

                return View(author);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_mapper.Map<AuthorViewModel>(_repo.Get(id)));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id", "FirstName", "LastName")] AuthorViewModel authorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var author = _repo.Get(id);
                    _mapper.Map(authorVM, author);
                    _repo.Update(author);
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    return View(authorVM);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_mapper.Map<AuthorViewModel>(_repo.Get(id)));
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AuthorViewModel authorViewModel)
        {
            try
            {
                _repo.Delete(_mapper.Map<Author>(authorViewModel));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
