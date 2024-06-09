using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EmployeesPruebas.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesPruebas.Models;

namespace EmployeesPruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MainContext _context;

        public EmployeesController(MainContext context)
        {
            _context = context;
        }
        // GET: api/Employees
        [HttpGet]
        public IActionResult Get()
        {
            var ConsultaDapper = new ConsultaDapper();
            ConsultaDapper.consultaSQL = @"select Id,CompanyId,CreatedOn,DeletedOn,Email,Fax,Name,Lastlogin,Password,PortalId,RoleId,StatusId,Telephone,UpdatedOn,Username FROM main.employee";
            return Ok(ConsultaDapper.ConectarBD());

        }
        // GET: api/Employees/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)

        {
            var ConsultaDapper = new ConsultaDapper();
            Console.Write(id.ToString());
            ConsultaDapper.consultaSQL = @"select Id,CompanyId,CreatedOn,DeletedOn,Email,Fax,Name,Lastlogin,Password,PortalId,RoleId,StatusId,Telephone,UpdatedOn,Username FROM main.employee where Id = " + id;
            return Ok(ConsultaDapper.ConectarBD());

        }


        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

    public async Task<IActionResult> Put(int id, [FromBody] Employee employee)
        {
            var employeeInfo = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employeeInfo == null)
                return NotFound();
            employeeInfo.Name = employee.Name;
            employeeInfo.CompanyId = employee.CompanyId;
            employeeInfo.Fax = employee.Fax;
            employeeInfo.Email = employee.Email;
            employeeInfo.DeletedOn = employee.DeletedOn;
            employeeInfo.CreatedOn = employee.CreatedOn;
            employeeInfo.UpdatedOn = employee.UpdatedOn;
            employeeInfo.Lastlogin = employee.Lastlogin;
            employeeInfo.Password = employee.Password;
            employeeInfo.PortalId = employee.PortalId;
            employeeInfo.RoleId = employee.RoleId;
            employeeInfo.StatusId = employee.StatusId;
            employeeInfo.Telephone = employee.Telephone;
            employeeInfo.UpdatedOn = employee.UpdatedOn;
            employeeInfo.Username = employee.Username;
            _context.Attach(employeeInfo);
            await _context.SaveChangesAsync();
            return Ok(employeeInfo);

        }
        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Employee>> PostEmployee(Models.Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
