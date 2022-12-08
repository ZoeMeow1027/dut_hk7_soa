using Microsoft.AspNetCore.Mvc;
using MVC_CS_API.DTO;
using MVC_CS_API.Services;

namespace MVC_CS_API.Controllers
{
    [Route("api/members")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        [HttpGet]
        public ActionResult<List<MemberDTO>> Get()
        {
            return memberService.GetMembers();
        }

        [HttpGet("{username}")]
        public ActionResult<MemberDTO> Get(string username)
        {
            var member = memberService.GetMember(username);
            return member == null ? NotFound() : Ok(member);
        }
    }
}
