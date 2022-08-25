using NhlStatsCrm.Application.Dto;

namespace NhlStatsCrm.Application.Features.Players.GetAllPlayersByAltKey
{
	public class GetAllPlayersByPlayerAltKeyQuery : IRequest<PlayerDto>
	{
		public string PlayerId { get; }

		public GetAllPlayersByPlayerAltKeyQuery (string playerId)
		{
			PlayerId = playerId;
		}
	}
}