using InTech.Core.Entities;
using MediatR;

namespace InTech.Application.Queries
{
    public class GetUserByUsernameQuery : IRequest<User>
    {
        public string Username { get; private set; }

        public GetUserByUsernameQuery(string username)
        {
            this.Username = username;
        }
    }
}
