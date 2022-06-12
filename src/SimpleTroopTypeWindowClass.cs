// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleTroopTypeWindowClass
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
  public class SimpleTroopTypeWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int tableId;
    private int loadId;
    private int versionid;
    private int text1id;
    private int detailnr;
    private int addId;
    private int loadMasterId;
    private int addReinf;
    private int removeReinf;
    private int ratioid;
    private int ratioidb;
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
    private int editIdb;
    private int strId;
    private int detailx;
    private int detaily;
    private StringListClass stringy;
    private int VarsStartOn;
    private bool AddNew;
    private bool Change;
    private int currentSfTypeNr;
    private int cellinfoid;
    private int[] ColIsSFTypeVar;
    private int exportCsv;
    private int importCsv;
    private string lastsound;
    private string masterfileStart;

    public SimpleTroopTypeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight, 9, tDoBorders: 1, tHeaderString: "Intermediate TroopType Editor")
    {
      this.ColIsSFTypeVar = new int[100];
      this.detailx = -1;
      this.detaily = -1;
      this.detailnr = -1;
      this.currentSfTypeNr = -1;
      this.AddNew = false;
      this.Change = false;
      this.lastsound = "";
      this.game.EditObj.TempSFType = -1;
      this.masterfileStart = this.game.Data.MasterFile;
      this.DoStuff();
    }

    public override void DoRefresh()
    {
      if (!((this.AddNew | this.Change) & this.currentSfTypeNr > -1))
        return;
      if (this.tableId > 0)
        this.RemoveSubPart(this.tableId);
      this.tableId = 0;
      this.AddNew = false;
      this.Change = false;
      this.currentSfTypeNr = -1;
      this.DoStuff();
    }

    public void PopUpRefresh()
    {
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
      if (!(this.detailx > -1 & this.detaily >= 8 & this.detaily <= 9) || Operators.CompareString(this.lastsound, this.stringy.Data[this.detailx, this.detaily], false) == 0)
        return;
      this.lastsound = this.stringy.Data[this.detailx, this.detaily];
      SoundMod.PlayAWave(this.game.AppPath + "sound/" + this.stringy.Data[this.detailx, this.detaily], ref this.game.EditObj);
    }

    public void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = this.game.ScreenHeight - 768;
      string str = "";
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight, -1);
      int num3 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 322) / 24.0)) - 1;
      int num4 = 172 + num3 * 24 + 46;
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
      if (this.loadMasterId > 0)
        this.RemoveSubPart(this.loadMasterId);
      if (this.loadId > 0)
        this.RemoveSubPart(this.loadId);
      if (this.exportCsv > 0)
        this.RemoveSubPart(this.exportCsv);
      if (this.importCsv > 0)
        this.RemoveSubPart(this.importCsv);
      if (this.cellinfoid > 0)
      {
        this.RemoveSubPart(this.cellinfoid);
        this.cellinfoid = 0;
      }
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
      if (this.ratioid > 0)
        this.RemoveSubPart(this.ratioid);
      if (this.ratioidb > 0)
        this.RemoveSubPart(this.ratioidb);
      if (this.listId > 0)
        this.RemoveSubPart(this.listId);
      this.listObj = new ListClass();
      int reinfCounter1 = this.game.Data.ReinfCounter;
      for (int tdata = 0; tdata <= reinfCounter1; ++tdata)
        this.listObj.add(this.game.Data.ReinfName[tdata] + " (ratio:" + this.game.Data.ReinfRatio[tdata].ToString() + ")", tdata);
      ListClass listObj = this.listObj;
      int detailnr = this.detailnr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(listObj, 24, 250, detailnr, game, true, "ReinforcementTypes", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 10, bby: 192, tMarcStyle: true, overruleFont: (ref local2));
      this.listId = this.AddSubPart(ref tsubpart1, 10, 192, 250, 432, 0);
      DrawMod.DrawTextColouredMarc(ref objgraphics, "REINFORCEMENT TYPES", this.game.MarcFont4, 15, 172, Color.White);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Add ReinfType", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 620, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addReinf = this.AddSubPart(ref tsubpart2, 10, 620, 190, 35, 1);
      if (this.detailnr > -1)
      {
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Remove ReinfType", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 660, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeReinf = this.AddSubPart(ref tsubpart3, 10, 660, 190, 35, 1);
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Rename ReinfType", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 700, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RenameReinf = this.AddSubPart(ref tsubpart4, 10, 700, 190, 35, 1);
        SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Set Ratio", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 740, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.ratioid = this.AddSubPart(ref tsubpart5, 10, 740, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Remove ReinfType", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 660, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RemoveReinfb = this.AddSubPart(ref tsubpart6, 10, 660, 190, 35, 1);
        SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("Rename ReinfType", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 700, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.RenameReinfb = this.AddSubPart(ref tsubpart7, 10, 700, 190, 35, 1);
        SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass("Set Ratio", 190, tBackbitmap: (ref this.OwnBitmap), bbx: 10, bby: 740, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.ratioidb = this.AddSubPart(ref tsubpart8, 10, 740, 190, 35, 1);
      }
      if (this.detailx > -1 & this.detaily > -1 & !Information.IsNothing((object) this.stringy))
        this.RefreshCellInfo();
      int smallPicCounter = this.game.Data.SmallPicCounter;
      for (int index = 0; index <= smallPicCounter; ++index)
      {
        this.game.Data.SmallLibId[index].libSlot = -1;
        this.game.Data.SmallLibId[index].id = -1;
      }
      if (this.tableId == 0)
      {
        this.stringy = new StringListClass(-1);
        int col1 = 1 - 1;
        this.stringy.AddCol(col1, "Slot#");
        int col2 = col1 + 1;
        this.stringy.AddCol(col2, "BasedOn");
        int col3 = col2 + 1;
        this.stringy.AddCol(col3, "Name");
        int col4 = col3 + 1;
        this.stringy.AddCol(col4, "ReinfType1");
        int col5 = col4 + 1;
        this.stringy.AddCol(col5, "ReinfType2");
        int col6 = col5 + 1;
        this.stringy.AddCol(col6, "Description");
        int col7 = col6 + 1;
        this.stringy.AddCol(col7, "Symbol Gfx");
        int col8 = col7 + 1;
        this.stringy.AddCol(col8, "Sideways Gfx");
        int col9 = col8 + 1;
        this.stringy.AddCol(col9, "Move Sound");
        int col10 = col9 + 1;
        this.stringy.AddCol(col10, "Attack Sound");
        int col11 = col10 + 1;
        this.stringy.AddCol(col11, "Ratio");
        int col12 = col11 + 1;
        this.stringy.AddCol(col12, "Weight");
        int col13 = col12 + 1;
        this.stringy.AddCol(col13, "Carry");
        int col14 = col13 + 1;
        this.stringy.AddCol(col14, "Manpower");
        int col15 = col14 + 1;
        this.stringy.AddCol(col15, "Man.Carry");
        this.VarsStartOn = col15 + 1;
        this.ColIsSFTypeVar = new int[100];
        int num5 = 0;
        do
        {
          if (this.game.Data.TempString[num5 + 600].Length > 0)
          {
            if (Operators.CompareString(Strings.Trim(this.game.Data.TempString[num5 + 600]), "", false) == 0)
              this.game.Data.TempString[num5 + 600] = "";
            if (this.game.Data.TempString[num5 + 600].Length > 0)
            {
              ++col15;
              this.ColIsSFTypeVar[col15] = num5;
              this.stringy.AddCol(col15, this.game.Data.TempString[num5 + 600]);
              if (this.game.Data.TempString[num5 + 1000].Length <= 0)
                ;
            }
          }
          ++num5;
        }
        while (num5 <= 99);
        int index1 = -1;
        int sfTypeCounter = this.game.Data.SFTypeCounter;
        for (int index2 = 0; index2 <= sfTypeCounter; ++index2)
        {
          if (!this.game.Data.SFTypeObj[index2].DontShowInList & this.game.Data.SFTypeObj[index2].CopyDataFrom == -1)
            str = str + this.game.Data.SFTypeObj[index2].Name + " (SFTypeSlot#" + index2.ToString() + ")\r\n";
          else if (!this.game.Data.SFTypeObj[index2].DontShowInList & this.game.Data.SFTypeObj[index2].CopyDataFrom > -1)
          {
            ++index1;
            this.stringy.AddRow(index1 - 1);
            int index3 = 1 - 1;
            this.stringy.Data[index1, index3] = index2.ToString();
            int index4 = index3 + 1;
            this.stringy.Data[index1, index4] = "(" + this.game.Data.SFTypeObj[index2].Ratio.ToString() + "x)" + this.game.Data.SFTypeObj[this.game.Data.SFTypeObj[index2].CopyDataFrom].Name;
            int index5 = index4 + 1;
            this.stringy.Data[index1, index5] = this.game.Data.SFTypeObj[index2].Name;
            int index6 = index5 + 1;
            this.stringy.Data[index1, index6] = this.game.Data.SFTypeObj[index2].ReinforcementType <= -1 ? "None" : this.game.Data.ReinfName[this.game.Data.SFTypeObj[index2].ReinforcementType];
            int index7 = index6 + 1;
            this.stringy.Data[index1, index7] = this.game.Data.SFTypeObj[index2].ReinforcementType2 <= -1 ? "None" : this.game.Data.ReinfName[this.game.Data.SFTypeObj[index2].ReinforcementType2];
            int index8 = index7 + 1;
            this.stringy.Data[index1, index8] = "descript";
            int index9 = index8 + 1;
            this.stringy.Data[index1, index9] = this.game.Data.SFTypeObj[index2].SymbolFileName;
            if (this.game.Data.SFTypeObj[index2].SymbolSpriteID > -1)
              this.stringy.TempBmp[index1, index9] = this.game.Data.SFTypeObj[index2].SymbolSpriteID;
            int index10 = index9 + 1;
            this.stringy.Data[index1, index10] = this.game.Data.SFTypeObj[index2].SidewaysFileName;
            if (this.game.Data.SFTypeObj[index2].SidewaysSpriteID > -1)
              this.stringy.TempBmp[index1, index10] = this.game.Data.SFTypeObj[index2].SidewaysSpriteID;
            int index11 = index10 + 1;
            this.stringy.Data[index1, index11] = this.game.Data.SFTypeObj[index2].MoveWAV;
            int index12 = index11 + 1;
            this.stringy.Data[index1, index12] = this.game.Data.SFTypeObj[index2].BattleWAV;
            int index13 = index12 + 1;
            this.stringy.Data[index1, index13] = this.game.Data.SFTypeObj[index2].Ratio.ToString();
            int index14 = index13 + 1;
            this.stringy.Data[index1, index14] = this.game.Data.SFTypeObj[index2].Weight.ToString();
            int index15 = index14 + 1;
            this.stringy.Data[index1, index15] = this.game.Data.SFTypeObj[index2].CarryCap.ToString();
            int index16 = index15 + 1;
            this.stringy.Data[index1, index16] = this.game.Data.SFTypeObj[index2].manpower.ToString();
            int index17 = index16 + 1;
            this.stringy.Data[index1, index17] = this.game.Data.SFTypeObj[index2].manpowerCarry.ToString();
            int index18 = 0;
            do
            {
              if (this.game.Data.TempString[index18 + 600].Length > 0)
              {
                ++index17;
                this.stringy.Data[index1, index17] = this.game.Data.SFTypeObj[index2].SFTypeVar[index18].ToString();
              }
              ++index18;
            }
            while (index18 <= 99);
          }
        }
        SubPartClass tsubpart9 = (SubPartClass) new MatrixSubPartClass(this.stringy, num3 - 1, this.game.ScreenWidth - 323, this.detailx, this.detaily, this.game, tbackbitmap: (ref this.BackBitmap), bbx: 312, bby: 172, trowheight: 24, tfontsize: 16, tfontoffsety: 4, tMarcy: true);
        this.tableId = this.AddSubPart(ref tsubpart9, 312, 172, this.game.ScreenWidth - 323, num3 * 25, 0);
      }
      if (str.Length > 0)
      {
        int num6 = (int) Interaction.MsgBox((object) ("There is a problem with your masterfile. All the SFTypes in the master should be SFType Models (dontShowInList=True). The following are not: " + str), Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      SubPartClass tsubpart10 = (SubPartClass) new TextButtonPartClass("Add TroopType", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 10), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addId = this.AddSubPart(ref tsubpart10, num1 + 10, num4, 190, 35, 1);
      if (this.detailx > -1)
      {
        SubPartClass tsubpart11 = (SubPartClass) new TextButtonPartClass("Remove TroopType", 190, "Click and remove selected row", ref this.OwnBitmap, num1 + 210, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeId = this.AddSubPart(ref tsubpart11, num1 + 210, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart12 = (SubPartClass) new TextButtonPartClass("Remove TroopType", 190, "No row selected", ref this.OwnBitmap, num1 + 210, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeIdb = this.AddSubPart(ref tsubpart12, num1 + 210, num4, 190, 35, 1);
      }
      if (this.detailx > -1 & this.detaily > -1)
      {
        SubPartClass tsubpart13 = (SubPartClass) new TextButtonPartClass("Change Cell", 190, "Click to edit selected value or text", ref this.OwnBitmap, num1 + 410, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.editId = this.AddSubPart(ref tsubpart13, num1 + 410, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart14 = (SubPartClass) new TextButtonPartClass("Change Cell", 190, "No cell selected", ref this.OwnBitmap, num1 + 410, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.editIdb = this.AddSubPart(ref tsubpart14, num1 + 410, num4, 190, 35, 1);
      }
      if ((double) this.game.Data.RuleVar[946] < 1.0)
      {
        SubPartClass tsubpart15 = (SubPartClass) new TextButtonPartClass("Save Troop Library", 190, "This masterfile does not support creating TroopType libraries", ref this.OwnBitmap, num1 + 610, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.saveIdb = this.AddSubPart(ref tsubpart15, num1 + 610, num4, 190, 35, 1);
      }
      else if (this.stringy.Length > -1)
      {
        SubPartClass tsubpart16 = (SubPartClass) new TextButtonPartClass("Save Troop Library", 190, "Save a TroopType Library", ref this.OwnBitmap, num1 + 610, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.saveId = this.AddSubPart(ref tsubpart16, num1 + 610, num4, 190, 35, 1);
      }
      else
      {
        SubPartClass tsubpart17 = (SubPartClass) new TextButtonPartClass("Save Troop Library", 190, "Nothing to save", ref this.OwnBitmap, num1 + 610, num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.saveIdb = this.AddSubPart(ref tsubpart17, num1 + 610, num4, 190, 35, 1);
      }
      SubPartClass tsubpart18 = (SubPartClass) new TextButtonPartClass("Exit", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 810), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.exitId = this.AddSubPart(ref tsubpart18, num1 + 810, num4, 190, 35, 1);
      SubPartClass tsubpart19 = (SubPartClass) new TextButtonPartClass("Load TroopType Library", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 10), bby: (num4 + 50), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadId = this.AddSubPart(ref tsubpart19, num1 + 10, num4 + 50, 190, 35, 1);
      SubPartClass tsubpart20 = (SubPartClass) new TextButtonPartClass("Export CSV", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 210), bby: (num4 + 50), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.exportCsv = this.AddSubPart(ref tsubpart20, num1 + 210, num4 + 50, 190, 35, 1);
      SubPartClass tsubpart21 = (SubPartClass) new TextButtonPartClass("Import CSV", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 410), bby: (num4 + 50), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.importCsv = this.AddSubPart(ref tsubpart21, num1 + 410, num4 + 50, 190, 35, 1);
      tsubpart21 = (SubPartClass) new TextButtonPartClass("Reload Master", 190, "For if you want to update the model units. It overwrites all but will keep your troops, reinftypes and library settings.", ref this.OwnBitmap, num1 + 610, num4 + 50, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadMasterId = this.AddSubPart(ref tsubpart21, num1 + 610, num4 + 50, 190, 35, 1);
      if (this.game.Data.LibraryCounter == -1)
      {
        this.game.Data.AddLibrary();
        this.game.Data.LibraryObj[0].name = "New TroopType Library";
        this.game.Data.LibraryObj[0].information = "no info specified";
        this.game.Data.LibraryObj[0].creator = "no creator specified";
        this.game.Data.LibraryObj[0].version = 1;
      }
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter1; ++index)
      {
        if (!this.game.Data.SFTypeObj[index].DontShowInList & this.game.Data.SFTypeObj[index].CopyDataFrom > -1)
        {
          this.game.Data.SFTypeObj[index].LibId.libSlot = 0;
          this.game.Data.SFTypeObj[index].LibId.id = -1;
        }
      }
      int reinfCounter2 = this.game.Data.ReinfCounter;
      for (int index = 0; index <= reinfCounter2; ++index)
      {
        this.game.Data.ReinfLibId[index] = new LibIdClass();
        this.game.Data.ReinfLibId[index].libSlot = 0;
        this.game.Data.ReinfLibId[index].id = -1;
      }
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Name:", this.game.MarcFont4, num1 + 10, 60, Color.White);
      DrawMod.DrawTextColouredMarc(ref objgraphics, this.game.Data.LibraryObj[0].name, this.game.MarcFont3, num1 + 10, 75, Color.White);
      tsubpart21 = (SubPartClass) new TextButtonPartClass("Change Library Name", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 10), bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.a1id = this.AddSubPart(ref tsubpart21, num1 + 10, 100, 190, 35, 1);
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Author:", this.game.MarcFont4, num1 + 310, 60, Color.White);
      DrawMod.DrawTextColouredMarc(ref objgraphics, this.game.Data.LibraryObj[0].creator, this.game.MarcFont3, num1 + 310, 75, Color.White);
      tsubpart21 = (SubPartClass) new TextButtonPartClass("Change Author", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 310), bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.a2id = this.AddSubPart(ref tsubpart21, num1 + 310, 100, 190, 35, 1);
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Information:", this.game.MarcFont4, num1 + 610, 60, Color.White);
      DrawMod.DrawTextColouredMarc(ref objgraphics, Strings.Left(this.game.Data.LibraryObj[0].information, 15) + "...", this.game.MarcFont3, num1 + 610, 75, Color.White);
      tsubpart21 = (SubPartClass) new TextButtonPartClass("Change information", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 610), bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.a3id = this.AddSubPart(ref tsubpart21, num1 + 610, 100, 190, 35, 1);
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Version:", this.game.MarcFont4, num1 + 910, 60, Color.White);
      DrawMod.DrawTextColouredMarc(ref objgraphics, this.game.Data.LibraryObj[0].version.ToString(), this.game.MarcFont3, num1 + 910, 75, Color.White);
      tsubpart21 = (SubPartClass) new TextButtonPartClass("Change version", 190, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 910), bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.versionid = this.AddSubPart(ref tsubpart21, num1 + 910, 100, 190, 35, 1);
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
            if (num1 == this.addReinf)
            {
              this.game.Data.AddReinf(Interaction.InputBox("Give name.", "Shadow Empire : Planetary Conquest"));
              this.game.Data.ReinfLibId[this.game.Data.ReinfCounter].libSlot = 0;
              this.RemoveSubPart(this.tableId);
              this.tableId = 0;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.removeReinf)
            {
              this.game.Data.RemoveReinf(this.detailnr);
              if (this.detailnr > this.game.Data.ReinfCounter)
                --this.detailnr;
              this.RemoveSubPart(this.tableId);
              this.tableId = 0;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.RenameReinf)
            {
              this.game.Data.ReinfName[this.detailnr] = Interaction.InputBox("Give name.", "Shadow Empire : Planetary Conquest");
              this.RemoveSubPart(this.tableId);
              this.tableId = 0;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.ratioid)
            {
              this.game.Data.ReinfRatio[this.detailnr] = Conversions.ToInteger(Interaction.InputBox("Give troops ratio.", "Shadow Empire : Planetary Conquest"));
              this.RemoveSubPart(this.tableId);
              this.tableId = 0;
              this.DoStuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.listId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.detailnr = num2;
                this.RemoveSubPart(this.tableId);
                this.tableId = 0;
                this.DoStuff();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
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
                this.game.EditObj.TutMode = false;
                if (this.game.Data.UseAI == 1)
                  this.game.NewAIObj.LastRegime = -1;
                this.game.SelectX = -1;
                this.game.SelectY = -1;
                DataClass dataClass = this.game.Data.Clone();
                this.game.Data = new DataClass();
                GC.Collect();
                Application.DoEvents();
                this.game.HandyFunctionsObj.Unzip(str2);
                this.game.Data = DataClass.deserialize(str2);
                this.game.HandyFunctionsObj.ZipFile(str2);
                for (int libraryCounter = this.game.Data.LibraryCounter; libraryCounter >= 0; libraryCounter += -1)
                  this.game.Data.RemoveLibrary(libraryCounter);
                this.game.Data.AddLibrary();
                this.game.Data.LibraryObj[0] = dataClass.LibraryObj[0].Clone();
                for (int sfTypeCounter = this.game.Data.SFTypeCounter; sfTypeCounter >= 0; sfTypeCounter += -1)
                {
                  if (!this.game.Data.SFTypeObj[sfTypeCounter].DontShowInList & this.game.Data.SFTypeObj[sfTypeCounter].CopyDataFrom > -1)
                    this.game.Data.RemoveSFType(sfTypeCounter);
                }
                int sfTypeCounter1 = dataClass.SFTypeCounter;
                for (int index2 = 0; index2 <= sfTypeCounter1; ++index2)
                {
                  if (!dataClass.SFTypeObj[index2].DontShowInList & dataClass.SFTypeObj[index2].CopyDataFrom > -1)
                  {
                    this.game.Data.AddSFType();
                    this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter] = dataClass.SFTypeObj[index2].Clone();
                  }
                }
                int sfTypeCounter2 = this.game.Data.SFTypeCounter;
                for (int index3 = 0; index3 <= sfTypeCounter2; ++index3)
                {
                  this.game.Data.SFTypeObj[index3].CopyDataFromBackup = -1;
                  int num3 = 0;
                  int sfTypeCounter3 = this.game.Data.SFTypeCounter;
                  for (int index4 = 0; index4 <= sfTypeCounter3; ++index4)
                  {
                    if (this.game.Data.SFTypeObj[index4].Id == this.game.Data.SFTypeObj[index3].Id & index3 != index4)
                    {
                      num3 = 1;
                      break;
                    }
                  }
                  if (num3 == 1 & this.game.Data.SFTypeObj[index3].LibId.libSlot == -1)
                  {
                    int id = this.game.Data.SFTypeObj[index3].Id;
                    bool flag1 = false;
                    while (!flag1)
                    {
                      bool flag2 = false;
                      int sfTypeCounter4 = this.game.Data.SFTypeCounter;
                      for (int index5 = 0; index5 <= sfTypeCounter4; ++index5)
                      {
                        if (this.game.Data.SFTypeObj[index5].Id == id)
                          flag2 = true;
                      }
                      if (!flag2)
                      {
                        this.game.Data.SFTypeObj[index3].Id = id;
                        if (id > this.game.Data.SFTypeIdCounter)
                        {
                          this.game.Data.SFTypeIdCounter = id;
                          break;
                        }
                        break;
                      }
                      ++id;
                    }
                    num3 = 0;
                  }
                  if (num3 == 1)
                  {
                    int sfTypeCounter5 = this.game.Data.SFTypeCounter;
                    for (int index6 = 0; index6 <= sfTypeCounter5; ++index6)
                    {
                      if (this.game.Data.SFTypeObj[index6].Id > this.game.Data.SFTypeIdCounter)
                        this.game.Data.SFTypeIdCounter = this.game.Data.SFTypeObj[index6].Id;
                    }
                    ++this.game.Data.SFTypeIdCounter;
                    this.game.Data.SFTypeObj[index3].Id = this.game.Data.SFTypeIdCounter;
                  }
                }
                while (this.game.Data.ReinfCounter > -1)
                  this.game.Data.RemoveReinf(0);
                int reinfCounter = dataClass.ReinfCounter;
                for (int index7 = 0; index7 <= reinfCounter; ++index7)
                {
                  this.game.Data.AddReinf(dataClass.ReinfName[index7]);
                  this.game.Data.ReinfId[this.game.Data.ReinfCounter] = dataClass.ReinfId[index7];
                  this.game.Data.ReinfLibId[this.game.Data.ReinfCounter] = dataClass.ReinfLibId[index7].Clone();
                  this.game.Data.ReinfRatio[this.game.Data.ReinfCounter] = dataClass.ReinfRatio[index7];
                }
                this.game.Data.reinfIdCounter = dataClass.reinfIdCounter;
                this.game.Data.Round = 0;
                this.game.Data.Turn = 0;
                if ((double) this.game.Data.RuleVar[344] == 1.0 & this.game.EditObj.HideUnit == 0)
                  this.game.EditObj.HideUnit = 2;
                this.game.EditObj.TempValue = new MapMatrix2[this.game.Data.MapCounter + 1];
                this.game.EditObj.TempValue2 = new MapMatrix2[this.game.Data.MapCounter + 1];
                int mapCounter = this.game.Data.MapCounter;
                for (int index8 = 0; index8 <= mapCounter; ++index8)
                {
                  this.game.EditObj.TempValue[index8] = new MapMatrix2(this.game.Data.MapObj[index8].MapWidth, this.game.Data.MapObj[index8].MapHeight);
                  this.game.EditObj.TempValue2[index8] = new MapMatrix2(this.game.Data.MapObj[index8].MapWidth, this.game.Data.MapObj[index8].MapHeight);
                }
                if (Strings.Len(this.game.Data.LoadPass) > 0)
                {
                  this.game.FormRef.Cursor = Cursors.Default;
                  if (Operators.CompareString(Strings.LCase(Interaction.InputBox("This File is protected by a load password. Please give it in order to load it.", "Shadow Empire : Planetary Conquest")), Strings.LCase(this.game.Data.LoadPass), false) == 0)
                  {
                    int num4 = (int) Interaction.MsgBox((object) "You are cleared.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    int num5 = (int) Interaction.MsgBox((object) "Wrong Password. You cannot Load this file. Exiting whole app.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
                int num6 = (int) Interaction.MsgBox((object) "Loaded Masterfile", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
              string str = this.game.HandyFunctionsObj.LoadSomething("SE1 Troops&Equipment library(*.se1troops)|*.se1troops", "Pick a trooptype library...", tinitdir, false);
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
                for (int index9 = 0; index9 <= mapCounter; ++index9)
                {
                  this.game.EditObj.TempValue[index9] = new MapMatrix2(this.game.Data.MapObj[index9].MapWidth, this.game.Data.MapObj[index9].MapHeight);
                  this.game.EditObj.TempValue2[index9] = new MapMatrix2(this.game.Data.MapObj[index9].MapWidth, this.game.Data.MapObj[index9].MapHeight);
                }
                if (Strings.Len(this.game.Data.LoadPass) > 0)
                {
                  this.game.FormRef.Cursor = Cursors.Default;
                  if (Operators.CompareString(Strings.LCase(Interaction.InputBox("This File is protected by a load password. Please give it in order to load it.", "Shadow Empire : Planetary Conquest")), Strings.LCase(this.game.Data.LoadPass), false) == 0)
                  {
                    int num7 = (int) Interaction.MsgBox((object) "You are cleared.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    int num8 = (int) Interaction.MsgBox((object) "Wrong Password. You cannot Load this file. Exiting whole app.", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
                int sfTypeCounter6 = this.game.Data.SFTypeCounter;
                for (int index10 = 0; index10 <= sfTypeCounter6; ++index10)
                {
                  this.game.Data.SFTypeObj[index10].CopyDataFromBackup = -1;
                  int num9 = 0;
                  int sfTypeCounter7 = this.game.Data.SFTypeCounter;
                  for (int index11 = 0; index11 <= sfTypeCounter7; ++index11)
                  {
                    if (this.game.Data.SFTypeObj[index11].Id == this.game.Data.SFTypeObj[index10].Id & index10 != index11)
                    {
                      num9 = 1;
                      break;
                    }
                  }
                  if (num9 == 1 & this.game.Data.SFTypeObj[index10].LibId.libSlot == -1)
                  {
                    int id = this.game.Data.SFTypeObj[index10].Id;
                    bool flag3 = false;
                    while (!flag3)
                    {
                      bool flag4 = false;
                      int sfTypeCounter8 = this.game.Data.SFTypeCounter;
                      for (int index12 = 0; index12 <= sfTypeCounter8; ++index12)
                      {
                        if (this.game.Data.SFTypeObj[index12].Id == id)
                          flag4 = true;
                      }
                      if (!flag4)
                      {
                        this.game.Data.SFTypeObj[index10].Id = id;
                        if (id > this.game.Data.SFTypeIdCounter)
                        {
                          this.game.Data.SFTypeIdCounter = id;
                          break;
                        }
                        break;
                      }
                      ++id;
                    }
                    num9 = 0;
                  }
                  if (num9 == 1)
                  {
                    int sfTypeCounter9 = this.game.Data.SFTypeCounter;
                    for (int index13 = 0; index13 <= sfTypeCounter9; ++index13)
                    {
                      if (this.game.Data.SFTypeObj[index13].Id > this.game.Data.SFTypeIdCounter)
                        this.game.Data.SFTypeIdCounter = this.game.Data.SFTypeObj[index13].Id;
                    }
                    ++this.game.Data.SFTypeIdCounter;
                    this.game.Data.SFTypeObj[index10].Id = this.game.Data.SFTypeIdCounter;
                  }
                }
                int num10 = 0;
                int sfTypeCounter10 = this.game.Data.SFTypeCounter;
                for (int index14 = 0; index14 <= sfTypeCounter10; ++index14)
                {
                  if (this.game.Data.SFTypeObj[index14].Id >= num10)
                    num10 = this.game.Data.SFTypeObj[index14].Id;
                }
                if (num10 + 100 < this.game.Data.SFTypeIdCounter)
                  this.game.Data.SFTypeIdCounter = num10 + 100;
                int num11 = (int) Interaction.MsgBox((object) "Loaded TroopType Library", Title: ((object) "Shadow Empire : Planetary Conquest"));
                this.RemoveSubPart(this.tableId);
                this.tableId = 0;
                this.DoStuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
            else if (num1 == this.importCsv)
            {
              string str3 = this.game.HandyFunctionsObj.LoadSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Select file to import...", this.game.AppPath + "csv/", false);
              if (Strings.Len(str3) < 2)
              {
                int num12 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                StreamReader streamReader;
                WindowReturnClass windowReturnClass2;
                try
                {
                  streamReader = File.OpenText(str3);
                  int num13 = 0;
                  string str4 = ",";
                  try
                  {
                    while (!streamReader.EndOfStream)
                    {
                      string str5 = streamReader.ReadLine();
                      if ((uint) Strings.InStr(str5, "sep=") > 0U)
                      {
                        str4 = Strings.Mid(str5, 5, 1);
                        num13 = 1;
                      }
                      else
                      {
                        switch (num13)
                        {
                          case 0:
                            if (Strings.InStr(str5, "\t") > 0)
                              str4 = "\t";
                            else if (Strings.InStr(str5, ",") > 0)
                              str4 = ",";
                            else if (Strings.InStr(str5, ";") > 0)
                              str4 = ";";
                            num13 = 2;
                            continue;
                          case 1:
                            num13 = 2;
                            continue;
                          case 2:
                            string[] strArray = str5.Split(Conversions.ToChar(str4));
                            int num14 = 0;
                            int num15;
                            ++num15;
                            int sfTypeCounter = this.game.Data.SFTypeCounter;
                            int index15;
                            for (index15 = 0; index15 <= sfTypeCounter; ++index15)
                            {
                              if (!this.game.Data.SFTypeObj[index15].DontShowInList & this.game.Data.SFTypeObj[index15].CopyDataFrom > -1)
                              {
                                ++num14;
                                if (num14 == num15)
                                  break;
                              }
                            }
                            if (num14 != num15)
                            {
                              this.game.Data.AddSFType();
                              index15 = this.game.Data.SFTypeCounter;
                              num14 = num15;
                            }
                            if (num14 == num15)
                            {
                              int index16 = index15;
                              this.game.Data.SFTypeObj[index16].CopyDataFrom = Conversions.ToInteger(strArray[0]);
                              this.game.Data.SFTypeObj[index16].Name = strArray[1];
                              this.game.Data.SFTypeObj[index16].ReinforcementType = Conversions.ToInteger(strArray[2]);
                              this.game.Data.SFTypeObj[index16].ReinforcementType2 = Conversions.ToInteger(strArray[3]);
                              while (this.game.Data.SFTypeObj[index16].ReinforcementType > this.game.Data.ReinfCounter)
                              {
                                this.game.Data.AddReinf("Unknown ReinfType");
                                this.game.Data.ReinfLibId[this.game.Data.ReinfCounter].libSlot = 0;
                              }
                              while (this.game.Data.SFTypeObj[index16].ReinforcementType2 > this.game.Data.ReinfCounter)
                              {
                                this.game.Data.AddReinf("Unknown ReinfType");
                                this.game.Data.ReinfLibId[this.game.Data.ReinfCounter].libSlot = 0;
                              }
                              this.game.Data.SFTypeObj[index16].SymbolFileName = strArray[4];
                              this.game.Data.SFTypeObj[index16].SidewaysFileName = strArray[5];
                              this.game.Data.SFTypeObj[index16].MoveWAV = strArray[6];
                              this.game.Data.SFTypeObj[index16].BattleWAV = strArray[7];
                              this.game.Data.SFTypeObj[index16].Ratio = Conversions.ToInteger(strArray[8]);
                              this.game.Data.SFTypeObj[index16].Weight = Conversions.ToInteger(strArray[9]);
                              this.game.Data.SFTypeObj[index16].CarryCap = Conversions.ToInteger(strArray[10]);
                              this.game.Data.SFTypeObj[index16].manpower = Conversions.ToInteger(strArray[11]);
                              this.game.Data.SFTypeObj[index16].manpowerCarry = Conversions.ToInteger(strArray[12]);
                              int num16 = 0;
                              int index17 = 0;
                              do
                              {
                                if (this.game.Data.TempString[index17 + 600].Length > 0)
                                {
                                  ++num16;
                                  this.game.Data.SFTypeObj[index16].SFTypeVar[index17] = Conversions.ToInteger(strArray[12 + num16]);
                                }
                                ++index17;
                              }
                              while (index17 <= 99);
                              continue;
                            }
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
                    int num17 = (int) Interaction.MsgBox((object) ("Import problem encountered: '" + exception.Message + "'. Your current data might be corrupted. "), Title: ((object) "Shadow Empire : Planetary Conquest"));
                    this.RemoveSubPart(this.tableId);
                    this.tableId = 0;
                    this.DoStuff();
                    windowReturnClass1.SetFlag(true);
                    windowReturnClass2 = windowReturnClass1;
                    ProjectData.ClearProjectError();
                    goto label_298;
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  int num18 = (int) Interaction.MsgBox((object) "Error opening file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  windowReturnClass2 = windowReturnClass1;
                  ProjectData.ClearProjectError();
                  goto label_298;
                }
                streamReader.Close();
                this.game.Data.LoadGraphics(this.formref);
                int num19 = (int) Interaction.MsgBox((object) "Import finished", Title: ((object) "Shadow Empire : Planetary Conquest"));
                this.RemoveSubPart(this.tableId);
                this.tableId = 0;
                this.DoStuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
label_298:
                return windowReturnClass2;
              }
            }
            else if (num1 == this.exportCsv)
            {
              string str6 = this.game.HandyFunctionsObj.SaveSomething("CSV (*.csv)|*.csv|TXT (*.txt)|*.txt|All (*.*)|*.*", "Give save name...", this.game.AppPath + "csv/", false);
              if (Strings.Len(str6) < 2)
              {
                int num20 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                try
                {
                  StreamWriter text = File.CreateText(str6);
                  try
                  {
                    text.WriteLine("sep=\t");
                    string str7 = "" + "BasedOn" + "\t" + "Name" + "\t" + "ReinfType1" + "\t" + "ReinfType2" + "\t" + "Symbol Gfx" + "\t" + "Sideways Gfx" + "\t" + "Move Sound" + "\t" + "Attack Sound" + "\t" + "Ratio" + "\t" + "Weight" + "\t" + "Carry" + "\t" + "Manpower" + "\t" + "ManpCarry";
                    int num21 = 0;
                    do
                    {
                      if (this.game.Data.TempString[num21 + 600].Length > 0)
                        str7 = str7 + "\t" + this.game.Data.TempString[num21 + 600];
                      ++num21;
                    }
                    while (num21 <= 99);
                    text.WriteLine(str7);
                    int sfTypeCounter = this.game.Data.SFTypeCounter;
                    for (int index18 = 0; index18 <= sfTypeCounter; ++index18)
                    {
                      if (!this.game.Data.SFTypeObj[index18].DontShowInList & this.game.Data.SFTypeObj[index18].CopyDataFrom > -1)
                      {
                        string str8 = "" + this.game.Data.SFTypeObj[index18].CopyDataFrom.ToString() + "\t" + this.game.Data.SFTypeObj[index18].Name + "\t";
                        string str9 = (this.game.Data.SFTypeObj[index18].ReinforcementType <= -1 ? str8 + "-1" : str8 + this.game.Data.SFTypeObj[index18].ReinforcementType.ToString()) + "\t";
                        string str10 = (this.game.Data.SFTypeObj[index18].ReinforcementType2 <= -1 ? str9 + "-1" : str9 + this.game.Data.SFTypeObj[index18].ReinforcementType2.ToString()) + "\t" + this.game.Data.SFTypeObj[index18].SymbolFileName + "\t" + this.game.Data.SFTypeObj[index18].SidewaysFileName + "\t" + this.game.Data.SFTypeObj[index18].MoveWAV + "\t" + this.game.Data.SFTypeObj[index18].BattleWAV + "\t" + this.game.Data.SFTypeObj[index18].Ratio.ToString() + "\t" + this.game.Data.SFTypeObj[index18].Weight.ToString() + "\t" + this.game.Data.SFTypeObj[index18].CarryCap.ToString() + "\t" + this.game.Data.SFTypeObj[index18].manpower.ToString() + "\t" + this.game.Data.SFTypeObj[index18].manpowerCarry.ToString();
                        int index19 = 0;
                        do
                        {
                          if (this.game.Data.TempString[index19 + 600].Length > 0)
                            str10 = str10 + "\t" + this.game.Data.SFTypeObj[index18].SFTypeVar[index19].ToString();
                          ++index19;
                        }
                        while (index19 <= 99);
                        text.WriteLine(str10);
                      }
                    }
                    text.Close();
                    int num22 = (int) Interaction.MsgBox((object) "Export has been written to the csv/ directory", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    text.Close();
                    int num23 = (int) Interaction.MsgBox((object) ("Problem writing: " + exception.Message), Title: ((object) "Shadow Empire : Planetary Conquest"));
                    ProjectData.ClearProjectError();
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  int num24 = (int) Interaction.MsgBox((object) "Problem writing. Check if the file is not opened in other application please.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  ProjectData.ClearProjectError();
                }
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
              string str = this.game.HandyFunctionsObj.SaveSomething("SE1 Troops&Equipment library(*.se1troops)|*.se1troops", "Give save name...", tinitdir, false);
              if (Strings.Len(str) < 2)
              {
                int num25 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
                int num26 = (int) Interaction.MsgBox((object) "Completed & Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
              if (num1 == this.versionid)
              {
                string InputStr = Interaction.InputBox("Give version.", "Shadow Empire : Planetary Conquest", Conversions.ToString(this.game.Data.LibraryObj[0].version));
                if (InputStr.Length > 0)
                  this.game.Data.LibraryObj[0].version = (int) Math.Round(Conversion.Val(InputStr));
                this.RemoveSubPart(this.tableId);
                this.tableId = 0;
                this.DoStuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
              if (num1 == this.a3id)
              {
                this.Change = true;
                new Form2((Form) this.formref).Initialize(this.game.Data, 13, 0);
                return windowReturnClass1;
              }
              if (num1 == this.exitId)
              {
                this.game.EditObj.InEditor = false;
                this.game.FormRef.Cursor = Cursors.WaitCursor;
                this.Interpret();
                this.game.Data.LoadGraphics(this.formref);
                this.game.FormRef.Cursor = Cursors.Default;
                if (this.game.EditorBlock)
                  this.game.EditObj.ShowInitialMenu = true;
                if (this.game.ModIntroType == 0)
                  windowReturnClass1.AddCommand(3, 1);
                else
                  windowReturnClass1.AddCommand(3, 12);
              }
              else
              {
                if (num1 == this.editId)
                {
                  if (this.detaily == 0)
                  {
                    int num27 = (int) Interaction.MsgBox((object) "Cannot change", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    if (this.detaily == 1)
                    {
                      this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      this.Change = true;
                      new Form3((Form) this.formref).Initialize(this.game.Data, 130, this.currentSfTypeNr, tGame: this.game);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 2)
                    {
                      this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      string str = Interaction.InputBox("Give name.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                      this.stringy.Data[this.detailx, this.detaily] = str;
                      this.game.Data.SFTypeObj[this.currentSfTypeNr].Name = str;
                      this.SubPartList[this.SubpartNr(this.tableId)].Refresh(this.stringy, this.detailx, 0);
                      this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 5)
                    {
                      this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      new Form2((Form) this.formref).Initialize(this.game.Data, 1, this.currentSfTypeNr);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 3)
                    {
                      this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      this.Change = true;
                      new Form3((Form) this.formref).Initialize(this.game.Data, 51, this.currentSfTypeNr, tGame: this.game);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 4)
                    {
                      this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      this.Change = true;
                      new Form3((Form) this.formref).Initialize(this.game.Data, 89, this.currentSfTypeNr, tGame: this.game);
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                    if (this.detaily == 6)
                    {
                      string str = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of symbol Sprite:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + str))
                      {
                        if (Strings.InStr(str, "BIG") > 0 | Strings.InStr(str, "SMALL") > 0)
                        {
                          int num28 = (int) Interaction.MsgBox((object) "You cannot load a file that in the path include 'BIG' or 'SMALL'.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                        }
                        else
                        {
                          this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                          this.stringy.Data[this.detailx, this.detaily] = str;
                          this.game.Data.SFTypeObj[this.currentSfTypeNr].SymbolFileName = str;
                          this.game.Data.SFTypeObj[this.currentSfTypeNr].ReplaceSymbolSprite(str);
                          this.RemoveSubPart(this.tableId);
                          this.tableId = 0;
                          this.DoStuff();
                          windowReturnClass1.SetFlag(true);
                          return windowReturnClass1;
                        }
                      }
                      else
                      {
                        int num29 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      }
                    }
                    else if (this.detaily == 7)
                    {
                      string s = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps (*.bmp)|*.bmp", "Give File Name For Replacement of sideways Sprite:", this.game.AppPath + "graphics\\", true);
                      if (File.Exists(this.game.AppPath + "graphics/" + s))
                      {
                        this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        this.stringy.Data[this.detailx, this.detaily] = s;
                        this.game.Data.SFTypeObj[this.currentSfTypeNr].SidewaysFileName = s;
                        this.game.Data.SFTypeObj[this.currentSfTypeNr].ReplaceSidewaysSprite(s);
                        this.RemoveSubPart(this.tableId);
                        this.tableId = 0;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      int num30 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      if (this.detaily == 8)
                      {
                        string Left = this.game.Data.SoundDir;
                        if (Operators.CompareString(Left, "", false) == 0)
                          Left = this.game.ModSoundDir;
                        if (Operators.CompareString(Left, "", false) == 0)
                          Left = "sound";
                        string str11 = Left + "/";
                        string str12 = this.game.HandyFunctionsObj.LoadSomething("WAVs (*.wav)|*.wav", "Select File For Move Sound", this.game.AppPath + str11, true);
                        if (!File.Exists(this.game.AppPath + str11 + str12))
                        {
                          int num31 = (int) Interaction.MsgBox((object) "File does not exist. wav set to no sound.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          str12 = "";
                        }
                        this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        this.stringy.Data[this.detailx, this.detaily] = str12;
                        this.game.Data.SFTypeObj[this.currentSfTypeNr].MoveWAV = str12;
                        this.SubPartList[this.SubpartNr(this.tableId)].Refresh(this.stringy, this.detailx, this.detaily);
                        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 9)
                      {
                        string Left = this.game.Data.SoundDir;
                        if (Operators.CompareString(Left, "", false) == 0)
                          Left = this.game.ModSoundDir;
                        if (Operators.CompareString(Left, "", false) == 0)
                          Left = "sound";
                        string str13 = Left + "/";
                        string str14 = this.game.HandyFunctionsObj.LoadSomething("WAVs (*.wav)|*.wav", "Select File For Battle Sound", this.game.AppPath + str13, true);
                        if (!File.Exists(this.game.AppPath + str13 + str14))
                        {
                          int num32 = (int) Interaction.MsgBox((object) "File does not exist. wav set to no sound.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                          str14 = "";
                        }
                        this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        this.stringy.Data[this.detailx, this.detaily] = str14;
                        this.game.Data.SFTypeObj[this.currentSfTypeNr].BattleWAV = str14;
                        this.SubPartList[this.SubpartNr(this.tableId)].Refresh(this.stringy, this.detailx, this.detaily);
                        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 10)
                      {
                        this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string InputStr = Interaction.InputBox("Give ratio.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = InputStr;
                        this.game.Data.SFTypeObj[this.currentSfTypeNr].Ratio = (int) Math.Round(Conversion.Val(InputStr));
                        this.SubPartList[this.SubpartNr(this.tableId)].Refresh(this.stringy, this.detailx, this.detaily);
                        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 11)
                      {
                        this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string InputStr = Interaction.InputBox("Give weight points.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = InputStr;
                        this.game.Data.SFTypeObj[this.currentSfTypeNr].Weight = (int) Math.Round(Conversion.Val(InputStr));
                        this.SubPartList[this.SubpartNr(this.tableId)].Refresh(this.stringy, this.detailx, this.detaily);
                        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 12)
                      {
                        this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string InputStr = Interaction.InputBox("Give carry points.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = InputStr;
                        this.game.Data.SFTypeObj[this.currentSfTypeNr].CarryCap = (int) Math.Round(Conversion.Val(InputStr));
                        this.SubPartList[this.SubpartNr(this.tableId)].Refresh(this.stringy, this.detailx, this.detaily);
                        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 13)
                      {
                        this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string InputStr = Interaction.InputBox("Give manpower points.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = InputStr;
                        this.game.Data.SFTypeObj[this.currentSfTypeNr].manpower = (int) Math.Round(Conversion.Val(InputStr));
                        this.SubPartList[this.SubpartNr(this.tableId)].Refresh(this.stringy, this.detailx, this.detaily);
                        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      if (this.detaily == 14)
                      {
                        this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                        string InputStr = Interaction.InputBox("Give manpower carry points.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily]);
                        this.stringy.Data[this.detailx, this.detaily] = InputStr;
                        this.game.Data.SFTypeObj[this.currentSfTypeNr].manpowerCarry = (int) Math.Round(Conversion.Val(InputStr));
                        this.SubPartList[this.SubpartNr(this.tableId)].Refresh(this.stringy, this.detailx, this.detaily);
                        this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
                        this.DoStuff();
                        windowReturnClass1.SetFlag(true);
                        return windowReturnClass1;
                      }
                      this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                      string str = Conversion.Str((object) Conversion.Val(Interaction.InputBox("Give new value of cell, please.", "Shadow Empire : Planetary Conquest", this.stringy.Data[this.detailx, this.detaily])));
                      this.stringy.Data[this.detailx, this.detaily] = str;
                      this.game.Data.SFTypeObj[this.currentSfTypeNr].SFTypeVar[this.ColIsSFTypeVar[this.detaily]] = Conversions.ToInteger(str);
                      this.SubPartList[this.SubpartNr(this.tableId)].Refresh(this.stringy, this.detailx, this.detaily);
                      this.SubPartFlag[this.SubpartNr(this.tableId)] = true;
                      this.DoStuff();
                      windowReturnClass1.SetFlag(true);
                      return windowReturnClass1;
                    }
                  }
                  return windowReturnClass1;
                }
                if (num1 == this.removeId)
                {
                  this.currentSfTypeNr = (int) Math.Round(Conversion.Val(this.stringy.Data[this.detailx, 0]));
                  --this.detailx;
                  this.game.Data.RemoveSFType(this.currentSfTypeNr);
                  this.RemoveSubPart(this.tableId);
                  this.tableId = 0;
                  this.DoStuff();
                  windowReturnClass1.SetFlag(true);
                  return windowReturnClass1;
                }
                if (num1 == this.addId)
                {
                  this.game.Data.AddSFType();
                  this.currentSfTypeNr = this.game.Data.SFTypeCounter;
                  this.game.Data.SFTypeObj[this.game.Data.SFTypeCounter].LibId.libSlot = 0;
                  this.AddNew = true;
                  new Form3((Form) this.formref).Initialize(this.game.Data, 130, this.currentSfTypeNr, 1, this.game);
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
      int sfTypeCounter1 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter1; ++index)
      {
        if (!this.game.Data.SFTypeObj[index].DontShowInList & this.game.Data.SFTypeObj[index].CopyDataFrom > -1)
        {
          string name = this.game.Data.SFTypeObj[index].Name;
          string description = this.game.Data.SFTypeObj[index].Description;
          int reinforcementType = this.game.Data.SFTypeObj[index].ReinforcementType;
          int reinforcementType2 = this.game.Data.SFTypeObj[index].ReinforcementType2;
          string symbolFileName = this.game.Data.SFTypeObj[index].SymbolFileName;
          string sidewaysFileName = this.game.Data.SFTypeObj[index].SidewaysFileName;
          string moveWav = this.game.Data.SFTypeObj[index].MoveWAV;
          string battleWav = this.game.Data.SFTypeObj[index].BattleWAV;
          int copyDataFrom = this.game.Data.SFTypeObj[index].CopyDataFrom;
          int id = this.game.Data.SFTypeObj[index].Id;
          int weight = this.game.Data.SFTypeObj[index].Weight;
          int carryCap = this.game.Data.SFTypeObj[index].CarryCap;
          int manpower = this.game.Data.SFTypeObj[index].manpower;
          int manpowerCarry = this.game.Data.SFTypeObj[index].manpowerCarry;
          int[] numArray1 = new int[100];
          int[] numArray2 = (int[]) this.game.Data.SFTypeObj[index].SFTypeVar.Clone();
          this.game.Data.SFTypeObj[index] = this.game.Data.SFTypeObj[copyDataFrom].Clone();
          this.game.Data.SFTypeObj[index].Name = name;
          this.game.Data.SFTypeObj[index].Description = description;
          this.game.Data.SFTypeObj[index].SFTypeVar = (int[]) numArray2.Clone();
          this.game.Data.SFTypeObj[index].DontShowInList = false;
          this.game.Data.SFTypeObj[index].ReinforcementType = reinforcementType;
          this.game.Data.SFTypeObj[index].ReinforcementType2 = reinforcementType2;
          this.game.Data.SFTypeObj[index].PicFileName = "systemgraphics/trans.bmp";
          this.game.Data.SFTypeObj[index].SymbolFileName = symbolFileName;
          this.game.Data.SFTypeObj[index].SymbolFileName2 = symbolFileName;
          this.game.Data.SFTypeObj[index].SidewaysFileName = sidewaysFileName;
          this.game.Data.SFTypeObj[index].MoveWAV = moveWav;
          this.game.Data.SFTypeObj[index].BattleWAV = battleWav;
          this.game.Data.SFTypeObj[index].CopyDataFrom = copyDataFrom;
          this.game.Data.SFTypeObj[index].Id = id;
          this.game.Data.SFTypeObj[index].Weight = weight;
          this.game.Data.SFTypeObj[index].CarryCap = carryCap;
          this.game.Data.SFTypeObj[index].manpower = manpower;
          this.game.Data.SFTypeObj[index].manpowerCarry = manpowerCarry;
        }
      }
      int sfTypeCounter2 = this.game.Data.SFTypeCounter;
      for (int index = 0; index <= sfTypeCounter2; ++index)
      {
        if (!this.game.Data.SFTypeObj[index].DontShowInList & this.game.Data.SFTypeObj[index].CopyDataFrom > -1)
        {
          this.game.Data.SFTypeObj[index].LibId.libSlot = 0;
          this.game.Data.SFTypeObj[index].LibId.id = -1;
        }
      }
      int reinfCounter = this.game.Data.ReinfCounter;
      for (int index = 0; index <= reinfCounter; ++index)
      {
        this.game.Data.ReinfLibId[index].libSlot = 0;
        this.game.Data.ReinfLibId[index].id = -1;
      }
      this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.HandyFunctionsObj.GetEventByID((int) Math.Round((double) this.game.Data.RuleVar[946])));
    }
  }
}
