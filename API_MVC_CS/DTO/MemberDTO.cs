namespace MVC_CS_API.DTO
{
    public class MemberDTO
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public int Ages { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string KnownAs { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string Introduction { get; set; }

        public string Avatar { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}