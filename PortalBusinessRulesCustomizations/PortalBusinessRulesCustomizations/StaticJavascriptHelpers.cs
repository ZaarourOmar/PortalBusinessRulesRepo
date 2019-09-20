﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalBusinessRulesCustomizations
{
   public class StaticJavascriptHelpers
    {

        private static string GetFieldValueJS()
        {
            return $"function getFieldValue(e){{var l=document.getElementById(e),n=null===l||null===l.type||void 0===l.type?\"\":l.type;if(null===l)return null;var t=n.indexOf(\"text\")>-1&&-1===l.className.indexOf(\"money\"),a=n.indexOf(\"text\")>-1&&l.className.indexOf(\"money\")>-1,d=l.className.indexOf(\"lookup\")>-1&&n.indexOf(\"select\")>-1,u=null!==document.getElementById(e+\"_name\")&&document.getElementById(e+\"_name\").className.indexOf(\"lookup\")>-1,i=l.className.indexOf(\"picklist\")>-1&&n.indexOf(\"select\")>-1,o=l.className.indexOf(\"picklist\")>-1&&-1===n.indexOf(\"select\"),c=l.className.indexOf(\"boolean - dropdown\")>-1&&n.indexOf(\"select\")>-1,s=l.className.indexOf(\"boolean - radio\")>-1,m=l.className.indexOf(\"datetime\")>-1,r=n.indexOf(\"checkbox\")>-1;if(d)return\"\"===l.value?null:{{id:l.options[l.selectedIndex].value}};if(u)return\"\"===l.value?null:{{id:l.value,name:document.getElementById(e+\"_name\").value,logicalName:document.getElementById(e+\"_entityname\").value}};if(i||c)return c?\"1\"===l.options[l.selectedIndex].value:l.options[l.selectedIndex].value;if(o||s){{var f=null;if(\"function\"==typeof document.querySelector&&\"function\"==typeof document.querySelectorAll)f=document.querySelectorAll('*[id^=\"'+e+'_\"]');else for(var x=document.getElementsByTagName(\" * \"),v=0;v<x.length;v++)\"radio\"===x[v].type&&x[v].id.indexOf(e)&&f.push(x[v]);for(var y=0;y<f.length;y++)if(\"radio\"===f[y].type&&f[y].checked)return l.className.indexOf(\"boolean - radio\")>-1?\"1\"===f[y].value:f[y].value;return null}}return m?null===l.value||\"\"===l.value?null:new Date(l.value):r?l.checked:t&&!a?l.value:a?parseInt(l.value,10):null}}";
        }
        private static string SetVisibleJS()
        {
            return "function setVisible(e,t){for(var l=getArrayOfFieldNames(e),a=0;a<l.length;a++){var n=l[a],s=document.getElementById(n),i=document.getElementById(n+\"_label\");if(null===s)return;t||\"none\"===s.style.display||(saveElemDisplayType(s),saveElemDisplayType(i)),s.parentElement.parentElement.style.display=t?getPreviousDisplayValue(s):\"none\",i.parentElement.parentElement.style.display=t?getPreviousDisplayValue(s):\"none\";var r=document.getElementById(n).parentElement.parentElement.parentElement;if(t)r.style.display=getPreviousDisplayValue(r,e+\"_parentrow\"),checkForLeftPadding(e,!1,r,r.getElementsByTagName(\"td\"));else{for(var m=!0,d=r.getElementsByTagName(\"td\"),y=d[0].className.indexOf(\"picklist\")>-1,p=0;p<d.length;p++)if(!(d[p].className.indexOf(\"zero - cell\")>-1||0===d[p].offsetWidth&&0===d[p].offsetHeight||y&&d[p].className.indexOf(\"clearfix cell\")>-1)){m=!1;break}checkForLeftPadding(e,m,r,d)}}}";
        }
        private static string SetDisabledJS()
        {
            return "function setDisabled(e, t) { for (var a = getArrayOfFieldNames(e), d = 0; d < a.length; d++) { var l = a[d]; document.getElementById(l).disabled = t} }";
        }
        private static string SetReadOnlyJS()
        {
            return "function setReadOnly(e,n){for(var a=getArrayOfFieldNames(e),r=0;r<a.length;r++){var t=a[r];document.getElementById(t).readOnly=n?\"readonly\":\"\"}}";
        }

        private static string GetHelperFunctions()
        {
            return "var elems=[];function saveElemDisplayType(e,l){for(var i=0;i<elems.length;i++){var s=elems[i];if(s.Id===(\"\"===e.id?l:e.id))return void(s.Display=e.style.display)}elems.push({Id:\"\"===e.id?l:e.id,Display:e.style.display})}function getPreviousDisplayValue(e,l){for(var i=0;i<elems.length;i++){var s=elems[i];if(s.Id===(\"\"===e.id?l:e.id))return s.Display}}function checkForLeftPadding(e,l,i,s){l&&\"none\"!==i.style.display?(saveElemDisplayType(i,e+\"_parentrow\"),i.style.display=\"none\"):0===s[0].offsetWidth&&0===s[0].offsetHeight&&null!==s[1]?s[1].style.paddingLeft=0:null!==s[1]&&(s[1].style.paddingLeft=\"20px\")}function getArrayOfFieldNames(e){var l=e;return\"string\"==typeof e&&(l=[]).push(e),l}";


        }
        public static string GetAllHelperFunctions()
        {
            return "\n/*Start of Helper Functions*/" +
                 GetFieldValueJS() + "\n" +
                 SetVisibleJS() + "\n" +
                 SetDisabledJS() + "\n" +
                 SetReadOnlyJS() + "\n" +
                 GetHelperFunctions() + "\n" +
                "\n/*End of Helper Functions*/\n";
        }
    }
}
