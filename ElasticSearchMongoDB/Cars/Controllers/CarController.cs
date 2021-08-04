using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cars.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarBL _carService;

        private readonly string _secret;
        private readonly string _issuer;

        public CarController(ICarBL carService, IConfiguration config)
        {
            _carService = carService;
            _secret = config.GetSection("Jwt").GetSection("Key").Value;
            _issuer = config.GetSection("Jwt").GetSection("Issuer").Value;
        }

        private string GetTokenType()
        {
            string name = User.FindFirst("Name").Value;
            return name;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _issuer,
                    Audience = _issuer,
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("Name", "Prashik"),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(1440),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var cars = _carService.Get();
                return this.Ok(new { success = true, Token = tokenString, cars });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public IActionResult Get(string id)
        {
            try
            {
                if (GetTokenType() != "Prashik")
                {
                    return this.BadRequest(new { success = false, message = "Wrong Token" });
                }

                var car = _carService.Get(id);

                if (car == null)
                {
                    return this.BadRequest(new { success = false, message = "No Car Found" });
                }

                return this.Ok(new { success = true, car });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            try
            {
                if (GetTokenType() != "Prashik")
                {
                    return this.BadRequest(new { success = false, message = "Wrong Token" });
                }
                _carService.Create(car);

                return this.Ok(new { success = true, message = "Added new Car to data" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Car carIn)
        {
            try 
            {
                if (GetTokenType() != "Prashik")
                {
                    return this.BadRequest(new { success = false, message = "Wrong Token" });
                }

                var car = _carService.Get(id);

                if (car == null)
                {
                    return NotFound();
                }

                _carService.Update(id, carIn);

                return this.Ok(new { success = true, message = "Car Updated" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (GetTokenType() != "Prashik")
                {
                    return this.BadRequest(new { success = false, message = "Wrong Token" });
                }

                var car = _carService.Get(id);

                if (car == null)
                {
                    return NotFound();
                }

                _carService.Remove(car.Id);

                return this.Ok(new { success = true, message = "Car Deleted" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
