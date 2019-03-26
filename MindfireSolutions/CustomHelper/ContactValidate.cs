using MindfireSolutions.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MindfireSolutions.CustomHelper
{
    public class ContactValidate
    {
        public static bool IsContactValid(MindfireEmployeeRegister employeeRegister)
        {            
            Regex regex = new Regex(@"^[0-9]{5,10}$");
            for(int i = 0; i < employeeRegister.UserContactList.Length;i++)
            { 
                    if (!regex.IsMatch(employeeRegister.ContactNumber[i]))
                    {
                        return false;
                    }                
            }
            return true;
        }
    }
}