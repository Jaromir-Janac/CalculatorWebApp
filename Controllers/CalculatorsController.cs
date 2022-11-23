using CalculatorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using org.matheval;
using Expression = org.matheval.Expression;
using CalculatorWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json.Linq;
using CalculatorWebApp.Models;

namespace Kalkulacka.Controllers {
    public class CalculatorsController : Controller {
        private readonly ApplicationDbContext _context;

        public CalculatorsController(ApplicationDbContext context) {
            _context = context;
        }
        public string Calculate(string input) {
            string result = "";
            if (input != null) {
                result = new Expression(input).Eval().ToString();
            }
            return result;
        }
        public async Task<IActionResult> Index(string result = "") {
            ViewBag.History = (await _context.Results.ToListAsync()).TakeLast(10);
            ViewBag.Result = result;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Input")] Calculator calculator) {
            if (ModelState.IsValid) {
                var result = Calculate(calculator.Input);
                calculator.Input += $" = {result}";
                _context.Add(calculator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { result = result });
            }
            return View("Index");
        }
    }
}

