using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Model
{
    public class BoM
    {
        public string FGCode { get; set; }
        public string RMCode { get; set; }
        public string RMName { get; set; }
        public string Unit { get; set; }
        public decimal BoM { get; set; }
        public decimal Rate { get; set; }
        public decimal BoMTotal { get; set; }
        public string Supplier { get; set; }
        
    }
    public class FG
    {
        public string ItemCode { get; set; }
        public string FGName { get; set; }
        public string HSCode { get; set; }
        public string FGCode { get; set; }
        public decimal Qty { get; set; }
        public string Customer { get; set; }
        public string Po { get; set; }
        public string Invoice { get; set; }
        public DateTime Date { get; set; }
        public string LogCode { get; set; }
    }
    public class RM
    {
        public DateTime InputDate { get; set; }
        public string CusDecNo { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string RMCode { get; set; }
        public string RMName { get; set; }
        public string HSCode { get; set; }
        public decimal Price { get; set; }
        public decimal ExRate { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Tax { get; set; }
        public decimal PriceOutput { get; set; }
        public decimal Input { get; set; }
        public decimal Output { get; set; }
    }
    public class RMOutputLog
    {
        public string LogCode { get; set; }
        public string CusDecNo { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string RMCode { get; set; }
        public decimal Output { get; set; }
    }
}
