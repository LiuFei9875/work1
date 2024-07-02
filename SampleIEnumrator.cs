using System.Collections;
using System.IO;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class SampleIEnumrator : MonoBehaviour
{
    public Image SampleImage;
    public Button SampleButton;
    // Start is called before the first frame update
    async UniTask Start()
    {
         Downaload();
        Fade();
    }

    IEnumerator IEnumratorDownload()
    {
        string fileURL = Path.Combine("http://10.255.46.70:8080/", "sample.zip");

        UnityWebRequest request= UnityWebRequest.Get(fileURL);

        Debug.Log($"IEnumrator下载开始{Time.frameCount}");

         request.SendWebRequest();
        while (!request.isDone)
        {
            Debug.Log(request.downloadProgress);
            yield return null;
        }

        Debug.Log($"IEnumrator下载完成{Time.frameCount}");

        string localSavePath = Path.Combine(Application.streamingAssetsPath, "downloadIEnumrator.zip");

        //协程支持了所有的异步操作
        yield return File.WriteAllBytesAsync(localSavePath, request.downloadHandler.data);
    }
    async UniTask<string> UniTaskDownload()
    {
        string fileURL = Path.Combine("http://10.255.46.70:8080/", "sample.zip");

        UnityWebRequest request = UnityWebRequest.Get(fileURL);

        Debug.Log($"UniTask下载开始{Time.frameCount}");

        request.SendWebRequest();

        while (!request.isDone)
        {
            Debug.Log(request.downloadProgress);
            await UniTask.Yield(PlayerLoopTiming.LastUpdate);
        }

        Debug.Log($"UniTask下载完成{Time.frameCount}");

        string localSavePath = Path.Combine(Application.streamingAssetsPath, "downloadUniTask.zip");

        //协程支持了所有的异步操作
        await File.WriteAllBytesAsync(localSavePath, request.downloadHandler.data);

        return localSavePath;
    }

    async void Downaload()
    {
        string fileURL = Path.Combine("http://10.255.46.70:8080/", "sample.zip");
        HttpClient client = new HttpClient();
	//await Delay(1);
        Debug.Log($"下载开始{Time.frameCount}");

        HttpResponseMessage responseMessage = await client.GetAsync(fileURL);
        Debug.Log($"下载完成{Time.frameCount}");
        byte[] bytes = await responseMessage.Content.ReadAsByteArrayAsync();

        string localSavePath = Path.Combine(Application.streamingAssetsPath, "download.zip");
        await File.WriteAllBytesAsync(localSavePath, bytes);
    }
    async UniTask Sample()
    {
        Debug.Log("异步开始");
        await UniTask.Delay(1000);
        Debug.Log("异步结束");
    }

    void Fade() {
        float alpha = 3.0f;
 	Debug.Log($"下载开始{Time.frameCount}");
        while (alpha > 0)
        {
            Debug.Log("方法执行");
            alpha -= Time.deltaTime;
            //Color color = SampleImage.color;
            //color.a = alpha;
            //SampleImage.color = color;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
