using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://www.sears.com/home-mattresses-accessories-mattresses/b-5000612?Brand=Beautyrest&Brand=Sealy&Brand=Serta&Brand=Serta%20iComfort&Brand=Simmons%20Beauty%20Sleep&Brand=Stearns%20%26%20Foster&Brand=Tempur-Pedic&Size=King&filterList=Brand%7CSize";
            var page = new WebPage(url);
            page.Visit();
            //var html = page.Html;
            var prefix = "card-";
            var list = new List<string>() { "container", "bottom", "title" };
            var tag = "a[bo-title='product.name']";
            string xpath = CreateXPath(prefix, list);
            var attributes = new List<string>() { "href", "title" };
            //var properties = new List<string> { "text" };
            var linkElements = page.Parse(tag, xpath, attributes/*, properties*/);
            
            foreach(var linkElem in linkElements)
            {
                /*var linkUrl = linkElem.Attributes["href"];
                var nextPage = new WebPage(linkUrl);
                nextPage.Visit();
                nextPage.Parse();
                */
                var productFullName = linkElem.Attributes["title"];
                //var brand = ExtractBrand(productFullName);
                //var model = ExtractModel(productFullName);
                Output(productFullName);
            }

        }
    }
}
