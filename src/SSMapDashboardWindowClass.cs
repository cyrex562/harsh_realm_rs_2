// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SSMapDashboardWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SSMapDashboardWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int loadMapId;
    private int setdateid;
    private int exportid;
    private int exportid2;
    private int setdescriptid;
    private int setnameid;
    private int setdesignid;
    private int loadMapIdB;
    private int saveId;
    private int newId;
    private int saveid2;
    private int textId;
    private int text2id;
    private int text3id;
    private int text4id;
    private int e4id;
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

    public SSMapDashboardWindowClass(ref GameClass tGame)
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
      if (this.saveid2 > 0)
        this.RemoveSubPart(this.saveid2);
      if (this.newId > 0)
        this.RemoveSubPart(this.newId);
      if (this.textId > 0)
        this.RemoveSubPart(this.textId);
      if (this.text2id > 0)
        this.RemoveSubPart(this.text2id);
      if (this.text3id > 0)
        this.RemoveSubPart(this.text3id);
      if (this.text4id > 0)
        this.RemoveSubPart(this.text4id);
      if (this.e1id > 0)
        this.RemoveSubPart(this.e1id);
      if (this.e2id > 0)
        this.RemoveSubPart(this.e2id);
      if (this.e3id > 0)
        this.RemoveSubPart(this.e3id);
      if (this.e4id > 0)
        this.RemoveSubPart(this.e4id);
      if (this.exportid > 0)
        this.RemoveSubPart(this.exportid);
      if (this.exportid2 > 0)
        this.RemoveSubPart(this.exportid2);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      int y1 = 80;
      string tText1 = "This is the Story & Stratagem (S&S) editor. Welcome! Check the PDF S&S Guide on how to make a so called 'library' with this editor.";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "S&S Dashboard", this.game.MarcFont1, num1 + 25, y1, Color.White);
      int num2 = y1 + 0;
      SubPartClass tsubpart = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText1, 27, ref this.OwnBitmap, num1 + 10, num2, true, true);
      this.textId = this.AddSubPart(ref tsubpart, num1 + 10, num2, 450, 108, 0);
      int y2 = num2 + 120;
      string tText2 = "Click to load or save an S&S library file.";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "File Ops", this.game.MarcFont1, num1 + 25, y2, Color.White);
      int num3 = y2 + 0;
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText2, 27, ref this.OwnBitmap, num1 + 10, num3, true, true);
      this.text2id = this.AddSubPart(ref tsubpart, num1 + 10, num3, 450, 108, 0);
      int num4 = num3 + 70;
      tsubpart = (SubPartClass) new TextButtonPartClass("Load Lib", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadMapId = this.AddSubPart(ref tsubpart, num1 + 25, num4, 140, 35, 1);
      if (Strings.InStr(this.game.Data.LibraryObj[0].name.ToLower(), "default") > 0)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Save Lib", 140, "You cannot save if the word 'default' is present in the library name.", ref this.OwnBitmap, num1 + 25 + 160, num4, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.saveid2 = this.AddSubPart(ref tsubpart, num1 + 25 + 160, num4, 140, 35, 0);
      }
      else
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Save Lib", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 160), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.saveId = this.AddSubPart(ref tsubpart, num1 + 25 + 160, num4, 140, 35, 1);
      }
      tsubpart = (SubPartClass) new TextButtonPartClass("Clear Lib", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 320), bby: num4, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.newId = this.AddSubPart(ref tsubpart, num1 + 25 + 320, num4, 140, 35, 1);
      int y3 = num4 + 70;
      string creator = this.game.Data.LibraryObj[0].creator;
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Designer", this.game.MarcFont1, num1 + 25, y3, Color.White);
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, creator, 27, ref this.OwnBitmap, num1 + 10, y3 - 5, true, true);
      this.textId = this.AddSubPart(ref tsubpart, num1 + 10, y3 - 5, 250, 108, 0);
      tsubpart = (SubPartClass) new TextButtonPartClass("Change", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: (y3 + 70), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.e1id = this.AddSubPart(ref tsubpart, num1 + 25, y3 + 70, 140, 35, 1);
      string tText3 = this.game.Data.LibraryObj[0].version.ToString();
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Library Version", this.game.MarcFont1, num1 + 25 + 250, y3, Color.White);
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText3, 27, ref this.OwnBitmap, num1 + 10 + 250, y3 - 5, true, true);
      this.text2id = this.AddSubPart(ref tsubpart, num1 + 10 + 250, y3 - 5, 250, 108, 0);
      tsubpart = (SubPartClass) new TextButtonPartClass("Change", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 250), bby: (y3 + 70), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.e3id = this.AddSubPart(ref tsubpart, num1 + 25 + 250, y3 + 70, 140, 35, 1);
      string name = this.game.Data.LibraryObj[0].name;
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Library Name", this.game.MarcFont1, num1 + 25 + 500, y3, Color.White);
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, name, 27, ref this.OwnBitmap, num1 + 10 + 500, y3 - 5, true, true);
      this.text3id = this.AddSubPart(ref tsubpart, num1 + 10 + 500, y3 - 5, 550, 108, 0);
      tsubpart = (SubPartClass) new TextButtonPartClass("Change", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 500), bby: (y3 + 70), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.e2id = this.AddSubPart(ref tsubpart, num1 + 25 + 500, y3 + 70, 140, 35, 1);
      string tText4 = Strings.Left(this.game.Data.LibraryObj[0].information, 15);
      if (this.game.Data.LibraryObj[0].information.Length > 15)
        tText4 += "...";
      if (tText4.Length < 1)
        tText4 = "-Not yet given-";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Library Description", this.game.MarcFont1, num1 + 25 + 750, y3, Color.White);
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText4, 27, ref this.OwnBitmap, num1 + 10 + 750, y3 - 5, true, true);
      this.text4id = this.AddSubPart(ref tsubpart, num1 + 10 + 750, y3 - 5, 550, 108, 0);
      tsubpart = (SubPartClass) new TextButtonPartClass("Change", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25 + 750), bby: (y3 + 70), usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.e4id = this.AddSubPart(ref tsubpart, num1 + 25 + 750, y3 + 70, 140, 35, 1);
      int y4 = y3 + 160;
      string tText5 = "By using the export function you can create a se1zip file that can be easily imported by the end user of your Mod Library.";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Exporting", this.game.MarcFont1, num1 + 25, y4, Color.White);
      int num5 = y4 + 0;
      tsubpart = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText5, 27, ref this.OwnBitmap, num1 + 10, num5, true, true);
      this.textId = this.AddSubPart(ref tsubpart, num1 + 10, num5, 450, 108, 0);
      int num6 = num5 + 100;
      if (Strings.InStr(this.game.Data.LibraryObj[0].name.ToLower(), "default") > 0)
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Export Se1zip", 240, "You still need to rename your Mod Library", ref this.OwnBitmap, num1 + 25, num6, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.exportid2 = this.AddSubPart(ref tsubpart, num1 + 25, num6, 240, 35, 0);
      }
      else
      {
        tsubpart = (SubPartClass) new TextButtonPartClass("Export Se1zip", 240, tBackbitmap: (ref this.OwnBitmap), bbx: (num1 + 25), bby: num6, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.exportid = this.AddSubPart(ref tsubpart, num1 + 25, num6, 240, 35, 1);
      }
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
            if (num1 == this.e4id)
            {
              new Form2((Form) this.formref).Initialize(this.game.Data, 13, 0);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.e1id)
            {
              this.game.Data.LibraryObj[0].creator = Interaction.InputBox("Give designer name", "Shadow Empire : Planetary Conquest", this.game.Data.LibraryObj[0].creator);
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.e2id)
            {
              string str = Interaction.InputBox("Give library name", "Shadow Empire : Planetary Conquest", this.game.Data.LibraryObj[0].name);
              int num2 = 0;
              if (Strings.InStr(str.ToLower(), "default") > 0)
                num2 = 1;
              if (Strings.InStr(str.ToLower(), "random") > 0)
                num2 = 1;
              if (Strings.InStr(str.ToLower(), "system") > 0)
                num2 = 1;
              if (Strings.InStr(str.ToLower(), "shadow") > 0)
                num2 = 1;
              if (Strings.InStr(str.ToLower(), "big") > 0)
                num2 = 1;
              if (Strings.InStr(str.ToLower(), "small") > 0)
                num2 = 1;
              if (Strings.InStr(str.ToLower(), "se_") > 0)
                num2 = 1;
              if (Strings.InStr(str.ToLower(), "_v") > 0)
                num2 = 1;
              if (num2 == 0)
              {
                this.game.Data.LibraryObj[0].name = str;
              }
              else
              {
                int num3 = (int) Interaction.MsgBox((object) "You are not allowed to use the following reserved words: default, _v, random, system, shadow, big, small, se_", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.e3id)
            {
              int num4 = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give library version number", "Shadow Empire : Planetary Conquest", this.game.Data.LibraryObj[0].version.ToString())));
              if (num4 > 0)
              {
                this.game.Data.LibraryObj[0].version = num4;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.loadMapId)
              {
                string path = this.game.HandyFunctionsObj.LoadSomething("SE1 Event library(*.se1evlib)|*.se1evlib", "Pick Mod Library to load...", this.game.AppPath + this.game.ModScenarioDir, false);
                if (File.Exists(path))
                {
                  this.game.EditObj.LoadFileName = path;
                  this.game.EditObj.PopupValue = 19;
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.AddCommand(5, 10);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num5 = (int) Interaction.MsgBox((object) "Could not find file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.newId)
              {
                string path = this.game.AppPath + this.game.ModScenarioDir + "/default.se1evlib";
                if (File.Exists(path))
                {
                  this.game.EditObj.LoadFileName = path;
                  this.game.EditObj.PopupValue = 19;
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.AddCommand(5, 10);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                int num6 = (int) Interaction.MsgBox((object) "Could not find file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.exportid)
              {
                this.game.HandyFunctionsObj.ExportModLibraryEditor(this.game.Data.LibraryObj[0].name);
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
                string str1 = this.game.HandyFunctionsObj.SaveSomething("SE1 Event library(*.se1evlib)|*.se1evlib", "Give save name...", tinitdir, false);
                if (Strings.Len(str1) < 2)
                {
                  int num7 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  this.game.Data.serialize(str1);
                  this.game.HandyFunctionsObj.ZipFile(str1);
                  windowReturnClass.SetFlag(true);
                  this.game.FormRef.Cursor = Cursors.Default;
                  this.game.Data.LoadGraphics(this.formref);
                  this.game.Data.PermanentOverlaySpriteID = -1;
                  this.game.Data.PermanentOverlayUse = false;
                  string path1 = this.game.AppPath + "graphics\\" + this.game.Data.LibraryObj[0].name.ToLower();
                  if (!Directory.Exists(path1))
                    Directory.CreateDirectory(path1);
                  string path2 = this.game.AppPath + "graphics\\" + this.game.Data.LibraryObj[0].name.ToLower() + "BIG";
                  if (!Directory.Exists(path2))
                    Directory.CreateDirectory(path2);
                  string path3 = this.game.AppPath + "graphics\\" + this.game.Data.LibraryObj[0].name.ToLower() + "SMALL";
                  if (!Directory.Exists(path3))
                    Directory.CreateDirectory(path3);
                  string str2 = this.game.AppPath + "graphics\\";
                  int num8 = (int) Interaction.MsgBox((object) "Completed & Saved", Title: ((object) "Shadow Empire : Planetary Conquest"));
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
