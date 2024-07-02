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

        XmlElement xmlRootElement = xmlDoc.CreateElement("ѧУ����");

        xmlRootElement.InnerText = "�����ƾ���ѧ";
        xmlRootElement.SetAttribute("ʱ��", DateTime.Now.ToShortDateString());


        XmlElement xmlStudentElement = xmlDoc.CreateElement("ѧ��");

        for (int i = 0; i < 10; i++)
        {
            XmlElement xmlStudentIndexElement = xmlDoc.CreateElement("ѧ��");
            xmlStudentIndexElement.InnerText = i.ToString();

            xmlStudentElement.AppendChild(xmlStudentIndexElement);
        }


        xmlRootElement.AppendChild(xmlStudentElement);

        XmlElement xmlTeacherElement = xmlDoc.CreateElement("��ʦ");

        for (int i = 0; i < 10; i++)
        {
            XmlElement xmlTeacherIndexElement = xmlDoc.CreateElement("ѧ��");
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
        //XML.LOAD�������ֻ��Windowsƽ̨ʹ��
        string xmlPath = Path.Combine(Application.dataPath, "xmlDocSample.Sample");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlPath);

        //Node�ǽڵ��ȡ������,�����������޷�ʹ��
        foreach(XmlNode node in xmlDoc.ChildNodes)
        {
            Debug.Log(node.Name);
            XmlElement element = (XmlElement)node;

            element.SetAttribute("��̬���", "����ʱ");

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
