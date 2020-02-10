using BPS.Getway;
using BPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.BLL
{
    public class HireBLL
    {
        HireGetway hireGetway = new HireGetway();
        public string RequestHire(HireEng ahireEng)
        {
            if (!hireGetway.isExistRequest(ahireEng))
            {
                if (hireGetway.HireEng(ahireEng) > 0)
                {
                    return "Request Sent Successfully";
                }

                else
                    return "Faild";
            }
            return "Sorry!!! You already send Request.......";
            }
            
        }
    }
