using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using testapi.Data;
using testapi.Dtos;
using testapi.Models;

namespace testapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CarController : ControllerBase 
    {
        private readonly DataContext _context;

        public CarController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetCars()
        {
            var cars = await _context.Cars.ToListAsync();

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarsById(int id)
        {
            var car = await _context.Cars.Where(x => x.Id == id).ToListAsync();

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Register (CarForRegisterDto carForRegisterDto)
        {
            var carToCreate = new Car 
            {
                Name = carForRegisterDto.Name,
                Color = carForRegisterDto.Color,
                Power = carForRegisterDto.Power,
            };

            await _context.AddAsync(carToCreate);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}

