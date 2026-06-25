using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using static FantasyMania.TurnBasedCombat.GameEnums;

public class BattleSceneKeyBag : IEquatable<BattleSceneKeyBag>
{
    public string ChrID;
    public BattleScenePosition battleScenePosition;

    public BattleSceneKeyBag(string _ChrID, BattleScenePosition _battleScenePosition)
    {
        ChrID = _ChrID;
        battleScenePosition = _battleScenePosition;
    }

    public BattleSceneKeyBag(BattleScenePosition _battleScenePosition,string _ChrID="NoneChr")
    {
        ChrID = _ChrID;
        battleScenePosition = _battleScenePosition;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as BattleSceneKeyBag);
    }

    public bool Equals(BattleSceneKeyBag other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return ChrID == other.ChrID && battleScenePosition == other.battleScenePosition;
    }

    public override int GetHashCode()
    {
        // 使用HashCode.Combine（.NET Core 2.1+推荐）
        return HashCode.Combine(ChrID, battleScenePosition);
    }

    public static bool operator ==(BattleSceneKeyBag left, BattleSceneKeyBag right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(BattleSceneKeyBag left, BattleSceneKeyBag right) => !(left == right);
}
