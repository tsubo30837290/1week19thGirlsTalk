using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParamsSO : ScriptableObject
{
    [Header("バナナの移動速度")]
    public float bananaSpeed;

    [Header("バナナの生成間隔")]
    public float bananaInterval;

    [Header("バナナに当たった時に1度で上がる量")]
    public float bananaHitGauge;

    [Header("Playerの移動速度")]
    public float playerSpeed;

    [Header("トッピング弾の速度")]
    public float bulletSpeed;

    [Header("1度に上がるスコアの量")]
    public int score;

    [Header("1度に上がるSPの量")]
    public float sp;

    [Header("1度に上がるスコアの量(Fever)")]
    public int feverScore;

    [Header("制限時間")]
    public float timeLimit;

    //MyScriptableObjectが保存してある場所のパス
    public const string PATH = "ParamsSO";

    //MyScriptableObjectの実体
    private static ParamsSO _entity;
    public static ParamsSO Entity
    {
        get
        {
            //初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<ParamsSO>(PATH);

                //ロード出来なかった場合はエラーログを表示
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}
