using Bluetrip.Data;
using Bluetrip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bluetrip.Controllers;
public class AgendamentoController : Controller
{
    private readonly ApplicationDbContext _context;

    public AgendamentoController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Agendamento.ToList());
    }

    public IActionResult Create()
    {
        ViewBag.Turistas = _context.Turista.ToList();
        ViewBag.Eventos = _context.Evento.ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Create(AgendamentoModel agendamento)
    {
        try
        {
            _context.Agendamento.Add(agendamento);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewBag.Turistas = _context.Turista.ToList();
            ViewBag.Eventos = _context.Evento.ToList();

            Debug.WriteLine(e.Message);
            return View(agendamento);
        }
    }

    public IActionResult Edit(int id)
    {
        var agendamento = _context.Agendamento.Find(id);

        if(agendamento == null)
        {
            return NotFound();
        }


        ViewBag.Turistas = _context.Turista.ToList();
        ViewBag.Eventos = _context.Evento.ToList();

        return View(agendamento);
    }

    [HttpPost]
    public IActionResult Edit(AgendamentoModel agendamento)
    {
        try
        {
            _context.Agendamento.Update(agendamento);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewBag.Turistas = _context.Turista.ToList();
            ViewBag.Eventos = _context.Evento.ToList();

            Debug.WriteLine(e.Message);
            return View(agendamento);
        }
    }

    public IActionResult Delete(int id)
    {
        var agendamento = _context.Agendamento.Find(id);

        if(agendamento == null)
        {
            return NotFound();
        }

        return View(agendamento);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var agendamento = _context.Agendamento.Find(id);

        if(agendamento == null)
        {
            return NotFound();
        }

        _context.Agendamento.Remove(agendamento);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
