﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Index_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Index_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
__o = model;


#line default
#line hidden

#line 2 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
  
    Layout = "~/Views/Shared/AdminLayout.cshtml";


#line default
#line hidden

#line 3 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                                           __o = Html.ActionLink("Thêm mới khách hàng", "Create");


#line default
#line hidden

#line 4 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
           __o = Html.ActionLink("Xuất excel ", "ExportToExcel");


#line default
#line hidden

#line 5 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                foreach (var item in Model)
                {
                    

#line default
#line hidden

#line 6 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.DisplayFor(modelItem => item.ID_KH);


#line default
#line hidden

#line 7 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.DisplayFor(modelItem => item.HoTen_KH);


#line default
#line hidden

#line 8 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.DisplayFor(modelItem => item.GioiTinh_KH);


#line default
#line hidden

#line 9 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.DisplayFor(modelItem => item.NgaySinh_KH);


#line default
#line hidden

#line 10 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.DisplayFor(modelItem => item.SDT_KH);


#line default
#line hidden

#line 11 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.DisplayFor(modelItem => item.Mail_KH);


#line default
#line hidden

#line 12 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.DisplayFor(modelItem => item.Diem);


#line default
#line hidden

#line 13 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.ActionLink("Edit", "Edit", new { id = item.ID_KH });


#line default
#line hidden

#line 14 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.ActionLink("Details", "Details", new { id = item.ID_KH });


#line default
#line hidden

#line 15 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                       __o = Html.ActionLink("Delete", "Delete", new { id = item.ID_KH });


#line default
#line hidden

#line 16 "C:\Users\ADMIN\AppData\Local\Temp\07417AA2B5EEDFF0454399B579704E851792\2\DAPM_LT_TourDL\DAPM_TOURDL\Views\KHACHHANGs\Index.cshtml"
                         
                }

#line default
#line hidden
}
}
}
