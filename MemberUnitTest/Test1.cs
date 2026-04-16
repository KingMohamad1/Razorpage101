using SailClubLibrary.Models;
using SailClubLibrary.Services;
using System.Threading.Tasks;

namespace MemberUnitTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            //Arrange
            Member John = new Member(1,"Alfred","Saudi","131413131","Røstump 242","Roskilde","gord@gmail.com",MemberType.Adult,MemberRole.Member);
            MemberRepository mrepo = new MemberRepository();

            //Act
            await mrepo.AddMember(John);
            //Assert
            var members = await mrepo.GetAllMembers();
            Assert.IsTrue(members.Any(john => john.Mail == "gord@gmail.com"));
        }
    }
}
