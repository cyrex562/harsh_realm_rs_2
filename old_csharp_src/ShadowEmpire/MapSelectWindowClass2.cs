// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MapSelectWindowClass2
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
  public class MapSelectWindowClass2 : WindowClass
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
    private int oldShowSetting;
    private int tempUnitHisId;
    private int tempUnitHis2Id;
    private int tcx;
    private int tcy;
    private bool UdsMode;
    private int tSelectX;
    private int tSelectY;
    private int tSelectMap;
    private int tCornerX;
    private int tCornerY;
    private MapMatrix2 cacheTemp;
    private MapMatrix2Coordinate cacheTempCameFrom;
    private MapMatrix2 cacheTempValueSpecial;
    private MapMatrix2 cacheTempValueSpecial2;
    private MapMatrix2 cacheTemp2;
    private MapMatrix2Plus6 cacheTempAttack;

    public void Close()
    {
      if (this.game.Data.Product != 6)
        return;
      this.game.EditObj.TempValue[0] = this.cacheTemp;
      this.game.EditObj.TempCameFrom[0] = this.cacheTempCameFrom;
      this.game.EditObj.TempValueSpecial[0] = this.cacheTempValueSpecial;
      this.game.EditObj.TempValueSpecial2[0] = this.cacheTempValueSpecial2;
      this.game.EditObj.TempValue2[0] = this.cacheTemp2;
      this.game.EditObj.TempAttack[0] = this.cacheTempAttack;
    }

    public MapSelectWindowClass2(ref GameClass tGame)
      : base(ref tGame, 860, 700, 8)
    {
      if (Information.IsNothing((object) this.game.EditObj.TempValue[0]))
        this.game.HandyFunctionsObj.RedimTempValue(9999);
      if (Information.IsNothing((object) this.game.EditObj.TempValueSpecial[0]))
        this.game.HandyFunctionsObj.RedimTempValueSpecial(0);
      if (Information.IsNothing((object) this.game.EditObj.TempValueSpecial2[0]))
        this.game.HandyFunctionsObj.RedimTempValueSpecial2(0);
      if (Information.IsNothing((object) this.game.EditObj.TempValue2[0]))
        this.game.HandyFunctionsObj.RedimTempValue2(9999);
      if (Information.IsNothing((object) this.game.EditObj.TempCameFrom[0]))
        this.game.HandyFunctionsObj.RedimTempCameFrom();
      if (Information.IsNothing((object) this.game.EditObj.TempAttack[0]))
        this.game.HandyFunctionsObj.RedimTempAttack(true);
      this.cacheTemp = this.game.EditObj.TempValue[0].Clone();
      this.cacheTempCameFrom = this.game.EditObj.TempCameFrom[0].Clone();
      this.cacheTempValueSpecial = this.game.EditObj.TempValueSpecial[0].Clone();
      this.cacheTempValueSpecial2 = this.game.EditObj.TempValueSpecial2[0].Clone();
      this.cacheTemp2 = this.game.EditObj.TempValue2[0].Clone();
      this.cacheTempAttack = this.game.EditObj.TempAttack[0].Clone();
      this.FromMessage = tGame.EditObj.FromMessage;
      this.oldShowSetting = this.game.EditObj.HideUnit;
      this.game.EditObj.MapPopupMode = true;
      if (this.game.Data.Product < 6)
        this.game.EditObj.HideUnit = 0;
      this.UnitSelected = this.game.EditObj.UnitSelected;
      this.tempUnitHisId = -1;
      this.tempUnitHis2Id = -1;
      if (this.game.EditObj.UnitSelected > -1)
      {
        this.tempUnitHisId = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
        this.tempUnitHis2Id = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HistoricalSubPart;
      }
      this.tSelectX = this.game.SelectX;
      this.tSelectY = this.game.SelectY;
      this.tCornerX = this.game.CornerX;
      this.tCornerY = this.game.CornerY;
      this.tSelectMap = this.game.EditObj.MapSelected;
      this.tcx = this.game.CornerX;
      this.tcy = this.game.CornerY;
      this.game.CornerX = this.game.SelectX - 5;
      this.game.CornerY = this.game.SelectY - 4;
      if (this.game.CornerX > this.game.Data.MapObj[0].MapWidth - 15)
        this.game.CornerX -= this.game.CornerX - (this.game.Data.MapObj[0].MapWidth - 15);
      if (this.game.CornerY > this.game.Data.MapObj[0].MapHeight - 10)
        this.game.CornerY -= this.game.CornerY - (this.game.Data.MapObj[0].MapHeight - 10);
      if (0 > this.game.CornerX)
        this.game.CornerX = 0;
      if (0 > this.game.CornerY)
        this.game.CornerY = 0;
      this.NewBackGroundAndClearAll(860, 700, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 860, 700);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      this.UdsMode = false;
      if (this.game.EditObj.HandCard == -1 & this.game.EditObj.DoCardSlot == -1 & this.game.Data.Product > 6)
        this.UdsMode = true;
      Bitmap bitmap;
      if (!this.UdsMode)
      {
        if (this.game.EditObj.HandCard == -1)
        {
          ref Graphics local1 = ref graphics;
          bitmap = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.game.EditObj.DoCardSlot], size: 2);
          ref Bitmap local2 = ref bitmap;
          DrawMod.DrawSimple(ref local1, ref local2, 210, 538);
        }
        else
        {
          ref Graphics local3 = ref graphics;
          bitmap = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.EditObj.HandCard, size: 2);
          ref Bitmap local4 = ref bitmap;
          DrawMod.DrawSimple(ref local3, ref local4, 210, 538);
        }
      }
      ref Graphics local5 = ref graphics;
      bitmap = BitmapStore.GetBitmap(this.game.MARCMESFRAME);
      ref Bitmap local6 = ref bitmap;
      Rectangle rectangle1 = new Rectangle(32, 1, 10, 4);
      Rectangle srcrect1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(4, 56, 842, 4);
      Rectangle destrect1 = rectangle2;
      DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect1, destrect1);
      ref Graphics local7 = ref graphics;
      bitmap = BitmapStore.GetBitmap(this.game.MARCMESFRAME);
      ref Bitmap local8 = ref bitmap;
      rectangle2 = new Rectangle(32, 385, 10, 4);
      Rectangle srcrect2 = rectangle2;
      rectangle1 = new Rectangle(4, 531, 842, 4);
      Rectangle destrect2 = rectangle1;
      DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect2, destrect2);
      ref Graphics local9 = ref graphics;
      bitmap = BitmapStore.GetBitmap(this.game.MARCMESFRAME);
      ref Bitmap local10 = ref bitmap;
      rectangle2 = new Rectangle(1, 300, 4, 42);
      Rectangle srcrect3 = rectangle2;
      rectangle1 = new Rectangle(205, 535, 4, 150);
      Rectangle destrect3 = rectangle1;
      DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect3, destrect3);
      ref Graphics local11 = ref graphics;
      bitmap = BitmapStore.GetBitmap(this.game.MARCMESFRAME);
      ref Bitmap local12 = ref bitmap;
      rectangle2 = new Rectangle(1, 300, 4, 42);
      Rectangle srcrect4 = rectangle2;
      rectangle1 = new Rectangle(320, 535, 4, 150);
      Rectangle destrect4 = rectangle1;
      DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect4, destrect4);
      ref Graphics local13 = ref graphics;
      bitmap = BitmapStore.GetBitmap(this.game.MARCMESFRAME);
      ref Bitmap local14 = ref bitmap;
      rectangle2 = new Rectangle(1, 300, 4, 42);
      Rectangle srcrect5 = rectangle2;
      rectangle1 = new Rectangle(615, 535, 4, 150);
      Rectangle destrect5 = rectangle1;
      DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect5, destrect5);
      if (!this.UdsMode)
      {
        if (this.UnitSelected == -1 | this.game.EditObj.HandCard == -1)
        {
          if (this.game.EditObj.HandCard > -1)
          {
            ref Graphics local15 = ref graphics;
            bitmap = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.EditObj.HandCard, size: 3);
            ref Bitmap local16 = ref bitmap;
            DrawMod.DrawSimple(ref local15, ref local16, 10, 7);
          }
          else
          {
            ref Graphics local17 = ref graphics;
            bitmap = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.game.EditObj.DoCardSlot], size: 3);
            ref Bitmap local18 = ref bitmap;
            DrawMod.DrawSimple(ref local17, ref local18, 10, 7);
          }
          DrawMod.DrawTextColouredMarc(ref graphics, "Select a hex to play card on", this.game.MarcFont1, 50, 15, Color.White);
        }
        else
        {
          DrawMod.DrawTextColouredMarc(ref graphics, "Unit", this.game.MarcFont1, 10, 15, Color.White);
          ref Graphics local19 = ref graphics;
          bitmap = this.game.CustomBitmapObj.DrawUnit(this.UnitSelected);
          ref Bitmap local20 = ref bitmap;
          DrawMod.DrawSimple(ref local19, ref local20, 72, 12);
          DrawMod.DrawTextColouredMarc(ref graphics, "is playing card ", this.game.MarcFont1, 110, 15, Color.White);
          if (this.game.EditObj.HandCard == -1)
          {
            ref Graphics local21 = ref graphics;
            bitmap = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.game.EditObj.DoCardSlot], size: 3);
            ref Bitmap local22 = ref bitmap;
            DrawMod.DrawSimple(ref local21, ref local22, 290, 7);
          }
          else
          {
            ref Graphics local23 = ref graphics;
            bitmap = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.EditObj.HandCard, size: 3);
            ref Bitmap local24 = ref bitmap;
            DrawMod.DrawSimple(ref local23, ref local24, 290, 7);
          }
          DrawMod.DrawTextColouredMarc(ref graphics, "You need to select a hex to play card on.", this.game.MarcFont1, 330, 15, Color.White);
        }
      }
      else
        DrawMod.DrawTextColouredMarc(ref graphics, this.game.EditObj.QuestionText, this.game.MarcFont1, 50, 15, Color.White);
      this.game.EditObj.TempCoordList = new CoordList();
      this.ViewMessage();
    }

    public override void Dispose()
    {
      base.Dispose();
      DrawMod.TGame.EditObj.MapPopupMode = false;
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
      this.ClearMouse();
      Rectangle trect1;
      if (!this.UdsMode)
      {
        if (this.game.EditObj.HandCard > -1)
        {
          int handCard = this.game.EditObj.HandCard;
          if (this.game.Data.ActionCardObj[handCard].MouseOver.Length > 0)
          {
            trect1 = new Rectangle(210, 538, 105, 147);
            this.AddMouse(ref trect1, "", this.game.Data.ActionCardObj[handCard].MouseOver);
          }
        }
        else
        {
          int index = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.game.EditObj.DoCardSlot];
          if (this.game.Data.ActionCardObj[index].MouseOver.Length > 0)
          {
            trect1 = new Rectangle(210, 538, 105, 147);
            Rectangle trect2 = trect1;
            this.AddMouse(ref trect2, "", this.game.Data.ActionCardObj[index].MouseOver);
          }
        }
      }
      if (this.mapid == 0)
      {
        SubPartClass tsubpart = (SubPartClass) new MapPartClass(839, 470, this.game, ZoomLevel: 0, tFromPopupMap: true);
        this.mapid = this.AddSubPart(ref tsubpart, 5, 60, 839, 470, 0);
      }
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref objgraphics;
      ref Bitmap local2 = ref this.BackBitmap;
      trect1 = new Rectangle(370, 540, 240, 140);
      Rectangle rect = trect1;
      DrawMod.DrawSimplePart(ref local1, ref local2, rect);
      if (!this.UdsMode)
      {
        if (this.game.SelectX > -1 & this.game.SelectY > -1)
        {
          DrawMod.DrawTextColouredMarc(ref objgraphics, "HEX SELECTED:", this.game.MarcFont4, 370, 550, Color.White);
          ref Graphics local3 = ref objgraphics;
          CustomBitmapClass customBitmapObj = this.game.CustomBitmapObj;
          int selectX = this.game.SelectX;
          int selectY = this.game.SelectY;
          Bitmap bitmap1 = (Bitmap) null;
          ref Bitmap local4 = ref bitmap1;
          bool flag = false;
          ref bool local5 = ref flag;
          Bitmap bitmap2 = customBitmapObj.DrawHex(selectX, selectY, 0, gBitmap: (ref local4), tFromMapPopup: (ref local5));
          ref Bitmap local6 = ref bitmap2;
          DrawMod.DrawSimple(ref local3, ref local6, 370, 575);
          DrawMod.DrawTextColouredMarc(ref objgraphics, this.game.HandyFunctionsObj.GetHexName(this.game.SelectX, this.game.SelectY, 0), this.game.MarcFont4, 440, 585, Color.White);
          if (this.game.EditObj.AreaSlot > -1)
          {
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].AreaCode[this.game.EditObj.AreaSlot] == this.game.EditObj.AreaValue)
            {
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("PLAY CARD", 200, "Click to play the card on selected hex. [SPACE]", ref this.BackBitmap, 630, 550, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              this.okid = this.AddSubPart(ref tsubpart, 630, 550, 200, 40, 1);
              DrawMod.DrawTextColouredMarc(ref objgraphics, "CAN PLAY CARD", this.game.MarcFont4, 370, 640, Color.White);
            }
            else
              DrawMod.DrawTextColouredMarc(ref objgraphics, "CANNOT PLAY CARD", this.game.MarcFont4, 370, 640, Color.Red);
          }
        }
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("CANCEL", 200, "Click to cancel and not play the card. [ESC]", ref this.BackBitmap, 630, 610, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.cancelid = this.AddSubPart(ref tsubpart1, 630, 610, 200, 40, 1);
      }
      else
      {
        if (this.game.SelectX > -1 & this.game.SelectY > -1)
        {
          DrawMod.DrawTextColouredMarc(ref objgraphics, "HEX SELECTED:", this.game.MarcFont4, 370, 550, Color.White);
          ref Graphics local7 = ref objgraphics;
          CustomBitmapClass customBitmapObj = this.game.CustomBitmapObj;
          int selectX = this.game.SelectX;
          int selectY = this.game.SelectY;
          Bitmap bitmap3 = (Bitmap) null;
          ref Bitmap local8 = ref bitmap3;
          bool flag = false;
          ref bool local9 = ref flag;
          Bitmap bitmap4 = customBitmapObj.DrawHex(selectX, selectY, 0, gBitmap: (ref local8), tFromMapPopup: (ref local9));
          ref Bitmap local10 = ref bitmap4;
          DrawMod.DrawSimple(ref local7, ref local10, 370, 575);
          DrawMod.DrawTextColouredMarc(ref objgraphics, this.game.HandyFunctionsObj.GetHexName(this.game.SelectX, this.game.SelectY, 0), this.game.MarcFont4, 440, 585, Color.White);
          if (this.game.EditObj.AreaSlot > -1)
          {
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].AreaCode[this.game.EditObj.AreaSlot] == this.game.EditObj.AreaValue)
            {
              SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("CONFIRM", 200, "Click to confirm this hex as a destination [SPACE]", ref this.BackBitmap, 630, 550, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              this.okid = this.AddSubPart(ref tsubpart, 630, 550, 200, 40, 1);
              DrawMod.DrawTextColouredMarc(ref objgraphics, "CAN CONFIRM HEX", this.game.MarcFont4, 370, 640, Color.White);
            }
            else
              DrawMod.DrawTextColouredMarc(ref objgraphics, "CANNOT CONFIRM HEX", this.game.MarcFont4, 370, 640, Color.Red);
          }
        }
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("CANCEL", 200, "Click to cancel selection of destination hex [ESC]", ref this.BackBitmap, 630, 610, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.cancelid = this.AddSubPart(ref tsubpart2, 630, 610, 200, 40, 1);
      }
      SubPartClass tsubpart3 = (SubPartClass) new MiniMapPartClass(this.game, tMapWidth: 834, tMapHeight: 470, ZoomLevel: 0);
      this.Pic1Id = this.AddSubPart(ref tsubpart3, 5, 535, 200, 150, 0);
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
            if (num1 == this.mapid)
            {
              int selectX = this.game.SelectX;
              int selectY = this.game.SelectY;
              Coordinate coordinate = this.SubPartList[index1].ClickMap(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (coordinate.onmap)
              {
                this.game.SelectX = coordinate.x;
                this.game.SelectY = coordinate.y;
                this.game.EditObj.TempCoordList.AddCoord(selectX, selectY, 0);
                this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, 0);
              }
              this.SubPartList[this.SubpartNr(this.mapid)].Paint();
              this.ViewMessage();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.cancelid)
            {
              this.game.EditObj.HideUnit = this.oldShowSetting;
              this.game.EditObj.AreaX = -1;
              this.game.EditObj.AreaY = -1;
              this.game.EditObj.DoCardSlot = -1;
              this.game.CornerX = this.tCornerX;
              this.game.CornerY = this.tCornerY;
              this.game.SelectX = this.tSelectX;
              this.game.SelectY = this.tSelectY;
              this.game.EditObj.AreaSlot = -1;
              this.game.EditObj.MapSelected = this.tSelectMap;
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.UnitSelected = this.UnitSelected;
              if (this.game.EditObj.UnitSelected > -1)
              {
                if (this.game.EditObj.UnitSelected > this.game.Data.UnitCounter)
                  this.game.EditObj.UnitSelected = -1;
                else if (!(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical == this.tempUnitHisId & this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HistoricalSubPart == this.tempUnitHis2Id))
                  this.game.EditObj.UnitSelected = -1;
              }
              int widthForMiniMap = DrawMod.GetWidthForMiniMap();
              MiniMapPartClass miniMapPartClass = new MiniMapPartClass(DrawMod.TGame, tx: widthForMiniMap, ty: 200);
              this.game.HandyFunctionsObj.RedimTempValue(9999);
              this.Close();
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.okid)
            {
              this.game.EditObj.HideUnit = this.oldShowSetting;
              this.game.EditObj.AreaX = this.game.SelectX;
              this.game.EditObj.AreaY = this.game.SelectY;
              int widthForMiniMap = DrawMod.GetWidthForMiniMap();
              MiniMapPartClass miniMapPartClass = new MiniMapPartClass(DrawMod.TGame, tx: widthForMiniMap, ty: 200);
              if (this.UdsMode)
              {
                this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EditObj.nextEventSlot);
                windowReturnClass.SetFlag(true);
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                windowReturnClass.SetFlag(true);
                this.game.CornerX = this.tCornerX;
                this.game.CornerY = this.tCornerY;
                this.game.SelectX = this.tSelectX;
                this.game.SelectY = this.tSelectY;
                this.game.EditObj.UnitSelected = this.UnitSelected;
                return windowReturnClass;
              }
              if ((double) this.game.Data.RuleVar[408] > 0.0 & this.game.EditObj.DoCardSlot > -1)
              {
                this.game.ProcessingObj.PlayCard(this.game.Data.Turn, this.game.EditObj.DoCardSlot);
                windowReturnClass.SetFlag(true);
                this.game.EditObj.PopupValue = 21;
                windowReturnClass.AddCommand(5, 14);
                windowReturnClass.SetFlag(true);
                this.game.CornerX = this.tCornerX;
                this.game.CornerY = this.tCornerY;
                this.game.SelectX = this.tSelectX;
                this.game.SelectY = this.tSelectY;
                this.game.EditObj.UnitSelected = this.UnitSelected;
                return windowReturnClass;
              }
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
                this.game.CornerX = this.tCornerX;
                this.game.CornerY = this.tCornerY;
                this.game.SelectX = this.tSelectX;
                this.game.SelectY = this.tSelectY;
                this.game.EditObj.UnitSelected = this.UnitSelected;
                if (this.game.EditObj.UnitSelected > -1)
                {
                  if (this.game.EditObj.UnitSelected > this.game.Data.UnitCounter)
                    this.game.EditObj.UnitSelected = -1;
                  else if (!(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical == this.tempUnitHisId & this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HistoricalSubPart == this.tempUnitHis2Id))
                    this.game.EditObj.UnitSelected = -1;
                }
                this.Close();
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
              if (this.game.EditObj.HandCard > -1)
                this.game.ProcessingObj.PlayCardByUnit(this.UnitSelected, this.game.EditObj.HandCard);
              else
                this.game.ProcessingObj.PlayCard(this.game.Data.Turn, this.game.EditObj.DoCardSlot);
              this.game.EditObj.AreaX = -1;
              this.game.EditObj.AreaSlot = -1;
              this.game.EditObj.HandCard = -1;
              this.game.EditObj.DoCardSlot = -1;
              this.game.CornerX = this.tCornerX;
              this.game.CornerY = this.tCornerY;
              this.game.SelectX = this.tSelectX;
              this.game.SelectY = this.tSelectY;
              this.game.EditObj.UnitSelected = this.UnitSelected;
              if (this.game.EditObj.UnitSelected > -1)
              {
                if (this.game.EditObj.UnitSelected > this.game.Data.UnitCounter)
                  this.game.EditObj.UnitSelected = -1;
                else if (!(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical == this.tempUnitHisId & this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HistoricalSubPart == this.tempUnitHis2Id))
                  this.game.EditObj.UnitSelected = -1;
              }
              if (Strings.Len(this.game.Data.LoadGame) > 0)
              {
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                Form formRef = (Form) this.game.FormRef;
                this.game.HandyFunctionsObj.LoadGameNow();
                this.game.FormRef = (Form1) formRef;
                this.game.FormRef.Cursor = Cursors.Default;
                windowReturnClass.AddCommand(3, 13);
                return windowReturnClass;
              }
              int locCounter = this.game.Data.LocCounter;
              int Number;
              for (int locnr = 0; locnr <= locCounter; ++locnr)
              {
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
                {
                  int index2 = 0;
                  do
                  {
                    if (this.game.Data.LocObj[locnr].Production[index2] > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, this.game.Data.LocObj[locnr].Production[index2]).result)
                    {
                      ++Number;
                      this.game.Data.LocObj[locnr].Production[index2] = -1;
                      this.game.Data.LocObj[locnr].ProdPointRemainder[index2] = 0;
                      this.game.Data.LocObj[locnr].ProdPercent[index2] = 0;
                    }
                    ++index2;
                  }
                  while (index2 <= 3);
                }
              }
              if ((double) this.game.Data.RuleVar[701] > 0.0 & this.game.Data.Product >= 6)
                this.game.EditObj.udsReturnFromPopup = true;
              if (Number > 0)
              {
                int num2 = (int) Interaction.MsgBox((object) (Conversion.Str((object) Number) + " production lines have been cancelled due to this action card being played."), Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter > messCounter)
              {
                this.game.EditObj.PopupValue = 0;
                this.game.EditObj.FromMessage = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
                windowReturnClass.AddCommand(5, 14);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              this.Close();
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              this.game.EditObj.DoCardSlot = -1;
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
        return this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.cancelid)] + 1, this.SubPartY[this.SubpartNr(this.cancelid)] + 1, 1);
      return nr == 32 & this.okid > 0 ? this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okid)] + 1, this.SubPartY[this.SubpartNr(this.okid)] + 1, 1) : windowReturnClass;
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
