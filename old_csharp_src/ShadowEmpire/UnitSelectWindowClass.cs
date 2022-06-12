// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UnitSelectWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class UnitSelectWindowClass : WindowClass
  {
    private int okid;
    private int cancelid;
    private int oktextid;
    private int Pic1Id;
    private int unitheaderid;
    private int unitsfid;
    private int mapid;
    private int FromMessage;
    private int UnitSelected;
    private int tcx;
    private int tcy;
    private int tSelectX;
    private int tSelectY;
    private int tSelectMap;
    private int tCornerX;
    private int tCornerY;

    public UnitSelectWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.FromMessage = tGame.EditObj.FromMessage;
      this.UnitSelected = this.game.EditObj.UnitSelected;
      this.tSelectX = this.game.SelectX;
      this.tSelectY = this.game.SelectY;
      this.tCornerX = this.game.CornerX;
      this.tCornerY = this.game.CornerY;
      this.tSelectMap = this.game.EditObj.MapSelected;
      this.game.SelectX = this.game.Data.MapObj[0].MapWidth;
      this.game.SelectY = this.game.Data.MapObj[0].MapHeight;
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          int unitCounter = this.game.Data.MapObj[0].HexObj[index1, index2].UnitCounter;
          for (int index3 = 0; index3 <= unitCounter; ++index3)
          {
            if (this.game.Data.UnitObj[this.game.Data.MapObj[0].HexObj[index1, index2].UnitList[index3]].TempUnitSelectable && index1 + index2 < this.game.SelectX + this.game.SelectY)
            {
              this.game.SelectX = index1;
              this.game.SelectY = index2;
            }
          }
        }
      }
      this.tcx = this.game.CornerX;
      this.tcy = this.game.CornerY;
      this.game.CornerX = this.game.SelectX - 5;
      this.game.CornerY = this.game.SelectY - 4;
      if (0 > this.game.CornerX)
        this.game.CornerX = 0;
      if (0 > this.game.CornerY)
        this.game.CornerY = 0;
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawTextVic2(ref Expression, "Select a highlighted unit", this.game.VicFont1, 50, 43, this.game.VicColor2, this.game.VicColor2Shade);
      if (this.game.EditObj.DoCardSlot > -1)
      {
        ref Graphics local1 = ref Expression;
        Bitmap bitmap = this.game.CustomBitmapObj.DrawActionCard(this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.game.EditObj.DoCardSlot]);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawScaled(ref local1, ref local2, 685, 210, 267, 400);
      }
      else
      {
        ref Graphics local3 = ref Expression;
        Bitmap bitmap = this.game.CustomBitmapObj.DrawActionCard(this.game.EditObj.HandCard);
        ref Bitmap local4 = ref bitmap;
        DrawMod.DrawScaled(ref local3, ref local4, 685, 210, 267, 400);
      }
      DrawMod.DrawRectangle(ref Expression, 49, 79, 602, 442, (int) this.game.GameCol2.R, (int) this.game.GameCol2.G, (int) this.game.GameCol2.B, (int) byte.MaxValue);
      this.ViewMessage();
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    public void ViewMessage()
    {
      if (this.Pic1Id > 0)
        this.RemoveSubPart(this.Pic1Id);
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
      if (this.oktextid > 0)
        this.RemoveSubPart(this.oktextid);
      if (this.unitheaderid > 0)
        this.RemoveSubPart(this.unitheaderid);
      if (this.unitsfid > 0)
        this.RemoveSubPart(this.unitsfid);
      this.game.EditObj.TempCoordList = new CoordList();
      SubPartClass tsubpart;
      if (this.mapid == 0)
      {
        tsubpart = (SubPartClass) new MapPartClass(600, 440, this.game, ZoomLevel: 0);
        this.mapid = this.AddSubPart(ref tsubpart, 50, 80, 600, 440, 0);
      }
      if (this.game.EditObj.UnitSelected > -1)
      {
        tsubpart = (SubPartClass) new UnitHeaderPartClass(this.game.EditObj.UnitSelected, this.game);
        this.unitheaderid = this.AddSubPart(ref tsubpart, 50, 540, 285, 200, 0);
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].TempUnitSelectable)
        {
          tsubpart = (SubPartClass) new TextButtonPartClass("SELECT", 250, tBackbitmap: (ref this.OwnBitmap), bbx: 695, bby: 627, theight: 50);
          this.okid = this.AddSubPart(ref tsubpart, 695, 627, 250, 50, 1);
        }
      }
      if (this.okid == 0)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("SELECT", 250, tBackbitmap: (ref this.OwnBitmap), bbx: 695, bby: 627, tinactive: true, theight: 50);
        this.oktextid = this.AddSubPart(ref tsubpart, 695, 627, 250, 50, 1);
      }
      tsubpart = (SubPartClass) new TextButtonPartClass("Cancel", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 720, bby: 690);
      this.cancelid = this.AddSubPart(ref tsubpart, 720, 690, 200, 35, 1);
      tsubpart = (SubPartClass) new MiniMapPartClass(this.game, tMapWidth: 600, tMapHeight: 440, ZoomLevel: 0);
      this.Pic1Id = this.AddSubPart(ref tsubpart, 720, 50, 200, 150, 0);
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
              this.ViewMessage();
              windowReturnClass.SetFlag(true);
            }
            else
            {
              if (num1 == this.mapid)
              {
                int selectX = this.game.SelectX;
                int selectY = this.game.SelectY;
                Coordinate coordinate = this.SubPartList[index1].ClickMap(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                if (coordinate.onmap)
                {
                  this.game.SelectX = coordinate.x;
                  this.game.SelectY = coordinate.y;
                  this.game.EditObj.SFSelected = -1;
                  int num2 = !(selectX == this.game.SelectX & selectY == this.game.SelectY) ? this.game.HandyFunctionsObj.ClickOnHexGivesUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, true, b, coordinate.data1, coordinate.penalty, true) : this.game.HandyFunctionsObj.ClickOnHexGivesUnit(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, false, b, coordinate.data1, coordinate.penalty, true);
                  if (selectX > -1)
                  {
                    SubPartClass subPart = this.SubPartList[index1];
                    int x1 = selectX;
                    int y1 = selectY;
                    int map = coordinate.map;
                    Bitmap bitmap = (Bitmap) null;
                    ref Bitmap local = ref bitmap;
                    subPart.PaintCoordinate((Graphics) null, x1, y1, map, gBitmap: (ref local));
                  }
                  this.game.EditObj.UnitSelected = num2;
                }
                this.ViewMessage();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.cancelid)
              {
                this.game.EditObj.AreaX = -1;
                this.game.EditObj.AreaY = -1;
                this.game.EditObj.DoCardSlot = -1;
                this.game.CornerX = this.tCornerX;
                this.game.CornerY = this.tCornerY;
                this.game.SelectX = this.tSelectX;
                this.game.SelectY = this.tSelectY;
                this.game.EditObj.MapSelected = this.tSelectMap;
                this.game.EditObj.TempCoordList = new CoordList();
                this.game.EditObj.AreaSlot = -1;
                int unitCounter = this.game.Data.UnitCounter;
                for (int index2 = 0; index2 <= unitCounter; ++index2)
                  this.game.Data.UnitObj[index2].TempUnitSelectable = false;
                this.game.EditObj.UnitSelected = this.UnitSelected;
                this.game.HandyFunctionsObj.RedimTempValue(9999);
                if (this.game.EditObj.OrderType == 23)
                {
                  this.game.EditObj.PopupValue = 14;
                  windowReturnClass.AddCommand(5, 10);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.okid)
              {
                this.game.EditObj.AreaX = this.game.SelectX;
                this.game.EditObj.AreaY = this.game.SelectY;
                int unitCounter = this.game.Data.UnitCounter;
                for (int index3 = 0; index3 <= unitCounter; ++index3)
                  this.game.Data.UnitObj[index3].TempUnitSelectable = false;
                if (!(this.game.EditObj.DoCardSlot > -1 | this.game.EditObj.HandCard > -1))
                  return windowReturnClass;
                this.game.CornerX = this.tcx;
                this.game.CornerY = this.tcy;
                if (this.game.EditObj.AreaX == -1)
                {
                  this.game.EditObj.DoCardSlot = -1;
                  this.game.EditObj.AreaX = -1;
                  this.game.EditObj.HandCard = -1;
                  this.game.EditObj.AreaY = -1;
                  if (this.game.EditObj.OrderType == 23)
                  {
                    this.game.EditObj.PopupValue = 14;
                    windowReturnClass.AddCommand(5, 10);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
                if (this.game.EditObj.HandCard > -1)
                  this.game.ProcessingObj.PlayCardByUnit(this.UnitSelected, this.game.EditObj.HandCard);
                else if (this.game.EditObj.OrderType == 23)
                  this.game.ProcessingObj.PlayCard(this.game.Data.Turn, this.game.EditObj.DoCardSlot);
                else
                  this.game.ProcessingObj.PlayCard(this.game.EditObj.DoCardSlot);
                this.game.EditObj.AreaX = -1;
                this.game.EditObj.AreaSlot = -1;
                this.game.EditObj.HandCard = -1;
                if (Strings.Len(this.game.Data.LoadGame) > 0)
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  Form formRef = (Form) this.game.FormRef;
                  this.game.HandyFunctionsObj.LoadGameNow();
                  this.game.FormRef = (Form1) formRef;
                  this.game.FormRef.Cursor = Cursors.Default;
                  windowReturnClass.AddCommand(3, 4);
                  return windowReturnClass;
                }
                int locCounter = this.game.Data.LocCounter;
                for (int locnr = 0; locnr <= locCounter; ++locnr)
                {
                  if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
                  {
                    int index4 = 0;
                    do
                    {
                      if (this.game.Data.LocObj[locnr].Production[index4] > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, this.game.Data.LocObj[locnr].Production[index4]).result)
                      {
                        int num3;
                        ++num3;
                        this.game.Data.LocObj[locnr].Production[index4] = -1;
                        this.game.Data.LocObj[locnr].ProdPointRemainder[index4] = 0;
                        this.game.Data.LocObj[locnr].ProdPercent[index4] = 0;
                      }
                      ++index4;
                    }
                    while (index4 <= 3);
                  }
                }
                if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter > messCounter)
                {
                  this.game.EditObj.PopupValue = 0;
                  this.game.EditObj.FromMessage = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
                  windowReturnClass.AddCommand(5, 10);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (this.game.EditObj.OrderType == 23)
                {
                  this.game.EditObj.PopupValue = 14;
                  windowReturnClass.AddCommand(5, 10);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                this.game.EditObj.DoCardSlot = -1;
                return windowReturnClass;
              }
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
      if (this.game.Data.Round > 0)
      {
        SubPartClass subPart = this.SubPartList[this.SubpartNr(this.mapid)];
        int selectX = this.game.SelectX;
        int selectY = this.game.SelectY;
        int mapSelected = this.game.EditObj.MapSelected;
        int counterAlpha = this.game.EditObj.CounterAlpha;
        Bitmap bitmap = (Bitmap) null;
        ref Bitmap local = ref bitmap;
        subPart.PaintCoordinate((Graphics) null, selectX, selectY, mapSelected, counterAlpha, ref local);
        this.PaintCurrentBitmap(this.mapid);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
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
      if (nr == 27)
        return this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.cancelid)] + 1, this.SubPartY[this.SubpartNr(this.cancelid)] + 1, 1);
      if (nr == 32 & this.okid > 0)
        return this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okid)] + 1, this.SubPartY[this.SubpartNr(this.okid)] + 1, 1);
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
      this.PaintCurrentBitmap(this.mapid);
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }
  }
}
