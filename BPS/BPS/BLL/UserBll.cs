using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BRS.Getway;
using BRS.Models;

namespace BRS.BLL
{
    public class UserBll
    {

        UserGetway aUserGetway = new UserGetway();
        public List<UserLogin> GetUserRole()
        {

            return aUserGetway.GetUserRole();
        }

        public List<UserLogin> GetUsers()
        {

            return aUserGetway.Getusers();
        }

        public string saveUserReg(RegisterView auserlogin)
        {
            if (!aUserGetway.isExistUser(auserlogin.UserName))
            {
                if (aUserGetway.saveReg(auserlogin) > 0)
                {
                    return "Registration Successfully";
                }
                return "Error!! Not Save.......";
            }
            else
            {
                return "This User Name Already Exist!!!";
            }
        }


    }
}