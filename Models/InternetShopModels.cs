using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShopCore.Models
{
    public class GroupCategory
    {
        [Key]
        public int GroupCategoryId { get; set; }

        [Required (ErrorMessage = "Не указано наименование группы категорий товаров")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Не указано наименование категории товаров")]
        public string Name { get; set; }

        [Display(Name = "Группа категории")]
        [Required(ErrorMessage = "Не выбрана группа категории")]
        [ForeignKey("Category")]
        public int GroupCategoryId { get; set; }
        public GroupCategory GroupCategory { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int? Rating { get; set; }

        public string Description { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public SmartPhoneProduct SmartPhoneProduct { get; set; }
    }

    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class Review
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTimeReview { get; set; }
        public string NameAuthor { get; set; }
        public string CityAuthor { get; set; }
        public string Text { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public class Image
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Product")]
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
        public string OperationSystem { get; set; }
        public string BodyProtect { get; set; }
        public bool DualSimSupport { get; set; }
        public int CoreCount { get; set; }
        public string CPU_Frequency { get; set; }
        public int RAM_Size { get; set; }
        public int MemorySize { get; set; }
        public string ScreenSize { get; set; }
        public bool WorkIn4G { get; set; }
        public string CameraResolution { get; set; }
        public string BatteryCapacity { get; set; }
        public string Color { get; set; }
    }

    public class TabletPCProduct
    {
        [Key]
        [ForeignKey("Product")]
        public int ProdId { get; set; }
        public Product Product { get; set; }
        public string OperationSystem { get; set; }
        public string ScreenType { get; set; }
        public string ScreenSize { get; set; }
        public string ModelCPU { get; set; }
        public string CPU_Frequency { get; set; }
        public int CoreCount { get; set; }
        public int MemorySize { get; set; }
        public int RAM_Size { get; set; }
        public bool HasWiFi { get; set; }
        public bool Has3G { get; set; }
        public bool Has4G { get; set; }
        public string CameraResolution { get; set; }
        public string FrontCameraRes { get; set; }
        public string Color { get; set; }
    }

    public class SmartWatchProduct
    {
        [Key]
        [ForeignKey("Product")]
        public int ProdId { get; set; }
        public Product Product { get; set; }
        public string Monitoring { get; set; }
        public string Tracker { get; set; }
        public string DisplayType { get; set; }
        public bool HasSensorDisplay { get; set; }
        public string ScreenSize { get; set; }
        public string ScreenResolution { get; set; }
        public int RAM_Size { get; set; }
        public bool HasBluetooth { get; set; }
        public string TypeGlass { get; set; }
        public string BodyColor { get; set; }
        public string WatchbandColor { get; set; }
    }
}