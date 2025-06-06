﻿using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models.Domain
{
    public class Inventoryreservation
    {
        [Key]
        public int RId { get; set; }
        public Inventory Inventory { get; set; }
        public int inventoryid { get; set; }
        public Job FROMJob { get; set; }
        public int fromjobid { get; set; }
        public Job TOJob { get; set; }
        public int tojobid { get; set; }
        public decimal reservedqty { get; set; }
        public Product Product { get; set; }
        public int  productid { get; set; }
        public UOM UOM { get; set; }
        public int uomid { get; set; }
        public decimal issuecreatedqty { get; set; }
        public decimal invunitprice { get; set; }
        public  DateTime  reservationtime { get; set; }
        public PRDetails PRDetails { get; set; }
        public int prtblid { get; set; }
        public Currency Currency { get; set; }
        public int invrcurrencyid { get; set; }


    }
}
