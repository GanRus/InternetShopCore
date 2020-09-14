using Microsoft.AspNetCore.Mvc;
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

        [Display(Name = "Наименование")]
        [Required (ErrorMessage = "Не указано наименование группы категорий товаров")]
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

        [Display(Name = "Наименование категории товара")]
        [Required(ErrorMessage = "Не выбрана категория")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        [Display(Name = "Наименование товара")]
        [Required(ErrorMessage = "Не указано наименование")]
        public string Name { get; set; }
        
        [Display(Name = "Артикул")]
        [Required(ErrorMessage = "Не указан артикул")]
        public string VendorCode { get; set; }
        
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Не указана цена")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Количество товара")]
        [Required(ErrorMessage = "Не указано количество товара")]
        [DataType(DataType.Currency)]
        public int Count { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? Rating { get; set; }

        [Display(Name = "Описание товара")]
        [Required(ErrorMessage = "Опишите товар")]
        public string Description { get; set; }

        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "Укажите производителя товара")]
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [Display(Name = "Укажите изображение товара")]
        [Required(ErrorMessage = "Необходимо указать изображение")]
        public ICollection<Image> Images { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public SmartPhoneProduct SmartPhoneProducts { get; set; }
        public TabletPCProduct TabletPCProducts { get; set; }
        public SmartWatchProduct SmartWatchProducts { get; set; }
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

        [Display(Name = "Операционная система")]
        [Required(ErrorMessage = "Не указана ОС")]
        public string OperationSystem { get; set; }
        
        [Display(Name = "Защита корпуса")]
        public string BodyProtect { get; set; }

        [Display(Name = "Поддержка 2-х SIM-карт")]
        [Required(ErrorMessage = "Необходимо указать поддержку")]
        public bool DualSimSupport { get; set; }

        [Display(Name = "Количество ядер")]
        [Required(ErrorMessage = "Необходимо указать количество ядер")]
        public int CoreCount { get; set; }

        [Display(Name = "Частота процессора")]
        [Required(ErrorMessage = "Необходимо указать частоту процессора")]
        public string CPU_Frequency { get; set; }

        [Display(Name = "Объем оперативной памяти")]
        [Required(ErrorMessage = "Необходимо указать объем оперативной памяти")]
        public int RAM_Size { get; set; }

        [Display(Name = "Объем встроенной памяти")]
        [Required(ErrorMessage = "Необходимо указать объем встроенной памяти")]
        public int MemorySize { get; set; }

        [Display(Name = "Разрешение экрана")]
        [Required(ErrorMessage = "Необходимо указать разрешение экрана")]
        public string ScreenSize { get; set; }

        [Display(Name = "Работа в 4G(LTE)-сетях")]
        [Required(ErrorMessage = "Необходимо указать поддержку 4G")]
        public bool WorkIn4G { get; set; }

        [Display(Name = "Разрешение камеры")]
        [Required(ErrorMessage = "Необходимо указать разрешение камеры")]
        public string CameraResolution { get; set; }

        [Display(Name = "Емкость аккумуллятора")]
        [Required(ErrorMessage = "Необходимо указать емкость аккумулятора")]
        public string BatteryCapacity { get; set; }

        [Display(Name = "Количество ядер")]
        [Required(ErrorMessage = "Необходимо указать количество ядер")]
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