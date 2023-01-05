using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using CalculatorApp.Data;
using CalculatorApp.Models;
using CalculatorLogic;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorDbContext _calculatorContext;

        public CalculatorController(CalculatorDbContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }
        public async Task<IActionResult> Index(string result = "")
        {
            ViewBag.History = (await _calculatorContext.Results.ToListAsync()).TakeLast(10);
            ViewBag.Result = result;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculation(CalculatorViewModel calculatorViewModel)
        {
            if (ModelState.IsValid)
            {
                var instance = calculatorViewModel.Input;
                var isRounded = Convert.ToBoolean(calculatorViewModel.IsRounded);
                Logic calcLogic = new Logic(instance, isRounded);
                calcLogic.Calculate();
                var result = calcLogic.Result.Replace(",", ".");
                instance = calcLogic.Instance.Replace(",", ".");
                CalculatorModel calculatorModel = new CalculatorModel();
                calculatorModel.Input = instance;
                _calculatorContext.Add(calculatorModel);
                await _calculatorContext.SaveChangesAsync();
                return RedirectToAction("Index", new { result });
            }
            return View("Index");
        }
    }
}
