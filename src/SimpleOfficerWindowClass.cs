// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleOfficerWindowClass
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
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimpleOfficerWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int cellinfoid;
    private int tableId;
    private int loadId;
    private int text1id;
    private int loadMasterId;
    private int detailnr;
    private int addId;
    private int versionid;
    private int addReinf;
    private int exportCsv;
    private int importCsv;
    private int removeReinf;
    private int RenameReinf;
    private int RenameReinfb;
    private int RemoveReinfb;
    private int a1id;
    private int a2id;
    private int a3id;
    private int removeId;
    private int changeId;
    private int exitId;
    private int saveId;
    private int editId;
    private int removeIdb;
    private int saveIdb;
    private int tab1id;
    private int tab2id;
    private int tab3id;
    private int tab4id;
    private int tab1idb;
    private int tab2idb;
    private int tab3idb;
    private int tab4idb;
    private int editIdb;
    private int strId;
    private int detailx;
    private int detaily;
    private int tabId;
    private StringListClass stringy;
    private int VarsStartOn;
    private bool AddNew;
    private bool Change;
    private int currentPplNr;
    private int currentUnitNr;
    private int currentHisNr;
    private int currentInstNr;
    private int[] ColIsVar;
    private string masterfileStart;
    private int oldTopX;
    private int oldTopY;

    public SimpleOfficerWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight, 9, tDoBorders: 1, tHeaderString: "Intermediate Officer Editor")
    {
      this.ColIsVar = new int[100];
      this.detailx = -1;
      this.detaily = -1;
      this.detailnr = -1;
      this.tabId = 1;
      this.currentPplNr = -1;
      this.currentUnitNr = -1;
      this.currentHisNr = -1;
      this.currentInstNr = -1;
      this.AddNew = false;
      this.Change = false;
      this.masterfileStart = this.game.Data.MasterFile;
      this.game.EditObj.TempSFType = -1;
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
      else
        txt = "(row" + this.detailx.ToString() + ",col" + this.detaily.ToString() + ")             " + this.stringy.ColumnName[this.detaily].ToUpper() + "                " + this.stringy.Data[this.detailx, this.detaily];
      SubPartClass tsubpart = (SubPartClass) new TextPartClass(txt, this.game.MarcFont4, this.game.ScreenWidth - 323, 20, false, tMarc: true);
      this.cellinfoid = this.AddSubPart(ref tsubpart, 312, 152, this.game.ScreenWidth - 323, 20, 0);
    }

    public override void DoRefresh()
    {
      if (!(this.Change & (this.currentUnitNr > -1 | this.currentHisNr > -1 | this.currentInstNr > -1 | this.currentPplNr > -1)))
        return;
      if (this.tableId > 0)
        this.RemoveSubPart(this.tableId);
      this.tableId = 0;
      this.Change = false;
      this.currentUnitNr = -1;
      this.currentHisNr = -1;
      this.currentPplNr = -1;
      this.currentInstNr = -1;
      this.DoStuff();
    }

    public void PopUpRefresh() => this.DoStuff();

    public void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = this.game.ScreenHeight - 768;
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight, -1);
      if (this.versionid > 0)
        this.RemoveSubPart(this.versionid);
      if (this.addId > 0)
        this.RemoveSubPart(this.addId);
      if (this.removeId > 0)
        this.RemoveSubPart(this.removeId);
      if (this.editId > 0)
        this.RemoveSubPart(this.editId);
      if (this.saveId > 0)
        this.RemoveSubPart(this.saveId);
      if (this.removeIdb > 0)
        this.RemoveSubPart(this.removeIdb);
      if (this.editIdb > 0)
        this.RemoveSubPart(this.editIdb);
      if (this.saveIdb > 0)
        this.RemoveSubPart(this.saveIdb);
      if (this.exitId > 0)
        this.RemoveSubPart(this.exitId);
      if (this.a1id > 0)
        this.RemoveSubPart(this.a1id);
      if (this.a2id > 0)
        this.RemoveSubPart(this.a2id);
      if (this.a3id > 0)
        this.RemoveSubPart(this.a3id);
      if (this.cellinfoid > 0)
      {
        this.RemoveSubPart(this.cellinfoid);
        this.cellinfoid = 0;
      }
      if (this.loadId > 0)
        this.RemoveSubPart(this.loadId);
      if (this.tab1id > 0)
        this.RemoveSubPart(this.tab1id);
      if (this.tab2id > 0)
        this.RemoveSubPart(this.tab2id);
      if (this.tab3id > 0)
        this.RemoveSubPart(this.tab3id);
      if (this.tab4id > 0)
        this.RemoveSubPart(this.tab4id);
      if (this.tab1idb > 0)
        this.RemoveSubPart(this.tab1idb);
      if (this.tab2idb > 0)
        this.RemoveSubPart(this.tab2idb);
      if (this.tab3idb > 0)
        this.RemoveSubPart(this.tab3idb);
      if (this.tab4idb > 0)
        this.RemoveSubPart(this.tab4idb);
      if (this.loadMasterId > 0)
        this.RemoveSubPart(this.loadMasterId);
      if (this.addReinf > 0)
        this.RemoveSubPart(this.addReinf);
      if (this.removeReinf > 0)
        this.RemoveSubPart(this.removeReinf);
      if (this.RenameReinf > 0)
        this.RemoveSubPart(this.RenameReinf);
      if (this.RemoveReinfb > 0)
        this.RemoveSubPart(this.RemoveReinfb);
      if (this.RenameReinfb > 0)
        this.RemoveSubPart(this.RenameReinfb);
      if (this.exportCsv > 0)
        this.RemoveSubPart(this.exportCsv);
      if (this.importCsv > 0)
        this.RemoveSubPart(this.importCsv);
      if (this.listId > 0)
        this.RemoveSubPart(this.listId);
      if (this.game.Data.LibraryCounter == -1)
      {
        this.game.Data.AddLibrary();
        this.game.Data.LibraryObj[0].name = "New Officer Library";
        this.game.Data.LibraryObj[0].information = "no info specified";
        this.game.Data.LibraryObj[0].creator = "no creator specified";
      }
      if (this.game.Data.RegimeCounter == -1)
      {
        this.game.Data.AddRegime();
        this.game.Data.RegimeObj[0].Name = "Only regime in library";
      }
      this.game.Data.RegimeObj[0].libId.libSlot = 0;
      this.game.Data.RegimeObj[0].libId.id = -1;
      if (this.game.Data.PeopleCounter == -1)
      {
        this.game.Data.AddPeople();
        this.game.Data.PeopleObj[0].Name = "Only people in library";
      }
      else
        this.game.Data.PeopleObj[0].Name = "Only people in library";
      DrawMod.DrawTextColouredMarc(ref graphics, "Name:", this.game.MarcFont4, num1 + 10, 60, Color.White);
      DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.LibraryObj[0].name, this.game.MarcFont3, num1 + 10, 75, Color.White);
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Change Library Name", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 10), bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.a1id = this.AddSubPart(ref tsubpart1, num1 + 10, 100, 190, 35, 1);
      DrawMod.DrawTextColouredMarc(ref graphics, "Author:", this.game.MarcFont4, num1 + 310, 60, Color.White);
      DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.LibraryObj[0].creator, this.game.MarcFont3, num1 + 310, 75, Color.White);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Change Author", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 310), bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.a2id = this.AddSubPart(ref tsubpart2, num1 + 310, 100, 190, 35, 1);
      DrawMod.DrawTextColouredMarc(ref graphics, "Information:", this.game.MarcFont4, num1 + 610, 60, Color.White);
      DrawMod.DrawTextColouredMarc(ref graphics, Strings.Left(this.game.Data.LibraryObj[0].information, 15) + "...", this.game.MarcFont3, num1 + 610, 75, Color.White);
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Change information", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 610), bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.a3id = this.AddSubPart(ref tsubpart2, num1 + 610, 100, 190, 35, 1);
      DrawMod.DrawTextColouredMarc(ref graphics, "Version:", this.game.MarcFont4, num1 + 910, 60, Color.White);
      DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.LibraryObj[0].version.ToString(), this.game.MarcFont3, num1 + 910, 75, Color.White);
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Change version", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 910), bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.versionid = this.AddSubPart(ref tsubpart2, num1 + 910, 100, 190, 35, 1);
      if (this.detailx > -1 & this.detaily > -1 & !Information.IsNothing((object) this.stringy))
        this.RefreshCellInfo();
      int y1 = 60;
      int num3 = 40;
      DrawMod.DrawTextColouredMarc(ref graphics, "Ops:", this.game.MarcFont3, 40, y1, Color.White);
      int num4 = y1 + 40;
      if (this.game.Data.PeopleCounter > -1)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Save Officer Library", 190, "Save a officer Library", ref this.OwnBitmap, num3, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.saveId = this.AddSubPart(ref tsubpart2, num3, num4, 190, 35, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Save Officer Library", 190, "Nothing to save", ref this.OwnBitmap, num3, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.saveIdb = this.AddSubPart(ref tsubpart2, num3, num4, 190, 35, 1);
      }
      int num5 = num4 + 50;
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Load Officer Library", 190, tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num5, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadId = this.AddSubPart(ref tsubpart2, num3, num5, 190, 35, 1);
      int num6 = num5 + 50;
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Exit", 190, tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.exitId = this.AddSubPart(ref tsubpart2, num3, num6, 190, 35, 1);
      int y2 = num6 + 50;
      DrawMod.DrawTextColouredMarc(ref graphics, "Officer Card Libraries:", this.game.MarcFont3, 40, y2, Color.White);
      int y3 = y2 + 40;
      this.listObj = new ListClass();
      int num7 = -1;
      int num8 = -1;
      int libraryCounter = this.game.Data.LibraryCounter;
      for (int tdata = 0; tdata <= libraryCounter; ++tdata)
      {
        bool flag = false;
        int actionCardCounter = this.game.Data.ActionCardCounter;
        for (int index = 0; index <= actionCardCounter; ++index)
        {
          if (this.game.Data.ActionCardObj[index].LibId.libSlot == tdata)
            flag = true;
        }
        if (flag)
        {
          ++num7;
          if (this.detailnr == tdata)
            num8 = num7;
          this.listObj.add(this.game.Data.LibraryObj[tdata].name, tdata);
        }
      }
      int smallPicCounter = this.game.Data.SmallPicCounter;
      for (int index = 0; index <= smallPicCounter; ++index)
      {
        this.game.Data.SmallLibId[index].libSlot = -1;
        this.game.Data.SmallLibId[index].id = -1;
      }
      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
      for (int index = 0; index <= historicalUnitCounter; ++index)
      {
        if (this.game.Data.HistoricalUnitObj[index].CommanderName.Length > 0)
        {
          this.game.Data.HistoricalUnitObj[index].LibId.libSlot = 0;
          this.game.Data.HistoricalUnitObj[index].LibId.id = -1;
        }
      }
      ListClass listObj = this.listObj;
      int tlistselect = num8;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      int bby = y3;
      Font font = (Font) null;
      ref Font local2 = ref font;
      tsubpart2 = (SubPartClass) new ListSubPartClass(listObj, 6, 210, tlistselect, game, true, "Officer Card Libraries", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 40, bby: bby, tMarcStyle: true, overruleFont: (ref local2));
      this.listId = this.AddSubPart(ref tsubpart2, 40, y3, 210, 144, 0);
      int num9 = y3 + 135;
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Add Off Card Library", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 40, bby: num9, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addReinf = this.AddSubPart(ref tsubpart2, 40, num9, 190, 35, 1);
      int num10 = num9 + 50;
      if (this.detailnr > -1)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove Library", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 40, bby: num10, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeReinf = this.AddSubPart(ref tsubpart2, 40, num10, 190, 35, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove Library", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 40, bby: num10, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveReinfb = this.AddSubPart(ref tsubpart2, 40, num10, 190, 35, 1);
      }
      int num11 = num10 + 50;
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Reload Master", 190, "For if you want to update this library with the latest masterfile.", ref this.OwnBitmap, 40, num11, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadMasterId = this.AddSubPart(ref tsubpart2, 40, num11, 190, 35, 1);
      if (this.tabId != 1)
        return;
      this.Tab1(ref graphics);
    }

    public void Tab1(ref Graphics g)
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = this.game.ScreenHeight - 768;
      int num3 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 322) / 24.0)) - 1;
      int num4 = 172 + num3 * 24 + 56;
      if (this.tableId == 0)
      {
        this.stringy = new StringListClass(-1);
        int col1 = 1 - 1;
        this.stringy.AddCol(col1, "Slot#");
        int col2 = col1 + 1;
        this.stringy.AddCol(col2, "ID#");
        int col3 = col2 + 1;
        this.stringy.AddCol(col3, "Name");
        int col4 = col3 + 1;
        this.stringy.AddCol(col4, "Portrait");
        int col5 = col4 + 1;
        this.stringy.AddCol(col5, "Description");
        int col6 = col5 + 1;
        this.stringy.AddCol(col6, "CombatMod");
        int col7 = col6 + 1;
        this.stringy.AddCol(col7, "MoraleMod");
        int col8 = col7 + 1;
        this.stringy.AddCol(col8, "Staff Pts");
        int col9 = col8 + 1;
        this.stringy.AddCol(col9, "PP");
        int col10 = col9 + 1;
        this.stringy.AddCol(col10, "Card1");
        int col11 = col10 + 1;
        this.stringy.AddCol(col11, "Card2");
        int col12 = col11 + 1;
        this.stringy.AddCol(col12, "Card3");
        int col13 = col12 + 1;
        this.stringy.AddCol(col13, "Card4");
        int col14 = col13 + 1;
        this.stringy.AddCol(col14, "Card5");
        int col15 = col14 + 1;
        this.stringy.AddCol(col15, "Card6");
        int col16 = col15 + 1;
        this.stringy.AddCol(col16, "Card7");
        int col17 = col16 + 1;
        this.stringy.AddCol(col17, "Card8");
        int num5 = 0;
        do
        {
          if (this.game.Data.TempString[1200 + num5].Length > 0)
          {
            ++col17;
            this.stringy.AddCol(col17, this.game.Data.TempString[1200 + num5]);
            this.ColIsVar[col17] = num5;
          }
          ++num5;
        }
        while (num5 <= 99);
        int index1 = -1;
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int index2 = 0; index2 <= historicalUnitCounter; ++index2)
        {
          if (this.game.Data.HistoricalUnitObj[index2].CommanderName.Length > 0)
          {
            this.game.Data.HistoricalUnitObj[index2].TempRegime = 0;
            this.game.Data.HistoricalUnitObj[index2].People = 0;
            ++index1;
            this.stringy.AddRow(index1 - 1);
            int index3 = 1 - 1;
            this.stringy.Data[index1, index3] = index2.ToString();
            int index4 = index3 + 1;
            this.stringy.Data[index1, index4] = this.game.Data.HistoricalUnitObj[index2].ID.ToString();
            int index5 = index4 + 1;
            this.stringy.Data[index1, index5] = this.game.Data.HistoricalUnitObj[index2].CommanderName;
            int index6 = index5 + 1;
            this.stringy.Data[index1, index6] = this.game.Data.HistoricalUnitObj[index2].CommanderFileName;
            if (this.game.Data.HistoricalUnitObj[index2].CommanderSpriteID > -1)
              this.stringy.TempBmp[index1, index6] = this.game.Data.HistoricalUnitObj[index2].CommanderSpriteID;
            int index7 = index6 + 1;
            this.stringy.Data[index1, index7] = "DESCRIPT";
            int index8 = index7 + 1;
            this.stringy.Data[index1, index8] = this.game.Data.HistoricalUnitObj[index2].CombatMod.ToString();
            int index9 = index8 + 1;
            this.stringy.Data[index1, index9] = this.game.Data.HistoricalUnitObj[index2].MoraleMod.ToString();
            int index10 = index9 + 1;
            this.stringy.Data[index1, index10] = this.game.Data.HistoricalUnitObj[index2].StaffSize.ToString();
            int index11 = index10 + 1;
            this.stringy.Data[index1, index11] = this.game.Data.HistoricalUnitObj[index2].PP.ToString();
            int index12 = 0;
            do
            {
              if (index12 <= this.game.Data.HistoricalUnitObj[index2].DeckCardCounter)
              {
                ++index11;
                this.stringy.Data[index1, index11] = this.game.Data.ActionCardObj[this.game.Data.HistoricalUnitObj[index2].DeckCard[index12]].Title;
              }
              else
              {
                ++index11;
                this.stringy.Data[index1, index11] = "none";
              }
              ++index12;
            }
            while (index12 <= 7);
            int typ = 0;
            do
            {
              if (this.game.Data.TempString[1200 + typ].Length > 0)
              {
                ++index11;
                this.stringy.Data[index1, index11] = Conversions.ToString(this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(typ));
                this.game.Data.HistoricalUnitObj[index2].SetHisVarValue(typ, this.game.Data.HistoricalUnitObj[index2].GiveHisVarValue(typ), (int) Math.Round(Conversion.Val(this.game.Data.TempString[1300 + typ])));
              }
              ++typ;
            }
            while (typ <= 99);
          }
        }
        SubPartClass tsubpart = (SubPartClass) new MatrixSubPartClass(this.stringy, num3 - 1, this.game.ScreenWidth - 323, this.detailx, this.detaily, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 312, bby: 172, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true);
        this.tableId = this.AddSubPart(ref tsubpart, 312, 172, this.game.ScreenWidth - 323, num3 * 25, 0);
        if (this.oldTopX > 0 | this.oldTopY > 0)
        {
          ((MatrixSubPartClass) this.SubPartList[this.SubpartNr(this.tableId)]).TopItemX = this.oldTopX;
          ((MatrixSubPartClass) this.SubPartList[this.SubpartNr(this.tableId)]).TopItemY = this.oldTopY;
        }
      }
      else
      {
        this.oldTopX = ((MatrixSubPartClass) this.SubPartList[this.SubpartNr(this.tableId)]).TopItemX;
        this.oldTopY = ((MatrixSubPartClass) this.SubPartList[this.SubpartNr(this.tableId)]).TopItemY;
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Add Officer", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 10), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addId = this.AddSubPart(ref tsubpart1, num1 + 10, num4, 190, 35, 1);
      if (this.detailx > -1)
      {
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove Officer", 190, "Click and remove selected row", ref this.OwnBitmap, num1 + 210, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeId = this.AddSubPart(ref tsubpart2, num1 + 210, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Remove Officer", 190, "No row selected", ref this.OwnBitmap, num1 + 210, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeIdb = this.AddSubPart(ref tsubpart3, num1 + 210, num4, 190, 35, 1);
      }
      if (this.detailx > -1 & this.detaily > -1)
      {
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Change Cell", 190, "Click to edit selected value or text", ref this.OwnBitmap, num1 + 410, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.editId = this.AddSubPart(ref tsubpart4, num1 + 410, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Change Cell", 190, "No cell selected", ref this.OwnBitmap, num1 + 410, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.editIdb = this.AddSubPart(ref tsubpart5, num1 + 410, num4, 190, 35, 1);
      }
      SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Export CSV", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 610), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.exportCsv = this.AddSubPart(ref tsubpart6, num1 + 610, num4, 190, 35, 1);
      SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("Import CSV", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 810), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.importCsv = this.AddSubPart(ref tsubpart7, num1 + 810, num4, 190, 35, 1);
      int peopleCounter = this.game.Data.PeopleCounter;
      for (int index = 0; index <= peopleCounter; ++index)
      {
        this.game.Data.PeopleObj[index].LibId.libSlot = 0;
        this.game.Data.PeopleObj[index].LibId.id = -1;
      }
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (this.strId == -1 || Information.IsNothing((object) this.stringy))
        return windowReturnClass1;
      if (nr == 32 & this.detailx > -1 & this.editId > 0)
      {
        WindowReturnClass windowReturnClass2 = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.editId)] + 1, this.SubPartY[this.SubpartNr(this.editId)] + 1, 1);
        windowReturnClass2.SetFlag(true);
        return windowReturnClass2;
      }
      if (nr == 38 & this.detailx > 0)
      {
        --this.detailx;
        this.RefreshCellInfo();
        this.SubPartList[this.SubpartNr(this.tableId)].ShiftUp();
        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 40 & this.detailx < this.stringy.Length)
      {
        ++this.detailx;
        this.RefreshCellInfo();
        this.SubPartList[this.SubpartNr(this.tableId)].ShiftDown();
        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (nr == 37 & this.detaily > 0 & this.stringy.Length > -1 & this.detailx > -1)
      {
        --this.detaily;
        this.RefreshCellInfo();
        this.SubPartList[this.SubpartNr(this.tableId)].ShiftLeft();
        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (!(nr == 39 & this.detaily < this.stringy.Width & this.stringy.Length > -1 & this.detailx > -1))
        return windowReturnClass1;
      ++this.detaily;
      this.RefreshCellInfo();
      this.SubPartList[this.SubpartNr(this.tableId)].ShiftRight();
      this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
      windowReturnClass1.SetFlag(true);
      return windowReturnClass1;
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
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
            if (num1 == this.loadMasterId)
            {
              string str1 = this.game.AppPath + "scenarios\\";
              if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
              {
                if (this.game.Data.ScenarioDir.Length > 1)
                  str1 = str1.Replace("scenarios", this.game.Data.ScenarioDir);
                else if (this.game.ModScenarioDir.Length > 1)
                  str1 = str1.Replace("scenarios", this.game.ModScenarioDir);
              }
              else if (this.game.ModScenarioDir.Length > 1)
                str1 = str1.Replace("scenarios", this.game.ModScenarioDir);
              string str2 = str1 + this.masterfileStart;
              if (File.Exists(str2))
              {
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                this.game.HandyFunctionsObj.LoadMasterFile(str2);
                this.game.Data.Round = 0;
                this.game.Data.Turn = 0;
                if ((double) this.game.Data.RuleVar[344] == 1.0 & this.game.EditObj.HideUnit == 0)
                  this.game.EditObj.HideUnit = 2;
                this.game.EditObj.TempValue = new MapMatrix2[this.game.Data.MapCounter + 1];
                this.game.EditObj.TempValue2 = new MapMatrix2[this.game.Data.MapCounter + 1];
                int mapCounter = this.game.Data.MapCounter;
                for (int index2 = 0; index2 <= mapCounter; ++index2)
                {
                  this.game.EditObj.TempValue[index2] = new MapMatrix2(this.game.Data.MapObj[index2].MapWidth, this.game.Data.MapObj[index2].MapHeight);
                  this.game.EditObj.TempValue2[index2] = new MapMatrix2(this.game.Data.MapObj[index2].MapWidth, this.game.Data.MapObj[index2].MapHeight);
                }
                if (Strings.Len(this.game.Data.LoadPass) > 0)
                {
                  this.game.FormRef.Cursor = Cursors.Default;
                  if (Operators.CompareString(Strings.LCase(Interaction.InputBox("This File is protected by a load password. Please give it in order to load it.", "Shadow Empire : Planetary Conquest")), Strings.LCase(this.game.Data.LoadPass), false) == 0)
                  {
                    int num2 = (int) Interaction.MsgBox((object) "You are cleared.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    int num3 = (int) Interaction.MsgBox((object) "Wrong Password. You cannot Load this file. Exiting whole app.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    ProjectData.EndApp();
                  }
                }
                BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                this.game.Data.LoadGraphics((Form1) null);
                this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                this.game.EditObj.StratMap = new Bitmap(this.game.ScreenWidth, this.game.ScreenHeight - 265);
                this.game.EditObj.StratMap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
                this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.StratMap, this.game.ScreenWidth, this.game.ScreenHeight - 265, false, true, false);
                this.game.FormRef.Cursor = Cursors.Default;
                int num4 = (int) Interaction.MsgBox((object) "Loaded Master", Title: ((object) "Shadow Empire : Planetary Conquest"));
                this.RemoveSubPart(this.tableId);
                this.tableId = 0;
                this.DoStuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.loadId)
            {
              string tinitdir = this.game.AppPath + "scenarios\\";
              if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
              {
                if (this.game.Data.ScenarioDir.Length > 1)
                  tinitdir = tinitdir.Replace("scenarios", this.game.Data.ScenarioDir);
                else if (this.game.ModScenarioDir.Length > 1)
                  tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
              }
              else if (this.game.ModScenarioDir.Length > 1)
                tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
              string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Officer library(*.se1off)|*.se1off", "Pick a officer library...", tinitdir, false);
              if (File.Exists(str))
              {
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                this.game.EditObj.TutMode = false;
                if (this.game.Data.UseAI == 1)
                  this.game.NewAIObj.LastRegime = -1;
                this.game.SelectX = -1;
                this.game.SelectY = -1;
                this.game.Data = new DataClass();
                GC.Collect();
                Application.DoEvents();
                this.game.HandyFunctionsObj.Unzip(str);
                this.game.Data = DataClass.deserialize(str);
                this.game.HandyFunctionsObj.ZipFile(str);
                if (Operators.CompareString(this.game.Data.MasterFile, "", false) == 0)
                {
                  if (Strings.Len(this.masterfileStart) > 0 && Interaction.MsgBox((object) ("Update data with masterfile '" + this.masterfileStart + "' data"), MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                  {
                    this.game.Data.MasterfileReadPeople = false;
                    string masterfileStart = this.masterfileStart;
                    this.game.HandyFunctionsObj.LoadMasterFile(this.game.HandyFunctionsObj.ReturnLongMaster(str, masterfileStart));
                    this.game.Data.MasterFile = this.masterfileStart;
                  }
                }
                else
                {
                  this.game.Data.MasterfileReadPeople = false;
                  string masterFile = this.game.Data.MasterFile;
                  this.game.HandyFunctionsObj.LoadMasterFile(this.game.HandyFunctionsObj.ReturnLongMaster(str, masterFile));
                }
                this.game.Data.Round = 0;
                this.game.Data.Turn = 0;
                if ((double) this.game.Data.RuleVar[344] == 1.0 & this.game.EditObj.HideUnit == 0)
                  this.game.EditObj.HideUnit = 2;
                this.game.EditObj.TempValue = new MapMatrix2[this.game.Data.MapCounter + 1];
                this.game.EditObj.TempValue2 = new MapMatrix2[this.game.Data.MapCounter + 1];
                int mapCounter = this.game.Data.MapCounter;
                for (int index3 = 0; index3 <= mapCounter; ++index3)
                {
                  this.game.EditObj.TempValue[index3] = new MapMatrix2(this.game.Data.MapObj[index3].MapWidth, this.game.Data.MapObj[index3].MapHeight);
                  this.game.EditObj.TempValue2[index3] = new MapMatrix2(this.game.Data.MapObj[index3].MapWidth, this.game.Data.MapObj[index3].MapHeight);
                }
                if (Strings.Len(this.game.Data.LoadPass) > 0)
                {
                  this.game.FormRef.Cursor = Cursors.Default;
                  if (Operators.CompareString(Strings.LCase(Interaction.InputBox("This File is protected by a load password. Please give it in order to load it.", "Shadow Empire : Planetary Conquest")), Strings.LCase(this.game.Data.LoadPass), false) == 0)
                  {
                    int num5 = (int) Interaction.MsgBox((object) "You are cleared.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    int num6 = (int) Interaction.MsgBox((object) "Wrong Password. You cannot Load this file. Exiting whole app.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    ProjectData.EndApp();
                  }
                }
                BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                this.game.Data.LoadGraphics((Form1) null);
                this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                this.game.EditObj.StratMap = new Bitmap(this.game.ScreenWidth, this.game.ScreenHeight - 265);
                this.game.EditObj.StratMap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
                this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.StratMap, this.game.ScreenWidth, this.game.ScreenHeight - 265, false, true, false);
                this.game.FormRef.Cursor = Cursors.Default;
                int num7 = (int) Interaction.MsgBox((object) "Loaded Historical Library", Title: ((object) "Shadow Empire : Planetary Conquest"));
                this.RemoveSubPart(this.tableId);
                this.tableId = 0;
                this.DoStuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.saveId)
            {
              string tinitdir = this.game.AppPath + "scenarios\\";
              if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
              {
                if (this.game.Data.ScenarioDir.Length > 1)
                  tinitdir = tinitdir.Replace("scenarios", this.game.Data.ScenarioDir);
                else if (this.game.ModScenarioDir.Length > 1)
                  tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
              }
              else if (this.game.ModScenarioDir.Length > 1)
                tinitdir = tinitdir.Replace("scenarios", this.game.ModScenarioDir);
              string str = this.game.HandyFunctionsObj.SaveSomething("SE1 Officer library(*.se1off)|*.se1off", "Give save name...", tinitdir, false);
              if (Strings.Len(str) < 2)
              {
                int num8 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                this.game.Data.serialize(str);
                this.game.HandyFunctionsObj.ZipFile(str);
                windowReturnClass1.SetFlag(true);
                this.game.FormRef.Cursor = Cursors.Default;
                this.game.Data.LoadGraphics(this.formref);
                int num9 = (int) Interaction.MsgBox((object) "Completed & Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
            }
            else
            {
              if (num1 == this.a1id)
              {
                string str = Interaction.InputBox("Give name.", "Shadow Empire : Planetary Conquest", this.game.Data.LibraryObj[0].name);
                if (str.Length > 0)
                  this.game.Data.LibraryObj[0].name = str;
                this.RemoveSubPart(this.tableId);
                this.tableId = 0;
                this.DoStuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (num1 == this.a2id)
              {
                string str = Interaction.InputBox("Give author name.", "Shadow Empire : Planetary Conquest", this.game.Data.LibraryObj[0].creator);
                if (str.Length > 0)
                  this.game.Data.LibraryObj[0].creator = str;
                this.RemoveSubPart(this.tableId);
                this.tableId = 0;
                this.DoStuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (num1 == this.a3id)
              {
                new Form2((Form) this.formref).Initialize(this.game.Data, 13, 0);
                this.Change = true;
                return windowReturnClass1;
              }
              if (num1 == this.exitId)
              {
                this.game.EditObj.InEditor = false;
                if (this.game.EditorBlock)
                  this.game.EditObj.ShowInitialMenu = true;
                if (this.game.ModIntroType == 0)
                  windowReturnClass1.AddCommand(3, 1);
                else
                  windowReturnClass1.AddCommand(3, 12);
              }
              else if (num1 == this.editId)
              {
                if (this.tabId == 1)
                {
                  if (this.detaily <= 1)
                  {
                    int num10 = (int) Interaction.MsgBox((object) "Cannot change", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    if (this.detaily == 2)
                    {
                      this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      string str = Interaction.InputBox("Give name.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                      if (str.Length == 0)
                      {
                        int num11 = (int) Interaction.MsgBox((object) "An officer MUST ALWAYS have a name. always.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      this.stringy.Data[this.detailx, this.detaily] = str;
                      this.game.Data.HistoricalUnitObj[this.currentHisNr].CommanderName = str;
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 3)
                    {
                      string str = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of symbol Sprite:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + str))
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].CommanderFileName = str;
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].LoadSprites();
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      int num12 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      if (this.detaily == 4)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        new Form2((Form) this.formref).Initialize(this.game.Data, 6, this.currentHisNr);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 5)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string str = Interaction.InputBox("Give value 0-100%", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].CombatMod = Conversions.ToInteger(str);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 6)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string str = Interaction.InputBox("Give value 0-100%", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].MoraleMod = Conversions.ToInteger(str);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 7)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string str = Interaction.InputBox("Give value", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].StaffSize = Conversions.ToInteger(str);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 8)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string str = Interaction.InputBox("Give value", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].PP = Conversions.ToInteger(str);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily >= 9 & this.detaily <= 16)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        int tnr2 = this.detaily - 9;
                        this.Change = true;
                        new Form3((Form) this.formref).Initialize(this.game.Data, 139, this.currentHisNr, tnr2, this.game);
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily >= 17)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string InputStr = Interaction.InputBox("Give value", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = InputStr;
                        int smallGfx = this.game.Data.TempString[1300 + this.ColIsVar[this.detaily]].ToString().Length <= 0 ? -1 : (int) Math.Round(Conversion.Val(this.game.Data.TempString[1300 + this.ColIsVar[this.detaily]]));
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].SetHisVarValue(this.ColIsVar[this.detaily], (int) Math.Round(Conversion.Val(InputStr)), smallGfx);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                    }
                  }
                }
              }
              else
              {
                if (num1 == this.removeId)
                {
                  if (this.tabId == 1)
                  {
                    this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                    --this.detailx;
                    this.game.Data.RemoveHistoricalUnit(this.currentHisNr);
                  }
                  this.RemoveSubPart(this.tableId);
                  this.tableId = 0;
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.addId)
                {
                  if (this.tabId == 1)
                  {
                    int num13 = 0;
                    int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                    for (int index4 = 0; index4 <= historicalUnitCounter; ++index4)
                    {
                      if (this.game.Data.HistoricalUnitObj[index4].ID > num13)
                        num13 = this.game.Data.HistoricalUnitObj[index4].ID;
                    }
                    if (num13 + 100 < this.game.Data.HistoricalIDCounter)
                      this.game.Data.HistoricalIDCounter = num13 + 100;
                    this.game.Data.AddHistoricalUnit();
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].CommanderName = "New Commander";
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].TempRegime = 0;
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].People = 0;
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId.libSlot = 0;
                  }
                  this.RemoveSubPart(this.tableId);
                  this.tableId = 0;
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.removeReinf)
                {
                  this.game.Data.RemoveLibrary(this.detailnr);
                  this.RemoveSubPart(this.tableId);
                  this.tableId = 0;
                  this.detailnr = -1;
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.addReinf)
                {
                  string path = this.game.HandyFunctionsObj.LoadSomething("SE1 Officer Card Library(*.se1offcard)|*.se1offcard", "Pick Officer card library...", this.game.AppPath + this.game.ModScenarioDir, false);
                  if (File.Exists(path))
                  {
                    this.game.EditObj.TempFileName = path;
                    this.game.EditObj.TempFileType = NewEnums.LibFileType.ImportCardsInOfficerEditor;
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    DataClass dataClass;
                    this.game.HandyFunctionsObj.LoadLibrary(ref dataClass);
                    bool[] import = new bool[dataClass.LibraryCounter + 1];
                    int[] subreg = new int[dataClass.RegimeCounter + 1];
                    int[] subPpl = new int[dataClass.PeopleCounter + 1];
                    int[] sublib = new int[dataClass.LibraryCounter + 1];
                    int libraryCounter1 = dataClass.LibraryCounter;
                    for (int index5 = 0; index5 <= libraryCounter1; ++index5)
                    {
                      sublib[index5] = -1;
                      import[index5] = false;
                    }
                    int regimeCounter = dataClass.RegimeCounter;
                    for (int index6 = 0; index6 <= regimeCounter; ++index6)
                      subreg[index6] = 0;
                    int peopleCounter = dataClass.PeopleCounter;
                    for (int index7 = 0; index7 <= peopleCounter; ++index7)
                      subPpl[index7] = -1;
                    int libraryCounter2 = dataClass.LibraryCounter;
                    for (int index8 = 0; index8 <= libraryCounter2; ++index8)
                    {
                      sublib[index8] = -1;
                      int libraryCounter3 = this.game.Data.LibraryCounter;
                      for (int index9 = 0; index9 <= libraryCounter3; ++index9)
                      {
                        if (Operators.CompareString(this.game.Data.LibraryObj[index9].name, dataClass.LibraryObj[index8].name, false) == 0)
                        {
                          bool flag;
                          sublib[-(flag ? 1 : 0)] = index9;
                        }
                      }
                      int actionCardCounter = dataClass.ActionCardCounter;
                      for (int index10 = 0; index10 <= actionCardCounter; ++index10)
                      {
                        if (dataClass.ActionCardObj[index10].LibId.libSlot == index8)
                          import[index8] = true;
                      }
                    }
                    this.game.HandyFunctionsObj.ActuallyImportLibs(ref dataClass, ref import, ref sublib, ref subPpl, ref subreg);
                    int num14 = (int) Interaction.MsgBox((object) "Import completed", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.game.FormRef.Cursor = Cursors.Default;
                    this.RemoveSubPart(this.tableId);
                    this.tableId = 0;
                    this.DoStuff();
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  int num15 = (int) Interaction.MsgBox((object) "Could not find file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.versionid)
                {
                  string InputStr = Interaction.InputBox("Give version.", "Shadow Empire : Planetary Conquest");
                  if (InputStr.Length > 0)
                    this.game.Data.LibraryObj[0].version = (int) Math.Round(Conversion.Val(InputStr));
                  this.RemoveSubPart(this.tableId);
                  this.tableId = 0;
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.listId)
                {
                  int num16 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num16 > -1)
                  {
                    this.detailnr = num16;
                    this.RemoveSubPart(this.tableId);
                    this.tableId = 0;
                    this.DoStuff();
                  }
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.tableId)
                {
                  Coordinate coordinate = this.SubPartList[index1].Click2(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (coordinate.x > -1)
                  {
                    this.detailx = coordinate.x;
                    this.detaily = coordinate.y;
                    if (this.detaily > this.stringy.Width)
                      this.detaily = this.stringy.Width;
                    if (this.detailx > this.stringy.Length)
                      this.detailx = this.stringy.Length;
                  }
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.importCsv)
                {
                  string str3 = this.game.HandyFunctionsObj.LoadSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Select file to import...", this.game.AppPath + "csv/", false);
                  if (Strings.Len(str3) < 2)
                  {
                    int num17 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    StreamReader Expression;
                    WindowReturnClass windowReturnClass2;
                    try
                    {
                      Expression = File.OpenText(str3);
                      int num18 = 0;
                      string str4 = ",";
                      while (!Expression.EndOfStream)
                      {
                        string str5 = Expression.ReadLine();
                        if ((uint) Strings.InStr(str5, "sep=") > 0U)
                        {
                          str4 = Strings.Mid(str5, 5, 1);
                          num18 = 1;
                        }
                        else
                        {
                          switch (num18)
                          {
                            case 0:
                              if (Strings.InStr(str5, "\t") > 0)
                                str4 = "\t";
                              else if (Strings.InStr(str5, ",") > 0)
                                str4 = ",";
                              else if (Strings.InStr(str5, ";") > 0)
                                str4 = ";";
                              num18 = 2;
                              continue;
                            case 1:
                              num18 = 2;
                              continue;
                            case 2:
                              string[] strArray = str5.Split(Conversions.ToChar(str4));
                              int id = (int) Math.Round(Conversion.Val(strArray[0]));
                              int index11;
                              if (id > 0)
                              {
                                index11 = this.game.HandyFunctionsObj.GetHistoricalUnitByID(id);
                                if (index11 == -1)
                                {
                                  this.game.Data.AddHistoricalUnit();
                                  index11 = this.game.Data.HistoricalUnitCounter;
                                  this.game.Data.HistoricalUnitObj[index11].ID = Conversions.ToInteger(strArray[0]);
                                }
                                else if (this.game.Data.HistoricalUnitObj[index11].CommanderName.Length < 1)
                                {
                                  this.game.Data.AddHistoricalUnit();
                                  index11 = this.game.Data.HistoricalUnitCounter;
                                  strArray[0] = Conversions.ToString(this.game.Data.HistoricalUnitObj[index11].ID);
                                }
                              }
                              else
                              {
                                this.game.Data.AddHistoricalUnit();
                                index11 = this.game.Data.HistoricalUnitCounter;
                                strArray[0] = Conversions.ToString(this.game.Data.HistoricalUnitObj[index11].ID);
                              }
                              this.game.Data.HistoricalUnitObj[index11].ID = (int) Math.Round(Conversion.Val(strArray[0]));
                              this.game.Data.HistoricalUnitObj[index11].CommanderName = strArray[1];
                              this.game.Data.HistoricalUnitObj[index11].CommanderFileName = strArray[2];
                              this.game.Data.HistoricalUnitObj[index11].CombatMod = (int) Math.Round(Conversion.Val(strArray[3]));
                              this.game.Data.HistoricalUnitObj[index11].MoraleMod = (int) Math.Round(Conversion.Val(strArray[4]));
                              this.game.Data.HistoricalUnitObj[index11].StaffSize = (int) Math.Round(Conversion.Val(strArray[5]));
                              this.game.Data.HistoricalUnitObj[index11].PP = (int) Math.Round(Conversion.Val(strArray[6]));
                              int index12 = 0;
                              do
                              {
                                if (Conversion.Val(strArray[index12 + 7]) > -1.0)
                                {
                                  if (index12 <= this.game.Data.HistoricalUnitObj[index11].DeckCardCounter)
                                  {
                                    this.game.Data.HistoricalUnitObj[index11].DeckCard[index12] = (int) Math.Round(Conversion.Val(strArray[index12 + 7]));
                                  }
                                  else
                                  {
                                    this.game.Data.HistoricalUnitObj[index11].DeckCard = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[index11].DeckCard, (Array) new int[index12 + 1]);
                                    this.game.Data.HistoricalUnitObj[index11].DeckChance = (int[]) Utils.CopyArray((Array) this.game.Data.HistoricalUnitObj[index11].DeckChance, (Array) new int[index12 + 1]);
                                    this.game.Data.HistoricalUnitObj[index11].DeckChance[index12] = 100;
                                    this.game.Data.HistoricalUnitObj[index11].DeckCard[index12] = (int) Math.Round(Conversion.Val(strArray[index12 + 7]));
                                    this.game.Data.HistoricalUnitObj[index11].DeckCardCounter = index12;
                                    int num19 = index12;
                                    for (int index13 = 0; index13 <= num19; ++index13)
                                    {
                                      if (this.game.Data.HistoricalUnitObj[index11].DeckCard[index13] == -1)
                                      {
                                        this.game.Data.HistoricalUnitObj[index11].DeckCard[index13] = (int) Math.Round(Conversion.Val(strArray[index12 + 7]));
                                        this.game.Data.HistoricalUnitObj[index11].DeckChance[index13] = 100;
                                      }
                                    }
                                  }
                                }
                                ++index12;
                              }
                              while (index12 <= 7);
                              int num20 = 0;
                              int typ = 0;
                              do
                              {
                                if (this.game.Data.TempString[1200 + typ].Length > 0)
                                {
                                  ++num20;
                                  this.game.Data.HistoricalUnitObj[index11].SetHisVarValue(typ, (int) Math.Round(Conversion.Val(strArray[14 + num20])));
                                }
                                ++typ;
                              }
                              while (typ <= 99);
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
                      if (!Information.IsNothing((object) Expression))
                        Expression.Close();
                      this.game.Data.LoadGraphics(this.formref);
                      int num21 = (int) Interaction.MsgBox((object) ("Import problem encountered: '" + exception.Message + "'. Your current data might be corrupted. "), Title: ((object) "Shadow Empire : Planetary Conquest"));
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      windowReturnClass2 = windowReturnClass1;
                      ProjectData.ClearProjectError();
                      goto label_224;
                    }
                    Expression.Close();
                    this.game.Data.LoadGraphics(this.formref);
                    int num22 = (int) Interaction.MsgBox((object) "Import finished", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.RemoveSubPart(this.tableId);
                    this.tableId = 0;
                    this.DoStuff();
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
label_224:
                    return windowReturnClass2;
                  }
                }
                else if (num1 == this.exportCsv)
                {
                  string str6 = this.game.HandyFunctionsObj.SaveSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Give save name...", this.game.AppPath + "csv/", false);
                  if (Strings.Len(str6) < 2)
                  {
                    int num23 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    try
                    {
                      StreamWriter text = File.CreateText(str6);
                      try
                      {
                        text.WriteLine("sep=\t");
                        string str7 = "" + "ID#" + "\t" + "Name" + "\t" + "Portrait" + "\t" + "CombatMod" + "\t" + "MoraleMod" + "\t" + "Staff Pts" + "\t" + "PP" + "\t" + "Card1" + "\t" + "Card2" + "\t" + "Card3" + "\t" + "Card4" + "\t" + "Card5" + "\t" + "Card6" + "\t" + "Card7" + "\t" + "Card8";
                        int num24 = 0;
                        do
                        {
                          if (this.game.Data.TempString[1200 + num24].Length > 0)
                            str7 = str7 + "\t" + this.game.Data.TempString[1200 + num24];
                          ++num24;
                        }
                        while (num24 <= 99);
                        text.WriteLine(str7);
                        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                        for (int index14 = 0; index14 <= historicalUnitCounter; ++index14)
                        {
                          if (this.game.Data.HistoricalUnitObj[index14].CommanderName.Length > 0)
                          {
                            string str8 = "" + this.game.Data.HistoricalUnitObj[index14].ID.ToString() + "\t" + this.game.Data.HistoricalUnitObj[index14].CommanderName + "\t" + this.game.Data.HistoricalUnitObj[index14].CommanderFileName + "\t" + this.game.Data.HistoricalUnitObj[index14].CombatMod.ToString() + "\t" + this.game.Data.HistoricalUnitObj[index14].MoraleMod.ToString() + "\t" + this.game.Data.HistoricalUnitObj[index14].StaffSize.ToString() + "\t" + this.game.Data.HistoricalUnitObj[index14].PP.ToString();
                            int index15 = 0;
                            do
                            {
                              str8 = index15 > this.game.Data.HistoricalUnitObj[index14].DeckCardCounter ? str8 + "\t" + "-1" : str8 + "\t" + this.game.Data.HistoricalUnitObj[index14].DeckCard[index15].ToString();
                              ++index15;
                            }
                            while (index15 <= 7);
                            int typ = 0;
                            do
                            {
                              if (this.game.Data.TempString[1200 + typ].Length > 0)
                                str8 = str8 + "\t" + this.game.Data.HistoricalUnitObj[index14].GiveHisVarValue(typ).ToString();
                              ++typ;
                            }
                            while (typ <= 99);
                            text.WriteLine(str8);
                          }
                        }
                        text.Close();
                        int num25 = (int) Interaction.MsgBox((object) "Export has been written to the csv/ directory", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      catch (Exception ex)
                      {
                        ProjectData.SetProjectError(ex);
                        Exception exception = ex;
                        text.Close();
                        int num26 = (int) Interaction.MsgBox((object) ("Problem writing: " + exception.Message), Title: ((object) "Shadow Empire : Planetary Conquest"));
                        ProjectData.ClearProjectError();
                      }
                    }
                    catch (Exception ex)
                    {
                      ProjectData.SetProjectError(ex);
                      int num27 = (int) Interaction.MsgBox((object) "Problem writing. Check if the file is not opened in other application please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      ProjectData.ClearProjectError();
                    }
                  }
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

    public void Interpret()
    {
    }
  }
}
