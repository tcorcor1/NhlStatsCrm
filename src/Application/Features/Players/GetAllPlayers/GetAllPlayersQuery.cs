using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Players.GetAllPlayers
{
	public class GetAllPlayersQuery : IRequest<IEnumerable<Player?>>
	{
		public GetAllPlayersQuery ()
		{
		}
	}
}