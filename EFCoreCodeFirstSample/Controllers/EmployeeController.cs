using EFCoreCodeFirstSample.Filters;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EFCoreCodeFirstSample.Controllers
{
    [TypeFilter(typeof(AuthFilter))]
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IDataRepository<Employees> _dataRepository;

        public EmployeeController(IDataRepository<Employees> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Employees> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Employees employee = _dataRepository.Get(id);

            if (employee == null)
            {
                return NotFound(" EmployeeNotFound");
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employees employees)
        {
            if (employees == null || (employees.FirstName == null && employees.LastName == null))
            {
                return BadRequest("Employee passed is null.");
            }
            _dataRepository.Add(employees);
            return CreatedAtRoute("Get", new { Id = employees.EmployeeId }, employees);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Employees employees)
        {
            if (employees == null)
            {
                return BadRequest("Employee passed is null.");
            }
            Employees employeeToUpdate = _dataRepository.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("Employee details you wants to update not found");
            }

            _dataRepository.Update(employeeToUpdate, employees);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Employees employees = _dataRepository.Get(id);
            if (employees == null)
            {
                return NotFound("Employee details you wants to update not found");
            }
            _dataRepository.Delete(employees);
            return NoContent();
        }
    }
}
