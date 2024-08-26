using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ManualCompile : MonoBehaviour
{
    // �C�ӂ̃^�C�~���O�ŃR���p�C�����g���K�[���郁�\�b�h
    public static void TriggerCompile()
    {
        // �X�N���v�g�t�@�C����t�H���_���ăC���|�[�g����
        AssetDatabase.ImportAsset("Assets", ImportAssetOptions.ForceUpdate);

        // �R���p�C�����g���K�[
        AssetDatabase.Refresh();
    }

    // �G�f�B�^�[���j���[������Ăяo����悤��
    [MenuItem("Tools/Trigger Compile")]
    public static void MenuTriggerCompile()
    {
        TriggerCompile();
    }
}
