using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBridge.Models;


namespace ShopBridge.Controllers
{
    public class ProductController : ApiController
    {
        ShopBridgeEntities db = new ShopBridgeEntities();
        //Add Post Request
        public string Post(product product)
        {
            try
            {
                db.products.Add(product);
                db.SaveChanges();
                return ("product added");

            }
            catch (Exception ex)

            {
              return ex.Message.ToString();
            }
        }

        //Get all records
        public IEnumerable<product> Get()
        {
            
                return db.products.ToList();
            
          

        }



        //get single record
        public product Get(int id)
        {
           
                product product = db.products.Find(id);
                return product;
           

           
        }


      


        //update the records



        public string Put(int id, product product)
        {
            var product_ = db.products.Find(id);

            product_.Product_name = product_.Product_name;
            product_.Product_Desc = product_.Product_Desc;
            product_.Price = product_.Price;
            db.Entry(product_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return ("Product Updated");


        }




        //delete the records
        public string Delete(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();

            return ("deleted");
        }

    }
}
