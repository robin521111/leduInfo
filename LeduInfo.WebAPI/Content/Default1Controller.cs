using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LeduInfo.WebAPI.Models;

namespace LeduInfo.WebAPI.Content
{
    public class Default1Controller : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();
        public IEnumerable<Product> GetALlProducts()
        {
            return repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }
        
    }


}
