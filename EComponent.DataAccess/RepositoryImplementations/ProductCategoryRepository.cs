using System.Collections.Generic;
using System.Data;
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
                    CategoryName
                    FROM productCategories /**where**/";

            var builder = new SqlBuilder();
            var selectTemplate = builder.AddTemplate(sqlTemplate);

            if (request.Id != null)
            {
                builder.Where("Id = @Id", new { Id = request.Id });
            }

            if (!string.IsNullOrEmpty(request.CategoryName))
            {
                builder.Where("CategoryName = @CategoryName", new { CategoryName = request.CategoryName });
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

        public int Upsert(ProductCategoryPostRequest request)
        {
            var sprocParameters = new DynamicParameters();
            sprocParameters.Add("prodCatId", request.Id, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
            sprocParameters.Add("prodCatParentId", request.ParentId);
            sprocParameters.Add("prodCatName", request.CategoryName);
            sprocParameters.Add("createdModifiedBy", request.ModifiedBy);

            using (var db = DbProvider.GetConnection())
            {
                db.Query<int>("upsert_productCategory", sprocParameters, commandType: CommandType.StoredProcedure);
                int? upsertedId = sprocParameters.Get<int?>("prodCatId");
                return (upsertedId == null) ? 0 : upsertedId.Value;
            }
        }
        
    }
}
