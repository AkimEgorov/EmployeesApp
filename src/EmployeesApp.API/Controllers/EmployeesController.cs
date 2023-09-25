using AutoMapper;
using EmployeesApp.API.Dtos.Employee;
using EmployeesApp.Domain.Interfaces;
using EmployeesApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : MainController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IMapper mapper,  IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAll();
            return Ok(_mapper.Map<IEnumerable<EmployeeResultDto>>(employees));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetById(id);

            if (employee == null) return NotFound();

            return Ok(_mapper.Map<EmployeeResultDto>(employee));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(EmployeeAddDto employeeDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var employee = _mapper.Map<Employee>(employeeDto);
            var employeeResult = await _employeeService.Add(employee);

            if (employeeResult == null) return BadRequest();

            return Ok(_mapper.Map<EmployeeResultDto>(employeeResult));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, EmployeeEditDto employeeDto)
        {
            //if (id != employeeDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            employeeDto.Id = id;

            await _employeeService.Update(_mapper.Map<Employee>(employeeDto));

            return Ok(employeeDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null) return NotFound();

            var result = await _employeeService.Remove(employee);

            if (!result) return BadRequest();

            return Ok();
        }
    }
}
