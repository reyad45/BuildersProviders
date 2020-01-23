using BPS.Getway;
using BPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.BLL
{
    public class ClientBLL
    {
        ClientGetway aClientGetway = new ClientGetway();

        public string SaveProfile(ClientProfile aprofile)
        {
            if (aClientGetway.ProfileSave(aprofile) > 0)
            {
                if (aClientGetway.CreateClientUser(aprofile) > 0)
                {
                    return "Save Successfully";
                }
                else 
                    return "Client profile Create Faild!..";
            }
            else
                return "Faild";
        }

        public List<ClientProfile> GetProfile()
        {
            return aClientGetway.GetProfile();
        }
    }
}