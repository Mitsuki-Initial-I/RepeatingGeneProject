using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class SimulationManager : MonoBehaviour
{
    private Environment environment;
    private List<AI> aiControllers;
    private LogManger logManger;
    private FeedbackManager feedbackManager;

    private void Start()
    {
        // LogManagerの初期化
        logManger = new LogManger();

        // 環境の初期化
        environment = new Environment(100);

        // 遺伝子情報
        GeneticInfo deerGenes = new GeneticInfo { Strength = 50, Speed = 30, Intelligence = 40 };
        GeneticInfo wolfGenes = new GeneticInfo { Strength = 50, Speed = 30, Intelligence = 40 };

        // 生物の作成
        Creature deer = new Creature("Deer", 50, 10, deerGenes);  // 鹿
        Creature wolf = new Creature("Wolf", 80, 15, wolfGenes, true);  // 狼

        // 繁殖と捕食者の関係設定
        wolf.AddPrey(deer);

        // 感情と道徳の設定
        Morality deerMorality = new Morality(80, 20);       // 優しい
        Morality wolfMorality = new Morality(20, 80);       // 攻撃的

        AI deerAI = new AI(deer, deerMorality);
        AI wolfAI = new AI(wolf, wolfMorality);

        // AIコントローラに追加
        aiControllers = new List<AI> { deerAI, wolfAI };

        // 生物を環境に追加
        environment.AddCreature(deer);
        environment.AddCreature(wolf);

        // フィードバック
        feedbackManager = new FeedbackManager(environment.Creatures, logManger);

        // 開始ログ
        logManger.Log("Simulation started.");
    }

    private void Update()
    {
        // シミュレーションの1日分を実行
        if (Time.frameCount % 10 == 0)
        {
            environment.SimulateDay();

            foreach (var ai in aiControllers)
            {
                // 感情の追加と思考プロセスを実行
                ai.AddEmotion(new Emotion("Fear", Random.Range(0, 100)));
                ai.Think();
            }

            // ログに記録
            logManger.LogEnvironmmentState(environment);

            // 適応度を分析
            feedbackManager.AnalyzeAdaptation(environment.Temperature);

            if (environment.SimulationDays>=environment.MaxSimulationDays || (environment.IsError))
            {
                if (environment.IsError)
                {
                    Debug.Log("エラーを検知しました");
                }
                // シミュレーション終了
                this.enabled = false;
                EditorApplication.isPlaying = false;
            }
        }
    }
}