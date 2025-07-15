using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Xml;
using Xamarin.Essentials;
using System.IO;

namespace IT123P_Final_Course_Assessment_MP
{
    class XMLclass
    {

        string XMLFileName, TagName;
        Stream stream;
        XmlDocument localInfo;
        XmlNodeList tagList;

        int cnt;

        public XMLclass(string xmlfilename, string tagname)
        {
            this.XMLFileName = xmlfilename;
            this.TagName = tagname;
            localInfo = new XmlDocument();
        }

        public void ConnectXML()
        {
            string cachePath = Path.Combine(Android.App.Application.Context.CacheDir.AbsolutePath, XMLFileName);
            localInfo.Load(cachePath);
            tagList = localInfo.GetElementsByTagName(TagName);

        }

        public int TagList_Count()
        {
            return tagList.Count;
        }

        public string[,] ExtractXMLData()
        {
            string[,] XMLValues;
            using (stream)
            {

                XMLValues = new string[tagList.Count, 6];
                foreach (XmlElement xmlElement in tagList)
                {
                    XMLValues[cnt, 0] = xmlElement.ChildNodes[0].InnerText;
                    XMLValues[cnt, 1] = xmlElement.ChildNodes[1].InnerText;
                    XMLValues[cnt, 2] = xmlElement.ChildNodes[2].InnerText;
                    XMLValues[cnt, 3] = xmlElement.ChildNodes[3].InnerText;
                    XMLValues[cnt, 4] = xmlElement.ChildNodes[4].InnerText;
                    XMLValues[cnt, 5] = xmlElement.ChildNodes[5].InnerText;
                    cnt++;
                }
            }
            return XMLValues;
        }
    }
}