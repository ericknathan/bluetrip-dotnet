using Bluetrip.Data;
using Bluetrip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

namespace Bluetrip.Controllers;
public class PontoTuristicoController : Controller
{
    private readonly ApplicationDbContext _context;

    public PontoTuristicoController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.PontoTuristico.Include(p => p.Endereco).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(PontoTuristicoModel pontoTuristico)
    {
        if (ModelState.IsValid)
        {
            var endereco = _context.Endereco.Add(pontoTuristico.Endereco);
            _context.SaveChanges();

            pontoTuristico.EnderecoId = endereco.Entity.EnderecoId;

            _context.PontoTuristico.Add(pontoTuristico);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(pontoTuristico);
    }

    public IActionResult Edit(int id)
    {
        var pontoTuristico = _context.PontoTuristico.Include(p => p.Endereco).FirstOrDefault(p => p.PontoTuristicoId == id);

        if(pontoTuristico == null)
        {
            return NotFound();
        }

        return View(pontoTuristico);
    }

    [HttpPost]
    public IActionResult Edit(PontoTuristicoModel pontoTuristico)
    {
        if (ModelState.IsValid)
        {
            _context.Endereco.Update(pontoTuristico.Endereco);
            _context.PontoTuristico.Update(pontoTuristico);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(pontoTuristico);
    }

    public IActionResult Delete(int id)
    {
        var pontoTuristico = _context.PontoTuristico.Find(id);

        if(pontoTuristico == null)
        {
            return NotFound();
        }

        return View(pontoTuristico);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var pontoTuristico = _context.PontoTuristico.Find(id);

        if(pontoTuristico == null)
        {
            return NotFound();
        }

        _context.PontoTuristico.Remove(pontoTuristico);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
