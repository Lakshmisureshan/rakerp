﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class Customer
    {
        [Key]
        public int customerid { get; set; }
        public string  Customername { get; set; }
        public string  ccode { get; set; }
        public string shortname { get; set; } 
        public string Trnno { get; set; }
        public string IEC { get; set; }
        public string address { get; set; }
        public string email { get; set; } 
        public string pobox { get; set; } 
        public string web { get; set; }  
        public string location  { get; set; }  
        public string phone { get; set; }
        public Country country { get; set; }
        public int  countryid { get; set; }
        public string remarks { get; set; }   
    }
}
