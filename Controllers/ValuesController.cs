using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TokenAuthentication.Model;
using TokenAuthentication.Service;

namespace TokenAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;

        public ValuesController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("test")]
        public ActionResult<string> test()
        {
            var user = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var user = Thread.CurrentPrincipal.Identity.Name;
            return "test " + user;
        }

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel model)
        {
            try
            {
                var userDataService = new UserDataService();
                var users = userDataService.GetUsers();
                var user = users.Find(u => u.Username == model.Username);

                if(user != null)
                {
                    //var identity = new GenericIdentity(user.Username);
                    //var principal = new GenericPrincipal(identity, new string[] { "admin" });

                    ////HttpContext.User = principal;
                    ////Thread.CurrentPrincipal = principal;

                    //_httpContext.HttpContext.User = principal;


                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, "aalu"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.Name, user.Username),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKey."));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "https://localhost:44364/",
                        audience: "https://localhost:44364/",
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(15),
                        signingCredentials: creds
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
            }
            catch (Exception ex)
            {

            }

            return BadRequest();
        }
    }
}
