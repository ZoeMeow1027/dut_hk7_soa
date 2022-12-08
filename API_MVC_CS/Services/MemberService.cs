using AutoMapper;
using AutoMapper.QueryableExtensions;
using MVC_CS_API.Data;
using MVC_CS_API.Data.Entities;
using MVC_CS_API.DTO;

namespace MVC_CS_API.Services
{
    public class MemberService : IMemberService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MemberService(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public MemberDTO GetMember(string username)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.Username == username);
            if (user == null)
                return null;
            return _mapper.Map<User, MemberDTO>(user);
/*            return new MemberDTO
            {
                Avatar = user.Avatar,
                City = user.City,
                CreatedAt = user.CreatedAt,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Gender = user.Gender,
                Introduction = user.Introduction,
                KnownAs = user.KnownAs,
                Username = user.Username,
            };*/
        }

        public List<MemberDTO> GetMembers()
        {
            /*            return _context.AppUsers.Select(
                            user => new MemberDTO
                            {
                                Avatar = user.Avatar,
                                City = user.City,
                                CreatedAt = user.CreatedAt,
                                DateOfBirth = user.DateOfBirth,
                                Email = user.Email,
                                Gender = user.Gender,
                                Introduction = user.Introduction,
                                KnownAs = user.KnownAs,
                                Username = user.Username,
                            }
                        ).ToList();
            */
            // return _context.AppUsers.ProjectTo<MemberDTO>(_mapper.ConfigurationProvider).ToList();

            return _mapper.Map<List<User>, List<MemberDTO>>(_context.AppUsers.ToList());
        }
    }
}
