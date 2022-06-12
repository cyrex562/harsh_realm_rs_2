// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleHisWindowClass
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
  public class SimpleHisWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int cellinfoid;
    private int tableId;
    private int loadId;
    private int text1id;
    private int detailnr;
    private int noneId;
    private int noneIdB;
    private int versionid;
    private int addId;
    private int addReinf;
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
    private int exportCsv;
    private int importCsv;
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
    private int[] ColIsSFTypeVar;
    private int oldTopX;
    private int oldTopY;
    private string masterfileStart;

    public SimpleHisWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight, 9, tDoBorders: 1, tHeaderString: "Intermediate Historical Unit Editor")
    {
      this.ColIsSFTypeVar = new int[100];
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
      this.game.EditObj.TempSFType = -1;
      this.masterfileStart = this.game.Data.MasterFile;
      this.game.Data.MasterFile = "";
      this.DoStuff();
    }

    public void RefreshCellInfo()
    {
      string txt;
      if (this.detaily == -1 | this.detailx == -1)
      {
        txt = "No cell selected";
      }
      else
      {
        txt = "(row" + this.detailx.ToString() + ",col" + this.detaily.ToString() + ")             " + this.stringy.ColumnName[this.detaily].ToUpper() + "                ";
        if (this.stringy.Data[this.detailx, this.detaily].Length > 0)
          txt += this.stringy.Data[this.detailx, this.detaily];
        else if (this.stringy.TempDesc[this.detailx, this.detaily].Length > 0)
          txt += this.stringy.TempDesc[this.detailx, this.detaily];
      }
      if (this.cellinfoid > 0)
      {
        this.RemoveSubPart(this.cellinfoid);
        this.cellinfoid = 0;
      }
      SubPartClass tsubpart = (SubPartClass) new TextPartClass(txt, this.game.MarcFont4, this.game.ScreenWidth - 323, 20, false, tMarc: true);
      this.cellinfoid = this.AddSubPart(ref tsubpart, 312, 152, this.game.ScreenWidth - 323, 20, 0);
    }

    public override void DoRefresh()
    {
      if (!this.Change)
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

    public void PopUpRefresh()
    {
    }

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
      if (this.noneId > 0)
        this.RemoveSubPart(this.noneId);
      if (this.noneIdB > 0)
        this.RemoveSubPart(this.noneIdB);
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
      if (this.cellinfoid > 0)
      {
        this.RemoveSubPart(this.cellinfoid);
        this.cellinfoid = 0;
      }
      if (this.exportCsv > 0)
        this.RemoveSubPart(this.exportCsv);
      if (this.importCsv > 0)
        this.RemoveSubPart(this.importCsv);
      if (this.listId > 0)
        this.RemoveSubPart(this.listId);
      if (this.game.Data.LibraryCounter == -1)
      {
        this.game.Data.AddLibrary();
        this.game.Data.LibraryObj[0].name = "New Historical Library";
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
      bool[] flagArray = new bool[this.game.Data.SmallPicCounter + 1];
      int smallPicCounter1 = this.game.Data.SmallPicCounter;
      for (int index = 0; index <= smallPicCounter1; ++index)
      {
        if (this.game.Data.SmallLibId[index].libSlot >= 0)
          flagArray[index] = true;
        this.game.Data.SmallLibId[index].libSlot = -1;
        this.game.Data.SmallLibId[index].id = -1;
      }
      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
      for (int index1 = 0; index1 <= historicalUnitCounter; ++index1)
      {
        if (this.game.Data.HistoricalUnitObj[index1].ModelMaster > -1)
          this.game.Data.HistoricalUnitObj[index1].People = this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[index1].ModelMaster].People;
        if (this.game.Data.HistoricalUnitObj[index1].Model)
        {
          if (this.game.Data.HistoricalUnitObj[index1].SmallGfx > -1)
          {
            this.game.Data.SmallLibId[this.game.Data.HistoricalUnitObj[index1].SmallGfx].libSlot = 0;
            this.game.Data.SmallLibId[this.game.Data.HistoricalUnitObj[index1].SmallGfx].id = -1;
          }
          int index2 = 0;
          do
          {
            if (this.game.Data.HistoricalUnitObj[index1].SubParts[index2] > -1 && this.game.Data.HistoricalUnitObj[index1].DesignationSmall[index2] > -1)
            {
              this.game.Data.SmallLibId[this.game.Data.HistoricalUnitObj[index1].DesignationSmall[index2]].libSlot = 0;
              this.game.Data.SmallLibId[this.game.Data.HistoricalUnitObj[index1].DesignationSmall[index2]].id = -1;
            }
            ++index2;
          }
          while (index2 <= 5);
        }
      }
      for (int smallPicCounter2 = this.game.Data.SmallPicCounter; smallPicCounter2 >= 0; smallPicCounter2 += -1)
      {
        if (flagArray[smallPicCounter2] & this.game.Data.SmallLibId[smallPicCounter2].libSlot == -1)
          this.game.Data.RemoveSmallPic(smallPicCounter2);
      }
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
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Save Historical Library", 190, "Save a TroopType Library", ref this.OwnBitmap, num3, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.saveId = this.AddSubPart(ref tsubpart2, num3, num4, 190, 35, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Save Historical Library", 190, "Nothing to save", ref this.OwnBitmap, num3, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.saveIdb = this.AddSubPart(ref tsubpart2, num3, num4, 190, 35, 1);
      }
      int num5 = num4 + 50;
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Load Historical Library", 190, tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num5, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadId = this.AddSubPart(ref tsubpart2, num3, num5, 190, 35, 1);
      int num6 = num5 + 50;
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Exit", 190, tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.exitId = this.AddSubPart(ref tsubpart2, num3, num6, 190, 35, 1);
      int y2 = num6 + 50;
      DrawMod.DrawTextColouredMarc(ref graphics, "Tabsheets:", this.game.MarcFont3, 40, y2, Color.White);
      int num7 = y2 + 40;
      int num8 = 20;
      if (this.tabId != 1)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Peoples", 190, "Click to go to people tabsheet", ref this.OwnBitmap, num8 + 20, num7, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.tab1id = this.AddSubPart(ref tsubpart2, num8 + 20, num7, 190, 35, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Peoples", 190, "People tabsheet already on screen", ref this.OwnBitmap, num8 + 20, num7, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.tab1idb = this.AddSubPart(ref tsubpart2, num8 + 20, num7, 190, 35, 1);
      }
      int num9 = num7 + 50;
      if (this.tabId != 2)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Unit Composition", 190, "Click to go to unit composition tabsheet", ref this.OwnBitmap, num8 + 20, num9, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.tab2id = this.AddSubPart(ref tsubpart2, num8 + 20, num9, 190, 35, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Unit Composition", 190, "Unit composition tabsheet already on screen", ref this.OwnBitmap, num8 + 20, num9, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.tab2idb = this.AddSubPart(ref tsubpart2, num8 + 20, num9, 190, 35, 1);
      }
      int num10 = num9 + 50;
      if (this.tabId != 3)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Historical Models", 190, "Click to go to Historical Models tabsheet", ref this.OwnBitmap, num8 + 20, num10, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.tab3id = this.AddSubPart(ref tsubpart2, num8 + 20, num10, 190, 35, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Historical Models", 190, "Historical Models tabsheet already on screen", ref this.OwnBitmap, num8 + 20, num10, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.tab3idb = this.AddSubPart(ref tsubpart2, num8 + 20, num10, 190, 35, 1);
      }
      int num11 = num10 + 50;
      if (this.tabId != 4)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Historical Units", 190, "Click to go to Historical Units tabsheet", ref this.OwnBitmap, num8 + 20, num11, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.tab4id = this.AddSubPart(ref tsubpart2, num8 + 20, num11, 190, 35, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Historical Units", 190, "Historical Units tabsheet already on screen", ref this.OwnBitmap, num8 + 20, num11, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.tab4idb = this.AddSubPart(ref tsubpart2, num8 + 20, num11, 190, 35, 1);
      }
      int y3 = num11 + 50;
      DrawMod.DrawTextColouredMarc(ref graphics, "TroopType Libraries:", this.game.MarcFont3, 40, y3, Color.White);
      int y4 = y3 + 40;
      this.listObj = new ListClass();
      int num12 = -1;
      int num13 = -1;
      int libraryCounter = this.game.Data.LibraryCounter;
      for (int tdata = 0; tdata <= libraryCounter; ++tdata)
      {
        bool flag = false;
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter; ++index)
        {
          if (this.game.Data.SFTypeObj[index].LibId.libSlot == tdata)
            flag = true;
        }
        if (flag)
        {
          ++num12;
          if (this.detailnr == tdata)
            num13 = num12;
          this.listObj.add(this.game.Data.LibraryObj[tdata].name, tdata);
        }
      }
      ListClass listObj = this.listObj;
      int tlistselect = num13;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      int bby = y4;
      Font font = (Font) null;
      ref Font local2 = ref font;
      tsubpart2 = (SubPartClass) new ListSubPartClass(listObj, 6, 210, tlistselect, game, true, "TroopType Libraries", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 40, bby: bby, tMarcStyle: true, overruleFont: (ref local2));
      this.listId = this.AddSubPart(ref tsubpart2, 40, y4, 210, 144, 0);
      int y5 = y4 + 135;
      tsubpart2 = (SubPartClass) new TextButtonPartClass("Add Library", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 620, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addReinf = this.AddSubPart(ref tsubpart2, 40, y5, 190, 35, 1);
      int y6 = y5 + 50;
      if (this.detailnr > -1)
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove Library", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 660, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeReinf = this.AddSubPart(ref tsubpart2, 40, y6, 190, 35, 1);
      }
      else
      {
        tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove Library", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 660, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveReinfb = this.AddSubPart(ref tsubpart2, 40, y6, 190, 35, 1);
      }
      if (this.tabId == 1)
        this.Tab1(ref graphics);
      if (this.tabId == 2)
        this.Tab2(ref graphics);
      if (this.tabId == 3)
        this.Tab3(ref graphics);
      if (this.tabId != 4)
        return;
      this.Tab4(ref graphics);
    }

    public void Tab2(ref Graphics g)
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = this.game.ScreenHeight - 768;
      int num3 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 322) / 24.0)) - 1;
      int num4 = 172 + num3 * 24 + 56;
      if (this.tableId == 0)
      {
        this.stringy = new StringListClass(-1);
        int col1 = 1 - 1;
        this.stringy.AddCol(col1, "Slot");
        int col2 = col1 + 1;
        this.stringy.AddCol(col2, "ID#");
        int col3 = col2 + 1;
        this.stringy.AddCol(col3, "Name");
        int col4 = col3 + 1;
        this.stringy.AddCol(col4, "IsHQ");
        int index1 = 1;
        do
        {
          int col5 = col4 + 1;
          this.stringy.AddCol(col5, "Troop" + index1.ToString());
          int col6 = col5 + 1;
          this.stringy.AddCol(col6, "People" + index1.ToString());
          int col7 = col6 + 1;
          this.stringy.AddCol(col7, "Qty" + index1.ToString());
          int col8 = col7 + 1;
          this.stringy.AddCol(col8, "Mor" + index1.ToString());
          col4 = col8 + 1;
          this.stringy.AddCol(col4, "Xp" + index1.ToString());
          ++index1;
        }
        while (index1 <= 8);
        int index2 = -1;
        int unitCounter = this.game.Data.UnitCounter;
        for (int index3 = 0; index3 <= unitCounter; ++index3)
        {
          if (this.game.Data.UnitObj[index3].PreDef > -1)
          {
            ++index2;
            this.stringy.AddRow(index2 - 1);
            int index4 = 1 - 1;
            this.stringy.Data[index2, index4] = index3.ToString();
            int index5 = index4 + 1;
            this.stringy.Data[index2, index5] = this.game.Data.UnitObj[index3].PreDef.ToString();
            int index6 = index5 + 1;
            this.stringy.Data[index2, index6] = this.game.Data.UnitObj[index3].Name;
            int index7 = index6 + 1;
            this.stringy.Data[index2, index7] = this.game.Data.UnitObj[index3].IsHQ.ToString();
            index1 = 0;
            do
            {
              if (this.game.Data.UnitObj[index3].SFCount >= index1)
              {
                if (this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].Type == -1)
                {
                  this.game.Data.UnitObj[index3].RemoveSF(this.game.Data.UnitObj[index3].SFList[index1]);
                  --index1;
                }
                else if (this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].People == -1 && this.game.Data.PeopleCounter > -1)
                  this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].People = 0;
              }
              ++index1;
            }
            while (index1 <= 7);
            index1 = 0;
            do
            {
              if (this.game.Data.UnitObj[index3].SFCount >= index1)
              {
                int index8 = index7 + 1;
                this.stringy.Data[index2, index8] = this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].Type <= -1 ? "none set" : this.game.Data.SFTypeObj[this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].Type].Name;
                int index9 = index8 + 1;
                this.stringy.Data[index2, index9] = this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].People <= -1 ? "none set" : this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].People.ToString();
                int index10 = index9 + 1;
                this.stringy.Data[index2, index10] = this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].Qty.ToString();
                int index11 = index10 + 1;
                this.stringy.Data[index2, index11] = this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].Mor.ToString();
                index7 = index11 + 1;
                this.stringy.Data[index2, index7] = this.game.Data.SFObj[this.game.Data.UnitObj[index3].SFList[index1]].Xp.ToString();
              }
              else
              {
                int index12 = index7 + 1;
                this.stringy.Data[index2, index12] = "";
                int index13 = index12 + 1;
                this.stringy.Data[index2, index13] = "";
                int index14 = index13 + 1;
                this.stringy.Data[index2, index14] = "";
                int index15 = index14 + 1;
                this.stringy.Data[index2, index15] = "";
                index7 = index15 + 1;
                this.stringy.Data[index2, index7] = "";
              }
              ++index1;
            }
            while (index1 <= 7);
          }
        }
        SubPartClass tsubpart = (SubPartClass) new MatrixSubPartClass(this.stringy, num3 - 1, this.game.ScreenWidth - 323, this.detailx, this.detaily, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 312, bby: 172, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true);
        this.tableId = this.AddSubPart(ref tsubpart, 312, 172, this.game.ScreenWidth - 323, (num3 + 2) * 24, 0);
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
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Add Unit", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 10), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addId = this.AddSubPart(ref tsubpart1, num1 + 10, num4, 190, 35, 1);
      if (this.detailx > -1)
      {
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove Unit", 190, "Click and remove selected row", ref this.OwnBitmap, num1 + 210, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeId = this.AddSubPart(ref tsubpart2, num1 + 210, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Remove Unit", 190, "No row selected", ref this.OwnBitmap, num1 + 210, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
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
      int unitCounter1 = this.game.Data.UnitCounter;
      for (int index = 0; index <= unitCounter1; ++index)
      {
        if (this.game.Data.UnitObj[index].PreDef > -1)
        {
          this.game.Data.UnitObj[index].LibId.libSlot = 0;
          this.game.Data.UnitObj[index].LibId.id = -1;
        }
      }
    }

    public void Tab3(ref Graphics g)
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = this.game.ScreenHeight - 768;
      int num3 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 322) / 24.0)) - 1;
      int num4 = 172 + num3 * 24 + 56;
      if (this.tableId == 0)
      {
        this.stringy = new StringListClass(-1);
        int col1 = 1 - 1;
        this.stringy.AddCol(col1, "Slot");
        int col2 = col1 + 1;
        this.stringy.AddCol(col2, "ID#");
        int col3 = col2 + 1;
        this.stringy.AddCol(col3, "Name");
        int col4 = col3 + 1;
        this.stringy.AddCol(col4, "Level");
        int col5 = col4 + 1;
        this.stringy.AddCol(col5, "Small Gfx");
        int col6 = col5 + 1;
        this.stringy.AddCol(col6, "Shortname");
        int col7 = col6 + 1;
        this.stringy.AddCol(col7, "Pol.Pts");
        int col8 = col7 + 1;
        this.stringy.AddCol(col8, "GfxSymbolUsePeople");
        int col9 = col8 + 1;
        this.stringy.AddCol(col9, "NameCounter");
        int col10 = col9 + 1;
        this.stringy.AddCol(col10, "CounterRomans");
        int col11 = col10 + 1;
        this.stringy.AddCol(col11, "UseModelCounter");
        int col12 = col11 + 1;
        this.stringy.AddCol(col12, "People");
        int col13 = col12 + 1;
        this.stringy.AddCol(col13, "Max Present");
        int col14 = col13 + 1;
        this.stringy.AddCol(col14, "Battlegroup");
        int col15 = col14 + 1;
        this.stringy.AddCol(col15, "Unit1");
        int col16 = col15 + 1;
        this.stringy.AddCol(col16, "Gfx1");
        int col17 = col16 + 1;
        this.stringy.AddCol(col17, "Unit2");
        int col18 = col17 + 1;
        this.stringy.AddCol(col18, "Gfx2");
        int col19 = col18 + 1;
        this.stringy.AddCol(col19, "Unit3");
        int col20 = col19 + 1;
        this.stringy.AddCol(col20, "Gfx3");
        int col21 = col20 + 1;
        this.stringy.AddCol(col21, "Unit4");
        int col22 = col21 + 1;
        this.stringy.AddCol(col22, "Gfx4");
        int col23 = col22 + 1;
        this.stringy.AddCol(col23, "Unit5");
        int col24 = col23 + 1;
        this.stringy.AddCol(col24, "Gfx5");
        int col25 = col24 + 1;
        this.stringy.AddCol(col25, "Unit6");
        this.stringy.AddCol(col25 + 1, "Gfx6");
        int index1 = -1;
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int index2 = 0; index2 <= historicalUnitCounter; ++index2)
        {
          if (this.game.Data.HistoricalUnitObj[index2].Model)
          {
            ++index1;
            this.stringy.AddRow(index1 - 1);
            int index3 = 1 - 1;
            this.stringy.Data[index1, index3] = index2.ToString();
            int index4 = index3 + 1;
            this.stringy.Data[index1, index4] = this.game.Data.HistoricalUnitObj[index2].ID.ToString();
            int index5 = index4 + 1;
            this.stringy.Data[index1, index5] = this.game.Data.HistoricalUnitObj[index2].Name;
            int index6 = index5 + 1;
            this.stringy.Data[index1, index6] = "";
            if (this.game.Data.HistoricalUnitObj[index2].Type == 1)
              this.stringy.Data[index1, index6] = "Ind Unit";
            if (this.game.Data.HistoricalUnitObj[index2].Type == 2)
              this.stringy.Data[index1, index6] = "Multi Unit";
            if (this.game.Data.HistoricalUnitObj[index2].Type == 5)
              this.stringy.Data[index1, index6] = "Lowest HQ";
            if (this.game.Data.HistoricalUnitObj[index2].Type == 6)
              this.stringy.Data[index1, index6] = "Medium HQ";
            if (this.game.Data.HistoricalUnitObj[index2].Type == 7)
              this.stringy.Data[index1, index6] = "High HQ";
            if (this.game.Data.HistoricalUnitObj[index2].Type == 8)
              this.stringy.Data[index1, index6] = "Supreme HQ";
            int index7 = index6 + 1;
            if (this.game.Data.HistoricalUnitObj[index2].SmallGfx == -1)
              this.stringy.Data[index1, index7] = "none";
            if (this.game.Data.HistoricalUnitObj[index2].SmallGfx > -1)
            {
              this.stringy.TempBmp[index1, index7] = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[index2].SmallGfx];
              this.stringy.TempDesc[index1, index7] = "SmallGfxNr" + this.game.Data.HistoricalUnitObj[index2].SmallGfx.ToString();
            }
            int index8 = index7 + 1;
            this.stringy.Data[index1, index8] = this.game.Data.HistoricalUnitObj[index2].CounterString;
            int index9 = index8 + 1;
            this.stringy.Data[index1, index9] = this.game.Data.HistoricalUnitObj[index2].PP.ToString();
            int index10 = index9 + 1;
            this.stringy.Data[index1, index10] = this.game.Data.HistoricalUnitObj[index2].UsePeopleGfx <= -1 ? "none" : this.game.Data.PeopleObj[this.game.Data.HistoricalUnitObj[index2].UsePeopleGfx].Name;
            int index11 = index10 + 1;
            this.stringy.Data[index1, index11] = this.game.Data.HistoricalUnitObj[index2].NameCounter.ToString();
            int index12 = index11 + 1;
            this.stringy.Data[index1, index12] = this.game.Data.HistoricalUnitObj[index2].UseRomans.ToString();
            int index13 = index12 + 1;
            this.stringy.Data[index1, index13] = this.game.Data.HistoricalUnitObj[index2].UseModelCounter <= -1 ? "none" : this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[index2].UseModelCounter].Name;
            int index14 = index13 + 1;
            this.stringy.Data[index1, index14] = this.game.Data.HistoricalUnitObj[index2].People <= -1 ? "none" : this.game.Data.PeopleObj[this.game.Data.HistoricalUnitObj[index2].People].Name;
            int index15 = index14 + 1;
            this.stringy.Data[index1, index15] = this.game.Data.HistoricalUnitObj[index2].MaxPresent.ToString();
            int index16 = index15 + 1;
            this.stringy.Data[index1, index16] = this.game.Data.HistoricalUnitObj[index2].BattleGroup.ToString();
            int index17 = 0;
            do
            {
              if (this.game.Data.HistoricalUnitObj[index2].SubParts[index17] > -1)
              {
                int index18 = index16 + 1;
                this.stringy.Data[index1, index18] = this.game.Data.HistoricalUnitObj[index2].SubParts[index17] <= -1 ? "none" : this.game.Data.UnitObj[this.game.HandyFunctionsObj.GetPreDef(this.game.Data.HistoricalUnitObj[index2].SubParts[index17])].Name;
                index16 = index18 + 1;
                if (this.game.Data.HistoricalUnitObj[index2].DesignationSmall[index17] == -1)
                  this.stringy.Data[index1, index16] = "none";
                if (this.game.Data.HistoricalUnitObj[index2].DesignationSmall[index17] > -1)
                {
                  this.stringy.Data[index1, index16] = "";
                  this.stringy.TempBmp[index1, index16] = this.game.Data.SmallPicNr[this.game.Data.HistoricalUnitObj[index2].DesignationSmall[index17]];
                }
              }
              else
              {
                int index19 = index16 + 1;
                this.stringy.Data[index1, index19] = "";
                index16 = index19 + 1;
                this.stringy.Data[index1, index16] = "";
              }
              ++index17;
            }
            while (index17 <= 5);
          }
        }
        SubPartClass tsubpart = (SubPartClass) new MatrixSubPartClass(this.stringy, num3 - 1, this.game.ScreenWidth - 323, this.detailx, this.detaily, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 312, bby: 172, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true);
        this.tableId = this.AddSubPart(ref tsubpart, 312, 172, this.game.ScreenWidth - 323, num3 * 25, 0);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Add Model", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 10), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addId = this.AddSubPart(ref tsubpart1, num1 + 10, num4, 190, 35, 1);
      if (this.detailx > -1)
      {
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove Model", 190, "Click and remove selected row", ref this.OwnBitmap, num1 + 210, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeId = this.AddSubPart(ref tsubpart2, num1 + 210, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Remove Model", 190, "No row selected", ref this.OwnBitmap, num1 + 210, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
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
      if (this.detaily == 4 | this.detaily == 14 | this.detaily == 16 | this.detaily == 18 | this.detaily == 20 | this.detaily == 22 | this.detaily == 24)
      {
        SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Clear Cell", 190, "Click to remove Gfx in this cell", ref this.OwnBitmap, num1 + 610, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.noneId = this.AddSubPart(ref tsubpart6, num1 + 610, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("Clear Cell", 190, "No valid gfx cell selected", ref this.OwnBitmap, num1 + 610, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.noneIdB = this.AddSubPart(ref tsubpart7, num1 + 610, num4, 190, 35, 1);
      }
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int index = 0; index <= historicalUnitCounter1; ++index)
      {
        this.game.Data.HistoricalUnitObj[index].LibId.libSlot = 0;
        this.game.Data.HistoricalUnitObj[index].LibId.id = -1;
      }
    }

    public void Tab4(ref Graphics g)
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = this.game.ScreenHeight - 768;
      int num3 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 322) / 24.0)) - 1;
      int num4 = 172 + num3 * 24 + 56;
      if (this.tableId == 0)
      {
        this.stringy = new StringListClass(-1);
        int col1 = 1 - 1;
        this.stringy.AddCol(col1, "Slot");
        int col2 = col1 + 1;
        this.stringy.AddCol(col2, "ID#");
        int col3 = col2 + 1;
        this.stringy.AddCol(col3, "Name");
        int col4 = col3 + 1;
        this.stringy.AddCol(col4, "Based On Model");
        int col5 = col4 + 1;
        this.stringy.AddCol(col5, "Shortname");
        int col6 = col5 + 1;
        this.stringy.AddCol(col6, "tv1");
        int col7 = col6 + 1;
        this.stringy.AddCol(col7, "tv2");
        int col8 = col7 + 1;
        this.stringy.AddCol(col8, "tv3");
        int col9 = col8 + 1;
        this.stringy.AddCol(col9, "tv4");
        this.stringy.AddCol(col9 + 1, "tv5");
        int index1 = -1;
        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
        for (int index2 = 0; index2 <= historicalUnitCounter; ++index2)
        {
          if (!this.game.Data.HistoricalUnitObj[index2].Model)
          {
            ++index1;
            this.stringy.AddRow(index1 - 1);
            int index3 = 1 - 1;
            this.stringy.Data[index1, index3] = index2.ToString();
            int index4 = index3 + 1;
            this.stringy.Data[index1, index4] = this.game.Data.HistoricalUnitObj[index2].ID.ToString();
            int index5 = index4 + 1;
            this.stringy.Data[index1, index5] = this.game.Data.HistoricalUnitObj[index2].Name;
            int index6 = index5 + 1;
            this.stringy.Data[index1, index6] = this.game.Data.HistoricalUnitObj[index2].ModelMaster <= -1 ? "none" : this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[index2].ModelMaster].Name;
            int index7 = index6 + 1;
            this.stringy.Data[index1, index7] = this.game.Data.HistoricalUnitObj[index2].CounterString;
            int index8 = index7 + 1;
            this.stringy.Data[index1, index8] = this.game.Data.HistoricalUnitObj[index2].TempVar1.ToString();
            int index9 = index8 + 1;
            this.stringy.Data[index1, index9] = this.game.Data.HistoricalUnitObj[index2].TempVar2.ToString();
            int index10 = index9 + 1;
            this.stringy.Data[index1, index10] = this.game.Data.HistoricalUnitObj[index2].TempVar3.ToString();
            int index11 = index10 + 1;
            this.stringy.Data[index1, index11] = this.game.Data.HistoricalUnitObj[index2].TempVar4.ToString();
            int index12 = index11 + 1;
            this.stringy.Data[index1, index12] = this.game.Data.HistoricalUnitObj[index2].TempVar5.ToString();
          }
        }
        SubPartClass tsubpart = (SubPartClass) new MatrixSubPartClass(this.stringy, num3 - 1, this.game.ScreenWidth - 323, this.detailx, this.detaily, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 312, bby: 172, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true);
        this.tableId = this.AddSubPart(ref tsubpart, 312, 172, this.game.ScreenWidth - 323, num3 * 23, 0);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Add His Unit", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 10), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addId = this.AddSubPart(ref tsubpart1, num1 + 10, num4, 190, 35, 1);
      if (this.detailx > -1)
      {
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove His Unit", 190, "Click and remove selected row", ref this.OwnBitmap, num1 + 210, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeId = this.AddSubPart(ref tsubpart2, num1 + 210, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Remove His Unit", 190, "No row selected", ref this.OwnBitmap, num1 + 210, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
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
      int historicalUnitCounter1 = this.game.Data.HistoricalUnitCounter;
      for (int index = 0; index <= historicalUnitCounter1; ++index)
      {
        this.game.Data.HistoricalUnitObj[index].LibId.libSlot = 0;
        this.game.Data.HistoricalUnitObj[index].LibId.id = -1;
      }
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
        this.stringy.AddCol(col1, "Slot# / Id#");
        int col2 = col1 + 1;
        this.stringy.AddCol(col2, "Name");
        int col3 = col2 + 1;
        this.stringy.AddCol(col3, "BreakAt");
        int col4 = col3 + 1;
        this.stringy.AddCol(col4, "People Sideways Gfx");
        int col5 = col4 + 1;
        this.stringy.AddCol(col5, "People Symbol Gfx");
        int col6 = col5 + 1;
        this.stringy.AddCol(col6, "Base Morale");
        int col7 = col6 + 1;
        this.stringy.AddCol(col7, "Color");
        this.stringy.AddCol(col7 + 1, "ArtCode");
        int index1 = -1;
        int peopleCounter = this.game.Data.PeopleCounter;
        for (int index2 = 0; index2 <= peopleCounter; ++index2)
        {
          ++index1;
          this.stringy.AddRow(index1 - 1);
          int index3 = 1 - 1;
          this.stringy.Data[index1, index3] = index2.ToString() + "/" + this.game.Data.PeopleObj[index2].id.ToString();
          int index4 = index3 + 1;
          this.stringy.Data[index1, index4] = this.game.Data.PeopleObj[index2].Name;
          int index5 = index4 + 1;
          this.stringy.Data[index1, index5] = this.game.Data.PeopleObj[index2].BreakAt.ToString();
          int index6 = index5 + 1;
          this.stringy.Data[index1, index6] = this.game.Data.PeopleObj[index2].SidewaysFileName;
          int index7 = index6 + 1;
          this.stringy.Data[index1, index7] = this.game.Data.PeopleObj[index2].NationalFileName;
          int index8 = index7 + 1;
          this.stringy.Data[index1, index8] = this.game.Data.PeopleObj[index2].BaseMorale[0].ToString();
          int index9 = index8 + 1;
          if (this.game.Data.PeopleObj[index2].Red > -1)
            this.stringy.Data[index1, index9] = this.game.Data.PeopleObj[index2].Red.ToString() + "," + this.game.Data.PeopleObj[index2].Green.ToString() + "," + this.game.Data.PeopleObj[index2].Blue.ToString();
          else
            this.stringy.Data[index1, index9] = "No color";
          int index10 = index9 + 1;
          this.stringy.Data[index1, index10] = this.game.Data.PeopleObj[index2].artCode.ToString();
        }
        SubPartClass tsubpart = (SubPartClass) new MatrixSubPartClass(this.stringy, num3 - 1, this.game.ScreenWidth - 323, this.detailx, this.detaily, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 312, bby: 172, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true);
        this.tableId = this.AddSubPart(ref tsubpart, 312, 172, this.game.ScreenWidth - 323, num3 * 23, 0);
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Add People", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 10), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addId = this.AddSubPart(ref tsubpart1, num1 + 10, num4, 190, 35, 1);
      if (this.detailx > -1)
      {
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Remove People", 190, "Click and remove selected row", ref this.OwnBitmap, num1 + 210, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeId = this.AddSubPart(ref tsubpart2, num1 + 210, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Remove People", 190, "No row selected", ref this.OwnBitmap, num1 + 210, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
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
      int peopleCounter1 = this.game.Data.PeopleCounter;
      for (int index = 0; index <= peopleCounter1; ++index)
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
        this.SubPartList[this.SubpartNr(this.tableId)].ShiftUp();
        this.RefreshCellInfo();
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
      if (nr == 37 & this.detaily > 0)
      {
        --this.detaily;
        this.RefreshCellInfo();
        this.SubPartList[this.SubpartNr(this.tableId)].ShiftLeft();
        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (!(nr == 39 & this.detaily < this.stringy.Width))
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
            if (num1 == this.tab1id)
            {
              this.tabId = 1;
              this.detailx = -1;
              this.detaily = -1;
              this.RemoveSubPart(this.tableId);
              this.tableId = 0;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.tab2id)
            {
              this.tabId = 2;
              this.detailx = -1;
              this.detaily = -1;
              this.RemoveSubPart(this.tableId);
              this.tableId = 0;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.tab3id)
            {
              this.tabId = 3;
              this.detailx = -1;
              this.detaily = -1;
              this.RemoveSubPart(this.tableId);
              this.tableId = 0;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.tab4id)
            {
              this.tabId = 4;
              this.detailx = -1;
              this.detaily = -1;
              this.RemoveSubPart(this.tableId);
              this.tableId = 0;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.loadId)
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
              string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Historical library(*.se1his)|*.se1his", "Pick a historical library...", tinitdir, false);
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
                if (Interaction.MsgBox((object) "Update with masterfile?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                {
                  this.game.Data.MasterfileReadPeople = false;
                  string masterfileStart = this.masterfileStart;
                  string filename = this.game.HandyFunctionsObj.ReturnLongMaster(str, masterfileStart);
                  this.game.EditObj.LoadString = "Loading Masterfile";
                  this.game.HandyFunctionsObj.LoadMasterFile(filename, alsohistorical: false, LoadVariants: false);
                }
                this.game.Data.MasterFile = "";
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
                int num4 = (int) Interaction.MsgBox((object) "Loaded Historical Library", Title: ((object) "Shadow Empire : Planetary Conquest"));
                this.detailx = -1;
                this.detaily = -1;
                this.RemoveSubPart(this.tableId);
                this.tableId = 0;
                this.DoStuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.saveId)
            {
              this.game.Data.MasterFile = "";
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
              string str = this.game.HandyFunctionsObj.SaveSomething("SE1 Historical library(*.se1his)|*.se1his", "Give save name...", tinitdir, false);
              if (Strings.Len(str) < 2)
              {
                int num5 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                this.Interpret();
                this.game.Data.serialize(str);
                this.game.HandyFunctionsObj.ZipFile(str);
                windowReturnClass1.SetFlag(true);
                this.game.FormRef.Cursor = Cursors.Default;
                this.game.Data.LoadGraphics(this.formref);
                int num6 = (int) Interaction.MsgBox((object) "Completed & Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
              int tnr2_1;
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
              else if (num1 == this.noneId)
              {
                if (this.tabId == 3)
                {
                  if (this.detaily <= 1)
                  {
                    int num7 = (int) Interaction.MsgBox((object) "Cannot change", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    if (this.detaily == 4)
                    {
                      this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      this.stringy.Data[this.detailx, this.detaily] = "-1";
                      this.game.Data.HistoricalUnitObj[this.currentHisNr].SmallGfx = -1;
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily >= 14)
                    {
                      this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int index3 = (int) Math.Round((double) this.detaily / 2.0 - 7.0);
                      this.stringy.Data[this.detailx, this.detaily] = "-1";
                      this.game.Data.HistoricalUnitObj[this.currentHisNr].DesignationSmall[index3] = -1;
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                  }
                }
              }
              else if (num1 == this.editId)
              {
                this.oldTopX = ((MatrixSubPartClass) this.SubPartList[this.SubpartNr(this.tableId)]).TopItemX;
                this.oldTopY = ((MatrixSubPartClass) this.SubPartList[this.SubpartNr(this.tableId)]).TopItemY;
                if (this.tabId == 1)
                {
                  if (this.detaily == 0)
                  {
                    int num8 = (int) Interaction.MsgBox((object) "Changeing the ID# is not advised and for EXPERT USE ONLY. ", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    if (Interaction.MsgBox((object) "Change ID# ?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                    {
                      this.currentPplNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int num9 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new ID#", "Shadow Empire : Planetary Conquest", this.game.Data.PeopleObj[this.currentPplNr].id.ToString())));
                      this.stringy.Data[this.detailx, this.detaily] = num9.ToString();
                      this.game.Data.PeopleObj[this.currentPplNr].id = num9;
                      if (this.game.Data.PeopleIdCounter < num9)
                        this.game.Data.PeopleIdCounter = num9;
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                  }
                  else
                  {
                    if (this.detaily == 1)
                    {
                      this.currentPplNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      string str = Interaction.InputBox("Give name.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                      this.stringy.Data[this.detailx, this.detaily] = str;
                      this.game.Data.PeopleObj[this.currentPplNr].Name = str;
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 2)
                    {
                      this.currentPplNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int num10 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give breakAt (0-100).", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily])));
                      if (num10 >= 0 & num10 <= 100)
                      {
                        this.stringy.Data[this.detailx, this.detaily] = num10.ToString();
                        this.game.Data.PeopleObj[this.currentPplNr].BreakAt = num10;
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                      }
                      else
                      {
                        int num11 = (int) Interaction.MsgBox((object) "no go. Between 0-100 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      return windowReturnClass1;
                    }
                    if (this.detaily == 7)
                    {
                      this.currentPplNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int num12 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give ArtCode. 0=default/none.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily])));
                      if (num12 >= 0 & num12 <= 100)
                      {
                        this.stringy.Data[this.detailx, this.detaily] = num12.ToString();
                        this.game.Data.PeopleObj[this.currentPplNr].artCode = num12;
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                      }
                      else
                      {
                        int num13 = (int) Interaction.MsgBox((object) "no go. Between 0-100 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      return windowReturnClass1;
                    }
                    if (this.detaily == 5)
                    {
                      this.currentPplNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int num14 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give BaseMorale (0-100).", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily])));
                      if (num14 >= 0 & num14 <= 100)
                      {
                        this.stringy.Data[this.detailx, this.detaily] = num14.ToString();
                        int index4 = 0;
                        do
                        {
                          this.game.Data.PeopleObj[this.currentPplNr].BaseMorale[index4] = num14;
                          ++index4;
                        }
                        while (index4 <= 99);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                      }
                      else
                      {
                        int num15 = (int) Interaction.MsgBox((object) "no go. Between 0-100 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      return windowReturnClass1;
                    }
                    if (this.detaily == 6)
                    {
                      this.currentPplNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      if (Interaction.MsgBox((object) "Use Color?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                      {
                        int num16 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Red (0-255).", "Shadow Empire : Planetary Conquest")));
                        if (num16 >= 0 & num16 <= (int) byte.MaxValue)
                        {
                          this.game.Data.PeopleObj[this.currentPplNr].Red = num16;
                        }
                        else
                        {
                          int num17 = (int) Interaction.MsgBox((object) "no go. Between 0-255 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        int num18 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Green (0-255).", "Shadow Empire : Planetary Conquest")));
                        if (num18 >= 0 & num18 <= (int) byte.MaxValue)
                        {
                          this.game.Data.PeopleObj[this.currentPplNr].Green = num18;
                        }
                        else
                        {
                          int num19 = (int) Interaction.MsgBox((object) "no go. Between 0-255 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        int num20 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Blue (0-255).", "Shadow Empire : Planetary Conquest")));
                        if (num20 >= 0 & num20 <= (int) byte.MaxValue)
                        {
                          this.game.Data.PeopleObj[this.currentPplNr].Blue = num20;
                        }
                        else
                        {
                          int num21 = (int) Interaction.MsgBox((object) "no go. Between 0-255 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                      }
                      else
                      {
                        this.game.Data.PeopleObj[this.currentPplNr].Red = -1;
                        this.game.Data.PeopleObj[this.currentPplNr].Green = -1;
                        this.game.Data.PeopleObj[this.currentPplNr].Blue = -1;
                      }
                      string str;
                      if (this.game.Data.PeopleObj[this.currentPplNr].Red > -1)
                        str = this.game.Data.PeopleObj[this.currentPplNr].Red.ToString() + "," + this.game.Data.PeopleObj[this.currentPplNr].Green.ToString() + "," + this.game.Data.PeopleObj[this.currentPplNr].Blue.ToString();
                      else
                        str = "No color";
                      this.stringy.Data[this.detailx, this.detaily] = str;
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
                        this.currentPplNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.PeopleObj[this.currentPplNr].SidewaysFileName = str;
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      int num22 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else if (this.detaily == 4)
                    {
                      string String1 = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of sideways Sprite:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + String1))
                      {
                        if (Strings.InStr(String1, "BIG") > 0 | Strings.InStr(String1, "SMALL") > 0)
                        {
                          int num23 = (int) Interaction.MsgBox((object) "You cannot load a file that in the path include 'BIG' or 'SMALL'.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        else
                        {
                          this.currentPplNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                          this.stringy.Data[this.detailx, this.detaily] = String1;
                          this.game.Data.PeopleObj[this.currentPplNr].NationalFileName = String1;
                          this.RemoveSubPart(this.tableId);
                          this.tableId = 0;
                          this.DoStuff();
                          windowReturnClass1.SetFlag(true);
                          return windowReturnClass1;
                        }
                      }
                      else
                      {
                        int num24 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                    }
                  }
                }
                if (this.tabId == 2)
                {
                  if (this.detaily <= 1)
                  {
                    int num25 = (int) Interaction.MsgBox((object) "Cannot change", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    if (this.detaily == 2)
                    {
                      this.currentUnitNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      string str = Interaction.InputBox("Give name.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                      this.stringy.Data[this.detailx, this.detaily] = str;
                      this.game.Data.UnitObj[this.currentUnitNr].Name = str;
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 3)
                    {
                      this.currentUnitNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      if (Interaction.MsgBox((object) "Is HQ?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                        this.game.Data.UnitObj[this.currentUnitNr].IsHQ = true;
                      else
                        this.game.Data.UnitObj[this.currentUnitNr].IsHQ = false;
                      this.stringy.Data[this.detailx, this.detaily] = this.game.Data.UnitObj[this.currentUnitNr].IsHQ.ToString();
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if ((this.detaily - 4 + 5) % 5 == 0)
                    {
                      this.currentUnitNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int index5 = (int) Math.Round(Conversion.Int((double) (this.detaily - 4) / 5.0));
                      while (index5 > this.game.Data.UnitObj[this.currentUnitNr].SFCount)
                      {
                        this.game.Data.AddSF(this.currentUnitNr);
                        this.game.Data.SFObj[this.game.Data.SFCounter].People = -1;
                      }
                      this.Change = true;
                      new Form3((Form) this.formref).Initialize(this.game.Data, 131, this.game.Data.UnitObj[this.currentUnitNr].SFList[index5], tGame: this.game);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if ((this.detaily - 4 + 5) % 5 == 1)
                    {
                      this.currentUnitNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int index6 = (int) Math.Round(Conversion.Int((double) (this.detaily - 4) / 5.0));
                      while (index6 > this.game.Data.UnitObj[this.currentUnitNr].SFCount)
                      {
                        this.game.Data.AddSF(this.currentUnitNr);
                        this.game.Data.SFObj[this.game.Data.SFCounter].People = -1;
                      }
                      this.Change = true;
                      new Form3((Form) this.formref).Initialize(this.game.Data, 132, this.game.Data.UnitObj[this.currentUnitNr].SFList[index6], tGame: this.game);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if ((this.detaily - 4 + 5) % 5 == 2)
                    {
                      this.currentUnitNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int index7 = (int) Math.Round(Conversion.Int((double) (this.detaily - 4) / 5.0));
                      while (index7 > this.game.Data.UnitObj[this.currentUnitNr].SFCount)
                      {
                        this.game.Data.AddSF(this.currentUnitNr);
                        this.game.Data.SFObj[this.game.Data.SFCounter].People = -1;
                      }
                      int sf = this.game.Data.UnitObj[this.currentUnitNr].SFList[index7];
                      int num26 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Qty (0-999).", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily])));
                      if (num26 >= 0 & num26 <= 999)
                      {
                        this.stringy.Data[this.detailx, this.detaily] = num26.ToString();
                        this.game.Data.SFObj[sf].Qty = num26;
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                      }
                      else
                      {
                        int num27 = (int) Interaction.MsgBox((object) "no go. Between 0-999 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      return windowReturnClass1;
                    }
                    if ((this.detaily - 4 + 5) % 5 == 3)
                    {
                      this.currentUnitNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int index8 = (int) Math.Round(Conversion.Int((double) (this.detaily - 4) / 5.0));
                      while (index8 > this.game.Data.UnitObj[this.currentUnitNr].SFCount)
                      {
                        this.game.Data.AddSF(this.currentUnitNr);
                        this.game.Data.SFObj[this.game.Data.SFCounter].People = -1;
                      }
                      int sf = this.game.Data.UnitObj[this.currentUnitNr].SFList[index8];
                      int num28 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Mor (0-100).", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily])));
                      if (num28 >= 0 & num28 <= 100)
                      {
                        this.stringy.Data[this.detailx, this.detaily] = num28.ToString();
                        this.game.Data.SFObj[sf].Mor = num28;
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                      }
                      else
                      {
                        int num29 = (int) Interaction.MsgBox((object) "no go. Between 0-100 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      return windowReturnClass1;
                    }
                    if ((this.detaily - 4 + 5) % 5 == 4)
                    {
                      this.currentUnitNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      int index9 = (int) Math.Round(Conversion.Int((double) (this.detaily - 4) / 5.0));
                      while (index9 > this.game.Data.UnitObj[this.currentUnitNr].SFCount)
                      {
                        this.game.Data.AddSF(this.currentUnitNr);
                        this.game.Data.SFObj[this.game.Data.SFCounter].People = -1;
                      }
                      int sf = this.game.Data.UnitObj[this.currentUnitNr].SFList[index9];
                      int num30 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give XP (0-100).", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily])));
                      if (num30 >= 0 & num30 <= 100)
                      {
                        this.stringy.Data[this.detailx, this.detaily] = num30.ToString();
                        this.game.Data.SFObj[sf].Xp = num30;
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                      }
                      else
                      {
                        int num31 = (int) Interaction.MsgBox((object) "no go. Between 0-100 plz", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      return windowReturnClass1;
                    }
                  }
                }
                if (this.tabId == 3)
                {
                  if (this.detaily <= 1)
                  {
                    int num32 = (int) Interaction.MsgBox((object) "Cannot change", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    if (this.detaily == 2)
                    {
                      this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      string str = Interaction.InputBox("Give name.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                      this.stringy.Data[this.detailx, this.detaily] = str;
                      this.game.Data.HistoricalUnitObj[this.currentHisNr].Name = str;
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 3)
                    {
                      this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      this.Change = true;
                      new Form3((Form) this.formref).Initialize(this.game.Data, 133, this.currentHisNr, tGame: this.game);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 4)
                    {
                      string str = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Small Gfx:", this.game.AppPath + "graphics\\", true);
                      if (Information.IsNothing((object) str))
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        this.stringy.TempBmp[this.detailx, this.detaily] = 0;
                        this.stringy.Data[this.detailx, this.detaily] = "";
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].SmallGfx = -1;
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (File.Exists(this.game.AppPath + "graphics/" + str))
                      {
                        if (Strings.InStr(str, "BIG") > 0 | Strings.InStr(str, "SMALL") > 0)
                        {
                          int num33 = (int) Interaction.MsgBox((object) "You cannot load a file that in the path include 'BIG' or 'SMALL'.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        else
                        {
                          int index10 = this.game.Data.FindSmallPic(str, -1, this.game.Data.LibraryObj[0].name);
                          if (index10 == -1)
                          {
                            this.game.Data.AddSmallPic(str);
                            this.game.Data.SmallLibId[this.game.Data.SmallPicCounter].libSlot = 0;
                            this.game.Data.SmallLibId[this.game.Data.SmallPicCounter].id = -1;
                            index10 = this.game.Data.SmallPicCounter;
                          }
                          this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                          this.stringy.TempBmp[this.detailx, this.detaily] = this.game.Data.SmallPicNr[index10];
                          this.stringy.Data[this.detailx, this.detaily] = index10.ToString();
                          this.game.Data.HistoricalUnitObj[this.currentHisNr].SmallGfx = index10;
                          this.RemoveSubPart(this.tableId);
                          this.tableId = 0;
                          this.DoStuff();
                          windowReturnClass1.SetFlag(true);
                          return windowReturnClass1;
                        }
                      }
                      else
                      {
                        int num34 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                    }
                    else
                    {
                      if (this.detaily == 5)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string str = Interaction.InputBox("Give shortname.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].CounterString = str;
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 6)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string InputStr = Interaction.InputBox("Give Political Points.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = InputStr;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].PP = (int) Math.Round(Conversion.Val(InputStr));
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 7)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        this.Change = true;
                        new Form3((Form) this.formref).Initialize(this.game.Data, 134, this.currentHisNr, tGame: this.game);
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 8)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string str = Interaction.InputBox("Give value", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].NameCounter = Conversions.ToInteger(str);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 9)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        if (Interaction.MsgBox((object) "Use Roman Numerals?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                        {
                          this.stringy.Data[this.detailx, this.detaily] = "True";
                          this.game.Data.HistoricalUnitObj[this.currentHisNr].UseRomans = true;
                        }
                        else
                        {
                          this.stringy.Data[this.detailx, this.detaily] = "False";
                          this.game.Data.HistoricalUnitObj[this.currentHisNr].UseRomans = false;
                        }
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 10)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        this.Change = true;
                        new Form3((Form) this.formref).Initialize(this.game.Data, 135, this.currentHisNr, tGame: this.game);
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 11)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        this.Change = true;
                        new Form3((Form) this.formref).Initialize(this.game.Data, 137, this.currentHisNr, tnr2_1, this.game);
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 12)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string str = Interaction.InputBox("Give value", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].MaxPresent = Conversions.ToInteger(str);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 13)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string str = Interaction.InputBox("Give value (0=no,1=yes)", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = str;
                        this.game.Data.HistoricalUnitObj[this.currentHisNr].BattleGroup = Conversions.ToInteger(str);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily >= 14 & this.detaily % 2 == 0)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        int tnr2_2 = (int) Math.Round(Conversion.Int((double) (this.detaily - 13) / 2.0));
                        this.Change = true;
                        new Form3((Form) this.formref).Initialize(this.game.Data, 136, this.currentHisNr, tnr2_2, this.game);
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily >= 15 & this.detaily % 2 == 1)
                      {
                        this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        int index11 = (int) Math.Round(Conversion.Int((double) (this.detaily - 13) / 2.0)) - 1;
                        string str = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Small Gfx", this.game.AppPath + "graphics\\", true);
                        if (!Information.IsNothing((object) str))
                        {
                          if (File.Exists(this.game.AppPath + "graphics/" + str))
                          {
                            if (Strings.InStr(str, "BIG") > 0 | Strings.InStr(str, "SMALL") > 0)
                            {
                              int num35 = (int) Interaction.MsgBox((object) "You cannot load a file that in the path include 'BIG' or 'SMALL'.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                            }
                            else
                            {
                              int index12 = this.game.Data.FindSmallPic(str, -1, this.game.Data.LibraryObj[0].name);
                              if (index12 == -1)
                              {
                                this.game.Data.AddSmallPic(str);
                                this.game.Data.SmallLibId[this.game.Data.SmallPicCounter].libSlot = 0;
                                this.game.Data.SmallLibId[this.game.Data.SmallPicCounter].id = -1;
                                index12 = this.game.Data.SmallPicCounter;
                              }
                              this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                              this.stringy.TempBmp[this.detailx, this.detaily] = this.game.Data.SmallPicNr[index12];
                              this.stringy.Data[this.detailx, this.detaily] = index12.ToString();
                              this.game.Data.HistoricalUnitObj[this.currentHisNr].DesignationSmall[index11] = index12;
                              this.RemoveSubPart(this.tableId);
                              this.tableId = 0;
                              this.DoStuff();
                              windowReturnClass1.SetFlag(true);
                              return windowReturnClass1;
                            }
                          }
                          else
                          {
                            int num36 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          }
                        }
                      }
                    }
                  }
                }
                if (this.tabId == 4)
                {
                  if (this.detaily <= 1)
                  {
                    int num37 = (int) Interaction.MsgBox((object) "Cannot change", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    if (this.detaily == 2)
                    {
                      this.currentInstNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      string str = Interaction.InputBox("Give name.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                      this.stringy.Data[this.detailx, this.detaily] = str;
                      this.game.Data.HistoricalUnitObj[this.currentInstNr].Name = str;
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 3)
                    {
                      this.currentInstNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      this.Change = true;
                      new Form3((Form) this.formref).Initialize(this.game.Data, 138, this.currentInstNr, tGame: this.game);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 4)
                    {
                      this.currentInstNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      string str = Interaction.InputBox("Give shortname", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                      this.stringy.Data[this.detailx, this.detaily] = str;
                      this.game.Data.HistoricalUnitObj[this.currentInstNr].CounterString = str;
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily >= 5)
                    {
                      this.currentInstNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      string str = Interaction.InputBox("Give value", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                      this.stringy.Data[this.detailx, this.detaily] = str;
                      if (this.detaily == 5)
                        this.game.Data.HistoricalUnitObj[this.currentInstNr].TempVar1 = Conversions.ToInteger(str);
                      if (this.detaily == 6)
                        this.game.Data.HistoricalUnitObj[this.currentInstNr].TempVar2 = Conversions.ToInteger(str);
                      if (this.detaily == 7)
                        this.game.Data.HistoricalUnitObj[this.currentInstNr].TempVar3 = Conversions.ToInteger(str);
                      if (this.detaily == 8)
                        this.game.Data.HistoricalUnitObj[this.currentInstNr].TempVar4 = Conversions.ToInteger(str);
                      if (this.detaily == 9)
                        this.game.Data.HistoricalUnitObj[this.currentInstNr].TempVar5 = Conversions.ToInteger(str);
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                  }
                  return windowReturnClass1;
                }
              }
              else
              {
                if (num1 == this.removeId)
                {
                  if (this.tabId == 1)
                  {
                    this.currentPplNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                    --this.detailx;
                    this.game.Data.RemovePeople(this.currentPplNr);
                  }
                  else if (this.tabId == 2)
                  {
                    this.currentUnitNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                    --this.detailx;
                    DataClass data = this.game.Data;
                    int currentUnitNr = this.currentUnitNr;
                    GameClass gameClass = (GameClass) null;
                    ref GameClass local = ref gameClass;
                    data.RemoveUnit(currentUnitNr, ref local);
                  }
                  else if (this.tabId == 3)
                  {
                    this.currentHisNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                    --this.detailx;
                    this.game.Data.RemoveHistoricalUnit(this.currentHisNr);
                  }
                  else if (this.tabId == 4)
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
                  if (this.tabId == 3 | this.tabId == 4)
                  {
                    int num38 = 0;
                    int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                    for (int index13 = 0; index13 <= historicalUnitCounter; ++index13)
                    {
                      if (this.game.Data.HistoricalUnitObj[index13].ID >= num38)
                        num38 = this.game.Data.HistoricalUnitObj[index13].ID;
                    }
                    if (num38 + 100 < this.game.Data.HistoricalIDCounter)
                      this.game.Data.HistoricalIDCounter = num38 + 100;
                  }
                  if (this.tabId == 1)
                  {
                    this.game.Data.AddPeople();
                    this.game.Data.PeopleObj[this.game.Data.PeopleCounter].LibId.libSlot = 0;
                  }
                  else if (this.tabId == 2)
                  {
                    tnr2_1 = this.game.Data.AddUnit(0, 0, 0);
                    int unitCounter = this.game.Data.UnitCounter;
                    this.game.Data.UnitObj[unitCounter].Regime = 0;
                    this.game.Data.MapObj[0].HexObj[0, 0].RemoveUnitFromList(unitCounter);
                    this.game.Data.UnitObj[unitCounter].PreDef = this.game.HandyFunctionsObj.GetNextPreDefNr();
                    this.game.Data.UnitObj[unitCounter].LibId.libSlot = 0;
                  }
                  else if (this.tabId == 3)
                  {
                    this.game.Data.AddHistoricalUnit();
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Model = true;
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].TempRegime = 0;
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId.libSlot = 0;
                  }
                  else if (this.tabId == 4)
                  {
                    this.game.Data.AddHistoricalUnit();
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].Model = false;
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].TempRegime = 0;
                    this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitCounter].LibId.libSlot = 0;
                  }
                  this.RemoveSubPart(this.tableId);
                  this.tableId = 0;
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
                  string path = this.game.HandyFunctionsObj.LoadSomething("SE1 Troops&Equipment library(*.se1troops)|*.se1troops", "Pick troopType library...", this.game.AppPath + this.game.ModScenarioDir, false);
                  if (File.Exists(path))
                  {
                    this.game.EditObj.TempFileName = path;
                    this.game.EditObj.TempFileType = NewEnums.LibFileType.ImportTroopsInHistoricalEditor;
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    DataClass dataClass;
                    this.game.HandyFunctionsObj.LoadLibrary(ref dataClass);
                    bool[] import = new bool[dataClass.LibraryCounter + 1];
                    int[] subreg = new int[dataClass.RegimeCounter + 1];
                    int[] subPpl = new int[dataClass.PeopleCounter + 1];
                    int[] sublib = new int[dataClass.LibraryCounter + 1];
                    int libraryCounter1 = dataClass.LibraryCounter;
                    for (int index14 = 0; index14 <= libraryCounter1; ++index14)
                    {
                      sublib[index14] = -1;
                      import[index14] = false;
                    }
                    int regimeCounter = dataClass.RegimeCounter;
                    for (int index15 = 0; index15 <= regimeCounter; ++index15)
                      subreg[index15] = 0;
                    int peopleCounter = dataClass.PeopleCounter;
                    for (int index16 = 0; index16 <= peopleCounter; ++index16)
                      subPpl[index16] = -1;
                    int libraryCounter2 = dataClass.LibraryCounter;
                    for (int index17 = 0; index17 <= libraryCounter2; ++index17)
                    {
                      sublib[index17] = -1;
                      int libraryCounter3 = this.game.Data.LibraryCounter;
                      for (int index18 = 0; index18 <= libraryCounter3; ++index18)
                      {
                        if (Operators.CompareString(this.game.Data.LibraryObj[index18].name, dataClass.LibraryObj[index17].name, false) == 0)
                        {
                          bool flag;
                          sublib[-(flag ? 1 : 0)] = index18;
                        }
                      }
                      int sfTypeCounter = dataClass.SFTypeCounter;
                      for (int index19 = 0; index19 <= sfTypeCounter; ++index19)
                      {
                        if (dataClass.SFTypeObj[index19].LibId.libSlot == index17)
                          import[index17] = true;
                      }
                    }
                    this.game.HandyFunctionsObj.ActuallyImportLibs(ref dataClass, ref import, ref sublib, ref subPpl, ref subreg);
                    int num39 = (int) Interaction.MsgBox((object) "Import completed", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.game.FormRef.Cursor = Cursors.Default;
                    this.RemoveSubPart(this.tableId);
                    this.tableId = 0;
                    this.DoStuff();
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
                  }
                  int num40 = (int) Interaction.MsgBox((object) "Could not find file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.listId)
                {
                  int num41 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  this.SubPartFlag[index1] = true;
                  if (num41 > -1)
                  {
                    this.detailnr = num41;
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
                  string str1 = this.game.HandyFunctionsObj.LoadSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Select file to import...", this.game.AppPath + "csv/", false);
                  if (Strings.Len(str1) < 2)
                  {
                    int num42 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    StreamReader Expression;
                    WindowReturnClass windowReturnClass2;
                    try
                    {
                      Expression = File.OpenText(str1);
                      int num43 = 0;
                      string str2 = ",";
                      while (!Expression.EndOfStream)
                      {
                        string str3 = Expression.ReadLine();
                        if ((uint) Strings.InStr(str3, "sep=") > 0U)
                        {
                          str2 = Strings.Mid(str3, 5, 1);
                          num43 = 1;
                        }
                        else
                        {
                          switch (num43)
                          {
                            case 0:
                              if (Strings.InStr(str3, "\t") > 0)
                                str2 = "\t";
                              else if (Strings.InStr(str3, ",") > 0)
                                str2 = ",";
                              else if (Strings.InStr(str3, ";") > 0)
                                str2 = ";";
                              num43 = 2;
                              continue;
                            case 1:
                              num43 = 2;
                              continue;
                            case 2:
                              string[] strArray = str3.Split(Conversions.ToChar(str2));
                              int id = (int) Math.Round(Conversion.Val(strArray[0]));
                              int index20;
                              if (id > 0)
                              {
                                index20 = this.game.HandyFunctionsObj.GetHistoricalUnitByID(id);
                                if (index20 == -1)
                                {
                                  this.game.Data.AddHistoricalUnit();
                                  index20 = this.game.Data.HistoricalUnitCounter;
                                  this.game.Data.HistoricalUnitObj[index20].ID = Conversions.ToInteger(strArray[0]);
                                }
                                else if (this.game.Data.HistoricalUnitObj[index20].Model)
                                {
                                  this.game.Data.AddHistoricalUnit();
                                  index20 = this.game.Data.HistoricalUnitCounter;
                                  strArray[0] = Conversions.ToString(this.game.Data.HistoricalUnitObj[index20].ID);
                                }
                              }
                              else
                              {
                                this.game.Data.AddHistoricalUnit();
                                index20 = this.game.Data.HistoricalUnitCounter;
                                strArray[0] = Conversions.ToString(this.game.Data.HistoricalUnitObj[index20].ID);
                              }
                              this.game.Data.HistoricalUnitObj[index20].ID = (int) Math.Round(Conversion.Val(strArray[0]));
                              this.game.Data.HistoricalUnitObj[index20].Name = strArray[1];
                              this.game.Data.HistoricalUnitObj[index20].ModelMaster = this.game.HandyFunctionsObj.GetHistoricalUnitByID((int) Math.Round(Conversion.Val(strArray[2])));
                              this.game.Data.HistoricalUnitObj[index20].CounterString = strArray[3];
                              this.game.Data.HistoricalUnitObj[index20].TempVar1 = (int) Math.Round(Conversion.Val(strArray[4]));
                              this.game.Data.HistoricalUnitObj[index20].TempVar2 = (int) Math.Round(Conversion.Val(strArray[5]));
                              this.game.Data.HistoricalUnitObj[index20].TempVar3 = (int) Math.Round(Conversion.Val(strArray[6]));
                              this.game.Data.HistoricalUnitObj[index20].TempVar4 = (int) Math.Round(Conversion.Val(strArray[7]));
                              this.game.Data.HistoricalUnitObj[index20].TempVar5 = (int) Math.Round(Conversion.Val(strArray[8]));
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
                      int num44 = (int) Interaction.MsgBox((object) ("Import problem encountered: '" + exception.Message + "'. Your current data might be corrupted. "), Title: ((object) "Shadow Empire : Planetary Conquest"));
                      this.RemoveSubPart(this.tableId);
                      this.tableId = 0;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      windowReturnClass2 = windowReturnClass1;
                      ProjectData.ClearProjectError();
                      goto label_350;
                    }
                    Expression.Close();
                    int num45 = (int) Interaction.MsgBox((object) "Import finished", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.RemoveSubPart(this.tableId);
                    this.tableId = 0;
                    this.DoStuff();
                    windowReturnClass1.SetFlag(true);
                    return windowReturnClass1;
label_350:
                    return windowReturnClass2;
                  }
                }
                else if (num1 == this.exportCsv)
                {
                  string str4 = this.game.HandyFunctionsObj.SaveSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Give save name...", this.game.AppPath + "csv/", false);
                  if (Strings.Len(str4) < 2)
                  {
                    int num46 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    try
                    {
                      StreamWriter text = File.CreateText(str4);
                      try
                      {
                        text.WriteLine("sep=\t");
                        string str5 = "" + "ID#" + "\t" + "Name" + "\t" + "Based On Model" + "\t" + "Shortname" + "\t" + "tv1" + "\t" + "tv2" + "\t" + "tv3" + "\t" + "tv4" + "\t" + "tv5";
                        text.WriteLine(str5);
                        int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
                        for (int index21 = 0; index21 <= historicalUnitCounter; ++index21)
                        {
                          if (!this.game.Data.HistoricalUnitObj[index21].Model)
                          {
                            string str6 = "" + this.game.Data.HistoricalUnitObj[index21].ID.ToString() + "\t" + this.game.Data.HistoricalUnitObj[index21].Name + "\t";
                            string str7 = (this.game.Data.HistoricalUnitObj[index21].ModelMaster <= -1 ? str6 + "-1" : str6 + this.game.Data.HistoricalUnitObj[this.game.Data.HistoricalUnitObj[index21].ModelMaster].ID.ToString()) + "\t" + this.game.Data.HistoricalUnitObj[index21].CounterString + "\t" + this.game.Data.HistoricalUnitObj[index21].TempVar1.ToString() + "\t" + this.game.Data.HistoricalUnitObj[index21].TempVar2.ToString() + "\t" + this.game.Data.HistoricalUnitObj[index21].TempVar3.ToString() + "\t" + this.game.Data.HistoricalUnitObj[index21].TempVar4.ToString() + "\t" + this.game.Data.HistoricalUnitObj[index21].TempVar5.ToString();
                            text.WriteLine(str7);
                          }
                        }
                        text.Close();
                        int num47 = (int) Interaction.MsgBox((object) "Export has been written to the csv/ directory", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                      catch (Exception ex)
                      {
                        ProjectData.SetProjectError(ex);
                        Exception exception = ex;
                        text.Close();
                        int num48 = (int) Interaction.MsgBox((object) ("Problem writing: " + exception.Message), Title: ((object) "Shadow Empire : Planetary Conquest"));
                        ProjectData.ClearProjectError();
                      }
                    }
                    catch (Exception ex)
                    {
                      ProjectData.SetProjectError(ex);
                      int num49 = (int) Interaction.MsgBox((object) "Problem writing. Check if the file is not opened in other application please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
      bool[] flagArray = new bool[this.game.Data.SmallPicCounter + 1];
      int historicalUnitCounter = this.game.Data.HistoricalUnitCounter;
      for (int index1 = 0; index1 <= historicalUnitCounter; ++index1)
      {
        if (this.game.Data.HistoricalUnitObj[index1].LibId.libSlot == 0)
        {
          this.game.Data.HistoricalUnitObj[index1].NameCounterBackup = this.game.Data.HistoricalUnitObj[index1].NameCounter;
          if (this.game.Data.HistoricalUnitObj[index1].SmallGfx > -1)
          {
            if (this.game.Data.HistoricalUnitObj[index1].SmallGfx == 110)
              index1 = index1;
            flagArray[this.game.Data.HistoricalUnitObj[index1].SmallGfx] = true;
          }
          int index2 = 0;
          do
          {
            if (this.game.Data.HistoricalUnitObj[index1].DesignationSmall[index2] > -1)
              flagArray[this.game.Data.HistoricalUnitObj[index1].DesignationSmall[index2]] = true;
            ++index2;
          }
          while (index2 <= 5);
        }
      }
      for (int smallPicCounter = this.game.Data.SmallPicCounter; smallPicCounter >= 0; smallPicCounter += -1)
      {
        if (this.game.Data.SmallLibId[smallPicCounter].libSlot == 0 && !flagArray[smallPicCounter])
          this.game.Data.RemoveSmallPic(smallPicCounter);
      }
    }
  }
}
