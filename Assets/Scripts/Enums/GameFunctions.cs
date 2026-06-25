using UnityEngine;
using System.Collections.Generic;
using System;

namespace FantasyMania.TurnBasedCombat
{
    public class GameFunctions : BaseManager<GameFunctions>
    {
        // 存放返回 float、参数为 uint 的函数
        private Dictionary<string, Func<uint, float>> floatFuncDict;
        // 存放返回 long、参数为 long 的函数
        private Dictionary<string, Func<long, long>> longFuncDict;

        private GameFunctions()
        {
            InitializeFloatFuncDict();
            InitializeLongFuncDict();
        }

        private void InitializeFloatFuncDict()
        {
            floatFuncDict = new Dictionary<string, Func<uint, float>>
            {
                { "NoneFunc", NoneFunc },
                { "AddFunc1", AddFunc1 },
                { "MEquiLevelUpFunc", MEquiLevelUpFunc },
                { "AEquiLevelUpFunc", AEquiLevelUpFunc }
            };
        }

        private void InitializeLongFuncDict()
        {
            longFuncDict = new Dictionary<string, Func<long, long>>
            {
                { "ExpGroethFunc", ExpGroethFunc },
                { "LevelCoinFunction_1", LevelCoinFunction_1 },
                { "LevelCoinFunction_2", LevelCoinFunction_2 },
                { "LevelCoinFunction_3", LevelCoinFunction_3 },
                { "LevelCoinFunction_4", LevelCoinFunction_4 },
                { "LevelCoinFunction_5", LevelCoinFunction_5 }
            };
        }

        // 通过字符串调用 float 类型函数
        public float CallFloatFunc(string funcName, uint value)
        {
            if (floatFuncDict.TryGetValue(funcName, out var func))
                return func(value);
            throw new ArgumentException($"未知的 float 函数名: {funcName}");
        }

        // 通过字符串调用 long 类型函数
        public long CallLongFunc(string funcName, long value)
        {
            if (longFuncDict.TryGetValue(funcName, out var func))
                return func(value);
            throw new ArgumentException($"未知的 long 函数名: {funcName}");
        }

        // 如果需要直接获取委托（支持索引风格访问）
        public Func<uint, float> this[string funcName] => floatFuncDict.ContainsKey(funcName) ? floatFuncDict[funcName] : null;

        // 以下是你原有的方法（保持不变）...
        public float NoneFunc(uint value) => 1;
        public float AddFunc1(uint value) => 1 + (value - 1) * 2f;
        public long ExpGroethFunc(long expNum) => (long)(expNum * 1.2);
        public long LevelCoinFunction_1(long coinNum) => (long)(coinNum * 1.1);
        public long LevelCoinFunction_2(long coinNum) => (long)(coinNum * 1.3);
        public long LevelCoinFunction_3(long coinNum) => (long)(coinNum * 1.6);
        public long LevelCoinFunction_4(long coinNum) => (long)(coinNum * 1.8);
        public long LevelCoinFunction_5(long coinNum) => (long)(coinNum * 2.0);
        public float MEquiLevelUpFunc(uint value) => 1 + (value - 1) * 0.02f;
        public float AEquiLevelUpFunc(uint value) => 1 + (value - 1) * 0.02f;
    }
}