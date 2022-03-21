using CreciSP.Domain.Enum;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.UserRepository;
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CreciSP.Test
{
    public class AutoMockerFixture
    {
        public AutoMocker mocker;
        public User user;
        public User userInactive;

        public AutoMockerFixture()
        {
            InitializeObjects();
        }

        private void InitializeObjects()
        {
            mocker = new AutoMocker();

            user = new User(new Guid(), "Teste", "01234567890", "teste@teste.com", UserTypeEnum.Common, true, "0123456789");
            userInactive = new User(new Guid(), "Teste", "01234567890", "teste@teste.com", UserTypeEnum.Common, false, "0123456789");
        }

        private void SetMocks()
        {
            //mocker.GetMock<IUserRepository>().Setup(x => x)
            //    .Returns(new List<User>() { user }.AsQueryable());
        }
    }
}
