﻿using System.Diagnostics;
using Lab7.Areas.Identity.Data;
using Lab7.Data;
using Microsoft.AspNetCore.Mvc;
using Lab7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ChinookDbContext _chinook;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, ChinookDbContext chinook, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _chinook = chinook;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View(_chinook.Customers.ToList());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Authorize]
    public async Task<IActionResult> MyOrders()
    {
        var user = await _userManager.GetUserAsync(User);
        var customerId = user.CustomerId;
        return View(await _chinook.Invoices.Where(x =>
            x.CustomerId == customerId).ToListAsync());
    }

    [Authorize]
    public async Task<IActionResult> OrderDetails(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        var customerId = user.CustomerId;
        var invoice = await _chinook.Invoices
            .Include(x => x.InvoiceLines)
            .ThenInclude(x => x.Track)
            .FirstOrDefaultAsync(x => x.CustomerId == customerId && x.InvoiceId == id);
        return invoice is null ? NotFound() : View(invoice);
    }

}
