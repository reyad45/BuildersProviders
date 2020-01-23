using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BPS.Getway;
using BPS.Models;
using BRS.Models;

namespace BPS.BLL
{
    public class EngineerBLL
    {
        public EngineerGetway aEngineerGetway = new EngineerGetway();

        public string SaveEngProfile(Engineer aEngineer)
        {
            if (aEngineerGetway.CreateEngUser(aEngineer) > 0)
            {
                if (aEngineerGetway.saveEngProfile(aEngineer) > 0)
                {
                    return "Engineer Profile Create Successfully";
                }

                else
                    return "User Create Faild";
            }
            else
            {
                return "Faild!!!!";
            }
        }

        public List<Engineer> EngineersViewProfile()
        {
            return aEngineerGetway.EngineerViewGetway();
        }

    }
}