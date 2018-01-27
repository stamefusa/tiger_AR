using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class clickPlane : MonoBehaviour {
	// tiger
	public GameObject tiger;
	private GameObject myTiger = null;
	// クリックした位置座標
	private Vector3 clickPosition;

	// 画面キャプチャ可能フラグ
	int captureStatus = 0;
	// 画像ファイルベース名
	string filename_base = "";

	// Use this for initialization
	void Start () {
		/*
		print (System.DateTime.Now.ToFileTime().ToString());
		// 画像保存用ディレクトリ作成
		Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "tigerImages"));
		*/
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			/*
			filename_base = "tigerImages/"
						  + System.DateTime.Now.Year.ToString ("D2")
						  + System.DateTime.Now.Month.ToString ("D2")
						  + System.DateTime.Now.Day.ToString ("D2")
						  + "_"
						  + System.DateTime.Now.Hour.ToString ("D2")
						  + System.DateTime.Now.Minute.ToString ("D2")
						  + System.DateTime.Now.Second.ToString ("D2")
						  + "_"
						  + System.DateTime.Now.Millisecond.ToString ("D5")
						  + "_";
						  */

			// 既にオブジェクトが存在していたら消す
			if (myTiger != null) {
				Destroy (myTiger);
			}

			clickPosition = Input.mousePosition;
			clickPosition.z = 13f;
			myTiger = Instantiate (tiger, Camera.main.ScreenToWorldPoint(clickPosition), Quaternion.Euler(0, 180, 0));
			myTiger.transform.localScale = Vector3.one * 3f;
			myTiger.AddComponent<Rigidbody> ().useGravity = true;
		}

		// オブジェクトの位置を原点に近づける
		if (myTiger != null) { 
			Vector3 pos = myTiger.transform.position;
			pos.z -= 0.8f;
			myTiger.transform.position = pos;
		}

		/*
		// キャプチャ
		if (myTiger != null && myTiger.transform.position.z < 15f && captureStatus == 0) {
			captureStatus = 1;
			ScreenCapture.CaptureScreenshot (filename_base + "001.png");
		}
		if (myTiger != null && myTiger.transform.position.z < 12f && captureStatus == 1) {
			captureStatus = 2;
			ScreenCapture.CaptureScreenshot (filename_base + "002.png");
		}
		if (myTiger != null && myTiger.transform.position.z < 9f && captureStatus == 2) {
			captureStatus = 3;
			ScreenCapture.CaptureScreenshot (filename_base + "003.png");
		}
		if (myTiger != null && myTiger.transform.position.z < 6f && captureStatus == 3) {
			captureStatus = 4;
			ScreenCapture.CaptureScreenshot (filename_base + "004.png");
		}
		if (myTiger != null && myTiger.transform.position.z < 3f && captureStatus == 4) {
			captureStatus = 5;
			ScreenCapture.CaptureScreenshot (filename_base + "005.png");
		}
		if (myTiger != null && myTiger.transform.position.z < 0f && captureStatus == 5) {
			captureStatus = 9;
			ScreenCapture.CaptureScreenshot (filename_base + "006.png");
		}
		*/

		// オブジェクトの削除
		if (myTiger != null && myTiger.transform.position.z < -3f){ 
			Destroy (myTiger);
			captureStatus = 0;
		}
	}
}
