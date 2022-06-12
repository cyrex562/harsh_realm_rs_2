// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.EditorPaintWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace WindowsApplication1
{
  public class EditorPaintWindowClass : WindowClass
  {
    private int TempText1;
    private int temptext2;
    private int temptext3;
    private int temptext4;
    private int temptext5;
    private int temptext6;
    private int temptext7;
    private int temptext8;
    private int temptext9;
    private int temptext10;
    private int TempText11;
    private int temptext12;
    private int temptext13;
    private int temptext14;
    private int temptext15;
    private int temptext16;
    private int temptext17;
    private int temptext18;
    private int temptext19;
    private int temptext20;
    private int TempText21;
    private int temptext22;
    private int temptext23;
    private int temptext24;
    private int temptext25;
    private int temptext26;
    private int temptext27;
    private int temptext28;
    private int temptext29;
    private int temptext30;
    private int TempText31;
    private int temptext32;
    private int temptext33;
    private int temptext34;
    private int temptext35;
    private int temptext36;
    private int temptext37;
    private int temptext38;
    private int temptext39;
    private int temptext40;
    private int temptext41;
    private int temptext42;
    private int temptext43;
    private int temptext44;
    private int temptext45;
    private int temptext46;
    private int LogoListId;
    private int but1id;
    private int tab1id;
    private int tab2id;
    private int tab3id;
    private int tab4id;
    private int tab5id;
    private int but1textid;
    private int but1bid;
    private int hqbut0;
    private int hqbut1;
    private int hqbut2;
    private int but2id;
    private int but2textid;
    private int but3id;
    private int but3textid;
    private int but4id;
    private int but4textid;
    private int but5id;
    private int but5textid;
    private int but6id;
    private int but6textid;
    private int but7id;
    private int quitid;
    private int but7textid;
    private int descid;
    private int comparenr;
    private int sliderid;
    private int logolist2id;
    private int logolist3id;
    private float tempBlink;
    private int unr;
    private int sfnr;
    private int sftyp;
    private int detailnr;
    private int detailnr2;
    private int detailtype;
    private int ammount;
    private bool hqreach;
    private int passenger;
    private int firstlistId;
    private ATListClass firstlistObj;
    private int medlistId;
    private ATListClass medListObj;
    private int lastListId;
    private ATListClass lastListObj;
    private int OptionsList4Id;
    private ATListClass OptionsList4Obj;
    private int OptionsList5Id;
    private ATListClass OptionsList5Obj;
    private int OptionsList6Id;
    private ATListClass OptionsList6Obj;
    private int combatListId;
    private ATListClass combatListObj;
    private int combatList2Id;
    private ATListClass combatList2Obj;
    private int StatTyp;
    private int StatMode;
    private int[] ChainHq;
    private int HQselect;
    private int infoid;
    private int ltnr;
    private int locnr;
    private int ppl;
    private int spnr;

    public override WindowReturnClass handleTimer() => new WindowReturnClass();

    public EditorPaintWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, 9, tDoBorders: 1, tHeaderString: "Select paint type")
    {
      this.ChainHq = new int[3];
      this.tempBlink = 0.0f;
      this.game.EditObj.CurrentDescript = "";
      this.unr = -1;
      this.ppl = this.game.EditObj.PeopleSelected;
      this.StatMode = 0;
      this.detailnr = -1;
      this.detailnr2 = 0;
      this.DoStuff();
    }

    public void DoStuff()
    {
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(1024, 768, -1);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      if (this.but1id > 0)
        this.RemoveSubPart(this.but1id);
      if (this.firstlistId > 0)
        this.RemoveSubPart(this.firstlistId);
      if (this.medlistId > 0)
        this.RemoveSubPart(this.medlistId);
      if (this.lastListId > 0)
        this.RemoveSubPart(this.lastListId);
      if (this.TempText1 > 0)
        this.RemoveSubPart(this.TempText1);
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("OK", 320, tBackbitmap: (ref this.OwnBitmap), bbx: 312, bby: 680, theight: 45);
      this.but1id = this.AddSubPart(ref tsubpart1, 312, 680, 320, 45, 1);
      this.firstlistObj = new ATListClass();
      int tlistselect1 = -1;
      if (this.game.EditObj.inSimpleEditor & !this.game.EditObj.inSimpleMapEditor)
      {
        this.firstlistObj.add("Regimes", 3);
        if (this.game.EditObj.PaintShortcut1 == 3)
          tlistselect1 = 0;
        this.firstlistObj.add("Libvar Slots", 11);
        if (this.game.EditObj.PaintShortcut1 == 11)
          tlistselect1 = 1;
      }
      else if (this.game.EditObj.inSimpleMapEditor)
      {
        this.firstlistObj.add("Landscapes", 1);
        if (this.game.EditObj.PaintShortcut1 == 1)
          tlistselect1 = 0;
        this.firstlistObj.add("Roads", 2);
        if (this.game.EditObj.PaintShortcut1 == 2)
          tlistselect1 = 1;
        this.firstlistObj.add("Location Types", 4);
        if (this.game.EditObj.PaintShortcut1 == 4)
          tlistselect1 = 2;
        this.firstlistObj.add("Rivers", 5);
        if (this.game.EditObj.PaintShortcut1 == 5)
          tlistselect1 = 3;
        this.firstlistObj.add("Bridge", 6);
        if (this.game.EditObj.PaintShortcut1 == 6)
          tlistselect1 = 4;
        this.firstlistObj.add("Areaslots", 9);
        if (this.game.EditObj.PaintShortcut1 == 9)
          tlistselect1 = 5;
        if (this.game.AllowHeightMap)
        {
          this.firstlistObj.add("Height Map", 12);
          if (this.game.EditObj.PaintShortcut1 == 12)
            tlistselect1 = 6;
        }
      }
      else
      {
        this.firstlistObj.add("Landscapes", 1);
        if (this.game.EditObj.PaintShortcut1 == 1)
          tlistselect1 = 0;
        this.firstlistObj.add("Roads", 2);
        if (this.game.EditObj.PaintShortcut1 == 2)
          tlistselect1 = 1;
        this.firstlistObj.add("Regimes", 3);
        if (this.game.EditObj.PaintShortcut1 == 3)
          tlistselect1 = 2;
        this.firstlistObj.add("LocType", 4);
        if (this.game.EditObj.PaintShortcut1 == 4)
          tlistselect1 = 3;
        this.firstlistObj.add("Rivers", 5);
        if (this.game.EditObj.PaintShortcut1 == 5)
          tlistselect1 = 4;
        this.firstlistObj.add("Bridge", 6);
        if (this.game.EditObj.PaintShortcut1 == 6)
          tlistselect1 = 5;
        this.firstlistObj.add("Slots", 9);
        if (this.game.EditObj.PaintShortcut1 == 9)
          tlistselect1 = 6;
        this.firstlistObj.add("Specials", 10);
        if (this.game.EditObj.PaintShortcut1 == 10)
          tlistselect1 = 7;
        this.firstlistObj.add("Libvar Slots", 11);
        if (this.game.EditObj.PaintShortcut1 == 11)
          tlistselect1 = 8;
        if (this.game.AllowHeightMap)
        {
          this.firstlistObj.add("Height Map", 12);
          if (this.game.EditObj.PaintShortcut1 == 12)
            tlistselect1 = 9;
        }
      }
      SubPartClass tsubpart2 = (SubPartClass) new ATListSubPartClass(this.firstlistObj, 18, 250, tlistselect1, this.game, tHeader: "What?", tbackbitmap: (ref this.OwnBitmap), bbx: 50, bby: 50);
      this.firstlistId = this.AddSubPart(ref tsubpart2, 50, 50, 250, 336, 0);
      string str1 = "";
      if (this.game.EditObj.PaintShortcut1 == 1)
      {
        this.medListObj = new ATListClass();
        str1 = "Landscapes";
        int num = -1;
        int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
        for (int tdata = 0; tdata <= landscapeTypeCounter; ++tdata)
        {
          if (!this.game.Data.LandscapeTypeObj[tdata].DontShowInList)
          {
            this.medListObj.add(this.game.Data.LandscapeTypeObj[tdata].Name, tdata);
            ++num;
            if (tdata == this.game.EditObj.PaintShortcut2)
              tlistselect1 = num;
          }
        }
      }
      else if (this.game.EditObj.PaintShortcut1 == 2)
      {
        this.medListObj = new ATListClass();
        str1 = "Roads";
        int roadTypeCounter = this.game.Data.RoadTypeCounter;
        for (int tdata = 0; tdata <= roadTypeCounter; ++tdata)
          this.medListObj.add(this.game.Data.RoadTypeObj[tdata].Name, tdata);
      }
      else if (this.game.EditObj.PaintShortcut1 == 3)
      {
        this.medListObj = new ATListClass();
        str1 = "Regimes";
        int regimeCounter = this.game.Data.RegimeCounter;
        for (int tdata = 0; tdata <= regimeCounter; ++tdata)
          this.medListObj.add(this.game.Data.RegimeObj[tdata].Name, tdata);
        this.medListObj.add("Neutral", this.game.Data.RegimeCounter + 1);
      }
      else if (this.game.EditObj.PaintShortcut1 == 4)
      {
        this.medListObj = new ATListClass();
        str1 = "LocType";
        int num = -1;
        int locTypeCounter = this.game.Data.LocTypeCounter;
        for (int tdata = 0; tdata <= locTypeCounter; ++tdata)
        {
          if (!this.game.Data.LocTypeObj[tdata].editorBlock)
          {
            ++num;
            this.medListObj.add(this.game.Data.LocTypeObj[tdata].Name, tdata);
            if (tdata == this.game.EditObj.PaintShortcut2)
              tlistselect1 = num;
          }
        }
      }
      else if (this.game.EditObj.PaintShortcut1 == 5)
      {
        this.medListObj = new ATListClass();
        str1 = "Rivers";
        int riverTypeCounter = this.game.Data.RiverTypeCounter;
        for (int tdata = 0; tdata <= riverTypeCounter; ++tdata)
          this.medListObj.add(this.game.Data.RiverTypeObj[tdata].Name, tdata);
      }
      else if (this.game.EditObj.PaintShortcut1 == 6)
      {
        this.medListObj = new ATListClass();
        str1 = "Bridges";
        this.medListObj.add("Bridge", 0);
      }
      else if (this.game.EditObj.PaintShortcut1 == 9)
      {
        this.medListObj = new ATListClass();
        str1 = "Slot Numbers (non-library)";
        int num = 0;
        do
        {
          this.medListObj.add(Strings.Trim(Conversion.Str((object) num)) + ") " + this.game.Data.TempString[710 + num], num);
          ++num;
        }
        while (num <= 9);
      }
      else if (this.game.EditObj.PaintShortcut1 == 10)
      {
        this.medListObj = new ATListClass();
        str1 = "Landscapes";
        this.medListObj.add("No Special", -1);
        int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
        for (int tdata = 0; tdata <= landscapeTypeCounter; ++tdata)
          this.medListObj.add(this.game.Data.LandscapeTypeObj[tdata].Name, tdata);
      }
      else if (this.game.EditObj.PaintShortcut1 == 11)
      {
        this.medListObj = new ATListClass();
        str1 = "LibVar slots";
        int num = -1;
        int libVarCounter = this.game.Data.LibVarCounter;
        for (int tdata = 0; tdata <= libVarCounter; ++tdata)
        {
          if (this.game.Data.LibVarObj[tdata].type == NewEnums.LibVarType.Hex)
          {
            ++num;
            this.medListObj.add(this.game.Data.LibVarObj[tdata].name, tdata);
            if (tdata == this.game.EditObj.PaintShortcut2)
              tlistselect1 = num;
          }
        }
      }
      else if (this.game.EditObj.PaintShortcut1 == 12)
      {
        this.medListObj = new ATListClass();
        str1 = "Height Map";
        this.medListObj.add("Height Map Values", 0);
        this.medListObj.add("Left-Right Click", 1);
      }
      if (this.game.EditObj.PaintShortcut1 != 1 && this.game.EditObj.PaintShortcut1 != 4 && this.game.EditObj.PaintShortcut1 != 11)
        tlistselect1 = this.game.EditObj.PaintShortcut2;
      if (Strings.Len(str1) > 0)
      {
        if (this.game.EditObj.PaintShortcut1 == 1 | this.game.EditObj.PaintShortcut1 >= 9)
        {
          tsubpart2 = (SubPartClass) new ATListSubPartClass(this.medListObj, 36, 250, tlistselect1, this.game, tHeader: str1, tbackbitmap: (ref this.OwnBitmap), bbx: 350, bby: 50);
          this.medlistId = this.AddSubPart(ref tsubpart2, 350, 50, 250, 624, 0);
        }
        else
        {
          tsubpart2 = (SubPartClass) new ATListSubPartClass(this.medListObj, 36, 250, tlistselect1, this.game, tHeader: str1, tbackbitmap: (ref this.OwnBitmap), bbx: 350, bby: 50);
          this.medlistId = this.AddSubPart(ref tsubpart2, 350, 50, 250, 624, 0);
        }
      }
      string str2 = "";
      int tlistselect2;
      if ((this.game.EditObj.PaintShortcut1 == 1 | this.game.EditObj.PaintShortcut1 == 10) & this.game.EditObj.PaintShortcut2 > -1)
      {
        this.lastListObj = new ATListClass();
        str2 = "Sprites";
        int basicSpriteCounter = this.game.Data.LandscapeTypeObj[this.game.EditObj.PaintShortcut2].BasicSpriteCounter;
        for (int tdata = 0; tdata <= basicSpriteCounter; ++tdata)
          this.lastListObj.add(this.game.Data.LandscapeTypeObj[this.game.EditObj.PaintShortcut2].BasicSpriteFileName[tdata], tdata);
      }
      else if (this.game.EditObj.PaintShortcut1 == 9 & this.game.EditObj.PaintShortcut2 > -1)
      {
        this.lastListObj = new ATListClass();
        str2 = "Values";
        int num = 0;
        do
        {
          int areaBySlot = this.game.HandyFunctionsObj.GetAreaBySlot(this.game.EditObj.PaintShortcut2, num);
          if (areaBySlot > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num)) + ") " + this.game.Data.AreaObj[areaBySlot].Name, num);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num)), num);
          ++num;
        }
        while (num <= 125);
      }
      else if (this.game.EditObj.PaintShortcut1 == 12 & this.game.EditObj.PaintShortcut2 == 0)
      {
        this.lastListObj = new ATListClass();
        str2 = "Values";
        int num1 = -1;
        tlistselect2 = -1;
        int num2 = 0;
        do
        {
          ++num1;
          if (num2 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num1;
          this.lastListObj.add("Height Level " + Strings.Trim(Conversion.Str((object) num2)), num2);
          ++num2;
        }
        while (num2 <= 9);
      }
      else if (this.game.EditObj.PaintShortcut1 == 11 & this.game.EditObj.PaintShortcut2 > -1)
      {
        this.lastListObj = new ATListClass();
        str2 = "Values";
        int num3 = -1;
        tlistselect2 = -1;
        int index = -1;
        int num4 = 0;
        do
        {
          ++num3;
          if (num4 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num3;
          if (index > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num4)) + ") " + this.game.Data.AreaObj[index].Name, num4);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num4)), num4);
          ++num4;
        }
        while (num4 <= 100);
        int num5 = 105;
        do
        {
          ++num3;
          if (num5 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num3;
          if (index > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num5)) + ") " + this.game.Data.AreaObj[index].Name, num5);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num5)), num5);
          num5 += 5;
        }
        while (num5 <= 250);
        int num6 = 260;
        do
        {
          ++num3;
          if (num6 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num3;
          if (index > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num6)) + ") " + this.game.Data.AreaObj[index].Name, num6);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num6)), num6);
          num6 += 10;
        }
        while (num6 <= 500);
        int num7 = 550;
        do
        {
          ++num3;
          if (num7 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num3;
          if (index > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num7)) + ") " + this.game.Data.AreaObj[index].Name, num7);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num7)), num7);
          num7 += 50;
        }
        while (num7 <= 2000);
        int num8 = 2500;
        do
        {
          ++num3;
          if (num8 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num3;
          if (index > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num8)) + ") " + this.game.Data.AreaObj[index].Name, num8);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num8)), num8);
          num8 += 500;
        }
        while (num8 <= 10000);
      }
      if (!(this.game.EditObj.PaintShortcut1 == 11 & this.game.EditObj.PaintShortcut2 > -1))
        tlistselect2 = this.game.EditObj.PaintShortcut3;
      if (Strings.Len(str2) <= 0)
        return;
      tsubpart2 = (SubPartClass) new ATListSubPartClass(this.lastListObj, 36, 250, tlistselect2, this.game, tHeader: str2, tbackbitmap: (ref this.OwnBitmap), bbx: 650, bby: 50);
      this.lastListId = this.AddSubPart(ref tsubpart2, 650, 50, 250, 624, 0);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          this.game.EditObj.TempCoordList = new CoordList();
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

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
            if (num1 == this.but1id)
            {
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.firstlistId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 > -1)
              {
                this.game.EditObj.PencilType = num2;
                this.game.EditObj.PaintShortcut1 = num2;
                this.game.EditObj.PaintShortcut2 = -1;
                this.game.EditObj.PaintShortcut3 = -1;
                if (num2 == 1 | num2 == 9)
                {
                  this.game.EditObj.PaintShortcut2 = 0;
                  this.game.EditObj.PaintShortcut3 = 0;
                  this.game.EditObj.PencilData1 = 0;
                  this.game.EditObj.PencilData2 = 0;
                }
                if (num2 == 2 | num2 == 4 | num2 == 5 | num2 == 6)
                {
                  this.game.EditObj.PaintShortcut2 = 0;
                  this.game.EditObj.PencilData1 = 0;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.medlistId)
            {
              int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              int num4 = -1;
              if (this.SubpartNr(this.lastListId) > 0)
                num4 = this.SubPartList[this.SubpartNr(this.lastListId)].GetSelect();
              this.SubPartFlag[index] = true;
              if (num3 > -1)
              {
                this.game.EditObj.PaintShortcut2 = num3;
                this.game.EditObj.PaintShortcut3 = num4;
                if (this.game.EditObj.PaintShortcut1 == 2)
                {
                  this.game.EditObj.PencilType = 2;
                  this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                }
                else if (this.game.EditObj.PaintShortcut1 == 3)
                {
                  this.game.EditObj.PencilType = 3;
                  this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                }
                else if (this.game.EditObj.PaintShortcut1 == 4)
                {
                  this.game.EditObj.PencilType = 4;
                  this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                }
                else if (this.game.EditObj.PaintShortcut1 == 5)
                {
                  this.game.EditObj.PencilType = 5;
                  this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                }
                else if (this.game.EditObj.PaintShortcut1 == 6)
                {
                  this.game.EditObj.PencilType = 6;
                  this.game.EditObj.PencilData1 = 0;
                }
                else if (this.game.EditObj.PaintShortcut1 == 1 | this.game.EditObj.PaintShortcut1 == 10)
                {
                  this.game.EditObj.PencilType = this.game.EditObj.PaintShortcut1;
                  this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                  this.game.EditObj.PencilData2 = this.game.EditObj.PaintShortcut3;
                }
                else if (this.game.EditObj.PaintShortcut1 == 9)
                {
                  this.game.EditObj.PencilType = 9;
                  this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                  this.game.EditObj.PencilData2 = this.game.EditObj.PaintShortcut3;
                }
                else if (this.game.EditObj.PaintShortcut1 == 11)
                {
                  this.game.EditObj.PencilType = 11;
                  this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                  this.game.EditObj.PencilData2 = this.game.EditObj.PaintShortcut3;
                }
                else if (this.game.EditObj.PaintShortcut1 == 12)
                {
                  this.game.EditObj.PencilType = 12;
                  this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                  this.game.EditObj.PencilData2 = this.game.EditObj.PaintShortcut3;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
              }
              else if (this.game.EditObj.PaintShortcut1 == 10)
              {
                this.game.EditObj.PencilType = this.game.EditObj.PaintShortcut1;
                this.game.EditObj.PencilData1 = -1;
                this.game.EditObj.PencilData2 = -1;
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 != this.lastListId)
              return windowReturnClass;
            int num5 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
            this.SubPartFlag[index] = true;
            if (num5 > -1)
            {
              this.game.EditObj.PaintShortcut3 = num5;
              if (this.game.EditObj.PaintShortcut1 == 1 | this.game.EditObj.PaintShortcut1 == 10)
              {
                this.game.EditObj.PencilType = this.game.EditObj.PaintShortcut1;
                this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                this.game.EditObj.PencilData2 = this.game.EditObj.PaintShortcut3;
              }
              else if (this.game.EditObj.PaintShortcut1 == 9)
              {
                this.game.EditObj.PencilType = 9;
                this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                this.game.EditObj.PencilData2 = this.game.EditObj.PaintShortcut3;
              }
              else if (this.game.EditObj.PaintShortcut1 == 11)
              {
                this.game.EditObj.PencilType = 11;
                this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                this.game.EditObj.PencilData2 = this.game.EditObj.PaintShortcut3;
              }
              else if (this.game.EditObj.PaintShortcut1 == 12)
              {
                this.game.EditObj.PencilType = 12;
                this.game.EditObj.PencilData1 = this.game.EditObj.PaintShortcut2;
                this.game.EditObj.PencilData2 = this.game.EditObj.PaintShortcut3;
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
            }
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
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
