using Bluetrip.Data;
using Bluetrip.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bluetrip.Controllers;
public class TuristaController : Controller
{
    private readonly ApplicationDbContext _context;

    public TuristaController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Turista.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TuristaModel turista)
    {
        if (ModelState.IsValid)
        {
            _context.Turista.Add(turista);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(turista);
    }

    public IActionResult Edit(int id)
    {
        var turista = _context.Turista.Find(id);

        if(turista == null)
        {
            return NotFound();
        }

        return View(turista);
    }

    [HttpPost]
    public IActionResult Edit(TuristaModel turista)
    {
        if (ModelState.IsValid)
        {
            _context.Turista.Update(turista);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(turista);
    }

    public IActionResult Delete(int id)
    {
        var turista = _context.Turista.Find(id);

        if(turista == null)
        {
            return NotFound();
        }

        return View(turista);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var turista = _context.Turista.Find(id);

        if(turista == null)
        {
            return NotFound();
        }

        _context.Turista.Remove(turista);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
