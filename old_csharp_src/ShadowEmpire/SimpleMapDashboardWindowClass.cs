// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleMapDashboardWindowClass
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
  public class SimpleMapDashboardWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int loadMapId;
    private int setdateid;
    private int exportid;
    private int setdescriptid;
    private int setnameid;
    private int setdesignid;
    private int loadMapIdB;
    private int saveId;
    private int newId;
    private int textId;
    private int text2id;
    private int text3id;
    private int detailnr;
    private int currentStep;
    private int loadLayer;
    private int removeLayer;
    private int removeLayerB;
    private int rleft;
    private int rtop;
    private int rbottom;
    private int rright;
    private int aleft;
    private int atop;
    private int abottom;
    private int aright;
    private int e1id;
    private int e2id;
    private int e3id;

    public SimpleMapDashboardWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Map Options")
    {
      this.detailnr = -1;
      this.DoStuff();
    }

    public void PopUpRefresh() => this.DoStuff();

    public void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      if (this.loadMapId > 0)
        this.RemoveSubPart(this.loadMapId);
      if (this.saveId > 0)
        this.RemoveSubPart(this.saveId);
      if (this.newId > 0)
        this.RemoveSubPart(this.newId);
      if (this.textId > 0)
        this.RemoveSubPart(this.textId);
      if (this.text2id > 0)
        this.RemoveSubPart(this.text2id);
      if (this.text3id > 0)
        this.RemoveSubPart(this.text3id);
      if (this.rleft > 0)
        this.RemoveSubPart(this.rleft);
      if (this.rright > 0)
        this.RemoveSubPart(this.rright);
      if (this.rbottom > 0)
        this.RemoveSubPart(this.rbottom);
      if (this.rtop > 0)
        this.RemoveSubPart(this.rtop);
      if (this.aleft > 0)
        this.RemoveSubPart(this.aleft);
      if (this.aright > 0)
        this.RemoveSubPart(this.aright);
      if (this.abottom > 0)
        this.RemoveSubPart(this.abottom);
      if (this.atop > 0)
        this.RemoveSubPart(this.atop);
      if (this.loadLayer > 0)
        this.RemoveSubPart(this.loadLayer);
      if (this.removeLayer > 0)
        this.RemoveSubPart(this.removeLayer);
      if (this.removeLayerB > 0)
        this.RemoveSubPart(this.removeLayer);
      if (this.e1id > 0)
        this.RemoveSubPart(this.e1id);
      if (this.e2id > 0)
        this.RemoveSubPart(this.e2id);
      if (this.e3id > 0)
        this.RemoveSubPart(this.e3id);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      int y1 = 60;
      string tText1 = "We are using the ruleset : '" + this.game.Data.RuleSetName + "'. This cannot be changed.";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Ruleset", this.game.MarcFont1, num1 + 25, y1, Color.White);
      int num2 = y1 + 0;
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText1, 27, ref this.OwnBitmap, num1 + 10, num2, true, true);
      this.textId = this.AddSubPart(ref tsubpart1, num1 + 10, num2, 450, 108, 0);
      int y2 = num2 + 80;
      string tText2 = "Click to load or save a map file. Keep in mind you can only load a map using the ruleset";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "File Ops", this.game.MarcFont1, num1 + 25, y2, Color.White);
      int num3 = y2 + 0;
      SubPartClass tsubpart2 = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText2, 27, ref this.OwnBitmap, num1 + 10, num3, true, true);
      this.text2id = this.AddSubPart(ref tsubpart2, num1 + 10, num3, 450, 108, 0);
      int num4 = num3 + 70;
      SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Load Map", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadMapId = this.AddSubPart(ref tsubpart3, num1 + 25, num4, 140, 35, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Save Map", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 160), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.saveId = this.AddSubPart(ref tsubpart4, num1 + 25 + 160, num4, 140, 35, 1);
      SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("New Map", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 320), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.newId = this.AddSubPart(ref tsubpart5, num1 + 25 + 320, num4, 140, 35, 1);
      int y3 = num4 + 50;
      string tText3 = "These options allow you to crop or enlarge the current map.";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Map Dimensions", this.game.MarcFont1, num1 + 25, y3, Color.White);
      int num5 = y3 + 0;
      SubPartClass tsubpart6 = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText3, 27, ref this.OwnBitmap, num1 + 10, num5, true, true);
      this.text2id = this.AddSubPart(ref tsubpart6, num1 + 10, num5, 450, 108, 0);
      int num6 = num5 + 70;
      SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("Remove Left", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.rleft = this.AddSubPart(ref tsubpart7, num1 + 25, num6, 140, 35, 1);
      SubPartClass tsubpart8 = (SubPartClass) new TextButtonPartClass("Remove Top", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 160), bby: num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.rtop = this.AddSubPart(ref tsubpart8, num1 + 25 + 160, num6, 140, 35, 1);
      SubPartClass tsubpart9 = (SubPartClass) new TextButtonPartClass("Remove Right", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 320), bby: num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.rright = this.AddSubPart(ref tsubpart9, num1 + 25 + 320, num6, 140, 35, 1);
      SubPartClass tsubpart10 = (SubPartClass) new TextButtonPartClass("Remove Bottom", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 480), bby: num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.rbottom = this.AddSubPart(ref tsubpart10, num1 + 25 + 480, num6, 140, 35, 1);
      int num7 = num6 + 45;
      SubPartClass tsubpart11 = (SubPartClass) new TextButtonPartClass("Add Left", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num7, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.aleft = this.AddSubPart(ref tsubpart11, num1 + 25, num7, 140, 35, 1);
      SubPartClass tsubpart12 = (SubPartClass) new TextButtonPartClass("Add Top", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 160), bby: num7, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.atop = this.AddSubPart(ref tsubpart12, num1 + 25 + 160, num7, 140, 35, 1);
      SubPartClass tsubpart13 = (SubPartClass) new TextButtonPartClass("Add Right", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 320), bby: num7, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.aright = this.AddSubPart(ref tsubpart13, num1 + 25 + 320, num7, 140, 35, 1);
      SubPartClass tsubpart14 = (SubPartClass) new TextButtonPartClass("Add Bottom", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 480), bby: num7, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.abottom = this.AddSubPart(ref tsubpart14, num1 + 25 + 480, num7, 140, 35, 1);
      int y4 = num7 + 50;
      string tText4 = "You can load an image file to be transparently overlaid the map to help you trace coastlines, position cities, etc...";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Transparent overlay aid", this.game.MarcFont1, num1 + 25, y4, Color.White);
      int num8 = y4 + 0;
      SubPartClass tsubpart15 = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText4, 27, ref this.OwnBitmap, num1 + 10, num8, true, true);
      this.text3id = this.AddSubPart(ref tsubpart15, num1 + 10, num8, 450, 108, 0);
      int num9 = num8 + 100;
      SubPartClass tsubpart16 = (SubPartClass) new TextButtonPartClass("(Re)load overlay", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num9, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadLayer = this.AddSubPart(ref tsubpart16, num1 + 25, num9, 140, 35, 1);
      if (this.game.Data.PermanentOverlayUse)
      {
        tsubpart16 = (SubPartClass) new TextButtonPartClass("Remove overlay", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 160), bby: num9, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeLayer = this.AddSubPart(ref tsubpart16, num1 + 25 + 160, num9, 140, 35, 1);
      }
      else
      {
        tsubpart16 = (SubPartClass) new TextButtonPartClass("Remove overlay", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 160), bby: num9, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.removeLayerB = this.AddSubPart(ref tsubpart16, num1 + 25 + 160, num9, 140, 35, 1);
      }
      int y5 = num9 + 50;
      string mapDesigner = this.game.Data.MapDesigner;
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Designer", this.game.MarcFont1, num1 + 25, y5, Color.White);
      tsubpart16 = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, mapDesigner, 27, ref this.OwnBitmap, num1 + 10, y5 - 5, true, true);
      this.text3id = this.AddSubPart(ref tsubpart16, num1 + 10, y5 - 5, 250, 108, 0);
      tsubpart16 = (SubPartClass) new TextButtonPartClass("Change", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: (y5 + 70), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.e1id = this.AddSubPart(ref tsubpart16, num1 + 25, y5 + 70, 140, 35, 1);
      string tText5 = this.game.Data.MapVersion.ToString();
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Map version", this.game.MarcFont1, num1 + 25 + 250, y5, Color.White);
      tsubpart16 = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText5, 27, ref this.OwnBitmap, num1 + 10 + 250, y5 - 5, true, true);
      this.text3id = this.AddSubPart(ref tsubpart16, num1 + 10 + 250, y5 - 5, 250, 108, 0);
      tsubpart16 = (SubPartClass) new TextButtonPartClass("Change", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 250), bby: (y5 + 70), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.e3id = this.AddSubPart(ref tsubpart16, num1 + 25 + 250, y5 + 70, 140, 35, 1);
      string mapName = this.game.Data.MapName;
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Map name", this.game.MarcFont1, num1 + 25 + 500, y5, Color.White);
      tsubpart16 = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, mapName, 27, ref this.OwnBitmap, num1 + 10 + 500, y5 - 5, true, true);
      this.text3id = this.AddSubPart(ref tsubpart16, num1 + 10 + 500, y5 - 5, 550, 108, 0);
      tsubpart16 = (SubPartClass) new TextButtonPartClass("Change", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 500), bby: (y5 + 70), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.e2id = this.AddSubPart(ref tsubpart16, num1 + 25 + 500, y5 + 70, 140, 35, 1);
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
            if (num1 == this.e1id)
            {
              this.game.Data.MapDesigner = Interaction.InputBox("Give designer name", "Shadow Empire : Planetary Conquest", this.game.Data.MapDesigner);
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.e2id)
            {
              this.game.Data.MapName = Interaction.InputBox("Give map name", "Shadow Empire : Planetary Conquest", this.game.Data.MapName);
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.e3id)
            {
              int num2 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give version number", "Shadow Empire : Planetary Conquest", this.game.Data.MapVersion.ToString())));
              if (num2 > 0)
              {
                this.game.Data.MapVersion = num2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.aleft)
              {
                int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Add howmany columns of hexes? (2-100)", "Shadow Empire : Planetary Conquest")));
                if (tempint > 0 & tempint <= 100)
                {
                  if ((tempint + 2) % 2 > 0)
                  {
                    int num3 = (int) Interaction.MsgBox((object) "You can only add an EVEN number of columns", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    this.game.HandyFunctionsObj.AddXToMapLeft(tempint);
                    int num4 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.aright)
              {
                int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Add howmany columns of hexes? (1-100)", "Shadow Empire : Planetary Conquest")));
                if (tempint > 0 & tempint <= 100)
                {
                  this.game.HandyFunctionsObj.AddXToMap(tempint);
                  int num5 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.atop)
              {
                int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Add howmany rows of hexes? (1-100)", "Shadow Empire : Planetary Conquest")));
                if (tempint > 0 & tempint <= 100)
                {
                  this.game.HandyFunctionsObj.AddYToMapLeft(tempint);
                  int num6 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.abottom)
              {
                int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Add howmany rows of hexes? (1-100)", "Shadow Empire : Planetary Conquest")));
                if (tempint > 0 & tempint <= 100)
                {
                  this.game.HandyFunctionsObj.AddYToMap(tempint);
                  int num7 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.rleft)
              {
                int num8 = this.game.Data.MapObj[0].MapWidth + 1;
                if (num8 < 2)
                {
                  int num9 = (int) Interaction.MsgBox((object) "Not enough hexes for operation.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  return windowReturnClass;
                }
                int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Remove howmany columns of hexes? (2-" + ((int) Math.Round(Math.Ceiling((double) num8 / 2.0) * 2.0)).ToString() + ")", "Shadow Empire : Planetary Conquest")));
                if (tempint > 0 & tempint <= num8)
                {
                  if ((tempint + 2) % 2 > 0)
                  {
                    int num10 = (int) Interaction.MsgBox((object) "You can only add an EVEN number of columns", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    this.game.HandyFunctionsObj.RemoveXToMapLeft(tempint);
                    int num11 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.rright)
              {
                int num12 = this.game.Data.MapObj[0].MapWidth + 1;
                if (num12 < 2)
                {
                  int num13 = (int) Interaction.MsgBox((object) "Not enough hexes for operation.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  return windowReturnClass;
                }
                int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Remove howmany columns of hexes? (1-" + num12.ToString() + ")", "Shadow Empire : Planetary Conquest")));
                if (tempint > 0 & tempint <= num12)
                {
                  this.game.HandyFunctionsObj.RemoveXToMap(tempint);
                  int num14 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.rtop)
              {
                int num15 = this.game.Data.MapObj[0].MapHeight + 1;
                if (num15 < 2)
                {
                  int num16 = (int) Interaction.MsgBox((object) "Not enough hexes for operation.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  return windowReturnClass;
                }
                int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Remove howmany rows of hexes? (1-" + num15.ToString() + ")", "Shadow Empire : Planetary Conquest")));
                if (tempint > 0 & tempint <= 100)
                {
                  this.game.HandyFunctionsObj.RemoveYToMapLeft(tempint);
                  int num17 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.rbottom)
              {
                int num18 = this.game.Data.MapObj[0].MapHeight + 1;
                if (num18 < 2)
                {
                  int num19 = (int) Interaction.MsgBox((object) "Not enough hexes for operation.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  return windowReturnClass;
                }
                int tempint = (int) Math.Round(Conversion.Val(Interaction.InputBox("Remove howmany rows of hexes? (1-" + num18.ToString() + ")", "Shadow Empire : Planetary Conquest")));
                if (tempint > 0 & tempint <= 100)
                {
                  this.game.HandyFunctionsObj.RemoveYToMap(tempint);
                  int num20 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.loadLayer)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("JPG(*.jpg)|*.jpg|PNG(*.png)|*.png", "Pick a graphic... press cancel to delete the overlay graphic. graphic selected must be in graphics directory", this.game.AppPath + "graphics/", true);
                if (File.Exists(this.game.AppPath + "graphics/" + str))
                {
                  this.game.Data.PermanentOverlayName = str;
                  this.game.Data.PermanentOverlayUse = true;
                  this.game.Data.LoadSprites();
                }
                else
                {
                  int num21 = (int) Interaction.MsgBox((object) "Could not find graphic. Make sure its located inside the ''graphics'' directory", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.Data.PermanentOverlayUse = false;
                  this.game.Data.PermanentOverlayName = "systemgraphics/trans.bmp";
                  this.game.Data.LoadSprites();
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.removeLayer)
              {
                this.game.Data.PermanentOverlayUse = false;
                this.game.Data.PermanentOverlayName = "systemgraphics/trans.bmp";
                this.game.Data.LoadSprites();
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.newId)
              {
                string str1 = Interaction.InputBox("Give width of map in hexes (10-200)", "Shadow Empire : Planetary Conquest");
                int twidth = Operators.CompareString(Strings.Trim(str1), "", false) == 0 ? 0 : Conversions.ToInteger(str1);
                string str2 = Interaction.InputBox("Give height of map in hexes (10-200)", "Shadow Empire : Planetary Conquest");
                int theight = Operators.CompareString(Strings.Trim(str2), "", false) == 0 ? 0 : Conversions.ToInteger(str2);
                if (twidth < 10 | theight < 10 | twidth > 200 | theight > 200)
                {
                  int num22 = (int) Interaction.MsgBox((object) "Cannot comply. Width and Height must be between 10 and 200", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                  string filename = this.game.AppPath + this.game.ModScenarioDir + "/" + this.game.Data.MasterFile;
                  this.game.Data = new DataClass(twidth, theight);
                  this.game.HandyFunctionsObj.LoadMasterFile(filename);
                  BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                  this.game.Data.LoadGraphics((Form1) null);
                  this.game.Data.SimpleEditor = true;
                  this.game.EditObj.inSimpleMapEditor = true;
                  this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                  this.game.FormRef.Cursor = Cursors.Default;
                  this.game.SelectX = 0;
                  this.game.SelectY = 0;
                  this.game.CornerX = 0;
                  this.game.CornerY = 0;
                  int num23 = (int) Interaction.MsgBox((object) "Done", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  this.game.EditObj.MiddleWindow = true;
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
              else
              {
                if (num1 == this.loadMapId)
                {
                  string path = this.game.HandyFunctionsObj.LoadSomething("SE1 Map file(*.se1map)|*.se1map", "Pick a map to load...", this.game.AppPath + this.game.ModScenarioDir, false);
                  if (File.Exists(path))
                  {
                    this.game.EditObj.TempFileName = path;
                    this.game.EditObj.PopupValue = 18;
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass.AddCommand(5, 10);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  int num24 = (int) Interaction.MsgBox((object) "Could not find file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.saveId)
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
                  string str = this.game.HandyFunctionsObj.SaveSomething("SE1 Map file(*.se1map)|*.se1map", "Give save name...", tinitdir, false);
                  if (Strings.Len(str) < 2)
                  {
                    int num25 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                  else
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.Data.serialize(str);
                    this.game.HandyFunctionsObj.ZipFile(str);
                    windowReturnClass.SetFlag(true);
                    this.game.FormRef.Cursor = Cursors.Default;
                    this.game.Data.LoadGraphics(this.formref);
                    this.game.Data.PermanentOverlaySpriteID = -1;
                    this.game.Data.PermanentOverlayUse = false;
                    int num26 = (int) Interaction.MsgBox((object) "Completed & Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  }
                }
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
