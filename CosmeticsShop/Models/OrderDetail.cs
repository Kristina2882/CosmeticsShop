using System.Runtime.CompilerServices;
using CosmeticsShop.Models;
using Microsoft.AspNetCore.Mvc;


namespace CosmeticsShop.Models
{
    public class OrderDetail
    {
       
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CosmeticId { get; set; }
        public int Price { get; set; }
        public Cosmetic? Cosmetic { get; set; }
        public Order? Order { get; set; }    

    }
}
