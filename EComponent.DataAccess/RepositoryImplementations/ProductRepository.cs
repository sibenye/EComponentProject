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
    public class ProductRepository : BaseRepository, IProductRepository
    {
         public ProductRepository(IDbConnectionProvider dbProvider)
            : base(dbProvider)
        {
        }

         public IEnumerable<ProductResponse> Get(ProductGetRequest request, bool includeDeleted = false)
         {
             const string sqlTemplate = @"SELECT 
                    Id,
                    ProductCategoryId,
                    ProductCode,
                    ManufacturerName,
                    ManufacturerPartNumber,
                    Description,
                    InStock,
                    ImageUrl
                    FROM products /**where**/";

             var builder = new SqlBuilder();
             var selectTemplate = builder.AddTemplate(sqlTemplate);

             if (request.Id != null)
             {
                 builder.Where("Id = @Id", new { Id = request.Id });
             }

             if (!string.IsNullOrEmpty(request.ProductCode))
             {
                 builder.Where("ProductCode = @ProductCode", new { ProductCode = request.ProductCode });
             }

             if (request.ProductCategoryId != null)
             {
                 builder.Where("ProductCategoryId = @ProductCategoryId", new { ProductCategoryId = request.ProductCategoryId });
             }

             if (!includeDeleted)
             {
                 builder.Where("IsDeleted = 0");
             }

             using (var Db = DbProvider.GetConnection())
             {
                 var queryResult = Db.Query<Product>(selectTemplate.RawSql, selectTemplate.Parameters).ToList();

                 var response = Mapper.Map<ProductResponse[]>(queryResult);
                 return response;
             }
         }

         public int Upsert(ProductPostRequest request)
         {
             throw new NotImplementedException();
         }
    }
}
