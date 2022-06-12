// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleEditMapWindowClass
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
  public class SimpleEditMapWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int loadMapId;
    private int loadMapIdB;
    private int textId;
    private int detailnr;
    private int currentStep;
    private int pickid;
    private int opt1id;
    private int opt2id;
    private int opt3id;
    private int opt4id;
    private int opt5id;
    private int opt6id;
    private int opt7id;
    private int opt8id;
    private int opt9id;
    private int opt10id;
    private int opt11id;
    private int opt12id;
    private ListClass VPListOBj;
    private int miniId;
    private int VPListId;
    private int AddVPId;
    private int AddVPIdb;

    public SimpleEditMapWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, 300, 9, tDoBorders: 1, tHeaderString: "Map")
    {
      this.detailnr = -1;
      this.DoStuff();
    }

    public override void DoRefresh() => this.DoStuff();

    public void PopUpRefresh() => this.formref.Screeny.FlagAllIncludingRefresh();

    public void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 350, -1);
      DrawMod.DrawBlock(ref graphics, 2, 294, DrawMod.TGame.ScreenWidth - 4, 4, 0, 0, 0, 128);
      if (this.VPListId > 0)
        this.RemoveSubPart(this.VPListId);
      if (this.AddVPId > 0)
        this.RemoveSubPart(this.AddVPId);
      if (this.AddVPIdb > 0)
        this.RemoveSubPart(this.AddVPIdb);
      this.VPListOBj = new ListClass();
      int num2 = -1;
      int num3 = -1;
      int num4 = 0;
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int x = 0; x <= mapWidth; ++x)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int y = 0; y <= mapHeight; ++y)
        {
          if (this.game.Data.MapObj[0].HexObj[x, y].VP > 0)
          {
            ++num3;
            num4 += this.game.Data.MapObj[0].HexObj[x, y].VP;
            this.VPListOBj.add(x.ToString() + "," + y.ToString() + " VP=" + this.game.Data.MapObj[0].HexObj[x, y].VP.ToString() + ", " + this.game.HandyFunctionsObj.GetHexName(x, y, 0), x * 10000 + y);
            if (this.game.SelectX == x & this.game.SelectY == y)
              num2 = num3;
          }
        }
      }
      this.VPListOBj.add("Total VP on map = " + num4.ToString(), -2);
      ListClass vpListObj = this.VPListOBj;
      int tlistselect = num2;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      int bbx = 10 + num1;
      Font font = (Font) null;
      ref Font local2 = ref font;
      SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(vpListObj, 12, 200, tlistselect, game, true, "Victory Points (VP)", false, tValueWidth: 0, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: bbx, bby: 52, tMarcStyle: true, overruleFont: (ref local2));
      this.VPListId = this.AddSubPart(ref tsubpart, 10 + num1, 52, 220, 208, 0);
      int num5 = num1 + 250;
      int y1 = 50;
      if (this.game.SelectX > -1 & this.game.SelectY > -1)
      {
        DrawMod.DrawTextColouredMarc(ref graphics, "Selected hex:", this.game.MarcFont4, num5, y1, Color.White);
        string tstring1 = this.game.SelectX.ToString() + "," + this.game.SelectY.ToString() + "," + this.game.HandyFunctionsObj.GetHexName(this.game.SelectX, this.game.SelectY, 0);
        if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].HeightLevel > 0)
          tstring1 = tstring1 + " (Lvl " + this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].HeightLevel.ToString() + ")";
        DrawMod.DrawTextColouredMarc(ref graphics, tstring1, this.game.MarcFont3, num5, y1 + 20, Color.White);
        string tstring2 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime <= -1 ? "no regime set" : this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime].Name;
        DrawMod.DrawTextColouredMarc(ref graphics, tstring2, this.game.MarcFont3, num5, y1 + 40, Color.White);
        string tstring3 = "none";
        if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location > -1)
        {
          tstring3 = this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location].Type].Name;
          if (this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location].People > -1)
            tstring3 = tstring3 + ", " + this.game.Data.PeopleObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location].People].Name;
        }
        DrawMod.DrawTextColouredMarc(ref graphics, "Location Type + People:", this.game.MarcFont4, num5, y1 + 70, Color.White);
        DrawMod.DrawTextColouredMarc(ref graphics, tstring3, this.game.MarcFont3, num5, y1 + 90, Color.White);
        DrawMod.DrawTextColouredMarc(ref graphics, "Victory Points (VP):", this.game.MarcFont4, num5, y1 + 120, Color.White);
        DrawMod.DrawTextColouredMarc(ref graphics, this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].VP.ToString(), this.game.MarcFont3, num5, y1 + 140, Color.White);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change VP of hex", 200, "Click to change the VP on this hex.", ref this.OwnBitmap, num5, y1 + 180, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.AddVPId = this.AddSubPart(ref tsubpart, num5, y1 + 180, 200, 35, 1);
      }
      else
      {
        DrawMod.DrawTextColouredMarc(ref graphics, "Selected hex:", this.game.MarcFont4, num5, y1, Color.White);
        DrawMod.DrawTextColouredMarc(ref graphics, "None", this.game.MarcFont3, num5, y1 + 20, Color.White);
        tsubpart = (SubPartClass) new TextButtonPartClass("Change VP of hex", 200, "You have to select a hex on the map first.", ref this.OwnBitmap, num5, y1 + 120, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.AddVPIdb = this.AddSubPart(ref tsubpart, num5, y1 + 120, 200, 35, 1);
      }
      if (this.pickid > 0)
        this.RemoveSubPart(this.pickid);
      if (this.opt1id > 0)
        this.RemoveSubPart(this.opt1id);
      if (this.opt2id > 0)
        this.RemoveSubPart(this.opt2id);
      if (this.opt3id > 0)
        this.RemoveSubPart(this.opt3id);
      if (this.opt4id > 0)
        this.RemoveSubPart(this.opt4id);
      if (this.opt5id > 0)
        this.RemoveSubPart(this.opt5id);
      if (this.opt6id > 0)
        this.RemoveSubPart(this.opt6id);
      if (this.opt7id > 0)
        this.RemoveSubPart(this.opt7id);
      if (this.opt8id > 0)
        this.RemoveSubPart(this.opt8id);
      if (this.opt9id > 0)
        this.RemoveSubPart(this.opt9id);
      if (this.opt10id > 0)
        this.RemoveSubPart(this.opt10id);
      if (this.opt12id > 0)
        this.RemoveSubPart(this.opt12id);
      int num6 = num1 + 500;
      int y2 = 50;
      bool flag1;
      string str1;
      string str2;
      if (this.game.EditObj.PencilType > 0)
      {
        if (!(this.game.EditObj.PencilType == 3 | this.game.EditObj.PencilType == 10 | this.game.EditObj.PencilType == 12 | this.game.EditObj.PencilType == 11 | this.game.EditObj.PencilType == 1 | this.game.EditObj.PencilType == 9))
          flag1 = true;
        string str3;
        if (this.game.EditObj.PencilType == 1 | this.game.EditObj.PencilType == 10)
        {
          str1 = "Landsc# " + Conversion.Str((object) this.game.EditObj.PencilData1) + "," + Conversion.Str((object) this.game.EditObj.PencilData2);
          str2 = this.game.Data.LandscapeTypeObj[this.game.EditObj.PencilData1].Name;
          str3 = "Left click to draw this landscape+sprite on a hex, right click to only select a hex.";
        }
        else if (this.game.EditObj.PencilType == 2)
        {
          str1 = "Road# " + Conversion.Str((object) this.game.EditObj.PencilData1);
          str2 = this.game.Data.RoadTypeObj[this.game.EditObj.PencilData1].Name;
          str3 = "First right click to select a hex, then left click on a neighbouring hex to draw a road between them.";
        }
        else if (this.game.EditObj.PencilType == 3)
        {
          str1 = "Reg# " + Conversion.Str((object) this.game.EditObj.PencilData1);
          str2 = this.game.EditObj.PencilData1 <= this.game.Data.RegimeCounter ? this.game.Data.RegimeObj[this.game.EditObj.PencilData1].Name : "Neutral Hex";
          str3 = "Left click to draw this regime on a hex, right click just to select a hex, clicking twice results in hex becoming neutral again.";
        }
        else if (this.game.EditObj.PencilType == 4)
        {
          str1 = "LocTyp# " + Conversion.Str((object) this.game.EditObj.PencilData1);
          str2 = this.game.Data.LocTypeObj[this.game.EditObj.PencilData1].Name;
          str3 = "Left click on a hex to place a location of this locationtype. Right click is only select.";
        }
        else if (this.game.EditObj.PencilType == 5)
        {
          str1 = "RiverTyp# " + Conversion.Str((object) this.game.EditObj.PencilData1);
          str2 = this.game.Data.RiverTypeObj[this.game.EditObj.PencilData1].Name;
          str3 = "First right click to select a hex, then left click on a neighbouring hex to draw a river inbetween them.";
        }
        else if (this.game.EditObj.PencilType == 6)
        {
          str1 = "Bridge";
          str2 = "";
          str3 = "First right click to select a hex, then left click on a neighbouring hex to draw a bridge in between them.";
        }
        else if (this.game.EditObj.PencilType == 9)
        {
          str1 = "Slot# " + Conversion.Str((object) this.game.EditObj.PencilData1) + ", => " + Conversion.Str((object) this.game.EditObj.PencilData2);
          str2 = "";
          str3 = "Left click to place this value on a hex, right click just to select a hex.";
        }
        else if (this.game.EditObj.PencilType == 11)
        {
          str1 = "Hex LibVar# " + Conversion.Str((object) this.game.EditObj.PencilData1);
          str2 = "value " + Conversion.Str((object) this.game.EditObj.PencilData2);
          str3 = "Left click to place this value on a hex, right click just to select a hex.";
        }
        else if (this.game.EditObj.PencilType == 12)
        {
          str1 = "Height Level";
          str2 = Conversion.Str((object) this.game.EditObj.PencilData2);
          str3 = "Left click to place this value on a hex.";
        }
        else
        {
          str1 = "Pointer";
          str2 = "";
          str3 = "I hope you are having a good day!";
        }
      }
      string str4 = this.game.EditObj.PencilMode != 0 ? "Fill" : "Draw";
      if (this.game.EditObj.PencilType == 0)
      {
        str4 = "None";
        str1 = "N/a";
      }
      DrawMod.DrawTextColouredMarc(ref graphics, "Draw mode:", this.game.MarcFont4, num6, y2, Color.White);
      DrawMod.DrawTextColouredMarc(ref graphics, "Draw type:", this.game.MarcFont4, num6, y2 + 50, Color.White);
      DrawMod.DrawTextColouredMarc(ref graphics, str1 + " " + str2, this.game.MarcFont3, num6, y2 + 18, Color.White);
      DrawMod.DrawTextColouredMarc(ref graphics, str4, this.game.MarcFont3, num6, y2 + 68, Color.White);
      tsubpart = (SubPartClass) new TextButtonPartClass("Pick Draw Type", 160, tBackbitmap: (ref this.OwnBitmap), bbx: num6, bby: (y2 + 140), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.pickid = this.AddSubPart(ref tsubpart, num6, y2 + 140, 160, 35, 1);
      if (Operators.CompareString(str4, "Draw", false) == 0)
      {
        if (!flag1)
        {
          tsubpart = (SubPartClass) new TextButtonPartClass("Go to fill mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: num6, bby: (y2 + 100), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.opt2id = this.AddSubPart(ref tsubpart, num6, y2 + 100, 160, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new TextButtonPartClass("Go to fill mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: num6, bby: (y2 + 100), tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.opt4id = this.AddSubPart(ref tsubpart, num6, y2 + 100, 160, 35, 0);
        }
      }
      else if (Operators.CompareString(str4, "Fill", false) == 0)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Go to draw mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: num6, bby: (y2 + 100), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.opt1id = this.AddSubPart(ref tsubpart, num6, y2 + 100, 160, 35, 1);
      }
      if (Operators.CompareString(str4, "None", false) != 0)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("End drawing mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: num6, bby: (y2 + 180), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.opt3id = this.AddSubPart(ref tsubpart, num6, y2 + 180, 160, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Go to fill mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: num6, bby: (y2 + 100), tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.opt4id = this.AddSubPart(ref tsubpart, num6, y2 + 100, 160, 35, 0);
        tsubpart = (SubPartClass) new TextButtonPartClass("End drawing mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: num6, bby: (y2 + 140), tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.opt5id = this.AddSubPart(ref tsubpart, num6, y2 + 180, 160, 35, 1);
      }
      if (this.game.EditObj.inSimpleMapEditor)
      {
        bool flag2 = true;
        if (this.game.SelectX > -1 && this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Location > -1)
          flag2 = false;
        if (!flag2)
        {
          tsubpart = (SubPartClass) new TextButtonPartClass("Rename location", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num6 + 180), bby: (y2 + 60), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.opt12id = this.AddSubPart(ref tsubpart, num6 + 180, y2 + 60, 160, 35, 1);
          tsubpart = (SubPartClass) new TextButtonPartClass("Delete location", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num6 + 180), bby: (y2 + 100), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.opt7id = this.AddSubPart(ref tsubpart, num6 + 180, y2 + 100, 160, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new TextButtonPartClass("Set hex name", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num6 + 180), bby: (y2 + 100), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.opt8id = this.AddSubPart(ref tsubpart, num6 + 180, y2 + 100, 160, 35, 1);
        }
        tsubpart = (SubPartClass) new TextButtonPartClass("Set Labels", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num6 + 180), bby: (y2 + 140), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.opt9id = this.AddSubPart(ref tsubpart, num6 + 180, y2 + 140, 160, 35, 1);
        tsubpart = (SubPartClass) new TextButtonPartClass("Remove Labels", 160, tBackbitmap: (ref this.OwnBitmap), bbx: (num6 + 180), bby: (y2 + 180), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.opt10id = this.AddSubPart(ref tsubpart, num6 + 180, y2 + 180, 160, 35, 1);
      }
      if (this.miniId > 0)
      {
        this.RemoveSubPart(this.miniId);
        this.miniId = 0;
      }
      if (this.miniId >= 1)
        return;
      tsubpart = (SubPartClass) new MiniMapPartClass(DrawMod.TGame, tx: (100 + num1), ty: 220);
      this.miniId = this.AddSubPart(ref tsubpart, num1 + 860, 50, 180 + num1, 220, 0);
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
            if (num1 == this.VPListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                int tx = (int) Math.Round(Conversion.Int((double) num2 / 10000.0));
                int ty = num2 % 10000;
                this.game.SelectX = tx;
                this.game.SelectY = ty;
                this.game.HandyFunctionsObj.CenterOnXY(tx, ty, true);
                windowReturnClass.AddCommand(4, 12);
                this.DoStuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddVPId)
            {
              string DefaultResponse = "";
              if (this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].VP > 0)
                DefaultResponse = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].VP.ToString().ToString();
              this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].VP = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give new number value for variable", "Shadow Empire : Planetary Conquest", DefaultResponse)));
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.pickid)
            {
              this.game.EditObj.PopupValue = 16;
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.AddCommand(5, 10);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.opt1id)
            {
              this.game.EditObj.PencilMode = 0;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
            }
            else
            {
              if (num1 == this.opt2id)
              {
                this.game.EditObj.PencilMode = 1;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt3id)
              {
                this.game.EditObj.PencilType = 0;
                this.game.EditObj.PencilMode = 0;
                this.game.EditObj.PaintShortcut1 = -1;
                this.game.EditObj.PaintShortcut2 = -1;
                this.game.EditObj.PaintShortcut3 = -1;
                this.DoStuff();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt7id)
              {
                this.game.Data.RemoveLoc(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location);
                this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location = -1;
                this.DoStuff();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt12id)
              {
                this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Name = Interaction.InputBox("Give new name for location", "Shadow Empire : Planetary Conquest", this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Name);
                this.DoStuff();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt8id)
              {
                this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Name = Interaction.InputBox("Give new name for hex", "Shadow Empire : Planetary Conquest", this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Name);
                this.DoStuff();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt9id)
              {
                this.game.HandyFunctionsObj.MakeAutoLabels(1, 1);
                this.game.HandyFunctionsObj.MakeAutoLabels(2, 2);
                this.game.HandyFunctionsObj.MakeAutoLabels(5, 3);
                int num3 = (int) Interaction.MsgBox((object) "Set all hex labels");
                this.DoStuff();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.opt10id)
              {
                int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
                for (int index2 = 0; index2 <= mapWidth; ++index2)
                {
                  int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
                  for (int index3 = 0; index3 <= mapHeight; ++index3)
                  {
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index2, index3].LabelText1 = "";
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index2, index3].LabelText2 = "";
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index2, index3].LabelType1 = 0;
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index2, index3].LabelType2 = 0;
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index2, index3].SmallLabel = "";
                    this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index2, index3].SmallLabelType = 0;
                  }
                }
                int num4 = (int) Interaction.MsgBox((object) "Removed all hex labels");
                this.DoStuff();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.miniId)
              {
                this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                windowReturnClass.AddCommand(4, 12);
                this.DoStuff();
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
