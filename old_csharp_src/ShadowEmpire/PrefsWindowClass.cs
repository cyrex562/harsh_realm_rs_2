// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PrefsWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class PrefsWindowClass : WindowClass
  {
    private int LocNr;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int B1TextId;
    private int saveid;
    private int quitid;
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
    private int B7Id;
    private int B7TextId;
    private int B8Id;
    private int B8TextId;
    private int B9Id;
    private int B9TextId;
    private int B10Id;
    private int B10TextId;
    private int B11Id;
    private int B11TextId;
    private int B12Id;
    private int B12TextId;
    private int B13Id;
    private int B13TextId;
    private int B14Id;
    private int B14TextId;
    private int B15Id;
    private int B15TextId;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private int detailnr;
    private int regnr;

    public PrefsWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, 1024, 200, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.regnr = this.game.Data.Turn;
      this.detailnr = -1;
      this.fixshade = true;
      this.dostuff();
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
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      if (this.B8Id > 0)
        this.RemoveSubPart(this.B8Id);
      if (this.B8TextId > 0)
        this.RemoveSubPart(this.B8TextId);
      if (this.B9Id > 0)
        this.RemoveSubPart(this.B9Id);
      if (this.B9TextId > 0)
        this.RemoveSubPart(this.B9TextId);
      if (this.B10Id > 0)
        this.RemoveSubPart(this.B10Id);
      if (this.B10TextId > 0)
        this.RemoveSubPart(this.B10TextId);
      if (this.B11Id > 0)
        this.RemoveSubPart(this.B11Id);
      if (this.B11TextId > 0)
        this.RemoveSubPart(this.B11TextId);
      if (this.B12Id > 0)
        this.RemoveSubPart(this.B12Id);
      if (this.B12TextId > 0)
        this.RemoveSubPart(this.B12TextId);
      if (this.B13Id > 0)
        this.RemoveSubPart(this.B13Id);
      if (this.B13TextId > 0)
        this.RemoveSubPart(this.B13TextId);
      if (this.B14Id > 0)
        this.RemoveSubPart(this.B14Id);
      if (this.B14TextId > 0)
        this.RemoveSubPart(this.B14TextId);
      if (this.B15Id > 0)
        this.RemoveSubPart(this.B15Id);
      if (this.B15TextId > 0)
        this.RemoveSubPart(this.B15TextId);
      if (this.saveid > 0)
        this.RemoveSubPart(this.saveid);
      if (this.quitid > 0)
        this.RemoveSubPart(this.quitid);
      this.NewBackGroundAndClearAll(1024, 200, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (!this.game.EditObj.SoundOn)
      {
        SubPartClass tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 10);
        this.B1Id = this.AddSubPart(ref tsubpart, 140, 10, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 10);
        this.B1Id = this.AddSubPart(ref tsubpart, 140, 10, 35, 35, 1);
      }
      SubPartClass tsubpart1 = (SubPartClass) new ATTextPartClass("Sound Effects", this.game.VicFont2, 200, 24, false);
      this.B1TextId = this.AddSubPart(ref tsubpart1, 190, 19, 200, 24, 0);
      if (!this.game.EditObj.PrefShowFOW)
      {
        SubPartClass tsubpart2 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 45);
        this.B2Id = this.AddSubPart(ref tsubpart2, 140, 45, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart3 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 45);
        this.B2Id = this.AddSubPart(ref tsubpart3, 140, 45, 35, 35, 1);
      }
      SubPartClass tsubpart4 = (SubPartClass) new ATTextPartClass("Show FOW", this.game.VicFont2, 200, 24, false);
      this.B2TextId = this.AddSubPart(ref tsubpart4, 190, 54, 200, 24, 0);
      if (!this.game.EditObj.HexRasterOn)
      {
        SubPartClass tsubpart5 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 115);
        this.B4Id = this.AddSubPart(ref tsubpart5, 140, 115, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart6 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 115);
        this.B4Id = this.AddSubPart(ref tsubpart6, 140, 115, 35, 35, 1);
      }
      SubPartClass tsubpart7 = (SubPartClass) new ATTextPartClass("Raster Grid", this.game.VicFont2, 200, 24, false);
      this.B4TextId = this.AddSubPart(ref tsubpart7, 190, 124, 200, 24, 0);
      if (!this.game.EditObj.IntroSoundOn)
      {
        SubPartClass tsubpart8 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 80);
        this.B8Id = this.AddSubPart(ref tsubpart8, 140, 80, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart9 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 80);
        this.B8Id = this.AddSubPart(ref tsubpart9, 140, 80, 35, 35, 1);
      }
      SubPartClass tsubpart10 = (SubPartClass) new ATTextPartClass("Background Music", this.game.VicFont2, 200, 24, false);
      this.B8TextId = this.AddSubPart(ref tsubpart10, 190, 87, 200, 24, 0);
      if (!this.game.EditObj.RegimeColoring)
      {
        SubPartClass tsubpart11 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 150);
        this.B12Id = this.AddSubPart(ref tsubpart11, 140, 150, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart12 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 140, bby: 150);
        this.B12Id = this.AddSubPart(ref tsubpart12, 140, 150, 35, 35, 1);
      }
      SubPartClass tsubpart13 = (SubPartClass) new ATTextPartClass("Hex Coloring", this.game.VicFont2, 200, 24, false);
      this.B12TextId = this.AddSubPart(ref tsubpart13, 190, 157, 200, 24, 0);
      if (!this.game.Data.PBEM | this.game.EditObj.InEditor)
      {
        SubPartClass tsubpart14 = (SubPartClass) new SteveButtonPartClass(this.game.BUTTONSAVE, tDescript: "Save", tBackbitmap: (ref this.OwnBitmap), bbx: 740, bby: 90);
        this.saveid = this.AddSubPart(ref tsubpart14, 740, 140, 32, 32, 1);
        SubPartClass tsubpart15 = (SubPartClass) new ATTextPartClass("Save", this.game.VicFont2, 200, 24, false);
        this.Text2Id = this.AddSubPart(ref tsubpart15, 790, 147, 200, 24, 0);
      }
      SubPartClass tsubpart16 = (SubPartClass) new SteveButtonPartClass(this.game.BUTTONQUIT, tDescript: "Quit", tBackbitmap: (ref this.OwnBitmap), bbx: 740, bby: 50);
      this.quitid = this.AddSubPart(ref tsubpart16, 740, 105, 32, 32, 1);
      SubPartClass tsubpart17 = (SubPartClass) new ATTextPartClass("Quit", this.game.VicFont2, 200, 24, false);
      this.Text1Id = this.AddSubPart(ref tsubpart17, 790, 112, 200, 24, 0);
      if (this.game.Data.Round <= 1)
      {
        if (!this.game.EditObj.CombatSim)
        {
          SubPartClass tsubpart18 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 115);
          this.B6Id = this.AddSubPart(ref tsubpart18, 440, 115, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart19 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 115);
          this.B6Id = this.AddSubPart(ref tsubpart19, 440, 115, 35, 35, 1);
        }
        SubPartClass tsubpart20 = (SubPartClass) new ATTextPartClass("Combat Sim", this.game.VicFont2, 200, 24, false);
        this.B6TextId = this.AddSubPart(ref tsubpart20, 490, 122, 200, 24, 0);
      }
      if (!this.game.EditObj.ShowBase)
      {
        SubPartClass tsubpart21 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 150);
        this.B7Id = this.AddSubPart(ref tsubpart21, 440, 150, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart22 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 150);
        this.B7Id = this.AddSubPart(ref tsubpart22, 440, 150, 35, 35, 1);
      }
      SubPartClass tsubpart23 = (SubPartClass) new ATTextPartClass("Show Location Bases", this.game.VicFont2, 200, 24, false);
      this.B7TextId = this.AddSubPart(ref tsubpart23, 490, 159, 200, 24, 0);
      if (this.game.EditObj.HideAS)
      {
        SubPartClass tsubpart24 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 80);
        this.B5Id = this.AddSubPart(ref tsubpart24, 440, 80, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart25 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 80);
        this.B5Id = this.AddSubPart(ref tsubpart25, 440, 80, 35, 35, 1);
      }
      SubPartClass tsubpart26 = (SubPartClass) new ATTextPartClass("Show Extra Hex Info", this.game.VicFont2, 200, 24, false);
      this.B5TextId = this.AddSubPart(ref tsubpart26, 490, 84, 200, 24, 0);
      if (!this.game.EditObj.AutoSave)
      {
        SubPartClass tsubpart27 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 115);
        this.B9Id = this.AddSubPart(ref tsubpart27, 440, 10, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart28 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 115);
        this.B9Id = this.AddSubPart(ref tsubpart28, 440, 10, 35, 35, 1);
      }
      SubPartClass tsubpart29 = (SubPartClass) new ATTextPartClass("Auto Save", this.game.VicFont2, 200, 24, false);
      this.B9TextId = this.AddSubPart(ref tsubpart29, 490, 17, 200, 24, 0);
      if (!this.game.EditObj.ShowLabel)
      {
        SubPartClass tsubpart30 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 740, bby: 45);
        this.B10Id = this.AddSubPart(ref tsubpart30, 740, 45, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart31 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 740, bby: 45);
        this.B10Id = this.AddSubPart(ref tsubpart31, 740, 45, 35, 35, 1);
      }
      SubPartClass tsubpart32 = (SubPartClass) new ATTextPartClass("Show Hex Labels", this.game.VicFont2, 200, 24, false);
      this.B10TextId = this.AddSubPart(ref tsubpart32, 790, 55, 200, 24, 0);
      if (!this.game.EditObj.Screenshoton)
      {
        SubPartClass tsubpart33 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 740, bby: 130);
        this.B13Id = this.AddSubPart(ref tsubpart33, 740, 10, 35, 35, 1);
      }
      else
      {
        SubPartClass tsubpart34 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 740, bby: 130);
        this.B13Id = this.AddSubPart(ref tsubpart34, 740, 10, 35, 35, 1);
      }
      SubPartClass tsubpart35 = (SubPartClass) new ATTextPartClass("Make screenshots", this.game.VicFont2, 200, 24, false);
      this.B13TextId = this.AddSubPart(ref tsubpart35, 790, 17, 200, 24, 0);
      if (this.game.Data.Round > 0)
      {
        if (!this.game.EditObj.TownInfo)
        {
          SubPartClass tsubpart36 = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 45);
          this.B15Id = this.AddSubPart(ref tsubpart36, 440, 45, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart37 = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 440, bby: 45);
          this.B15Id = this.AddSubPart(ref tsubpart37, 440, 45, 35, 35, 1);
        }
        SubPartClass tsubpart38 = (SubPartClass) new ATTextPartClass("Town Info", this.game.VicFont2, 200, 24, false);
        this.B15TextId = this.AddSubPart(ref tsubpart38, 490, 52, 200, 24, 0);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
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
            if (num1 == this.saveid)
            {
              string str;
              if (this.game.Data.Round == 0)
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
                int eventCounter = this.game.Data.EventCounter;
                for (int index2 = 0; index2 <= eventCounter; ++index2)
                  this.game.Data.EventObj[index2].Blocked = false;
                str = this.game.HandyFunctionsObj.SaveSomething("SE1 Scenario file (*.se1)|*.se1|SE1 Map file(*.se1map)|*.se1map|SE1 Master file(*.se1master)|*.se1master|SE1 Event library(*.se1evlib)|*.se1evlib|SE1 Troops&Equipment library(*.se1troops)|*.se1troops|SE1 Historical library(*.se1his)|*.se1his|SE1 Officer Card Library(*.se1offcard)|*.se1offcard|SE1 Officer library(*.se1off)|*.se1off", "Give save name...", tinitdir, false);
              }
              else
                str = this.game.HandyFunctionsObj.SaveSomething("SE1 Scenario file (*.se1)|*.se1|SE1 Map file(*.se1map)|*.se1map|SE1 Master file(*.se1master)|*.se1master|SE1 Event library(*.se1evlib)|*.se1evlib|SE1 Troops&Equipment library(*.se1troops)|*.se1troops|SE1 Historical library(*.se1his)|*.se1his|SE1 Officer Card Library(*.se1offcard)|*.se1offcard|SE1 Officer library(*.se1off)|*.se1off", "Give save name...", this.game.AppPath_SAVEGAMES, false);
              if (Strings.Len(str) < 2)
              {
                int num2 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.Data.serialize(str);
                this.game.HandyFunctionsObj.ZipFile(str);
                windowReturnClass.SetFlag(true);
                int num3 = (int) Interaction.MsgBox((object) "Game has been saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
            }
            else if (num1 == this.quitid)
            {
              if (Interaction.MsgBox((object) "Are you Sure?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                this.game.Data = new DataClass();
                this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                this.game.EditObj.ShowInitialMenu = true;
                windowReturnClass.AddCommand(3, 1);
                windowReturnClass.SetFlag(true);
              }
            }
            else if (num1 == this.B11Id)
            {
              int x1 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give X coord to show extra history log")));
              if (x1 < 0 | x1 > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
                return windowReturnClass;
              int y1 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give Y coord to show extra history log")));
              if (y1 < 0 | y1 > this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
                return windowReturnClass;
              string str = Interaction.InputBox("Give text to add to history log of other players. ");
              if (Strings.Len(str) < 1)
                return windowReturnClass;
              ++this.game.Data.StepNr;
              this.game.HandyFunctionsObj.HistoryAddHex(x1, y1, this.game.EditObj.MapSelected, this.game.Data.Turn, 2, 0, 0, infostring: str);
            }
            else
            {
              if (num1 == this.B1Id)
              {
                this.game.EditObj.SoundOn = !this.game.EditObj.SoundOn;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B2Id)
              {
                this.game.EditObj.PrefShowFOW = !this.game.EditObj.PrefShowFOW;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(1, 3);
                windowReturnClass.AddCommand(2, 12);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B3Id)
              {
                this.game.EditObj.AutoCombat = !this.game.EditObj.AutoCombat;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B14Id)
              {
                if (this.game.EditObj.Layout == 0)
                  this.game.EditObj.Layout = 1;
                else
                  this.game.EditObj.Layout = 0;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                this.game.EditObj.CameFrom = 45;
                windowReturnClass.AddCommand(3, 3);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B12Id)
              {
                this.game.EditObj.RegimeColoring = !this.game.EditObj.RegimeColoring;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B15Id)
              {
                this.game.EditObj.TownInfo = !this.game.EditObj.TownInfo;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == 4444)
              {
                int num4 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenWidth - 200) / 53.0));
                int num5 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenWidth - 200) / 106.0));
                int num6 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 265) / 53.0));
                int num7 = (int) Math.Round(Conversion.Int((double) (this.game.ScreenHeight - 265) / 106.0));
                int num8;
                int num9;
                if (this.game.EditObj.Zoom == 0)
                {
                  this.game.EditObj.Zoom = 1;
                  this.game.CornerX += (int) Math.Round(Conversion.Int((double) num5 / 2.0));
                  this.game.CornerY += (int) Math.Round(Conversion.Int((double) num7 / 2.0));
                  num8 = 106;
                  num9 = 96;
                }
                else
                {
                  this.game.EditObj.Zoom = 0;
                  this.game.CornerX -= (int) Math.Round(Conversion.Int((double) num5 / 2.0));
                  this.game.CornerY -= (int) Math.Round(Conversion.Int((double) num7 / 2.0));
                  num8 = 53;
                  num9 = 48;
                }
                if ((double) this.game.CornerX + (double) (this.game.ScreenWidth - 200) / (double) num8 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth)
                  this.game.CornerX = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth) - (double) (this.game.ScreenWidth - 200) / (double) num8);
                if ((double) this.game.CornerY + (double) (this.game.ScreenHeight - 256) / (double) num9 > (double) this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight)
                  this.game.CornerY = (int) Math.Round((double) (1 + this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight) - (double) (this.game.ScreenHeight - 256) / (double) num9);
                if (this.game.CornerX < 0)
                  this.game.CornerX = 0;
                if (this.game.CornerY < 0)
                  this.game.CornerY = 0;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(1, 3);
                windowReturnClass.AddCommand(2, 12);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B8Id)
              {
                this.game.EditObj.IntroSoundOn = !this.game.EditObj.IntroSoundOn;
                if (!this.game.EditObj.IntroSoundOn)
                  SoundMod.STopEventBackground();
                else
                  SoundMod.RestartLastBackground(ref this.game.EditObj);
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B9Id)
              {
                this.game.EditObj.AutoSave = !this.game.EditObj.AutoSave;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B10Id)
              {
                this.game.EditObj.ShowLabel = !this.game.EditObj.ShowLabel;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B13Id)
              {
                this.game.EditObj.Screenshoton = !this.game.EditObj.Screenshoton;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B4Id)
              {
                this.game.EditObj.HexRasterOn = !this.game.EditObj.HexRasterOn;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B6Id)
              {
                this.game.EditObj.CombatSim = !this.game.EditObj.CombatSim;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B7Id)
              {
                this.game.EditObj.ShowBase = !this.game.EditObj.ShowBase;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.B5Id)
              {
                this.game.EditObj.HideAS = !this.game.EditObj.HideAS;
                this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
                windowReturnClass.AddCommand(4, 12);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
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
