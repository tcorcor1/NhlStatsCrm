using NhlStatsCrm.Application.Dto;
using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeams
{
	public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsQuery, IEnumerable<TeamDto>>
	{
		private readonly IDynamicsRepository<Team> _teamsRepository;
		private readonly IMapper _mapper;

		public GetAllTeamsHandler (IDynamicsRepository<Team> teamsRepository, IMapper mapper)
		{
			_teamsRepository = teamsRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<TeamDto>> Handle (GetAllTeamsQuery request, CancellationToken cancellationToken)
		{
			var response = await _teamsRepository.GetAllAsync();

			return response.Entities.Select(entity =>
			{
				var entityAttrDictionary = entity.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

				return _mapper.Map<TeamDto>(entityAttrDictionary);
			});
		}
	}
}