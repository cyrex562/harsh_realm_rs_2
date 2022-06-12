// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.NonCardSelectWindowClass
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
  public class NonCardSelectWindowClass : WindowClass
  {
    private int okid;
    private int ok2id;
    private int cancelid;
    private int cancel2id;
    private int resultMesOkId;
    private int oktextid;
    private int subId;
    private int quitId;
    private int deselectId;
    private int deselectid2;
    private int tMiniWidth;
    private int tMiniHeight;
    private int Pic1Id;
    private int FinalId;
    private int unitheaderid;
    private int unitsfid;
    private int mapid;
    private int tUnitSelected;
    private int tcx;
    private int tcy;
    private int tSelectX;
    private int tSelectY;
    private int tSelectMap;
    private int tCornerX;
    private int tCornerY;
    private SimpleList UL;
    private CoordList HL;
    private int OptionsListId;
    private int textAreaId;
    private ListClass OptionsListObj;
    private SelectUsageMode usageMode;
    private int targetUnitSelected;
    private bool subordinatesToo;
    private string resultString;

    public NonCardSelectWindowClass(ref GameClass tGame, SelectUsageMode tUsageMode)
      : base(ref tGame, 1280, 768, 8)
    {
      this.targetUnitSelected = -1;
      this.subordinatesToo = false;
      this.resultString = "";
      this.UL = new SimpleList();
      this.HL = new CoordList();
      this.subordinatesToo = true;
      this.usageMode = tUsageMode;
      if (tUsageMode == SelectUsageMode.selectHQ)
      {
        int unitCounter1 = this.game.Data.UnitCounter;
        for (int index = 0; index <= unitCounter1; ++index)
          this.game.Data.UnitObj[index].TempUnitSelectable = false;
        int unitSelected = this.game.EditObj.UnitSelected;
        int unitCounter2 = this.game.Data.UnitCounter;
        for (int unr = 0; unr <= unitCounter2; ++unr)
        {
          if (this.game.Data.UnitObj[unr].PreDef == -1 & this.game.Data.UnitObj[unr].X > -1 && unitSelected > -1 && unitSelected != unr & this.game.Data.UnitObj[unitSelected].HQ != unr & this.game.Data.UnitObj[unr].IsHQ & (this.game.Data.UnitObj[unr].Regime == this.game.Data.Turn | this.game.Data.UnitObj[unr].Regime == this.game.Data.UnitObj[unitSelected].Regime) && this.game.HandyFunctionsObj.CanUnitBecomeHQfor(unr, unitSelected))
          {
            int num = 0;
            if (this.game.Data.UnitObj[unitSelected].IsHQ)
              num = 1;
            if ((double) this.game.Data.RuleVar[304] == 0.0 | (double) (this.game.HandyFunctionsObj.HowmanyHQsAbove(unr) + this.game.HandyFunctionsObj.HowmanyHQsBelow(unitSelected) + 1 + num) <= (double) this.game.Data.RuleVar[304])
              this.game.Data.UnitObj[unr].TempUnitSelectable = true;
          }
        }
      }
      if (tUsageMode == SelectUsageMode.autoMove)
      {
        int unitSelected = this.game.EditObj.UnitSelected;
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int x = 0; x <= mapWidth; ++x)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int y = 0; y <= mapHeight; ++y)
          {
            this.game.Data.MapObj[0].HexObj[x, y].tempSelectable = false;
            if (this.game.Data.MapObj[0].HexObj[x, y].Regime == this.game.Data.Turn && this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[x, y].LandscapeType].AIBlock == 0)
            {
              this.game.Data.MapObj[0].HexObj[x, y].tempSelectable = true;
              this.HL.AddCoord(x, y, 0, 0, 0);
            }
          }
        }
      }
      if (tUsageMode == SelectUsageMode.blowBridge)
      {
        int unitSelected = this.game.EditObj.UnitSelected;
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
            this.game.Data.MapObj[0].HexObj[index1, index2].tempSelectable = false;
        }
        int num = 1;
        do
        {
          Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbourSameMap(this.game.Data.UnitObj[unitSelected].X, this.game.Data.UnitObj[unitSelected].Y, 0, num);
          if (coordinate.onmap && this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Bridge[num - 1] & this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].RiverType[num - 1] > -1)
          {
            this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].tempSelectable = true;
            this.HL.AddCoord(coordinate.x, coordinate.y, 0, num, 0);
          }
          ++num;
        }
        while (num <= 6);
      }
      if (tUsageMode == SelectUsageMode.repairBridge)
      {
        CoordList coordList = this.game.HandyFunctionsObj.InfraHexHighlight_getCoordList(this.game.SelectX, this.game.SelectY, 0, this.game.EditObj.UnitSelected);
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index3 = 0; index3 <= mapWidth; ++index3)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index4 = 0; index4 <= mapHeight; ++index4)
            this.game.Data.MapObj[0].HexObj[index3, index4].tempSelectable = false;
        }
        int counter = coordList.counter;
        for (int index = 0; index <= counter; ++index)
        {
          Coordinate coordinate = coordList.coord[index];
          if (coordinate.onmap)
          {
            int dat1 = this.game.HandyFunctionsObj.HexFacing(this.game.SelectX, this.game.SelectY, 0, coordinate.x, coordinate.y, 0);
            this.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].tempSelectable = true;
            this.HL.AddCoord(coordinate.x, coordinate.y, 0, dat1, 0);
          }
        }
      }
      if (this.usageMode != SelectUsageMode.none)
      {
        if (this.usageMode == SelectUsageMode.joinAttack)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int tid = 0; tid <= unitCounter; ++tid)
          {
            if (this.game.Data.UnitObj[tid].TempUnitSelectable)
              this.UL.Add(tid, 0);
          }
        }
        else if (this.usageMode == SelectUsageMode.selectHQ)
        {
          int unitCounter = this.game.Data.UnitCounter;
          for (int tid = 0; tid <= unitCounter; ++tid)
          {
            if (this.game.Data.UnitObj[tid].TempUnitSelectable)
              this.UL.Add(tid, 0);
          }
        }
      }
      this.tUnitSelected = this.game.EditObj.UnitSelected;
      if (!Information.IsNothing((object) this.game.EditObj.MiniMap))
      {
        this.tMiniWidth = this.game.EditObj.MiniMap.Width;
        this.tMiniHeight = this.game.EditObj.MiniMap.Height;
      }
      this.tSelectX = this.game.SelectX;
      this.tSelectY = this.game.SelectY;
      this.tCornerX = this.game.CornerX;
      this.tCornerY = this.game.CornerY;
      this.tSelectMap = this.game.EditObj.MapSelected;
      this.tcx = this.game.CornerX;
      this.tcy = this.game.CornerY;
      this.game.SelectX = this.game.EditObj.TargetX;
      this.game.SelectY = this.game.EditObj.TargetY;
      this.game.HandyFunctionsObj.CenterOnXY(this.game.SelectX, this.game.SelectY, useWidth: 939, useHeight: 538);
      if (!(this.usageMode == SelectUsageMode.blowBridge | this.usageMode == SelectUsageMode.repairBridge))
      {
        if (this.usageMode == SelectUsageMode.autoMove)
        {
          if (this.game.Data.UnitObj[this.tUnitSelected].autoMoveX > -1)
          {
            this.game.SelectX = this.game.Data.UnitObj[this.tUnitSelected].autoMoveX;
            this.game.SelectY = this.game.Data.UnitObj[this.tUnitSelected].autoMoveY;
          }
        }
        else if (this.usageMode == SelectUsageMode.joinAttack)
        {
          this.game.SelectX = this.game.EditObj.TargetX;
          this.game.SelectY = this.game.EditObj.TargetY;
        }
        else
        {
          this.game.SelectX = -1;
          this.game.SelectY = -1;
        }
      }
      this.game.EditObj.UnitSelected = -1;
      this.OptionsListObj = new ListClass();
      this.game.EditObj.TempCoordList = new CoordList();
      this.ViewMessage();
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

    public void ViewMessage()
    {
      if (this.Pic1Id > 0)
      {
        this.RemoveSubPart(this.Pic1Id);
        this.Pic1Id = 0;
      }
      if (this.okid > 0)
      {
        this.RemoveSubPart(this.okid);
        this.okid = 0;
      }
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      if (this.ok2id > 0)
      {
        this.RemoveSubPart(this.ok2id);
        this.ok2id = 0;
      }
      if (this.cancel2id > 0)
      {
        this.RemoveSubPart(this.cancel2id);
        this.cancel2id = 0;
      }
      if (this.quitId > 0)
      {
        this.RemoveSubPart(this.quitId);
        this.quitId = 0;
      }
      if (this.FinalId > 0)
      {
        this.RemoveSubPart(this.FinalId);
        this.FinalId = 0;
      }
      if (this.subId > 0)
      {
        this.RemoveSubPart(this.subId);
        this.subId = 0;
      }
      if (this.deselectId > 0)
      {
        this.RemoveSubPart(this.deselectId);
        this.deselectId = 0;
      }
      if (this.deselectid2 > 0)
      {
        this.RemoveSubPart(this.deselectid2);
        this.deselectid2 = 0;
      }
      if (this.resultMesOkId > 0)
      {
        this.RemoveSubPart(this.resultMesOkId);
        this.resultMesOkId = 0;
      }
      if (this.textAreaId > 0)
      {
        this.RemoveSubPart(this.textAreaId);
        this.textAreaId = 0;
      }
      this.ClearMouse();
      if (this.resultString.Length > 1)
      {
        Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
        this.NewBackGroundAndClearAll(1280, 768, -1);
        DrawMod.DrawMessFrame(ref this.OwnBitmap, ref g, 0, 0, 1280, 768);
        this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
        if (this.textAreaId < 1)
        {
          SubPartClass tsubpart = (SubPartClass) new TextAreaClass2(this.game, 1100, 26, this.game.MarcFont8, "[tab]result," + this.resultString + "[/tab]", 17, ref this.OwnBitmap, 100, 100);
          this.textAreaId = this.AddSubPart(ref tsubpart, 100, 100, 1100, 476, 0);
        }
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("OK", 180, "Click to acknowledge message and return to map.", ref this.OwnBitmap, 540, 600, theight: 60, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.resultMesOkId = this.AddSubPart(ref tsubpart1, 540, 600, 180, 60, 1);
        g.Dispose();
      }
      else
      {
        int num1 = 0;
        int num2 = this.usageMode == SelectUsageMode.blowBridge | this.usageMode == SelectUsageMode.repairBridge ? 1 : 0;
        if (this.mapid == 0)
        {
          SubPartClass tsubpart = (SubPartClass) new MapPartClass(947, 460 + num1, this.game, ZoomLevel: 0, tFromPopupMap: true);
          this.mapid = this.AddSubPart(ref tsubpart, 5, 60, 947, 460 + num1, 0);
        }
        Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
        this.NewBackGroundAndClearAll(1280, 768, -1);
        DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 1280, 768);
        if (this.usageMode == SelectUsageMode.joinAttack)
          DrawMod.DrawTextColouredMarc(ref graphics, "Select units to join in the planned attack.", this.game.MarcFont2, 30, 17, Color.White);
        else if (this.usageMode == SelectUsageMode.selectHQ)
          DrawMod.DrawTextColouredMarc(ref graphics, "Select HQ for " + this.game.Data.UnitObj[this.tUnitSelected].Name, this.game.MarcFont2, 30, 17, Color.White);
        else if (this.usageMode == SelectUsageMode.blowBridge)
          DrawMod.DrawTextColouredMarc(ref graphics, "Select Bridge to be blown by " + this.game.Data.UnitObj[this.tUnitSelected].Name, this.game.MarcFont2, 30, 17, Color.White);
        else if (this.usageMode == SelectUsageMode.repairBridge)
          DrawMod.DrawTextColouredMarc(ref graphics, "Select Bridge to be repaired by " + this.game.Data.UnitObj[this.tUnitSelected].Name, this.game.MarcFont2, 30, 17, Color.White);
        else if (this.usageMode == SelectUsageMode.autoMove)
        {
          if (this.game.Data.UnitObj[this.tUnitSelected].autoMoveX > -1)
            DrawMod.DrawTextColouredMarc(ref graphics, "Auto-move destination for " + this.game.Data.UnitObj[this.tUnitSelected].Name + " is " + this.game.Data.UnitObj[this.tUnitSelected].autoMoveX.ToString() + "," + this.game.Data.UnitObj[this.tUnitSelected].autoMoveY.ToString(), this.game.MarcFont2, 30, 17, Color.White);
          else
            DrawMod.DrawTextColouredMarc(ref graphics, "Select Auto-move destination for " + this.game.Data.UnitObj[this.tUnitSelected].Name, this.game.MarcFont2, 30, 17, Color.White);
        }
        SubPartClass tsubpart2;
        if (this.usageMode == SelectUsageMode.joinAttack)
        {
          if (this.UL.Counter <= -1)
          {
            DrawMod.DrawTextColouredMarc(ref graphics, "No units selectable.", this.game.MarcFont3, 970, 11, Color.White);
            DrawMod.DrawTextColouredMarc(ref graphics, "None selected.", this.game.MarcFont3, 970, 31, Color.White);
          }
          else
          {
            ref Graphics local1 = ref graphics;
            int num3 = this.UL.Counter + 1;
            string tstring1 = num3.ToString() + " units selectable.";
            Font marcFont3_1 = this.game.MarcFont3;
            Color white1 = Color.White;
            DrawMod.DrawTextColouredMarc(ref local1, tstring1, marcFont3_1, 970, 11, white1);
            ref Graphics local2 = ref graphics;
            num3 = this.game.EditObj.TempUnitList.counter + 1;
            string tstring2 = num3.ToString() + " selected.";
            Font marcFont3_2 = this.game.MarcFont3;
            Color white2 = Color.White;
            DrawMod.DrawTextColouredMarc(ref local2, tstring2, marcFont3_2, 970, 31, white2);
          }
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Back", 86, "Click to go back to the combat setup window [ESC].", ref this.BackBitmap, 1210, 11, theight: 43, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.quitId = this.AddSubPart(ref tsubpart3, 1160, 11, 86, 43, 1);
        }
        else if (this.usageMode == SelectUsageMode.selectHQ)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "Current HQ is:", this.game.MarcFont3, 970, 11, Color.White);
          DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.UnitObj[this.tUnitSelected].Name, this.game.MarcFont3, 970, 31, Color.White);
          tsubpart2 = (SubPartClass) new TextButtonPartClass("Cancel", 50, "Abort changing HQ [ESC]", ref this.BackBitmap, 1210, 5, theight: 50, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.quitId = this.AddSubPart(ref tsubpart2, 1210, 5, 50, 50, 1);
        }
        else if (this.usageMode == SelectUsageMode.blowBridge)
        {
          SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Cancel", 50, "Abort blowing bridge [ESC]", ref this.BackBitmap, 1210, 5, theight: 50, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.quitId = this.AddSubPart(ref tsubpart4, 1210, 5, 50, 50, 1);
        }
        else if (this.usageMode == SelectUsageMode.autoMove)
        {
          SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Cancel", 50, "Abort auto-move [ESC]", ref this.BackBitmap, 1210, 5, theight: 50, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.quitId = this.AddSubPart(ref tsubpart5, 1210, 5, 50, 50, 1);
        }
        else if (this.usageMode == SelectUsageMode.repairBridge)
        {
          SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Cancel", 50, "Abort repairing bridge [ESC]", ref this.BackBitmap, 1210, 5, theight: 50, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.quitId = this.AddSubPart(ref tsubpart6, 1210, 5, 50, 50, 1);
        }
        tsubpart2 = (SubPartClass) new MiniMapPartClass(DrawMod.TGame, tx: DrawMod.GetWidthForMiniMap(), ty: 200);
        this.Pic1Id = this.AddSubPart(ref tsubpart2, 957, 322, DrawMod.GetWidthForMiniMap(), 200, 0);
        if ((this.UL.Counter <= -1 | this.usageMode == SelectUsageMode.blowBridge | this.usageMode == SelectUsageMode.repairBridge) & this.usageMode != SelectUsageMode.autoMove)
        {
          if (this.usageMode == SelectUsageMode.blowBridge | this.usageMode == SelectUsageMode.repairBridge)
          {
            this.OptionsListObj = new ListClass();
            int num4 = -1;
            int tlistselect = -1;
            int counter = this.HL.counter;
            for (int index = 0; index <= counter; ++index)
            {
              int x = this.HL.coord[index].x;
              int y = this.HL.coord[index].y;
              int data1 = this.HL.coord[index].data1;
              ++num4;
              if (this.game.SelectX == x & this.game.SelectY == y)
                tlistselect = num4;
              this.OptionsListObj.add("Bridge towards " + x.ToString() + "," + y.ToString(), data1);
            }
            if (this.OptionsListId <= 0)
            {
              tsubpart2 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, 18, 292, tlistselect, this.game, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 956, bby: 55, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 20);
              this.OptionsListId = this.AddSubPart(ref tsubpart2, 956, 55, 292, 380, 0);
            }
            else
            {
              this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
              this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
              this.SubPartList[this.SubpartNr(this.OptionsListId)].Paint();
            }
          }
        }
        else if (this.usageMode == SelectUsageMode.autoMove)
        {
          this.OptionsListObj = new ListClass();
          int num5 = -1;
          int tlistselect = -1;
          int counter = this.HL.counter;
          for (int tdata = 0; tdata <= counter; ++tdata)
          {
            int x = this.HL.coord[tdata].x;
            int y = this.HL.coord[tdata].y;
            int data1 = this.HL.coord[tdata].data1;
            if (this.game.Data.MapObj[0].HexObj[x, y].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Type].cityLevel >= 3)
            {
              ++num5;
              if (this.game.SelectX == x & this.game.SelectY == y)
                tlistselect = num5;
              this.OptionsListObj.add(this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[x, y].Location].Name + " " + x.ToString() + "," + y.ToString(), tdata);
            }
          }
          if (this.OptionsListId <= 0)
          {
            tsubpart2 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, 18, 292, tlistselect, this.game, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 956, bby: 55, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 20);
            this.OptionsListId = this.AddSubPart(ref tsubpart2, 956, 55, 292, 380, 0);
          }
          else
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Paint();
          }
        }
        else
        {
          this.OptionsListObj = new ListClass();
          int num6 = -1;
          int tlistselect = -1;
          int counter = this.UL.Counter;
          for (int index1 = 0; index1 <= counter; ++index1)
          {
            int index2 = this.UL.Id[index1];
            ++num6;
            if (index2 == this.game.EditObj.UnitSelected)
              tlistselect = num6;
            int nr = this.game.SMALLCHAR1;
            if (this.game.EditObj.TempUnitList.CheckIfPresent(index2))
              nr = this.game.SMALLCHAR2;
            string name = this.game.Data.UnitObj[index2].Name;
            if (this.tUnitSelected > -1 && index2 == this.game.Data.UnitObj[this.tUnitSelected].HQ)
              name += " *";
            if (this.usageMode == SelectUsageMode.selectHQ)
              this.OptionsListObj.add(name, index2);
            else
              this.OptionsListObj.add(name, index2, tbmp: BitmapStore.GetBitmap(nr));
          }
          if (this.OptionsListId <= 0)
          {
            tsubpart2 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, 12, 292, tlistselect, this.game, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 956, bby: 55, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 20);
            this.OptionsListId = this.AddSubPart(ref tsubpart2, 956, 55, 292, 260, 0);
          }
          else
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Paint();
          }
        }
        if (this.usageMode == SelectUsageMode.joinAttack | this.usageMode == SelectUsageMode.selectHQ)
        {
          int screenWidth = this.game.ScreenWidth;
          this.game.ScreenWidth = 1280;
          PlayExtraWindowClass2 extraWindowClass2 = new PlayExtraWindowClass2(ref this.game, tcalledFromNonCardSelectWindow: true);
          extraWindowClass2.Paint();
          int mouseCounter = extraWindowClass2.MouseCounter;
          for (int index = 0; index <= mouseCounter; ++index)
          {
            Rectangle trect = extraWindowClass2.MouseRect[index];
            trect.X += 0;
            trect.Y += 419;
            extraWindowClass2.MouseText[index] = extraWindowClass2.MouseText[index].Replace("Click to get more information on these troops.", "");
            extraWindowClass2.MouseText[index] = extraWindowClass2.MouseText[index].Replace("Click to change name of unit", "");
            extraWindowClass2.MouseText[index] = extraWindowClass2.MouseText[index].Replace("Click to jump to its map location.", "");
            this.AddMouse(ref trect, extraWindowClass2.MouseTitle[index], extraWindowClass2.MouseText[index]);
          }
          this.game.ScreenWidth = screenWidth;
          DrawMod.DrawSimplePart2(ref graphics, ref extraWindowClass2.OwnBitmap, new Rectangle(10, 0, 1240, 222), new Rectangle(10, 529, 1240, 222));
          extraWindowClass2.Dispose();
        }
        if (this.game.EditObj.UnitSelected > -1 && this.usageMode == SelectUsageMode.selectHQ)
        {
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].TempUnitSelectable)
          {
            tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 100, "Click to select this Unit as the new HQ [SPACE].", ref this.OwnBitmap, 450, 627, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.FinalId = this.AddSubPart(ref tsubpart2, 450, 627, 100, 40, 1);
          }
          else
          {
            tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 100, "Unit is not a selectable HQ.", ref this.OwnBitmap, 450, 627, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.cancel2id = this.AddSubPart(ref tsubpart2, 450, 627, 100, 40, 0);
          }
        }
        if ((this.usageMode == SelectUsageMode.blowBridge | this.usageMode == SelectUsageMode.repairBridge) & this.game.SelectX > -1)
        {
          DrawMod.DrawTextColouredMarcCenter(ref graphics, "Selected Hex: " + this.game.SelectX.ToString() + "," + this.game.SelectY.ToString(), this.game.MarcFont3, 1106, 617, Color.White);
          if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].tempSelectable)
          {
            tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 180, "Click to select this Bridge [SPACE].", ref this.OwnBitmap, 1016, 657, theight: 60, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.FinalId = this.AddSubPart(ref tsubpart2, 1016, 657, 180, 60, 1);
          }
          else
          {
            tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 180, "Hex is not selectable.", ref this.OwnBitmap, 1016, 657, true, theight: 60, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.cancel2id = this.AddSubPart(ref tsubpart2, 1016, 657, 180, 60, 0);
          }
        }
        if (this.usageMode == SelectUsageMode.autoMove & this.game.SelectX > -1)
        {
          DrawMod.DrawTextColouredMarcCenter(ref graphics, "Selected Hex: " + this.game.SelectX.ToString() + "," + this.game.SelectY.ToString(), this.game.MarcFont3, 206, 617, Color.White);
          if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].tempSelectable)
          {
            tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 180, "Click to select this Hex as the target for Auto-move [SPACE].", ref this.OwnBitmap, 116, 657, theight: 60, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.FinalId = this.AddSubPart(ref tsubpart2, 116, 657, 180, 60, 1);
          }
          else
          {
            tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 180, "Hex is not selectable.", ref this.OwnBitmap, 116, 657, true, theight: 60, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.cancel2id = this.AddSubPart(ref tsubpart2, 116, 657, 180, 60, 0);
          }
          int index = -1;
          if (this.tUnitSelected > -1)
            index = !this.game.Data.UnitObj[this.tUnitSelected].IsHQ ? this.game.Data.UnitObj[this.tUnitSelected].HQ : this.tUnitSelected;
          DrawMod.DrawTextColouredMarc(ref graphics, "Include Subordinates", this.game.MarcFont3, 456, 617, Color.White);
          if (index > -1)
            DrawMod.DrawTextColouredMarc(ref graphics, "(All units of " + this.game.Data.UnitObj[index].Name + ")", this.game.MarcFont3, 456, 641, Color.White);
          tsubpart2 = (SubPartClass) new MarcRadioPartClass(0, this.subordinatesToo, "If subordinates are included changing (or cancelling) the target will apply to all non-HQ unit under command of selected HQ", ref this.OwnBitmap, 416, 611);
          this.subId = this.AddSubPart(ref tsubpart2, 416, 611, 35, 35, 1);
          DrawMod.DrawTextColouredMarcCenter(ref graphics, "Stop auto-move", this.game.MarcFont3, 1006, 617, Color.White);
          if (this.game.Data.UnitObj[this.tUnitSelected].autoMoveX > -1)
          {
            tsubpart2 = (SubPartClass) new TextButtonPartClass("STOP", 180, "Click to get unit out of auto-move mode.", ref this.OwnBitmap, 936, 657, theight: 60, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.deselectId = this.AddSubPart(ref tsubpart2, 936, 657, 180, 60, 1);
          }
          else
          {
            tsubpart2 = (SubPartClass) new TextButtonPartClass("STOP", 180, "Unit is not in auto-move mode.", ref this.OwnBitmap, 936, 657, true, theight: 60, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.deselectid2 = this.AddSubPart(ref tsubpart2, 936, 657, 180, 60, 0);
          }
        }
        if (this.game.EditObj.UnitSelected > -1)
        {
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].TempUnitSelectable)
          {
            if (this.usageMode == SelectUsageMode.joinAttack)
            {
              if (!this.game.EditObj.TempUnitList.CheckIfPresent(this.game.EditObj.UnitSelected))
              {
                tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 200, "Click to select [SPACE].", ref this.OwnBitmap, 330, 590, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
                this.okid = this.AddSubPart(ref tsubpart2, 330, 590, 200, 40, 1);
                tsubpart2 = (SubPartClass) new TextButtonPartClass("DESELECT", 200, "Unit is not selected.", ref this.OwnBitmap, 330, 650, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
                this.cancel2id = this.AddSubPart(ref tsubpart2, 330, 650, 200, 40, 0);
              }
              else
              {
                tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 200, "This unit is already selected.", ref this.OwnBitmap, 330, 590, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
                this.ok2id = this.AddSubPart(ref tsubpart2, 330, 590, 200, 40, 0);
                tsubpart2 = (SubPartClass) new TextButtonPartClass("DESELECT", 200, "Click to deselect this unit. [SPACE]", ref this.OwnBitmap, 330, 650, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
                this.cancelid = this.AddSubPart(ref tsubpart2, 330, 650, 200, 40, 1);
              }
            }
            else if (this.usageMode == SelectUsageMode.selectHQ & this.UL.Counter > -1)
            {
              tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 100, "HQ is already selected.", ref this.OwnBitmap, 450, 627, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              this.ok2id = this.AddSubPart(ref tsubpart2, 450, 627, 100, 40, 0);
              tsubpart2 = (SubPartClass) new TextButtonPartClass("DESELECT", 100, "HQ is already selected.", ref this.OwnBitmap, 560, 627, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              this.cancel2id = this.AddSubPart(ref tsubpart2, 560, 627, 100, 40, 0);
            }
          }
          else if (this.usageMode != SelectUsageMode.autoMove)
          {
            tsubpart2 = (SubPartClass) new TextButtonPartClass("SELECT", 200, "This unit is already selected.", ref this.OwnBitmap, 330, 590, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.ok2id = this.AddSubPart(ref tsubpart2, 330, 590, 200, 40, 0);
            tsubpart2 = (SubPartClass) new TextButtonPartClass("DESELECT", 200, "Unit is not selected.", ref this.OwnBitmap, 330, 650, true, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
            this.cancel2id = this.AddSubPart(ref tsubpart2, 330, 650, 200, 40, 0);
          }
        }
        graphics.Dispose();
        graphics = (Graphics) null;
      }
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.Pic1Id)
            {
              int selectX = this.game.SelectX;
              int selectY = this.game.SelectY;
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.game.EditObj.TempCoordList = new CoordList();
              this.SubPartList[this.SubpartNr(this.mapid)].Paint();
              this.ViewMessage();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              int index2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (index2 > -1)
              {
                this.SubpartNr(this.mapid);
                int index3;
                if (this.usageMode == SelectUsageMode.autoMove)
                {
                  this.game.SelectX = this.HL.coord[index2].x;
                  this.game.SelectY = this.HL.coord[index2].y;
                }
                else if (this.usageMode == SelectUsageMode.repairBridge | this.usageMode == SelectUsageMode.blowBridge)
                {
                  int counter = this.HL.counter;
                  for (int index4 = 0; index4 <= counter; ++index4)
                  {
                    if (this.HL.coord[index4].data1 == index2)
                    {
                      this.game.SelectX = this.HL.coord[index4].x;
                      this.game.SelectY = this.HL.coord[index4].y;
                    }
                  }
                }
                else
                {
                  index3 = index2;
                  this.game.SelectX = this.game.Data.UnitObj[index3].X;
                  this.game.SelectY = this.game.Data.UnitObj[index3].Y;
                }
                int zoom = this.game.EditObj.Zoom;
                this.game.EditObj.Zoom = 0;
                this.game.HandyFunctionsObj.CenterOnXY(this.game.SelectX, this.game.SelectY, useWidth: 939, useHeight: 538);
                this.game.EditObj.Zoom = zoom;
                if (this.game.EditObj.UnitSelected != index3)
                  this.game.EditObj.SFSelected = -1;
                this.game.EditObj.UnitSelected = index3;
                this.SubPartList[this.SubpartNr(this.mapid)].Paint();
                this.ViewMessage();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.mapid)
            {
              int selectX = this.game.SelectX;
              int selectY = this.game.SelectY;
              Coordinate coordinate = this.SubPartList[index1].ClickMap(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (coordinate.onmap)
              {
                this.game.SelectX = coordinate.x;
                this.game.SelectY = coordinate.y;
                this.game.EditObj.TempCoordList = new CoordList();
                int num2 = !(selectX == this.game.SelectX & selectY == this.game.SelectY) ? this.game.HandyFunctionsObj.ClickOnHexGivesUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, true, b, coordinate.data1, coordinate.penalty, true) : this.game.HandyFunctionsObj.ClickOnHexGivesUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, false, b, coordinate.data1, coordinate.penalty, true);
                if (this.game.EditObj.UnitSelected != num2)
                  this.game.EditObj.SFSelected = -1;
                this.game.EditObj.UnitSelected = num2;
                this.SubPartList[this.SubpartNr(this.mapid)].Paint();
                this.ViewMessage();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.deselectId)
            {
              this.game.ProcessingObj.AutoMoveChange(this.tUnitSelected, false, this.subordinatesToo, -1, -1);
              this.game.EditObj.AreaX = -1;
              this.game.EditObj.AreaY = -1;
              this.game.EditObj.DoCardSlot = -1;
              this.game.CornerX = this.tCornerX;
              this.game.CornerY = this.tCornerY;
              this.game.SelectX = this.tSelectX;
              this.game.SelectY = this.tSelectY;
              this.game.EditObj.UnitSelected = this.tUnitSelected;
              this.game.EditObj.MapSelected = this.tSelectMap;
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.AreaSlot = -1;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index5 = 0; index5 <= unitCounter; ++index5)
                this.game.Data.UnitObj[index5].TempUnitSelectable = false;
              this.game.EditObj.UnitSelected = this.tUnitSelected;
              DrawMod.GetWidthForMiniMap();
              this.game.EditObj.MiniMap = (Bitmap) null;
              MiniMapPartClass miniMapPartClass = new MiniMapPartClass(DrawMod.TGame, tx: this.tMiniWidth, ty: this.tMiniHeight);
              this.game.HandyFunctionsObj.RedimTempValue(9999);
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.FinalId)
            {
              this.targetUnitSelected = this.game.EditObj.UnitSelected;
              this.resultString = "";
              if (this.usageMode == SelectUsageMode.selectHQ)
                this.game.ProcessingObj.SetUnitHq(this.tUnitSelected, this.targetUnitSelected);
              if (this.usageMode == SelectUsageMode.autoMove)
                this.resultString = this.game.ProcessingObj.AutoMoveChange(this.tUnitSelected, true, this.subordinatesToo, this.game.SelectX, this.game.SelectY);
              if (this.usageMode == SelectUsageMode.blowBridge)
              {
                int slot = this.HL.FindSlot(this.game.SelectX, this.game.SelectY, 0);
                this.game.EditObj.UnitSelected = this.tUnitSelected;
                this.game.EditObj.form3windowClass.form3_orderResult = this.game.ProcessingObj.BlowBridge(this.tUnitSelected, this.tSelectX, this.tSelectY, 0, this.HL.coord[slot].data1 - 1);
                this.game.EditObj.form3windowClass.form3_returnInstruction = true;
                this.game.EditObj.form3windowClass.form3_data1 = 35;
              }
              if (this.usageMode == SelectUsageMode.repairBridge)
              {
                int slot = this.HL.FindSlot(this.game.SelectX, this.game.SelectY, 0);
                this.game.EditObj.UnitSelected = this.tUnitSelected;
                this.game.EditObj.form3windowClass.form3_orderResult = this.game.ProcessingObj.BuildInfra(this.game.EditObj.UnitSelected, this.tSelectX, this.tSelectY, 0, this.HL.coord[slot].data1 - 1);
                this.game.EditObj.form3windowClass.form3_returnInstruction = true;
                this.game.EditObj.form3windowClass.form3_data1 = 36;
              }
              if (this.resultString.Length > 1)
              {
                if (this.OptionsListId > 0)
                {
                  this.RemoveSubPart(this.OptionsListId);
                  this.OptionsListId = 0;
                }
                if (this.mapid > 0)
                {
                  this.RemoveSubPart(this.mapid);
                  this.mapid = 0;
                }
                if (this.Pic1Id > 0)
                {
                  this.RemoveSubPart(this.Pic1Id);
                  this.Pic1Id = 0;
                }
                this.ViewMessage();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.game.EditObj.AreaX = -1;
              this.game.EditObj.AreaY = -1;
              this.game.EditObj.DoCardSlot = -1;
              this.game.CornerX = this.tCornerX;
              this.game.CornerY = this.tCornerY;
              this.game.SelectX = this.tSelectX;
              this.game.SelectY = this.tSelectY;
              this.game.EditObj.UnitSelected = this.tUnitSelected;
              this.game.EditObj.MapSelected = this.tSelectMap;
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.AreaSlot = -1;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index6 = 0; index6 <= unitCounter; ++index6)
                this.game.Data.UnitObj[index6].TempUnitSelectable = false;
              this.game.EditObj.UnitSelected = this.tUnitSelected;
              DrawMod.GetWidthForMiniMap();
              this.game.EditObj.MiniMap = (Bitmap) null;
              MiniMapPartClass miniMapPartClass = new MiniMapPartClass(DrawMod.TGame, tx: this.tMiniWidth, ty: this.tMiniHeight);
              this.game.HandyFunctionsObj.RedimTempValue(9999);
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.resultMesOkId)
            {
              this.game.EditObj.AreaX = -1;
              this.game.EditObj.AreaY = -1;
              this.game.EditObj.DoCardSlot = -1;
              this.game.CornerX = this.tCornerX;
              this.game.CornerY = this.tCornerY;
              this.game.SelectX = this.tSelectX;
              this.game.SelectY = this.tSelectY;
              this.game.EditObj.UnitSelected = this.tUnitSelected;
              this.game.EditObj.MapSelected = this.tSelectMap;
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.AreaSlot = -1;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index7 = 0; index7 <= unitCounter; ++index7)
                this.game.Data.UnitObj[index7].TempUnitSelectable = false;
              this.game.EditObj.UnitSelected = this.tUnitSelected;
              DrawMod.GetWidthForMiniMap();
              this.game.EditObj.MiniMap = (Bitmap) null;
              MiniMapPartClass miniMapPartClass = new MiniMapPartClass(DrawMod.TGame, tx: this.tMiniWidth, ty: this.tMiniHeight);
              this.game.HandyFunctionsObj.RedimTempValue(9999);
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.quitId)
            {
              this.game.EditObj.AreaX = -1;
              this.game.EditObj.AreaY = -1;
              this.game.EditObj.DoCardSlot = -1;
              this.game.CornerX = this.tCornerX;
              this.game.CornerY = this.tCornerY;
              this.game.SelectX = this.tSelectX;
              this.game.SelectY = this.tSelectY;
              this.game.EditObj.UnitSelected = this.tUnitSelected;
              this.game.EditObj.MapSelected = this.tSelectMap;
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.AreaSlot = -1;
              int unitCounter = this.game.Data.UnitCounter;
              for (int index8 = 0; index8 <= unitCounter; ++index8)
                this.game.Data.UnitObj[index8].TempUnitSelectable = false;
              this.game.EditObj.UnitSelected = this.tUnitSelected;
              DrawMod.GetWidthForMiniMap();
              this.game.EditObj.MiniMap = (Bitmap) null;
              MiniMapPartClass miniMapPartClass = new MiniMapPartClass(DrawMod.TGame, tx: this.tMiniWidth, ty: this.tMiniHeight);
              this.game.HandyFunctionsObj.RedimTempValue(9999);
              if (this.usageMode == SelectUsageMode.autoMove | this.usageMode == SelectUsageMode.selectHQ | this.usageMode == SelectUsageMode.blowBridge | this.usageMode == SelectUsageMode.repairBridge)
              {
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.game.EditObj.PopupValue = 22;
              windowReturnClass.AddCommand(5, 14);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.textAreaId)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.cancelid)
            {
              if (this.usageMode == SelectUsageMode.joinAttack)
                this.game.EditObj.TempUnitList.remove(this.game.EditObj.UnitSelected);
              this.ViewMessage();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.subId)
            {
              this.subordinatesToo = !this.subordinatesToo;
              this.ViewMessage();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.okid)
            {
              if (this.usageMode == SelectUsageMode.joinAttack)
                this.game.EditObj.TempUnitList.add(this.game.EditObj.UnitSelected);
              this.ViewMessage();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.FormRef.WindowState == FormWindowState.Minimized)
        return windowReturnClass;
      if (this.game.EditObj.ScrollDir == 1)
      {
        this.game.EditObj.ScrollDir = 0;
        return this.HandleKeyPress(38, false);
      }
      if (this.game.EditObj.ScrollDir == 2)
      {
        this.game.EditObj.ScrollDir = 0;
        return this.HandleKeyPress(39, false);
      }
      if (this.game.EditObj.ScrollDir == 3)
      {
        this.game.EditObj.ScrollDir = 0;
        return this.HandleKeyPress(40, false);
      }
      if (this.game.EditObj.ScrollDir == 4)
      {
        this.game.EditObj.ScrollDir = 0;
        return this.HandleKeyPress(37, false);
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public override WindowReturnClass HandleKeyup(int nr)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int cornerX = this.game.CornerX;
      int cornerY = this.game.CornerY;
      if (nr == 27)
        return this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.quitId)] + 1, this.SubPartY[this.SubpartNr(this.quitId)] + 1, 1);
      if (nr == 32 & this.okid > 0)
        return this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okid)] + 1, this.SubPartY[this.SubpartNr(this.okid)] + 1, 1);
      return nr == 32 & this.cancelid > 0 ? this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.cancelid)] + 1, this.SubPartY[this.SubpartNr(this.cancelid)] + 1, 1) : windowReturnClass;
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      bool flag = false;
      int cornerX = this.game.CornerX;
      int cornerY = this.game.CornerY;
      if (nr == 39)
      {
        ++this.game.CornerX;
        flag = true;
      }
      if (nr == 37 & (this.game.CornerX > 0 | this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop))
      {
        --this.game.CornerX;
        if (0 > this.game.CornerX & !this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop)
          this.game.CornerX = 0;
        flag = true;
      }
      if (nr == 40)
      {
        ++this.game.CornerY;
        flag = true;
      }
      if (nr == 38 & this.game.CornerY > 0)
      {
        --this.game.CornerY;
        if (this.game.CornerY < 0)
          this.game.CornerY = 0;
        flag = true;
      }
      int num1 = 230;
      if (this.game.Data.Round == 0)
        num1 += 100;
      int num2 = (int) Math.Round(Conversion.Int((double) (this.OwnBitmap.Width - 250) / (double) (53 * (this.game.EditObj.Zoom + 1))));
      int num3 = (int) Math.Round(Conversion.Int((double) (this.OwnBitmap.Height - num1) / (double) (48 * (this.game.EditObj.Zoom + 1))));
      int num4 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth - this.game.CornerX + 1;
      int num5 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight - this.game.CornerY + 1;
      if (num2 > num4 & !this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop)
      {
        flag = true;
        this.game.CornerX = cornerX;
      }
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & 0 > this.game.CornerX)
        this.game.CornerX = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + this.game.CornerX + 1;
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].MapLoop & this.game.CornerX > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
        this.game.CornerX -= this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth + 1;
      if (num3 > num5)
      {
        flag = true;
        this.game.CornerY = cornerY;
      }
      if (this.game.CornerX == cornerX & this.game.CornerY == cornerY)
        flag = false;
      if (!flag)
        return windowReturnClass;
      if (nr == 39)
        this.SubPartList[this.SubpartNr(this.mapid)].ShiftLeft();
      if (nr == 37)
        this.SubPartList[this.SubpartNr(this.mapid)].ShiftRight();
      if (nr == 40)
        this.SubPartList[this.SubpartNr(this.mapid)].ShiftUp();
      if (nr == 38)
        this.SubPartList[this.SubpartNr(this.mapid)].ShiftDown();
      windowReturnClass.SetFlag(true);
      this.ViewMessage();
      return windowReturnClass;
    }
  }
}
