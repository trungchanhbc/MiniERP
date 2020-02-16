using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Model
{
    /// <summary>
    /// Database
    /// </summary>
    public class Account
    {
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }

    /*
     * NEW DATABASE MODEL
     */
    public class RawMaterialInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string HSCode { get; set; }
        public int UnitID { get; set; }
    }
    public class RawMaterialInput
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal TaxCost { get; set; }
        public string CustomsDeclarationCode { get; set; }
        public int SupplierID { get; set; }
    }
    public class RawMaterialOutput
    { 
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
    public class CustomsDeclaration
    {
        public string Code { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime GoodsArrivalDate { get; set; }
    }
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Unit
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class FinishGoodInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string HSCode { get; set; }
    }
    public class FinishGoodInput
    {
        public string Code { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public string FormulaCode { get; set; }
        public int CustomerID { get; set; }
        public string LogCode { get; set; }
    }
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PO { get; set; }
        public string Invoice { get; set; }
        public string Biller { get; set; }
    }

    public class Formula
    {
        public string Code { get; set; }
        public string RawMaterialCode { get; set; }
        public decimal Consumed { get; set; }
        public decimal LossRate { get; set; }
        public decimal ActualConsumed { get; set; }
    }

}
