using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTeknololoji.Models
{
    public class CategoryDetail
    {
        public int KategoriId { get; set; }
        [Required(ErrorMessage = "Category Name Required")]
        [StringLength(100, ErrorMessage = "Minimum 3 and minimum 5 and maximum 100 charaters are allwed", MinimumLength = 3)]
        public string KategoriIsim { get; set; }
        public Nullable<bool> AktifMi { get; set; }
        public Nullable<bool> SilindiMi { get; set; }
    }

    public class ProductDetail
    {
        public int UrunId { get; set; }
        [Required(ErrorMessage = "Product Name Required")]
        [StringLength(100, ErrorMessage = "Minimum 3 and minimum 5 and maximum 100 charaters are allwed")]
        public string UrunIsim { get; set; }
        [Required]
        [Range(1, 50)]
        public Nullable<int> KategoriId { get; set; }
        public Nullable<bool> AktifMi { get; set; }
        public Nullable<bool> SilindiMi { get; set; }
        public Nullable<System.DateTime> OlusturmaTarihi { get; set; }
        public Nullable<System.DateTime> DegistirilmeTarihi { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Aciklama { get; set; }
        public string UrunFoto { get; set; }
        public Nullable<bool> OzellikliMi { get; set; }
        [Required]
        [Range(typeof(int), "1", "500", ErrorMessage = "Invalid Quantity")]
        public Nullable<int> Miktar { get; set; }
        [Required]
        [Range(typeof(decimal), "1", "200000", ErrorMessage ="invalid Price")]
        public Nullable<decimal> Fiyat { get; set; }
        public SelectList Categories { get; set; }
    }
}