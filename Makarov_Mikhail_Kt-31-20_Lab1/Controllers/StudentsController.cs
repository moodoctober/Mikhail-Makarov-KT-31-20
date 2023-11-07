using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Makarov_Mikhail_Kt_31_20_Lab1.Database;
using Makarov_Mikhail_Kt_31_20_Lab1.Models;
using Makarov_Mikhail_Kt_31_20_Lab1.Filters.StudentFilters;
using Makarov_Mikhail_Kt_31_20_Lab1.interfaces.StudentInterfaces;

namespace Makarov_Mikhail_Kt_31_20_Lab1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;

        private readonly IStudentService _studentFilter;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentFilter)
        {
            _logger = logger;
            _studentFilter = studentFilter;
        }

        [HttpPost(Name = "GetStudentByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentFilter.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }
    }
}

       
