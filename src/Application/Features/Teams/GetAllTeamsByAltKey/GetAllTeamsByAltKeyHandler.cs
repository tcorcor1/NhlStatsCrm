using NhlStatsCrm.Domain.Entities.Nhl;
using NhlStatsCrm.Application.Dto;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeamsByAltKey
{
	public class GetAllTeamsByAltKeyHandler : IRequestHandler<GetAllTeamsByAltKeyQuery, TeamDto?>
	{
		private readonly IDynamicsRepository<Team> _teamsRepository;
		private readonly IMapper _mapper;

		public GetAllTeamsByAltKeyHandler (IDynamicsRepository<Team> teamsRepository, IMapper mapper)
		{
			_teamsRepository = teamsRepository;
			_mapper = mapper;
		}

		public async Task<TeamDto?> Handle (GetAllTeamsByAltKeyQuery request, CancellationToken cancellationToken)
		{
			var response = await _teamsRepository.GetByAltKeyAsync(request.TeamId);

			var entityAttrDictionary = response.Entities.First()
				.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

			return _mapper.Map<TeamDto>(entityAttrDictionary);
		}
	}
}