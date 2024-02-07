using Microsoft.AspNetCore.Http.Json;


namespace ASP.NET_1.src.Common

{
    public class ProductService
    {
        private IProductProcessor ProductProcessor { get; set; }
        public ProductService(IProductProcessor productProcessor) 
        {
            ProductProcessor = productProcessor;
        }

        public IResult CreateProduct(Product product) 
        {
            string resultMessage;
            try
            {
                ProductProcessor.CreateProduct(product);
                resultMessage = ProductProcessor.Message_AddProduct;
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
            }

            return Results.Text(content: resultMessage, statusCode: StatusCodes.Status201Created);
        }
        public IResult UpdateProduct(Product product)
        {
            string resultMessage;
            try
            {
                ProductProcessor.UpdateProduct(product);
                resultMessage = ProductProcessor.Message_UpdateProduct;
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
            }

            return Results.Text(content: resultMessage, statusCode: StatusCodes.Status200OK);

        }
        public IResult DeleteProduct(int id) 
        {
            string resultMessage;
            try
            {
                ProductProcessor.DeleteProduct(id);
                resultMessage = ProductProcessor.Message_RemoveProduct;
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
            }

            return Results.Text(content: resultMessage, statusCode: StatusCodes.Status200OK);
        }
        public IResult GetProduct(int id)
        {
            //return ProductProcessor.GetProduct(id);
            string resultMessage;
            try
            {
                resultMessage = ProductProcessor.GetProduct(id).ToString();
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
            }


            return Results.Text(content: resultMessage, statusCode: StatusCodes.Status200OK);
        }
        public IResult ClearCatalogue() 
        {
            string resultMessage;
            try
            {
                ProductProcessor.ClearCatalogue();
                resultMessage = ProductProcessor.Message_ClearCatalogue;
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
            }
            
            return Results.Text(content: resultMessage, statusCode: StatusCodes.Status200OK);
        }

        public IResult GetCatalogue()
        {
            //return ProductProcessor.GetCatalogue();
            string resultMessage;
            try
            {
                resultMessage = ProductProcessor.GetCatalogue().ToString();
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
            }


            return Results.Text(content: resultMessage, statusCode: StatusCodes.Status200OK);
        }


    }
}
