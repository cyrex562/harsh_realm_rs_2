// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.BridgeWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;

namespace WindowsApplication1
{
  public class BridgeWindowClass : WindowClass
  {
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int BDrawId;
    private int BDrawTextId;
    private int BAltId;
    private int BAltTextId;
    private ListClass BasicListObj;
    private int BasicListId;
    private int BBasicSpriteId;
    private int BChangeBasicSpriteId;
    private int BAlternateSpriteId;
    private int BChangeAlternateSpriteId;
    private int[] Bitemid;
    private int[] bitemtextid;
    private int BEP;
    private int BEPText;
    private int bridgeNr;
    private int TabSheetNr;
    private int DetailNr;
    private string ss;

    public BridgeWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 100, tDoBorders: 1, tHeaderString: "Bridge")
    {
      this.Bitemid = new int[5];
      this.bitemtextid = new int[5];
      this.bridgeNr = 0;
      this.TabSheetNr = -1;
      this.DetailNr = -1;
      this.MakebridgeListGUI(-1);
    }

    private void MakebridgeListGUI(int tbridgenr) => this.MakebridgeTypeItemGUI();

    private void MakebridgeTypeItemGUI()
    {
      if (this.BAltId > 0)
        this.RemoveSubPart(this.BAltId);
      if (this.BAltTextId > 0)
        this.RemoveSubPart(this.BAltTextId);
      if (this.BDrawId > 0)
        this.RemoveSubPart(this.BDrawId);
      if (this.BDrawTextId > 0)
        this.RemoveSubPart(this.BDrawTextId);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      int index = 0;
      do
      {
        if (this.Bitemid[index] > 0)
          this.RemoveSubPart(this.Bitemid[index]);
        if (this.bitemtextid[index] > 0)
          this.RemoveSubPart(this.bitemtextid[index]);
        ++index;
      }
      while (index <= 4);
      if (this.BEP > 0)
        this.RemoveSubPart(this.BEP);
      if (this.BEPText > 0)
        this.RemoveSubPart(this.BEPText);
      if (this.bridgeNr > -1)
      {
        this.ss = "Click to set the basic EP Cost to build a bridge. This is modified by the size of the river.";
        SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BEP = this.AddSubPart(ref tsubpart1, 10, 140, 32, 16, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("EPCOST=" + Conversion.Str((object) this.game.Data.BridgeObj[0].EPCost), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 400, 20, false, tDescript: this.ss);
        this.BEPText = this.AddSubPart(ref tsubpart2, 50, 139, 400, 20, 0);
        this.ss = "Click to draw a bridge on the map.";
        SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONDRAW, tDescript: this.ss);
        this.BDrawId = this.AddSubPart(ref tsubpart3, 10, 160, 32, 16, 1);
        SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Select as pencil", new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BDrawTextId = this.AddSubPart(ref tsubpart4, 50, 159, 200, 20, 0);
        this.ss = "Click to set with which roadtype the alternate graphic is used. -1=never";
        SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BAltId = this.AddSubPart(ref tsubpart5, 10, 180, 32, 16, 1);
        SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Alt=" + Conversion.Str((object) this.game.Data.BridgeObj[0].AlternateIfRoadType) + ", " + Conversion.Str((object) this.game.Data.BridgeObj[0].AlternateIfRoadType2) + ", " + Conversion.Str((object) this.game.Data.BridgeObj[0].AlternateIfRoadType3) + ", " + Conversion.Str((object) this.game.Data.BridgeObj[0].AlternateIfRoadType4), new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 20, false, tDescript: this.ss);
        this.BAltTextId = this.AddSubPart(ref tsubpart6, 50, 179, 200, 20, 0);
        this.OptionsListObj = new ListClass();
        this.OptionsListObj.add("The 6 Sprites", 0);
        this.OptionsListObj.add("Statistics", 1);
        ListClass optionsListObj = this.OptionsListObj;
        int tabSheetNr = this.TabSheetNr;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart7 = (SubPartClass) new ListSubPartClass(optionsListObj, 3, 300, tabSheetNr, game, tHeader: "Property Sheets", tbackbitmap: (ref local1), bbx: 370, bby: 140, overruleFont: (ref local2));
        this.OptionsListId = this.AddSubPart(ref tsubpart7, 370, 140, 300, 96, 0);
      }
      this.maketabsheet();
    }

    private void maketabsheet()
    {
      if (this.BasicListId > 0)
        this.RemoveSubPart(this.BasicListId);
      if (this.BBasicSpriteId > 0)
        this.RemoveSubPart(this.BBasicSpriteId);
      if (this.BChangeBasicSpriteId > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId);
      if (this.BAlternateSpriteId > 0)
        this.RemoveSubPart(this.BAlternateSpriteId);
      if (this.BChangeAlternateSpriteId > 0)
        this.RemoveSubPart(this.BChangeAlternateSpriteId);
      if (!(this.bridgeNr > -1 & this.TabSheetNr > -1))
        return;
      if (this.TabSheetNr == 0)
        this.maketabsheetnr0();
      if (this.TabSheetNr != 1)
        return;
      this.maketabsheetnr1();
    }

    private void maketabsheetnr0()
    {
      if (this.game.Data.LandscapeTypeObj[this.bridgeNr].BasicSpriteCounter <= -1)
        return;
      this.BasicListObj = new ListClass();
      int tdata = 0;
      do
      {
        this.BasicListObj.add(this.game.Data.BridgeObj[this.bridgeNr].BasicSpriteFileName[tdata], tdata);
        ++tdata;
      }
      while (tdata <= 5);
      ListClass basicListObj = this.BasicListObj;
      int detailNr = this.DetailNr;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(basicListObj, 10, 300, detailNr, game, tHeader: "Sprites", tbackbitmap: (ref local1), bbx: 10, bby: 350, overruleFont: (ref local2));
      this.BasicListId = this.AddSubPart(ref tsubpart, 10, 350, 300, 208, 0);
      if (this.DetailNr > 5)
        this.DetailNr = -1;
      if (this.DetailNr <= -1)
        return;
      this.maketabsheetnr0b();
    }

    private void maketabsheetnr0b()
    {
      if (this.BBasicSpriteId > 0)
        this.RemoveSubPart(this.BBasicSpriteId);
      if (this.BChangeBasicSpriteId > 0)
        this.RemoveSubPart(this.BChangeBasicSpriteId);
      if (this.BAlternateSpriteId > 0)
        this.RemoveSubPart(this.BAlternateSpriteId);
      if (this.BChangeAlternateSpriteId > 0)
        this.RemoveSubPart(this.BChangeAlternateSpriteId);
      this.ss = "Click to change this sprite";
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.Data.BridgeObj[this.bridgeNr].BasicSpriteID[this.DetailNr], tDescript: this.ss);
      this.BBasicSpriteId = this.AddSubPart(ref tsubpart1, 400, 350, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) == 0)
      {
        SubPartClass tsubpart2 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
        this.BChangeBasicSpriteId = this.AddSubPart(ref tsubpart2, 400, 410, 32, 16, 1);
      }
      this.ss = "Click to change this alternate sprite";
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.Data.BridgeObj[this.bridgeNr].AlternateSpriteID[this.DetailNr], tDescript: this.ss);
      this.BAlternateSpriteId = this.AddSubPart(ref tsubpart3, 600, 350, 64, 48, 0);
      if (Strings.Len(this.game.Data.MasterFile) != 0)
        return;
      SubPartClass tsubpart4 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK, tDescript: this.ss);
      this.BChangeAlternateSpriteId = this.AddSubPart(ref tsubpart4, 600, 410, 32, 16, 1);
    }

    private void maketabsheetnr1()
    {
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
            if (num1 == this.OptionsListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 > -1)
              {
                this.TabSheetNr = num2;
                this.maketabsheet();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BasicListId)
            {
              int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num3 > -1)
              {
                this.DetailNr = num3;
                this.maketabsheetnr0b();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BChangeBasicSpriteId)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Bitmaps (*.bmp)|*.bmp|Png|*.png", "Select File For Bridge Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.BridgeObj[this.bridgeNr].ReplaceBasicSprite(this.DetailNr, filename);
              }
              else
              {
                int num4 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BChangeAlternateSpriteId)
            {
              string filename = this.game.HandyFunctionsObj.LoadSomething("Bitmaps (*.bmp)|*.bmp|Png|*.png", "Select File For Bridge Sprite:", this.game.AppPath + "graphics\\", true);
              if (File.Exists(this.game.AppPath + "graphics/" + filename))
              {
                this.game.Data.BridgeObj[this.bridgeNr].ReplaceAlternateSprite(this.DetailNr, filename);
              }
              else
              {
                int num5 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.maketabsheet();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BDrawId)
            {
              this.game.EditObj.PencilType = 6;
              this.game.EditObj.PencilData1 = this.bridgeNr;
              windowReturnClass.AddCommand(1, 13);
              windowReturnClass.AddCommand(2, 13);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BAltId)
            {
              int num6 = (int) Math.Round(Conversion.Val(Interaction.InputBox("TYPE: Give roadtype or -1", "Shadow Empire : Planetary Conquest")));
              if (num6 >= -1 & num6 <= this.game.Data.RoadTypeCounter)
                this.game.Data.BridgeObj[0].AlternateIfRoadType = num6;
              int num7 = (int) Math.Round(Conversion.Val(Interaction.InputBox("SECOND TYPE: Give roadtype or -1", "Shadow Empire : Planetary Conquest")));
              if (num7 >= -1 & num7 <= this.game.Data.RoadTypeCounter)
                this.game.Data.BridgeObj[0].AlternateIfRoadType2 = num7;
              int num8 = (int) Math.Round(Conversion.Val(Interaction.InputBox("THIRD TYPE: Give roadtype or -1", "Shadow Empire : Planetary Conquest")));
              if (num8 >= -1 & num8 <= this.game.Data.RoadTypeCounter)
                this.game.Data.BridgeObj[0].AlternateIfRoadType3 = num8;
              int num9 = (int) Math.Round(Conversion.Val(Interaction.InputBox("FOURTH TYPE: Give roadtype or -1", "Shadow Empire : Planetary Conquest")));
              if (num9 >= -1 & num9 <= this.game.Data.RoadTypeCounter)
                this.game.Data.BridgeObj[0].AlternateIfRoadType4 = num9;
              this.MakebridgeTypeItemGUI();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.BEP)
            {
              int num10 = (int) Math.Round(Conversion.Val(Interaction.InputBox("TYPE: Give new EP cost", "Shadow Empire : Planetary Conquest")));
              if (num10 > -1 & num10 < 9999)
                this.game.Data.BridgeObj[0].EPCost = num10;
              this.MakebridgeTypeItemGUI();
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
