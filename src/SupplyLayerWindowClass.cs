// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SupplyLayerWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SupplyLayerWindowClass : WindowClass
  {
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int w;
    private int h;
    private int detailnr;
    private int detailnr2;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsListId2;
    private ListClass OptionsListObj2;
    private bool firstCall;
    private int curMode;
    private int curModeX;
    private int curModeY;
    private SimpleList CacheL;
    private SimpleList CacheL2;
    private bool firstCallOnNew;

    public SupplyLayerWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, tGame.ScreenWidth, 150, BackSprite: tGame.MARCBOTBAR)
    {
      this.curMode = 0;
      this.curModeX = -1;
      this.curModeY = -1;
      this.CacheL = new SimpleList();
      this.CacheL2 = new SimpleList();
      this.game.EditObj.OrderX = this.game.SelectX;
      this.game.EditObj.OrderY = this.game.SelectY;
      this.game.EditObj.OrderType = 51;
      this.game.EditObj.udsUnitOrderMode = 0;
      this.w = tGame.ScreenWidth;
      this.h = 222;
      this.BlockBlit = true;
      this.firstCall = true;
      if (this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Regime == this.game.Data.Turn | this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Regime == -1)
      {
        this.detailnr = -1;
        this.detailnr2 = -2;
      }
      else
      {
        this.detailnr = -2;
        this.detailnr2 = -1;
      }
      this.firstCallOnNew = true;
      this.dostuff();
    }

    private void dostuff()
    {
      this.CacheL = new SimpleList();
      this.CacheL2 = new SimpleList();
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      int tdata1;
      int tdata2;
      Coordinate coordinate1;
      Coordinate coordinate2;
      for (tdata1 = 0; tdata1 <= mapWidth; ++tdata1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (tdata2 = 0; tdata2 <= mapHeight; ++tdata2)
        {
          if (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Regime == this.game.Data.Turn)
          {
            int location2 = this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location2;
            int num = 0;
            if (location2 > -1)
            {
              int type = this.game.Data.LocObj[location2].Type;
              if (this.game.Data.LocTypeObj[type].isSupplySource)
              {
                num = 1;
                this.CacheL.Add(location2, 100, tdata1, tdata2);
              }
              else if (this.game.Data.LocTypeObj[type].isSupplyBase)
              {
                num = 1;
                this.CacheL.Add(location2, 5, tdata1, tdata2);
              }
            }
            if (num == 0)
            {
              int location = this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location;
              if (location > -1)
              {
                num = 1;
                int type = this.game.Data.LocObj[location].Type;
                if (this.game.Data.LocTypeObj[type].isSupplySource)
                  this.CacheL.Add(location, 100, tdata1, tdata2);
                else if (this.game.Data.LocTypeObj[type].isSupplyBase)
                  this.CacheL.Add(location, 5, tdata1, tdata2);
              }
            }
            if (num == 0 && !coordinate1.onmap)
            {
              coordinate1.x = tdata1;
              coordinate1.y = tdata2;
              coordinate1.onmap = true;
            }
          }
          else if (this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Regime > -1)
          {
            int location2 = this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location2;
            int num = 0;
            if (location2 > -1)
            {
              int type = this.game.Data.LocObj[location2].Type;
              if (this.game.Data.LocTypeObj[type].isSupplySource)
              {
                num = 1;
                this.CacheL2.Add(location2, 100, tdata1, tdata2);
              }
              else if (this.game.Data.LocTypeObj[type].isSupplyBase)
              {
                num = 1;
                this.CacheL2.Add(location2, 5, tdata1, tdata2);
              }
            }
            if (num == 0)
            {
              int location = this.game.Data.MapObj[0].HexObj[tdata1, tdata2].Location;
              if (location > -1)
              {
                num = 1;
                int type = this.game.Data.LocObj[location].Type;
                if (this.game.Data.LocTypeObj[type].isSupplySource)
                  this.CacheL2.Add(location, 100, tdata1, tdata2);
                else if (this.game.Data.LocTypeObj[type].isSupplyBase)
                  this.CacheL2.Add(location, 5, tdata1, tdata2);
              }
            }
            if (num == 0 && !coordinate2.onmap)
            {
              coordinate2.x = tdata1;
              coordinate2.y = tdata2;
              coordinate2.onmap = true;
            }
          }
        }
      }
      this.CacheL.ReverseSortHighSpeed();
      this.CacheL2.ReverseSortHighSpeed();
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.OptionsListId > 0)
      {
        this.RemoveSubPart(this.OptionsListId);
        this.OptionsListId = 0;
      }
      if (this.OptionsListId2 > 0)
      {
        this.RemoveSubPart(this.OptionsListId2);
        this.OptionsListId2 = 0;
      }
      int num1 = (int) Math.Round((double) (this.w - 1280) / 2.0);
      this.NewBackGroundAndClearAll(this.w, this.h, this.game.MARCBOTBAR);
      this.ClearMouse();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawBlock(ref Expression, num1 + 20, 10, 400, 135, 0, 0, 0, 100);
      DrawMod.DrawBlock(ref Expression, num1 + 440, 10, 400, 135, 0, 0, 0, 100);
      DrawMod.DrawBlock(ref Expression, num1 + 860, 10, 400, 135, 0, 0, 0, 100);
      this.OptionsListObj = new ListClass();
      int num2 = -1;
      int tlistselect1 = -1;
      int num3 = -1;
      if (!coordinate1.onmap)
        num3 = 0;
      if (this.firstCallOnNew & this.game.EditObj.dc4_last_supply_x > -1)
      {
        this.firstCallOnNew = false;
        int counter1 = this.CacheL.Counter;
        for (int index = 0; index <= counter1; ++index)
        {
          int num4 = this.CacheL.Id[index];
          tdata1 = this.CacheL.Data1[index];
          tdata2 = this.CacheL.Data2[index];
          if (this.game.EditObj.dc4_last_supply_x == tdata1 & tdata2 == this.game.EditObj.dc4_last_supply_y)
          {
            this.detailnr = num4;
            this.detailnr2 = -2;
          }
        }
        int counter2 = this.CacheL2.Counter;
        for (int index = 0; index <= counter2; ++index)
        {
          int num5 = this.CacheL2.Id[index];
          tdata1 = this.CacheL2.Data1[index];
          tdata2 = this.CacheL2.Data2[index];
          if (this.game.EditObj.dc4_last_supply_x == tdata1 & tdata2 == this.game.EditObj.dc4_last_supply_y)
          {
            this.detailnr2 = num5;
            this.detailnr = -2;
          }
        }
      }
      int counter3 = this.CacheL.Counter;
      for (int index = -1; index <= counter3; ++index)
      {
        if (index > -1)
        {
          int tdata = this.CacheL.Id[index];
          tdata1 = this.CacheL.Data1[index];
          tdata2 = this.CacheL.Data2[index];
          int type = this.game.Data.LocObj[tdata].Type;
          ++num2;
          if (this.detailnr == -1)
            this.detailnr = tdata;
          if (tdata == this.detailnr)
          {
            tlistselect1 = num2;
            this.game.EditObj.dc4_last_supply_x = tdata1;
            this.game.EditObj.dc4_last_supply_y = tdata2;
          }
          string tname = this.game.Data.LocTypeObj[type].Name + " (" + tdata1.ToString() + "," + tdata2.ToString() + ")";
          if (Operators.CompareString(Strings.LCase(this.game.Data.LocTypeObj[type].Name), Strings.LCase(this.game.Data.LocObj[tdata].Name), false) != 0)
            tname = tname + " '" + this.game.Data.LocObj[tdata].Name + "'";
          else if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tdata].X, this.game.Data.LocObj[tdata].Y].Location != tdata)
          {
            int location = this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tdata].X, this.game.Data.LocObj[tdata].Y].Location;
            if (location > -1)
              tname = tname + " '" + this.game.Data.LocObj[location].Name + "'";
          }
          this.OptionsListObj.add(tname, tdata);
        }
        else
        {
          int tdata = 999999;
          ++num2;
          if (this.detailnr == -1)
            this.detailnr = 999999;
          if (tdata == this.detailnr)
            tlistselect1 = num2;
          this.OptionsListObj.add("All friendly supply sources", tdata);
        }
      }
      SubPartClass tsubpart;
      if (this.OptionsListId > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect1);
        this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
      }
      else
      {
        tsubpart = (SubPartClass) new ListSubPartClass(this.OptionsListObj, 4, 380, tlistselect1, this.game, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (num1 + 450), bby: 18, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
        this.OptionsListId = this.AddSubPart(ref tsubpart, num1 + 450, 18, 380, 120, 0);
      }
      this.OptionsListObj2 = new ListClass();
      int num6 = -1;
      int tlistselect2 = -1;
      num3 = -1;
      if (!coordinate2.onmap)
        num3 = 0;
      int counter4 = this.CacheL2.Counter;
      for (int index = -1; index <= counter4; ++index)
      {
        if (index > -1)
        {
          int tdata = this.CacheL2.Id[index];
          tdata1 = this.CacheL2.Data1[index];
          tdata2 = this.CacheL2.Data2[index];
          int type = this.game.Data.LocObj[tdata].Type;
          ++num6;
          if (this.detailnr2 == -1)
            this.detailnr2 = tdata;
          if (tdata == this.detailnr2)
          {
            this.game.EditObj.dc4_last_supply_x = tdata1;
            this.game.EditObj.dc4_last_supply_y = tdata2;
            tlistselect2 = num6;
          }
          string tname = this.game.Data.LocTypeObj[type].Name + " (" + tdata1.ToString() + "," + tdata2.ToString() + ")";
          if (Operators.CompareString(Strings.LCase(this.game.Data.LocTypeObj[type].Name), Strings.LCase(this.game.Data.LocObj[tdata].Name), false) != 0)
            tname = tname + " '" + this.game.Data.LocObj[tdata].Name + "'";
          else if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tdata].X, this.game.Data.LocObj[tdata].Y].Location != tdata)
          {
            int location = this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[tdata].X, this.game.Data.LocObj[tdata].Y].Location;
            if (location > -1)
              tname = tname + " '" + this.game.Data.LocObj[location].Name + "'";
          }
          this.OptionsListObj2.add(tname, tdata);
        }
        else
        {
          int tdata = 999999;
          ++num6;
          if (this.detailnr2 == -1)
            this.detailnr2 = 999999;
          if (tdata == this.detailnr2)
            tlistselect2 = num6;
          this.OptionsListObj2.add("All enemy supply sources", tdata);
        }
      }
      if (this.OptionsListId2 > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsListId2)].Refresh(this.OptionsListObj2, tlistselect2);
        this.SubPartFlag[this.SubpartNr(this.OptionsListId2)] = true;
      }
      else
      {
        tsubpart = (SubPartClass) new ListSubPartClass(this.OptionsListObj2, 4, 380, tlistselect2, this.game, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (num1 + 870), bby: 18, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
        this.OptionsListId2 = this.AddSubPart(ref tsubpart, num1 + 870, 18, 380, 120, 0);
      }
      bool flag = false;
      string str1 = "";
      string str2 = "";
      if (this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Regime == this.game.Data.Turn & this.detailnr2 <= -2 | this.detailnr > -2)
      {
        str2 = "Friendly";
        if (this.detailnr == 999999)
        {
          str1 = "All friendly supply sources";
          str2 = "";
          if (this.firstCall | !(this.game.EditObj.OrderX == coordinate1.x & this.game.EditObj.OrderY == coordinate1.y))
          {
            this.curMode = 1;
            this.game.EditObj.OrderX = coordinate1.x;
            this.game.EditObj.OrderY = coordinate1.y;
            this.game.HandyFunctionsObj.MakeSupplyLayer3(this.game.EditObj.OrderX, this.game.EditObj.OrderY, 0);
            flag = true;
          }
        }
        else if (this.detailnr > -1)
        {
          int index = this.CacheL.Id[this.CacheL.FindNr(this.detailnr)];
          int type = this.game.Data.LocObj[index].Type;
          str1 = this.game.Data.LocTypeObj[type].Name + " (" + this.game.Data.LocObj[index].X.ToString() + "," + this.game.Data.LocObj[index].Y.ToString() + ")";
          if (Operators.CompareString(Strings.LCase(this.game.Data.LocTypeObj[type].Name), Strings.LCase(this.game.Data.LocObj[index].Name), false) != 0)
            str1 = str1 + " '" + this.game.Data.LocObj[index].Name + "'";
          else if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index].X, this.game.Data.LocObj[index].Y].Location != index)
          {
            int location = this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index].X, this.game.Data.LocObj[index].Y].Location;
            if (location > -1)
              str1 = str1 + " '" + this.game.Data.LocObj[location].Name + "'";
          }
          int nr = this.CacheL.FindNr(this.detailnr);
          if (this.firstCall | !(this.curModeX == this.CacheL.Data1[nr] & this.curModeY == this.CacheL.Data2[nr] & this.curMode == 2))
          {
            this.curMode = 2;
            this.curModeX = this.CacheL.Data1[nr];
            this.curModeY = this.CacheL.Data2[nr];
            this.game.EditObj.OrderX = this.curModeX;
            this.game.EditObj.OrderY = this.curModeY;
            this.game.HandyFunctionsObj.MakeSupplyLayer2(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.MapSelected);
            flag = true;
          }
        }
      }
      if (this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Regime != this.game.Data.Turn & this.detailnr <= -2 | this.detailnr2 > -2)
      {
        str2 = "Enemy";
        if (this.detailnr2 == 999999)
        {
          str1 = "All enemy supply sources";
          str2 = "";
          if (this.firstCall | !(this.game.EditObj.OrderX == coordinate2.x & this.game.EditObj.OrderY == coordinate2.y))
          {
            this.curMode = 1;
            flag = true;
            this.game.EditObj.OrderX = coordinate2.x;
            this.game.EditObj.OrderY = coordinate2.y;
            this.game.HandyFunctionsObj.MakeSupplyLayer3(this.game.EditObj.OrderX, this.game.EditObj.OrderY, 0);
          }
        }
        else if (this.detailnr2 > -1)
        {
          int index = this.CacheL2.Id[this.CacheL2.FindNr(this.detailnr2)];
          int type = this.game.Data.LocObj[index].Type;
          str1 = this.game.Data.LocTypeObj[type].Name + " (" + tdata1.ToString() + "," + tdata2.ToString() + ")";
          if (Operators.CompareString(Strings.LCase(this.game.Data.LocTypeObj[type].Name), Strings.LCase(this.game.Data.LocObj[index].Name), false) != 0)
            str1 = str1 + " '" + this.game.Data.LocObj[index].Name + "'";
          else if (this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index].X, this.game.Data.LocObj[index].Y].Location != index)
          {
            int location = this.game.Data.MapObj[0].HexObj[this.game.Data.LocObj[index].X, this.game.Data.LocObj[index].Y].Location;
            if (location > -1)
              str1 = str1 + " '" + this.game.Data.LocObj[location].Name + "'";
          }
          int nr = this.CacheL2.FindNr(this.detailnr2);
          if (this.firstCall | !(this.curModeX == this.CacheL2.Data1[nr] & this.curModeY == this.CacheL2.Data2[nr] & this.curMode == 3))
          {
            this.curMode = 3;
            flag = true;
            this.curModeX = this.CacheL2.Data1[nr];
            this.curModeY = this.CacheL2.Data2[nr];
            this.game.EditObj.OrderX = this.curModeX;
            this.game.EditObj.OrderY = this.curModeY;
            this.game.HandyFunctionsObj.MakeSupplyLayer2(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.MapSelected);
          }
        }
      }
      if (flag)
      {
        this.game.EditObj.SupplyPath = new CoordList();
        int x1 = this.game.SelectX;
        int y1 = this.game.SelectY;
        int map1;
        for (int map2 = 0; this.game.EditObj.TempSupCameFrom[map2].Value[x1, y1].onmap; map2 = map1)
        {
          this.game.EditObj.SupplyPath.AddCoord(x1, y1, map2);
          int x2 = this.game.EditObj.TempSupCameFrom[map2].Value[x1, y1].x;
          int y2 = this.game.EditObj.TempSupCameFrom[map2].Value[x1, y1].y;
          map1 = this.game.EditObj.TempSupCameFrom[map2].Value[x1, y1].map;
          x1 = x2;
          y1 = y2;
        }
        this.game.EditObj.TempCoordList = new CoordList();
      }
      this.firstCall = false;
      int x = num1 + 220;
      int y3 = 30;
      string tstring1 = "current supply layer mode:";
      DrawMod.DrawTextColouredMarcCenter(ref Expression, tstring1, this.game.MarcFont8, x, y3, Color.LightGray);
      string tstring2 = str1;
      int y4 = y3 + 20;
      DrawMod.DrawTextColouredMarcCenter(ref Expression, tstring2, this.game.MarcFont6, x, y4, Color.WhiteSmoke);
      if (str2.Length > 1)
      {
        y4 += 20;
        string str3 = str2;
        DrawMod.DrawTextColouredMarcCenter(ref Expression, "(" + str3 + ")", this.game.MarcFont8b, x, y4, Color.WhiteSmoke);
      }
      int y5 = y4 + 30;
      string tstring3 = "";
      if (this.curMode == 1)
        tstring3 = "Shows all sources as white hexes and traces path to selected hex from closest source.";
      else if (this.curMode == 2 | this.curMode == 3)
        tstring3 = "Shows the specific source/base with a white hexe and traces path to selected hex from this source.";
      DrawMod.DrawTextColouredConsoleMultiline(ref Expression, tstring3, this.game.MarcFont8c, x - 200, y5, Color.LightGray, 390, 80, true);
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      OrderResult orderResult = new OrderResult();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            int selectX;
            int selectY;
            if (num1 == this.OptionsListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              bool flag = false;
              if (num2 > -1)
              {
                if (this.detailnr == num2)
                  flag = true;
                this.detailnr = num2;
                this.detailnr2 = -2;
                if (this.detailnr < 999999 & !Information.IsNothing((object) this.CacheL))
                {
                  int nr = this.CacheL.FindNr(this.detailnr);
                  this.game.EditObj.OrderX = this.CacheL.Data1[nr];
                  this.game.EditObj.OrderY = this.CacheL.Data2[nr];
                }
                this.dostuff();
              }
              if (flag & this.detailnr < 999999)
              {
                selectX = this.game.SelectX;
                selectY = this.game.SelectY;
                this.game.SelectX = this.game.EditObj.OrderX;
                this.game.SelectY = this.game.EditObj.OrderY;
                this.game.HandyFunctionsObj.SetcornerXY2();
              }
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 69);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId2)
            {
              int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              bool flag = false;
              if (num3 > -1)
              {
                if (this.detailnr2 == num3)
                  flag = true;
                this.detailnr2 = num3;
                this.detailnr = -2;
                if (this.detailnr2 < 999999 & !Information.IsNothing((object) this.CacheL2))
                {
                  int nr = this.CacheL2.FindNr(this.detailnr2);
                  this.game.EditObj.OrderX = this.CacheL2.Data1[nr];
                  this.game.EditObj.OrderY = this.CacheL2.Data2[nr];
                }
                this.dostuff();
              }
              if (flag & this.detailnr2 < 999999)
              {
                selectX = this.game.SelectX;
                selectY = this.game.SelectY;
                this.game.SelectX = this.game.EditObj.OrderX;
                this.game.SelectY = this.game.EditObj.OrderY;
                this.game.HandyFunctionsObj.SetcornerXY2();
              }
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 69);
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
  }
}
