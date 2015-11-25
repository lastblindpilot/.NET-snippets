using System;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;

namespace SharePointConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site = new SPSite("http://sharepoint"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    // Build a query.
                    SPQuery query = new SPQuery();
                    query.Query = string.Concat(
                         "<Where><Eq>",
                                 "<FieldRef Name='Name'/>",
                                 "<Value Type='Text'>SMSK01WE16</Value>",
                              "</Eq></Where>",

                                   "<OrderBy>",
                                      "<FieldRef Name='Title' Ascending='TRUE' />",
                                   "</OrderBy>");

                    query.ViewFields = string.Concat(
                                        "<FieldRef Name='Title' />");

                    query.ViewFieldsOnly = true; // Fetch only the data that we need.

                    // Get data from a list.
                    string listUrl = web.ServerRelativeUrl + "/lists/Servers";
                    SPList list = web.GetList(listUrl);
                    SPListItemCollection items = list.GetItems(query);


                    // Print the details.
                    foreach (SPListItem item in items)
                    {
                        Console.WriteLine(item["Title"]);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
