using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MindfireSolutions.CustomHelper
{
    public class FileValidate
    {
        public static bool IsFileValid(string extension)
        {
            string[] extensionArray = { ".jpg", ".png", ".jpeg" };
            foreach(var ext in extensionArray)
            {
               if(ext.Equals(extension))
                {
                    return true;
                }
            }
            return false;
        }
    }
}