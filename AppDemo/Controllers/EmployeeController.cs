using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDemo.Models;
using AppDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [Route("[Action]")]
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage));
                    return BadRequest(message);
                }
                await _repo.Add(model);
                return StatusCode(200, await _repo.GetAll());
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [Route("[Action]")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return StatusCode(200, await _repo.GetAll());
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [Route("[Action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return StatusCode(200, await _repo.GetById(id));
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [Route("[Action]")]
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage));
                    return BadRequest(message);
                }
                var rec = await _repo.GetById(model.Id);
                if(rec == null)
                {
                    return BadRequest(StatusCodes.Status404NotFound);
                }
                return StatusCode(200, await _repo.Update(model));
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [Route("[Action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var rec = await _repo.GetById(id);
                if (rec == null)
                {
                    return BadRequest(StatusCodes.Status404NotFound);
                }
                return StatusCode(200, await _repo.Delete(id));
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
    }
}