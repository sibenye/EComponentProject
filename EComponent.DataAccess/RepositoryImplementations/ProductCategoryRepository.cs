using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Objects;
using AutoMapper;
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

        public IEnumerable<ProductCategoryResponse> GetProductCategories(bool includeDeleted = false)
        {
            using (var Db = new EComponentObjectContext(DbProvider.GetConnectionName()))
            {                
                try
                {
                    var productCats = Db.productCategories.ToList();
                
                    var response = Mapper.Map<ProductCategoryResponse[]>(productCats);
                    return response;
                }
                catch (System.Exception e)
                {
                    //TODO: log error
                    return new List<ProductCategoryResponse>();
                }                
            }           
            
        }

        public ProductCategoryResponse GetProductCategory(ProductCategoryGetRequest request, bool includeDeleted = false)
        {
            using (var Db = new EComponentObjectContext(DbProvider.GetConnectionName()))
            {
                try
                {
                    if (request.Id == null & string.IsNullOrEmpty(request.Name))
                    {
                        return null;
                    }
                    const string sqlTemplate = @"SELECT * FROM ProductCategories /**where**/";

                    var builder = new SqlBuilder();
                    var selectTemplate = builder.AddTemplate(sqlTemplate);
                    var objectParams = new List<object>();

                    if (request.Id != null)
                    {
                        builder.Where("Id = @Id");
                        var sqlParam = new ObjectParameter("Id", request.Id);
                        objectParams.Add(sqlParam);
                    }

                    if (!string.IsNullOrEmpty(request.Name))
                    {
                        builder.Where("Name = @Name");
                        var sqlParam = new ObjectParameter("Name", request.Name);
                        objectParams.Add(sqlParam);
                    }

                    if (!includeDeleted)
                    {
                        builder.Where("IsDeleted = 0");
                    }

                    var queryResult = Db.productCategories.SqlQuery(selectTemplate.RawSql, objectParams.ToArray()).ToList();

                    var productCat = queryResult;
                    if (productCat == null)
                    {
                        return null;
                    }

                    var response = Mapper.Map<ProductCategoryResponse>(productCat);
                    return response;
                }
                catch (System.Exception e)
                {
                    //TODO: log error
                    return null;
                }
            }
        }

        
    }
}
