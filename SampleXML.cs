using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class SampleXML : MonoBehaviour
{

    public SampleScriptableObject Sample;
    // Start is called before the first frame update
    void Start()
    {
        //LoadXML();

        Sample = ScriptableObject.CreateInstance<SampleScriptableObject>();
        Sample.Index++;
        Debug.Log(Sample.Index);
    }

    void SaveXML()
    {
        XmlDocument xmlDoc = new XmlDocument();

        XmlElement xmlRootElement = xmlDoc.CreateElement("学校名称");

        xmlRootElement.InnerText = "江西财经大学";
        xmlRootElement.SetAttribute("时间", DateTime.Now.ToShortDateString());


        XmlElement xmlStudentElement = xmlDoc.CreateElement("学生");

        for (int i = 0; i < 10; i++)
        {
            XmlElement xmlStudentIndexElement = xmlDoc.CreateElement("学号");
            xmlStudentIndexElement.InnerText = i.ToString();

            xmlStudentElement.AppendChild(xmlStudentIndexElement);
        }


        xmlRootElement.AppendChild(xmlStudentElement);

        XmlElement xmlTeacherElement = xmlDoc.CreateElement("教师");

        for (int i = 0; i < 10; i++)
        {
            XmlElement xmlTeacherIndexElement = xmlDoc.CreateElement("学号");
            xmlTeacherIndexElement.InnerText = i.ToString();

            xmlTeacherElement.AppendChild(xmlTeacherIndexElement);
        }
        xmlRootElement.AppendChild(xmlTeacherElement);
        xmlDoc.AppendChild(xmlRootElement);

        string xmlPath = Path.Combine(Application.dataPath, "xmlDocSample.Sample");
        xmlDoc.Save(xmlPath);
    }

    void LoadXML()
    {
        //XML.LOAD方法最好只在Windows平台使用
        string xmlPath = Path.Combine(Application.dataPath, "xmlDocSample.Sample");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlPath);

        //Node是节点读取的类型,但部分设置无法使用
        foreach(XmlNode node in xmlDoc.ChildNodes)
        {
            Debug.Log(node.Name);
            XmlElement element = (XmlElement)node;

            element.SetAttribute("动态添加", "运行时");

            foreach(XmlNode childNode in node.ChildNodes)
            {
                Debug.Log(childNode.Name);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
