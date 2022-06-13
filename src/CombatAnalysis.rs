// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CombatAnalysis
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;

namespace WindowsApplication1
{
  pub class CombatAnalysis
  {
    pub int[,,] stats;
    pub int[,,] ustats;
    pub GameClass game;

    pub CombatAnalysis(let mut tgame: GameClass = null)
    {
      this.stats = new int[2, 41, 8];
      this.ustats = new int[100, 41, 8];
      this.game = tgame;
    }

    pub void analyse(bool attlog, bool deflog)
    {
      int attackerRegime = this.game.TempCombat.AttackerRegime;
      int defenderRegime = this.game.TempCombat.DefenderRegime;
      int icounter = this.game.TempCombat.ICounter;
      int iulistNr;
      for (int index1 = 0; index1 <= icounter; index1 += 1)
      {
        int iattacker = this.game.TempCombat.IList[index1].IAttacker;
        iulistNr = this.game.TempCombat.IList[index1].IUlistNr;
        int unitGroup = this.game.Data.SFTypeObj[this.game.TempCombat.IList[index1].ISFType].UnitGroup;
        if (this.game.TempCombat.IList[index1].IKilled > 0)
        {
          int[,,] stats1 = this.stats;
          int[,,] numArray1 = stats1;
          int index2 = iattacker;
          int index3 = index2;
          int index4 = unitGroup;
          int index5 = index4;
          int index6 = 4;
          int index7 = index6;
          int num1 = stats1[index2, index4, index6] + 1;
          numArray1[index3, index5, index7] = num1;
          int[,,] stats2 = this.stats;
          int[,,] numArray2 = stats2;
          int index8 = iattacker;
          int index9 = index8;
          int index10 = 40;
          int index11 = index10;
          int index12 = 4;
          int index13 = index12;
          int num2 = stats2[index8, index10, index12] + 1;
          numArray2[index9, index11, index13] = num2;
          int[,,] stats3 = this.stats;
          int[,,] numArray3 = stats3;
          int index14 = iattacker;
          int index15 = index14;
          int index16 = unitGroup;
          int index17 = index16;
          int index18 = 7;
          int index19 = index18;
          int num3 = stats3[index14, index16, index18] + 1;
          numArray3[index15, index17, index19] = num3;
          int[,,] ustats1 = this.ustats;
          int[,,] numArray4 = ustats1;
          int index20 = iulistNr;
          int index21 = index20;
          int index22 = unitGroup;
          int index23 = index22;
          int index24 = 4;
          int index25 = index24;
          int num4 = ustats1[index20, index22, index24] + 1;
          numArray4[index21, index23, index25] = num4;
          int[,,] ustats2 = this.ustats;
          int[,,] numArray5 = ustats2;
          int index26 = iulistNr;
          int index27 = index26;
          int index28 = 40;
          int index29 = index28;
          int index30 = 4;
          int index31 = index30;
          int num5 = ustats2[index26, index28, index30] + 1;
          numArray5[index27, index29, index31] = num5;
          int[,,] ustats3 = this.ustats;
          int[,,] numArray6 = ustats3;
          int index32 = iulistNr;
          int index33 = index32;
          int index34 = unitGroup;
          int index35 = index34;
          int index36 = 7;
          int index37 = index36;
          int num6 = ustats3[index32, index34, index36] + 1;
          numArray6[index33, index35, index37] = num6;
        }
        else if (this.game.TempCombat.IList[index1].IRetreated == 1)
        {
          int[,,] stats4 = this.stats;
          int[,,] numArray7 = stats4;
          int index38 = iattacker;
          int index39 = index38;
          int index40 = unitGroup;
          int index41 = index40;
          int index42 = 1;
          int index43 = index42;
          int num7 = stats4[index38, index40, index42] + 1;
          numArray7[index39, index41, index43] = num7;
          int[,,] stats5 = this.stats;
          int[,,] numArray8 = stats5;
          int index44 = iattacker;
          int index45 = index44;
          int index46 = 40;
          int index47 = index46;
          int index48 = 1;
          int index49 = index48;
          int num8 = stats5[index44, index46, index48] + 1;
          numArray8[index45, index47, index49] = num8;
          int[,,] stats6 = this.stats;
          int[,,] numArray9 = stats6;
          int index50 = iattacker;
          int index51 = index50;
          int index52 = unitGroup;
          int index53 = index52;
          int index54 = 7;
          int index55 = index54;
          int num9 = stats6[index50, index52, index54] + 1;
          numArray9[index51, index53, index55] = num9;
          int[,,] ustats4 = this.ustats;
          int[,,] numArray10 = ustats4;
          int index56 = iulistNr;
          int index57 = index56;
          int index58 = unitGroup;
          int index59 = index58;
          int index60 = 1;
          int index61 = index60;
          int num10 = ustats4[index56, index58, index60] + 1;
          numArray10[index57, index59, index61] = num10;
          int[,,] ustats5 = this.ustats;
          int[,,] numArray11 = ustats5;
          int index62 = iulistNr;
          int index63 = index62;
          int index64 = 40;
          int index65 = index64;
          int index66 = 1;
          int index67 = index66;
          int num11 = ustats5[index62, index64, index66] + 1;
          numArray11[index63, index65, index67] = num11;
          int[,,] ustats6 = this.ustats;
          int[,,] numArray12 = ustats6;
          int index68 = iulistNr;
          int index69 = index68;
          int index70 = unitGroup;
          int index71 = index70;
          int index72 = 7;
          int index73 = index72;
          int num12 = ustats6[index68, index70, index72] + 1;
          numArray12[index69, index71, index73] = num12;
        }
        else if (this.game.TempCombat.IList[index1].IRetreat > 0 & this.game.TempCombat.IList[index1].IRetreated == 0)
        {
          int[,,] stats7 = this.stats;
          int[,,] numArray13 = stats7;
          int index74 = iattacker;
          int index75 = index74;
          int index76 = unitGroup;
          int index77 = index76;
          int index78 = 5;
          int index79 = index78;
          int num13 = stats7[index74, index76, index78] + 1;
          numArray13[index75, index77, index79] = num13;
          int[,,] stats8 = this.stats;
          int[,,] numArray14 = stats8;
          int index80 = iattacker;
          int index81 = index80;
          int index82 = 40;
          int index83 = index82;
          int index84 = 5;
          int index85 = index84;
          int num14 = stats8[index80, index82, index84] + 1;
          numArray14[index81, index83, index85] = num14;
          int[,,] stats9 = this.stats;
          int[,,] numArray15 = stats9;
          int index86 = iattacker;
          int index87 = index86;
          int index88 = unitGroup;
          int index89 = index88;
          int index90 = 7;
          int index91 = index90;
          int num15 = stats9[index86, index88, index90] + 1;
          numArray15[index87, index89, index91] = num15;
          int[,,] ustats7 = this.ustats;
          int[,,] numArray16 = ustats7;
          int index92 = iulistNr;
          int index93 = index92;
          int index94 = unitGroup;
          int index95 = index94;
          int index96 = 5;
          int index97 = index96;
          int num16 = ustats7[index92, index94, index96] + 1;
          numArray16[index93, index95, index97] = num16;
          int[,,] ustats8 = this.ustats;
          int[,,] numArray17 = ustats8;
          int index98 = iulistNr;
          int index99 = index98;
          int index100 = 40;
          int index101 = index100;
          int index102 = 5;
          int index103 = index102;
          int num17 = ustats8[index98, index100, index102] + 1;
          numArray17[index99, index101, index103] = num17;
          int[,,] ustats9 = this.ustats;
          int[,,] numArray18 = ustats9;
          int index104 = iulistNr;
          int index105 = index104;
          int index106 = unitGroup;
          int index107 = index106;
          int index108 = 7;
          int index109 = index108;
          int num18 = ustats9[index104, index106, index108] + 1;
          numArray18[index105, index107, index109] = num18;
        }
        else
        {
          int[,,] stats10 = this.stats;
          int[,,] numArray19 = stats10;
          int index110 = iattacker;
          int index111 = index110;
          int index112 = unitGroup;
          int index113 = index112;
          int index114 = 6;
          int index115 = index114;
          int num19 = stats10[index110, index112, index114] + 1;
          numArray19[index111, index113, index115] = num19;
          int[,,] stats11 = this.stats;
          int[,,] numArray20 = stats11;
          int index116 = iattacker;
          int index117 = index116;
          int index118 = 40;
          int index119 = index118;
          int index120 = 6;
          int index121 = index120;
          int num20 = stats11[index116, index118, index120] + 1;
          numArray20[index117, index119, index121] = num20;
          int[,,] stats12 = this.stats;
          int[,,] numArray21 = stats12;
          int index122 = iattacker;
          int index123 = index122;
          int index124 = unitGroup;
          int index125 = index124;
          int index126 = 7;
          int index127 = index126;
          int num21 = stats12[index122, index124, index126] + 1;
          numArray21[index123, index125, index127] = num21;
          int[,,] ustats10 = this.ustats;
          int[,,] numArray22 = ustats10;
          int index128 = iulistNr;
          int index129 = index128;
          int index130 = unitGroup;
          int index131 = index130;
          int index132 = 6;
          int index133 = index132;
          int num22 = ustats10[index128, index130, index132] + 1;
          numArray22[index129, index131, index133] = num22;
          int[,,] ustats11 = this.ustats;
          int[,,] numArray23 = ustats11;
          int index134 = iulistNr;
          int index135 = index134;
          int index136 = 40;
          int index137 = index136;
          int index138 = 6;
          int index139 = index138;
          int num23 = ustats11[index134, index136, index138] + 1;
          numArray23[index135, index137, index139] = num23;
          int[,,] ustats12 = this.ustats;
          int[,,] numArray24 = ustats12;
          int index140 = iulistNr;
          int index141 = index140;
          int index142 = unitGroup;
          int index143 = index142;
          int index144 = 7;
          int index145 = index144;
          int num24 = ustats12[index140, index142, index144] + 1;
          numArray24[index141, index143, index145] = num24;
        }
        if (this.game.TempCombat.IList[index1].IBreakTrough > 0 & this.game.TempCombat.IList[index1].IRetreated == 0 & this.game.TempCombat.IList[index1].IKilled == 0 & this.game.TempCombat.IList[index1].IRetreat == 0)
        {
          int[,,] stats13 = this.stats;
          int[,,] numArray25 = stats13;
          int index146 = iattacker;
          int index147 = index146;
          int index148 = unitGroup;
          int index149 = index148;
          int index150 = 0;
          int index151 = index150;
          int num25 = stats13[index146, index148, index150] + 1;
          numArray25[index147, index149, index151] = num25;
          int[,,] stats14 = this.stats;
          int[,,] numArray26 = stats14;
          int index152 = iattacker;
          int index153 = index152;
          int index154 = 40;
          int index155 = index154;
          int index156 = 0;
          int index157 = index156;
          int num26 = stats14[index152, index154, index156] + 1;
          numArray26[index153, index155, index157] = num26;
          int[,,] stats15 = this.stats;
          int[,,] numArray27 = stats15;
          int index158 = iattacker;
          int index159 = index158;
          int index160 = unitGroup;
          int index161 = index160;
          int index162 = 7;
          int index163 = index162;
          int num27 = stats15[index158, index160, index162] + 1;
          numArray27[index159, index161, index163] = num27;
          int[,,] ustats13 = this.ustats;
          int[,,] numArray28 = ustats13;
          int index164 = iulistNr;
          int index165 = index164;
          int index166 = unitGroup;
          int index167 = index166;
          int index168 = 0;
          int index169 = index168;
          int num28 = ustats13[index164, index166, index168] + 1;
          numArray28[index165, index167, index169] = num28;
          int[,,] ustats14 = this.ustats;
          int[,,] numArray29 = ustats14;
          int index170 = iulistNr;
          int index171 = index170;
          int index172 = 40;
          int index173 = index172;
          int index174 = 0;
          int index175 = index174;
          int num29 = ustats14[index170, index172, index174] + 1;
          numArray29[index171, index173, index175] = num29;
          int[,,] ustats15 = this.ustats;
          int[,,] numArray30 = ustats15;
          int index176 = iulistNr;
          int index177 = index176;
          int index178 = unitGroup;
          int index179 = index178;
          int index180 = 7;
          int index181 = index180;
          int num30 = ustats15[index176, index178, index180] + 1;
          numArray30[index177, index179, index181] = num30;
        }
      }
      int ucounter = this.game.TempCombat.UCounter;
      for (int index = 0; index <= ucounter; index += 1)
      {
        int num = 0;
        if (this.game.TempCombat.UList[index].Uattacker == 0 & !deflog)
          num = 1;
        if (this.game.TempCombat.UList[index].Uattacker == 1 & !attlog)
          num = 1;
        if (this.game.TempCombat.BattleEnded <= 0)
          num = 1;
        if (num == 0)
          "Lost " + Conversion.Str((object) (this.ustats[iulistNr, 40, 4] + this.ustats[iulistNr, 40, 2])) + " troops in combat at " + Conversion.Str((object) this.game.TempCombat.CombatTarget.x) + "," + Conversion.Str((object) this.game.TempCombat.CombatTarget.y);
      }
    }
  }
}
