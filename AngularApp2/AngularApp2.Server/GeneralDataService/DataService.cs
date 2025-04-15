using AngularApp2.Server.Models;
using AngularApp2.Server.Models.Dto;
using AngularApp2.Server.GeneralIDataService;
using Microsoft.Identity.Client;

namespace AngularApp2.Server.GeneralDataService
{
    public class DataService : IDataService
    {

        private readonly MyDbContext _db;

        public DataService(MyDbContext db)
        {
            _db = db;
        }

     


        public bool LoginUser(string Email, string Password)
        {
            var existUser = _db.Regestrations.FirstOrDefault(u => u.Email == Email && u.Password == Password);
            if (existUser == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public bool LoginUser(LoginUserDto Userdto)
        {
            var NewUser = _db.Regestrations.FirstOrDefault(u => u.Email == Userdto.Email && u.Password == Userdto.Password);
            if (NewUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

            public List<Regestration> ShowUsers()
             {
                var users = _db.Regestrations.ToList();
                return users;
              }


        public bool Register(RegestrationDto user) {
        
            var esxistUser = _db.Regestrations.FirstOrDefault(u => u.Email == user.Email);
            if (esxistUser != null)
            {
                return false;
            }
            else
            {
                var NewUser = new Regestration()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password
                };

                _db.Regestrations.Add(NewUser);
                _db.SaveChanges();
                return true;
            }

        }


    }


}