// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SpecialWindowClass4
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
  public class SpecialWindowClass4 : WindowClass
  {
    private int okId;
    private int RightId;
    private int StartTurnId;
    private int PreviewId;
    private int RightId2;
    private int StartTurnId2;
    private int PreviewId2;
    private ListClass ListObj;
    private ListClass List2Obj;
    private int listId;
    private int list2Id;
    private int useWidth;
    private int useHeight;
    private SimpleList listShq;
    private SimpleList listZone;
    private SimpleList listAsset;
    private SimpleList listItemAsset;
    private bool anyZoneWithoutSHQ;
    private int prevAssetId;
    private SimpleList IL;
    private SimpleStringList ILdesc;
    private SimpleList PIL;
    private SimpleStringList PILdesc;
    private int[] assetButton;
    private int assetButtonCounter;
    private int[] assetButtonData;
    private int AssetOrderNumber;
    private string orderfeedbackString;
    private bool onPopupRefreshReCalc;
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
    private int[] itemWeight;
    private string[] itemName;
    private bool previewSet;

    public override void Dispose()
    {
      if (!this.game.EditObj.layerLisPreview & this.previewSet)
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            int index3 = 0;
            do
            {
              this.game.Data.MapObj[0].HexObj[index1, index2].tempPreviewLIS[index3] = 0;
              this.game.Data.MapObj[0].HexObj[index1, index2].tempPreviewAssetLIS[index3] = 0;
              ++index3;
            }
            while (index3 <= 8);
          }
        }
      }
      base.Dispose();
    }

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      return base.HandleMouseMove(x, y);
    }

    public SpecialWindowClass4(ref GameClass tGame, int tUseWidth, int tUseHeight)
      : base(ref tGame, tUseWidth, tUseHeight, 8)
    {
      this.ListObj = new ListClass();
      this.List2Obj = new ListClass();
      this.anyZoneWithoutSHQ = false;
      this.prevAssetId = -1;
      this.assetButton = new int[600];
      this.assetButtonCounter = -1;
      this.assetButtonData = new int[600];
      this.onPopupRefreshReCalc = false;
      this.itemWeight = new int[100];
      this.itemName = new string[100];
      this.previewSet = false;
      this.useWidth = tUseWidth;
      this.useHeight = tUseHeight;
      string libName = "SE_Data";
      this.slotPaid = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 500, 0, 0));
      this.slotHexNames = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 382, 0, 0));
      this.slotPerks = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 381, 0, 0));
      this.slotZones = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 123, 0, 0));
      this.slotZoneKeys = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 160, 0, 0));
      this.slotAssets = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 148, 0, 0));
      this.slotAssetLog = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 241, 0, 0));
      this.slotPreviewAssetLog = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 513, 0, 0));
      this.slotAssetTypes = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 144, 0, 0));
      this.slotItemType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 149, 0, 0));
      this.slotAssetPresentation = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 166, 0, 0));
      this.slotCharacter = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      this.slotPortrait = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 204, 0, 0));
      this.slotZones = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 123, 0, 0));
      this.slotZoneKeys = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 160, 0, 0));
      this.slotAssets = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 148, 0, 0));
      this.slotAssetTypes = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 144, 0, 0));
      this.slotItemType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 149, 0, 0));
      this.slotAssetPresentation = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 166, 0, 0));
      this.slotCharacter = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      this.slotPortrait = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 204, 0, 0));
      this.slotRegKey = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      this.slotDetail = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 361, 0, 0));
      this.slotLandscape = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 362, 0, 0));
      this.slotConstruction = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 150, 0, 0));
      int length = this.game.Data.StringListObj[this.slotItemType].Length;
      for (int index1 = 0; index1 <= length; ++index1)
      {
        int index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotItemType].Data[index1, 0]));
        int num = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotItemType].Data[index1, 3]));
        this.itemWeight[index2] = num;
        this.itemName[index2] = this.game.Data.StringListObj[this.slotItemType].Data[index1, 1];
      }
      if (!(this.game.EditObj.se1_assetSHQ > this.game.Data.UnitCounter | this.game.EditObj.se1_assetSHQ == -1))
      {
        if (this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].Regime == this.game.Data.Turn)
        {
          if (this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].Historical > -1)
          {
            if (this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].Historical].Type == 8)
              this.game.EditObj.se1_assetSHQ = -1;
          }
          else
            this.game.EditObj.se1_assetSHQ = -1;
        }
        else
          this.game.EditObj.se1_assetSHQ = -1;
      }
      if (!this.game.EditObj.layerLisPreview & this.game.EditObj.se1_assetMode == 2)
      {
        this.game.ProcessingObj.LIS_SetNetwork(false, true);
        this.previewSet = true;
      }
      this.ReCalculate();
      this.dostuff();
    }

    public void ReCalculate()
    {
      string libName = "SE_Data";
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 381, 0, 0));
      this.listShq = new SimpleList();
      this.listZone = new SimpleList();
      this.game.EventRelatedObj.ExecSuperImposeMessage("Calculating", "Hold on while we calculate the details on your Assets", 0, 0, "");
      int unitCounter = this.game.Data.UnitCounter;
      for (int tid = 0; tid <= unitCounter; ++tid)
      {
        if (this.game.Data.UnitObj[tid].Regime == this.game.Data.Turn && this.game.Data.UnitObj[tid].PreDef == -1 && this.game.Data.UnitObj[tid].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tid].Historical].Type == 8)
        {
          this.listShq.Add(tid, 0);
          if (this.game.EditObj.se1_assetSHQ == -1)
            this.game.EditObj.se1_assetSHQ = tid;
        }
      }
      bool flag = false;
      int length1 = this.game.Data.StringListObj[this.slotZones].Length;
      for (int index = 0; index <= length1; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].Data[index, 8])) == this.game.Data.RegimeObj[this.game.Data.Turn].id)
        {
          int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].Data[index, 0]));
          int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].Data[index, 6]));
          int num2 = -1;
          if (id > 0)
          {
            int locationById = this.game.HandyFunctionsObj.GetLocationByID(id);
            if (locationById > -1)
              num2 = this.game.Data.LocObj[locationById].HQ;
          }
          int tweight = ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZoneKeys].GetData2(0, num1, 1, "pop", 2))) + (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZoneKeys].GetData2(0, num1, 1, "worker", 2)))) * 100;
          this.listZone.Add(num1, tweight, num2);
          if (num2 > -1)
            this.listShq.AddWeight(num2, tweight);
          else
            flag = true;
        }
      }
      this.listShq.ReverseSort();
      this.listZone.ReverseSort();
      this.listAsset = new SimpleList();
      this.listItemAsset = new SimpleList();
      int length2 = this.game.Data.StringListObj[this.slotAssets].Length;
      for (int tid = 0; tid <= length2; ++tid)
      {
        int num = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[tid, 0]));
        if (this.listZone.FindNr(num) > -1)
          this.listAsset.Add(tid, num);
      }
      this.PIL = new SimpleList();
      this.PILdesc = new SimpleStringList();
      int stringListById2 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 166, 0, 0));
      SimpleList simpleList1 = new SimpleList();
      SimpleList simpleList2 = new SimpleList();
      int[] numArray1 = new int[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray1 = new SimpleList[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray2 = new SimpleList[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray3 = new SimpleList[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray4 = new SimpleList[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray5 = new SimpleList[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray6 = new SimpleList[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray7 = new SimpleList[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray8 = new SimpleList[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray9 = new SimpleList[this.listZone.Counter + 1 + 1];
      SimpleList[] simpleListArray10 = new SimpleList[this.listZone.Counter + 1 + 1];
      int num3 = 0;
      int[] numArray2 = new int[(int) Math.Round(Conversion.Val((object) this.game.Data.StringListObj[this.slotAssets].GetHighestValue(9))) + 29999 + 1];
      int length3 = this.game.Data.StringListObj[this.slotAssets].Length;
      for (int index1 = 0; index1 <= length3; ++index1)
      {
        int index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index1, 9]));
        numArray2[index2] = index1;
      }
      int x1;
      int y1;
      if (this.game.EditObj.se1_assetSHQ > 0)
      {
        x1 = this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].X;
        y1 = this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].Y;
        this.game.HandyFunctionsObj.MakeMovePredictionLIS_Preview(this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].X, this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].Y, this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].Map);
        int counter = this.listZone.Counter;
        for (int index3 = 0; index3 <= counter; ++index3)
        {
          if (this.listZone.Data1[index3] == this.game.EditObj.se1_assetSHQ)
          {
            int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, this.listZone.Id[index3], 6)));
            int index4 = -1;
            if (id > 0)
              index4 = this.game.HandyFunctionsObj.GetLocationByID(id);
            int num4 = 0;
            if (index4 > -1)
              num4 = this.game.ProcessingObj.LIS_GetLowestPointsOnTrajectory_PREVIEW(this.game.Data.LocObj[index4].X, this.game.Data.LocObj[index4].Y, this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].X, this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].Y, true);
            numArray1[index3] = num4;
            if (numArray1[index3] < 0)
              numArray1[index3] = 0;
          }
        }
      }
      int counter1 = this.listZone.Counter;
      int tweight1;
      for (int index5 = 0; index5 <= counter1; ++index5)
      {
        if (this.listZone.Data1[index5] == this.game.EditObj.se1_assetSHQ)
        {
          ++num3;
          simpleListArray1[index5] = new SimpleList();
          simpleListArray2[index5] = new SimpleList();
          simpleListArray3[index5] = new SimpleList();
          simpleListArray4[index5] = new SimpleList();
          simpleListArray5[index5] = new SimpleList();
          simpleListArray6[index5] = new SimpleList();
          simpleListArray7[index5] = new SimpleList();
          simpleListArray8[index5] = new SimpleList();
          simpleListArray9[index5] = new SimpleList();
          simpleListArray10[index5] = new SimpleList();
          int num5 = this.listZone.Id[index5];
          int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, num5, 6)));
          int index6 = -1;
          if (id > 0)
            index6 = this.game.HandyFunctionsObj.GetLocationByID(id);
          int x2;
          int y2;
          if (index6 > -1)
          {
            x2 = this.game.Data.LocObj[index6].X;
            y2 = this.game.Data.LocObj[index6].Y;
          }
          if (index6 > -1)
          {
            if (Information.IsNothing((object) this.game.Data.LocObj[index6].items))
              this.game.Data.LocObj[index6].items = new ItemList();
            int counter2 = this.game.Data.LocObj[index6].items.list.Counter;
            for (int index7 = 0; index7 <= counter2; ++index7)
            {
              int tid = this.game.Data.LocObj[index6].items.list.Id[index7];
              int tweight2 = this.game.Data.LocObj[index6].items.list.Weight[index7];
              simpleListArray1[index5].AddWeight(tid, tweight2);
              this.PIL.Add(tid, tweight2, tdata2: num5, tdata4: 1, CheckExistence: false);
            }
          }
          int counter3 = this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].items.list.Counter;
          for (int index8 = 0; index8 <= counter3; ++index8)
          {
            int index9 = this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].items.list.Id[index8];
            int tweight3 = this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].items.list.Weight[index8];
            if (num3 == 1)
              simpleList1.AddWeight(index9, tweight3);
            this.PIL.Add(index9, tweight3, 1, num5, tdata4: 1, CheckExistence: false);
            this.PILdesc.Add("The amount of " + this.itemName[index9] + " currently available at SHQ.", 1, 1, num5, index9, 1, CheckExistence: false);
          }
          EventRelatedClass eventRelatedObj = this.game.EventRelatedObj;
          int onlyZoneId = num5;
          SimpleList simpleList3 = (SimpleList) null;
          ref SimpleList local1 = ref simpleList3;
          SimpleList simpleList4 = (SimpleList) null;
          ref SimpleList local2 = ref simpleList4;
          int num6 = num3 == 1 ? 1 : 0;
          eventRelatedObj.ExecMakeAssetPresentation("SE_Data", -1, -1, onlyZoneId, "", itemsProdModList: (ref local1), itemsUpkeepModList: (ref local2), logNeed: true, clearLogs: (num6 != 0));
          int length4 = this.game.Data.StringListObj[stringListById2].Length;
          for (int index10 = 0; index10 <= length4; ++index10)
          {
            int tid = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index10, 0]));
            if (tid > 0)
            {
              int num7 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index10, 2]));
              int tweight4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index10, 3]));
              tweight1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index10, 4]));
              int tweight5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index10, 8]));
              if (tweight4 > 0)
              {
                simpleListArray2[index5].AddWeight(tid, tweight4);
                if (tweight5 > 0)
                  simpleListArray6[index5].AddWeight(tid, tweight5);
              }
              if (tweight1 > 0)
                simpleListArray3[index5].AddWeight(tid, tweight1);
            }
          }
          simpleListArray4[index5] = simpleListArray2[index5].Clone();
          simpleListArray4[index5].RemoveWeight(ref simpleListArray1[index5]);
          simpleListArray4[index5].removeWeight0orLower();
          simpleListArray5[index5] = simpleListArray4[index5].Clone();
          int num8 = 0;
          int counter4 = simpleListArray4[index5].Counter;
          for (int index11 = 0; index11 <= counter4; ++index11)
          {
            int num9 = this.itemWeight[simpleListArray4[index5].Id[index11]] * simpleListArray4[index5].Weight[index11];
            if (x1 == x2 & y1 == y2)
              num9 = 0;
            num8 += num9;
          }
          if (num8 > numArray1[index5])
          {
            int counter5 = simpleListArray4[index5].Counter;
            for (int index12 = 0; index12 <= counter5; ++index12)
            {
              if (this.itemWeight[simpleListArray4[index5].Id[index12]] > 0 | numArray1[index5] == 0 && !(x1 == x2 & y1 == y2))
              {
                int num10 = (int) Math.Round(Math.Floor((double) (simpleListArray4[index5].Weight[index12] * numArray1[index5]) / (double) num8));
                simpleListArray4[index5].Weight[index12] = num10;
              }
            }
          }
          simpleList2.AddWeight(ref simpleListArray4[index5]);
        }
      }
      SimpleList simpleList5 = new SimpleList();
      int counter6 = simpleList2.Counter;
      for (int index = 0; index <= counter6; ++index)
      {
        int tid = simpleList2.Id[index];
        int num11 = simpleList2.Weight[index];
        int weight = this.game.Data.UnitObj[this.game.EditObj.se1_assetSHQ].items.list.FindWeight(tid);
        int tweight6 = !(weight >= num11 & num11 > 0) ? (num11 <= 0 ? 0 : (int) Math.Round(Math.Floor((double) (100 * weight) / (double) num11))) : 100;
        simpleList5.AddWeight(tid, tweight6);
      }
      int tid1 = 1;
      do
      {
        if (simpleList5.FindNr(tid1) == -1)
          simpleList5.AddWeight(tid1, 100);
        ++tid1;
      }
      while (tid1 <= 30);
      int counter7 = this.listZone.Counter;
      string str1;
      string str2;
      string str3;
      int num12;
      int num13;
      for (int index13 = 0; index13 <= counter7; ++index13)
      {
        if (this.listZone.Data1[index13] == this.game.EditObj.se1_assetSHQ)
        {
          int num14 = this.listZone.Id[index13];
          int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, num14, 6)));
          int index14 = -1;
          if (id > 0)
            index14 = this.game.HandyFunctionsObj.GetLocationByID(id);
          int x3;
          int y3;
          if (index14 > -1)
          {
            x3 = this.game.Data.LocObj[index14].X;
            y3 = this.game.Data.LocObj[index14].Y;
          }
          if (index14 > -1)
          {
            SimpleList simpleList6 = new SimpleList();
            SimpleList simpleList7 = new SimpleList();
            int index15 = 1;
            do
            {
              int tweight7 = 0;
              int tweight8 = 0;
              int weight1 = simpleListArray2[index13].FindWeight(index15);
              int tweight9 = 0;
              if (weight1 > 0)
              {
                int weight2 = simpleListArray6[index13].FindWeight(index15);
                int weight3 = simpleListArray4[index13].FindWeight(index15);
                int weight4 = simpleListArray5[index13].FindWeight(index15);
                int weight5 = simpleList5.FindWeight(index15);
                int num15 = weight1 - weight4;
                if (num15 < 0)
                  num15 = 0;
                int tweight10 = (int) Math.Round(Math.Floor((double) (weight3 * weight5) / 100.0));
                tweight9 = tweight10;
                int num16 = num15 + tweight10;
                if (num16 >= weight1)
                {
                  tweight7 = 100;
                  tweight8 = 100;
                }
                else if (num16 > weight2 & num16 > 0)
                {
                  tweight7 = (int) Math.Round(Math.Floor((double) (100 * (num16 - weight2)) / (double) weight1));
                  tweight8 = 100;
                }
                else if (weight1 > 0)
                {
                  tweight7 = 0;
                  tweight8 = (int) Math.Round(Math.Floor((double) (100 * num16) / (double) weight2));
                }
                this.PIL.Add(index15, tweight10, 2, num14, weight4, 1, CheckExistence: false);
                if (weight4 > 0)
                {
                  string str4 = "" + weight4.ToString() + " of " + this.itemName[index15] + " is missing in Zone.\r\n";
                  string str5;
                  if (weight3 < weight4)
                    str5 = str4 + "Only " + weight3.ToString() + " of " + this.itemName[index15] + " is requested at SHQ due to probable lack of Logistical Points.\r\n";
                  else
                    str5 = str4 + weight3.ToString() + " of " + this.itemName[index15] + " is requested at SHQ.\r\n";
                  string tid2;
                  if (tweight10 < weight3)
                    tid2 = str5 + "Only " + tweight10.ToString() + " " + this.itemName[index15] + " will be delivered Zone due to probable lack of SHQ inventory.";
                  else
                    tid2 = str5 + tweight10.ToString() + " " + this.itemName[index15] + " will be delivered to Zone.";
                  this.PILdesc.Add(tid2, 1, 2, num14, index15, 1, CheckExistence: false);
                }
              }
              else
              {
                tweight7 = 100;
                tweight8 = 100;
              }
              simpleList1.RemoveWeight(index15, tweight9);
              int tweight11 = simpleListArray1[index13].FindWeight(index15) + tweight9;
              simpleListArray1[index13].AddWeight(index15, tweight9);
              this.PIL.Add(index15, tweight11, 3, num14, tdata4: 1, CheckExistence: false);
              if (tweight11 > 0)
                this.PILdesc.Add("After any deliveries from SHQ the Zone will have " + tweight11.ToString() + " " + this.itemName[index15] + " in reserve.", 1, 3, num14, index15, 1, CheckExistence: false);
              simpleList6.Add(index15, tweight7);
              simpleList7.Add(index15, tweight8);
              ++index15;
            }
            while (index15 <= 30);
            this.game.EventRelatedObj.ExecMakeAssetPresentation("SE_Data", -1, -1, num14, "", prodAdjustmentLists: true, itemsProdModList: (ref simpleList6), itemsUpkeepModList: (ref simpleList7), logActual: true);
            int length5 = this.game.Data.StringListObj[stringListById2].Length;
            for (int index16 = 0; index16 <= length5; ++index16)
            {
              int index17 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index16, 0]));
              if (index17 > 0)
              {
                int num17 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index16, 2]));
                int tweight12 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index16, 3]));
                int tweight13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index16, 4]));
                int num18 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index16, 8]));
                int num19;
                if (tweight12 > 0)
                {
                  simpleListArray7[index13].AddWeight(index17, tweight12);
                  int weight6 = simpleListArray2[index13].FindWeight(index17);
                  if (tweight12 > 0 | weight6 > 0)
                  {
                    this.slotDetail = this.slotPreviewAssetLog;
                    str1 = "";
                    str2 = "";
                    string Left1 = "";
                    string Left2 = "";
                    str3 = this.itemName[index17] + " consumed in Zone";
                    string str6 = weight6.ToString() + " could optimally be consumed.\r\n" + tweight12.ToString() + " was actually available and consumed by Zone.";
                    if (weight6 > 0)
                    {
                      Left1 = "Assets that consumed:\r\n";
                      num19 = 0;
                      num12 = 0;
                      if (this.slotDetail > -1)
                      {
                        int length6 = this.game.Data.StringListObj[this.slotDetail].Length;
                        for (int index18 = 0; index18 <= length6; ++index18)
                        {
                          int tid3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 0]));
                          if (tid3 < 1000000)
                            tweight1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[tid3], 0]));
                          int num20 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 1]));
                          int num21 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 3]));
                          if (tid3 < 1000000)
                          {
                            if (tweight1 == num14 & num20 == 2 & num21 == index17)
                            {
                              int num22 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 2]));
                              num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 4]));
                              int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[tid3], 1]));
                              string str7 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
                              int nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
                              int num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[tid3], 11]));
                              if (num22 == 2 | num22 == 4 | num22 == 6)
                              {
                                this.listItemAsset.Add(tid3, 1, 4, index17, CheckExistence: false);
                                if (nr > 0)
                                  str7 = str7 + " " + this.game.HandyFunctionsObj.GetRomanNumerical(nr);
                                Left1 = Left1 + num23.ToString() + "% prod, " + str7 + " consumed " + num13.ToString() + " " + this.itemName[index17] + "\r\n";
                              }
                            }
                          }
                          else if (tid3 >= 1000000)
                          {
                            int tid4 = tid3;
                            tweight1 = num14;
                            int num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 1]));
                            int num25 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 3]));
                            if (tweight1 == num14 & num24 == 2 & num25 == index17)
                            {
                              string data = this.game.Data.StringListObj[stringListById1].GetData(0, tid4 - 1000000, 1);
                              int num26 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 2]));
                              num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 4]));
                              int num27 = this.game.Data.StringListObj[this.slotDetail].Width < 5 ? num14 : (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index18, 5]));
                              if (num26 == 14 & num27 == num14)
                              {
                                this.listItemAsset.Add(tid4, 1, 4, index17, CheckExistence: false);
                                if (Operators.CompareString(Left2, "", false) == 0)
                                  Left2 = "Hex Perks that contributed:\r\n";
                                if (index17 == 9 | index17 == 12)
                                  num13 *= 100;
                                Left2 = Left2 + data + " produced " + num13.ToString() + " " + this.itemName[index17] + "\r\n";
                              }
                            }
                          }
                        }
                      }
                    }
                    if (Left2.Length > 0)
                      Left1 += Left2;
                    if (Operators.CompareString(Left1, "", false) == 0)
                      Left1 = "No assets contributed to this consumption";
                    this.PILdesc.Add(str6 + "\r\n" + Left1, 1, 4, num14, index17, 1, CheckExistence: false);
                  }
                  int nr1 = this.PIL.FindNr(index17, 4, num14, tdata4: 1);
                  if (nr1 == -1)
                  {
                    this.PIL.Add(index17, tweight12, 4, num14, weight6, 1, CheckExistence: false);
                  }
                  else
                  {
                    int[] weight7 = this.PIL.Weight;
                    int[] numArray3 = weight7;
                    int index19 = nr1;
                    int index20 = index19;
                    int num28 = weight7[index19] + tweight12;
                    numArray3[index20] = num28;
                  }
                }
                if (tweight13 > 0)
                {
                  simpleListArray8[index13].AddWeight(index17, tweight13);
                  int weight8 = simpleListArray3[index13].FindWeight(index17);
                  string Left3 = "";
                  if ((weight8 > 0 | tweight13 > 0) & this.slotPreviewAssetLog > -1)
                  {
                    this.slotDetail = this.slotPreviewAssetLog;
                    str1 = "";
                    str2 = "";
                    string Left4 = "";
                    str3 = this.itemName[index17] + " produced in Zone";
                    string str8 = weight8.ToString() + " could optimally be produced.\r\n" + tweight13.ToString() + " was actually produced by Zone.";
                    if (weight8 > 0)
                    {
                      num19 = 0;
                      num12 = 0;
                      if (this.slotDetail > -1)
                      {
                        int length7 = this.game.Data.StringListObj[this.slotDetail].Length;
                        for (int index21 = 0; index21 <= length7; ++index21)
                        {
                          int tid5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 0]));
                          if (tid5 < 1000000)
                          {
                            tweight1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[tid5], 0]));
                            int num29 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 1]));
                            int num30 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 3]));
                            if (tweight1 == num14 & num29 == 2 & num30 == index17)
                            {
                              int num31 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 2]));
                              num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 4]));
                              int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[tid5], 1]));
                              string str9 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
                              int nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
                              int num32 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[tid5], 11]));
                              if (num31 == 14)
                              {
                                this.listItemAsset.Add(tid5, 1, 5, index17, CheckExistence: false);
                                if (Operators.CompareString(Left4, "", false) == 0)
                                  Left4 = "Assets that contributed:\r\n";
                                if (nr > 0)
                                  str9 = str9 + " " + this.game.HandyFunctionsObj.GetRomanNumerical(nr);
                                Left4 = Left4 + num32.ToString() + "% prod, " + str9 + " produced " + num13.ToString() + " " + this.itemName[index17] + "\r\n";
                              }
                            }
                          }
                          else if (tid5 >= 1000000)
                          {
                            tweight1 = num14;
                            int num33 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 1]));
                            int num34 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 3]));
                            if (tweight1 == num14 & num33 == 2 & num34 == index17)
                            {
                              string data = this.game.Data.StringListObj[stringListById1].GetData(0, tid5 - 1000000, 1);
                              int num35 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 2]));
                              num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 4]));
                              int num36 = this.game.Data.StringListObj[this.slotDetail].Width < 5 ? num14 : (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index21, 5]));
                              if (num35 == 14 & num36 == num14)
                              {
                                this.listItemAsset.Add(tid5, 1, 5, index17, CheckExistence: false);
                                if (Operators.CompareString(Left3, "", false) == 0)
                                  Left3 = "Hex Perks that contributed:\r\n";
                                if (index17 == 9 | index17 == 12)
                                  num13 *= 100;
                                Left3 = Left3 + data + " produced " + num13.ToString() + " " + this.itemName[index17] + "\r\n";
                              }
                            }
                          }
                        }
                      }
                    }
                    if (Left3.Length > 0)
                      Left4 += Left3;
                    if (Operators.CompareString(Left4, "", false) == 0)
                      Left4 = "No assets contributed to this production";
                    this.PILdesc.Add(str8 + "\r\n" + Left4, 1, 5, num14, index17, 1, CheckExistence: false);
                  }
                  int num37 = this.PIL.FindNr(index17, 5, num14, tdata4: 1);
                  if (index17 == 13)
                    num37 = num37;
                  if (num37 == -1)
                  {
                    this.PIL.Add(index17, tweight13, 5, num14, weight8, 1, CheckExistence: false);
                  }
                  else
                  {
                    int[] weight9 = this.PIL.Weight;
                    int[] numArray4 = weight9;
                    int index22 = num37;
                    int index23 = index22;
                    int num38 = weight9[index22] + tweight13;
                    numArray4[index23] = num38;
                  }
                }
              }
            }
            int index24 = 0;
            do
            {
              int tweight14 = simpleListArray1[index13].FindWeight(index24) + simpleListArray8[index13].FindWeight(index24) - simpleListArray7[index13].FindWeight(index24);
              if (tweight14 < 0)
                tweight14 = 0;
              if (tweight14 > 0)
              {
                this.PIL.Add(index24, tweight14, 6, num14, tdata4: 1, CheckExistence: false);
                this.PILdesc.Add("After consumption and production of Items the Zone will have " + tweight14.ToString() + " " + this.itemName[index24] + " in reserve.", 1, 6, num14, index24, 1, CheckExistence: false);
              }
              ++index24;
            }
            while (index24 <= 30);
            simpleListArray1[index13].AddWeight(ref simpleListArray8[index13]);
            simpleListArray1[index13].RemoveWeight(ref simpleListArray7[index13]);
            simpleListArray1[index13].removeWeight0orLower();
            if (index14 > -1)
            {
              SimpleList simpleList8 = this.game.Data.LocObj[index14].items.list.Clone();
              this.game.Data.LocObj[index14].items.list = simpleListArray1[index13].Clone();
              this.game.EventRelatedObj.ExecMakeListForLocationReturns("SE_Data", num14, 0, 0, "");
              this.game.Data.LocObj[index14].items.list = simpleList8;
              simpleListArray9[index13].AddWeight(ref this.game.Data.LocObj[index14].tempRequestItems);
              simpleListArray10[index13] = simpleListArray9[index13].Clone();
              int num39 = 0;
              int counter8 = simpleListArray9[index13].Counter;
              for (int index25 = 0; index25 <= counter8; ++index25)
              {
                int num40 = this.itemWeight[simpleListArray9[index13].Id[index25]] * simpleListArray9[index13].Weight[index25];
                if (x1 == x3 & y1 == y3)
                  num40 = 0;
                num39 += num40;
              }
              if (num39 > numArray1[index13] | numArray1[index13] == 0)
              {
                int counter9 = simpleListArray9[index13].Counter;
                for (int index26 = 0; index26 <= counter9; ++index26)
                {
                  if (this.itemWeight[simpleListArray9[index13].Id[index26]] > 0 | numArray1[index13] == 0 && !(x1 == x3 & y1 == y3))
                  {
                    int num41 = (int) Math.Round(Math.Floor((double) (simpleListArray9[index13].Weight[index26] * numArray1[index13]) / (double) num39));
                    simpleListArray9[index13].Weight[index26] = num41;
                  }
                }
              }
              int counter10 = simpleListArray9[index13].Counter;
              for (int index27 = 0; index27 <= counter10; ++index27)
              {
                int index28 = simpleListArray9[index13].Id[index27];
                int tweight15 = simpleListArray9[index13].Weight[index27];
                int weight = simpleListArray10[index13].FindWeight(index28);
                this.PIL.Add(index28, tweight15, 7, num14, weight, 1, CheckExistence: false);
                if (weight > 0)
                {
                  string str10 = "Ideally the Zone would like to send a local surplus of " + weight.ToString() + " " + this.itemName[index28] + " to its SHQ.";
                  string tid6;
                  if (tweight15 >= weight)
                    tid6 = str10 + "\r\nThis is what will probably happen.";
                  else
                    tid6 = str10 + "\r\nDue to probable logistical problems only " + tweight15.ToString() + " " + this.itemName[index28] + " will be sent to its SHQ.";
                  this.PILdesc.Add(tid6, 1, 7, num14, index28, 1, CheckExistence: false);
                }
                simpleList1.AddWeight(index28, tweight15);
              }
            }
          }
        }
      }
      simpleList1.removeWeight0orLower();
      int counter11 = this.listZone.Counter;
      for (int index29 = 0; index29 <= counter11; ++index29)
      {
        if (this.listZone.Data1[index29] == this.game.EditObj.se1_assetSHQ)
        {
          int tdata2 = this.listZone.Id[index29];
          int counter12 = simpleList1.Counter;
          for (int index30 = 0; index30 <= counter12; ++index30)
            this.PIL.Add(simpleList1.Id[index30], simpleList1.Weight[index30], 8, tdata2, tdata4: 1, CheckExistence: false);
        }
      }
      this.IL = new SimpleList();
      this.ILdesc = new SimpleStringList();
      int counter13 = this.listZone.Counter;
      for (int index31 = 0; index31 <= counter13; ++index31)
      {
        int num42 = this.listZone.Id[index31];
        Conversions.ToInteger(this.game.Data.StringListObj[this.slotZones].GetData(0, num42, 1));
        Conversions.ToInteger(this.game.Data.StringListObj[this.slotZones].GetData(0, num42, 2));
        int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, num42, 6)));
        this.game.Data.StringListObj[this.slotZones].GetData(0, num42, 7);
        int index32 = this.game.EventRelatedObj.CheckRegimeSlot((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, num42, 8))), 0, 0, 0);
        int locationById;
        if (id > 0)
          locationById = this.game.HandyFunctionsObj.GetLocationByID(id);
        int num43 = -1;
        if (locationById > -1)
          num43 = this.game.Data.LocObj[locationById].HQ;
        int num44 = -1;
        if (num42 > 0 & index32 > -1)
          num44 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[index32].id, 10, num42, 0);
        if (locationById > -1)
        {
          SimpleList simpleList9 = new SimpleList();
          SimpleList simpleList10 = new SimpleList();
          SimpleStringList simpleStringList = new SimpleStringList();
          int tdata1_1 = 0;
          int tdata2_1 = 0;
          simpleList9.Add(7, 0, tdata1_1, tdata2_1);
          simpleList10.Add(19, 0, CheckExistence: false);
          simpleStringList.Add("Food", 1);
          int tdata2_2 = tdata2_1 + 1;
          simpleList9.Add(5, 0, tdata1_1, tdata2_2);
          simpleList10.Add(20, 0, CheckExistence: false);
          simpleStringList.Add("Water", 1);
          int tdata2_3 = tdata2_2 + 1;
          simpleList9.Add(1, 0, tdata1_1, tdata2_3);
          simpleList10.Add(18, 0, CheckExistence: false);
          simpleStringList.Add("Fuel", 1);
          int tdata2_4 = tdata2_3 + 1;
          simpleList9.Add(10, 0, tdata1_1, tdata2_4);
          simpleList10.Add(17, 0, CheckExistence: false);
          simpleStringList.Add("Ammo", 1);
          int tdata2_5 = tdata2_4 + 1;
          simpleList9.Add(15, 0, tdata1_1, tdata2_5);
          simpleList10.Add(16, 0, CheckExistence: false);
          simpleStringList.Add("Energy", 1);
          int tdata1_2 = tdata1_1 + 1;
          int tdata2_6 = 0;
          simpleList9.Add(2, 0, tdata1_2, tdata2_6);
          simpleList10.Add(2, 0, CheckExistence: false);
          simpleStringList.Add("Metals", 1);
          int tdata2_7 = tdata2_6 + 1;
          simpleList9.Add(3, 0, tdata1_2, tdata2_7);
          simpleList10.Add(3, 0, CheckExistence: false);
          simpleStringList.Add("Rare Metals", 1);
          int tdata2_8 = tdata2_7 + 1;
          simpleList9.Add(13, 0, tdata1_2, tdata2_8);
          simpleList10.Add(13, 0, CheckExistence: false);
          simpleStringList.Add("Machines", 1);
          int tdata2_9 = tdata2_8 + 1;
          simpleList9.Add(14, 0, tdata1_2, tdata2_9);
          simpleList10.Add(14, 0, CheckExistence: false);
          simpleStringList.Add("Hi-Tech Parts", 1);
          int tdata2_10 = tdata2_9 + 1;
          simpleList9.Add(8, 0, tdata1_2, tdata2_10);
          simpleList10.Add(22, 0, CheckExistence: false);
          simpleStringList.Add("Industrial Points", 1);
          int tdata1_3 = tdata1_2 + 1;
          int tdata2_11 = 0;
          simpleList9.Add(9, 0, tdata1_3, tdata2_11);
          simpleList10.Add(9, 0, CheckExistence: false);
          simpleStringList.Add("Recruits", 1);
          int tdata2_12 = tdata2_11 + 1;
          simpleList9.Add(12, 0, tdata1_3, tdata2_12);
          simpleList10.Add(12, 0, CheckExistence: false);
          simpleStringList.Add("Colonists", 1);
          int tdata2_13 = tdata2_12 + 1;
          simpleList9.Add(4, 0, tdata1_3, tdata2_13);
          simpleList10.Add(4, 0, CheckExistence: false);
          simpleStringList.Add("Radioactives", 1);
          int counter14 = simpleList9.Counter;
          for (int index33 = 0; index33 <= counter14; ++index33)
          {
            string str11 = simpleStringList.Id[index33];
            int num45 = simpleList9.Id[index33];
            int num46 = simpleList10.Id[index33];
            if (num45 == num46)
              ;
            int tweight16 = 0;
            int num47 = 0;
            int num48 = 0;
            int num49 = 0;
            int num50 = 0;
            int tdata3_1 = 0;
            int num51 = 0;
            int tdata3_2 = 0;
            int tdata3_3 = 0;
            int num52 = 0;
            int num53 = 0;
            int num54 = 0;
            int num55 = 0;
            int num56 = 0;
            int logCounter = this.game.Data.LocObj[locationById].LogCounter;
            for (int index34 = 0; index34 <= logCounter; ++index34)
            {
              if (this.game.Data.LocObj[locationById].LogData1[index34] == num45)
              {
                if (this.game.Data.LocObj[locationById].LogType[index34] == 101)
                  tweight16 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 104)
                  num47 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 103)
                  num49 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 102)
                  num50 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 121)
                  num48 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 201)
                  tdata3_1 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 204)
                  num51 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 203)
                  tdata3_2 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 202)
                  tdata3_3 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 401)
                  num53 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 402)
                {
                  num52 += this.game.Data.LocObj[locationById].LogData3[index34];
                  num49 += this.game.Data.LocObj[locationById].LogData3[index34];
                }
                if (this.game.Data.LocObj[locationById].LogType[index34] == 403)
                  num54 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 404)
                  num55 += this.game.Data.LocObj[locationById].LogData3[index34];
                if (this.game.Data.LocObj[locationById].LogType[index34] == 405)
                  num56 += this.game.Data.LocObj[locationById].LogData3[index34];
              }
            }
            if (num45 == 9 | num45 == 12)
            {
              tweight16 *= 100;
              num47 *= 100;
              num48 *= 100;
              num49 *= 100;
              num50 *= 100;
              tdata3_1 *= 100;
              num51 *= 100;
              tdata3_2 *= 100;
              tdata3_3 *= 100;
              num54 *= 100;
              num56 *= 100;
            }
            int tweight17;
            double num57;
            int eventPicSlotFor;
            if (tweight16 > 0 | tdata3_1 > 0)
            {
              tweight17 = tweight16;
              string tid7 = tweight17.ToString();
              if (tweight17 > 999)
              {
                num57 = Math.Round((double) tweight17 / 1000.0, 1);
                tid7 = num57.ToString() + "k";
              }
              eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(num45, "", "");
              str3 = simpleStringList.Id[index33] + " sent from SHQ to Zone";
              str1 = tdata3_1.ToString() + " requested by Zone.\r\n" + tweight16.ToString() + " sent by SHQ.";
              if (tweight16 > 0)
                tid7 = "+" + tid7;
              this.IL.Add(num45, tweight16, 2, num42, tdata3_1, CheckExistence: false);
              this.ILdesc.Add(tid7, 1, 2, num42, num45, CheckExistence: false);
            }
            string Left5 = "";
            if (num47 > 0 | num51 > 0 | num48 > 0)
            {
              tweight17 = num47 + num48;
              string str12 = tweight17.ToString();
              if (tweight17 > 999)
              {
                num57 = Math.Round((double) tweight17 / 1000.0, 1);
                str12 = num57.ToString() + "k";
              }
              if (num47 > 0)
                str12 = "+" + str12;
              eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(num45, "", "");
              str3 = simpleStringList.Id[index33] + " produced in Zone";
              string str13 = num51.ToString() + " could optimally be produced.\r\n" + num47.ToString() + " was actually produced by Zone.";
              if (num48 > 0)
                str13 = str13 + "\r\n" + num48.ToString() + " was delivered by Zone Militia.";
              str2 = str12;
              string Left6 = "";
              if (num51 > 0)
              {
                tweight17 = 0;
                num12 = 0;
                if (this.slotDetail > -1)
                {
                  int length8 = this.game.Data.StringListObj[this.slotDetail].Length;
                  for (int index35 = 0; index35 <= length8; ++index35)
                  {
                    int index36 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 0]));
                    if (index36 < 1000000)
                    {
                      int num58 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[index36], 0]));
                      int num59 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 1]));
                      int num60 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 3]));
                      if (num58 == num42 & num59 == 2 & num60 == num45)
                      {
                        int num61 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 2]));
                        num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 4]));
                        int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[index36], 1]));
                        string str14 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
                        int nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
                        int num62 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[index36], 11]));
                        if (num61 == 14)
                        {
                          if (Operators.CompareString(Left6, "", false) == 0)
                            Left6 = "Assets that contributed:\r\n";
                          if (nr > 0)
                            str14 = str14 + " " + this.game.HandyFunctionsObj.GetRomanNumerical(nr);
                          Left6 = Left6 + num62.ToString() + "% prod, " + str14 + " produced " + num13.ToString() + " " + this.game.Data.StringListObj[this.slotItemType].GetData(0, num45, 1) + "\r\n";
                        }
                      }
                    }
                    else if (index36 >= 1000000)
                    {
                      int num63 = num42;
                      int num64 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 1]));
                      int num65 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 3]));
                      if (num63 == num42 & num64 == 2 & num65 == num45)
                      {
                        string data = this.game.Data.StringListObj[stringListById1].GetData(0, index36 - 1000000, 1);
                        int num66 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 2]));
                        num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 4]));
                        int num67 = this.game.Data.StringListObj[this.slotDetail].Width < 5 ? num42 : (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index35, 5]));
                        if (num66 == 14 & num67 == num42)
                        {
                          if (Operators.CompareString(Left5, "", false) == 0)
                            Left5 = "Hex Perks that contributed:\r\n";
                          if (num45 == 9 | num45 == 12)
                            num13 *= 100;
                          Left5 = Left5 + data + " produced " + num13.ToString() + " " + this.game.Data.StringListObj[this.slotItemType].GetData(0, num45, 1) + "\r\n";
                        }
                      }
                    }
                  }
                }
              }
              if (Left5.Length > 0)
                Left6 += Left5;
              if (num54 > 0)
                Left6 = Left6 + "Recruitment in zone contributed " + num54.ToString() + " " + this.game.Data.StringListObj[this.slotItemType].GetData(0, num45, 1) + "\r\n";
              if (num55 > 0)
                Left6 = Left6 + "Service Tax contributed " + num55.ToString() + " " + this.game.Data.StringListObj[this.slotItemType].GetData(0, num45, 1) + "\r\n";
              if (num56 > 0)
                Left6 = Left6 + "Free Production/Collection contributed " + num56.ToString() + " " + this.game.Data.StringListObj[this.slotItemType].GetData(0, num45, 1) + "\r\n";
              if (Operators.CompareString(Left6, "", false) == 0)
                Left6 = "No assets contributed to this production";
              string tid8 = str13 + "\r\n" + Left6;
              tweight17 = num47 + num48;
              this.IL.Add(num45, tweight17, 5, num42, num48 + num51, CheckExistence: false);
              this.ILdesc.Add(tid8, 1, 5, num42, num45, CheckExistence: false);
            }
            if (num49 > tdata3_2)
              tdata3_2 = num49;
            string str15;
            if (num49 > 0 | tdata3_2 > 0)
            {
              tweight17 = num49;
              string str16 = tweight17.ToString();
              if (tweight17 > 999)
              {
                num57 = Math.Round((double) tweight17 / 1000.0, 1);
                str16 = num57.ToString() + "k";
              }
              if (num49 > 0)
                str16 = "-" + str16;
              eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(num45, "", "");
              str3 = simpleStringList.Id[index33] + " consumed in Zone";
              string str17 = tdata3_2.ToString() + " could optimally be consumed.\r\n" + num49.ToString() + " was actually available and consumed by Zone.";
              str2 = str16;
              str15 = "";
              string Left7 = "";
              if (tdata3_2 > 0)
              {
                Left7 = "Assets that consumed:\r\n";
                tweight17 = 0;
                num12 = 0;
                if (this.slotDetail > -1)
                {
                  int length9 = this.game.Data.StringListObj[this.slotDetail].Length;
                  for (int index37 = 0; index37 <= length9; ++index37)
                  {
                    int index38 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index37, 0]));
                    if (index38 < 1000000)
                    {
                      int num68 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[index38], 0]));
                      int num69 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index37, 1]));
                      int num70 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index37, 3]));
                      if (num68 == num42 & num69 == 2 & num70 == num45)
                      {
                        int num71 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index37, 2]));
                        num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotDetail].Data[index37, 4]));
                        int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[index38], 1]));
                        string str18 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 1);
                        int nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue, 2)));
                        int num72 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[numArray2[index38], 11]));
                        if (num71 == 2 | num71 == 4 | num71 == 6)
                        {
                          if (nr > 0)
                            str18 = str18 + " " + this.game.HandyFunctionsObj.GetRomanNumerical(nr);
                          Left7 = Left7 + num72.ToString() + "% prod, " + str18 + " consumed " + num13.ToString() + " " + this.game.Data.StringListObj[this.slotItemType].GetData(0, num45, 1) + "\r\n";
                        }
                      }
                    }
                  }
                }
              }
              if (num53 > 0)
                Left7 = Left7 + "Workers consumed " + num53.ToString() + " " + this.game.Data.StringListObj[this.slotItemType].GetData(0, num45, 1) + "\r\n";
              if (num52 > 0)
                Left7 = Left7 + "Population was given " + num52.ToString() + " " + this.game.Data.StringListObj[this.slotItemType].GetData(0, num45, 1) + "\r\n";
              if (Operators.CompareString(Left7, "", false) == 0)
                Left7 = "No assets contributed to this consumption";
              string tid9 = str17 + "\r\n" + Left7;
              tweight17 = num49;
              this.IL.Add(num45, tweight17, 4, num42, tdata3_2, CheckExistence: false);
              this.ILdesc.Add(tid9, 1, 4, num42, num45, CheckExistence: false);
            }
            if (num50 > 0 | tdata3_3 > 0)
            {
              tweight17 = num50;
              str15 = tweight17.ToString();
              if (tweight17 > 999)
              {
                num57 = Math.Round((double) tweight17 / 1000.0, 1);
                str15 = num57.ToString() + "k";
              }
              str3 = simpleStringList.Id[index33] + " delivered from Zone to SHQ";
              string tid10 = tdata3_3.ToString() + " could optimally be delivered to SHQ.\r\n" + num50.ToString() + " was actually delivered by Zone.";
              this.IL.Add(num45, tweight17, 7, num42, tdata3_3, CheckExistence: false);
              this.ILdesc.Add(tid10, 1, 7, num42, num45, CheckExistence: false);
            }
            int num73 = 0;
            int num74 = 0;
            int tdata3_4 = 0;
            if (Information.IsNothing((object) this.game.Data.LocObj[locationById].items))
              this.game.Data.LocObj[locationById].items = new ItemList();
            if (Information.IsNothing((object) this.game.Data.LocObj[locationById].items.list))
              this.game.Data.LocObj[locationById].items.list = new SimpleList();
            int weight = this.game.Data.LocObj[locationById].items.list.FindWeight(num45);
            int num75 = 0;
            int num76 = 0;
            int num77 = 0;
            if (weight > 0)
            {
              tweight17 = weight;
              if (num45 == 9 | num45 == 12)
                tweight17 *= 100;
              str15 = tweight17.ToString();
              if (tweight17 > 999)
              {
                num57 = Math.Round((double) tweight17 / 1000.0, 1);
                str15 = num57.ToString() + "k";
              }
              str3 = simpleStringList.Id[index33] + " Zone Stocks";
              string tid11 = "This Zone has " + weight.ToString() + " " + simpleStringList.Id[index33] + " in reserve Stock.";
              if (num75 > 0)
                tid11 = tid11 + "\r\nLost " + (num75 - num76).ToString() + " items due to exceeding maximum stockage in Zone.";
              if (num76 > 0)
                tid11 = tid11 + "\r\nSold " + num76.ToString() + " items for " + num77.ToString() + " Credits due to exceeding maximum stockage in Zone.";
              if (num73 > 0)
                tid11 = tid11 + "\r\nZone provided " + num73.ToString() + " " + simpleStringList.Id[index33] + " Stockage.";
              if (num74 > 0)
                tid11 = tid11 + "\r\nOf these the Zone provided " + num74.ToString() + " " + simpleStringList.Id[index33] + " Stockage to its SHQ.";
              Color color = this.game.seColWhite;
              if (num75 > 0)
                color = this.game.seColYellow;
              this.IL.Add(num45, tweight17, 8, num42, tdata3_4, CheckExistence: false);
              this.ILdesc.Add(tid11, 1, 8, num42, num45, CheckExistence: false);
            }
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
      SizeF sizeF = new SizeF();
      int id1 = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      string libName1 = "SE_Data";
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 225, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 228, 0, 0));
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 169, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 168, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 143, 0, 0));
      int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName1, 190, 0, 0));
      int turn = this.game.Data.Turn;
      int idValue1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, id1, 2)));
      int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, idValue1, 1)));
      this.game.Data.StringListObj[stringListById1].SetData(0, "REGIMEID", 1, id1);
      this.game.Data.StringListObj[stringListById1].SetData(0, "ROUND", 1, this.game.Data.Round);
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
      if (this.okId > 0)
      {
        this.RemoveSubPart(this.okId);
        this.okId = 0;
      }
      if (this.RightId > 0)
      {
        this.RemoveSubPart(this.RightId);
        this.RightId = 0;
      }
      if (this.StartTurnId > 0)
      {
        this.RemoveSubPart(this.StartTurnId);
        this.StartTurnId = 0;
      }
      if (this.PreviewId > 0)
      {
        this.RemoveSubPart(this.PreviewId);
        this.PreviewId = 0;
      }
      if (this.RightId2 > 0)
      {
        this.RemoveSubPart(this.RightId2);
        this.RightId2 = 0;
      }
      if (this.StartTurnId2 > 0)
      {
        this.RemoveSubPart(this.StartTurnId2);
        this.StartTurnId2 = 0;
      }
      if (this.PreviewId2 > 0)
      {
        this.RemoveSubPart(this.PreviewId2);
        this.PreviewId2 = 0;
      }
      int assetButtonCounter1 = this.assetButtonCounter;
      for (int index = 0; index <= assetButtonCounter1; ++index)
      {
        this.RemoveSubPart(this.assetButton[index]);
        this.assetButton[index] = 0;
        this.assetButtonData[index] = 0;
      }
      this.assetButtonCounter = -1;
      int y1 = 80;
      Rectangle rectangle1 = new Rectangle(0, y1, this.useWidth, 50);
      Rectangle rectangle2 = new Rectangle(0, this.useHeight - 50, this.useWidth, 50);
      Rectangle rectangle3 = new Rectangle(0, y1 + rectangle1.Height, 200, this.useHeight - (rectangle1.Height + rectangle2.Height + y1));
      Rectangle rectangle4 = new Rectangle(this.useWidth - 500, y1 + rectangle1.Height, 500, this.useHeight - (rectangle1.Height + rectangle2.Height + 150 + y1));
      Rectangle rectangle5 = new Rectangle(rectangle3.Width, this.useHeight - (rectangle2.Height + 150), this.useWidth - rectangle3.Width, 150);
      int width1 = rectangle3.Width;
      int y2 = y1 + rectangle1.Height;
      int width2 = this.useWidth - (rectangle3.Width + rectangle4.Width);
      int height1 = this.useHeight - (rectangle1.Height + rectangle2.Height + rectangle5.Height);
      if (this.game.EditObj.se1_assetRightPanel < 1)
        width2 = this.useWidth - rectangle3.Width;
      Rectangle rectangle6 = new Rectangle(width1, y2, width2, height1);
      Rectangle rectangle7 = new Rectangle(rectangle3.Left, rectangle3.Top, rectangle3.Width, 150);
      Rectangle rectangle8 = new Rectangle(rectangle3.Left, rectangle7.Bottom + 10, rectangle3.Width, rectangle3.Height - 380);
      Rectangle rectangle9 = new Rectangle(rectangle3.Left, rectangle8.Bottom + 10, rectangle3.Width, 200);
      DrawMod.DrawBlock(ref g, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, 0, 0, 0, 120);
      DrawMod.DrawBlock(ref g, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, 0, 0, 0, 180);
      DrawMod.DrawBlock(ref g, rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height, 0, 0, 0, 180);
      DrawMod.DrawBlock(ref g, rectangle5.X, rectangle5.Y, rectangle5.Width, rectangle5.Height, 0, 0, 0, 60);
      if (this.game.EditObj.se1_assetRightPanel > 0)
        DrawMod.DrawBlock(ref g, rectangle4.X, rectangle4.Y, rectangle4.Width, rectangle4.Height, 0, 0, 0, 120);
      this.ListObj = new ListClass();
      int left1 = rectangle7.Left;
      int top1 = rectangle7.Top;
      int width3 = rectangle7.Width;
      int tlistsize1 = (int) Math.Round(Math.Floor((double) rectangle7.Height / 20.0)) - 1;
      int tlistselect1 = -1;
      int num2 = -1;
      if (this.anyZoneWithoutSHQ)
        this.ListObj.add("No SHQ", 0);
      int counter1 = this.listShq.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        ++num2;
        if (this.game.EditObj.se1_assetSHQ < 1 & !this.anyZoneWithoutSHQ)
          this.game.EditObj.se1_assetSHQ = this.listShq.Id[index];
        if (this.listShq.Id[index] == this.game.EditObj.se1_assetSHQ)
          tlistselect1 = num2;
        this.ListObj.add(this.game.Data.UnitObj[this.listShq.Id[index]].Name, this.listShq.Id[index]);
      }
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(this.ListObj, tlistsize1, width3, tlistselect1, this.game, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: left1, bby: top1, tMarcStyle: true, overruleFont: (ref this.game.MarcFont7), overruleItemSize: 20);
      this.listId = this.AddSubPart(ref tsubpart1, left1, top1, width3, (tlistsize1 + 1) * 20, 1);
      this.List2Obj = new ListClass();
      int left2 = rectangle8.Left;
      int top2 = rectangle8.Top;
      int width4 = rectangle8.Width;
      int tlistsize2 = (int) Math.Round(Math.Floor((double) rectangle8.Height / 20.0)) - 1;
      int tlistselect2 = -1;
      int num3 = -1;
      int counter2 = this.listZone.Counter;
      for (int index = 0; index <= counter2; ++index)
      {
        if (this.listZone.Data1[index] == this.game.EditObj.se1_assetSHQ)
        {
          ++num3;
          if (this.game.EditObj.se1_assetZone < 1)
            this.game.EditObj.se1_assetZone = this.listZone.Id[index];
          else if (this.listZone.FindNr(this.game.EditObj.se1_assetZone) == -1)
            this.game.EditObj.se1_assetZone = this.listZone.Id[index];
          if (this.listZone.Id[index] == this.game.EditObj.se1_assetZone)
            tlistselect2 = num3;
          this.List2Obj.add(this.game.Data.StringListObj[this.slotZones].GetData(0, this.listZone.Id[index], 7), this.listZone.Id[index], Conversions.ToString(this.listZone.Weight[index]));
        }
      }
      SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(this.List2Obj, tlistsize2, width4, tlistselect2, this.game, tShowPair: true, tValueWidth: 70, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: left2, bby: top2, tMarcStyle: true, overruleFont: (ref this.game.MarcFont7), overruleItemSize: 20);
      this.list2Id = this.AddSubPart(ref tsubpart2, left2, top2, width4, (tlistsize2 + 1) * 20, 1);
      int x1 = rectangle1.Left + (int) Math.Round((double) rectangle1.Width / 2.0);
      int y3 = rectangle1.Top + 10;
      string tstring1 = "Zone: " + (this.game.EditObj.se1_assetZone <= 0 ? "None" : this.game.Data.StringListObj[this.slotZones].GetData(0, this.game.EditObj.se1_assetZone, 7));
      if (this.game.EditObj.se1_assetMode == 2)
        tstring1 = "Preview " + tstring1;
      DrawMod.DrawTextColouredMarcCenter(ref g, tstring1, this.game.MarcFont2, x1, y3, Color.White);
      int num4 = rectangle1.Right - 330;
      int num5 = y1 + 2;
      int num6 = 100;
      int num7 = 46;
      bool tred1 = false;
      int overlay1 = 1;
      if (this.game.EditObj.se1_assetMode <= 1)
      {
        tred1 = true;
        overlay1 = 0;
      }
      if (overlay1 == 1)
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Start Turn", num6, "Data shown in right-pane will be based on the start of your turn.", ref this.OwnBitmap, num4, num5, tred: tred1, theight: num7, useshadow: true, tMarcStyle: true);
        this.StartTurnId = this.AddSubPart(ref tsubpart3, num4, num5, num6, num7, overlay1);
      }
      else
      {
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Start Turn", num6, tBackbitmap: (ref this.OwnBitmap), bbx: num4, bby: num5, tred: tred1, theight: num7, useshadow: true, tMarcStyle: true);
        this.StartTurnId2 = this.AddSubPart(ref tsubpart4, num4, num5, num6, num7, overlay1);
      }
      int num8 = num4 + 110;
      bool tred2 = false;
      int overlay2 = 1;
      if (this.game.EditObj.se1_assetMode == 2)
      {
        tred2 = true;
        overlay2 = 0;
      }
      if (overlay2 == 1)
      {
        SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Preview", num6, "Data shown in right-pane will be based on a preview calculation for your next turn start.", ref this.OwnBitmap, num8, num5, tred: tred2, theight: num7, useshadow: true, tMarcStyle: true);
        this.PreviewId = this.AddSubPart(ref tsubpart5, num8, num5, num6, num7, overlay2);
      }
      else
      {
        SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Preview", num6, tBackbitmap: (ref this.OwnBitmap), bbx: num8, bby: num5, tred: tred2, theight: num7, useshadow: true, tMarcStyle: true);
        this.PreviewId2 = this.AddSubPart(ref tsubpart6, num8, num5, num6, num7, overlay2);
      }
      int num9 = num8 + 110;
      bool tred3 = false;
      int overlay3 = 1;
      if (this.game.EditObj.se1_assetRightPanel == 1)
      {
        SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("Collapse", num6, "Will hide the right panel and free up space to show more Assets.", ref this.OwnBitmap, num9, num5, tred: tred3, theight: num7, useshadow: true, tMarcStyle: true);
        this.RightId = this.AddSubPart(ref tsubpart7, num9, num5, num6, num7, overlay3);
      }
      else
      {
        SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass("Expand", num6, "Will show the right panel to allow you to inspect Item inventory reports/previews.", ref this.OwnBitmap, num9, num5, tred: tred3, theight: num7, useshadow: true, tMarcStyle: true);
        this.RightId = this.AddSubPart(ref tsubpart8, num9, num5, num6, num7, overlay3);
      }
      int num10 = this.game.EditObj.se1_SelectAssetButton;
      int se1AssetZone = this.game.EditObj.se1_assetZone;
      int id2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, this.game.EditObj.se1_assetZone, 6)));
      int index1 = -1;
      int num11 = -1;
      int num12 = -1;
      int num13;
      if (id2 > 0)
      {
        index1 = this.game.HandyFunctionsObj.GetLocationByID(id2);
        if (index1 > -1)
        {
          num11 = this.game.Data.LocObj[index1].X;
          num12 = this.game.Data.LocObj[index1].Y;
        }
        else
          num13 = 0;
      }
      int id3 = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      int num14 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotRegKey].GetData2(0, id3, 1, "credits", 2)));
      this.orderfeedbackString = "";
      int num15;
      if (this.AssetOrderNumber > 0)
      {
        if (this.AssetOrderNumber == 32)
        {
          this.game.Data.StringListObj[this.slotAssets].SetData(9, num10, 5, -1);
          this.game.Data.StringListObj[this.slotAssets].SetData(9, num10, 15, 0);
        }
        if (this.AssetOrderNumber == 31)
        {
          int setValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].GetData(9, num10, 1))), 11)));
          this.game.Data.StringListObj[this.slotAssets].SetData(9, num10, 5, setValue);
          this.game.Data.StringListObj[this.slotAssets].SetData(9, num10, 15, 0);
        }
        if (this.AssetOrderNumber == 33)
        {
          this.game.Data.StringListObj[this.slotAssets].SetData(9, num10, 5, -2);
          this.game.Data.StringListObj[this.slotAssets].SetData(9, num10, 15, 0);
        }
        if (this.AssetOrderNumber >= 2000 & this.AssetOrderNumber <= 2100)
        {
          int setValue = this.AssetOrderNumber - 2000;
          if (setValue == 100)
            setValue = 0;
          this.game.Data.StringListObj[this.slotAssets].SetData(9, num10, 15, setValue);
        }
        if (this.AssetOrderNumber == 21)
        {
          int idValue2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].GetData(9, num10, 1)));
          int num16 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue2, 25)));
          int setValue1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, num16, 11)));
          int num17 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotConstruction].GetData3(0, idValue2, 1, 3, 2, "credits", 3)));
          int setValue2 = num14 - num17;
          int num18 = (int) Math.Round((double) num17 / 2.0);
          this.game.Data.StringListObj[this.slotRegKey].SetData2(0, id3, 1, "credits", 2, setValue2);
          int setValue3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZoneKeys].GetData2(0, se1AssetZone, 1, "popCredits", 2))) + num18;
          int num19 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZoneKeys].GetData2(0, se1AssetZone, 1, "popHapiness", 2)));
          int num20 = num19;
          int setValue4 = (int) Math.Round((double) num19 * 0.8);
          int num21 = num20 - setValue4;
          this.game.Data.StringListObj[this.slotZoneKeys].SetData2(0, se1AssetZone, 1, "popCredits", 2, setValue3, true);
          this.game.Data.StringListObj[this.slotZoneKeys].SetData2(0, se1AssetZone, 1, "popHapiness", 2, setValue4, true);
          this.game.Data.StringListObj[this.slotAssets].SetData(9, num10, 1, num16);
          this.game.Data.StringListObj[this.slotAssets].SetData(9, num10, 5, setValue1);
          this.orderfeedbackString = this.orderfeedbackString + "Asset was nationalized. Population happiness dropped with " + num21.ToString() + " points.";
        }
        if (this.AssetOrderNumber == 23)
        {
          int idValue3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].GetData(9, num10, 1)));
          num15 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].GetData(9, num10, 7)));
          int num22 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue3, 13)));
          int num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].GetData(9, num10, 3)));
          int num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].GetData(9, num10, 4)));
          SimpleList simpleList = new SimpleList();
          if (index1 > -1)
          {
            int length = this.game.Data.StringListObj[this.slotPaid].Length;
            for (int index2 = 0; index2 <= length; ++index2)
            {
              if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotPaid].Data[index2, 0])) == num10 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotPaid].Data[index2, 1])) == 1)
              {
                int tid = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotPaid].Data[index2, 2]));
                int tweight = (int) Math.Round((double) (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotPaid].Data[index2, 3])) / 2.0);
                if (tweight > 0)
                  simpleList.AddWeight(tid, tweight);
              }
            }
          }
          this.orderfeedbackString += "Construction was canceled. ";
          if (simpleList.Counter > -1)
          {
            int counter3 = simpleList.Counter;
            for (int index3 = 0; index3 <= counter3; ++index3)
            {
              if (index3 == 0)
                this.orderfeedbackString += "Recuperated: ";
              if (index3 > 0)
                this.orderfeedbackString += ", ";
              string data = this.game.Data.StringListObj[this.slotItemType].GetData(0, simpleList.Id[index3], 1);
              this.orderfeedbackString = this.orderfeedbackString + simpleList.Weight[index3].ToString() + "x " + data;
              this.game.Data.LocObj[index1].items.list.AddWeight(simpleList.Id[index3], simpleList.Weight[index3]);
            }
          }
          this.game.Data.StringListObj[this.slotAssets].RemoveRow(this.game.Data.StringListObj[this.slotAssets].FindRow(9, num10));
          this.game.EventRelatedObj.Helper_SetLocationTypeForHex(num23, num24, num23, num24);
        }
        this.ReCalculate();
      }
      this.AssetOrderNumber = 0;
      int num25 = 0;
      int num26 = (int) Math.Round(Math.Floor((double) rectangle6.Width / 160.0)) * (int) Math.Round(Math.Floor((double) rectangle6.Height / 210.0));
      num15 = -1;
      this.game.Data.FindEventPic("", 0, "SE_Present");
      this.game.Data.FindEventPic("", 109, "SE_Present");
      int num27 = -1;
      this.game.Data.FindEventPic("", 5, "SE_Present");
      int num28 = -1;
      int[] numArray1 = new int[10];
      SimpleList simpleList1 = new SimpleList();
      int num29 = 1;
      int num30;
      int integer1;
      int num31;
      int num32;
      int num33;
      int num34;
      do
      {
        int length = this.game.Data.StringListObj[this.slotAssets].Length;
        for (int tid1 = 0; tid1 <= length; ++tid1)
        {
          int tid2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[tid1, 9]));
          int idValue4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[tid1, 1]));
          num30 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue4, 3)));
          int x2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[tid1, 3]));
          int y4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[tid1, 4]));
          integer1 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x2, y4, libName1, "Zones"));
          int num35 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[tid1, 0]));
          if (se1AssetZone > 0 | x2 == this.game.SelectX & y4 == this.game.SelectY && num35 == se1AssetZone | integer1 == se1AssetZone && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue4, 5))) == num29)
          {
            int num36 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue4, 27)));
            if (num36 >= 0 & num36 <= 9)
            {
              int[] numArray2 = numArray1;
              int[] numArray3 = numArray2;
              int index4 = num36;
              int index5 = index4;
              int num37 = numArray2[index4] + 1;
              numArray3[index5] = num37;
            }
            if (integer1 == num35 | this.game.EditObj.se1_AssetCategory1 == 2)
            {
              if (num29 == 1)
                ++num31;
              if (num29 == 0)
                ++num32;
              if (num35 != integer1)
                ++num33;
            }
            if (x2 == this.game.SelectX & y4 == this.game.SelectY)
            {
              int num38;
              ++num38;
            }
            ++num34;
            bool flag = true;
            if (this.game.EditObj.se1_AssetCategory2 == 1 & num29 == 0)
              flag = false;
            if (this.game.EditObj.se1_AssetCategory2 == 2 & num29 == 1)
              flag = false;
            if (this.game.EditObj.se1_AssetCategory2 == 3 & num35 == integer1)
              flag = false;
            if (this.game.EditObj.se1_AssetCategory5 > 0 && num36 != this.game.EditObj.se1_AssetCategory5)
              flag = false;
            if (this.game.EditObj.se1_assetItemMode1 > 0 && this.listItemAsset.FindWeight(tid2, 4, this.game.EditObj.se1_assetItemMode1) < 1)
              flag = false;
            if (this.game.EditObj.se1_assetItemMode2 > 0 && this.listItemAsset.FindWeight(tid2, 5, this.game.EditObj.se1_assetItemMode2) < 1)
              flag = false;
            if (flag)
              simpleList1.Add(tid1, num29 * 100000 + x2 * 200 + y4);
          }
        }
        num29 += -1;
      }
      while (num29 >= 0);
      DataClass data1 = this.game.Data;
      string str1 = "perk";
      ref string local1 = ref str1;
      string libName2 = libName1;
      int libVar = data1.FindLibVar(ref local1, libName2);
      DataClass data2 = this.game.Data;
      string str2 = "hexname";
      ref string local2 = ref str2;
      string libName3 = libName1;
      data2.FindLibVar(ref local2, libName3);
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index6 = 0; index6 <= mapWidth; ++index6)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index7 = 0; index7 <= mapHeight; ++index7)
        {
          if (Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(index6, index7, libName1, "Zones")) == se1AssetZone)
          {
            int hexLibVarValue = this.game.Data.MapObj[0].HexObj[index6, index7].GetHexLibVarValue(libVar);
            if (hexLibVarValue > 0)
            {
              ++num34;
              ++num32;
              int[] numArray4 = numArray1;
              int[] numArray5 = numArray4;
              int index8 = 7;
              int index9 = index8;
              int num39 = numArray4[index8] + 1;
              numArray5[index9] = num39;
              if (this.game.EditObj.se1_AssetCategory2 != 1 && !(this.game.EditObj.se1_AssetCategory1 == 1 & !(index6 == this.game.SelectX & index7 == this.game.SelectY)) && this.game.EditObj.se1_AssetCategory5 < 1 | this.game.EditObj.se1_AssetCategory5 == 7)
              {
                bool flag = true;
                if (this.game.EditObj.se1_assetItemMode2 > 0 && this.listItemAsset.FindWeight(1000000 + hexLibVarValue, 5, this.game.EditObj.se1_assetItemMode2) < 1)
                  flag = false;
                if (this.game.EditObj.se1_assetItemMode1 > 0)
                  flag = false;
                if (flag)
                {
                  int num40 = 1000 * index6 + index7;
                  simpleList1.Add(9000000 + num40, 5000, index6, index7, hexLibVarValue);
                }
              }
            }
          }
        }
      }
      simpleList1.ReverseSort();
      int selectAssetButton = this.game.EditObj.se1_SelectAssetButton;
      int num41 = 0;
      int num42 = -1;
      int id4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, this.game.EditObj.se1_assetZone, 6)));
      int num43 = -1;
      int num44 = -1;
      if (id4 > 0)
      {
        int locationById = this.game.HandyFunctionsObj.GetLocationByID(id4);
        if (locationById > -1)
        {
          num43 = this.game.Data.LocObj[locationById].X;
          num44 = this.game.Data.LocObj[locationById].Y;
        }
        else
          num13 = 0;
      }
      int num45 = 1;
      int num46;
      do
      {
        int counter4 = simpleList1.Counter;
        for (int index10 = 0; index10 <= counter4; ++index10)
        {
          int index11 = simpleList1.Id[index10];
          int num47 = -1;
          int num48 = 0;
          num46 = -1;
          int idValue5;
          int num49;
          int num50;
          int num51;
          if (index11 >= 9000000 & index11 < 15000000)
          {
            num47 = simpleList1.Data3[index10];
            int num52 = simpleList1.Data1[index10];
            int num53 = simpleList1.Data2[index10];
            idValue5 = -1;
            num49 = 9000000 + num52 * 1000 + num53;
            num50 = se1AssetZone;
            if (num10 == num49)
            {
              num28 = num52;
              num51 = num53;
              num10 = num49;
            }
          }
          else if (index11 >= 15000000 & index11 < 16000000)
          {
            int num54 = simpleList1.Data1[index10];
            int num55 = simpleList1.Data2[index10];
            idValue5 = -1;
            num49 = 15000000 + num54 * 1000 + num55;
            num50 = se1AssetZone;
            num48 = simpleList1.Data3[index10];
            if (num10 == num49)
            {
              num28 = num54;
              num51 = num55;
              num10 = num49;
            }
          }
          else
          {
            num47 = -1;
            num49 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index11, 9]));
            idValue5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index11, 1]));
            num30 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue5, 3)));
            int x3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index11, 3]));
            int y5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index11, 4]));
            integer1 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x3, y5, libName1, "Zones"));
            num50 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index11, 0]));
            bool flag = false;
            if (num10 == num49)
            {
              num28 = x3;
              num51 = y5;
              num10 = num49;
              flag = true;
            }
          }
          if (num50 == se1AssetZone | integer1 == se1AssetZone && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue5, 5))) == num45 | num47 > 0 & num45 == 0 | num48 > 0 & num45 == 0)
          {
            ++num41;
            if (num42 == -1 & num49 == num10)
              num42 = num41;
          }
        }
        num45 += -1;
      }
      while (num45 >= 0);
      int num56 = 0;
      int num57 = (int) Math.Round(Math.Floor((double) simpleList1.Counter / (double) num26)) + 1;
      int num58;
      if (num42 > -1)
      {
        num56 = (int) Math.Round(Math.Floor((double) (num42 - 1) / (double) num26));
        num58 = num56 * num26 + 1;
      }
      else
        num58 = 1;
      if (this.game.EditObj.se1_assetPage2 > num57 | this.game.EditObj.se1_assetPage2 < 1)
      {
        this.game.EditObj.se1_assetPage2 = num56 + 1;
        this.prevAssetId = -1;
      }
      if (this.prevAssetId == num10)
      {
        num58 = (this.game.EditObj.se1_assetPage2 - 1) * num26 + 1;
        if (num58 < 1)
          num58 = 1;
      }
      else
        this.game.EditObj.se1_assetPage2 = num56 + 1;
      this.prevAssetId = num10;
      int num59 = num57;
      if (num59 > 8)
        num59 = 8;
      int num60 = (int) Math.Round(Math.Floor((double) rectangle6.Width / (double) num59)) - 4;
      if (num60 > 100)
        num60 = 100;
      int x4 = rectangle2.X + (int) Math.Round((double) rectangle2.Width / 2.0) - (int) Math.Round((double) (num59 * (num60 + 4)) / 2.0);
      int y6 = rectangle2.Y;
      int num61 = 1;
      if (num59 < num57)
      {
        num61 = this.game.EditObj.se1_assetPage2;
        if (num61 > num57 - 4)
          num61 = num57 - 4;
        if (num61 > this.game.EditObj.se1_assetPage2 - 3)
          num61 = this.game.EditObj.se1_assetPage2 - 3;
        if (1 > num61)
          num61 = 1;
      }
      int num62 = num59;
      for (int index12 = 1; index12 <= num62; ++index12)
      {
        int num63 = num61 - 1 + index12;
        if (num63 >= 1 & num63 <= num57)
        {
          ++this.assetButtonCounter;
          string tDescript = num63.ToString() + "/" + num57.ToString() + ". Click to view this Asset page.";
          if (this.game.EditObj.se1_assetPage2 == num63)
            tDescript = num63.ToString() + "/" + num57.ToString() + ". Currently selected Asset page for this Zone";
          int[] assetButton = this.assetButton;
          int assetButtonCounter2 = this.assetButtonCounter;
          SubPartClass tsubpart9 = (SubPartClass) new SEBigTextPartClass(num63.ToString(), tDescript, this.game.EditObj.se1_assetPage2 == num63, num60, 44);
          int num64 = this.AddSubPart(ref tsubpart9, x4, y6, num60, 44, 1);
          assetButton[assetButtonCounter2] = num64;
          this.assetButtonData[this.assetButtonCounter] = 50 + num63;
          x4 += num60 + 4;
        }
      }
      int x5 = rectangle9.X + 5;
      int y7 = rectangle9.Y;
      ++this.assetButtonCounter;
      string tDataString1 = num31.ToString();
      string tDescript1 = "Only Public Assets are shown if this button is tapped.";
      int[] assetButton1 = this.assetButton;
      int assetButtonCounter3 = this.assetButtonCounter;
      SubPartClass tsubpart10 = (SubPartClass) new SEZoneButtonShortPartClass(18, -1, tDataString1, tDescript1, this.game.EditObj.se1_AssetCategory2 == 1);
      int num65 = this.AddSubPart(ref tsubpart10, x5, y7, 93, 40, 1);
      assetButton1[assetButtonCounter3] = num65;
      this.assetButtonData[this.assetButtonCounter] = 13;
      int x6 = x5 + 97;
      ++this.assetButtonCounter;
      string tDataString2 = num32.ToString();
      string tDescript2 = "Only Private Assets are shown if this button is tapped.";
      int[] assetButton2 = this.assetButton;
      int assetButtonCounter4 = this.assetButtonCounter;
      SubPartClass tsubpart11 = (SubPartClass) new SEZoneButtonShortPartClass(19, -1, tDataString2, tDescript2, this.game.EditObj.se1_AssetCategory2 == 2);
      int num66 = this.AddSubPart(ref tsubpart11, x6, y7, 93, 40, 1);
      assetButton2[assetButtonCounter4] = num66;
      this.assetButtonData[this.assetButtonCounter] = 14;
      int y8 = y7 + 41;
      int x7 = rectangle9.X + 5;
      ++this.assetButtonCounter;
      string tDataString3 = numArray1[1].ToString();
      string tDescript3 = "Only Agriculture Assets are shown if this button is tapped.";
      int[] assetButton3 = this.assetButton;
      int assetButtonCounter5 = this.assetButtonCounter;
      SubPartClass tsubpart12 = (SubPartClass) new SEZoneButtonShortPartClass(58, -1, tDataString3, tDescript3, this.game.EditObj.se1_AssetCategory5 == 1);
      int num67 = this.AddSubPart(ref tsubpart12, x7, y8, 93, 40, 1);
      assetButton3[assetButtonCounter5] = num67;
      this.assetButtonData[this.assetButtonCounter] = 161;
      int x8 = x7 + 97;
      ++this.assetButtonCounter;
      string tDataString4 = numArray1[2].ToString();
      string tDescript4 = "Only Mining Assets are shown if this button is tapped.";
      int[] assetButton4 = this.assetButton;
      int assetButtonCounter6 = this.assetButtonCounter;
      SubPartClass tsubpart13 = (SubPartClass) new SEZoneButtonShortPartClass(59, -1, tDataString4, tDescript4, this.game.EditObj.se1_AssetCategory5 == 2);
      int num68 = this.AddSubPart(ref tsubpart13, x8, y8, 93, 40, 1);
      assetButton4[assetButtonCounter6] = num68;
      this.assetButtonData[this.assetButtonCounter] = 162;
      int y9 = y8 + 41;
      int x9 = rectangle9.X + 5;
      ++this.assetButtonCounter;
      string tDataString5 = numArray1[3].ToString();
      string tDescript5 = "Only Energy Assets are shown if this button is tapped.";
      int[] assetButton5 = this.assetButton;
      int assetButtonCounter7 = this.assetButtonCounter;
      SubPartClass tsubpart14 = (SubPartClass) new SEZoneButtonShortPartClass(32, -1, tDataString5, tDescript5, this.game.EditObj.se1_AssetCategory5 == 3);
      int num69 = this.AddSubPart(ref tsubpart14, x9, y9, 93, 40, 1);
      assetButton5[assetButtonCounter7] = num69;
      this.assetButtonData[this.assetButtonCounter] = 163;
      int x10 = x9 + 97;
      ++this.assetButtonCounter;
      string tDataString6 = numArray1[4].ToString();
      string tDescript6 = "Only Industry Assets are shown if this button is tapped.";
      int[] assetButton6 = this.assetButton;
      int assetButtonCounter8 = this.assetButtonCounter;
      SubPartClass tsubpart15 = (SubPartClass) new SEZoneButtonShortPartClass(60, -1, tDataString6, tDescript6, this.game.EditObj.se1_AssetCategory5 == 4);
      int num70 = this.AddSubPart(ref tsubpart15, x10, y9, 93, 40, 1);
      assetButton6[assetButtonCounter8] = num70;
      this.assetButtonData[this.assetButtonCounter] = 164;
      int y10 = y9 + 41;
      int x11 = rectangle9.X + 5;
      ++this.assetButtonCounter;
      string tDataString7 = numArray1[5].ToString();
      string tDescript7 = "Only QOL / Research / Government Assets are shown if this button is tapped.";
      int[] assetButton7 = this.assetButton;
      int assetButtonCounter9 = this.assetButtonCounter;
      SubPartClass tsubpart16 = (SubPartClass) new SEZoneButtonShortPartClass(17, -1, tDataString7, tDescript7, this.game.EditObj.se1_AssetCategory5 == 5);
      int num71 = this.AddSubPart(ref tsubpart16, x11, y10, 93, 40, 1);
      assetButton7[assetButtonCounter9] = num71;
      this.assetButtonData[this.assetButtonCounter] = 165;
      int x12 = x11 + 97;
      ++this.assetButtonCounter;
      string tDataString8 = numArray1[6].ToString();
      string tDescript8 = "Only Logistical Assets are shown if this button is tapped.";
      int[] assetButton8 = this.assetButton;
      int assetButtonCounter10 = this.assetButtonCounter;
      SubPartClass tsubpart17 = (SubPartClass) new SEZoneButtonShortPartClass(50, -1, tDataString8, tDescript8, this.game.EditObj.se1_AssetCategory5 == 6);
      int num72 = this.AddSubPart(ref tsubpart17, x12, y10, 93, 40, 1);
      assetButton8[assetButtonCounter10] = num72;
      this.assetButtonData[this.assetButtonCounter] = 166;
      int y11 = y10 + 41;
      int x13 = rectangle9.X + 5;
      ++this.assetButtonCounter;
      string tDataString9 = numArray1[7].ToString();
      string tDescript9 = "Only Hex Feats and Auxilliary Assets are shown if this button is tapped.";
      int[] assetButton9 = this.assetButton;
      int assetButtonCounter11 = this.assetButtonCounter;
      SubPartClass tsubpart18 = (SubPartClass) new SEZoneButtonShortPartClass(1, -1, tDataString9, tDescript9, this.game.EditObj.se1_AssetCategory5 == 7);
      int num73 = this.AddSubPart(ref tsubpart18, x13, y11, 93, 40, 1);
      assetButton9[assetButtonCounter11] = num73;
      this.assetButtonData[this.assetButtonCounter] = 167;
      int x14 = x13 + 97;
      ++this.assetButtonCounter;
      string tDataString10 = num33.ToString();
      string tDescript10 = "Delegated and Tasked Assets are shown if this button is tapped.";
      int[] assetButton10 = this.assetButton;
      int assetButtonCounter12 = this.assetButtonCounter;
      SubPartClass tsubpart19 = (SubPartClass) new SEZoneButtonShortPartClass(39, -1, tDataString10, tDescript10, this.game.EditObj.se1_AssetCategory2 == 3);
      int num74 = this.AddSubPart(ref tsubpart19, x14, y11, 93, 40, 1);
      assetButton10[assetButtonCounter12] = num74;
      this.assetButtonData[this.assetButtonCounter] = 15;
      int num75 = y11 + 41;
      int num76 = 0;
      num15 = -1;
      int num77 = -1;
      num75 = 18;
      Color color = Color.FromArgb(100, (int) byte.MaxValue, (int) byte.MaxValue, 0);
      if (turn > -1)
        color = Color.FromArgb(200, this.game.Data.RegimeObj[turn].Red, this.game.Data.RegimeObj[turn].Green, this.game.Data.RegimeObj[turn].Blue);
      int num78 = (int) Math.Round((double) (rectangle6.Width - (int) Math.Round(Math.Floor((double) rectangle6.Width / 160.0)) * 160) / 2.0);
      int x15 = rectangle6.X - 160 + num78;
      int y12 = rectangle6.Y;
      int num79 = 1;
      string str3;
      Rectangle rectangle10;
      do
      {
        int counter5 = simpleList1.Counter;
        for (int index13 = 0; index13 <= counter5; ++index13)
        {
          int index14 = simpleList1.Id[index13];
          int idValue6 = -1;
          num46 = -1;
          int num80 = 0;
          int x16;
          int y13;
          int idValue7;
          int assetId;
          int num81;
          int idValue8;
          int num82;
          int regime1;
          if (index14 >= 9000000 & index14 < 15000000)
          {
            idValue6 = simpleList1.Data3[index13];
            x16 = simpleList1.Data1[index13];
            y13 = simpleList1.Data2[index13];
            idValue7 = -1;
            assetId = 9000000 + x16 * 1000 + y13;
            num81 = se1AssetZone;
            idValue8 = se1AssetZone;
            num82 = 0;
            regime1 = this.game.Data.MapObj[0].HexObj[x16, y13].Regime;
          }
          else if (index14 >= 15000000 & index14 < 16000000)
          {
            num80 = simpleList1.Data3[index13];
            x16 = simpleList1.Data1[index13];
            y13 = simpleList1.Data2[index13];
            idValue7 = -1;
            assetId = 15000000 + x16 * 1000 + y13;
            num81 = se1AssetZone;
            idValue8 = se1AssetZone;
            num82 = 0;
            regime1 = this.game.Data.MapObj[0].HexObj[x16, y13].Regime;
          }
          else
          {
            idValue6 = -1;
            assetId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 9]));
            idValue7 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 1]));
            num30 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 3)));
            x16 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 3]));
            y13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 4]));
            num82 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 5)));
            idValue8 = Conversions.ToInteger(this.game.EventRelatedObj.CheckLibVarHex(x16, y13, libName1, "Zones"));
            regime1 = this.game.Data.MapObj[0].HexObj[x16, y13].Regime;
            num81 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 0]));
          }
          if (num81 == se1AssetZone | idValue8 == se1AssetZone && num80 > 0 & num79 == 0 | idValue6 > -1 & num79 == 0 | (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 5))) == num79)
          {
            ++num76;
            ++num25;
            if (num76 >= num58 & num76 < num58 + num26)
            {
              if (num10 < 1)
                num10 = assetId;
              if (num27 == -1)
                num27 = num76;
              ++num77;
              x15 += 160;
              if (x15 > rectangle6.Right - 160)
              {
                x15 = rectangle6.X + num78;
                y12 += 210;
              }
              if (this.game.EditObj.se1_SelectAssetButton < 1 & x16 == this.game.SelectX & y13 == this.game.SelectY)
                this.game.EditObj.se1_SelectAssetButton = assetId;
              CustomBitmapClass customBitmapObj = this.game.CustomBitmapObj;
              ref Graphics local3 = ref g;
              int tx = x15;
              int ty = y12;
              WindowClass windowClass = (WindowClass) this;
              ref WindowClass local4 = ref windowClass;
              int curAssetId = num10;
              int assetRowOrSpecialCode = index14;
              int specialOnX = x16;
              int specialOnY = y13;
              int specialType = simpleList1.Data3[index13];
              int zoneNr = se1AssetZone;
              int zoneRegNr = turn;
              int num83 = this.game.EditObj.se1_assetMode == 2 ? 1 : 0;
              customBitmapObj.Se1_DrawAssetBlock(ref local3, tx, ty, ref local4, curAssetId, assetRowOrSpecialCode, specialOnX, specialOnY, specialType, zoneNr, zoneRegNr, num83 != 0);
              string str4;
              Rectangle rectangle11;
              string str5;
              if (idValue7 > 0 & this.game.EditObj.se1_SelectAssetButton == assetId)
              {
                int num84 = x15;
                int num85 = y12;
                int regime2 = this.game.Data.MapObj[0].HexObj[x16, y13].Regime;
                int id5 = this.game.Data.RegimeObj[regime2].id;
                int num86 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 25)));
                int num87 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 5)));
                int num88 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 13]));
                int num89 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 11]));
                int num90 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 6]));
                int num91 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 15]));
                int num92 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 8]));
                int num93 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 2)));
                str3 = this.game.Data.StringListObj[this.slotAssets].Data[index14, 10];
                if (this.game.Data.MapObj[0].HexObj[x16, y13].Location > -1 & idValue8 > 0 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotZones].GetData(0, idValue8, 6))) != this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x16, y13].Location].ID)
                {
                  string name = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x16, y13].Location].Name;
                  this.game.Data.StringListObj[this.slotAssets].Data[index14, 10] = name;
                }
                str4 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 1);
                string str6 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 12);
                int num94 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 5]));
                int num95 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 4)));
                int num96 = rectangle5.X + 20;
                int y14 = rectangle5.Y;
                int w1 = 220;
                int h1 = 150;
                DrawMod.DrawBlock(ref g, num96, y14, w1, h1, 0, 0, 0, 100);
                DrawMod.DrawBlock(ref g, num96, y14, w1, 40, 0, 0, 0, 100);
                int index15 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 8)));
                int nr = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 2)));
                string tstring2 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 1);
                string data3 = this.game.Data.StringListObj[this.slotAssetTypes].GetData(0, idValue7, 12);
                if (nr > 0)
                {
                  str6 = data3 + " " + this.game.HandyFunctionsObj.GetRomanNumerical(nr);
                  tstring2 = tstring2 + " " + this.game.HandyFunctionsObj.GetRomanNumerical(nr);
                }
                if (index15 > 0)
                {
                  num60 = nr;
                  if (num60 > 5)
                    num60 = 5;
                  if (num60 < 1)
                    num60 = 1;
                  --num60;
                  int x17 = 2 + num60 * 134;
                  ref Graphics local5 = ref g;
                  Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[index15]);
                  ref Bitmap local6 = ref bitmap;
                  rectangle11 = new Rectangle(x17, 2, 131, 111);
                  Rectangle srcrect = rectangle11;
                  rectangle10 = new Rectangle(num96, y14 + 40, 131, 111);
                  Rectangle destrect = rectangle10;
                  DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
                  DrawMod.DrawTextColouredMarcCenter(ref g, tstring2, this.game.MarcFont4, num96 + 110, y14 + 10, Color.White);
                }
                int x18 = num96 + 130;
                int y15 = y14 + 45;
                Color c = Color.FromArgb((int) byte.MaxValue, 180, 180, 180);
                int num97 = 16;
                int idValue9 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 0]));
                str5 = idValue8 == se1AssetZone ? (num81 != se1AssetZone ? "DEL.TO:" + this.game.Data.StringListObj[this.slotZones].GetData(0, idValue9, 7) : (se1AssetZone >= 1 ? "ZONE:" + this.game.Data.StringListObj[this.slotZones].GetData(0, idValue9, 7) : "Hex without zone")) : (regime2 == this.game.Data.Turn ? "TASK FROM:" + this.game.Data.StringListObj[this.slotZones].GetData(0, idValue8, 7) : "ZONE:Evacuated Asset");
                if (num92 > 0)
                {
                  int y16;
                  if (turn == this.game.Data.Turn)
                  {
                    string tstring3 = "UPKP: " + num88.ToString() + "%";
                    DrawMod.DrawTextColouredConsole(ref g, tstring3, DrawMod.TGame.se1TypeWriterMedium, x18, y15, DrawMod.TGame.seColTW);
                    int y17 = y15 + num97;
                    string tstring4 = "CONS: " + num89.ToString() + "%";
                    DrawMod.DrawTextColouredConsole(ref g, tstring4, DrawMod.TGame.se1TypeWriterMedium, x18, y17, DrawMod.TGame.seColTW);
                    y16 = y17 + num97;
                  }
                  else
                  {
                    string tstring5 = "CONS: " + num89.ToString() + "%";
                    DrawMod.DrawTextColouredConsole(ref g, tstring5, DrawMod.TGame.se1TypeWriterMedium, x18, y15, DrawMod.TGame.seColTW);
                    y16 = y15 + num97;
                  }
                  string tstring6 = "DAM: " + num90.ToString() + " pts";
                  DrawMod.DrawTextColouredMarc(ref g, tstring6, this.game.MarcFont4, x18, y16, c);
                  int y18 = y16 + num97;
                  if (turn == this.game.Data.Turn)
                  {
                    string Left = ((float) Math.Round((double) ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 7])) * 100 - (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotAssets].Data[index14, 12]))) / 100.0, 1)).ToString();
                    if (Operators.CompareString(Left, "0", false) == 0)
                      Left = "0.1";
                    string tstring7 = "CONS: " + Left + "t.";
                    DrawMod.DrawTextColouredMarc(ref g, tstring7, this.game.MarcFont4, x18, y18, c);
                    num75 = y18 + num97;
                  }
                }
                else
                {
                  if (turn == this.game.Data.Turn)
                  {
                    string tstring8 = "UPKP: " + num88.ToString() + "%";
                    DrawMod.DrawTextColouredMarc(ref g, tstring8, this.game.MarcFont4, x18, y15, c);
                    int y19 = y15 + num97;
                    string tstring9 = "PROD: " + num89.ToString() + "%";
                    DrawMod.DrawTextColouredMarc(ref g, tstring9, this.game.MarcFont4, x18, y19, c);
                    y15 = y19 + num97;
                  }
                  string tstring10 = "DAM: " + num90.ToString();
                  DrawMod.DrawTextColouredMarc(ref g, tstring10, this.game.MarcFont4, x18, y15, c);
                  int y20 = y15 + num97;
                  if (turn == this.game.Data.Turn)
                  {
                    string tstring11 = !(num91 > 0 & num91 < 100) ? "LIM: 100%" : "LIM: " + num91.ToString() + "%";
                    DrawMod.DrawTextColouredMarc(ref g, tstring11, this.game.MarcFont4, x18, y20, c);
                    y20 += num97;
                  }
                  if (turn == this.game.Data.Turn && x16 > -1 & num95 == 5)
                  {
                    int location = this.game.Data.MapObj[0].HexObj[x16, y13].Location;
                    int num98 = 0;
                    int num99 = 0;
                    if (location > -1)
                    {
                      int logCounter = this.game.Data.LocObj[location].LogCounter;
                      for (int index16 = 0; index16 <= logCounter; ++index16)
                      {
                        if (this.game.Data.LocObj[location].LogType[index16] >= 801 & this.game.Data.LocObj[location].LogType[index16] <= 899)
                          num98 += this.game.Data.LocObj[location].LogData3[index16];
                        if (this.game.Data.LocObj[location].LogType[index16] >= 901 & this.game.Data.LocObj[location].LogType[index16] <= 999)
                          num99 += this.game.Data.LocObj[location].LogData3[index16];
                      }
                      if (num98 > 0 | num99 > 0)
                      {
                        string tstring12 = "L.EXT: " + num99.ToString();
                        DrawMod.DrawTextColouredMarc(ref g, tstring12, this.game.MarcFont4, x18, y20, c);
                        int y21 = y20 + num97;
                        string tstring13 = "NXT: " + num98.ToString();
                        DrawMod.DrawTextColouredMarc(ref g, tstring13, this.game.MarcFont4, x18, y21, c);
                        num75 = y21 + num97;
                      }
                    }
                  }
                }
                int x1_1 = rectangle5.X + 20 + 220 + 10;
                int y22 = rectangle5.Y;
                int w2 = 330;
                int h2 = 150;
                DrawMod.DrawBlock(ref g, x1_1, y22, w2, h2, 0, 0, 0, 100);
                DrawMod.DrawBlock(ref g, x1_1, y22, w2, 40, 0, 0, 0, 100);
                DrawMod.DrawTextColouredMarcCenter(ref g, "Options", this.game.MarcFont4, x1_1 + 165, y22 + 10, Color.White);
                if (turn == this.game.Data.Turn)
                {
                  int num100 = y22 + 45;
                  int num101 = x1_1 + 15;
                  int num102 = 90;
                  if (num82 < 1)
                    num102 = 160;
                  int num103 = num100;
                  SubPartClass tsubpart20;
                  if (num82 < 1)
                  {
                    int num104 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotRegKey].GetData2(0, this.game.Data.RegimeObj[turn].id, 1, "credits", 2)));
                    num60 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotConstruction].GetData3(0, idValue7, 1, 3, 2, "credits", 3)));
                    string buttontext = "Nationalize [" + num60.ToString() + "Cr]";
                    string tDescript11;
                    int num105;
                    if (num60 > num104)
                    {
                      tDescript11 = "You do not have the " + num60.ToString() + " credits required to nationalize this asset. ";
                      num105 = 1;
                    }
                    else
                    {
                      tDescript11 = "Nationalizing this asset will cost you " + num60.ToString() + " credits. ";
                      num105 = 0;
                    }
                    if (num86 < 1)
                    {
                      tDescript11 = "This Asset Type cannot be nationalized. ";
                      num105 = 1;
                      buttontext = "Nationalize";
                    }
                    else if (num92 > 0)
                    {
                      tDescript11 = "A Private Asset in construction cannot be nationalized. ";
                      num105 = 1;
                      buttontext = "Nationalize";
                    }
                    else if (this.game.EventRelatedObj.Helper_IsAssetUnderConstructionOrUpgrade(assetId))
                    {
                      tDescript11 = "A Private Asset in the process of being upgraded cannot be nationalized. ";
                      num105 = 1;
                      buttontext = "Nationalize";
                    }
                    ++this.assetButtonCounter;
                    int[] assetButton11 = this.assetButton;
                    int assetButtonCounter13 = this.assetButtonCounter;
                    tsubpart20 = (SubPartClass) new TextButtonPartClass(buttontext, num102, tDescript11, ref this.OwnBitmap, num101, num100, num105 == 1, theight: 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
                    int num106 = this.AddSubPart(ref tsubpart20, num101, num100, num102, 25, 1);
                    assetButton11[assetButtonCounter13] = num106;
                    this.assetButtonData[this.assetButtonCounter] = 21;
                    if (num105 == 1)
                      this.assetButtonData[this.assetButtonCounter] = 0;
                    num100 += 25;
                  }
                  string tDescript12 = "Change the zone this asset is delegated to";
                  ++this.assetButtonCounter;
                  int num107 = 0;
                  if (x16 == num43 & y13 == num44)
                  {
                    num107 = 1;
                    tDescript12 = "Cannot Delegate Assets in the City, only in Rural Hexes.";
                  }
                  if (num82 < 1 && num81 == se1AssetZone)
                  {
                    num107 = 1;
                    tDescript12 = "Cannot Delegate Private Assets, only Public ones.";
                  }
                  if (num81 != se1AssetZone)
                  {
                    int[] assetButton12 = this.assetButton;
                    int assetButtonCounter14 = this.assetButtonCounter;
                    tsubpart20 = (SubPartClass) new TextButtonPartClass("(Un)delegate", num102, tDescript12, ref this.OwnBitmap, num101, num100, num107 == 1, theight: 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
                    int num108 = this.AddSubPart(ref tsubpart20, num101, num100, num102, 25, 1);
                    assetButton12[assetButtonCounter14] = num108;
                  }
                  else
                  {
                    int[] assetButton13 = this.assetButton;
                    int assetButtonCounter15 = this.assetButtonCounter;
                    tsubpart20 = (SubPartClass) new TextButtonPartClass("Delegate", num102, tDescript12, ref this.OwnBitmap, num101, num100, num107 == 1, theight: 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
                    int num109 = this.AddSubPart(ref tsubpart20, num101, num100, num102, 25, 1);
                    assetButton13[assetButtonCounter15] = num109;
                  }
                  this.assetButtonData[this.assetButtonCounter] = 22;
                  if (num107 == 1)
                    this.assetButtonData[this.assetButtonCounter] = 0;
                  int num110 = num103;
                  int num111 = num101 + 100;
                  int num112 = 90;
                  if (num87 == 1)
                  {
                    if (num92 == 1)
                    {
                      int num113 = 0;
                      string tDescript13 = "Cancel Construction";
                      ++this.assetButtonCounter;
                      int[] assetButton14 = this.assetButton;
                      int assetButtonCounter16 = this.assetButtonCounter;
                      tsubpart20 = (SubPartClass) new TextButtonPartClass("Cancel Constr.", num112, tDescript13, ref this.OwnBitmap, num111, num110, num113 == 1, num113 == 1, 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
                      int num114 = this.AddSubPart(ref tsubpart20, num111, num110, num112, 25, 1);
                      assetButton14[assetButtonCounter16] = num114;
                      this.assetButtonData[this.assetButtonCounter] = 23;
                      if (num113 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      num75 = num110 + 25;
                    }
                    else
                    {
                      int num115 = 1;
                      if (num94 < 0)
                        num115 = 0;
                      string tDescript14 = "Set Asset to Active Mode";
                      ++this.assetButtonCounter;
                      int[] assetButton15 = this.assetButton;
                      int assetButtonCounter17 = this.assetButtonCounter;
                      tsubpart20 = (SubPartClass) new TextButtonPartClass("Active", num112, tDescript14, ref this.OwnBitmap, num111, num110, num115 == 1, num115 == 1, 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
                      int num116 = this.AddSubPart(ref tsubpart20, num111, num110, num112, 25, 1);
                      assetButton15[assetButtonCounter17] = num116;
                      this.assetButtonData[this.assetButtonCounter] = 31;
                      if (num115 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      int num117 = num110 + 25;
                      int num118 = 1;
                      if (num94 != -1)
                        num118 = 0;
                      string tDescript15 = "Set Asset to Mothball Mode";
                      ++this.assetButtonCounter;
                      int[] assetButton16 = this.assetButton;
                      int assetButtonCounter18 = this.assetButtonCounter;
                      tsubpart20 = (SubPartClass) new TextButtonPartClass("Mothball", num112, tDescript15, ref this.OwnBitmap, num111, num117, num118 == 1, num118 == 1, 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
                      int num119 = this.AddSubPart(ref tsubpart20, num111, num117, num112, 25, 1);
                      assetButton16[assetButtonCounter18] = num119;
                      this.assetButtonData[this.assetButtonCounter] = 32;
                      if (num118 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      int num120 = num117 + 25;
                      int num121 = 1;
                      if (num94 != -2)
                        num121 = 0;
                      string tDescript16 = "Close down the Asset";
                      ++this.assetButtonCounter;
                      int[] assetButton17 = this.assetButton;
                      int assetButtonCounter19 = this.assetButtonCounter;
                      tsubpart20 = (SubPartClass) new TextButtonPartClass("Close", num112, tDescript16, ref this.OwnBitmap, num111, num120, num121 == 1, num121 == 1, 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
                      int num122 = this.AddSubPart(ref tsubpart20, num111, num120, num112, 25, 1);
                      assetButton17[assetButtonCounter19] = num122;
                      this.assetButtonData[this.assetButtonCounter] = 33;
                      if (num121 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      num75 = num120 + 25;
                    }
                  }
                  if (num82 > 0)
                  {
                    int num123 = num103;
                    int num124 = num111 + 110;
                    int num125 = 90;
                    int num126 = 1;
                    do
                    {
                      ++this.assetButtonCounter;
                      if (num126 == 1)
                        num60 = 100;
                      if (num126 == 2)
                        num60 = 75;
                      if (num126 == 3)
                        num60 = 50;
                      if (num126 == 4)
                        num60 = 25;
                      string buttontext;
                      string tDescript17;
                      if (num92 > 0)
                      {
                        buttontext = num60.ToString() + "% Cons";
                        tDescript17 = "Set maximum construction speed of Asset to " + buttontext + ".";
                      }
                      else
                      {
                        buttontext = num60.ToString() + "% Prod";
                        tDescript17 = "Set maximum production speed of Asset to " + buttontext + ".";
                      }
                      int num127 = 0;
                      if (num91 == num60 | num91 == 0 & num60 == 100)
                        num127 = 1;
                      int[] assetButton18 = this.assetButton;
                      int assetButtonCounter20 = this.assetButtonCounter;
                      tsubpart20 = (SubPartClass) new TextButtonPartClass(buttontext, num125, tDescript17, ref this.OwnBitmap, num124, num123, num127 == 1, num127 == 1, 25, usefont: DrawMod.TGame.MarcFont4, useshadow: true, tMarcStyle: true);
                      int num128 = this.AddSubPart(ref tsubpart20, num124, num123, num125, 25, 1);
                      assetButton18[assetButtonCounter20] = num128;
                      this.assetButtonData[this.assetButtonCounter] = 2000 + num60;
                      if (num127 == 1)
                        this.assetButtonData[this.assetButtonCounter] = 0;
                      num123 += 25;
                      ++num126;
                    }
                    while (num126 <= 4);
                  }
                }
                x15 = num84;
                y12 = num85;
              }
              else if (idValue6 > 0)
              {
                if (num10 == assetId)
                {
                  int num129 = x15;
                  int num130 = y12;
                  int num131 = rectangle5.X + 20;
                  int y23 = rectangle5.Y;
                  int w = 220;
                  int h = 150;
                  DrawMod.DrawBlock(ref g, num131, y23, w, h, 0, 0, 0, 100);
                  DrawMod.DrawBlock(ref g, num131, y23, w, 40, 0, 0, 0, 100);
                  int integer2 = Conversions.ToInteger(this.game.Data.StringListObj[this.slotPerks].GetData(0, idValue6, 13));
                  int num132 = 0;
                  str5 = "";
                  str4 = "";
                  str3 = "";
                  string data4 = this.game.Data.StringListObj[this.slotPerks].GetData(0, idValue6, 1);
                  str3 = this.game.Data.StringListObj[this.slotPerks].GetData(0, idValue6, 7) + "\r\n\r\n" + "A Hex Perk is completely independent from your Public and Private Economy and delivers as long as it is connected to the Zone City.";
                  if (integer2 > 0)
                  {
                    num60 = num132;
                    if (num60 > 5)
                      num60 = 5;
                    if (num60 < 1)
                      num60 = 1;
                    --num60;
                    int x19 = 2 + num60 * 134;
                    ref Graphics local7 = ref g;
                    Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[integer2]);
                    ref Bitmap local8 = ref bitmap;
                    rectangle10 = new Rectangle(x19, 2, 131, 111);
                    Rectangle srcrect = rectangle10;
                    rectangle11 = new Rectangle(num131, y23 + 40, 131, 111);
                    Rectangle destrect = rectangle11;
                    DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
                    DrawMod.DrawTextColouredMarcCenter(ref g, data4, this.game.MarcFont4, num131 + 110, y23 + 10, Color.White);
                  }
                  int x20 = num131 + 130;
                  int y24 = y23 + 45;
                  Color c = Color.FromArgb((int) byte.MaxValue, 180, 180, 180);
                  int num133 = 16;
                  string tstring14 = "Hex Perk.\r\nNo settings\r\npossible.";
                  DrawMod.DrawTextColouredMarc(ref g, tstring14, this.game.MarcFont4, x20, y24, c);
                  num75 = y24 + num133;
                  x15 = num129;
                  y12 = num130;
                }
              }
              else if (num80 > 0 && num10 == assetId)
              {
                string tstring15 = idValue8 >= 1 ? "ZONE:" + this.game.Data.StringListObj[this.slotZones].GetData(0, idValue8, 7) : "Hex without zone";
                DrawMod.DrawTextColouredConsole(ref g, tstring15, DrawMod.TGame.se1TypeWriterMedium, x15, y12, DrawMod.TGame.seColTW);
                int y25 = y12 + 20;
                string tstring16 = "A Free Folk settlement.";
                DrawMod.DrawTextColouredConsole(ref g, tstring16, DrawMod.TGame.se1TypeWriterMedium, x15, y25, DrawMod.TGame.seColTW);
                int y26 = y25 + 20;
                string tstring17 = "No settings possible.";
                DrawMod.DrawTextColouredConsole(ref g, tstring17, DrawMod.TGame.se1TypeWriterMedium, x15, y26, DrawMod.TGame.seColTW);
                y12 = y26 + 20;
              }
            }
          }
        }
        num79 += -1;
      }
      while (num79 >= 0);
      bool flag1 = false;
      if (this.game.EditObj.se1_assetMode > 1)
        flag1 = true;
      if (this.game.EditObj.se1_assetRightPanel > 0)
      {
        SimpleList simpleList2 = new SimpleList();
        SimpleStringList simpleStringList = new SimpleStringList();
        simpleList2.Add(7, 0, 19);
        simpleStringList.Add("Food\r\nYour workers and soldiers need food in order not to starve.", 1);
        simpleList2.Add(5, 0, 20);
        simpleStringList.Add("Water\r\nYour domed farms need water in order to produce food.", 1);
        simpleList2.Add(1, 0, 18);
        simpleStringList.Add("Oil\r\nNeeded to keep your mechanized troops mobile.", 1);
        simpleList2.Add(10, 0, 17);
        simpleStringList.Add("Ammo\r\nNeeded to keep your army fighting. Build up reserves before starting a war.", 1);
        simpleList2.Add(2, 0);
        simpleStringList.Add("Met\r\nBase resource needed to build almost anything. Includes iron, copper and nickel.", 1);
        simpleList2.Add(8, 0, 22);
        simpleStringList.Add("IP\r\nKey to producing almost anything.", 1);
        simpleList2.Add(15, 0, 16);
        simpleStringList.Add("Energy\r\nSome assets require energy in-order to run. Energy can be produced in power plants.", 1);
        simpleList2.Add(4, 0);
        simpleStringList.Add("Radio\r\nSome models will require Radioactives for construction and/or ammunitions.", 1);
        simpleList2.Add(9, 0);
        simpleStringList.Add("Recruit\r\nIn order to raise new troops you need recruits.", 1);
        simpleList2.Add(12, 0);
        simpleStringList.Add("Colonist\r\nTo found a new city or increase populace of a zone you need colonists.", 1);
        simpleList2.Add(3, 0);
        simpleStringList.Add("Rare\r\nIncludes rare earth metals. For advanced production.", 1);
        simpleList2.Add(13, 0);
        simpleStringList.Add("Machine\r\nFor construction of advanced equipment and assets.", 1);
        simpleList2.Add(14, 0);
        simpleStringList.Add("Hi-Tech\r\nFor construction of very advanced equipment and assets.", 1);
        this.game.Data.FindEventPic("", 9, "SE_Present");
        this.game.Data.FindEventPic("", 8, "SE_Present");
        this.game.Data.FindEventPic("", 11, "SE_Present");
        int num134 = rectangle4.X + 5;
        int num135 = rectangle4.Y + 5;
        int height2 = 28;
        int num136 = num134;
        int x21 = num134 + 85;
        int num137 = 1;
        do
        {
          string tstring18;
          string tstring19;
          if (!flag1)
          {
            if (num137 == 1)
              tstring18 = "";
            if (num137 == 2)
            {
              tstring18 = "DELI";
              tstring19 = "SHQ";
            }
            if (num137 == 3)
              tstring18 = "";
            if (num137 == 4)
            {
              tstring18 = "CONS";
              tstring19 = "ZONE";
            }
            if (num137 == 5)
            {
              tstring18 = "PROD";
              tstring19 = "ZONE";
            }
            if (num137 == 6)
              tstring18 = "";
            if (num137 == 7)
            {
              tstring18 = "PICK";
              tstring19 = "SHQ";
            }
            if (num137 == 8)
            {
              tstring18 = "Inv.";
              tstring19 = "ZONE";
            }
          }
          else
          {
            if (num137 == 1)
            {
              tstring18 = "Inv.";
              tstring19 = "Shq";
            }
            if (num137 == 2)
            {
              tstring18 = "DELV";
              tstring19 = "SHQ";
            }
            if (num137 == 3)
            {
              tstring18 = "Inv.";
              tstring19 = "Zone";
            }
            if (num137 == 4)
            {
              tstring18 = "CONS";
              tstring19 = "ZONE";
            }
            if (num137 == 5)
            {
              tstring18 = "PROD";
              tstring19 = "ZONE";
            }
            if (num137 == 6)
            {
              tstring18 = "Inv.";
              tstring19 = "Zone";
            }
            if (num137 == 7)
            {
              tstring18 = "PICK";
              tstring19 = "SHQ";
            }
            if (num137 == 8)
            {
              tstring18 = "Next";
              tstring19 = "Shq";
            }
          }
          if (tstring18.Length > 1)
          {
            DrawMod.DrawTextColouredConsole(ref g, tstring19, this.game.MarcFont16, x21, num135 + 4, this.game.seColGray);
            DrawMod.DrawTextColouredConsole(ref g, tstring18, this.game.MarcFont16, x21, num135 + 20, this.game.seColGray);
          }
          x21 += 50;
          ++num137;
        }
        while (num137 <= 8);
        int y27 = num135 + (height2 + 16);
        int counter6 = simpleList2.Counter;
        for (int index17 = 0; index17 <= counter6; ++index17)
        {
          int x22 = num136;
          string data5 = this.game.Data.StringListObj[this.slotItemType].GetData(0, simpleList2.Id[index17], 2);
          string ttext1 = simpleStringList.Id[index17];
          ref Graphics local9 = ref g;
          Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.SE1_SIDEBAR_VARBOX_LONG);
          ref Bitmap local10 = ref bitmap1;
          int x23 = x22;
          int y28 = y27;
          DrawMod.DrawSimple(ref local9, ref local10, x23, y28);
          int eventPicSlotFor = this.game.EventRelatedObj.GetEventPicSlotFor(simpleList2.Id[index17], "", "");
          ref Graphics local11 = ref g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[eventPicSlotFor]);
          ref Bitmap local12 = ref bitmap2;
          int x24 = x22 + 2;
          int y29 = y27 + 6;
          DrawMod.DrawSimple(ref local11, ref local12, x24, y29);
          DrawMod.DrawTextColouredConsole(ref g, data5, this.game.MarcFont16, x22 + 31, y27 + 4, this.game.seColGray);
          rectangle10 = new Rectangle(x22, y27, 85, height2);
          Rectangle trect1 = rectangle10;
          this.AddMouse(ref trect1, data5, ttext1);
          int x25 = x22 + 85;
          int tdata1 = 1;
          do
          {
            string ttitle;
            if (!flag1)
            {
              if (tdata1 == 1)
                ttitle = "";
              if (tdata1 == 2)
                ttitle = "SHQ Delivery";
              if (tdata1 == 3)
                ttitle = "";
              if (tdata1 == 4)
                ttitle = "Consumption";
              if (tdata1 == 5)
                ttitle = "Production";
              if (tdata1 == 6)
                ttitle = "";
              if (tdata1 == 7)
                ttitle = "SHQ Pickup";
              if (tdata1 == 8)
                ttitle = "Start turn/Current Zone Reserves";
            }
            else
            {
              if (tdata1 == 1)
                ttitle = "Current SHQ Inventory";
              if (tdata1 == 2)
                ttitle = "Predicted SHQ delivery";
              if (tdata1 == 3)
                ttitle = "Predicted Zone Inventory after SHQ delivery";
              if (tdata1 == 4)
                ttitle = "Predicted Zone Consumption";
              if (tdata1 == 5)
                ttitle = "Predicted Zone Production";
              if (tdata1 == 6)
                ttitle = "Predicted Zone Inventory after Consumption & Production";
              if (tdata1 == 7)
                ttitle = "Predicted SHQ pickup of surplus Items at Zone";
              if (tdata1 == 8)
                ttitle = "Predicted SHQ Inventory at start of next turn";
            }
            bool flag2 = false;
            if (!flag1 & (tdata1 == 2 | tdata1 == 5 | tdata1 == 4 | tdata1 == 7 | tdata1 == 8))
              flag2 = true;
            if (flag1)
              flag2 = true;
            if (flag2)
            {
              str3 = "";
              int num138 = 0;
              int num139 = 0;
              string ttext2 = "";
              if (flag1)
              {
                int nr = this.PIL.FindNr(simpleList2.Id[index17], tdata1, se1AssetZone, tdata4: 1);
                if (nr > -1)
                {
                  num138 = this.PIL.Weight[nr];
                  num139 = this.PIL.Data3[nr];
                  int counter7 = this.PILdesc.Counter;
                  for (int index18 = 0; index18 <= counter7; ++index18)
                  {
                    if (this.PILdesc.Data1[index18] == tdata1 && this.PILdesc.Data2[index18] == se1AssetZone && this.PILdesc.Data3[index18] == simpleList2.Id[index17])
                      ttext2 = this.PILdesc.Id[index18];
                  }
                }
              }
              else if (!flag1)
              {
                int nr = this.IL.FindNr(simpleList2.Id[index17], tdata1, se1AssetZone, tdata4: 0);
                if (nr > -1)
                {
                  num138 = this.IL.Weight[nr];
                  num139 = this.IL.Data3[nr];
                  int counter8 = this.ILdesc.Counter;
                  for (int index19 = 0; index19 <= counter8; ++index19)
                  {
                    if (this.ILdesc.Data1[index19] == tdata1 && this.ILdesc.Data2[index19] == se1AssetZone && this.ILdesc.Data3[index19] == simpleList2.Id[index17])
                      ttext2 = this.ILdesc.Id[index19];
                  }
                }
              }
              string tstring20 = num138.ToString();
              if (num138 > 9999)
                tstring20 = Math.Round((double) num138 / 1000.0, 1).ToString() + "k";
              bool flag3 = false;
              if (tdata1 == 4 & this.game.EditObj.se1_assetItemMode1 == simpleList2.Id[index17])
                flag3 = true;
              if (tdata1 == 5 & this.game.EditObj.se1_assetItemMode2 == simpleList2.Id[index17])
                flag3 = true;
              if (flag3)
                DrawMod.DrawBlock(ref g, x25 - 3, y27 + 4, 46, height2 - 10, 100, (int) byte.MaxValue, 100, 100);
              Color c = this.game.seColGray;
              if (num139 > num138 & num139 > 0 & num138 > 0)
                c = this.game.seColYellow;
              else if (num139 > 0 & num138 < 1)
                c = this.game.seColRed;
              else if (num138 == 0)
                tstring20 = "-";
              DrawMod.DrawTextColouredConsole(ref g, tstring20, this.game.MarcFont16, x25, y27 + 4, c);
              if (tdata1 == 4 | tdata1 == 5)
              {
                if (flag3)
                {
                  string ttext3 = ttext2 + "\r\nYOU HAVE CURRENTLY SELECTED THIS ITEM.\r\nClick again or on other column than Prod+Cons to deselect.";
                  rectangle10 = new Rectangle(x25, y27, 50, height2);
                  Rectangle trect2 = rectangle10;
                  this.AddMouse(ref trect2, ttitle, ttext3, 120 + tdata1, simpleList2.Id[index17]);
                }
                else
                {
                  string ttext4 = ttext2 + "\r\nClick to view only Assets that are concerned.";
                  rectangle10 = new Rectangle(x25, y27, 50, height2);
                  Rectangle trect3 = rectangle10;
                  this.AddMouse(ref trect3, ttitle, ttext4, 120 + tdata1, simpleList2.Id[index17]);
                }
              }
              else if (ttext2.Length > 1)
              {
                rectangle10 = new Rectangle(x25, y27, 50, height2);
                Rectangle trect4 = rectangle10;
                this.AddMouse(ref trect4, ttitle, ttext2, 120);
              }
            }
            x25 += 50;
            ++tdata1;
          }
          while (tdata1 <= 8);
          y27 += height2;
        }
      }
      g.Dispose();
      g = (Graphics) null;
    }

    public override WindowReturnClass HandleKeyup(int nr)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          if (nr > 0 & this.okId > 0)
          {
            windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okId)] + 1, this.SubPartY[this.SubpartNr(this.okId)] + 1, 1);
            windowReturnClass.SetFlag(true);
          }
        }
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
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      WindowReturnClass windowReturnClass2 = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height & b == 1)
        {
          if (this.MouseData[index] == 120)
          {
            this.game.EditObj.se1_assetItemMode2 = 0;
            this.game.EditObj.se1_assetItemMode1 = 0;
            this.dostuff();
            windowReturnClass1.AddCommand(4, 67);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (this.MouseData[index] == 124)
          {
            this.game.EditObj.se1_assetItemMode2 = 0;
            if (this.game.EditObj.se1_assetItemMode1 == this.MouseData2[index])
              this.game.EditObj.se1_assetItemMode1 = 0;
            else
              this.game.EditObj.se1_assetItemMode1 = this.MouseData2[index];
            this.dostuff();
            windowReturnClass1.AddCommand(4, 67);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (this.MouseData[index] == 125)
          {
            this.game.EditObj.se1_assetItemMode1 = 0;
            if (this.game.EditObj.se1_assetItemMode2 == this.MouseData2[index])
              this.game.EditObj.se1_assetItemMode2 = 0;
            else
              this.game.EditObj.se1_assetItemMode2 = this.MouseData2[index];
            this.dostuff();
            windowReturnClass1.AddCommand(4, 67);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (this.MouseData[index] == 121)
          {
            if (this.game.EditObj.se1_SelectAssetButton == this.MouseData2[index])
            {
              this.game.EditObj.UDSpopupText = "";
              this.formref.Cursor = Cursors.WaitCursor;
              this.game.EditObj.UDSClearInput();
              this.game.EventRelatedObj.SetUDSKey("ASSETID", this.game.EditObj.se1_SelectAssetButton);
              this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 561, 0, 0));
              this.formref.Cursor = Cursors.Default;
              this.game.EditObj.PopupValue = 21;
              windowReturnClass1.AddCommand(5, 14);
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            this.game.EditObj.se1_SelectAssetButton = this.MouseData2[index];
            this.dostuff();
            windowReturnClass1.AddCommand(4, 67);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.RightId)
            {
              if (this.game.EditObj.se1_assetRightPanel == 1)
                this.game.EditObj.se1_assetRightPanel = 0;
              else
                this.game.EditObj.se1_assetRightPanel = 1;
              this.dostuff();
              windowReturnClass1.AddCommand(4, 67);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.PreviewId)
            {
              if (this.game.EditObj.se1_assetMode <= 1)
              {
                this.game.EditObj.se1_assetMode = 2;
                if (!this.previewSet)
                {
                  this.game.ProcessingObj.LIS_SetNetwork(false, true);
                  this.previewSet = true;
                }
                this.dostuff();
                windowReturnClass1.AddCommand(4, 67);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.StartTurnId)
            {
              if (this.game.EditObj.se1_assetMode > 1)
              {
                this.game.EditObj.se1_assetMode = 1;
                this.dostuff();
                windowReturnClass1.AddCommand(4, 67);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
            else
            {
              if (num1 == this.listId)
              {
                int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num2 <= -1)
                  return windowReturnClass1;
                this.game.EditObj.se1_assetSHQ = num2;
                this.ReCalculate();
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
              if (num1 == this.list2Id)
              {
                int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                if (num3 <= -1)
                  return windowReturnClass1;
                this.game.EditObj.se1_assetZone = num3;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
            }
            int assetButtonCounter = this.assetButtonCounter;
            for (int index2 = 0; index2 <= assetButtonCounter; ++index2)
            {
              if (this.assetButton[index2] == this.SubPartID[index1])
              {
                if (this.assetButtonData[index2] >= 51 & this.assetButtonData[index2] < 99)
                {
                  this.game.EditObj.se1_assetPage2 = this.assetButtonData[index2] - 50;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 11)
                {
                  this.game.EditObj.se1_AssetCategory1 = 1;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 12)
                {
                  this.game.EditObj.se1_AssetCategory1 = 2;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 13)
                {
                  if (this.game.EditObj.se1_AssetCategory2 == 1)
                    this.game.EditObj.se1_AssetCategory2 = 0;
                  else
                    this.game.EditObj.se1_AssetCategory2 = 1;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 14)
                {
                  if (this.game.EditObj.se1_AssetCategory2 == 2)
                    this.game.EditObj.se1_AssetCategory2 = 0;
                  else
                    this.game.EditObj.se1_AssetCategory2 = 2;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 15)
                {
                  if (this.game.EditObj.se1_AssetCategory2 == 3)
                    this.game.EditObj.se1_AssetCategory2 = 0;
                  else
                    this.game.EditObj.se1_AssetCategory2 = 3;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] > 160 & this.assetButtonData[index2] < 170)
                {
                  if (this.game.EditObj.se1_AssetCategory5 == this.assetButtonData[index2] - 160)
                    this.game.EditObj.se1_AssetCategory5 = 0;
                  else
                    this.game.EditObj.se1_AssetCategory5 = this.assetButtonData[index2] - 160;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 22)
                {
                  this.game.EditObj.UDSpopupText = "";
                  this.onPopupRefreshReCalc = true;
                  this.formref.Cursor = Cursors.WaitCursor;
                  this.game.EditObj.UDSClearInput();
                  this.game.EventRelatedObj.SetUDSKey("ASSETID", this.game.EditObj.se1_SelectAssetButton);
                  this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 569, 0, 0));
                  this.formref.Cursor = Cursors.Default;
                  this.game.EditObj.PopupValue = 21;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 21)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 21;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  if (this.orderfeedbackString.Length > 1)
                  {
                    this.game.EditObj.QuestionText = this.orderfeedbackString;
                    this.game.EditObj.AnswerCount = 1;
                    this.game.EditObj.AnswerText[1] = "OK";
                    this.game.EditObj.AnswerTextMouseOver[1] = "Click to continue";
                    DrawMod.TGame.EditObj.PopupValue = 10;
                    windowReturnClass1.AddCommand(5, 14);
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 23)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 23;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  if (this.orderfeedbackString.Length > 1)
                  {
                    this.game.EditObj.QuestionText = this.orderfeedbackString;
                    this.game.EditObj.AnswerCount = 1;
                    this.game.EditObj.AnswerText[1] = "OK";
                    this.game.EditObj.AnswerTextMouseOver[1] = "Click to continue";
                    DrawMod.TGame.EditObj.PopupValue = 10;
                    windowReturnClass1.AddCommand(5, 14);
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] >= 2000 & this.assetButtonData[index2] <= 2100)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = this.assetButtonData[index2];
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 24)
                {
                  this.game.EditObj.UDSpopupText = "";
                  this.formref.Cursor = Cursors.WaitCursor;
                  this.game.EditObj.UDSClearInput();
                  this.game.EventRelatedObj.SetUDSKey("ASSETID", this.game.EditObj.se1_SelectAssetButton);
                  this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 561, 0, 0));
                  this.formref.Cursor = Cursors.Default;
                  this.game.EditObj.PopupValue = 21;
                  windowReturnClass1.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 31)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 31;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 32)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 32;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index2] == 33)
                {
                  this.orderfeedbackString = "";
                  this.AssetOrderNumber = 33;
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

    public void PopUpRefresh()
    {
      if (this.onPopupRefreshReCalc)
        this.dostuff();
      this.onPopupRefreshReCalc = false;
    }
  }
}
