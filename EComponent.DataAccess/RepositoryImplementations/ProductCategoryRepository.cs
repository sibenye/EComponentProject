using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dapper;
using EComponent.DataAccess.DataModels;
using EComponent.Services.Repositories;
using EComponent.Services.Responses;
using EComponent.Services.Requests;
using EComponent.DataAccess.Extensions;

namespace EComponent.DataAccess.RepositoryImplementations
{
    public class ProductCategoryRepository : BaseRepository, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbConnectionProvider dbProvider)
            : base(dbProvider)
        {
        }

        public IEnumerable<ProductCategoryResponse> Get(ProductCategoryGetRequest request, bool includeDeleted = false)
        {
            const string sqlTemplate = @"SELECT 
                    Id,
                    ParentId,
                    Name
                    FROM productCategories /**where**/";

            var builder = new SqlBuilder();
            var selectTemplate = builder.AddTemplate(sqlTemplate);

            if (request.Id != null)
            {
                builder.Where("Id = @Id", new { Id = request.Id });
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                builder.Where("Name = @Name", new { Name = request.Name });
            }

            if (!includeDeleted)
            {
                builder.Where("IsDeleted = 0");
            }

            using (var Db = DbProvider.GetConnection())
            {
                var queryResult = Db.Query<productCategory>(selectTemplate.RawSql, selectTemplate.Parameters).ToList();

                var response = Mapper.Map<ProductCategoryResponse[]>(queryResult);
                return response;
            }

        }

        
    }
}
