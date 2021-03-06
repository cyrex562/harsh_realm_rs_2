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
  pub class EditorPaintWindowClass : WindowClass
  {
     int TempText1;
     int temptext2;
     int temptext3;
     int temptext4;
     int temptext5;
     int temptext6;
     int temptext7;
     int temptext8;
     int temptext9;
     int temptext10;
     int TempText11;
     int temptext12;
     int temptext13;
     int temptext14;
     int temptext15;
     int temptext16;
     int temptext17;
     int temptext18;
     int temptext19;
     int temptext20;
     int TempText21;
     int temptext22;
     int temptext23;
     int temptext24;
     int temptext25;
     int temptext26;
     int temptext27;
     int temptext28;
     int temptext29;
     int temptext30;
     int TempText31;
     int temptext32;
     int temptext33;
     int temptext34;
     int temptext35;
     int temptext36;
     int temptext37;
     int temptext38;
     int temptext39;
     int temptext40;
     int temptext41;
     int temptext42;
     int temptext43;
     int temptext44;
     int temptext45;
     int temptext46;
     int LogoListId;
     int but1id;
     int tab1id;
     int tab2id;
     int tab3id;
     int tab4id;
     int tab5id;
     int but1textid;
     int but1bid;
     int hqbut0;
     int hqbut1;
     int hqbut2;
     int but2id;
     int but2textid;
     int but3id;
     int but3textid;
     int but4id;
     int but4textid;
     int but5id;
     int but5textid;
     int but6id;
     int but6textid;
     int but7id;
     int quitid;
     int but7textid;
     int descid;
     int comparenr;
     int sliderid;
     int logolist2id;
     int logolist3id;
     float tempBlink;
     int unr;
     int sfnr;
     int sftyp;
     int detailnr;
     int detailnr2;
     int detailtype;
     int ammount;
     bool hqreach;
     int passenger;
     int firstlistId;
     ATListClass firstlistObj;
     int medlistId;
     ATListClass medListObj;
     int lastListId;
     ATListClass lastListObj;
     int OptionsList4Id;
     ATListClass OptionsList4Obj;
     int OptionsList5Id;
     ATListClass OptionsList5Obj;
     int OptionsList6Id;
     ATListClass OptionsList6Obj;
     int combatListId;
     ATListClass combatListObj;
     int combatList2Id;
     ATListClass combatList2Obj;
     int StatTyp;
     int StatMode;
     int[] ChainHq;
     int HQselect;
     int infoid;
     int ltnr;
     int locnr;
     int ppl;
     int spnr;

    pub handleTimer: WindowReturnClass() => WindowReturnClass::new();

    pub EditorPaintWindowClass(ref GameClass tGame)
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

    pub void DoStuff()
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
      let mut tsubpart1: SubPartClass =  new TextButtonPartClass("OK", 320, tBackbitmap: (ref this.OwnBitmap), bbx: 312, bby: 680, theight: 45);
      this.but1id = this.AddSubPart(ref tsubpart1, 312, 680, 320, 45, 1);
      this.firstlistObj = ATListClass::new();
      let mut tlistselect1: i32 =  -1;
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
      let mut tsubpart2: SubPartClass =  new ATListSubPartClass(this.firstlistObj, 18, 250, tlistselect1, this.game, tHeader: "What?", tbackbitmap: (ref this.OwnBitmap), bbx: 50, bby: 50);
      this.firstlistId = this.AddSubPart(ref tsubpart2, 50, 50, 250, 336, 0);
      str1: String = "";
      if (this.game.EditObj.PaintShortcut1 == 1)
      {
        this.medListObj = ATListClass::new();
        str1 = "Landscapes";
        let mut num: i32 =  -1;
        let mut landscapeTypeCounter: i32 =  this.game.Data.LandscapeTypeCounter;
        for (let mut tdata: i32 =  0; tdata <= landscapeTypeCounter; tdata += 1)
        {
          if (!this.game.Data.LandscapeTypeObj[tdata].DontShowInList)
          {
            this.medListObj.add(this.game.Data.LandscapeTypeObj[tdata].Name, tdata);
            num += 1;
            if (tdata == this.game.EditObj.PaintShortcut2)
              tlistselect1 = num;
          }
        }
      }
      else if (this.game.EditObj.PaintShortcut1 == 2)
      {
        this.medListObj = ATListClass::new();
        str1 = "Roads";
        let mut roadTypeCounter: i32 =  this.game.Data.RoadTypeCounter;
        for (let mut tdata: i32 =  0; tdata <= roadTypeCounter; tdata += 1)
          this.medListObj.add(this.game.Data.RoadTypeObj[tdata].Name, tdata);
      }
      else if (this.game.EditObj.PaintShortcut1 == 3)
      {
        this.medListObj = ATListClass::new();
        str1 = "Regimes";
        let mut regimeCounter: i32 =  this.game.Data.RegimeCounter;
        for (let mut tdata: i32 =  0; tdata <= regimeCounter; tdata += 1)
          this.medListObj.add(this.game.Data.RegimeObj[tdata].Name, tdata);
        this.medListObj.add("Neutral", this.game.Data.RegimeCounter + 1);
      }
      else if (this.game.EditObj.PaintShortcut1 == 4)
      {
        this.medListObj = ATListClass::new();
        str1 = "LocType";
        let mut num: i32 =  -1;
        let mut locTypeCounter: i32 =  this.game.Data.LocTypeCounter;
        for (let mut tdata: i32 =  0; tdata <= locTypeCounter; tdata += 1)
        {
          if (!this.game.Data.LocTypeObj[tdata].editorBlock)
          {
            num += 1;
            this.medListObj.add(this.game.Data.LocTypeObj[tdata].Name, tdata);
            if (tdata == this.game.EditObj.PaintShortcut2)
              tlistselect1 = num;
          }
        }
      }
      else if (this.game.EditObj.PaintShortcut1 == 5)
      {
        this.medListObj = ATListClass::new();
        str1 = "Rivers";
        let mut riverTypeCounter: i32 =  this.game.Data.RiverTypeCounter;
        for (let mut tdata: i32 =  0; tdata <= riverTypeCounter; tdata += 1)
          this.medListObj.add(this.game.Data.RiverTypeObj[tdata].Name, tdata);
      }
      else if (this.game.EditObj.PaintShortcut1 == 6)
      {
        this.medListObj = ATListClass::new();
        str1 = "Bridges";
        this.medListObj.add("Bridge", 0);
      }
      else if (this.game.EditObj.PaintShortcut1 == 9)
      {
        this.medListObj = ATListClass::new();
        str1 = "Slot Numbers (non-library)";
        let mut num: i32 =  0;
        do
        {
          this.medListObj.add(Strings.Trim(Conversion.Str((object) num)) + ") " + this.game.Data.TempString[710 + num], num);
          num += 1;
        }
        while (num <= 9);
      }
      else if (this.game.EditObj.PaintShortcut1 == 10)
      {
        this.medListObj = ATListClass::new();
        str1 = "Landscapes";
        this.medListObj.add("No Special", -1);
        let mut landscapeTypeCounter: i32 =  this.game.Data.LandscapeTypeCounter;
        for (let mut tdata: i32 =  0; tdata <= landscapeTypeCounter; tdata += 1)
          this.medListObj.add(this.game.Data.LandscapeTypeObj[tdata].Name, tdata);
      }
      else if (this.game.EditObj.PaintShortcut1 == 11)
      {
        this.medListObj = ATListClass::new();
        str1 = "LibVar slots";
        let mut num: i32 =  -1;
        let mut libVarCounter: i32 =  this.game.Data.LibVarCounter;
        for (let mut tdata: i32 =  0; tdata <= libVarCounter; tdata += 1)
        {
          if (this.game.Data.LibVarObj[tdata].type == NewEnums.LibVarType.Hex)
          {
            num += 1;
            this.medListObj.add(this.game.Data.LibVarObj[tdata].name, tdata);
            if (tdata == this.game.EditObj.PaintShortcut2)
              tlistselect1 = num;
          }
        }
      }
      else if (this.game.EditObj.PaintShortcut1 == 12)
      {
        this.medListObj = ATListClass::new();
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
          tsubpart2 =  new ATListSubPartClass(this.medListObj, 36, 250, tlistselect1, this.game, tHeader: str1, tbackbitmap: (ref this.OwnBitmap), bbx: 350, bby: 50);
          this.medlistId = this.AddSubPart(ref tsubpart2, 350, 50, 250, 624, 0);
        }
        else
        {
          tsubpart2 =  new ATListSubPartClass(this.medListObj, 36, 250, tlistselect1, this.game, tHeader: str1, tbackbitmap: (ref this.OwnBitmap), bbx: 350, bby: 50);
          this.medlistId = this.AddSubPart(ref tsubpart2, 350, 50, 250, 624, 0);
        }
      }
      str2: String = "";
      int tlistselect2;
      if ((this.game.EditObj.PaintShortcut1 == 1 | this.game.EditObj.PaintShortcut1 == 10) & this.game.EditObj.PaintShortcut2 > -1)
      {
        this.lastListObj = ATListClass::new();
        str2 = "Sprites";
        let mut basicSpriteCounter: i32 =  this.game.Data.LandscapeTypeObj[this.game.EditObj.PaintShortcut2].BasicSpriteCounter;
        for (let mut tdata: i32 =  0; tdata <= basicSpriteCounter; tdata += 1)
          this.lastListObj.add(this.game.Data.LandscapeTypeObj[this.game.EditObj.PaintShortcut2].BasicSpriteFileName[tdata], tdata);
      }
      else if (this.game.EditObj.PaintShortcut1 == 9 & this.game.EditObj.PaintShortcut2 > -1)
      {
        this.lastListObj = ATListClass::new();
        str2 = "Values";
        let mut num: i32 =  0;
        do
        {
          let mut areaBySlot: i32 =  this.game.HandyFunctionsObj.GetAreaBySlot(this.game.EditObj.PaintShortcut2, num);
          if (areaBySlot > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num)) + ") " + this.game.Data.AreaObj[areaBySlot].Name, num);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num)), num);
          num += 1;
        }
        while (num <= 125);
      }
      else if (this.game.EditObj.PaintShortcut1 == 12 & this.game.EditObj.PaintShortcut2 == 0)
      {
        this.lastListObj = ATListClass::new();
        str2 = "Values";
        let mut num1: i32 =  -1;
        tlistselect2 = -1;
        let mut num2: i32 =  0;
        do
        {
          num1 += 1;
          if (num2 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num1;
          this.lastListObj.add("Height Level " + Strings.Trim(Conversion.Str((object) num2)), num2);
          num2 += 1;
        }
        while (num2 <= 9);
      }
      else if (this.game.EditObj.PaintShortcut1 == 11 & this.game.EditObj.PaintShortcut2 > -1)
      {
        this.lastListObj = ATListClass::new();
        str2 = "Values";
        let mut num3: i32 =  -1;
        tlistselect2 = -1;
        let mut index: i32 =  -1;
        let mut num4: i32 =  0;
        do
        {
          num3 += 1;
          if (num4 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num3;
          if (index > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num4)) + ") " + this.game.Data.AreaObj[index].Name, num4);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num4)), num4);
          num4 += 1;
        }
        while (num4 <= 100);
        let mut num5: i32 =  105;
        do
        {
          num3 += 1;
          if (num5 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num3;
          if (index > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num5)) + ") " + this.game.Data.AreaObj[index].Name, num5);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num5)), num5);
          num5 += 5;
        }
        while (num5 <= 250);
        let mut num6: i32 =  260;
        do
        {
          num3 += 1;
          if (num6 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num3;
          if (index > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num6)) + ") " + this.game.Data.AreaObj[index].Name, num6);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num6)), num6);
          num6 += 10;
        }
        while (num6 <= 500);
        let mut num7: i32 =  550;
        do
        {
          num3 += 1;
          if (num7 == this.game.EditObj.PaintShortcut3)
            tlistselect2 = num3;
          if (index > -1)
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num7)) + ") " + this.game.Data.AreaObj[index].Name, num7);
          else
            this.lastListObj.add(Strings.Trim(Conversion.Str((object) num7)), num7);
          num7 += 50;
        }
        while (num7 <= 2000);
        let mut num8: i32 =  2500;
        do
        {
          num3 += 1;
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
      tsubpart2 =  new ATListSubPartClass(this.lastListObj, 36, 250, tlistselect2, this.game, tHeader: str2, tbackbitmap: (ref this.OwnBitmap), bbx: 650, bby: 50);
      this.lastListId = this.AddSubPart(ref tsubpart2, 650, 50, 250, 624, 0);
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      try
      {
        if (nr == 27 | nr == 32)
        {
          this.game.EditObj.TempCoordList = CoordList::new();
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

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 =  this.SubPartCounter;
        for (let mut index: i32 =  0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            let mut num1: i32 =  this.SubPartID[index];
            if (num1 == this.but1id)
            {
              windowReturnClass.AddCommand(6, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.firstlistId)
            {
              let mut num2: i32 =  this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
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
              let mut num3: i32 =  this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              let mut num4: i32 =  -1;
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
            let mut num5: i32 =  this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
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
