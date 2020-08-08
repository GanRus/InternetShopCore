using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShopCore.Models
{
    public class GroupCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? GroupCategoryId { get; set; }
        public GroupCategory GroupCategory { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int? Rating { get; set; }

        public string Description { get; set; }

        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public SmartPhoneProduct SmartPhoneProduct { get; set; }
    }

    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class Review
    {
        public int Id { get; set; }
        public DateTime DateTimeReview { get; set; }
        public string NameAuthor { get; set; }
        public string CityAuthor { get; set; }
        public string Text { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string Name { get; set; }
    }

    public class SmartPhoneProduct
    {
        [Key]
        [ForeignKey("Product")]
        public int ProdId { get; set; }
        public Product Product { get; set; }

    }
}
