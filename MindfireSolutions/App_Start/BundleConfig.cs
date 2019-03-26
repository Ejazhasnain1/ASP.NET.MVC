using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MindfireSolutions.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundle scriptBndl = new ScriptBundle("~/Bundles/JS");
            scriptBndl.Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                 "~/scripts/Script.js"
            );
            bundles.Add(scriptBndl);
        }
    }
}
