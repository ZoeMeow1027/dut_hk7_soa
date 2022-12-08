using MVC_CS_API.DTO;

namespace MVC_CS_API.Services
{
    public interface IMemberService
    {
        public List<MemberDTO> GetMembers();

        public MemberDTO GetMember(string username);
    }
}
