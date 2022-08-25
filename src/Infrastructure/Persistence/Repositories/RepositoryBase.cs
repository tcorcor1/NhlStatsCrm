using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using NhlStatsCrm.Application.Common.Exceptions;

namespace NhlStatsCrm.Infrastructure.Persistence.Repositories
{
	public abstract class RepositoryBase<T> where T : class
	{
		private ILogger<RepositoryBase<T>> _logger;
		private IOrganizationServiceAsync _service;
		public abstract string Entity { get; }
		public abstract string AlternateKey { get; }
		public abstract string[] Columns { get; }

		public RepositoryBase (ILogger<RepositoryBase<T>> logger, IOrganizationServiceAsync service)
		{
			_logger = logger;
			_service = service;
		}

		public virtual async Task<EntityCollection> GetByAltKeyAsync (string id)
		{
			var query = new QueryExpression(Entity)
			{
				ColumnSet = new ColumnSet(Columns)
			};
			query.Criteria.Conditions.Add(new ConditionExpression(AlternateKey, ConditionOperator.Equal, id));

			var retrieveMultipleReq = new RetrieveMultipleRequest()
			{
				Query = query
			};
			var retrieveMultipleRes = (RetrieveMultipleResponse)await _service.ExecuteAsync(retrieveMultipleReq);

			if (retrieveMultipleRes.EntityCollection.Entities.Count() == 0)
				throw new DynamicsNotFoundException($"No record found with ID: {id}");

			return retrieveMultipleRes.EntityCollection;
		}

		public virtual async Task<EntityCollection> GetAllAsync ()
		{
			var pageNumber = 1;
			var pagingCookie = string.Empty;
			var result = new EntityCollection();
			var response = new EntityCollection();

			var query = new QueryExpression(Entity)
			{
				EntityName = Entity,
				ColumnSet = new ColumnSet(Columns)
			};

			do
			{
				if (pageNumber != 1)
				{
					query.PageInfo.PageNumber = pageNumber;
					query.PageInfo.PagingCookie = pagingCookie;
				}

				var retrieveMultipleReq = new RetrieveMultipleRequest()
				{
					Query = query
				};
				var retrieveMultipleRes = (RetrieveMultipleResponse)await _service.ExecuteAsync(retrieveMultipleReq);

				response = retrieveMultipleRes.EntityCollection;

				if (response.MoreRecords)
				{
					pageNumber++;
					pagingCookie = response.PagingCookie;
				}

				result.Entities.AddRange(response.Entities);
			}
			while (response.MoreRecords);

			return result;
		}
	}
}