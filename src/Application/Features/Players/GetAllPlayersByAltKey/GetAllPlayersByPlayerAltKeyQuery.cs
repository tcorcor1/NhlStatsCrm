using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Players.GetAllPlayersByAltKey
{
	public class GetAllPlayersByPlayerAltKeyQuery : IRequest<Player>
	{
		public string PlayerId { get; }

		public GetAllPlayersByPlayerAltKeyQuery (string playerId)
		{
			PlayerId = playerId;
		}
	}
}