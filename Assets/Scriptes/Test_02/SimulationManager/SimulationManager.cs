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
        // LogManager�̏�����
        logManger = new LogManger();

        // ���̏�����
        environment = new Environment(100);

        // ��`�q���
        GeneticInfo deerGenes = new GeneticInfo { Strength = 50, Speed = 30, Intelligence = 40 };
        GeneticInfo wolfGenes = new GeneticInfo { Strength = 50, Speed = 30, Intelligence = 40 };

        // �����̍쐬
        Creature deer = new Creature("Deer", 50, 10, deerGenes);  // ��
        Creature wolf = new Creature("Wolf", 80, 15, wolfGenes, true);  // �T

        // �ɐB�ƕߐH�҂̊֌W�ݒ�
        wolf.AddPrey(deer);

        // ����Ɠ����̐ݒ�
        Morality deerMorality = new Morality(80, 20);       // �D����
        Morality wolfMorality = new Morality(20, 80);       // �U���I

        AI deerAI = new AI(deer, deerMorality);
        AI wolfAI = new AI(wolf, wolfMorality);

        // AI�R���g���[���ɒǉ�
        aiControllers = new List<AI> { deerAI, wolfAI };

        // ���������ɒǉ�
        environment.AddCreature(deer);
        environment.AddCreature(wolf);

        // �t�B�[�h�o�b�N
        feedbackManager = new FeedbackManager(environment.Creatures, logManger);

        // �J�n���O
        logManger.Log("Simulation started.");
    }

    private void Update()
    {
        // �V�~�����[�V������1���������s
        if (Time.frameCount % 10 == 0)
        {
            environment.SimulateDay();

            foreach (var ai in aiControllers)
            {
                // ����̒ǉ��Ǝv�l�v���Z�X�����s
                ai.AddEmotion(new Emotion("Fear", Random.Range(0, 100)));
                ai.Think();
            }

            // ���O�ɋL�^
            logManger.LogEnvironmmentState(environment);

            // �K���x�𕪐�
            feedbackManager.AnalyzeAdaptation(environment.Temperature);

            if (environment.SimulationDays>=environment.MaxSimulationDays || (environment.IsError))
            {
                if (environment.IsError)
                {
                    Debug.Log("�G���[�����m���܂���");
                }
                // �V�~�����[�V�����I��
                this.enabled = false;
                EditorApplication.isPlaying = false;
            }
        }
    }
}