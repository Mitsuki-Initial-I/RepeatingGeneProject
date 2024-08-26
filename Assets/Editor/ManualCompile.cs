using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ManualCompile : MonoBehaviour
{
    // 任意のタイミングでコンパイルをトリガーするメソッド
    public static void TriggerCompile()
    {
        // スクリプトファイルやフォルダを再インポートする
        AssetDatabase.ImportAsset("Assets", ImportAssetOptions.ForceUpdate);

        // コンパイルをトリガー
        AssetDatabase.Refresh();
    }

    // エディターメニューからも呼び出せるように
    [MenuItem("Tools/Trigger Compile")]
    public static void MenuTriggerCompile()
    {
        TriggerCompile();
    }
}
