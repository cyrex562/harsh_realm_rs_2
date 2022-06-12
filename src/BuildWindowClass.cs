﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.BuildWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class BuildWindowClass : WindowClass
  {
    private int LocNr;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int[] VarId;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int OptionsListId;
    private ATListClass OptionsListObj;
    private int OptionsList2Id;
    private ATListClass OptionsList2Obj;
    private int detailnr;
    private bool[] LocCanConstr;
    private bool[] LocCanConstr2;
    private bool LocCanSetup;

    public BuildWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.VarId = new int[5];
      this.LocCanConstr = new bool[1000];
      this.LocCanConstr2 = new bool[1000];
      this.LocNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
      this.detailnr = -1;
      this.game.EditObj.LocTypeSelected = -1;
      this.dostuff();
      this.fixshade = true;
    }

    private void dostuff()
    {
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
        this.RemoveSubPart(this.Text2Id);
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      int index1 = 0;
      do
      {
        if (this.VarId[index1] > 0)
          this.RemoveSubPart(this.VarId[index1]);
        ++index1;
      }
      while (index1 <= 4);
      this.NewBackGroundAndClearAll(1024, 200, -1);
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref objGraphics;
      Rectangle rectangle1 = new Rectangle(0, 0, 350, 14);
      Rectangle rect1_1 = rectangle1;
      Rectangle rectangle2;
      Rectangle rect2_1 = rectangle2;
      DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "LOCATION TYPE                         EP                   PP                 SUP", rect2_1, "");
      if (!this.LocCanSetup)
      {
        this.game.FormRef.Cursor = Cursors.WaitCursor;
        if (this.game.Data.LocTypeCounter > -1)
        {
          int locTypeCounter = this.game.Data.LocTypeCounter;
          for (int loctype = 0; loctype <= locTypeCounter; ++loctype)
          {
            if (this.game.EditObj.OrderUnit > -1)
            {
              if (this.game.HandyFunctionsObj.CanConstructLoc(loctype, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].X, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Y, this.game.Data.UnitObj[this.game.EditObj.OrderUnit].Map, this.game.Data.Turn, this.game.EditObj.UnitSelected, true))
                this.LocCanConstr[loctype] = true;
              if (this.game.HandyFunctionsObj.CanConstructLoc(loctype, this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.game.Data.Turn, this.game.EditObj.OrderUnit))
                this.LocCanConstr2[loctype] = true;
            }
          }
        }
        this.game.FormRef.Cursor = Cursors.Default;
        this.LocCanSetup = true;
      }
      int tlistselect;
      string str1;
      SubPartClass tsubpart;
      if (this.OptionsListId == 0)
      {
        this.OptionsListObj = new ATListClass();
        if (this.detailnr > this.game.Data.LocTypeCounter)
          this.detailnr = -1;
        tlistselect = -1;
        int num = -1;
        str1 = "NAME";
        if (this.game.Data.LocTypeCounter > -1)
        {
          int locTypeCounter = this.game.Data.LocTypeCounter;
          for (int tdata = 0; tdata <= locTypeCounter; ++tdata)
          {
            bool flag = this.LocCanConstr[tdata];
            if (this.game.Data.LocTypeObj[tdata].HumanCanBuild & this.game.Data.LocTypeObj[tdata].Buildable & this.game.Data.LocTypeObj[tdata].EPCost == 0 & this.game.Data.LocTypeObj[tdata].SupplyCost == 0)
              flag = true;
            if (flag)
            {
              ++num;
              if (this.detailnr == -1)
                this.detailnr = tdata;
              if (this.detailnr == tdata)
                tlistselect = num;
              string str2 = this.game.Data.LocTypeObj[tdata].Name;
              if (Strings.Len(str2) > 22)
                str2 = Strings.Left(str2, 22);
              this.OptionsListObj.add(str2, tdata, Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[tdata].EPCost)), Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[tdata].PPCost)), Strings.Trim(Conversion.Str((object) (int) Math.Round((double) ((float) this.game.Data.LocTypeObj[tdata].SupplyCost / this.game.Data.RuleVar[77])))));
            }
          }
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            tsubpart = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 10, 350, tlistselect, this.game, true, tShowPair: true, tValueWidth: 200, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 0, bby: 16);
            this.OptionsListId = this.AddSubPart(ref tsubpart, 0, 16, 350, 176, 0);
          }
        }
      }
      if (this.detailnr > -1)
      {
        DrawMod.DrawRectangle(ref objGraphics, 399, 44, 252, 105, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
        str1 = this.game.Data.LocTypeObj[this.detailnr].Name;
        if (this.game.Data.LocTypeObj[this.detailnr].OverdrawLTNr > -1)
        {
          ref Graphics local2 = ref objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.detailnr].OverdrawLTNr].BasicPicID[this.game.Data.LocTypeObj[this.detailnr].OverdrawSpriteNr]);
          ref Bitmap local3 = ref bitmap;
          DrawMod.DrawScaled(ref local2, ref local3, 400, 45, 250, 103);
        }
        else if (this.game.Data.LocTypeObj[this.detailnr].PictureLT > -1)
        {
          ref Graphics local4 = ref objGraphics;
          Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].LandscapeType].BasicPicID[this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].SpriteNr]);
          ref Bitmap local5 = ref bitmap1;
          DrawMod.DrawScaled(ref local4, ref local5, 400, 45, 250, 103);
          ref Graphics local6 = ref objGraphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.detailnr].PictureLT].BasicPicID[this.game.Data.LocTypeObj[this.detailnr].PictureSprite]);
          ref Bitmap local7 = ref bitmap2;
          DrawMod.DrawScaled(ref local6, ref local7, 400, 45, 250, 103);
        }
        else
        {
          ref Graphics local8 = ref objGraphics;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].LandscapeType].BasicPicID[this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].SpriteNr]);
          ref Bitmap local9 = ref bitmap;
          DrawMod.DrawScaled(ref local8, ref local9, 400, 45, 250, 103);
        }
        ref Graphics local10 = ref objGraphics;
        rectangle1 = new Rectangle(399, 0, 250, 14);
        Rectangle rect1_2 = rectangle1;
        Rectangle rectangle3 = new Rectangle(399, 14, 250, 23);
        Rectangle rect2_2 = rectangle3;
        string name = this.game.Data.LocTypeObj[this.detailnr].Name;
        DrawMod.MakeFullBoxVic2(ref local10, rect1_2, "SELECTED LOCATION TYPE", rect2_2, name);
        string str3 = this.game.Data.LocTypeObj[this.detailnr].SetPeopleToSlotX <= 0 ? this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].Name : this.game.Data.PeopleObj[this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].AreaCode[this.game.Data.LocTypeObj[this.detailnr].SetPeopleToSlotX]].Name;
        if (this.game.Data.LocTypeObj[this.detailnr].UpgradeNr > -1)
          str3 = this.game.Data.PeopleObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.EditObj.OrderX, this.game.EditObj.OrderY].Location].People].Name;
        ref Graphics local11 = ref objGraphics;
        rectangle3 = new Rectangle(700, 0, 130, 14);
        Rectangle rect1_3 = rectangle3;
        rectangle1 = new Rectangle(700, 14, 130, 23);
        Rectangle rect2_3 = rectangle1;
        string txt2 = str3;
        DrawMod.MakeFullBoxVic2(ref local11, rect1_3, "LOC PEOPLE", rect2_3, txt2);
        this.OptionsList2Obj = new ATListClass();
        string str4 = "0";
        if (this.game.EditObj.OrderUnit > -1)
          str4 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetUnitEP(this.game.EditObj.OrderUnit)));
        string str5 = Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.detailnr].EPCost));
        string tvalue3_1 = Conversion.Val(str4) < Conversion.Val(str5) ? "SHORT" : "OK";
        this.OptionsList2Obj.add("EP", -1, str5, str4, tvalue3_1);
        string str6 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts));
        string str7 = Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.detailnr].PPCost));
        string tvalue3_2 = Conversion.Val(str6) < Conversion.Val(str7) ? "SHORT" : "OK";
        this.OptionsList2Obj.add("PP", -1, str7, str6, tvalue3_2);
        string str8 = "0";
        if (this.game.EditObj.OrderUnit > -1)
          str8 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.HQSupplyChain(this.game.EditObj.OrderUnit, true)));
        string str9 = Strings.Trim(Conversion.Str((object) (int) Math.Round((double) ((float) this.game.Data.LocTypeObj[this.detailnr].SupplyCost / this.game.Data.RuleVar[77]))));
        string tvalue3_3 = Conversion.Val(str8) < Conversion.Val(str9) ? "SHORT" : "OK";
        this.OptionsList2Obj.add("SUP", -1, str9, str8, tvalue3_3);
        int index2 = 0;
        do
        {
          if (this.game.Data.LocTypeObj[this.detailnr].VarType[index2] > -1)
          {
            string str10 = Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].RegimeSlot[this.game.Data.LocTypeObj[this.detailnr].VarType[index2]]));
            string str11 = Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.detailnr].VarQty[index2]));
            string tvalue3_4 = Conversion.Val(str10) < Conversion.Val(str11) ? "SHORT" : "OK";
            this.OptionsList2Obj.add(this.game.Data.RegimeSlotName[this.game.Data.LocTypeObj[this.detailnr].VarType[index2]], -1, str11, str10, tvalue3_4);
          }
          ++index2;
        }
        while (index2 <= 4);
        ref Graphics local12 = ref objGraphics;
        rectangle3 = new Rectangle(700, 50, 310, 14);
        Rectangle rect1_4 = rectangle3;
        Rectangle rect2_4 = rectangle2;
        DrawMod.MakeFullBoxVic2(ref local12, rect1_4, "COST TYPE          NEED               AVAILABLE      STATUS", rect2_4, "");
        if (this.OptionsList2Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, tlistselect);
          this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
        }
        else
        {
          tsubpart = (SubPartClass) new ATListSubPartClass(this.OptionsList2Obj, 6, 310, tlistselect, this.game, true, tHighlight: false, tShowPair: true, tValueWidth: 225, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 700, bby: 66);
          this.OptionsList2Id = this.AddSubPart(ref tsubpart, 700, 66, 300, 112, 0);
        }
        tsubpart = (SubPartClass) new TextButtonPartClass("?", 40, "Get more information on selected location type", ref this.OwnBitmap, 400, 157);
        this.B1Id = this.AddSubPart(ref tsubpart, 400, 157, 40, 35, 1);
        if (this.LocCanConstr2[this.detailnr])
        {
          tsubpart = (SubPartClass) new TextButtonPartClass("Build", 196, "Build the selected location on this hex", ref this.OwnBitmap, 450, 157);
          this.B2Id = this.AddSubPart(ref tsubpart, 450, 157, 196, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new TextButtonPartClass("Build", 196, "You cannot build this location type", ref this.OwnBitmap, 450, 157, true);
          this.Text2Id = this.AddSubPart(ref tsubpart, 450, 157, 196, 35, 1);
        }
      }
      if (Information.IsNothing((object) objGraphics))
        return;
      objGraphics.Dispose();
    }

    public void PopUpRefresh() => this.DoRefresh();

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.B1Id)
            {
              this.game.EditObj.LocTypeSelected = this.detailnr;
              this.game.EditObj.PopupValue = 12;
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.AddCommand(5, 10);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B2Id)
            {
              if (this.detailnr > -1)
              {
                if (this.game.Data.LocTypeObj[this.detailnr].HumanCanBuild)
                  this.game.EditObj.OrderUnit = -1;
                OrderResult orderResult = this.game.ProcessingObj.Build(this.game.EditObj.OrderUnit, this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap, this.detailnr);
                if (this.game.EditObj.SoundOn)
                  SoundMod.PlayAWave(this.game.AppPath + "sound/building.wav", ref this.game.EditObj);
                if (orderResult.OK)
                {
                  this.game.EditObj.OrderType = 0;
                  this.game.ProcessingObj.LocationProductionPrognosis();
                  windowReturnClass.AddCommand(1, 5);
                  windowReturnClass.AddCommand(2, 20);
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.EditObj.TempCoordList.AddCoord(this.game.EditObj.OrderX, this.game.EditObj.OrderY, this.game.EditObj.OrderMap);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 18);
                  windowReturnClass.AddCommand(4, 66);
                  windowReturnClass.AddCommand(4, 44);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
            }
            else if (num1 == this.OptionsListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 > -1)
              {
                this.detailnr = num2;
                this.dostuff();
              }
              if (num2 == -2)
              {
                this.detailnr = -1;
                this.dostuff();
              }
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
