﻿namespace ASP.NET_1.src.Common
{
    public class RAMProductProcessor : IProductProcessor
    {
        public string Message_AddProduct { get; set; } = "Product added to list";
        public string Message_RemoveProduct { get; set; } = "Product removed from list";
        public string Message_UpdateProduct { get; set; } = "Product updated in list";
        public string Message_ClearCatalogue { get; set; } = "Catalogue in list is cleared";

        public static List<Product> Products { get; set; } = new List<Product>();
        public Product GetProduct(int id)
        {
            return Products.Where(x => x.Id == id).SingleOrDefault();
        }
        public void CreateProduct(Product product)
        {
            Products.Add(product);
        }
        public void DeleteProduct(int id)
        {
            Products.Remove(Products.Where(x => x.Id == id).SingleOrDefault());
        }
        public void UpdateProduct(Product product)
        {
            Product FoundById = Products.Where(x => x.Id == product.Id).SingleOrDefault();
            Products[Products.IndexOf(FoundById)] = product;  
        }
        public void ClearCatalogue()
        {
            Products.Clear();
        }

        public IEnumerable<Product> GetCatalogue()
        {
            return Products;
        }

    }
}
