using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Essentials;

namespace IT123P_Final_Course_Assessment_MP
{
    internal class WriteXMLClass
    {
        private string XMLFileName, TagName;
        private XmlDocument localInfo_Xml;

        public WriteXMLClass(string xmlfilename, string tagname)
        {
            this.XMLFileName = xmlfilename;
            this.TagName = tagname;
            localInfo_Xml = new XmlDocument();
        }

        // Creates a new XML file
        public void CreateXMLFile(string[] userInputs, string[] elementNames)
        {
            string cachePath = Path.Combine(Android.App.Application.Context.CacheDir.AbsolutePath, XMLFileName);

            // Load the existing XML document if it exists
            try
            {
                if (File.Exists(cachePath))
                {
                    localInfo_Xml.Load(cachePath);
                }
            }
            catch
            {
                // Create the root element if the XML document doesn't exist
                XmlElement rootElement = localInfo_Xml.CreateElement(TagName);
                localInfo_Xml.AppendChild(rootElement);
            }

            // Get the existing Question elements
            XmlNodeList questionElements = localInfo_Xml.GetElementsByTagName("Question");

            // Check if the limit of 10 Question elements has been reached
            if (questionElements.Count > 10)
            {
                GetQuestionCount();
            }

            // Create the new Question element
            XmlElement questionElement = localInfo_Xml.CreateElement("Question");

            if (userInputs.Length == elementNames.Length)
            {
                for (int i = 0; i < userInputs.Length; i++)
                {
                    // Create subchild elements in the Question element
                    XmlElement subChildElement = localInfo_Xml.CreateElement(elementNames[i]);
                    subChildElement.InnerText = userInputs[i];
                    questionElement.AppendChild(subChildElement);
                }

                // Append the new Question element to the root element
                localInfo_Xml.DocumentElement.AppendChild(questionElement);

                // Save the XML document to the cache directory
                using (Stream stream = File.Create(cachePath))
                {
                    localInfo_Xml.Save(stream);
                }
            }
            else
            {
                throw new ArgumentException("The number of user inputs must match the number of element names.");
            }
        }

        public int GetQuestionCount()
        {
            string cachePath = Path.Combine(Android.App.Application.Context.CacheDir.AbsolutePath, XMLFileName);

            if (File.Exists(cachePath))
            {
                localInfo_Xml.Load(cachePath);

                // Get the count of Question tags
                XmlNodeList questionElements = localInfo_Xml.GetElementsByTagName("Question");
                return questionElements.Count;
            }
            else
            {
                // XML file does not exist
                return 0;
            }
        }

        // Reads the created XML file
        public string ReadXMLFile(string elementName, int childElementIndex)
        {
            string cachePath = Path.Combine(Android.App.Application.Context.CacheDir.AbsolutePath, XMLFileName);

            if (File.Exists(cachePath))
            {
                localInfo_Xml.Load(cachePath);

                XmlNodeList childElements = localInfo_Xml.GetElementsByTagName("Question");

                if (childElementIndex >= 0 && childElementIndex < childElements.Count)
                {
                    XmlNodeList elements = childElements[childElementIndex].SelectNodes(elementName);

                    if (elements.Count > 0)
                    {
                        // Get the value of the first matching element
                        string elementValue = elements[0].InnerText;
                        return elementValue;
                    }
                    else
                    {
                        return $"Element '{elementName}' not found in the specified child element.";
                    }
                }
                else
                {
                    return "Invalid child element index.";
                }
            }
            else
            {
                return "XML file does not exist.";
            }
        }

        // Clears the XML file
        public void ClearXMLFile()
        {
            string cachePath = Path.Combine(Android.App.Application.Context.CacheDir.AbsolutePath, XMLFileName);

            if (File.Exists(cachePath))
            {
                localInfo_Xml.RemoveAll(); // Remove all nodes from the XML document

                // Save the empty XML document to clear the file content
                using (Stream stream = File.Create(cachePath))
                {
                    localInfo_Xml.Save(stream);
                }
            }
        }
    }
}   