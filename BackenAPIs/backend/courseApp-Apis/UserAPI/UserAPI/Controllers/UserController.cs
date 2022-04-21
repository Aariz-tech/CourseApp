using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Services;
using UserAPI.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly ITokenGenerator _tokenGenerator;
        
        public UserController(IUserService userService, ITokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }

        [Route("getAllUsers")]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            List<User> users = _userService.GetAllUsers();
            return Ok(users);
        }


        [AllowAnonymous]
        [Route("registerUser")]
        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            bool userStatus = _userService.RegisterUser(user);
            return Ok(userStatus);
        }

        [Route("getUserById{id:int}")]
        [HttpGet]
        public ActionResult GetUserBuId(int id)
        {
            User user = _userService.GetUserById(id);
            return Ok(user);
        }

        [Route("deleteUser{id:int}")]
        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            bool deleteStatus = _userService.DeleteUser(id);
            return Ok(deleteStatus);
        }

        [Route("blockUnBlockUser{id:int}")]
        [HttpPut]
        public ActionResult BlockUnBlockUser(int id,bool blockUnBlockUser)
        {
            bool blockUnBlockStatus = _userService.BlockAndUnBlockUser(id,blockUnBlockUser);
            return Ok(blockUnBlockStatus);
        }

        [Route("editUser{id:int}")]
        [HttpPut]
        public ActionResult EditUser(int id, User user)
        {
            bool userEditStatus = _userService.EditUser(id, user);
            return Ok(userEditStatus);
        }


        [AllowAnonymous]
        [Route("loginUser")]
        [HttpPost]
        public ActionResult LoginUser(LoginUser loginUser)
        {
            User user = _userService.Login(loginUser);
            string userToken = _tokenGenerator.GenerateToken(user.Id,user.UserName,user.Email);
            return Ok(userToken);
        }
    }
}
