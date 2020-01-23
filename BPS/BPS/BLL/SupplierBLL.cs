using BPS.Getway;
using BPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.BLL
{
    public class SupplierBLL
    {

        public SupplierGetway aSupplierGetway = new SupplierGetway();

        public string SaveSupProfile(Supplier aSupplier)
        {
            if (aSupplierGetway.saveSupProfile(aSupplier) > 0)
            {
                if (aSupplierGetway.CreateSupUser(aSupplier) > 0)
                {
                    return "Supplier Profile Create Successfully";
                }

                else
                    return "User Create Faild";
            }
            else
            {
                return "Faild!!!!";
            }
        }

        public List<Supplier> SuppliersViewProfile()
        {
            return aSupplierGetway.GetSuppliers();
        }

    }
}