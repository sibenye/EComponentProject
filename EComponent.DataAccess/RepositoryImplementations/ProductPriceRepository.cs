using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using EComponent.DataAccess.DataModels;
using EComponent.Services.Repositories;
using EComponent.Services.Responses;
using EComponent.Services.Requests;
using EComponent.DataAccess.Extensions;

namespace EComponent.DataAccess.RepositoryImplementations
{
    public class ProductPriceRepository : BaseRepository, IProductPriceRepository
    {
        public ProductPriceRepository(IDbConnectionProvider dbProvider)
            : base(dbProvider)
        {
        }

        public IEnumerable<ProductPriceResponse> Get(ProductPriceGetRequest request, bool includeDeleted = false)
        {
            const string sqlTemplate = @"SELECT 
                    Id,
                    ProductId,
                    Quantity,
                    Price,
                    FROM product_prices /**where**/";

            var builder = new SqlBuilder();
            var selectTemplate = builder.AddTemplate(sqlTemplate);

            if (request.Id != null)
            {
                builder.Where("Id = @Id", new { Id = request.Id });
            }

            if (request.ProductId != null)
            {
                builder.Where("ProductId = @ProductId", new { ProductId = request.ProductId });
            }

            if (!includeDeleted)
            {
                builder.Where("IsDeleted = 0");
            }

            using (var Db = DbProvider.GetConnection())
            {
                var queryResult = Db.Query<ProductPrice>(selectTemplate.RawSql, selectTemplate.Parameters).ToList();

                var response = Mapper.Map<ProductPriceResponse[]>(queryResult);
                return response;
            }
        }

        public int Upsert(ProductPricePostRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
