using Bluetrip.Data;
using Bluetrip.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bluetrip.Controllers;
public class EventoController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventoController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Evento.ToList());
    }

    public IActionResult Create()
    {
        ViewBag.PontosTuristicos = _context.PontoTuristico.ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Create(EventoModel evento)
    {
        try
        {
            _context.Evento.Add(evento);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } catch(Exception e)
        {
            ViewBag.PontosTuristicos = _context.PontoTuristico.ToList();

            Debug.WriteLine(e.Message);
            return View(evento);
        }
    }

    public IActionResult Edit(int id)
    {
        var evento = _context.Evento.Find(id);

        if(evento == null)
        {
            return NotFound();
        }

        ViewBag.PontosTuristicos = _context.PontoTuristico.ToList();

        return View(evento);
    }

    [HttpPost]
    public IActionResult Edit(EventoModel evento)
    {
        try
        {
            _context.Evento.Update(evento);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewBag.PontosTuristicos = _context.PontoTuristico.ToList();

            Debug.WriteLine(e.Message);
            return View(evento);
        }
    }

    public IActionResult Delete(int id)
    {
        var evento = _context.Evento.Find(id);

        if(evento == null)
        {
            return NotFound();
        }

        return View(evento);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var evento = _context.Evento.Find(id);

        if(evento == null)
        {
            return NotFound();
        }

        _context.Evento.Remove(evento);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
