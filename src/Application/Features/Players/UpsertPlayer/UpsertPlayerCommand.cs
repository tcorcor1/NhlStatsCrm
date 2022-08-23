using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Players.UpsertPlayer
{
	public class UpsertPlayerCommand : IRequest<Guid?>
	{
		public Player Player { get; }

		public UpsertPlayerCommand (Player player)
		{
			Player = player;
		}
	}
}