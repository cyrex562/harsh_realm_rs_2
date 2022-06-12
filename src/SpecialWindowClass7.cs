// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SpecialWindowClass7
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SpecialWindowClass7 : WindowClass
  {
    private int useWidth;
    private int useHeight;
    private int listId;
    private ListClass listObj;
    private ListClass libListObj;
    private int libTableId;
    private int tableId;
    private int text1id;
    private int addId;
    private int remId;
    private int remIdb;
    private int editId;
    private int editidb;
    private int importCsv;
    private int exportCsv;
    private int strId;
    private int detailx;
    private int detaily;
    private int cellinfoid;
    private int libSelect;
    private int switchId;
    private int fullForwardId;
    private int forwardId;
    private int backwardId;
    private int fullBackwardId;
    private int mode;
    private int pageNumberId;

    public SpecialWindowClass7(ref GameClass tGame, int tUseWidth, int tUseHeight)
      : base(ref tGame, tUseWidth, tUseHeight, 8)
    {
      this.useWidth = tUseWidth;
      this.useHeight = tUseHeight;
      this.strId = -1;
      this.detailx = -1;
      this.detaily = -1;
      this.libSelect = -1;
      this.mode = 1;
      this.DoStuff();
    }

    public void RefreshCellInfo()
    {
      int num = 40;
      if (this.cellinfoid > 0)
      {
        this.RemoveSubPart(this.cellinfoid);
        this.cellinfoid = 0;
      }
      string txt;
      if (this.detaily == -1 | this.detailx == -1)
        txt = "No cell selected";
      else if (this.strId > -1)
        txt = "(row" + this.detailx.ToString() + ",col" + this.detaily.ToString() + ")             " + this.game.Data.StringListObj[this.strId].ColumnName[this.detaily].ToUpper() + "                " + this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily];
      SubPartClass tsubpart = (SubPartClass) new TextPartClass(txt, this.game.MarcFont4, this.game.ScreenWidth - 23, 20, false, tMarc: true);
      this.cellinfoid = this.AddSubPart(ref tsubpart, 12, num + 49, this.game.ScreenWidth - 32, 20, 0);
    }

    public override void DoRefresh() => this.DoStuff();

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (this.strId == -1)
        return windowReturnClass1;
      if ((nr == 32 | nr == 13) & this.detailx > -1 & this.editId > 0)
      {
        WindowReturnClass windowReturnClass2 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.editId)] + 1, this.SubPartY[this.SubpartNr(this.editId)] + 1, 1);
        windowReturnClass2.SetFlag(true);
        return windowReturnClass2;
      }
      if (nr == 38 & this.detailx > 0)
      {
        --this.detailx;
        this.RefreshCellInfo();
        int index = this.SubpartNr(this.tableId);
        if (index > -1)
          this.SubPartFlag[index] = true;
        if (index > -1)
          this.SubPartList[index].Refresh(this.game.Data.StringListObj[this.strId], this.detailx, this.detaily);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 40 & this.detailx < this.game.Data.StringListObj[this.strId].Length)
      {
        ++this.detailx;
        this.RefreshCellInfo();
        int index = this.SubpartNr(this.tableId);
        if (index > -1)
          this.SubPartFlag[index] = true;
        if (index > -1)
          this.SubPartList[index].Refresh(this.game.Data.StringListObj[this.strId], this.detailx, this.detaily);
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (this.mode == 1)
      {
        if (nr == 37 & this.detaily > 0)
        {
          --this.detaily;
          this.RefreshCellInfo();
          int index = this.SubpartNr(this.tableId);
          if (index > -1)
            this.SubPartFlag[index] = true;
          if (index > -1)
            this.SubPartList[index].Refresh(this.game.Data.StringListObj[this.strId], this.detailx, this.detaily);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
        if (nr == 39 & this.detaily < this.game.Data.StringListObj[this.strId].Width)
        {
          ++this.detaily;
          this.RefreshCellInfo();
          int index = this.SubpartNr(this.tableId);
          if (index > -1)
            this.SubPartFlag[index] = true;
          if (index > -1)
            this.SubPartList[index].Refresh(this.game.Data.StringListObj[this.strId], this.detailx, this.detaily);
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
      }
      return windowReturnClass1;
    }

    public void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = this.game.ScreenHeight - 768;
      if (this.addId > 0)
        this.RemoveSubPart(this.addId);
      if (this.remId > 0)
        this.RemoveSubPart(this.remId);
      if (this.remIdb > 0)
        this.RemoveSubPart(this.remIdb);
      if (this.editId > 0)
        this.RemoveSubPart(this.editId);
      if (this.editidb > 0)
        this.RemoveSubPart(this.editidb);
      if (this.tableId > 0)
        this.RemoveSubPart(this.tableId);
      if (this.importCsv > 0)
        this.RemoveSubPart(this.importCsv);
      if (this.exportCsv > 0)
        this.RemoveSubPart(this.exportCsv);
      if (this.text1id > 0)
        this.RemoveSubPart(this.text1id);
      if (this.listId > 0)
      {
        this.RemoveSubPart(this.listId);
        this.listId = 0;
      }
      if (this.libTableId > 0)
      {
        this.RemoveSubPart(this.libTableId);
        this.libTableId = 0;
      }
      if (this.cellinfoid > 0)
      {
        this.RemoveSubPart(this.cellinfoid);
        this.cellinfoid = 0;
      }
      this.NewBackGroundAndClearAll(this.useWidth, this.useHeight, -1);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawRepeatingBackground(objgraphics, DrawMod.TGame.BACKGROUND3MARC, 0, 0, this.useWidth, this.useHeight);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      int num3 = -1;
      int num4 = 40;
      int num5;
      if (num2 > 10)
        num5 = (int) Math.Round((double) (num2 - 10) * 0.33 / 16.0);
      this.libListObj = new ListClass();
      this.libListObj.add("All", -2);
      if (this.libSelect == -1)
        num3 = 0;
      int num6 = 0;
      if (num1 >= 256)
      {
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Libraries:", this.game.MarcFont4, 10 + num1 - 256, (int) Math.Round((double) (num4 + 72) + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 30.0), Color.White);
        int libraryCounter = this.game.Data.LibraryCounter;
        for (int index1 = 0; index1 <= libraryCounter; ++index1)
        {
          bool flag = false;
          int stringListCounter = this.game.Data.StringListCounter;
          for (int index2 = 0; index2 <= stringListCounter; ++index2)
          {
            if (this.game.Data.StringListObj[index2].LibId.libSlot == index1 && this.game.Data.StringListObj[index2].Editable)
            {
              flag = true;
              break;
            }
          }
          if (flag)
          {
            ++num6;
            this.libListObj.add(Conversion.Str((object) index1) + ") " + this.game.Data.LibraryObj[index1].name, index1);
            if (this.libSelect == index1)
              num3 = num6;
          }
        }
        if (this.libListObj.ListCount > 0)
        {
          ListClass libListObj = this.libListObj;
          int tlistsize = 9 + num5;
          int tlistselect = num3;
          GameClass game = this.game;
          ref Bitmap local1 = ref this.OwnBitmap;
          int bbx = 10 + num1 - 256;
          int bby = (int) Math.Round((double) (num4 + 72) + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0);
          Font font = (Font) null;
          ref Font local2 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(libListObj, tlistsize, 250, tlistselect, game, true, "Tables", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx, bby: bby, tMarcStyle: true, overruleFont: (ref local2));
          this.libTableId = this.AddSubPart(ref tsubpart, 10 + num1 - 256, (int) Math.Round((double) (num4 + 72) + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0), 250, (12 + num5) * 16, 0);
        }
      }
      string tstring = "Tables:";
      DrawMod.DrawTextColouredMarc(ref objgraphics, tstring, this.game.MarcFont4, 10 + num1, (int) Math.Round((double) (num4 + 72) + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 30.0), Color.White);
      int num7 = -1;
      int num8 = -1;
      this.listObj = new ListClass();
      int stringListCounter1 = this.game.Data.StringListCounter;
      for (int index = 0; index <= stringListCounter1; ++index)
      {
        if (this.game.Data.StringListObj[index].Editable && this.game.Data.StringListObj[index].LibId.libSlot == this.libSelect | this.libSelect == -1)
        {
          ++num7;
          this.listObj.add(Conversion.Str((object) index) + ") " + this.game.Data.StringListObj[index].Name, index);
          if (num8 == -1)
            num8 = 0;
          if (this.strId == -1)
            this.strId = index;
          if (this.strId == index)
            num8 = num7;
        }
      }
      if (num8 > num7)
        num8 = 0;
      if (num8 == -1)
        this.strId = -1;
      if (this.game.Data.StringListCounter > -1)
      {
        ListClass listObj = this.listObj;
        int tlistsize = 9 + num5;
        int tlistselect = num8;
        GameClass game = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        int bbx = 10 + num1;
        int bby = (int) Math.Round((double) (num4 + 72) + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0);
        Font font = (Font) null;
        ref Font local4 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(listObj, tlistsize, 250, tlistselect, game, true, "Tables", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local3), bbx: bbx, bby: bby, tMarcStyle: true, overruleFont: (ref local4));
        this.listId = this.AddSubPart(ref tsubpart, 10 + num1, (int) Math.Round((double) (num4 + 72) + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0), 250, (12 + num5) * 16, 0);
      }
      int num9 = 40;
      if (this.strId <= -1)
        return;
      SubPartClass tsubpart1;
      if (this.mode == 1)
      {
        SubPartClass tsubpart2 = (SubPartClass) new MatrixSubPartClass(this.game.Data.StringListObj[this.strId], 11 + (int) Math.Round((double) num2 * 0.66 / 24.0), Math.Max(1000, this.game.ScreenWidth - 24), this.detailx, this.detaily, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 10, bby: (num9 + 72), trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true, tLibSlot: this.game.Data.StringListObj[this.strId].LibId.libSlot);
        this.tableId = this.AddSubPart(ref tsubpart2, 10, num9 + 72, Math.Max(1000, this.game.ScreenWidth - 24), (int) Math.Round((13.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0), 0);
      }
      else
      {
        if (this.detailx > this.game.Data.StringListObj[this.strId].Length | this.detailx == -1 & this.game.Data.StringListObj[this.strId].Length > -1)
          this.detailx = 0;
        if (this.detailx > -1 & this.detailx <= this.game.Data.StringListObj[this.strId].Length)
        {
          StringListClass tListobj = new StringListClass(-9999);
          tListobj.AddCol(0, "Column Name");
          tListobj.AddCol(1, "Value");
          int width = this.game.Data.StringListObj[this.strId].Width;
          for (int col = 0; col <= width; ++col)
          {
            LibVarClass libVarClass = this.game.Data.StringListObj[this.strId].GetValue(ref this.game.Data, this.detailx, col);
            tListobj.AddRowWithData(this.game.Data.StringListObj[this.strId].ColumnName[col], libVarClass.valueText);
          }
          tsubpart1 = (SubPartClass) new MatrixSubPartClass(tListobj, 13 + (int) Math.Round((double) num2 * 0.66 / 24.0), Math.Max(1000, this.game.ScreenWidth - 24), this.detaily, 1, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 10, bby: (num9 + 72), trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true, tTwoColumnVariant: 200);
          this.tableId = this.AddSubPart(ref tsubpart1, 10, num9 + 72, Math.Max(1000, this.game.ScreenWidth - 24), (int) Math.Round((15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0), 0);
        }
        else
          DrawMod.DrawTextColouredMarcCenter(ref objgraphics, "No rows in table", this.game.MarcFont4, num1 + 512, num9 + 256 + (int) Math.Round((double) num2 * 0.33), Color.White);
      }
      string str1 = " (Id " + this.game.Data.StringListObj[this.strId].ID.ToString();
      if (this.game.Data.StringListObj[this.strId].LibId.libSlot > -1)
        str1 = str1 + ", LibId " + this.game.Data.StringListObj[this.strId].ID.ToString();
      string str2 = str1 + ")";
      int num10 = 40;
      DrawMod.DrawTextColouredMarc(ref objgraphics, this.game.Data.StringListObj[this.strId].Name + str2 + " information:", this.game.MarcFont3, 310 + num1, num10 + 72 + (15 + (int) Math.Round((double) num2 * 0.66 / 24.0)) * 24 + 55 + 30, Color.White);
      tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, (int) Math.Round(Math.Max(700.0, (double) this.game.ScreenWidth / 2.0 - 324.0)), 4 + (int) Math.Round((double) num2 * 0.33 / 27.0), this.game.MarcFont4, this.game.Data.StringListObj[this.strId].Description, 27, ref this.OwnBitmap, 310 + num1, (int) Math.Round((double) (num10 + 72) + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 62.0 + 30.0));
      this.text1id = this.AddSubPart(ref tsubpart1, 310 + num1, (int) Math.Round((double) (num10 + 72) + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 62.0 + 30.0), (int) Math.Round(Math.Max(700.0, (double) this.game.ScreenWidth / 2.0 - 324.0)), Math.Max(120, this.game.ScreenHeight - 648), 0);
      this.Tabby();
      if (!(this.detailx > -1 & this.detaily > -1 & !Information.IsNothing((object) this.tableId)))
        return;
      this.RefreshCellInfo();
    }

    public void Tabby()
    {
      if (this.addId > 0)
        this.RemoveSubPart(this.addId);
      if (this.remId > 0)
        this.RemoveSubPart(this.remId);
      if (this.remIdb > 0)
        this.RemoveSubPart(this.remIdb);
      if (this.editId > 0)
        this.RemoveSubPart(this.editId);
      if (this.editidb > 0)
        this.RemoveSubPart(this.editidb);
      if (this.importCsv > 0)
        this.RemoveSubPart(this.importCsv);
      if (this.exportCsv > 0)
        this.RemoveSubPart(this.exportCsv);
      if (this.switchId > 0)
        this.RemoveSubPart(this.switchId);
      if (this.forwardId > 0)
        this.RemoveSubPart(this.forwardId);
      if (this.backwardId > 0)
        this.RemoveSubPart(this.backwardId);
      if (this.fullForwardId > 0)
        this.RemoveSubPart(this.fullForwardId);
      if (this.fullBackwardId > 0)
        this.RemoveSubPart(this.fullBackwardId);
      if (this.pageNumberId > 0)
        this.RemoveSubPart(this.pageNumberId);
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = this.game.ScreenHeight - 768;
      if (this.strId < 0)
        return;
      int num3 = (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) (num2 + 40) * 0.66) / 24.0) * 24.0 + 28.0);
      SubPartClass tsubpart;
      if (this.mode == 1)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("=> Records", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (330 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.switchId = this.AddSubPart(ref tsubpart, 330 + num1, num3, 150, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("=> Table", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (330 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.switchId = this.AddSubPart(ref tsubpart, 330 + num1, num3, 150, 35, 1);
        string tDescript = "";
        tsubpart = (SubPartClass) new TextButtonPartClass("<<", 40, tDescript, ref this.OwnBitmap, 10 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.fullBackwardId = this.AddSubPart(ref tsubpart, 10 + num1, num3, 40, 35, 1);
        tsubpart = (SubPartClass) new TextButtonPartClass("<", 40, tDescript, ref this.OwnBitmap, 50 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.backwardId = this.AddSubPart(ref tsubpart, 50 + num1, num3, 40, 35, 1);
        tsubpart = (SubPartClass) new TextButtonPartClass(">", 40, tDescript, ref this.OwnBitmap, 230 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.forwardId = this.AddSubPart(ref tsubpart, 230 + num1, num3, 40, 35, 1);
        tsubpart = (SubPartClass) new TextButtonPartClass(">>", 40, tDescript, ref this.OwnBitmap, 270 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.fullForwardId = this.AddSubPart(ref tsubpart, 270 + num1, num3, 40, 35, 1);
        string txt = this.detailx.ToString() + " / " + this.game.Data.StringListObj[this.strId].Length.ToString();
        if (this.game.Data.StringListObj[this.strId].Length == -1)
          txt = "No rows";
        tsubpart = (SubPartClass) new TextPartClass(txt, this.game.MarcFont4, 120, 35, true, tBlackBack: true, tMarc: true);
        this.pageNumberId = this.AddSubPart(ref tsubpart, 100 + num1, num3, 120, 35, 0);
      }
      if (this.detailx > -1 & this.detaily > -1)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Edit cell", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (830 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.editId = this.AddSubPart(ref tsubpart, 830 + num1, num3, 150, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Edit cell", 150, "First select a cell you want to edit the value of", ref this.OwnBitmap, 830 + num1, num3, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.editidb = this.AddSubPart(ref tsubpart, 830 + num1, num3, 150, 35, 1);
      }
      tsubpart = (SubPartClass) new TextButtonPartClass("Add row", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (510 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addId = this.AddSubPart(ref tsubpart, 510 + num1, num3, 150, 35, 1);
      if (this.detaily > -1)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Remove row", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (670 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.remId = this.AddSubPart(ref tsubpart, 670 + num1, num3, 150, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Remove row", 150, "First select a row you want to remove", ref this.OwnBitmap, 670 + num1, num3, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.remIdb = this.AddSubPart(ref tsubpart, 670 + num1, num3, 150, 35, 1);
      }
      if (this.mode != 1)
        return;
      tsubpart = (SubPartClass) new TextButtonPartClass("Mod Export Csv", 150, "Special CSV export that has pre-prepared the csv for importing into the 'Modify existing table' tables of a Mod Library.", ref this.OwnBitmap, 10 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.importCsv = this.AddSubPart(ref tsubpart, 10 + num1, num3, 150, 35, 1);
      tsubpart = (SubPartClass) new TextButtonPartClass("Export Csv", 150, "Normal CSV export", ref this.OwnBitmap, 170 + num1, num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.exportCsv = this.AddSubPart(ref tsubpart, 170 + num1, num3, 150, 35, 1);
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
            if (num1 == this.editId)
            {
              if (this.detaily > -1 && this.game.Data.StringListObj[this.strId].LookUpCol[this.detaily] > 0)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 150, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass.SetFlag(true);
                windowReturnClass.AddCommand(4, 67);
                return windowReturnClass;
              }
              this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = Interaction.InputBox("Give new value of cell, please.", "Shadow Empire : Planetary Conquest", this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily]);
              if (this.mode == 2)
                this.DoStuff();
              int index2 = this.SubpartNr(this.tableId);
              if (index2 > -1)
                this.SubPartFlag[index2] = true;
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.remId)
            {
              this.game.Data.StringListObj[this.strId].RemoveRow(this.detailx);
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.addId)
            {
              int index3;
              if (this.detailx == -1)
              {
                this.game.Data.StringListObj[this.strId].AddRow(this.game.Data.StringListObj[this.strId].Length);
                index3 = this.game.Data.StringListObj[this.strId].Length;
              }
              else
              {
                this.game.Data.StringListObj[this.strId].AddRow(this.detailx);
                index3 = this.detailx + 1;
              }
              if (this.game.Data.Product == 7)
              {
                int width1 = this.game.Data.StringListObj[this.strId].Width;
                for (int index4 = 0; index4 <= width1; ++index4)
                {
                  if (this.game.Data.StringListObj[this.strId].SSID[index4] > 0 & this.game.Data.StringListObj[this.strId].SSID[index4] < 50)
                  {
                    int num2 = 0;
                    int stringListCounter = this.game.Data.StringListCounter;
                    for (int index5 = 0; index5 <= stringListCounter; ++index5)
                    {
                      if (this.game.Data.StringListObj[index5].Length > -1)
                      {
                        int width2 = this.game.Data.StringListObj[index5].Width;
                        for (int index6 = 0; index6 <= width2; ++index6)
                        {
                          if (this.game.Data.StringListObj[index5].SSID[index6] > 0 & this.game.Data.StringListObj[index5].SSID[index6] < 50)
                          {
                            int length = this.game.Data.StringListObj[index5].Length;
                            for (int index7 = 0; index7 <= length; ++index7)
                            {
                              int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[index5].Data[index7, index6]));
                              if (num3 > num2)
                                num2 = num3;
                            }
                          }
                        }
                      }
                    }
                    ++num2;
                    this.game.Data.StringListObj[this.strId].Data[index3, index4] = num2.ToString();
                  }
                }
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.forwardId)
            {
              ++this.detailx;
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.backwardId)
            {
              --this.detailx;
              if (this.detailx < 0)
                this.detailx = 0;
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.fullForwardId)
            {
              this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.fullBackwardId)
            {
              this.detailx = 0;
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.switchId)
            {
              this.mode = this.mode != 1 ? 1 : 2;
              this.Tabby();
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.tableId)
            {
              Coordinate coordinate = this.SubPartList[index1].Click2(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (coordinate.x > -1)
              {
                if (this.mode == 1)
                {
                  this.detailx = coordinate.x;
                  this.detaily = coordinate.y;
                  if (this.detaily > this.game.Data.StringListObj[this.strId].Width)
                    this.detaily = this.game.Data.StringListObj[this.strId].Width;
                  if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                    this.detailx = this.game.Data.StringListObj[this.strId].Length;
                }
                else
                {
                  this.detaily = coordinate.x;
                  if (this.detaily > this.game.Data.StringListObj[this.strId].Width)
                    this.detaily = this.game.Data.StringListObj[this.strId].Width;
                }
                this.RefreshCellInfo();
                this.Tabby();
                this.game.EditObj.matrixSubPart_BlockMouseUpScroller1time = true;
              }
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.text1id)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.listId)
            {
              int num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (num4 <= -1)
                return windowReturnClass;
              this.SubPartFlag[index1] = true;
              this.strId = num4;
              this.detailx = -1;
              this.detaily = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            if (num1 == this.libTableId)
            {
              int num5 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (num5 > -1)
              {
                this.SubPartFlag[index1] = true;
                this.libSelect = num5;
                this.strId = -1;
                this.detailx = -1;
                this.detaily = -1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                windowReturnClass.AddCommand(4, 67);
                return windowReturnClass;
              }
              if (num5 != -2)
                return windowReturnClass;
              this.SubPartFlag[index1] = true;
              this.libSelect = -1;
              this.detailx = -1;
              this.detaily = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              windowReturnClass.AddCommand(4, 67);
              return windowReturnClass;
            }
            string str1;
            if (num1 == this.exportCsv)
            {
              string str2 = this.game.HandyFunctionsObj.SaveSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Give save name...", this.game.AppPath + "csv/", false);
              if (Strings.Len(str2) < 2)
              {
                int num6 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                bool flag1 = false;
                bool flag2 = false;
                try
                {
                  StreamWriter text = File.CreateText(str2);
                  try
                  {
                    if (!flag1)
                    {
                      string str3 = "";
                      int width3 = this.game.Data.StringListObj[this.strId].Width;
                      for (int index8 = 0; index8 <= width3; ++index8)
                      {
                        if (index8 > 0)
                          str3 += "\t";
                        str3 += this.game.Data.StringListObj[this.strId].ColumnName[index8];
                      }
                      text.WriteLine(str3);
                      int length = this.game.Data.StringListObj[this.strId].Length;
                      for (int row = 0; row <= length; ++row)
                      {
                        string str4 = "";
                        int width4 = this.game.Data.StringListObj[this.strId].Width;
                        for (int col = 0; col <= width4; ++col)
                        {
                          if (col > 0)
                            str4 += "\t";
                          string valueText = this.game.Data.StringListObj[this.strId].Data[row, col];
                          if (flag2)
                            valueText = this.game.Data.StringListObj[this.strId].GetValue(ref this.game.Data, row, col, this.game.Data.StringListObj[this.strId].LibId.libSlot).valueText;
                          str4 += valueText;
                        }
                        text.WriteLine(str4);
                      }
                    }
                    else
                    {
                      str1 = "";
                      int width = this.game.Data.StringListObj[this.strId].Width;
                      for (int index9 = 0; index9 <= width; ++index9)
                      {
                        string str5 = this.game.Data.StringListObj[this.strId].ColumnName[index9];
                        int length = this.game.Data.StringListObj[this.strId].Length;
                        for (int index10 = 0; index10 <= length; ++index10)
                          str5 = str5 + "\t" + this.game.Data.StringListObj[this.strId].Data[index10, index9];
                        text.WriteLine(str5);
                      }
                    }
                    text.Close();
                    int num7 = (int) Interaction.MsgBox((object) "Export has been written to the csv/ directory", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    text.Close();
                    int num8 = (int) Interaction.MsgBox((object) ("Problem writing: " + exception.Message), Title: ((object) "Shadow Empire : Planetary Conquest"));
                    ProjectData.ClearProjectError();
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  int num9 = (int) Interaction.MsgBox((object) "Problem writing. Check if the file is not opened in other application please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  ProjectData.ClearProjectError();
                }
              }
            }
            else if (num1 == this.importCsv)
            {
              string str6 = this.game.HandyFunctionsObj.SaveSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Give save name...", this.game.AppPath + "csv/", false);
              if (Strings.Len(str6) < 2)
              {
                int num10 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                bool flag3 = false;
                bool flag4 = false;
                this.game.Data.AddStringList();
                int strId = this.strId;
                this.game.Data.StringListObj[this.game.Data.StringListCounter] = this.game.Data.StringListObj[strId].Clone();
                this.strId = this.game.Data.StringListCounter;
                this.game.Data.StringListObj[this.strId].AddCol(-1, "Comment");
                this.game.Data.StringListObj[this.strId].AddCol(0, "Operation Type");
                this.game.Data.StringListObj[this.strId].AddCol(1, "Library Name");
                this.game.Data.StringListObj[this.strId].AddCol(2, "Library Id");
                this.game.Data.StringListObj[this.strId].AddCol(3, "Row#");
                this.game.Data.StringListObj[this.strId].AddCol(4, "Col#");
                int length1 = this.game.Data.StringListObj[this.strId].Length;
                for (int index11 = 0; index11 <= length1; ++index11)
                {
                  this.game.Data.StringListObj[this.strId].Data[index11, 0] = "";
                  this.game.Data.StringListObj[this.strId].Data[index11, 1] = "2";
                  this.game.Data.StringListObj[this.strId].Data[index11, 2] = this.game.Data.LibraryObj[this.game.Data.StringListObj[strId].LibId.libSlot].name;
                  if (this.game.Data.StringListObj[strId].LibId.id > -1)
                    this.game.Data.StringListObj[this.strId].Data[index11, 3] = this.game.Data.StringListObj[strId].LibId.id.ToString();
                  else
                    this.game.Data.StringListObj[this.strId].Data[index11, 3] = this.game.Data.StringListObj[strId].ID.ToString();
                  this.game.Data.StringListObj[this.strId].Data[index11, 4] = index11.ToString();
                  this.game.Data.StringListObj[this.strId].Data[index11, 5] = "";
                }
                try
                {
                  StreamWriter text = File.CreateText(str6);
                  try
                  {
                    if (!flag3)
                    {
                      string str7 = "";
                      int width5 = this.game.Data.StringListObj[this.strId].Width;
                      for (int index12 = 0; index12 <= width5; ++index12)
                      {
                        if (index12 > 0)
                          str7 += "\t";
                        str7 += this.game.Data.StringListObj[this.strId].ColumnName[index12];
                      }
                      text.WriteLine(str7);
                      int length2 = this.game.Data.StringListObj[this.strId].Length;
                      for (int row = 0; row <= length2; ++row)
                      {
                        string str8 = "";
                        int width6 = this.game.Data.StringListObj[this.strId].Width;
                        for (int col = 0; col <= width6; ++col)
                        {
                          if (col > 0)
                            str8 += "\t";
                          string valueText = this.game.Data.StringListObj[this.strId].Data[row, col];
                          if (flag4)
                            valueText = this.game.Data.StringListObj[this.strId].GetValue(ref this.game.Data, row, col, this.game.Data.StringListObj[this.strId].LibId.libSlot).valueText;
                          str8 += valueText;
                        }
                        text.WriteLine(str8);
                      }
                    }
                    else
                    {
                      str1 = "";
                      int width = this.game.Data.StringListObj[this.strId].Width;
                      for (int index13 = 0; index13 <= width; ++index13)
                      {
                        string str9 = this.game.Data.StringListObj[this.strId].ColumnName[index13];
                        int length3 = this.game.Data.StringListObj[this.strId].Length;
                        for (int index14 = 0; index14 <= length3; ++index14)
                          str9 = str9 + "\t" + this.game.Data.StringListObj[this.strId].Data[index14, index13];
                        text.WriteLine(str9);
                      }
                    }
                    text.Close();
                    int num11 = (int) Interaction.MsgBox((object) "Export has been written to the csv/ directory", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    text.Close();
                    int num12 = (int) Interaction.MsgBox((object) ("Problem writing: " + exception.Message), Title: ((object) "Shadow Empire : Planetary Conquest"));
                    ProjectData.ClearProjectError();
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  int num13 = (int) Interaction.MsgBox((object) "Problem writing. Check if the file is not opened in other application please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  ProjectData.ClearProjectError();
                }
                this.strId = strId;
                this.game.Data.RemoveStringList(this.game.Data.StringListCounter);
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
  }
}
