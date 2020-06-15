using OnlineTeknololoji.DAL1;
using OnlineTeknololoji.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTeknololoji.Controllers
{
    public class HomeController : Controller
    {
        teknomarketDB1Entities ctx = new teknomarketDB1Entities();
        public ActionResult Index(string search, int? page)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search, 4, page));
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult CheckOutDetails()
        {
            return View();
        }
        public ActionResult DecreaseQty(int productId)
        {
            if(Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = ctx.UrunTablo.Find(productId);
                foreach (var item in cart)
                {
                    if(item.Product.UrunId == productId)
                    {
                        int preQty = item.Miktar;
                        if(preQty > 0)
                        {
                            cart.Remove(item);
                            cart.Add(new Item()
                            {
                                Product = product,
                                Miktar = preQty - 1
                            });
                        }
                        break;
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("Checkout");
        }
        public ActionResult AddToCart(int productId, string url)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = ctx.UrunTablo.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Miktar = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var count = cart.Count();
                var product = ctx.UrunTablo.Find(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Product.UrunId == productId)
                    {
                        int prevQty = cart[i].Miktar;
                        cart.Remove(cart[i]);
                        cart.Add(new Item()
                        {
                            Product = product,
                            Miktar = prevQty + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Product.UrunId == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new Item()
                            {
                                Product = product,
                                Miktar = 1
                            });
                        }
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect(url);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult RemoveFromCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.UrunId == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Index");
        }
    }
    }
