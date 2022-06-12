// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SpecialWindowClass5
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
  public class SpecialWindowClass5 : WindowClass
  {
    private ListClass ListObj;
    private ListClass List2Obj;
    private int listId;
    private int list2Id;
    private int useWidth;
    private int useHeight;
    private SimpleList listShq;
    private SimpleList listUnit;
    private SimpleList listUnitModel;
    private SimpleList listUnitReinf;
    private SimpleList listReinf;
    private SimpleList listModel;
    private SimpleList listModelType;
    private SimpleList listUnitTotal;
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
    private int[] itemweight;
    private string[] itemName;
    private int[] assetButton;
    private int assetButtonCounter;
    private int[] assetButtonData;
    private int opt1;
    private int but0id;
    private int but1id;
    private int but2id;
    private int but3id;
    private int but4id;
    private int but5id;

    public override void Dispose() => base.Dispose();

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      return base.HandleMouseMove(x, y);
    }

    public SpecialWindowClass5(ref GameClass tGame, int tUseWidth, int tUseHeight)
      : base(ref tGame, tUseWidth, tUseHeight, 8)
    {
      this.ListObj = new ListClass();
      this.List2Obj = new ListClass();
      this.itemweight = new int[100];
      this.itemName = new string[100];
      this.assetButton = new int[600];
      this.assetButtonCounter = -1;
      this.assetButtonData = new int[600];
      this.useWidth = tUseWidth;
      this.useHeight = tUseHeight;
      string libName = "SE_Data";
      this.slotItemType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 149, 0, 0));
      this.slotCharacter = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      this.slotRegKey = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      this.slotModel = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 228, 0, 0));
      this.slotModelStat = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 363, 0, 0));
      this.slotModelStatName = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 349, 0, 0));
      this.slotModelType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 225, 0, 0));
      this.slotQuality = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 299, 0, 0));
      this.slotChoice = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 232, 0, 0));
      this.slotModelTech = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 230, 0, 0));
      this.slotTechType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 190, 0, 0));
      int length = this.game.Data.StringListObj[this.slotItemType].Length;
      for (int index1 = 0; index1 <= length; ++index1)
      {
        int index2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotItemType].Data[index1, 0]));
        int num = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotItemType].Data[index1, 3]));
        this.itemweight[index2] = num;
        this.itemName[index2] = this.game.Data.StringListObj[this.slotItemType].Data[index1, 1];
      }
      this.assetButtonCounter = -1;
      this.ReCalculate();
      this.dostuff();
    }

    public void ReCalculate()
    {
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 381, 0, 0));
      int id = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      this.listShq = new SimpleList();
      this.listUnit = new SimpleList();
      this.listUnitModel = new SimpleList();
      this.listUnitReinf = new SimpleList();
      this.listReinf = new SimpleList();
      this.listModel = new SimpleList();
      this.listUnitTotal = new SimpleList();
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[index].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index].Historical].Type == 8)
        {
          this.listShq.Add(index, 0);
          this.listUnit.Add(index, 0, index);
          if (this.game.EditObj.se1_modelSHQ < 1)
            this.game.EditObj.se1_modelSHQ = index;
        }
      }
      int unitCounter2 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter2; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[index].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index].Historical].Type >= 5 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index].Historical].Type < 8)
        {
          int topHq = this.game.HandyFunctionsObj.GetTopHQ(index);
          if (this.listShq.FindNr(topHq) > -1)
            this.listUnit.Add(index, 0, topHq);
        }
      }
      SimpleList simpleList = new SimpleList();
      int unitCounter3 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter3; ++index)
      {
        if (this.game.Data.UnitObj[index].Regime == this.game.Data.Turn && this.game.Data.UnitObj[index].PreDef == -1 && this.game.Data.UnitObj[index].Historical > -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index].Historical].Type < 5 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[index].Historical].GiveHisVarValue(11) < 1)
        {
          int topHq = this.game.HandyFunctionsObj.GetTopHQ(index);
          if (this.listShq.FindNr(topHq) > -1)
          {
            int hq = this.game.Data.UnitObj[index].HQ;
            if (hq != topHq)
              simpleList.Add(index, 0, hq);
            else
              this.listUnit.Add(index, 0, topHq);
          }
        }
      }
      int counter1 = this.listUnit.Counter;
      int ratio;
      int qty;
      for (int index1 = 0; index1 <= counter1; ++index1)
      {
        int tid = this.listUnit.Id[index1];
        int sfCount = this.game.Data.UnitObj[tid].SFCount;
        for (int index2 = 0; index2 <= sfCount; ++index2)
        {
          int sf = this.game.Data.UnitObj[tid].SFList[index2];
          int type = this.game.Data.SFObj[sf].Type;
          ratio = this.game.Data.SFTypeObj[type].Ratio;
          int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
          qty = this.game.Data.SFObj[sf].Qty;
          int tdata1 = this.game.Data.SFTypeObj[type].SFTypeVar[81];
          if (reinforcementType > -1)
            this.listUnitReinf.AddWeight(tid, ratio * qty, reinforcementType, CheckData1Existence: true);
          if (tdata1 > 0)
            this.listUnitModel.AddWeight(tid, ratio * qty, tdata1, CheckData1Existence: true);
          this.listUnitTotal.AddWeight(tid, ratio * qty);
        }
      }
      int counter2 = simpleList.Counter;
      for (int index3 = 0; index3 <= counter2; ++index3)
      {
        int index4 = simpleList.Id[index3];
        int tid = simpleList.Data1[index3];
        int sfCount = this.game.Data.UnitObj[index4].SFCount;
        for (int index5 = 0; index5 <= sfCount; ++index5)
        {
          int sf = this.game.Data.UnitObj[index4].SFList[index5];
          int type = this.game.Data.SFObj[sf].Type;
          ratio = this.game.Data.SFTypeObj[type].Ratio;
          int reinforcementType = this.game.Data.SFTypeObj[type].ReinforcementType;
          qty = this.game.Data.SFObj[sf].Qty;
          int tdata1 = this.game.Data.SFTypeObj[type].SFTypeVar[81];
          if (reinforcementType > -1)
            this.listUnitReinf.AddWeight(tid, ratio * qty, reinforcementType, CheckData1Existence: true);
          if (tdata1 > 0)
            this.listUnitModel.AddWeight(tid, ratio * qty, tdata1, CheckData1Existence: true);
          this.listUnitTotal.AddWeight(tid, ratio * qty);
        }
      }
      int length = this.game.Data.StringListObj[this.slotModel].Length;
      for (int index = 0; index <= length; ++index)
      {
        if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].Data[index, 2])) == id)
        {
          int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].Data[index, 5]));
          if (num1 > 0 && this.game.EditObj.se1_modelObsoleteHidden == 0 | Conversions.ToInteger(this.game.Data.StringListObj[this.slotQuality].GetData2(0, num1, 1, id, 2)) != 1)
          {
            int tid = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].Data[index, 0]));
            int num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].Data[index, 1]));
            int reinforcementType = this.game.Data.SFTypeObj[this.game.HandyFunctionsObj.GetSFTypeByID(num1)].ReinforcementType;
            if (reinforcementType > -1)
              this.listReinf.AddWeight(reinforcementType, ratio * qty);
            if (tid > 0)
              this.listModel.AddWeight(tid, ratio * qty, reinforcementType);
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
      string libName = "SE_Data";
      this.slotItemType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 149, 0, 0));
      this.slotCharacter = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 196, 0, 0));
      this.slotRegKey = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      this.slotModel = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 228, 0, 0));
      this.slotModelType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 225, 0, 0));
      this.slotQuality = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 299, 0, 0));
      this.slotChoice = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 232, 0, 0));
      this.slotModelStat = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 363, 0, 0));
      this.slotModelStatBefore = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 229, 0, 0));
      this.slotModelTech = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 230, 0, 0));
      this.slotTechType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 190, 0, 0));
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 169, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 168, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0));
      int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
      int turn = this.game.Data.Turn;
      int idValue1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, id, 2)));
      int cultureGroupId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, idValue1, 1)));
      this.game.Data.StringListObj[stringListById1].SetData(0, "REGIMEID", 1, id);
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
      int tTop = -1;
      if (this.list2Id > 0)
      {
        tTop = this.SubPartList[this.SubpartNr(this.list2Id)].GetTopItem();
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
      if (this.but5id > 0)
      {
        this.RemoveSubPart(this.but5id);
        this.but5id = 0;
      }
      if (this.opt1 > 0)
      {
        this.RemoveSubPart(this.opt1);
        this.opt1 = 0;
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
      int height1 = (int) Math.Round((double) (this.useHeight - (100 + y1)) / 2.0);
      Rectangle rectangle1 = new Rectangle(0, y1, 220, this.useHeight);
      int width1 = rectangle1.Width;
      int y2 = y1;
      int width2 = this.useWidth - width1;
      int height2 = 50;
      Rectangle rectangle2 = new Rectangle(width1, y2, width2, height2);
      Rectangle rectangle3 = new Rectangle(rectangle2.Left, rectangle2.Top + rectangle2.Height, rectangle2.Width, height1);
      Rectangle rectangle4 = new Rectangle(rectangle3.X, rectangle3.Y + rectangle3.Height, rectangle3.Width, 50);
      Rectangle rectangle5 = new Rectangle(rectangle4.Left, rectangle4.Top + rectangle4.Height, rectangle4.Width, height1);
      Rectangle rectangle6 = new Rectangle(10, rectangle3.Top + 10, 210, rectangle3.Height - 30);
      Rectangle rectangle7 = new Rectangle(10, rectangle5.Top + 10, 210, rectangle5.Height - 30);
      DrawMod.DrawBlock(ref g, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, 0, 0, 0, 120);
      DrawMod.DrawBlock(ref g, rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height, 0, 0, 0, 160);
      DrawMod.DrawBlock(ref g, rectangle4.X, rectangle4.Y, rectangle4.Width, rectangle4.Height, 0, 0, 0, 160);
      DrawMod.DrawBlock(ref g, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, 0, 0, 0, 60);
      DrawMod.DrawBlock(ref g, rectangle5.X, rectangle5.Y, rectangle5.Width, rectangle5.Height, 0, 0, 0, 60);
      int left1 = rectangle6.Left;
      int num1 = rectangle6.Top - 40;
      SubPartClass tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, this.game.EditObj.se1_modelObsoleteHidden == 1, "Click to show or hide Obsolete Quality Level Models", ref this.BackBitmap, left1, num1);
      this.opt1 = this.AddSubPart(ref tsubpart1, left1, num1, 35, 35, 1);
      DrawMod.DrawTextColouredConsole(ref g, "Hide Obsolete", this.game.MarcFont4, left1 + 40, num1 + 8, this.game.seColWhite);
      this.ListObj = new ListClass();
      int left2 = rectangle7.Left;
      int num2 = rectangle7.Top + 10;
      int twidth = rectangle7.Width - 10;
      int tlistsize1 = (int) Math.Round(Math.Floor((double) rectangle7.Height / 20.0)) - 1;
      int tlistselect1 = -1;
      int num3 = 1 - 1;
      this.ListObj.add("All", -2);
      if (this.game.EditObj.se1_modelSHQ < 1)
        tlistselect1 = num3;
      int counter1 = this.listShq.Counter;
      for (int index = 0; index <= counter1; ++index)
      {
        ++num3;
        if (this.listShq.Id[index] == this.game.EditObj.se1_modelSHQ)
          tlistselect1 = num3;
        this.ListObj.add(this.game.Data.UnitObj[this.listShq.Id[index]].Name, this.listShq.Id[index]);
      }
      SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(this.ListObj, tlistsize1, twidth, tlistselect1, this.game, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: left2, bby: num2, tMarcStyle: true, overruleFont: (ref this.game.MarcFont7), overruleItemSize: 20);
      this.listId = this.AddSubPart(ref tsubpart2, left2, num2, twidth + 20, (tlistsize1 + 1) * 20, 1);
      this.List2Obj = new ListClass();
      int left3 = rectangle6.Left;
      int num4 = rectangle6.Top + 10;
      int num5 = rectangle6.Width - 10;
      int tlistsize2 = (int) Math.Round(Math.Floor((double) rectangle6.Height / 20.0)) - 1;
      int tlistselect2 = -1;
      int num6 = 1 - 1;
      this.List2Obj.add("All", -2);
      if (this.game.EditObj.se1_modelReinf < 0)
        tlistselect2 = num6;
      int counter2 = this.listReinf.Counter;
      for (int index = 0; index <= counter2; ++index)
      {
        ++num6;
        if (this.listReinf.Id[index] == this.game.EditObj.se1_modelReinf)
          tlistselect2 = num6;
        this.List2Obj.add(this.game.Data.ReinfName[this.listReinf.Id[index]], this.listReinf.Id[index]);
      }
      if (tTop < 1)
        tTop = 0;
      if (tTop == 0)
        tTop = -1;
      tsubpart2 = (SubPartClass) new ListSubPartClass(this.List2Obj, tlistsize2, num5, tlistselect2, this.game, tTop: tTop, tShowPair: true, tValueWidth: 70, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: left3, bby: num4, tMarcStyle: true, overruleFont: (ref this.game.MarcFont7), overruleItemSize: 20);
      this.list2Id = this.AddSubPart(ref tsubpart2, left3, num4, num5, (tlistsize2 + 1) * 20, 1);
      int x1 = rectangle2.Left + 10;
      int y3 = rectangle2.Top + 10;
      string str1 = this.game.EditObj.se1_modelReinf <= -1 ? "No Reinforcement Type selected" : "Models for Reinforcement Type '" + this.game.Data.ReinfName[this.game.EditObj.se1_modelReinf] + "'";
      DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont2, x1, y3, Color.White);
      SizeF sizeF2 = g.MeasureString(str1, this.game.MarcFont2);
      int x2 = (int) Math.Round((double) rectangle2.Left + (double) sizeF2.Width + 40.0);
      int num7 = 75;
      int y4 = rectangle2.Top + 3;
      tsubpart2 = (SubPartClass) new SEBigTextPartClass("Quality", "Change data viewed for Models", this.game.EditObj.se1_modelView == 0, num7, 44);
      this.but0id = this.AddSubPart(ref tsubpart2, x2, y4, num7, 44, 1);
      int x3 = x2 + 72;
      tsubpart2 = (SubPartClass) new SEBigTextPartClass("Prd.Cost", "Change data viewed for Models", this.game.EditObj.se1_modelView == 1, num7, 44);
      this.but1id = this.AddSubPart(ref tsubpart2, x3, y4, num7, 44, 1);
      int x4 = x3 + 72;
      tsubpart2 = (SubPartClass) new SEBigTextPartClass("Op.Cost", "Change data viewed for Models", this.game.EditObj.se1_modelView == 2, num7, 44);
      this.but2id = this.AddSubPart(ref tsubpart2, x4, y4, num7, 44, 1);
      int x5 = x4 + 72;
      tsubpart2 = (SubPartClass) new SEBigTextPartClass("Design", "Change data viewed for Models", this.game.EditObj.se1_modelView == 3, num7, 44);
      this.but3id = this.AddSubPart(ref tsubpart2, x5, y4, num7, 44, 1);
      if (this.game.EventRelatedObj.Helper_AirEnabled())
      {
        x5 += 72;
        tsubpart2 = (SubPartClass) new SEBigTextPartClass("Air.Des", "Change data viewed for Models", this.game.EditObj.se1_modelView == 5, num7, 44);
        this.but5id = this.AddSubPart(ref tsubpart2, x5, y4, num7, 44, 1);
      }
      int x6 = x5 + 72;
      tsubpart2 = (SubPartClass) new SEBigTextPartClass("Techs", "Change data viewed for Models", this.game.EditObj.se1_modelView == 4, num7, 44);
      this.but4id = this.AddSubPart(ref tsubpart2, x6, y4, num7, 44, 1);
      int left4 = rectangle3.Left;
      int top1 = rectangle3.Top;
      int num8 = 40 + (int) Math.Round((double) Math.Max(0, this.useHeight - 800) / 25.0);
      if (num8 > 80)
        num8 = 80;
      int width3 = rectangle3.Width;
      int num9 = (int) Math.Round(Math.Floor((double) (rectangle3.Height - 20) / (double) num8));
      int num10 = 0;
      int counter3 = this.listModel.Counter;
      for (int index = 0; index <= counter3; ++index)
      {
        if (this.listModel.Data1[index] == this.game.EditObj.se1_modelReinf | this.game.EditObj.se1_modelReinf < 0)
          ++num10;
      }
      int num11 = 1 + (int) Math.Round(Math.Floor((double) (num10 - 1) / (double) num9));
      if (num11 < this.game.EditObj.se1_modelPage)
        this.game.EditObj.se1_modelPage = num11;
      if (this.game.EditObj.se1_modelPage < 1)
        this.game.EditObj.se1_modelPage = 1;
      int num12 = (this.game.EditObj.se1_modelPage - 1) * num9 + 1;
      int num13 = (int) Math.Round(Math.Floor((double) (rectangle2.Width - (x6 + 76 - rectangle2.Left)) / (double) num11));
      if (num13 > 100)
        num13 = 100;
      int num14 = num13 - 4;
      int num15 = left4;
      int num16 = top1;
      int x7 = rectangle2.Right - (num14 + 4) * num11;
      int y5 = rectangle2.Top + 3;
      int num17 = num11;
      for (int index = 1; index <= num17; ++index)
      {
        ++this.assetButtonCounter;
        str1 = index.ToString() + "/" + num11.ToString() + ". Click to view this Models page.";
        if (this.game.EditObj.se1_modelPage == index)
          str1 = index.ToString() + "/" + num11.ToString() + ". Currently selected Models page";
        int[] assetButton = this.assetButton;
        int assetButtonCounter2 = this.assetButtonCounter;
        tsubpart2 = (SubPartClass) new SEBigTextPartClass(index.ToString(), str1, this.game.EditObj.se1_modelPage == index, num14, 44);
        int num18 = this.AddSubPart(ref tsubpart2, x7, y5, num14, 44, 1);
        assetButton[assetButtonCounter2] = num18;
        this.assetButtonData[this.assetButtonCounter] = 50 + index;
        x7 += num14 + 4;
      }
      int x1_1 = num15;
      int y1_1 = num16;
      DrawMod.DrawBlock(ref g, x1_1, y1_1, width3 - 10, 19, 168, 168, 168, 70);
      int num19 = y1_1 + 20;
      int num20 = 0;
      int num21 = 0;
      int num22 = num19;
      int counter4 = this.listModel.Counter;
      int num23;
      int num24;
      int tdata1;
      Rectangle trect1;
      Rectangle rectangle8;
      int index1;
      for (int index2 = 0; index2 <= counter4; ++index2)
      {
        if (this.listModel.Data1[index2] == this.game.EditObj.se1_modelReinf | this.game.EditObj.se1_modelReinf < 0)
        {
          ++num21;
          if (num21 >= num12 & num21 <= num12 - 1 + num9)
          {
            ++num20;
            int left5 = rectangle3.Left;
            if (this.listModel.Id[index2] != this.game.EditObj.se1_modelSelected)
              DrawMod.DrawBlock(ref g, left5, num19, width3 - 10, num8 - 1, 168, 168, 168, 140);
            else
              DrawMod.DrawBlock(ref g, left5, num19, width3 - 10, num8 - 1, 148, 218, 148, 140);
            int idValue2 = this.listModel.Id[index2];
            int x8 = left5 + 10;
            int sfTypeById = this.game.HandyFunctionsObj.GetSFTypeByID((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue2, 5))));
            Bitmap bitmap = this.game.CustomBitmapObj.DrawSFTypeGraphic(sfTypeById, false, cultureGroupId, this.game.Data.Turn, -1);
            if (bitmap.Width > 70)
            {
              num23 = (int) Math.Round((double) (bitmap.Height * 70) / (double) bitmap.Width);
              num24 = 70;
              tdata1 = (int) Math.Round((double) (num8 - num23) / 2.0);
              if (num23 > num8)
              {
                num24 = (int) Math.Round((double) (num24 * num8) / (double) num23);
                num23 = num8;
                tdata1 = 0;
              }
            }
            else if (bitmap.Height > num8)
            {
              num23 = num8;
              num24 = (int) Math.Round((double) (bitmap.Width * num8) / (double) bitmap.Height);
              tdata1 = 0;
            }
            else
            {
              num23 = bitmap.Height;
              num24 = bitmap.Width;
              tdata1 = (int) Math.Round((double) (num8 - bitmap.Height) / 2.0);
            }
            if (num20 == 1)
              DrawMod.DrawTextColouredMarc(ref g, "ICON", this.game.MarcFont5, x8, num19 - 16, Color.White);
            ref Graphics local1 = ref g;
            ref Bitmap local2 = ref bitmap;
            trect1 = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            Rectangle srcrect = trect1;
            rectangle8 = new Rectangle(x8 - 6, num19 + tdata1, num24, num23);
            Rectangle destrect = rectangle8;
            DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
            bitmap.Dispose();
            bitmap = (Bitmap) null;
            rectangle8 = new Rectangle(x8, num19, 70, num8);
            Rectangle trect2 = rectangle8;
            this.AddMouse(ref trect2, "", "Click to get more information on this Model", 20000000 + this.listModel.Id[index2]);
            int x9 = x8 + 70;
            if (this.game.EditObj.se1_modelView == 0)
            {
              rectangle8 = new Rectangle(x9, num19, 290, num8);
              Rectangle trect3 = rectangle8;
              this.AddMouse(ref trect3, "", "Click to select this row", 1000000 + this.listModel.Id[index2]);
              rectangle8 = new Rectangle(x9 + 360 + 360, num19, width3 - 720, num8);
              trect1 = rectangle8;
              this.AddMouse(ref trect1, "", "Click to select this row", 1000000 + this.listModel.Id[index2]);
            }
            else
            {
              rectangle8 = new Rectangle(x9, num19, width3 - 360, num8);
              trect1 = rectangle8;
              this.AddMouse(ref trect1, "", "Click to select this row", 1000000 + this.listModel.Id[index2]);
            }
            string data1 = this.game.Data.StringListObj[this.slotModel].GetData(0, idValue2, 3);
            SizeF sizeF3 = g.MeasureString(data1, this.game.MarcFont4);
            int num25 = (int) Math.Round(((double) num8 - (double) Math.Max(15f, sizeF3.Height)) / 2.0);
            if (num20 == 1)
              DrawMod.DrawTextColouredMarc(ref g, "MODEL", this.game.MarcFont5, x9, num19 - 16, Color.White);
            DrawMod.DrawTextColouredMarc(ref g, data1, this.game.MarcFont16, x9, num19 + num25 - 10, Color.White);
            int idValue3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue2, 1)));
            int idValue4 = idValue3;
            string data2 = this.game.Data.StringListObj[this.slotModelType].GetData(0, idValue3, 1);
            DrawMod.DrawTextColouredMarc(ref g, data2, this.game.MarcFont4, x9, num19 + num25 + 10, Color.White);
            int x10 = x9 + 160;
            if (this.game.EditObj.se1_modelView <= 2)
            {
              num24 = this.game.HandyFunctionsObj.GetSFTypeCombatValueScore(sfTypeById);
              string tstring = num24.ToString();
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "COMBAT", this.game.MarcFont5, x10, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont4, x10, num19 + num25, Color.White);
              int x11 = x10 + 60;
              num24 = this.game.HandyFunctionsObj.GetSFTypeProdCostScore(sfTypeById);
              str1 = num24.ToString();
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "COST", this.game.MarcFont5, x11, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x11, num19 + num25, Color.White);
              x10 = x11 + 60;
            }
            if (this.game.EditObj.se1_modelView == 0)
            {
              int integer = Conversions.ToInteger(this.game.Data.StringListObj[this.slotQuality].GetData2(0, this.game.Data.SFTypeObj[sfTypeById].Id, 1, id, 2));
              int num26 = 0;
              do
              {
                bool flag = false;
                if (integer == num26)
                  flag = true;
                string str2 = "";
                if (num26 == 0)
                {
                  str1 = "None";
                  str2 = str1;
                }
                if (num26 == 1)
                {
                  str1 = "Obsl.";
                  str2 = "Obsolete";
                }
                if (num26 == 2)
                {
                  str1 = "Low";
                  str2 = str1;
                }
                if (num26 == 3)
                {
                  str1 = "Reg.";
                  str2 = "Regular";
                }
                if (num26 == 4)
                {
                  str1 = "High";
                  str2 = str1;
                }
                if (num26 == 5)
                {
                  str1 = "Elite";
                  str2 = str1;
                }
                string upper = str2.ToUpper();
                if (num26 == 1 | num26 == 3 | num26 == 5)
                  DrawMod.DrawBlock(ref g, x10 - 5, num19, 60, num8 - 1, 0, 0, 0, 40);
                else
                  DrawMod.DrawBlock(ref g, x10 - 5, num19, 60, num8 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
                if (num20 == 1)
                  DrawMod.DrawTextColouredMarc(ref g, str1.ToUpper(), this.game.MarcFont5, x10, num19 - 16, Color.White);
                if (flag)
                {
                  DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont16, x10, num19 + num25, Color.White);
                  rectangle8 = new Rectangle(x10, num19, 60, num8);
                  trect1 = rectangle8;
                  this.AddMouse(ref trect1, "Current Quality Level: " + upper, "This is the current Quality Level assigned to this Model.");
                }
                else
                {
                  rectangle8 = new Rectangle(x10, num19, 60, num8);
                  trect1 = rectangle8;
                  this.AddMouse(ref trect1, "Change to Quality Level: " + upper, "Click to change the Model to this Quality Level.", 10000000 + num26 * 1000000 + this.listModel.Id[index2]);
                }
                x10 += 60;
                ++num26;
              }
              while (num26 <= 5);
              int idValue5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelType].GetData(0, idValue4, 4)));
              int idValue6 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelType].GetData(0, idValue4, 5)));
              int idValue7 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelType].GetData(0, idValue4, 15)));
              int idValue8 = 0;
              int idValue9 = 0;
              int idValue10 = 0;
              int idValue11 = 0;
              if (this.game.EventRelatedObj.Helper_AirEnabled())
              {
                idValue8 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelType].GetData(0, idValue4, 21)));
                idValue9 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelType].GetData(0, idValue4, 22)));
                idValue10 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelType].GetData(0, idValue4, 23)));
                idValue11 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelType].GetData(0, idValue4, 24)));
              }
              str1 = "";
              int num27 = 0;
              if (idValue5 > 0)
              {
                num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChoice].GetData(0, idValue5, 1)));
                if (num24 > 0 & !(num24 == 531 | num24 == 533 | num24 == 535))
                {
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, num24, 2)));
                  string data2_1 = this.game.Data.StringListObj[this.slotChoice].GetData2(1, num24, 2, num23, 3);
                  if (Operators.CompareString(data2_1, "None", false) != 0 & Strings.InStr(data2_1, "No ") < 1)
                  {
                    if (data2_1.Length > 0 & str1.Length > 0)
                    {
                      if (((Strings.InStr(str1, ",") > 0 ? 1 : 0) & 0) != 0)
                      {
                        str1 += ",\r\n";
                        num27 = 0;
                      }
                      else
                      {
                        str1 += ", ";
                        num27 = 1;
                      }
                    }
                    if (data2_1.Length > 0)
                      str1 += data2_1;
                  }
                }
              }
              if (idValue6 > 0)
              {
                num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChoice].GetData(0, idValue6, 1)));
                if (num24 > 0 & !(num24 == 531 | num24 == 533 | num24 == 535))
                {
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, num24, 2)));
                  string data2_2 = this.game.Data.StringListObj[this.slotChoice].GetData2(1, num24, 2, num23, 3);
                  if (Operators.CompareString(data2_2, "None", false) != 0 & Strings.InStr(data2_2, "No ") < 1)
                  {
                    if (data2_2.Length > 0 & str1.Length > 0)
                    {
                      if (((Strings.InStr(str1, ",") > 0 ? 1 : 0) & 0) != 0)
                      {
                        str1 += ",\r\n";
                        num27 = 0;
                      }
                      else
                      {
                        str1 += ", ";
                        num27 = 1;
                      }
                    }
                    if (data2_2.Length > 0)
                      str1 += data2_2;
                  }
                }
              }
              if (idValue7 > 0)
              {
                num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChoice].GetData(0, idValue7, 1)));
                if (num24 > 0 & !(num24 == 531 | num24 == 533 | num24 == 535))
                {
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, num24, 2)));
                  string data2_3 = this.game.Data.StringListObj[this.slotChoice].GetData2(1, num24, 2, num23, 3);
                  if (Operators.CompareString(data2_3, "None", false) != 0 & Strings.InStr(data2_3, "No ") < 1)
                  {
                    if (data2_3.Length > 0 & str1.Length > 0)
                    {
                      if (((Strings.InStr(str1, ",") > 0 ? 1 : 0) & 0) != 0)
                      {
                        str1 += ",\r\n";
                        num27 = 0;
                      }
                      else
                      {
                        str1 += ", ";
                        num27 = 1;
                      }
                    }
                    if (data2_3.Length > 0)
                      str1 += data2_3;
                  }
                }
              }
              if (idValue8 > 0)
              {
                num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChoice].GetData(0, idValue8, 1)));
                if (num24 > 0 & !(num24 == 531 | num24 == 533 | num24 == 535))
                {
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, num24, 2)));
                  string data2_4 = this.game.Data.StringListObj[this.slotChoice].GetData2(1, num24, 2, num23, 3);
                  if (Operators.CompareString(data2_4, "None", false) != 0 & Strings.InStr(data2_4, "No ") < 1)
                  {
                    if (data2_4.Length > 0 & str1.Length > 0)
                    {
                      if (((Strings.InStr(str1, ",") > 0 ? 1 : 0) & 0) != 0)
                      {
                        if (num27 > 0)
                        {
                          str1 += ",\r\n";
                          num27 = 0;
                        }
                        else
                        {
                          str1 += ", ";
                          num27 = 1;
                        }
                      }
                      else
                      {
                        str1 += ", ";
                        num27 = 1;
                      }
                    }
                    if (data2_4.Length > 0)
                      str1 += data2_4;
                  }
                }
              }
              if (idValue9 > 0)
              {
                num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChoice].GetData(0, idValue9, 1)));
                if (num24 > 0 & !(num24 == 531 | num24 == 533 | num24 == 535))
                {
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, num24, 2)));
                  string data2_5 = this.game.Data.StringListObj[this.slotChoice].GetData2(1, num24, 2, num23, 3);
                  if (Operators.CompareString(data2_5, "None", false) != 0 & Strings.InStr(data2_5, "No ") < 1)
                  {
                    if (data2_5.Length > 0 & str1.Length > 0)
                    {
                      if (((Strings.InStr(str1, ",") > 0 ? 1 : 0) & 0) != 0)
                      {
                        if (num27 > 0)
                        {
                          str1 += ",\r\n";
                          num27 = 0;
                        }
                        else
                        {
                          str1 += ", ";
                          num27 = 1;
                        }
                      }
                      else
                      {
                        str1 += ", ";
                        num27 = 1;
                      }
                    }
                    if (data2_5.Length > 0)
                      str1 += data2_5;
                  }
                }
              }
              if (idValue10 > 0)
              {
                num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChoice].GetData(0, idValue10, 1)));
                if (num24 > 0 & !(num24 == 531 | num24 == 533 | num24 == 535))
                {
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, num24, 2)));
                  string data2_6 = this.game.Data.StringListObj[this.slotChoice].GetData2(1, num24, 2, num23, 3);
                  if (Operators.CompareString(data2_6, "None", false) != 0 & Strings.InStr(data2_6, "No ") < 1)
                  {
                    if (data2_6.Length > 0 & str1.Length > 0)
                    {
                      if (((Strings.InStr(str1, ",") > 0 ? 1 : 0) & 0) != 0)
                      {
                        if (num27 > 0)
                        {
                          str1 += ",\r\n";
                          num27 = 0;
                        }
                        else
                        {
                          str1 += ", ";
                          num27 = 1;
                        }
                      }
                      else
                      {
                        str1 += ", ";
                        num27 = 1;
                      }
                    }
                    if (data2_6.Length > 0)
                      str1 += data2_6;
                  }
                }
              }
              if (idValue11 > 0)
              {
                num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChoice].GetData(0, idValue11, 1)));
                if (num24 > 0 & !(num24 == 531 | num24 == 533 | num24 == 535))
                {
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, num24, 2)));
                  string data2_7 = this.game.Data.StringListObj[this.slotChoice].GetData2(1, num24, 2, num23, 3);
                  if (Operators.CompareString(data2_7, "None", false) != 0 & Strings.InStr(data2_7, "No ") < 1)
                  {
                    int num28;
                    if (data2_7.Length > 0 & str1.Length > 0)
                    {
                      if (((Strings.InStr(str1, ",") > 0 ? 1 : 0) & 0) != 0)
                      {
                        if (num27 > 0)
                        {
                          str1 += ",\r\n";
                          num28 = 0;
                        }
                        else
                        {
                          str1 += ", ";
                          num28 = 1;
                        }
                      }
                      else
                      {
                        str1 += ", ";
                        num28 = 1;
                      }
                    }
                    if (data2_7.Length > 0)
                      str1 += data2_7;
                  }
                }
              }
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "VARIANTS", this.game.MarcFont5, x10, num19 - 16, Color.White);
              sizeF1 = g.MeasureString(str1, this.game.MarcFont4);
              if (str1.Length > 110)
              {
                if (Strings.InStr(str1, "\r\n") > 0)
                  DrawMod.DrawTextColouredConsoleMultiline(ref g, str1, this.game.marcFont17, x10, num19 + num25 - 17, Color.White, 300, num8);
                else
                  DrawMod.DrawTextColouredConsoleMultiline(ref g, str1, this.game.marcFont17, x10, num19 + num25 - 17, Color.White, 300, num8);
              }
              else if (Strings.InStr(str1, "\r\n") > 0)
                DrawMod.DrawTextColouredConsoleMultiline(ref g, str1, this.game.MarcFont4, x10, num19 + num25 - 17, Color.White, 300, num8);
              else
                DrawMod.DrawTextColouredConsoleMultiline(ref g, str1, this.game.MarcFont4, x10, num19 + num25 - 17, Color.White, 300, num8);
              x10 += 320;
              if (x10 + 80 < this.game.ScreenWidth - 20)
              {
                num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStatBefore].GetData2(0, idValue2, 1, 7, 2)));
                num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStatBefore].GetData2(0, idValue2, 1, 8, 2)));
                tdata1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue2, 4)));
                int num29 = 120 + tdata1 * 10;
                int num30 = 100 - (int) Math.Round((double) (100 * (num29 - num24)) / (double) (num29 - num23));
                if (num30 > 100)
                  num30 = 100;
                str1 = num30.ToString() + "%";
                if (num20 == 1)
                  DrawMod.DrawTextColouredMarc(ref g, "FIELD TEST", this.game.MarcFont5, x10, num19 - 16, Color.White);
                DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x10, num19 + num25, Color.White);
                x10 += 80;
              }
            }
            if (this.game.EditObj.se1_modelView == 1)
            {
              int num31 = 1;
              do
              {
                num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 400 + num31, 2)));
                DrawMod.DrawBlock(ref g, x10 - 5, num19, 100, num8 - 1, 0, 0, 0, 40);
                string tstring = "";
                if (num31 == 1)
                {
                  tstring = "Manpower";
                  num23 *= 100;
                }
                if (num31 == 2)
                  tstring = "Metal";
                if (num31 == 3)
                  tstring = "IP";
                if (num31 == 4)
                  tstring = "Machinery";
                if (num31 == 5)
                  tstring = "Hi-Tech Parts";
                if (num31 == 6)
                  tstring = "Radioactives";
                if (num31 == 7)
                  tstring = "Rare metals";
                str1 = num23.ToString();
                if (num23 <= 0)
                  str1 = "-";
                if (num20 == 1)
                  DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont5, x10, num19 - 16, Color.White);
                DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x10, num19 + num25, Color.White);
                x10 += 100;
                ++num31;
              }
              while (num31 <= 7);
            }
            double num32;
            if (this.game.EditObj.se1_modelView == 2)
            {
              int num33 = 1;
              do
              {
                int idValue2_1 = 0;
                if (num33 == 1 | num33 == 2 | num33 == 3)
                  DrawMod.DrawBlock(ref g, x10 - 5, num19, 100, num8 - 1, 0, 0, 0, 40);
                else if (num33 == 4 | num33 == 5 | num33 == 6)
                  DrawMod.DrawBlock(ref g, x10 - 5, num19, 100, num8 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
                string tstring = "";
                if (num33 == 1)
                {
                  tstring = "Move Oil";
                  idValue2_1 = 101;
                }
                if (num33 == 2)
                {
                  tstring = "Move Energy";
                  idValue2_1 = 102;
                }
                if (num33 == 3)
                {
                  tstring = "Move Radio.";
                  idValue2_1 = 103;
                }
                if (num33 == 4)
                {
                  tstring = "Combat Ammo";
                  idValue2_1 = 201;
                }
                if (num33 == 5)
                {
                  tstring = "Combat Energy";
                  idValue2_1 = 202;
                }
                if (num33 == 6)
                {
                  tstring = "Combat Radio.";
                  idValue2_1 = 203;
                }
                if (num33 == 7)
                {
                  tstring = "Upkeep Food";
                  idValue2_1 = 301;
                }
                if (num33 == 8)
                {
                  tstring = "Upkeep Energy";
                  idValue2_1 = 302;
                }
                num23 = 0;
                if (num33 == 1)
                {
                  num24 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[45];
                  if (num24 == 1)
                    num23 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[46];
                }
                else if (num33 == 2)
                {
                  num24 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[45];
                  if (num24 == 15)
                    num23 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[46];
                }
                else if (num33 == 3)
                {
                  num24 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[45];
                  if (num24 == 4)
                    num23 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[46];
                }
                else
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, idValue2_1, 2)));
                str1 = num23.ToString();
                if (num33 == 7 && this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[50] == 7 & this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[68] > 1)
                {
                  num32 = Math.Round((double) ((float) this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[51] / (float) this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[68]), 1);
                  str1 = num32.ToString();
                }
                if (num23 <= 0)
                  str1 = "-";
                if (num33 == 4 & num23 > 0 && this.game.Data.SFTypeObj[sfTypeById].Theater == 2)
                {
                  tdata1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 529, 2)));
                  str1 = str1 + "/" + tdata1.ToString();
                }
                if (num20 == 1)
                  DrawMod.DrawTextColouredMarc(ref g, tstring, this.game.MarcFont5, x10, num19 - 16, Color.White);
                DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x10, num19 + num25, Color.White);
                x10 += 100;
                ++num33;
              }
              while (num33 <= 8);
            }
            if (this.game.EditObj.se1_modelView == 5 && this.game.EventRelatedObj.Helper_AirEnabled())
            {
              DrawMod.DrawBlock(ref g, x10 - 5, num19, 80, num8 - 1, 0, 0, 0, 40);
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 504, 2)));
              string tstring1 = num23.ToString();
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring1 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "ENGINE.EFF", this.game.MarcFont5, x10, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring1, this.game.MarcFont4, x10, num19 + num25, Color.White);
              int x12 = x10 + 80;
              DrawMod.DrawBlock(ref g, x12 - 5, num19, 80, num8 - 1, 0, 0, 0, 40);
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 510, 2)));
              string tstring2 = num23.ToString() + "%";
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring2 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "HP:WGT RATIO", this.game.MarcFont5, x12, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring2, this.game.MarcFont4, x12, num19 + num25, Color.White);
              int x13 = x12 + 80;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 525, 2)));
              string tstring3 = num23.ToString();
              if (num23 <= 0)
                tstring3 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "FIREP.vs.AIR", this.game.MarcFont5, x13, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring3, this.game.MarcFont4, x13, num19 + num25, Color.White);
              int x14 = x13 + 80;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 536, 2)));
              tdata1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 517, 2)));
              string tstring4 = num23.ToString() + "kmh / \r\n" + tdata1.ToString() + "kmh";
              if (num23 <= 0 | tdata1 <= 0)
                tstring4 = "-";
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring4 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "TAKEOFF", this.game.MarcFont5, x14, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring4, this.game.MarcFont4, x14, num19 + num25 - 8, Color.White);
              int x15 = x14 + 80;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 516, 2)));
              string tstring5 = num23.ToString() + "kmh";
              if (num23 <= 0)
                tstring5 = "-";
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring5 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "MAX SPEED", this.game.MarcFont5, x15, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring5, this.game.MarcFont4, x15, num19 + num25, Color.White);
              int x16 = x15 + 80;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 509, 2)));
              string tstring6 = num23 < 50 ? "No, Aero:" + num23.ToString() : "Yes, Aero:" + num23.ToString();
              if (num23 <= 0)
                tstring6 = "-";
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring6 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "HYPERSONIC", this.game.MarcFont5, x16, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring6, this.game.MarcFont4, x16, num19 + num25, Color.White);
              int x17 = x16 + 100;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 520, 2)));
              string tstring7 = num23.ToString();
              if (num23 <= 0)
                tstring7 = "-";
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring7 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "OP.RANGE", this.game.MarcFont5, x17, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring7, this.game.MarcFont4, x17, num19 + num25, Color.White);
              int x18 = x17 + 60;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 502, 2)));
              string tstring8 = num23.ToString() + " kg";
              if (num23 >= 1000)
              {
                num32 = Math.Round((double) num23 / 1000.0, 1);
                tstring8 = num32.ToString() + " ton";
              }
              if (num23 <= 0)
                tstring8 = "-";
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring8 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "FUEL.CAP", this.game.MarcFont5, x18, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring8, this.game.MarcFont4, x18, num19 + num25, Color.White);
              int x19 = x18 + 80;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 503, 2)));
              string tstring9 = num23.ToString() + "kg";
              if (num23 >= 1000)
              {
                num32 = Math.Round((double) num23 / 1000.0, 1);
                tstring9 = num32.ToString() + " ton";
              }
              if (num23 <= 0)
                tstring9 = "-";
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring9 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "CARGO.CAP", this.game.MarcFont5, x19, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring9, this.game.MarcFont4, x19, num19 + num25, Color.White);
              int x20 = x19 + 80;
              DrawMod.DrawBlock(ref g, x20 - 5, num19, 80, num8 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
              num24 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[14] * this.game.Data.SFTypeObj[sfTypeById].Attacks;
              string tstring10 = num24.ToString();
              if (num24 <= 0)
                tstring10 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "AIR ATT LOW", this.game.MarcFont5, x20, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring10, this.game.MarcFont4, x20, num19 + num25, Color.White);
              int x21 = x20 + 80;
              DrawMod.DrawBlock(ref g, x21 - 5, num19, 80, num8 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
              num24 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[21] * this.game.Data.SFTypeObj[sfTypeById].Attacks;
              string tstring11 = num24.ToString();
              if (num24 <= 0)
                tstring11 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "AIR ATT HIGH", this.game.MarcFont5, x21, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring11, this.game.MarcFont4, x21, num19 + num25, Color.White);
              int x22 = x21 + 80;
              DrawMod.DrawBlock(ref g, x22 - 5, num19, 80, num8 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
              num24 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[13];
              string tstring12 = num24.ToString();
              if (num24 <= 0)
                tstring12 = "-";
              if (num24 <= 0)
                tstring12 = "-";
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring12 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "DOGFIGHT", this.game.MarcFont5, x22, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring12, this.game.MarcFont4, x22, num19 + num25, Color.White);
              int x23 = x22 + 80;
              DrawMod.DrawBlock(ref g, x23 - 5, num19, 80, num8 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
              num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 530, 2)));
              str1 = this.game.HandyFunctionsObj.GetRomanNumerical(num24);
              if (this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                str1 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "Min.Airbase", this.game.MarcFont5, x23, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x23, num19 + num25, Color.White);
              x10 = x23 + 80;
            }
            if (this.game.EditObj.se1_modelView == 3)
            {
              DrawMod.DrawBlock(ref g, x10 - 5, num19, 80, num8 - 1, 0, 0, 0, 40);
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 151, 2)));
              string tstring13 = num23.ToString();
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "STR.DESIGN", this.game.MarcFont5, x10, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring13, this.game.MarcFont4, x10, num19 + num25, Color.White);
              int x24 = x10 + 80;
              DrawMod.DrawBlock(ref g, x24 - 5, num19, 80, num8 - 1, 0, 0, 0, 40);
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStatBefore].GetData2(0, idValue2, 1, 8, 2)));
              string tstring14 = num23.ToString();
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "B.DESIGN", this.game.MarcFont5, x24, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring14, this.game.MarcFont4, x24, num19 + num25, Color.White);
              int x25 = x24 + 80;
              DrawMod.DrawBlock(ref g, x25 - 5, num19, 80, num8 - 1, 0, 0, 0, 40);
              num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 43, 2)));
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 25, 2)));
              string tstring15 = num23.ToString();
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "ENG.DESIGN", this.game.MarcFont5, x25, num19 - 16, Color.White);
              if (num24 < 1)
                tstring15 = "-";
              DrawMod.DrawTextColouredMarc(ref g, tstring15, this.game.MarcFont4, x25, num19 + num25, Color.White);
              int x26 = x25 + 80;
              DrawMod.DrawBlock(ref g, x26 - 5, num19, 80, num8 - 1, 0, 0, 0, 40);
              num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 41, 2)));
              tdata1 = 0;
              if (this.game.EventRelatedObj.Helper_AirEnabled())
                tdata1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 534, 2)));
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 27, 2)));
              string tstring16 = num23.ToString();
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "WEAP.DESIGN", this.game.MarcFont5, x26, num19 - 16, Color.White);
              if (num24 < 1 & tdata1 < 1)
                tstring16 = "-";
              DrawMod.DrawTextColouredMarc(ref g, tstring16, this.game.MarcFont4, x26, num19 + num25, Color.White);
              int x27 = x26 + 80;
              DrawMod.DrawBlock(ref g, x27 - 5, num19, 80, num8 - 1, 0, 0, 0, 40);
              num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 42, 2)));
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 26, 2)));
              string tstring17 = num23.ToString();
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "ARM.DESIGN", this.game.MarcFont5, x27, num19 - 16, Color.White);
              if (num24 < 1 & this.game.Data.SFTypeObj[sfTypeById].Theater < 2)
                tstring17 = "-";
              DrawMod.DrawTextColouredMarc(ref g, tstring17, this.game.MarcFont4, x27, num19 + num25, Color.White);
              int x28 = x27 + 80;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 2, 2)));
              string tstring18 = num23.ToString();
              if (num23 <= 0)
                tstring18 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "FIRE POWER", this.game.MarcFont5, x28, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring18, this.game.MarcFont4, x28, num19 + num25, Color.White);
              int x29 = x28 + 80;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 5, 2)));
              string tstring19 = num23.ToString();
              if (num23 <= 0)
                tstring19 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "WEIGHT", this.game.MarcFont5, x29, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring19, this.game.MarcFont4, x29, num19 + num25, Color.White);
              int x30 = x29 + 80;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 3, 2)));
              string tstring20 = num23.ToString();
              if (num23 <= 0)
                tstring20 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "ENG.POWER", this.game.MarcFont5, x30, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, tstring20, this.game.MarcFont4, x30, num19 + num25, Color.White);
              int x31 = x30 + 80;
              num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStat].GetData2(0, idValue2, 1, 4, 2)));
              str1 = num23.ToString();
              if (num23 <= 0)
                str1 = "-";
              if (num20 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "ARMOUR.STR.", this.game.MarcFont5, x31, num19 - 16, Color.White);
              DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x31, num19 + num25, Color.White);
              x10 = x31 + 80;
              if (x10 + 80 < x10 + width3)
              {
                num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStatBefore].GetData2(0, idValue2, 1, 7, 2)));
                num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelStatBefore].GetData2(0, idValue2, 1, 8, 2)));
                tdata1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue2, 4)));
                int num34 = 120 + tdata1 * 10;
                int num35 = 100 - (int) Math.Round((double) (100 * (num34 - num24)) / (double) (num34 - num23));
                if (num35 > 100)
                  num35 = 100;
                str1 = num35.ToString() + "%";
                if (num20 == 1)
                  DrawMod.DrawTextColouredMarc(ref g, "FIELD TEST", this.game.MarcFont5, x10, num19 - 16, Color.White);
                DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x10, num19 + num25, Color.White);
                x10 += 80;
              }
              if (x10 + 100 < this.game.ScreenWidth - 20)
              {
                DrawMod.DrawBlock(ref g, x10 - 5, num19, 100, num8 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
                num23 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[40];
                num24 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[34];
                str1 = "i" + num23.ToString() + " / " + num24.ToString();
                if (num23 <= 0 & num24 <= 0)
                  str1 = "-";
                if (num20 == 1)
                  DrawMod.DrawTextColouredMarc(ref g, "HIT POINTS", this.game.MarcFont5, x10, num19 - 16, Color.White);
                DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x10, num19 + num25, Color.White);
                x10 += 100;
              }
              int num36;
              if (x10 + 80 < this.game.ScreenWidth - 20)
              {
                DrawMod.DrawBlock(ref g, x10 - 5, num19, 80, num8 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
                num24 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[30] * this.game.Data.SFTypeObj[sfTypeById].Attacks;
                num23 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[31] * this.game.Data.SFTypeObj[sfTypeById].Attacks;
                str1 = num24.ToString() + "/" + num23.ToString();
                if (num24 > 9999 | num23 > 9999)
                {
                  index1 = (int) Math.Round((double) num24 / 1000.0);
                  string str3 = index1.ToString();
                  num36 = (int) Math.Round((double) num23 / 1000.0);
                  string str4 = num36.ToString();
                  str1 = str3 + "k/" + str4 + "k";
                }
                if (num23 <= 0 & num24 <= 0)
                  str1 = "-";
                if (num20 == 1)
                  DrawMod.DrawTextColouredMarc(ref g, "SOFT ATT", this.game.MarcFont5, x10, num19 - 16, Color.White);
                DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x10, num19 + num25, Color.White);
                x10 += 80;
              }
              if (x10 + 80 < this.game.ScreenWidth - 20)
              {
                DrawMod.DrawBlock(ref g, x10 - 5, num19, 80, num8 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
                num24 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[32] * this.game.Data.SFTypeObj[sfTypeById].Attacks;
                num23 = this.game.Data.SFTypeObj[sfTypeById].SFTypeVar[33] * this.game.Data.SFTypeObj[sfTypeById].Attacks;
                str1 = num24.ToString() + "/" + num23.ToString();
                if (num24 > 9999 | num23 > 9999)
                {
                  num36 = (int) Math.Round((double) num24 / 1000.0);
                  string str5 = num36.ToString();
                  index1 = (int) Math.Round((double) num23 / 1000.0);
                  string str6 = index1.ToString();
                  str1 = str5 + "k/" + str6 + "k";
                }
                if (num23 <= 0 & num24 <= 0)
                  str1 = "-";
                if (num20 == 1)
                  DrawMod.DrawTextColouredMarc(ref g, "HARD ATT", this.game.MarcFont5, x10, num19 - 16, Color.White);
                DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x10, num19 + num25, Color.White);
                x10 += 80;
              }
            }
            if (this.game.EditObj.se1_modelView == 4 & this.game.Data.StringListObj[this.slotModelTech].Width >= 4)
            {
              bool[] flagArray = new bool[16];
              int index3 = 1;
              do
              {
                int num37 = 0;
                int idValue12 = -1;
                int num38 = -1;
                int idValue13 = -1;
                int num39 = -1;
                int length = this.game.Data.StringListObj[this.slotModelTech].Length;
                for (tdata1 = 0; tdata1 <= length; ++tdata1)
                {
                  if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelTech].Data[tdata1, 0])) == idValue2)
                  {
                    ++num37;
                    if (num37 == index3)
                    {
                      idValue12 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelTech].Data[tdata1, 1]));
                      num38 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelTech].Data[tdata1, 2]));
                      idValue13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelTech].Data[tdata1, 3]));
                      num39 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModelTech].Data[tdata1, 4]));
                      break;
                    }
                  }
                }
                if (idValue12 > -1 & num38 > -1 & idValue13 > 0 & num39 > -1)
                {
                  tdata1 = (int) Math.Round((double) (this.game.ScreenWidth - 500) / 9.0);
                  if (x10 + tdata1 < this.game.ScreenWidth - 20)
                  {
                    int Length = (int) Math.Round((double) tdata1 / 10.0);
                    string str7 = this.game.Data.StringListObj[this.slotTechType].GetData(0, idValue12, 1);
                    if (str7.Length > Length)
                      str7 = Strings.Left(str7, Length);
                    int num40 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotTechType].GetData(0, idValue12, 2)));
                    string str8 = this.game.Data.StringListObj[this.slotModelStatName].GetData(0, idValue13, 1);
                    if (str8.Length > Length)
                      str8 = Strings.Left(str8, Length);
                    if (str7.Length > 0 & str8.Length > 0)
                    {
                      string str9 = "";
                      switch (num40)
                      {
                        case 1:
                          str9 = str7;
                          break;
                        case 2:
                          str9 = str7 + " [" + num38.ToString() + "]";
                          break;
                      }
                      str1 = str9 + "\r\n" + str8;
                      if (num39 > 0)
                        str1 = str1 + " +" + num39.ToString();
                      if (-(flagArray[index3] ? 1 : 0) == 0)
                      {
                        DrawMod.DrawTextColouredMarc(ref g, "TECH BONUS #" + index3.ToString(), this.game.MarcFont5, x10, num22 - 16, Color.White);
                        flagArray[index3] = true;
                      }
                      if (num38 < 1 | num39 < 1)
                        DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, x10, num19 + (int) Math.Round((double) num25 / 2.0), Color.LightGray);
                      else
                        DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont16, x10, num19 + (int) Math.Round((double) num25 / 2.0), Color.White);
                      x10 += tdata1;
                    }
                  }
                }
                ++index3;
              }
              while (index3 <= 15);
            }
            num19 += num8;
          }
        }
      }
      int x32 = rectangle4.Left + 10;
      int y6 = rectangle4.Top + 10;
      bool flag1 = false;
      bool flag2 = false;
      string str10;
      if (this.game.EditObj.se1_modelSelected > 0)
      {
        str10 = "Units TOE for selected Model '" + this.game.Data.StringListObj[this.slotModel].GetData(0, this.game.EditObj.se1_modelSelected, 3) + "'";
        flag2 = true;
      }
      else if (this.game.EditObj.se1_modelReinf > -1)
      {
        str10 = "Units TOE for selected Reinforcement Type '" + this.game.Data.ReinfName[this.game.EditObj.se1_modelReinf] + "'";
        flag1 = true;
      }
      else
      {
        str10 = "Units TOE for all Troops";
        flag1 = true;
      }
      DrawMod.DrawTextColouredMarc(ref g, str10, this.game.MarcFont2, x32, y6, Color.White);
      int left6 = rectangle5.Left;
      int top2 = rectangle5.Top;
      int height3 = 20 + (int) Math.Round((double) Math.Max(0, this.useHeight - 800) / 35.0);
      if (height3 > 40)
        height3 = 40;
      int width4 = rectangle5.Width;
      int num41 = (int) Math.Round(Math.Floor((double) (rectangle5.Height - 20) / (double) height3));
      int num42 = 0;
      int counter5 = this.listUnit.Counter;
      for (int index4 = 0; index4 <= counter5; ++index4)
      {
        if (this.listUnit.Data1[index4] == this.game.EditObj.se1_modelSHQ | this.game.EditObj.se1_modelSHQ <= 0)
          ++num42;
      }
      num11 = 1 + (int) Math.Round(Math.Floor((double) (num42 - 1) / (double) num41));
      if (num11 < this.game.EditObj.se1_modelPage2)
        this.game.EditObj.se1_modelPage2 = num11;
      if (this.game.EditObj.se1_modelPage2 < 1)
        this.game.EditObj.se1_modelPage2 = 1;
      int num43 = (this.game.EditObj.se1_modelPage2 - 1) * num41 + 1;
      num24 = (int) Math.Round(Math.Floor((double) (rectangle2.Width - 500) / (double) num11));
      if (num24 > 100)
        num24 = 100;
      int num44 = left6;
      int num45 = top2;
      int x33 = rectangle4.Right - (10 + (num24 + 4) * num11);
      int y7 = rectangle4.Top + 3;
      int num46 = num11;
      for (int index5 = 1; index5 <= num46; ++index5)
      {
        ++this.assetButtonCounter;
        str10 = index5.ToString() + "/" + num11.ToString() + ". Click to view this Units page.";
        if (this.game.EditObj.se1_modelPage2 == index5)
          str10 = index5.ToString() + "/" + num11.ToString() + ". Currently selected Units page";
        int[] assetButton = this.assetButton;
        int assetButtonCounter3 = this.assetButtonCounter;
        tsubpart2 = (SubPartClass) new SEBigTextPartClass(index5.ToString(), str10, this.game.EditObj.se1_modelPage2 == index5, num24, 44);
        int num47 = this.AddSubPart(ref tsubpart2, x33, y7, num24, 44, 1);
        assetButton[assetButtonCounter3] = num47;
        this.assetButtonData[this.assetButtonCounter] = 100 + index5;
        x33 += num24 + 4;
      }
      int x1_2 = num44;
      int y1_2 = num45;
      DrawMod.DrawBlock(ref g, x1_2, y1_2, width4 - 10, 19, 168, 168, 168, 70);
      int num48 = y1_2 + 20;
      int num49 = 0;
      int num50 = 0;
      int counter6 = this.listUnit.Counter;
      for (int index6 = 0; index6 <= counter6; ++index6)
      {
        if (this.listUnit.Data1[index6] == this.game.EditObj.se1_modelSHQ | this.game.EditObj.se1_modelSHQ < 1)
        {
          ++num50;
          if (num50 >= num43 & num50 <= num43 - 1 + num41)
          {
            ++num49;
            int left7 = rectangle5.Left;
            int tid = this.listUnit.Id[index6];
            int historical = this.game.Data.UnitObj[tid].Historical;
            if (this.game.Data.HistoricalUnitObj[historical].Type == 8)
              DrawMod.DrawBlock(ref g, left7, num48, width4 - 10, height3 - 1, 168, 168, 168, 140);
            else if (this.game.Data.HistoricalUnitObj[historical].Type >= 5)
              DrawMod.DrawBlock(ref g, left7, num48, width4 - 10, height3 - 1, 138, 138, 138, 120);
            else
              DrawMod.DrawBlock(ref g, left7, num48, width4 - 10, height3 - 1, 108, 108, 108, 120);
            int x34 = left7 + 10;
            string name = this.game.Data.UnitObj[tid].Name;
            SizeF sizeF4 = g.MeasureString(name, this.game.MarcFont4);
            int num51 = (int) Math.Round(((double) height3 - (double) Math.Max(15f, sizeF4.Height)) / 2.0);
            if (num49 == 1)
              DrawMod.DrawTextColouredMarc(ref g, "UNIT NAME", this.game.MarcFont5, x34, num48 - 16, Color.White);
            DrawMod.DrawTextColouredMarc(ref g, name, this.game.MarcFont4, x34, num48 + num51, Color.White);
            int x35 = x34 + 400;
            string tstring21 = Conversions.ToString(this.listUnitTotal.FindWeight(tid));
            if (num49 == 1)
              DrawMod.DrawTextColouredMarc(ref g, "TOE.TOT", this.game.MarcFont5, x35, num48 - 16, Color.White);
            DrawMod.DrawTextColouredMarc(ref g, tstring21, this.game.MarcFont4, x35, num48 + num51, Color.White);
            int x36 = x35 + 60;
            string tstring22;
            if (flag1)
            {
              tstring22 = this.game.EditObj.se1_modelReinf <= -1 ? Conversions.ToString(this.listUnitTotal.FindWeight(tid)) : Conversions.ToString(this.listUnitReinf.FindWeight(tid, this.game.EditObj.se1_modelReinf));
              if (num49 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "TOE.REINF", this.game.MarcFont5, x36, num48 - 16, Color.White);
            }
            else if (flag2)
            {
              tstring22 = Conversions.ToString(this.listUnitModel.FindWeight(tid, this.game.EditObj.se1_modelSelected));
              if (num49 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "TOE.MODEL", this.game.MarcFont5, x36, num48 - 16, Color.White);
            }
            else
              tstring22 = "";
            DrawMod.DrawTextColouredMarc(ref g, tstring22, this.game.MarcFont4, x36, num48 + num51, Color.White);
            int x37 = x36 + 80;
            int[] numArray1 = new int[7];
            int index7 = 0;
            do
            {
              numArray1[index7] = 0;
              ++index7;
            }
            while (index7 <= 6);
            int counter7 = this.listUnitModel.Counter;
            for (int index8 = 0; index8 <= counter7; ++index8)
            {
              if (this.listUnitModel.Id[index8] == tid)
              {
                num24 = this.listUnitModel.Data1[index8];
                if (flag2 & (num24 == this.game.EditObj.se1_modelSelected | this.game.EditObj.se1_modelSelected < 1))
                {
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, num24, 5)));
                  tdata1 = Conversions.ToInteger(this.game.Data.StringListObj[this.slotQuality].GetData2(0, num23, 1, id, 2));
                  int[] numArray2 = numArray1;
                  int[] numArray3 = numArray2;
                  index1 = tdata1;
                  int index9 = index1;
                  int num52 = numArray2[index1] + this.listUnitModel.Weight[index8];
                  numArray3[index9] = num52;
                }
                else if (flag1)
                {
                  num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, num24, 5)));
                  if (this.game.Data.SFTypeObj[this.game.HandyFunctionsObj.GetSFTypeByID(num23)].ReinforcementType == this.game.EditObj.se1_modelReinf | this.game.EditObj.se1_modelReinf == -1)
                  {
                    tdata1 = Conversions.ToInteger(this.game.Data.StringListObj[this.slotQuality].GetData2(0, num23, 1, id, 2));
                    int[] numArray4 = numArray1;
                    int[] numArray5 = numArray4;
                    index1 = tdata1;
                    int index10 = index1;
                    int num53 = numArray4[index1] + this.listUnitModel.Weight[index8];
                    numArray5[index10] = num53;
                  }
                }
              }
            }
            int index11 = 0;
            do
            {
              string str11 = "";
              if (index11 == 0)
              {
                str10 = "None";
                str11 = str10;
              }
              if (index11 == 1)
              {
                str10 = "Obsl.";
                str11 = "Obsolete";
              }
              if (index11 == 2)
              {
                str10 = "Low";
                str11 = str10;
              }
              if (index11 == 3)
              {
                str10 = "Reg.";
                str11 = "Regular";
              }
              if (index11 == 4)
              {
                str10 = "High";
                str11 = str10;
              }
              if (index11 == 5)
              {
                str10 = "Elite";
                str11 = str10;
              }
              int x38 = x37;
              string upper = str11.ToUpper();
              if (index11 == 1 | index11 == 3 | index11 == 5)
                DrawMod.DrawBlock(ref g, x37 - 5, num48, 80, height3 - 1, 0, 0, 0, 40);
              else
                DrawMod.DrawBlock(ref g, x37 - 5, num48, 80, height3 - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 40);
              int num54 = 0;
              if (index11 >= 2)
                num54 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tid].Historical].GiveHisVarValue(40 + index11);
              string tstring23 = "";
              string str12 = "";
              if (num54 == 0)
              {
                str12 = "Allow";
                tstring23 = "All.";
              }
              if (num54 == 1)
              {
                str12 = "Tolerate";
                tstring23 = "Tol.";
              }
              if (num54 == 10)
              {
                str12 = "Disallow";
                tstring23 = "Dis.";
              }
              if (num49 == 1)
                DrawMod.DrawTextColouredMarc(ref g, str10.ToUpper(), this.game.MarcFont5, x37, num48 - 16, Color.White);
              if (index11 < 2)
                tstring23 = "";
              if (this.game.Data.HistoricalUnitObj[historical].Type == 8)
                tstring23 = "";
              string str13 = numArray1[index11].ToString();
              SizeF sizeF5 = g.MeasureString(str13, this.game.MarcFont4);
              if (numArray1[index11] > 0)
                DrawMod.DrawTextColouredMarc(ref g, str13, this.game.MarcFont4, x38, num48 + num51, Color.White);
              else
                DrawMod.DrawTextColouredMarc(ref g, str13, this.game.MarcFont4, x38, num48 + num51, Color.Gray);
              int x39 = (int) Math.Round((double) ((float) x38 + sizeF5.Width));
              if (num54 == 0)
                DrawMod.DrawTextColouredMarc(ref g, tstring23, this.game.MarcFont16, x39, num48 + num51, Color.Green);
              if (num54 == 1)
                DrawMod.DrawTextColouredMarc(ref g, tstring23, this.game.MarcFont16, x39, num48 + num51, Color.Yellow);
              if (num54 == 10)
                DrawMod.DrawTextColouredMarc(ref g, tstring23, this.game.MarcFont16, x39, num48 + num51, Color.OrangeRed);
              if (tstring23.Length > 0)
              {
                rectangle8 = new Rectangle(x37, num48, 80, height3);
                trect1 = rectangle8;
                this.AddMouse(ref trect1, "Quality level '" + upper + "' is " + str12.ToUpper(), "Click to change setting", 20000000 + 1000000 * index11 + tid);
              }
              x37 += 80;
              ++index11;
            }
            while (index11 <= 5);
            int num55 = rectangle5.Right - 10 - x37;
            if (num55 >= 100)
            {
              if (num49 == 1)
                DrawMod.DrawTextColouredMarc(ref g, "PROMINENT MODELS", this.game.MarcFont5, x37, num48 - 16, Color.White);
              SimpleList simpleList = new SimpleList();
              int counter8 = this.listUnitModel.Counter;
              for (int index12 = 0; index12 <= counter8; ++index12)
              {
                if (this.listUnitModel.Id[index12] == tid)
                {
                  num24 = this.listUnitModel.Data1[index12];
                  if (flag2 & (num24 == this.game.EditObj.se1_modelSelected | this.game.EditObj.se1_modelSelected < 1))
                  {
                    num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, num24, 5)));
                    tdata1 = Conversions.ToInteger(this.game.Data.StringListObj[this.slotQuality].GetData2(0, num23, 1, id, 2));
                    simpleList.AddWeight(num23, this.listUnitModel.Weight[index12], tdata1);
                  }
                  else if (flag1)
                  {
                    num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, num24, 5)));
                    if (this.game.Data.SFTypeObj[this.game.HandyFunctionsObj.GetSFTypeByID(num23)].ReinforcementType == this.game.EditObj.se1_modelReinf | this.game.EditObj.se1_modelReinf == -1)
                    {
                      tdata1 = Conversions.ToInteger(this.game.Data.StringListObj[this.slotQuality].GetData2(0, num23, 1, id, 2));
                      simpleList.AddWeight(num23, this.listUnitModel.Weight[index12], tdata1);
                    }
                  }
                }
              }
              simpleList.ReverseSortHighSpeed();
              int counter9 = simpleList.Counter;
              for (int index13 = 0; index13 <= counter9; ++index13)
              {
                int num56 = simpleList.Weight[index13];
                int sfTypeById = this.game.HandyFunctionsObj.GetSFTypeByID(simpleList.Id[index13]);
                Bitmap bitmap = this.game.CustomBitmapObj.DrawSFTypeGraphic(sfTypeById, false, cultureGroupId, this.game.Data.Turn, -1);
                if (bitmap.Width > 50)
                {
                  num23 = (int) Math.Round((double) (bitmap.Height * 50) / (double) bitmap.Width);
                  num24 = 50;
                  tdata1 = (int) Math.Round((double) (height3 - num23) / 2.0);
                  if (num23 > height3)
                  {
                    num24 = (int) Math.Round((double) (num24 * height3) / (double) num23);
                    num23 = height3;
                    tdata1 = 0;
                  }
                }
                else if (bitmap.Height > height3)
                {
                  num23 = height3;
                  num24 = (int) Math.Round((double) (bitmap.Width * height3) / (double) bitmap.Height);
                  tdata1 = 0;
                }
                else
                {
                  num23 = bitmap.Height;
                  num24 = bitmap.Width;
                  tdata1 = (int) Math.Round((double) (height3 - bitmap.Height) / 2.0);
                }
                ref Graphics local3 = ref g;
                ref Bitmap local4 = ref bitmap;
                rectangle8 = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                Rectangle srcrect = rectangle8;
                trect1 = new Rectangle(x37 - 6, num48 + tdata1, num24, num23);
                Rectangle destrect = trect1;
                DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
                bitmap.Dispose();
                bitmap = (Bitmap) null;
                int x40 = x37;
                int x41 = x37 + (num24 - 10);
                string str14 = "x" + num56.ToString();
                SizeF sizeF6 = g.MeasureString(str14, this.game.MarcFont4);
                DrawMod.DrawTextColouredMarc(ref g, str14, this.game.MarcFont4, x41, num48 + num51, Color.White);
                x37 = (int) Math.Round((double) ((float) x41 + (sizeF6.Width + 5f)));
                num55 = (int) Math.Round((double) ((float) num55 - (float) ((double) num24 + (double) sizeF6.Width + 5.0)));
                rectangle8 = new Rectangle(x40, num48, x37 - x40, height3);
                trect1 = rectangle8;
                this.AddMouse(ref trect1, this.game.Data.SFTypeObj[sfTypeById].Name, "There are " + num56.ToString() + " of this model in this Unit.");
                if (num55 < 100)
                  break;
              }
            }
            num48 += height3;
          }
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
          if (this.MouseData[index1] > 22000000 & this.MouseData[index1] < 23000000)
          {
            int index2 = this.MouseData[index1] - 22000000;
            int historical1 = this.game.Data.UnitObj[index2].Historical;
            int num = this.game.Data.HistoricalUnitObj[historical1].GiveHisVarValue(42);
            switch (num)
            {
              case 0:
                num = 1;
                break;
              case 1:
                num = 10;
                break;
              case 10:
                num = 0;
                break;
            }
            this.game.Data.HistoricalUnitObj[historical1].SetHisVarValue(42, num);
            if (this.game.Data.HistoricalUnitObj[historical1].Type == 5)
            {
              int unitCounter = this.game.Data.UnitCounter;
              for (int index3 = 0; index3 <= unitCounter; ++index3)
              {
                if (this.game.Data.UnitObj[index3].HQ == index2)
                {
                  int historical2 = this.game.Data.UnitObj[index3].Historical;
                  if (historical2 > -1)
                    this.game.Data.HistoricalUnitObj[historical2].SetHisVarValue(42, num);
                }
              }
            }
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 23000000 & this.MouseData[index1] < 24000000)
          {
            int index4 = this.MouseData[index1] - 23000000;
            int historical3 = this.game.Data.UnitObj[index4].Historical;
            int num = this.game.Data.HistoricalUnitObj[historical3].GiveHisVarValue(43);
            switch (num)
            {
              case 0:
                num = 1;
                break;
              case 1:
                num = 10;
                break;
              case 10:
                num = 0;
                break;
            }
            this.game.Data.HistoricalUnitObj[historical3].SetHisVarValue(43, num);
            if (this.game.Data.HistoricalUnitObj[historical3].Type == 5)
            {
              int unitCounter = this.game.Data.UnitCounter;
              for (int index5 = 0; index5 <= unitCounter; ++index5)
              {
                if (this.game.Data.UnitObj[index5].HQ == index4)
                {
                  int historical4 = this.game.Data.UnitObj[index5].Historical;
                  if (historical4 > -1)
                    this.game.Data.HistoricalUnitObj[historical4].SetHisVarValue(43, num);
                }
              }
            }
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 24000000 & this.MouseData[index1] < 25000000)
          {
            int index6 = this.MouseData[index1] - 24000000;
            int historical5 = this.game.Data.UnitObj[index6].Historical;
            int num = this.game.Data.HistoricalUnitObj[historical5].GiveHisVarValue(44);
            switch (num)
            {
              case 0:
                num = 1;
                break;
              case 1:
                num = 10;
                break;
              case 10:
                num = 0;
                break;
            }
            this.game.Data.HistoricalUnitObj[historical5].SetHisVarValue(44, num);
            if (this.game.Data.HistoricalUnitObj[historical5].Type == 5)
            {
              int unitCounter = this.game.Data.UnitCounter;
              for (int index7 = 0; index7 <= unitCounter; ++index7)
              {
                if (this.game.Data.UnitObj[index7].HQ == index6)
                {
                  int historical6 = this.game.Data.UnitObj[index7].Historical;
                  if (historical6 > -1)
                    this.game.Data.HistoricalUnitObj[historical6].SetHisVarValue(44, num);
                }
              }
            }
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 25000000 & this.MouseData[index1] < 26000000)
          {
            int index8 = this.MouseData[index1] - 25000000;
            int historical7 = this.game.Data.UnitObj[index8].Historical;
            int num = this.game.Data.HistoricalUnitObj[historical7].GiveHisVarValue(45);
            switch (num)
            {
              case 0:
                num = 1;
                break;
              case 1:
                num = 10;
                break;
              case 10:
                num = 0;
                break;
            }
            this.game.Data.HistoricalUnitObj[historical7].SetHisVarValue(45, num);
            if (this.game.Data.HistoricalUnitObj[historical7].Type == 5)
            {
              int unitCounter = this.game.Data.UnitCounter;
              for (int index9 = 0; index9 <= unitCounter; ++index9)
              {
                if (this.game.Data.UnitObj[index9].HQ == index8)
                {
                  int historical8 = this.game.Data.UnitObj[index9].Historical;
                  if (historical8 > -1)
                    this.game.Data.HistoricalUnitObj[historical8].SetHisVarValue(45, num);
                }
              }
            }
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 1000000 & this.MouseData[index1] < 2000000)
          {
            if (this.game.EditObj.se1_modelSelected == this.MouseData[index1] - 1000000)
              this.game.EditObj.se1_modelSelected = -1;
            else
              this.game.EditObj.se1_modelSelected = this.MouseData[index1] - 1000000;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 10000000 & this.MouseData[index1] < 11000000)
          {
            int idValue = this.MouseData[index1] - 10000000;
            this.game.Data.StringListObj[this.slotQuality].SetData2(0, (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue, 5))), 1, id, 2, 0);
            this.game.EditObj.se1_modelSelected = idValue;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 11000000 & this.MouseData[index1] < 12000000)
          {
            int idValue = this.MouseData[index1] - 11000000;
            this.game.Data.StringListObj[this.slotQuality].SetData2(0, (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue, 5))), 1, id, 2, 1, true);
            this.game.EditObj.se1_modelSelected = idValue;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 12000000 & this.MouseData[index1] < 13000000)
          {
            int idValue = this.MouseData[index1] - 12000000;
            this.game.Data.StringListObj[this.slotQuality].SetData2(0, (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue, 5))), 1, id, 2, 2, true);
            this.game.EditObj.se1_modelSelected = idValue;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 13000000 & this.MouseData[index1] < 14000000)
          {
            int idValue = this.MouseData[index1] - 13000000;
            this.game.Data.StringListObj[this.slotQuality].SetData2(0, (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue, 5))), 1, id, 2, 3, true);
            this.game.EditObj.se1_modelSelected = idValue;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 14000000 & this.MouseData[index1] < 15000000)
          {
            int idValue = this.MouseData[index1] - 14000000;
            this.game.Data.StringListObj[this.slotQuality].SetData2(0, (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue, 5))), 1, id, 2, 4, true);
            this.game.EditObj.se1_modelSelected = idValue;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 15000000 & this.MouseData[index1] < 16000000)
          {
            int idValue = this.MouseData[index1] - 15000000;
            this.game.Data.StringListObj[this.slotQuality].SetData2(0, (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotModel].GetData(0, idValue, 5))), 1, id, 2, 5, true);
            this.game.EditObj.se1_modelSelected = idValue;
            this.dostuff();
            windowReturnClass1.SetFlag(true);
            windowReturnClass1.AddCommand(4, 67);
            return windowReturnClass1;
          }
          if (this.MouseData[index1] > 20000000 & this.MouseData[index1] < 21000000)
          {
            if (this.game.EditObj.se1_modelSelected != this.MouseData[index1] - 20000000)
              this.game.EditObj.se1_modelSelected = this.MouseData[index1] - 20000000;
            this.game.EditObj.UDSpopupText = "";
            this.formref.Cursor = Cursors.WaitCursor;
            this.game.EditObj.UDSClearInput();
            this.game.EventRelatedObj.SetUDSKey("MODELID", this.game.EditObj.se1_modelSelected);
            this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 564, 0, 0));
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
        for (int index10 = 0; index10 <= subPartCounter; ++index10)
        {
          if (x > this.SubPartX[index10] & x < this.SubPartX[index10] + this.SubPartW[index10] && y > this.SubPartY[index10] & y < this.SubPartY[index10] + this.SubPartH[index10])
          {
            int num1 = this.SubPartID[index10];
            if (num1 == this.opt1)
            {
              if (this.game.EditObj.se1_modelObsoleteHidden == 0)
                this.game.EditObj.se1_modelObsoleteHidden = 1;
              else
                this.game.EditObj.se1_modelObsoleteHidden = 0;
              this.SubPartFlag[index10] = true;
              this.ReCalculate();
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              windowReturnClass1.AddCommand(4, 67);
              return windowReturnClass1;
            }
            if (num1 == this.but0id)
            {
              if (this.game.EditObj.se1_modelView != 0)
              {
                this.game.EditObj.se1_modelView = 0;
                this.SubPartFlag[index10] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.but1id)
            {
              if (this.game.EditObj.se1_modelView != 1)
              {
                this.game.EditObj.se1_modelView = 1;
                this.SubPartFlag[index10] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.but2id)
            {
              if (this.game.EditObj.se1_modelView != 2)
              {
                this.game.EditObj.se1_modelView = 2;
                this.SubPartFlag[index10] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.but3id)
            {
              if (this.game.EditObj.se1_modelView != 3)
              {
                this.game.EditObj.se1_modelView = 3;
                this.SubPartFlag[index10] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.but4id)
            {
              if (this.game.EditObj.se1_modelView != 4)
              {
                this.game.EditObj.se1_modelView = 4;
                this.SubPartFlag[index10] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.but5id)
            {
              if (this.game.EditObj.se1_modelView != 5)
              {
                this.game.EditObj.se1_modelView = 5;
                this.SubPartFlag[index10] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
            }
            else
            {
              if (num1 == this.listId)
              {
                int num2 = this.SubPartList[index10].Click(x - this.SubPartX[index10], y - this.SubPartY[index10]);
                if (num2 > -1)
                {
                  this.SubPartFlag[index10] = true;
                  this.game.EditObj.se1_modelSHQ = num2;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass1.AddCommand(4, 67);
                  return windowReturnClass1;
                }
                if (num2 == -2)
                {
                  this.SubPartFlag[index10] = true;
                  this.game.EditObj.se1_modelSHQ = -1;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass1.AddCommand(4, 67);
                  return windowReturnClass1;
                }
                this.SubPartFlag[index10] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
              if (num1 == this.list2Id)
              {
                int num3 = this.SubPartList[index10].Click(x - this.SubPartX[index10], y - this.SubPartY[index10]);
                if (num3 > -1)
                {
                  this.SubPartFlag[index10] = true;
                  this.game.EditObj.se1_modelReinf = num3;
                  this.game.EditObj.se1_modelSelected = -1;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass1.AddCommand(4, 67);
                  return windowReturnClass1;
                }
                if (num3 == -2)
                {
                  this.SubPartFlag[index10] = true;
                  this.game.EditObj.se1_modelReinf = -1;
                  this.game.EditObj.se1_modelSelected = -1;
                  this.dostuff();
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass1.AddCommand(4, 67);
                  return windowReturnClass1;
                }
                this.SubPartFlag[index10] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                windowReturnClass1.AddCommand(4, 67);
                return windowReturnClass1;
              }
            }
            int assetButtonCounter = this.assetButtonCounter;
            for (int index11 = 0; index11 <= assetButtonCounter; ++index11)
            {
              if (this.assetButton[index11] == this.SubPartID[index10])
              {
                if (this.assetButtonData[index11] >= 51 & this.assetButtonData[index11] < 99)
                {
                  this.game.EditObj.se1_modelPage = this.assetButtonData[index11] - 50;
                  this.dostuff();
                  windowReturnClass1.AddCommand(4, 67);
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (this.assetButtonData[index11] >= 101 & this.assetButtonData[index11] < 149)
                {
                  this.game.EditObj.se1_modelPage2 = this.assetButtonData[index11] - 100;
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
