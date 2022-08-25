using NhlStatsCrm.Application.Dto;

namespace NhlStatsCrm.Application.Features.Players.GetAllPlayers
{
	public class GetAllPlayersQuery : IRequest<IEnumerable<PlayerDto>>
	{
		public GetAllPlayersQuery ()
		{
		}
	}
}