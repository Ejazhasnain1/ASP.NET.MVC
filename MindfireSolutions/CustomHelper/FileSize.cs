﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MindfireSolutions.CustomHelper
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public FileSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            return _maxSize > (value as HttpPostedFileBase).ContentLength;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The file size should not exceed 500kb");
        }
    }
}