﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// using Frames.Web.Models;
using Microsoft.Extensions.Logging;

namespace Frames.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}