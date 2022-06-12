// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditTableWindowClass
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
  public class SimpleEditTableWindowClass : WindowClass
  {
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

    public SimpleEditTableWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Tables")
    {
      this.strId = -1;
      this.detailx = -1;
      this.detaily = -1;
      this.libSelect = -1;
      this.mode = 1;
      this.DoStuff();
    }

    public void RefreshCellInfo()
    {
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
      this.cellinfoid = this.AddSubPart(ref tsubpart, 12, 49, this.game.ScreenWidth - 32, 20, 0);
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
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      int num3 = -1;
      int num4;
      if (num2 > 10)
        num4 = (int) Math.Round((double) (num2 - 10) * 0.33 / 16.0);
      this.libListObj = new ListClass();
      this.libListObj.add("All", -2);
      if (this.libSelect == -1)
        num3 = 0;
      int num5 = 0;
      if (num1 >= 256)
      {
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Libraries:", this.game.MarcFont4, 10 + num1 - 256, (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 30.0), Color.White);
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
            ++num5;
            this.libListObj.add(Conversion.Str((object) index1) + ") " + this.game.Data.LibraryObj[index1].name, index1);
            if (this.libSelect == index1)
              num3 = num5;
          }
        }
        if (this.libListObj.ListCount > 0)
        {
          ListClass libListObj = this.libListObj;
          int tlistsize = 9 + num4;
          int tlistselect = num3;
          GameClass game = this.game;
          ref Bitmap local1 = ref this.OwnBitmap;
          int bbx = 10 + num1 - 256;
          int bby = (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0);
          Font font = (Font) null;
          ref Font local2 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(libListObj, tlistsize, 250, tlistselect, game, true, "Tables", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx, bby: bby, tMarcStyle: true, overruleFont: (ref local2));
          this.libTableId = this.AddSubPart(ref tsubpart, 10 + num1 - 256, (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0), 250, (12 + num4) * 16, 0);
        }
      }
      string tstring = "Tables:";
      DrawMod.DrawTextColouredMarc(ref objgraphics, tstring, this.game.MarcFont4, 10 + num1, (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 30.0), Color.White);
      int num6 = -1;
      int num7 = -1;
      this.listObj = new ListClass();
      int stringListCounter1 = this.game.Data.StringListCounter;
      for (int index = 0; index <= stringListCounter1; ++index)
      {
        if (this.game.Data.StringListObj[index].Editable && this.game.Data.StringListObj[index].LibId.libSlot == this.libSelect | this.libSelect == -1)
        {
          ++num6;
          this.listObj.add(Conversion.Str((object) index) + ") " + this.game.Data.StringListObj[index].Name, index);
          if (num7 == -1)
            num7 = 0;
          if (this.strId == -1)
            this.strId = index;
          if (this.strId == index)
            num7 = num6;
        }
      }
      if (num7 > num6)
        num7 = 0;
      if (num7 == -1)
        this.strId = -1;
      SubPartClass tsubpart1;
      if (this.game.Data.StringListCounter > -1)
      {
        ListClass listObj = this.listObj;
        int tlistsize = 9 + num4;
        int tlistselect = num7;
        GameClass game = this.game;
        ref Bitmap local3 = ref this.OwnBitmap;
        int bbx = 10 + num1;
        int bby = (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0);
        Font font = (Font) null;
        ref Font local4 = ref font;
        tsubpart1 = (SubPartClass) new ListSubPartClass(listObj, tlistsize, 250, tlistselect, game, true, "Tables", tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local3), bbx: bbx, bby: bby, tMarcStyle: true, overruleFont: (ref local4));
        this.listId = this.AddSubPart(ref tsubpart1, 10 + num1, (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 55.0 + 50.0), 250, (12 + num4) * 16, 0);
      }
      if (this.strId <= -1)
        return;
      if (this.mode == 1)
      {
        tsubpart1 = (SubPartClass) new MatrixSubPartClass(this.game.Data.StringListObj[this.strId], 13 + (int) Math.Round((double) num2 * 0.66 / 24.0), Math.Max(1000, this.game.ScreenWidth - 24), this.detailx, this.detaily, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 10, bby: 72, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true, tLibSlot: this.game.Data.StringListObj[this.strId].LibId.libSlot);
        this.tableId = this.AddSubPart(ref tsubpart1, 10, 72, Math.Max(1000, this.game.ScreenWidth - 24), (int) Math.Round((15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0), 0);
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
          tsubpart1 = (SubPartClass) new MatrixSubPartClass(tListobj, 13 + (int) Math.Round((double) num2 * 0.66 / 24.0), Math.Max(1000, this.game.ScreenWidth - 24), this.detaily, 1, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 10, bby: 72, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true, tTwoColumnVariant: 200);
          this.tableId = this.AddSubPart(ref tsubpart1, 10, 72, Math.Max(1000, this.game.ScreenWidth - 24), (int) Math.Round((15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0), 0);
        }
        else
          DrawMod.DrawTextColouredMarcCenter(ref objgraphics, "No rows in table", this.game.MarcFont4, num1 + 512, 256 + (int) Math.Round((double) num2 * 0.33), Color.White);
      }
      string str1 = " (Id " + this.game.Data.StringListObj[this.strId].ID.ToString();
      if (this.game.Data.StringListObj[this.strId].LibId.libSlot > -1)
        str1 = str1 + ", LibId " + this.game.Data.StringListObj[this.strId].ID.ToString();
      string str2 = str1 + ")";
      DrawMod.DrawTextColouredMarc(ref objgraphics, this.game.Data.StringListObj[this.strId].Name + str2 + " information:", this.game.MarcFont3, 310 + num1, 72 + (15 + (int) Math.Round((double) num2 * 0.66 / 24.0)) * 24 + 55 + 30, Color.White);
      tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, (int) Math.Round(Math.Max(700.0, (double) this.game.ScreenWidth / 2.0 - 324.0)), 4 + (int) Math.Round((double) num2 * 0.33 / 27.0), this.game.MarcFont4, this.game.Data.StringListObj[this.strId].Description, 27, ref this.OwnBitmap, 310 + num1, (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 62.0 + 30.0));
      this.text1id = this.AddSubPart(ref tsubpart1, 310 + num1, (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 62.0 + 30.0), (int) Math.Round(Math.Max(700.0, (double) this.game.ScreenWidth / 2.0 - 324.0)), Math.Max(120, this.game.ScreenHeight - 648), 0);
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
      int num3 = (int) Math.Round(72.0 + (15.0 + (double) (int) Math.Round((double) num2 * 0.66) / 24.0) * 24.0 + 28.0);
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
      tsubpart = (SubPartClass) new TextButtonPartClass("Import Csv", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (10 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.importCsv = this.AddSubPart(ref tsubpart, 10 + num1, num3, 150, 35, 1);
      tsubpart = (SubPartClass) new TextButtonPartClass("Export Csv", 150, tBackbitmap: (ref this.OwnBitmap), bbx: (170 + num1), bby: num3, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.exportCsv = this.AddSubPart(ref tsubpart, 170 + num1, num3, 150, 35, 1);
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
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
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.RegimeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 106, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.HistoricalUnitId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 144, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.HistoricalUnitModelId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 111, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.OfficerId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 112, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.LandscapeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 113, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.PeopleId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 114, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.RiverId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 115, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.LocationTypeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, (int) sbyte.MaxValue, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.RoadId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 116, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.SFTypeId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 145, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.ActionCardId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 146, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.SmallGfxId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 140, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.EventPicId)
              {
                new Form3((Form) this.formref).Initialize(this.game.Data, 141, this.strId, this.detailx, this.game, this.detaily);
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.DateString)
              {
                if (this.game.Data.AlternateRound < 1)
                {
                  this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = Interaction.InputBox("Give round number", "Shadow Empire : Planetary Conquest");
                }
                else
                {
                  string str1 = Interaction.InputBox("Give new Day.", "Shadow Empire : Planetary Conquest");
                  this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = "";
                  if (Operators.CompareString(str1, "", false) != 0)
                  {
                    string str2 = Conversions.ToString(Conversion.Val(str1));
                    if (Conversions.ToInteger(str2) >= 1 & Conversions.ToInteger(str2) <= 31)
                    {
                      string str3 = str2;
                      string str4 = Interaction.InputBox("Give new Month.", "Shadow Empire : Planetary Conquest");
                      if (Operators.CompareString(str4, "", false) != 0)
                      {
                        string str5 = Conversions.ToString(Conversion.Val(str4));
                        if (Conversions.ToInteger(str5) >= 1 & Conversions.ToInteger(str5) <= 12)
                        {
                          string str6 = str3 + "/" + str5;
                          string str7 = Interaction.InputBox("Give new Year.", "Shadow Empire : Planetary Conquest");
                          if (Operators.CompareString(str7, "", false) != 0)
                          {
                            string str8 = Conversions.ToString(Conversion.Val(str7));
                            if (Conversions.ToInteger(str8) >= 1 & Conversions.ToInteger(str8) <= 9999)
                              this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = str6 + "/" + str8;
                          }
                        }
                      }
                    }
                  }
                }
                if (this.mode == 2)
                  this.DoStuff();
                int index2 = this.SubpartNr(this.tableId);
                if (index2 > -1)
                  this.SubPartFlag[index2] = true;
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (this.game.Data.StringListObj[this.strId].ColValueType[this.detaily] == NewEnums.LibVarValueType.YesNo)
              {
                if (Interaction.MsgBox((object) "Set value of cell to Yes or No?", MsgBoxStyle.YesNo, (object) "Cell value") == MsgBoxResult.Yes)
                  this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = "1";
                else
                  this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = "0";
                if (this.mode == 2)
                  this.DoStuff();
                int index3 = this.SubpartNr(this.tableId);
                if (index3 > -1)
                  this.SubPartFlag[index3] = true;
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily] = Interaction.InputBox("Give new value of cell, please.", "Shadow Empire : Planetary Conquest", this.game.Data.StringListObj[this.strId].Data[this.detailx, this.detaily]);
              if (this.mode == 2)
                this.DoStuff();
              int index4 = this.SubpartNr(this.tableId);
              if (index4 > -1)
                this.SubPartFlag[index4] = true;
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.remId)
            {
              this.game.Data.StringListObj[this.strId].RemoveRow(this.detailx);
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.addId)
            {
              int index5;
              if (this.detailx == -1)
              {
                this.game.Data.StringListObj[this.strId].AddRow(this.game.Data.StringListObj[this.strId].Length);
                index5 = this.game.Data.StringListObj[this.strId].Length;
              }
              else
              {
                this.game.Data.StringListObj[this.strId].AddRow(this.detailx);
                index5 = this.detailx + 1;
              }
              if (this.game.Data.Product == 7)
              {
                int width1 = this.game.Data.StringListObj[this.strId].Width;
                for (int index6 = 0; index6 <= width1; ++index6)
                {
                  if (this.game.Data.StringListObj[this.strId].SSID[index6] > 0 & this.game.Data.StringListObj[this.strId].SSID[index6] < 50)
                  {
                    int num2 = 0;
                    int stringListCounter = this.game.Data.StringListCounter;
                    for (int index7 = 0; index7 <= stringListCounter; ++index7)
                    {
                      if (this.game.Data.StringListObj[index7].Length > -1)
                      {
                        int width2 = this.game.Data.StringListObj[index7].Width;
                        for (int index8 = 0; index8 <= width2; ++index8)
                        {
                          if (this.game.Data.StringListObj[index7].SSID[index8] > 0 & this.game.Data.StringListObj[index7].SSID[index8] < 50)
                          {
                            int length = this.game.Data.StringListObj[index7].Length;
                            for (int index9 = 0; index9 <= length; ++index9)
                            {
                              int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[index7].Data[index9, index8]));
                              if (num3 > num2)
                                num2 = num3;
                            }
                          }
                        }
                      }
                    }
                    ++num2;
                    this.game.Data.StringListObj[this.strId].Data[index5, index6] = num2.ToString();
                  }
                }
              }
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.forwardId)
            {
              ++this.detailx;
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
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
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.fullForwardId)
            {
              this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.fullBackwardId)
            {
              this.detailx = 0;
              if (this.detailx > this.game.Data.StringListObj[this.strId].Length)
                this.detailx = this.game.Data.StringListObj[this.strId].Length;
              this.Tabby();
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.switchId)
            {
              this.mode = this.mode != 1 ? 1 : 2;
              this.Tabby();
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
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
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.text1id)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.listId)
            {
              int num4 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num4 > -1)
              {
                this.strId = num4;
                this.detailx = -1;
                this.detaily = -1;
                this.DoStuff();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.libTableId)
            {
              int num5 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num5 > -1)
              {
                this.libSelect = num5;
                this.strId = -1;
                this.detailx = -1;
                this.detaily = -1;
                this.DoStuff();
              }
              else if (num5 == -2)
              {
                this.libSelect = -1;
                this.detailx = -1;
                this.detaily = -1;
                this.DoStuff();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.importCsv)
            {
              string str9 = this.game.HandyFunctionsObj.LoadSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Select file to import...", this.game.AppPath + "csv/", false);
              while (this.game.Data.StringListObj[this.strId].Length > -1)
                this.game.Data.StringListObj[this.strId].RemoveRow(this.game.Data.StringListObj[this.strId].Length);
              if (Strings.Len(str9) < 2)
              {
                int num6 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                WindowReturnClass windowReturnClass2;
                try
                {
                  StreamReader streamReader = File.OpenText(str9);
                  int num7 = 0;
                  string str10 = ",";
                  int index10 = 0;
                  try
                  {
                    bool flag1 = false;
                    if (this.game.Data.Product >= 7 && Interaction.MsgBox((object) "Inverse import?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                    {
                      flag1 = true;
                      num7 = 2;
                    }
                    while (!streamReader.EndOfStream)
                    {
                      string str11 = streamReader.ReadLine();
                      if ((uint) Strings.InStr(str11, "sep=") > 0U)
                      {
                        str10 = Strings.Mid(str11, 5, 1);
                        num7 = 1;
                      }
                      else
                      {
                        switch (num7)
                        {
                          case 0:
                            if (Strings.InStr(str11, "\t") > 0)
                              str10 = "\t";
                            else if (Strings.InStr(str11, ",") > 0)
                              str10 = ",";
                            else if (Strings.InStr(str11, ";") > 0)
                              str10 = ";";
                            num7 = 2;
                            continue;
                          case 1:
                            num7 = 2;
                            continue;
                          case 2:
                            bool flag2 = true;
                            while (flag2)
                            {
                              flag2 = false;
                              int num8 = Strings.InStr(str11, "\"");
                              if (num8 > 0)
                              {
                                int num9 = Strings.InStr(num8 + 1, str11, "\"");
                                if (num9 > 0)
                                {
                                  string str12 = Strings.Left(str11, num8 - 1);
                                  string str13 = Strings.Mid(str11, num8 + 1, num9 - num8 - 1);
                                  string str14 = Strings.Mid(str11, num9 + 1);
                                  string str15 = str13.Replace(",", "¢");
                                  str11 = str12 + str15 + str14;
                                  flag2 = true;
                                }
                              }
                            }
                            string[] strArray = str11.Split(Conversions.ToChar(str10));
                            if (!flag1 && strArray.GetUpperBound(0) > this.game.Data.StringListObj[this.strId].Width & index10 == 0 && Interaction.MsgBox((object) "Allow adding columns to table?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                            {
                              int num10 = strArray.GetUpperBound(0) - this.game.Data.StringListObj[this.strId].Width;
                              for (int index11 = 1; index11 <= num10; ++index11)
                                this.game.Data.StringListObj[this.strId].AddCol(this.game.Data.StringListObj[this.strId].Width);
                            }
                            if (!flag1)
                            {
                              this.game.Data.StringListObj[this.strId].AddRow(index10 - 1);
                              int upperBound = strArray.GetUpperBound(0);
                              for (int index12 = 0; index12 <= upperBound; ++index12)
                              {
                                if (index12 <= this.game.Data.StringListObj[this.strId].Width)
                                {
                                  string str16 = strArray[index12].Replace("¢", ",");
                                  this.game.Data.StringListObj[this.strId].Data[index10, index12] = str16;
                                }
                              }
                            }
                            else
                            {
                              if (index10 > this.game.Data.StringListObj[this.strId].Width)
                                this.game.Data.StringListObj[this.strId].AddCol(this.game.Data.StringListObj[this.strId].Width);
                              int upperBound = strArray.GetUpperBound(0);
                              for (int index13 = 0; index13 <= upperBound; ++index13)
                              {
                                if (index13 - 1 > this.game.Data.StringListObj[this.strId].Length)
                                  this.game.Data.StringListObj[this.strId].AddRow(this.game.Data.StringListObj[this.strId].Length);
                                string str17 = strArray[index13].Replace("¢", ",");
                                if (index13 == 0)
                                  this.game.Data.StringListObj[this.strId].ColumnName[index10] = str17;
                                else
                                  this.game.Data.StringListObj[this.strId].Data[index13 - 1, index10] = str17;
                              }
                            }
                            ++index10;
                            continue;
                          default:
                            continue;
                        }
                      }
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    streamReader.Close();
                    this.game.Data.LoadGraphics(this.formref);
                    int num11 = (int) Interaction.MsgBox((object) ("Import problem encountered: '" + exception.Message + "'. Your current data might be corrupted. "), Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.RemoveSubPart(this.tableId);
                    this.tableId = 0;
                    this.DoStuff();
                    windowReturnClass1.SetFlag(true);
                    windowReturnClass2 = windowReturnClass1;
                    ProjectData.ClearProjectError();
                    goto label_216;
                  }
                  streamReader.Close();
                  this.game.Data.LoadGraphics(this.formref);
                  int num12 = (int) Interaction.MsgBox((object) "Import finished", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.RemoveSubPart(this.tableId);
                  this.tableId = 0;
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  windowReturnClass2 = windowReturnClass1;
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  int num13 = (int) Interaction.MsgBox((object) "Error opening file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  ProjectData.ClearProjectError();
                  continue;
                }
label_216:
                return windowReturnClass2;
              }
            }
            else if (num1 == this.exportCsv)
            {
              string str18 = this.game.HandyFunctionsObj.SaveSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Give save name...", this.game.AppPath + "csv/", false);
              if (Strings.Len(str18) < 2)
              {
                int num14 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                bool flag3 = false;
                bool flag4 = false;
                if (this.game.Data.Product >= 7)
                {
                  if (Interaction.MsgBox((object) "Inverse export?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                    flag3 = true;
                }
                try
                {
                  StreamWriter text = File.CreateText(str18);
                  try
                  {
                    if (!flag3)
                    {
                      string str19 = "";
                      int width3 = this.game.Data.StringListObj[this.strId].Width;
                      for (int index14 = 0; index14 <= width3; ++index14)
                      {
                        if (index14 > 0)
                          str19 += "\t";
                        str19 += this.game.Data.StringListObj[this.strId].ColumnName[index14];
                      }
                      text.WriteLine(str19);
                      int length = this.game.Data.StringListObj[this.strId].Length;
                      for (int row = 0; row <= length; ++row)
                      {
                        string str20 = "";
                        int width4 = this.game.Data.StringListObj[this.strId].Width;
                        for (int col = 0; col <= width4; ++col)
                        {
                          if (col > 0)
                            str20 += "\t";
                          string valueText = this.game.Data.StringListObj[this.strId].Data[row, col];
                          if (flag4)
                            valueText = this.game.Data.StringListObj[this.strId].GetValue(ref this.game.Data, row, col, this.game.Data.StringListObj[this.strId].LibId.libSlot).valueText;
                          str20 += valueText;
                        }
                        text.WriteLine(str20);
                      }
                    }
                    else
                    {
                      int width = this.game.Data.StringListObj[this.strId].Width;
                      for (int index15 = 0; index15 <= width; ++index15)
                      {
                        string str21 = this.game.Data.StringListObj[this.strId].ColumnName[index15];
                        int length = this.game.Data.StringListObj[this.strId].Length;
                        for (int index16 = 0; index16 <= length; ++index16)
                          str21 = str21 + "\t" + this.game.Data.StringListObj[this.strId].Data[index16, index15];
                        text.WriteLine(str21);
                      }
                    }
                    text.Close();
                    int num15 = (int) Interaction.MsgBox((object) "Export has been written to the csv/ directory", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    text.Close();
                    int num16 = (int) Interaction.MsgBox((object) ("Problem writing: " + exception.Message), Title: ((object) "Shadow Empire : Planetary Conquest"));
                    ProjectData.ClearProjectError();
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  int num17 = (int) Interaction.MsgBox((object) "Problem writing. Check if the file is not opened in other application please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  ProjectData.ClearProjectError();
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
  }
}
