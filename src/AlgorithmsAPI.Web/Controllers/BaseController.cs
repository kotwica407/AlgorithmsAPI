using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmsAPI.Web.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class BaseController : ControllerBase
    {
        [HttpGet("info")]
        public ActionResult<string> Info()
        {
            Assembly assembly = typeof(Startup).Assembly;

            DateTime creationDate = System.IO.File.GetCreationTime(assembly.Location);
            string version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {creationDate}");
        }
    }
}