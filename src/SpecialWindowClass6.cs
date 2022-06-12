// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SpecialWindowClass6
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SpecialWindowClass6 : WindowClass
  {
    private ListClass ListObj;
    private ListClass List2Obj;
    private int listId;
    private int list2Id;
    private int useWidth;
    private int useHeight;
    private int slotAssetPresentation;
    private int slotPerks;
    private int slotPreviewAssetLog;
    private int slotHexPerk;
    private int slotPaid;
    private int slotHexNames;
    private int slotLandscape;
    private int slotAssetLog;
    private int slotConstruction;
    private int slotZones;
    private int slotRegKey;
    private int slotDetail;
    private int slotRegReg;
    private int slotRegZoneKeys;
    private int slotItemType;
    private int slotRegimes;
    private int slotZoneKeys;
    private int slotAssetTypes;
    private int slotAssets;
    private int slotCharacter;
    private int slotPortrait;
    private int slotModel;
    private int slotModelType;
    private int slotModelTech;
    private int slotTechType;
    private int slotModelStatName;
    private int slotModelStatBefore;
    private int slotModelStat;
    private int slotQuality;
    private int slotChoice;
    private int slotLog;
    private int slotOldChar;
    private int slotProfileDocs;
    private int slotSkills;
    private int slotSkillTypes;
    private int slotTraits;
    private int slotFactionProfile;
    private int slotFactions;
    private int slotFeatFx;
    private int slotFeats;
    private int slotFeatTypes;
    private int slotFlagInstructions;
    private int slotFlags;
    private int slotCulture;
    private int[] assetButton;
    private int assetButtonCounter;
    private int[] assetButtonData;
    private StringListClass leaderStr;
    private SimpleList ColList;
    private int maxSelection;
    private int curSelection;
    private int but0id;
    private int but1id;
    private int but2id;
    private int but3id;
    private int but4id;
    private string[] groupNames;
    private string[] colNames;
    private int FIX_KEY_RELATION;
    private int FIX_KEY_CAPLEVEL;
    private int FIX_KEY_SUITABILITY;
    private int FIX_KEY_LOYALTY;
    private int FIX_KEY_SENIORITY;
    private int FIX_KEY_TR;
    private int FIX_KEY_CR;
    private int FIX_KEY_IPR;
    private int FIX_KEY_FACTION;
    private int FIX_KEY_AGE;
    private int FIX_KEY_NATRELPOINT;
    private int FIX_JOB_RESERVE;
    private int FIX_JOB_OHQ;
    private int FIX_JOB_SHQ;
    private int FIX_JOB_DIRECTOR;
    private int FIX_JOB_ADVISOR;
    private int FIX_JOB_SECRETARY;
    private int FIX_JOB_GOVERNOR;
    private int FIX_STAT_STR;
    private int FIX_STAT_WAR;
    private int FIX_STAT_CHA;
    private int FIX_STAT_INT;
    private int FIX_STAT_WIL;
    private int[] FIX_SKILL;
    private int FIX_PERS_EMOT;
    private int FIX_PERS_HERO;
    private int FIX_PERS_AMB;
    private int FIX_PERS_AUTH;
    private int FIX_PERS_EGO;
    private int FIX_PERS_COR;
    private int FIX_PERS_THEFT;
    private int[] tempColId;

    public override void Dispose() => base.Dispose();

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      return base.HandleMouseMove(x, y);
    }

    public SpecialWindowClass6(ref GameClass tGame, int tUseWidth, int tUseHeight)
      : base(ref tGame, tUseWidth, tUseHeight, 8)
    {
      this.ListObj = new ListClass();
      this.List2Obj = new ListClass();
      this.assetButton = new int[600];
      this.assetButtonCounter = -1;
      this.assetButtonData = new int[600];
      this.maxSelection = 0;
      this.curSelection = 0;
      this.groupNames = new string[100];
      this.colNames = new string[1000];
      this.FIX_KEY_RELATION = 101;
      this.FIX_KEY_CAPLEVEL = 102;
      this.FIX_KEY_SUITABILITY = 103;
      this.FIX_KEY_LOYALTY = 104;
      this.FIX_KEY_SENIORITY = 105;
      this.FIX_KEY_TR = 106;
      this.FIX_KEY_CR = 107;
      this.FIX_KEY_IPR = 108;
      this.FIX_KEY_FACTION = 109;
      this.FIX_KEY_AGE = 110;
      this.FIX_KEY_NATRELPOINT = 111;
      this.FIX_JOB_RESERVE = 1;
      this.FIX_JOB_OHQ = 3;
      this.FIX_JOB_SHQ = 4;
      this.FIX_JOB_DIRECTOR = 5;
      this.FIX_JOB_ADVISOR = 6;
      this.FIX_JOB_SECRETARY = 8;
      this.FIX_JOB_GOVERNOR = 10;
      this.FIX_STAT_STR = 401;
      this.FIX_STAT_WAR = 402;
      this.FIX_STAT_CHA = 403;
      this.FIX_STAT_INT = 404;
      this.FIX_STAT_WIL = 405;
      this.FIX_SKILL = new int[300];
      this.FIX_PERS_EMOT = 501;
      this.FIX_PERS_HERO = 502;
      this.FIX_PERS_AMB = 503;
      this.FIX_PERS_AUTH = 504;
      this.FIX_PERS_EGO = 505;
      this.FIX_PERS_COR = 506;
      this.FIX_PERS_THEFT = 507;
      this.tempColId = new int[1000];
      this.useWidth = tUseWidth;
      this.useHeight = tUseHeight;
      this.colNames[this.FIX_KEY_RELATION] = "Relation";
      this.colNames[this.FIX_KEY_CAPLEVEL] = "Capability Lvl";
      this.colNames[this.FIX_KEY_SUITABILITY] = "Suitability";
      this.colNames[this.FIX_KEY_LOYALTY] = "Loyalty";
      this.colNames[this.FIX_KEY_SENIORITY] = "Seniority";
      this.colNames[this.FIX_KEY_TR] = "Technical Rating";
      this.colNames[this.FIX_KEY_CR] = "Command Rating";
      this.colNames[this.FIX_KEY_IPR] = "Interpersonal Rating";
      this.colNames[this.FIX_KEY_FACTION] = "Faction";
      this.colNames[this.FIX_KEY_AGE] = "Age";
      this.colNames[this.FIX_KEY_NATRELPOINT] = "Natural Relation Point";
      this.colNames[this.FIX_JOB_ADVISOR] = "Advisor";
      this.colNames[this.FIX_JOB_DIRECTOR] = "Director";
      this.colNames[this.FIX_JOB_GOVERNOR] = "Governor";
      this.colNames[this.FIX_JOB_OHQ] = "OHQ Commander";
      this.colNames[this.FIX_JOB_RESERVE] = "Reserve Pool";
      this.colNames[this.FIX_JOB_SECRETARY] = "Secretary";
      this.colNames[this.FIX_JOB_SHQ] = "SHQ Commander";
      this.colNames[this.FIX_STAT_CHA] = "Charisma";
      this.colNames[this.FIX_STAT_INT] = "Intelligence";
      this.colNames[this.FIX_STAT_STR] = "Strength";
      this.colNames[this.FIX_STAT_WAR] = "War";
      this.colNames[this.FIX_STAT_WIL] = "Willpower";
      this.colNames[this.FIX_PERS_AMB] = "Ambition";
      this.colNames[this.FIX_PERS_AUTH] = "Authority";
      this.colNames[this.FIX_PERS_COR] = "Corruption";
      this.colNames[this.FIX_PERS_EGO] = "Egoism";
      this.colNames[this.FIX_PERS_EMOT] = "Emotional";
      this.colNames[this.FIX_PERS_HERO] = "Heroic";
      this.colNames[this.FIX_PERS_THEFT] = "Theft";
      this.groupNames[1] = "Job Type";
      this.groupNames[2] = "Key Info";
      this.groupNames[3] = "Stats";
      this.groupNames[4] = "Technical Skills";
      this.groupNames[5] = "Command Skills";
      this.groupNames[6] = "Interpersonal Skills";
      this.groupNames[7] = "Non-Grouped Skills";
      this.groupNames[8] = "Personality";
      this.groupNames[9] = "Aux. Info";
      string libName = "SE_Data";
      this.slotCharacter = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      this.slotRegKey = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      this.slotFlagInstructions = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 169, 0, 0));
      this.slotFlags = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 168, 0, 0));
      this.slotRegimes = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0));
      this.slotCulture = tGame.HandyFunctionsObj.GetStringListByID(tGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
      this.slotOldChar = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 365, 0, 0));
      this.slotTraits = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 197, 0, 0));
      this.slotSkills = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 199, 0, 0));
      this.slotLog = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 198, 0, 0));
      this.slotSkillTypes = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 203, 0, 0));
      this.slotProfileDocs = tGame.HandyFunctionsObj.GetStringListByID(tGame.EventRelatedObj.CheckStringlistID(libName, 258, 0, 0));
      this.slotFeats = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 376, 0, 0));
      this.slotFeatTypes = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 377, 0, 0));
      this.slotFeatFx = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 378, 0, 0));
      this.slotFactions = tGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 200, 0, 0));
      this.slotFactionProfile = tGame.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 202, 0, 0));
      this.ColList = new SimpleList();
      int length = this.game.Data.StringListObj[this.slotSkillTypes].Length;
      for (int index1 = 0; index1 <= length; ++index1)
      {
        int index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotSkillTypes].Data[index1, 0]));
        string str = this.game.Data.StringListObj[this.slotSkillTypes].Data[index1, 1];
        int num = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotSkillTypes].Data[index1, 12]));
        if (Operators.CompareString(str.ToLower(), "n/a", false) != 0)
        {
          int tid = 200 + index2;
          this.FIX_SKILL[index2] = tid;
          this.colNames[tid] = str;
          if (num == 2)
            this.ColList.Add(tid, 1, 4);
          if (num == 3)
            this.ColList.Add(tid, 1, 5);
          if (num == 1)
            this.ColList.Add(tid, 1, 6);
          if (num == 0)
            this.ColList.Add(tid, 1, 7);
        }
      }
      this.assetButtonCounter = -1;
      if (Information.IsNothing((object) this.game.EditObj.se1_leaderColumns))
      {
        this.game.EditObj.se1_leaderColumns = new SimpleList();
        this.game.EditObj.se1_leaderColumns.Add(this.FIX_KEY_RELATION, 0);
        this.game.EditObj.se1_leaderColumns.Add(this.FIX_KEY_NATRELPOINT, 0);
        this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_ADVISOR, 0);
        this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_DIRECTOR, 0);
        this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_GOVERNOR, 0);
        this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_OHQ, 0);
        this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_RESERVE, 0);
        this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_SECRETARY, 0);
        this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_SHQ, 0);
      }
      if (this.game.EditObj.se1_leaderGroup < 1)
        this.game.EditObj.se1_leaderGroup = 1;
      this.ColList.Add(this.FIX_JOB_ADVISOR, 1, 1);
      this.ColList.Add(this.FIX_JOB_DIRECTOR, 1, 1);
      this.ColList.Add(this.FIX_JOB_GOVERNOR, 1, 1);
      this.ColList.Add(this.FIX_JOB_OHQ, 1, 1);
      this.ColList.Add(this.FIX_JOB_RESERVE, 1, 1);
      this.ColList.Add(this.FIX_JOB_SECRETARY, 1, 1);
      this.ColList.Add(this.FIX_JOB_SHQ, 1, 1);
      this.ColList.Add(this.FIX_KEY_RELATION, 1, 2);
      this.ColList.Add(this.FIX_KEY_NATRELPOINT, 1, 2);
      this.ColList.Add(this.FIX_KEY_CAPLEVEL, 1, 2);
      this.ColList.Add(this.FIX_KEY_SUITABILITY, 1, 2);
      this.ColList.Add(this.FIX_KEY_LOYALTY, 1, 2);
      this.ColList.Add(this.FIX_KEY_SENIORITY, 1, 2);
      this.ColList.Add(this.FIX_KEY_TR, 1, 2);
      this.ColList.Add(this.FIX_KEY_CR, 1, 2);
      this.ColList.Add(this.FIX_KEY_IPR, 1, 2);
      this.ColList.Add(this.FIX_KEY_FACTION, 1, 2);
      this.ColList.Add(this.FIX_KEY_AGE, 1, 2);
      this.ColList.Add(this.FIX_STAT_STR, 1, 3);
      this.ColList.Add(this.FIX_STAT_WAR, 1, 3);
      this.ColList.Add(this.FIX_STAT_CHA, 1, 3);
      this.ColList.Add(this.FIX_STAT_INT, 1, 3);
      this.ColList.Add(this.FIX_STAT_WIL, 1, 3);
      this.ColList.Add(this.FIX_PERS_EMOT, 1, 8);
      this.ColList.Add(this.FIX_PERS_HERO, 1, 8);
      this.ColList.Add(this.FIX_PERS_AMB, 1, 8);
      this.ColList.Add(this.FIX_PERS_AUTH, 1, 8);
      this.ColList.Add(this.FIX_PERS_EGO, 1, 8);
      this.ColList.Add(this.FIX_PERS_COR, 1, 8);
      this.ColList.Add(this.FIX_PERS_THEFT, 1, 8);
      this.ReCalculate();
      this.dostuff();
    }

    public void ReCalculate()
    {
      int id = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      int counter1 = this.game.EditObj.se1_leaderColumns.Counter;
      for (int index = 0; index <= counter1; ++index)
        this.game.EditObj.se1_leaderColumns.Data5[index] = this.game.EditObj.se1_leaderColumns.Id[index];
      this.game.EditObj.se1_leaderColumns.SortOnData5();
      this.leaderStr = new StringListClass(0);
      this.maxSelection = (int) Math.Round(Conversion.Val((object) ((double) (this.useWidth - 550) / 50.0)));
      this.curSelection = 0;
      this.leaderStr.AddCol(-1, "Char ID");
      int counter2 = this.game.EditObj.se1_leaderColumns.Counter;
      for (int index = 0; index <= counter2; ++index)
      {
        string colName = this.colNames[this.game.EditObj.se1_leaderColumns.Id[index]];
        if (this.game.EditObj.se1_leaderColumns.Id[index] > 100)
        {
          ++this.curSelection;
          this.leaderStr.AddCol(this.curSelection, colName);
          this.tempColId[this.curSelection] = this.game.EditObj.se1_leaderColumns.Id[index];
        }
      }
      int num1 = (int) Math.Round(Conversion.Val((object) this.game.Data.StringListObj[this.slotSkillTypes].GetHighestValue(0)));
      int length1 = this.game.Data.StringListObj[this.slotCharacter].Length;
      for (int index1 = 0; index1 <= length1; ++index1)
      {
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 5])) == id)
        {
          int num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 0]));
          int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 6]));
          bool flag1 = false;
          int counter3 = this.game.EditObj.se1_leaderColumns.Counter;
          for (int index2 = 0; index2 <= counter3; ++index2)
          {
            int num4 = this.game.EditObj.se1_leaderColumns.Id[index2];
            if (num4 < 20 && num3 == num4)
              flag1 = true;
          }
          if (flag1)
          {
            this.leaderStr.AddRow(this.leaderStr.Length);
            int length2 = this.leaderStr.Length;
            this.leaderStr.Data[length2, 0] = num2.ToString();
            int num5 = -1;
            int counter4 = this.game.EditObj.se1_leaderColumns.Counter;
            for (int index3 = 0; index3 <= counter4; ++index3)
            {
              bool flag2 = false;
              int num6 = this.game.EditObj.se1_leaderColumns.Id[index3];
              if (num6 >= 100)
              {
                ++num5;
                int num7 = this.game.EditObj.se1_leaderColumns.Weight[index3];
                string str1 = "";
                string str2 = "";
                int nr;
                if (num6 == this.FIX_KEY_RELATION)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 20]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_KEY_NATRELPOINT)
                {
                  int charId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 0]));
                  FunctionFeedback naturalRelationPoint = this.game.EventRelatedObj.Helper_GetCharacterNaturalRelationPoint(id, charId);
                  nr = naturalRelationPoint.value;
                  str1 = nr.ToString();
                  str2 = naturalRelationPoint.texty;
                }
                if (num6 == this.FIX_KEY_CAPLEVEL)
                {
                  flag2 = true;
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 1]));
                  str1 = nr.ToString();
                  if (nr > 0)
                    str1 = this.game.HandyFunctionsObj.GetRomanNumerical(nr);
                }
                if (num6 == this.FIX_KEY_SUITABILITY)
                {
                  nr = this.game.EventRelatedObj.Helper_GetCharacterSuitabilityRating((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 0])), (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 6])), (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 7])));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_KEY_LOYALTY)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 19]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_KEY_SENIORITY)
                {
                  nr = this.game.EventRelatedObj.Helper_GetCharacterSeniorityRanking(id, num2);
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_KEY_TR)
                {
                  nr = this.game.EventRelatedObj.Helper_GetCharacterTechnicalRating(num2);
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_KEY_CR)
                {
                  nr = this.game.EventRelatedObj.Helper_GetCharacterCommandRating(num2);
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_KEY_IPR)
                {
                  nr = this.game.EventRelatedObj.Helper_GetCharacterInterpersonalRating(num2);
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_KEY_FACTION)
                {
                  flag2 = true;
                  int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].GetData(0, num2, 13)));
                  str1 = idValue <= 0 ? "-" : this.game.Data.StringListObj[this.slotFactions].GetData(0, idValue, 10);
                }
                if (num6 == this.FIX_KEY_AGE)
                {
                  nr = this.game.Data.Round - (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 16]));
                  nr = (int) Math.Round(Math.Floor((double) nr / 6.0));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_STAT_STR)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 35]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_STAT_WAR)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 36]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_STAT_CHA)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 37]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_STAT_INT)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 38]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_STAT_WIL)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 39]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_PERS_EMOT)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 45]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_PERS_HERO)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 46]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_PERS_AMB)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 47]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_PERS_AUTH)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 48]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_PERS_EGO)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 49]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_PERS_COR)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 29]));
                  str1 = nr.ToString();
                }
                if (num6 == this.FIX_PERS_THEFT)
                {
                  nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCharacter].Data[index1, 28]));
                  string str3 = nr.ToString();
                  str1 = nr >= 1 ? str3 + " Cr" : "None";
                }
                if (num6 >= 200 & num6 < 400)
                {
                  str1 = "-";
                  int num8 = num1;
                  for (int idValue2 = 1; idValue2 <= num8; ++idValue2)
                  {
                    if (num6 == this.FIX_SKILL[idValue2])
                    {
                      int num9 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotSkills].GetData2(0, num2, 1, idValue2, 2)));
                      str1 = num9.ToString();
                      if (num9 < 1)
                        str1 = "-";
                    }
                  }
                }
                this.leaderStr.Data[length2, num5 + 1] = str1;
                this.leaderStr.TempDesc[length2, num5 + 1] = str2;
                this.leaderStr.ColValueType[num5 + 1] = !flag2 ? NewEnums.LibVarValueType.Number : NewEnums.LibVarValueType.Text;
              }
            }
          }
        }
      }
      int curSelection = this.curSelection;
      for (int col = 1; col <= curSelection; ++col)
      {
        int nr = this.game.EditObj.se1_leaderColumns.FindNr(this.tempColId[col]);
        if (nr > -1)
        {
          switch (this.game.EditObj.se1_leaderColumns.Weight[nr])
          {
            case 1:
              this.leaderStr.Sort(col);
              continue;
            case 2:
              this.leaderStr.Sort(col);
              this.leaderStr.Sort(col);
              continue;
            default:
              continue;
          }
        }
      }
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.SubPartList[index].DescriptInfo(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
            {
              this.game.EditObj.TipButton = true;
              this.game.EditObj.TipTitle = "";
              this.game.EditObj.TipText = this.SubPartList[index].Descript;
              return;
            }
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          break;
        }
      }
    }

    public void dostuff(bool crmAlreadySet = false)
    {
      SizeF sizeF1 = new SizeF();
      int id = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      int turn = this.game.Data.Turn;
      int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotCulture].GetData(0, (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotRegimes].GetData(0, id, 2))), 1)));
      this.game.Data.StringListObj[this.slotFlagInstructions].SetData(0, "REGIMEID", 1, id);
      this.game.Data.StringListObj[this.slotFlagInstructions].SetData(0, "ROUND", 1, this.game.Data.Round);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.useWidth, this.useHeight, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawRepeatingBackground(g, DrawMod.TGame.BACKGROUND3MARC, 0, 0, this.useWidth, this.useHeight);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      if (this.listId > 0)
      {
        this.RemoveSubPart(this.listId);
        this.listId = 0;
      }
      if (this.list2Id > 0)
      {
        this.RemoveSubPart(this.list2Id);
        this.list2Id = 0;
      }
      if (this.but0id > 0)
      {
        this.RemoveSubPart(this.but0id);
        this.but0id = 0;
      }
      if (this.but1id > 0)
      {
        this.RemoveSubPart(this.but1id);
        this.but1id = 0;
      }
      if (this.but2id > 0)
      {
        this.RemoveSubPart(this.but2id);
        this.but2id = 0;
      }
      if (this.but3id > 0)
      {
        this.RemoveSubPart(this.but3id);
        this.but3id = 0;
      }
      if (this.but4id > 0)
      {
        this.RemoveSubPart(this.but4id);
        this.but4id = 0;
      }
      int assetButtonCounter1 = this.assetButtonCounter;
      for (int index = 0; index <= assetButtonCounter1; ++index)
      {
        if (this.assetButton[index] > 0)
        {
          this.RemoveSubPart(this.assetButton[index]);
          this.assetButton[index] = 0;
          this.assetButtonData[index] = 0;
        }
      }
      this.assetButtonCounter = -1;
      int y1 = 80;
      Rectangle rectangle1 = new Rectangle(0, y1, 220, this.useHeight);
      int width1 = rectangle1.Width;
      int y2 = y1;
      int width2 = this.useWidth - width1;
      int height1 = 50;
      Rectangle rectangle2 = new Rectangle(width1, y2, width2, height1);
      Rectangle rectangle3 = new Rectangle(rectangle2.Left, rectangle2.Top + rectangle2.Height, rectangle2.Width, this.useHeight - (rectangle2.Height + 200 + y1));
      Rectangle rectangle4 = new Rectangle(rectangle3.X, rectangle3.Y + rectangle3.Height, rectangle3.Width, 200);
      DrawMod.DrawBlock(ref g, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, 0, 0, 0, 120);
      DrawMod.DrawBlock(ref g, rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height, 0, 0, 0, 160);
      DrawMod.DrawBlock(ref g, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, 0, 0, 0, 140);
      DrawMod.DrawBlock(ref g, rectangle4.X, rectangle4.Y, rectangle4.Width, rectangle4.Height, 0, 0, 0, 170);
      this.ListObj = new ListClass();
      int left1 = rectangle1.Left;
      int top1 = rectangle3.Top;
      int num2 = rectangle1.Width - 10;
      int tlistsize1 = (int) Math.Round(Math.Floor(210.0 / 24.0)) - 1;
      int tlistselect = -1;
      int num3 = -1;
      int tdata = 1;
      do
      {
        ++num3;
        string groupName = this.groupNames[tdata];
        if (this.game.EditObj.se1_leaderGroup == tdata)
          tlistselect = num3;
        this.ListObj.add(groupName, tdata);
        ++tdata;
      }
      while (tdata <= 8);
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(this.ListObj, tlistsize1, num2, tlistselect, this.game, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: left1, bby: top1, tMarcStyle: true, overruleFont: (ref this.game.MarcFont7), overruleItemSize: 24);
      this.listId = this.AddSubPart(ref tsubpart1, left1, top1, num2, (tlistsize1 + 1) * 24, 1);
      int num4 = top1 + 210;
      this.List2Obj = new ListClass();
      int tlistsize2 = (int) Math.Round(Math.Floor((double) (rectangle1.Height - (num4 + 50)) / 26.0)) - 1;
      int num5 = 1 - 1;
      this.List2Obj.add("None", -2);
      this.List2Obj.add("All", 0);
      int counter = this.ColList.Counter;
      for (int index = 0; index <= counter; ++index)
      {
        if (this.ColList.Data1[index] == this.game.EditObj.se1_leaderGroup)
        {
          ++num5;
          string colName = this.colNames[this.ColList.Id[index]];
          if (this.game.EditObj.se1_leaderColumns.FindNr(this.ColList.Id[index]) > -1)
            this.List2Obj.add(colName, this.ColList.Id[index], tbmp: BitmapStore.GetBitmap(this.game.SMALLCHAR2));
          else
            this.List2Obj.add(colName, this.ColList.Id[index], tbmp: BitmapStore.GetBitmap(this.game.SMALLCHAR1));
        }
      }
      SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(this.List2Obj, tlistsize2, num2, -1, this.game, tShowPair: true, tValueWidth: 70, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: left1, bby: num4, tMarcStyle: true, overruleFont: (ref this.game.MarcFont7), overruleItemSize: 26);
      this.list2Id = this.AddSubPart(ref tsubpart2, left1, num4, num2, (tlistsize2 + 1) * 26, 1);
      int x1 = rectangle2.Left + 10;
      int y3 = rectangle2.Top + 10;
      string str1 = "Leaders";
      DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont2, x1, y3, Color.White);
      SizeF sizeF2 = g.MeasureString(str1, this.game.MarcFont2);
      int x2 = (int) Math.Round((double) rectangle2.Left + (double) sizeF2.Width + 40.0);
      int num6 = 75;
      int y4 = rectangle2.Top + 3;
      SubPartClass tsubpart3 = (SubPartClass) new SEBigTextPartClass("Reset", "Change back to default selection of data columns", this.game.EditObj.se1_modelView == 0, num6, 44);
      this.but0id = this.AddSubPart(ref tsubpart3, x2, y4, num6, 44, 1);
      int num7 = x2 + 80;
      int left2 = rectangle3.Left;
      int top2 = rectangle3.Top;
      int height2 = 57;
      int width3 = rectangle3.Width;
      int num8 = (int) Math.Round(Math.Floor((double) (rectangle3.Height - 20) / (double) height2));
      int num9 = 1 + (int) Math.Round(Math.Floor((double) (this.leaderStr.Length + 1 - 1) / (double) num8));
      if (num9 < this.game.EditObj.se1_leaderPage)
        this.game.EditObj.se1_leaderPage = num9;
      if (this.game.EditObj.se1_leaderPage < 1)
        this.game.EditObj.se1_leaderPage = 1;
      int num10 = (this.game.EditObj.se1_leaderPage - 1) * num8 + 1;
      int num11 = (int) Math.Round(Math.Floor((double) (rectangle2.Width - 400) / (double) num9));
      if (num11 > 100)
        num11 = 100;
      int num12 = left2;
      int num13 = top2;
      int x3 = rectangle2.Right - (10 + (num11 + 4) * num9);
      int y5 = rectangle2.Top + 3;
      int num14 = num9;
      for (int index = 1; index <= num14; ++index)
      {
        ++this.assetButtonCounter;
        string tDescript = index.ToString() + "/" + num9.ToString() + ". Click to view this Leader page.";
        if (this.game.EditObj.se1_modelPage == index)
          tDescript = index.ToString() + "/" + num9.ToString() + ". Currently selected Leader page";
        int[] assetButton = this.assetButton;
        int assetButtonCounter2 = this.assetButtonCounter;
        tsubpart3 = (SubPartClass) new SEBigTextPartClass(index.ToString(), tDescript, this.game.EditObj.se1_leaderPage == index, num11, 44);
        int num15 = this.AddSubPart(ref tsubpart3, x3, y5, num11, 44, 1);
        assetButton[assetButtonCounter2] = num15;
        this.assetButtonData[this.assetButtonCounter] = 50 + index;
        x3 += num11 + 4;
      }
      int x1_1 = num12;
      int y1_1 = num13;
      DrawMod.DrawBlock(ref g, x1_1, y1_1, width3 - 10, 31, 168, 168, 168, 70);
      int num16 = y1_1 + 32;
      int num17 = 0;
      int num18 = 0;
      int num19 = 20;
      int num20 = 100;
      if (this.curSelection > 0)
        num20 = (int) Math.Round(Math.Floor((double) (rectangle3.Width - 420) / (double) this.curSelection));
      if (num20 > 150)
        num20 = 150;
      int length = this.leaderStr.Length;
      Rectangle trect;
      Rectangle rectangle5;
      for (int index1 = 0; index1 <= length; ++index1)
      {
        ++num18;
        int num21 = (int) Math.Round(Conversion.Val(this.leaderStr.Data[index1, 0]));
        if (num18 >= num10 & num18 <= num10 - 1 + num8)
        {
          ++num17;
          int left3 = rectangle3.Left;
          if (num21 != this.game.EditObj.se1_leaderSelected)
          {
            if (num17 % 2 == 0)
              DrawMod.DrawBlock(ref g, left3, num16, width3 - 10, height2 - 1, 148, 148, 148, 140);
            else
              DrawMod.DrawBlock(ref g, left3, num16, width3 - 10, height2 - 1, 128, 128, 128, 140);
          }
          else
            DrawMod.DrawBlock(ref g, left3, num16, width3 - 10, height2 - 1, 148, 218, 148, 140);
          int x4 = left3 + 10;
          Bitmap bitmap = (Bitmap) this.game.CustomBitmapObj.DrawLeaderPortrait(num21, 40, 56).Clone();
          if (num17 == 1)
            DrawMod.DrawTextColouredMarc(ref g, "PORTRAIT, NAME, JOB", this.game.MarcFont5, x4, num16 - 28, Color.White);
          ref Graphics local1 = ref g;
          ref Bitmap local2 = ref bitmap;
          trect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
          Rectangle srcrect = trect;
          rectangle5 = new Rectangle(x4, num16, 40, 56);
          Rectangle destrect = rectangle5;
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          bitmap.Dispose();
          bitmap = (Bitmap) null;
          rectangle5 = new Rectangle(x4, num16, 50, height2);
          trect = rectangle5;
          this.AddMouse(ref trect, "", "Click to get more information on this Leader", 20000000 + num21);
          int x5 = x4 + 50;
          string tstring = this.game.Data.StringListObj[this.slotCharacter].GetData(0, num21, 3) + " " + this.game.Data.StringListObj[this.slotCharacter].GetData(0, num21, 4);
          string characterJobTitle = this.game.EventRelatedObj.Helper_GetCharacterJobTitle(num21);
          DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont16, x5, num16 + num19 - 12, Color.White);
          DrawMod.DrawTextColouredMarc(ref g, characterJobTitle, this.game.MarcFont4, x5, num16 + num19 + 12, Color.LightGray);
          rectangle5 = new Rectangle(x5, num16, 300, height2);
          trect = rectangle5;
          this.AddMouse(ref trect, "", "Click to select this row", 1000000 + num21);
          int x6 = x5 + 300;
          int width4 = this.leaderStr.Width;
          for (int index2 = 1; index2 <= width4; ++index2)
          {
            if (index2 % 2 == 0)
              DrawMod.DrawBlock(ref g, x6 - 5, num16, num20, height2 - 1, 0, 0, 0, 40);
            if (this.leaderStr.ColSort[index2] == 2 & this.tempColId[index2] != 102 | this.leaderStr.ColSort[index2] == 1 & this.tempColId[index2] == 102)
              DrawMod.DrawBlock(ref g, x6 - 5, num16, num20, height2 - 1, 0, (int) byte.MaxValue, 0, 40);
            if (this.leaderStr.ColSort[index2] == 1 & this.tempColId[index2] != 102 | this.leaderStr.ColSort[index2] == 2 & this.tempColId[index2] == 102)
              DrawMod.DrawBlock(ref g, x6 - 5, num16, num20, height2 - 1, (int) byte.MaxValue, 0, 0, 40);
            if (num17 == 1)
            {
              string str2 = this.leaderStr.ColumnName[index2];
              int num22 = Strings.InStr(str2, " ");
              if (num22 > 0)
                str2 = Strings.Left(str2, num22 - 1) + "\r\n" + Strings.Mid(str2, num22 + 1);
              for (SizeF sizeF3 = g.MeasureString(str2, this.game.MarcFont5); (double) sizeF3.Width > (double) num20; sizeF3 = g.MeasureString(str2, this.game.MarcFont5))
                str2 = Strings.Left(str2, str2.Length - 1);
              DrawMod.DrawTextColouredMarc(ref g, str2, this.game.MarcFont5, x6, num16 - 28, Color.White);
              rectangle5 = new Rectangle(x6, num16 - 32, num20, 32);
              trect = rectangle5;
              this.AddMouse(ref trect, "", "Click to sort differently", 50000 + index2);
            }
            string str3 = this.leaderStr.Data[index1, index2];
            string ttext = this.leaderStr.TempDesc[index1, index2];
            for (SizeF sizeF4 = g.MeasureString(str3, this.game.MarcFont4); (double) sizeF4.Width > (double) num20; sizeF4 = g.MeasureString(str3, this.game.MarcFont4))
              str3 = Strings.Left(str3, str3.Length - 1);
            DrawMod.DrawTextColouredMarc(ref g, str3, this.game.MarcFont4, x6, num16 + num19, Color.White);
            if (ttext.Length > 1)
            {
              rectangle5 = new Rectangle(x6 - 5, num16, num20, height2 - 1);
              trect = rectangle5;
              this.AddMouse(ref trect, "", ttext);
            }
            else
            {
              rectangle5 = new Rectangle(x6 - 5, num16, num20, height2 - 1);
              trect = rectangle5;
              this.AddMouse(ref trect, "", "Click to select this row", 1000000 + num21);
            }
            x6 += num20;
          }
          rectangle5 = new Rectangle(x6, num16, rectangle3.Width - x6, height2);
          trect = rectangle5;
          this.AddMouse(ref trect, "", "Click to select this row", 1000000 + num21);
          num16 += height2;
        }
      }
      int x7 = rectangle4.X + 20;
      int y6 = rectangle4.Y + 10;
      int se1LeaderSelected = this.game.EditObj.se1_leaderSelected;
      if (se1LeaderSelected > 0)
      {
        Bitmap bitmap = this.game.CustomBitmapObj.DrawLeaderPortrait(se1LeaderSelected, 100, 140, true);
        ref Graphics local3 = ref g;
        ref Bitmap local4 = ref bitmap;
        rectangle5 = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        Rectangle srcrect = rectangle5;
        trect = new Rectangle(x7, y6, 100, 140);
        Rectangle destrect = trect;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
        bitmap.Dispose();
        bitmap = (Bitmap) null;
        rectangle5 = new Rectangle(x7, y6, 100, 140);
        trect = rectangle5;
        this.AddMouse(ref trect, "", "Click to get more information on this Leader", 20000000 + se1LeaderSelected);
        int num23 = x7 + 120;
        string tstring = this.game.Data.StringListObj[this.slotCharacter].GetData(0, se1LeaderSelected, 3) + " " + this.game.Data.StringListObj[this.slotCharacter].GetData(0, se1LeaderSelected, 4);
        string characterJobTitle = this.game.EventRelatedObj.Helper_GetCharacterJobTitle(se1LeaderSelected);
        DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont3, num23, y6, Color.White);
        DrawMod.DrawTextColouredMarc(ref g, characterJobTitle, this.game.MarcFont4, num23, y6 + 20, Color.LightGray);
        int num24 = y6 + 50;
        int num25 = 150;
        int num26 = 40;
        tsubpart3 = (SubPartClass) new TextButtonPartClass("Call", num25, "Give this Leader a Vidcom Call.", ref this.OwnBitmap, num23, num24, theight: num26, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.but1id = this.AddSubPart(ref tsubpart3, num23, num24, num25, num26, 1);
        int num27 = num24 + 50;
        tsubpart3 = (SubPartClass) new TextButtonPartClass("Stratagem", num25, "Play a Stratagem on this Leader.", ref this.OwnBitmap, num23, num27, theight: num26, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.but2id = this.AddSubPart(ref tsubpart3, num23, num27, num25, num26, 1);
      }
      g.Dispose();
      g = (Graphics) null;
    }

    public override WindowReturnClass HandleKeyup(int nr)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      int id = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      WindowReturnClass windowReturnClass2 = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index1 = 0; index1 <= mouseCounter; ++index1)
      {
        if (this.MouseData[index1] > 0 && x > this.MouseRect[index1].X & x < this.MouseRect[index1].X + this.MouseRect[index1].Width && y > this.MouseRect[index1].Y & y < this.MouseRect[index1].Y + this.MouseRect[index1].Height & b == 1)
        {
          if (this.MouseData[index1] > 50000 & this.MouseData[index1] < 60000)
          {
            int nr = this.game.EditObj.se1_leaderColumns.FindNr(this.tempColId[this.MouseData[index1] - 50000]);
            if (nr > -1)
            {
              int[] weight = this.game.EditObj.se1_leaderColumns.Weight;
              int[] numArray = weight;
              int index2 = nr;
              int index3 = index2;
              int num = weight[index2] + 1;
              numArray[index3] = num;
              if (this.game.EditObj.se1_leaderColumns.Weight[nr] > 2)
                this.game.EditObj.se1_leaderColumns.Weight[nr] = 0;
              int counter = this.game.EditObj.se1_leaderColumns.Counter;
              for (int index4 = 0; index4 <= counter; ++index4)
              {
                if (index4 != nr)
                  this.game.EditObj.se1_leaderColumns.Weight[index4] = 0;
              }
            }
            this.ReCalculate();
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 1000000 & this.MouseData[index1] < 2000000)
          {
            if (this.game.EditObj.se1_leaderSelected == this.MouseData[index1] - 1000000)
              this.game.EditObj.se1_leaderSelected = -1;
            else
              this.game.EditObj.se1_leaderSelected = this.MouseData[index1] - 1000000;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 20000000 & this.MouseData[index1] < 21000000)
          {
            if (this.game.EditObj.se1_leaderSelected != this.MouseData[index1] - 20000000)
              this.game.EditObj.se1_leaderSelected = this.MouseData[index1] - 20000000;
            this.game.EditObj.UDSpopupText = "";
            this.formref.Cursor = Cursors.WaitCursor;
            this.game.EditObj.UDSClearInput();
            this.game.EventRelatedObj.SetUDSKey("CHARID", this.game.EditObj.se1_leaderSelected);
            this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 531, 0, 0));
            this.formref.Cursor = Cursors.Default;
            this.game.EditObj.PopupValue = 21;
            windowReturnClass1.AddCommand(5, 14);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index5 = 0; index5 <= subPartCounter; ++index5)
        {
          if (x > this.SubPartX[index5] & x < this.SubPartX[index5] + this.SubPartW[index5] && y > this.SubPartY[index5] & y < this.SubPartY[index5] + this.SubPartH[index5])
          {
            int num1 = this.SubPartID[index5];
            if (num1 == this.but0id)
            {
              this.game.EditObj.se1_leaderColumns = new SimpleList();
              this.game.EditObj.se1_leaderColumns.Add(this.FIX_KEY_RELATION, 0);
              this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_ADVISOR, 0);
              this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_DIRECTOR, 0);
              this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_GOVERNOR, 0);
              this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_OHQ, 0);
              this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_RESERVE, 0);
              this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_SECRETARY, 0);
              this.game.EditObj.se1_leaderColumns.Add(this.FIX_JOB_SHQ, 0);
              this.ReCalculate();
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              windowReturnClass1.AddCommand(4, 67);
              return windowReturnClass1;
            }
            if (num1 == this.but1id)
            {
              this.game.EditObj.UDSpopupText = "";
              this.formref.Cursor = Cursors.WaitCursor;
              this.game.EditObj.UDSClearInput();
              this.game.EventRelatedObj.SetUDSKey("CHOICE", this.game.EditObj.se1_leaderSelected);
              this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 546, 0, 0));
              this.formref.Cursor = Cursors.Default;
              this.game.EditObj.PopupValue = 21;
              windowReturnClass1.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.but2id)
            {
              this.game.EditObj.se1_CardsCategory = 8;
              this.game.EditObj.se1_CardsTarget = this.game.EditObj.se1_leaderSelected;
              this.game.EditObj.se1_CardsCard = -1;
              this.game.EditObj.se1_CardsPage = 1;
              this.game.EditObj.SetViewMode2 = 5;
              this.game.EditObj.se1_ManagementMode = false;
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.OrderType = 0;
              if (this.game.ScreenHeight < 920)
              {
                this.game.EditObj.GuiDown = true;
                windowReturnClass1.AddCommand(3, 11);
              }
              else
                windowReturnClass1.AddCommand(3, 11);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.listId)
            {
              int num2 = this.SubPartList[index5].Click(x - this.SubPartX[index5], y - this.SubPartY[index5]);
              if (num2 > -1)
              {
                this.SubPartFlag[index5] = true;
                this.game.EditObj.se1_leaderGroup = num2;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
              this.SubPartFlag[index5] = true;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              windowReturnClass1.AddCommand(4, 67);
              return windowReturnClass1;
            }
            if (num1 == this.list2Id)
            {
              int tid = this.SubPartList[index5].Click(x - this.SubPartX[index5], y - this.SubPartY[index5]);
              if (tid > 0)
              {
                this.SubPartFlag[index5] = true;
                int nr = this.game.EditObj.se1_leaderColumns.FindNr(tid);
                if (nr > -1)
                  this.game.EditObj.se1_leaderColumns.RemoveNr(nr);
                else if (this.curSelection < this.maxSelection)
                {
                  ++this.curSelection;
                  this.game.EditObj.se1_leaderColumns.Add(tid, 0);
                }
                this.ReCalculate();
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
              switch (tid)
              {
                case -2:
                  this.SubPartFlag[index5] = true;
                  for (int counter = this.game.EditObj.se1_leaderColumns.Counter; counter >= 0; counter += -1)
                  {
                    if (this.ColList.FindData(this.game.EditObj.se1_leaderColumns.Id[counter], 1) == this.game.EditObj.se1_leaderGroup)
                      this.game.EditObj.se1_leaderColumns.RemoveNr(counter);
                  }
                  this.ReCalculate();
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass1.AddCommand(4, 67);
                  return windowReturnClass1;
                case 0:
                  this.SubPartFlag[index5] = true;
                  int counter1 = this.ColList.Counter;
                  for (int index6 = 0; index6 <= counter1; ++index6)
                  {
                    if (this.ColList.Data1[index6] == this.game.EditObj.se1_leaderGroup && this.game.EditObj.se1_leaderColumns.FindNr(this.ColList.Id[index6]) == -1 && this.curSelection < this.maxSelection)
                    {
                      ++this.curSelection;
                      this.game.EditObj.se1_leaderColumns.Add(this.ColList.Id[index6], 0);
                    }
                  }
                  this.ReCalculate();
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass1.AddCommand(4, 67);
                  return windowReturnClass1;
                default:
                  this.SubPartFlag[index5] = true;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass1.AddCommand(4, 67);
                  return windowReturnClass1;
              }
            }
            else
            {
              int assetButtonCounter = this.assetButtonCounter;
              for (int index7 = 0; index7 <= assetButtonCounter; ++index7)
              {
                if (this.assetButton[index7] == this.SubPartID[index5] && this.assetButtonData[index7] >= 51 & this.assetButtonData[index7] < 99)
                {
                  this.game.EditObj.se1_leaderPage = this.assetButtonData[index7] - 50;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
              }
            }
          }
        }
        windowReturnClass1.SetFlag(false);
        return windowReturnClass1;
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    public void PopUpRefresh() => this.dostuff();
  }
}
