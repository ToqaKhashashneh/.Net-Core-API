using AngularApp2.Server.Models;
using AngularApp2.Server.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp2.Server.GeneralIDataService
{
    public interface IDataService
    {



        public bool LoginUser(LoginUserDto Userdto);

        public List<Regestration> ShowUsers();

        public bool LoginUser(string Email, string Password);

        public bool Register(RegestrationDto user);
    }
}
