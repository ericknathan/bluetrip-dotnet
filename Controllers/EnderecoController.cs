using Bluetrip.Data;
using Bluetrip.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bluetrip.Controllers;
public class EnderecoController : Controller
{
    private readonly ApplicationDbContext _context;

    public EnderecoController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Endereco.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(EnderecoModel endereco)
    {
        if (ModelState.IsValid)
        {
            _context.Endereco.Add(endereco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(endereco);
    }

    public IActionResult Edit(int id)
    {
        var endereco = _context.Endereco.Find(id);

        if(endereco == null)
        {
            return NotFound();
        }

        return View(endereco);
    }

    [HttpPost]
    public IActionResult Edit(EnderecoModel endereco)
    {
        if (ModelState.IsValid)
        {
            _context.Endereco.Update(endereco);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(endereco);
    }

    public IActionResult Delete(int id)
    {
        var endereco = _context.Endereco.Find(id);

        if(endereco == null)
        {
            return NotFound();
        }

        return View(endereco);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var endereco = _context.Endereco.Find(id);

        if(endereco == null)
        {
            return NotFound();
        }

        _context.Endereco.Remove(endereco);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
