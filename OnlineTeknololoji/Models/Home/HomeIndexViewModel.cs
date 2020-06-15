using Microsoft.Ajax.Utilities;
using OnlineTeknololoji.DAL1;
using OnlineTeknololoji.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace OnlineTeknololoji.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        teknomarketDB1Entities context = new teknomarketDB1Entities();
        public IPagedList<UrunTablo> ListOfProducts { set; get; }
        public HomeIndexViewModel CreateModel(string search, int pageSize, int? page)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<UrunTablo> data = context.Database.SqlQuery<UrunTablo>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndexViewModel
            {
                ListOfProducts = data 
            };
        }
   
    }
}