using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Model
{
    public class User
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
    public class RawMaterial
    {
        private string _code;
        private string _hsCode;
        private decimal _importPrice;
        private decimal _exportPrice;
        private decimal _exchangeRate;
        private decimal _tax;
        private decimal _quantity;
        private string _customsDeclarationCode;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string HSCode
        {
            get { return _hsCode; }
            set { _hsCode = value; }
        }
        public decimal ImportPrice
        {
            get { return _importPrice; }
            set { _importPrice = value; }
        }
        public decimal ExportPrice
        {
            get { return _exportPrice; }
            set { _exportPrice = value; }
        }
        public decimal ExchangeRate
        {
            get { return _exchangeRate; }
            set { _exchangeRate = value; }
        }
        public decimal Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string CustomsDeclarationCode
        {
            get { return _customsDeclarationCode; }
            set { _customsDeclarationCode = value; }
        }
    }

    public class FinishGood
    {
        private string _code;
        private string _name;
        private string _hsCode;
        private string _formulaCode;
        private decimal _quantity;
        private string _customerName;
        private string _po;
        private string _invoice;
        private DateTime _date;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string HSCode
        {
            get { return _hsCode; }
            set { _hsCode = value; }
        }
        public string FormulaCode
        {
            get { return _formulaCode; }
            set { _formulaCode = value; }
        }
        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        public string PO
        {
            get { return _po; }
            set { _po = value; }
        }
        public string Invoice
        {
            get { return _po; }
            set { _po = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }

    public class Formula
    {
        private string _code;
        private string _rawMaterialCode;
        private decimal _originalConsumed;
        private decimal _lossRate;
        private decimal _actualConsumed;
        private int _supplierID;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string RawMaterialCode
        {
            get { return _rawMaterialCode; }
            set { _rawMaterialCode = value; }
        }
        public decimal OriginalConsumed
        {
            get { return _originalConsumed; }
            set { _originalConsumed = value; }
        }
        public decimal LossRate
        {
            get { return _lossRate; }
            set { _lossRate = value; }
        }
        public decimal ActualConsumed
        {
            get { return _actualConsumed; }
            set { _actualConsumed = value; }
        }
        public int SupplierID
        {
            get { return _supplierID; }
            set { _supplierID = value; }
        }
    }

    public class RawMaterialInfo
    {
        private string _code;
        private string _name;
        private int _unitID;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int UnitID
        {
            get { return _unitID; }
            set { _unitID = value; }
        }
    }

    public class Unit
    {
        private int _id;
        private string _name;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    public class Supplier
    {
        private int _id;
        private string _name;
        private string _address;
        private string _contractor;
        private string _phone;
        private string _email;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Contractor
        {
            get { return _contractor; }
            set { _contractor = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Email 
        { 
            get { return _email; }
            set { _email = value; }
        }

    }

    public class CustomsDeclaration
    {
        private string _code;
        private DateTime _openDate;
        private DateTime _goodsArrivalDate;
        private DateTime _inputDate;

        public string Code 
        {
            get { return _code; }
            set { _code = value; }
        }
        public DateTime OpenDate
        {
            get { return _openDate; }
            set { _openDate = value; }
        }
        public DateTime GoodArrivalDate
        {
            get { return _goodsArrivalDate; }
            set { _goodsArrivalDate = value; }
        }
        public DateTime InputDate
        {
            get { return _inputDate; }
            set { _inputDate = value; }
        }
    }


    /*
     * OLD ACCESS DATABASE
     */
}
