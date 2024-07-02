using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SampleCSV : MonoBehaviour
{
    public string CarriageReturn = "\r";
    public string LineFeed = "\n";

    string SeparateSymbol = ",";

    string LineFeedSymbol = "\r\n";

    // Start is called before the first frame update
    void Start()
    {
        LoadCSV();
    }

    void LoadCSV()
    {
        string csvPath = Path.Combine(Application.dataPath, "Sample.csv");
        string csvString = File.ReadAllText(csvPath);

        string[] csvRowDatas = csvString.Split(LineFeedSymbol);

        //��Ϊ��һ���Ǳ�ͷ,����Ҫ���,�������ﲻ��ȡ��ͷ
        for(int i = 1; i < csvRowDatas.Length; i++)
        {

            string[] csvColunmDatas = csvRowDatas[i].Split(SeparateSymbol);

            for(int j = 0; j < csvColunmDatas.Length; j++)
            {
                Debug.Log(csvColunmDatas[j]);
            }
        }
    }

    void SaveCSV()
    {
        DataTable csvSample = new DataTable("ʾ��CSV");
        csvSample.Columns.Add("���");
        csvSample.Columns.Add("����");
        csvSample.Columns.Add("�ɼ�");

        DataRow dataRow = csvSample.NewRow();

        dataRow["���"] = 0;
        dataRow["����"] = "����";
        dataRow["�ɼ�"] = Random.Range(50, 100);

        csvSample.Rows.Add(dataRow);

        dataRow = csvSample.NewRow();
        dataRow[0] = 1;
        dataRow[1] = "����";
        dataRow[2] = Random.Range(50, 100);

        csvSample.Rows.Add(dataRow);


        for (int i = 1; i < 10; i++)
        {
            dataRow = csvSample.NewRow();

            dataRow[0] = i;
            dataRow[1] = "����" + i;
            dataRow[2] = Random.Range(50, 100);

            csvSample.Rows.Add(dataRow);
        }

        StringBuilder csvString = new StringBuilder();


        //������ӱ�ͷ
        for (int j = 0; j < csvSample.Columns.Count; j++)
        {
            csvString.Append(csvSample.Columns[j].ColumnName);

            if (j < csvSample.Columns.Count - 1)
            {
                csvString.Append(SeparateSymbol);
            }
        }

        //����ÿһ��,����ĳһ��ĳһ�е����ݴ��뵽�ַ�����
        for (int i = 0; i < csvSample.Rows.Count; i++)
        {
            csvString.Append(LineFeedSymbol);


            for (int j = 0; j < csvSample.Columns.Count; j++)
            {
                csvString.Append(csvSample.Rows[i][j].ToString());

                if (j < csvSample.Columns.Count - 1)
                {
                    csvString.Append(SeparateSymbol);
                }
            }
        }

        string csvPath = Path.Combine(Application.dataPath, "csv.Sample");

        File.WriteAllText(csvPath, csvString.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
