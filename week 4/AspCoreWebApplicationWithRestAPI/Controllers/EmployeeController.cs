using AspCoreWebApplicationWithRestAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace AspCoreWebApplicationWithRestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="POC,Admin")]
    public class EmployeeController : ControllerBase
    {
        private static List<Models.Employee> employees = new List<Models.Employee>
        {
            new Models.Employee {
                Id = 1,
                Name = "Sunderesan",
                Salary = 7000000,
                Permanent = true,
                DateOfBirth = new DateTime(2005, 2, 14)
            },
            new Models.Employee {
                Id = 2,
                Name = "Suraj",
                Salary = 6000000,
                Permanent = false,
                DateOfBirth = new DateTime(2005, 6, 3)
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Models.Employee>> GetAllEmployees()
            => Ok(employees);

        [HttpGet("{id}")]
        public ActionResult<Models.Employee> GetEmployeeById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [HttpPost]
        public ActionResult CreateEmployee([FromBody] Models.Employee employee)
        {
            if (employee == null) return BadRequest("Employee data is null.");

            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]               // on success
        [ProducesResponseType(StatusCodes.Status400BadRequest)]      // invalid id or not found
        public ActionResult<Models.Employee> UpdateEmployee(int id, [FromBody] Models.Employee updatedEmployee)
        {
            //validate id > 0
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            //find existing
            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
            {
                // id > 0 but not in list
                return BadRequest("Invalid employee id");
            }

            //update fields from the input JSON
            existing.Name = updatedEmployee.Name;
            existing.Salary = updatedEmployee.Salary;
            existing.Permanent = updatedEmployee.Permanent;
            existing.DateOfBirth = updatedEmployee.DateOfBirth;

            //return the updated employee object
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();

            employees.Remove(emp);
            return NoContent();
        }

        private List<Models.Employee> GetStandardEmployeeList()
        {
            return new List<Models.Employee>
            {
                new Models.Employee {
                    Id = 1,
                    Name = "Alice",
                    Salary = 80000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1985, 4, 12)
                },
                new Models.Employee {
                    Id = 2,
                    Name = "Bob",
                    Salary = 75000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1990, 9, 23)
                }
            };
        }

        [HttpGet("standard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Models.Employee>> GetStandard()
        {
            var list = GetStandardEmployeeList();
            return Ok(list);
        }

        [HttpGet("error")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult TriggerError()
        {
            throw new InvalidOperationException("Test exception");
        }
    }
}
