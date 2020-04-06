using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthRoleBased.Controllers
{
    public class EmpController : Controller
    {
        
        [Authorize(Policy ="writepolicy")]
        public IActionResult Post()
        {
            return View();
        }
        [Authorize(Roles ="Expert")]
        public IActionResult Certified()
        {
            return View();
        }
    }
}