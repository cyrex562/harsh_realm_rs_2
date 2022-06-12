// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SimpleMapReplacementsWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class SimpleMapReplacementsWindowClass : WindowClass
  {
    private int listId;
    private ListClass listObj;
    private int detailnr;
    private int tabnr;
    private int e1id;
    private int e2id;
    private int e3id;
    private int e4id;
    private int t1id;
    private int t2id;
    private int t3id;
    private int t4id;
    private int t5id;
    private int e1idb;
    private int e2idb;
    private int e3idb;
    private int e4idb;
    private int t1idb;
    private int t2idb;
    private int t3idb;
    private int t4idb;
    private int t5idb;
    private int text1id;
    private int text2id;
    private int text3id;
    private int[] land;
    private int[] road;
    private int[] river;
    private int[] loctype;

    public SimpleMapReplacementsWindowClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Replacements")
    {
      this.detailnr = -1;
      this.tabnr = 1;
      this.Counters();
      this.DoStuff();
    }

    public void PopUpRefresh()
    {
    }

    public override void DoRefresh()
    {
      this.Counters();
      this.detailnr = -1;
      this.DoStuff();
    }

    public void Counters()
    {
      this.land = new int[this.game.Data.LandscapeTypeCounter + 1];
      this.road = new int[this.game.Data.RoadTypeCounter + 1];
      this.river = new int[this.game.Data.RiverTypeCounter + 1];
      this.loctype = new int[this.game.Data.LocTypeCounter + 1];
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      for (int index1 = 0; index1 <= mapWidth; ++index1)
      {
        int mapHeight = this.game.Data.MapObj[0].MapHeight;
        for (int index2 = 0; index2 <= mapHeight; ++index2)
        {
          if (this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType > -1)
          {
            int[] land = this.land;
            int[] numArray = land;
            int landscapeType = this.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType;
            int index3 = landscapeType;
            int num = land[landscapeType] + 1;
            numArray[index3] = num;
          }
          int index4 = 0;
          do
          {
            if (this.game.Data.MapObj[0].HexObj[index1, index2].RoadType[index4] > -1)
            {
              int[] road = this.road;
              int[] numArray1 = road;
              int[] roadType = this.game.Data.MapObj[0].HexObj[index1, index2].RoadType;
              int[] numArray2 = roadType;
              int index5 = index4;
              int index6 = index5;
              int index7 = numArray2[index6];
              int num = road[roadType[index5]] + 1;
              numArray1[index7] = num;
            }
            if (this.game.Data.MapObj[0].HexObj[index1, index2].RiverType[index4] > -1)
            {
              int[] river = this.river;
              int[] numArray3 = river;
              int[] riverType = this.game.Data.MapObj[0].HexObj[index1, index2].RiverType;
              int[] numArray4 = riverType;
              int index8 = index4;
              int index9 = index8;
              int index10 = numArray4[index9];
              int num = river[riverType[index8]] + 1;
              numArray3[index10] = num;
            }
            ++index4;
          }
          while (index4 <= 5);
          if (this.game.Data.MapObj[0].HexObj[index1, index2].Location > -1 && this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index1, index2].Location].Type > -1)
          {
            int[] loctype = this.loctype;
            int[] numArray = loctype;
            int type = this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[index1, index2].Location].Type;
            int index11 = type;
            int num = loctype[type] + 1;
            numArray[index11] = num;
          }
        }
      }
    }

    public void DoStuff()
    {
      int val1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      if (this.listId > 0)
        this.RemoveSubPart(this.listId);
      if (this.e1id > 0)
        this.RemoveSubPart(this.e1id);
      if (this.e2id > 0)
        this.RemoveSubPart(this.e2id);
      if (this.e3id > 0)
        this.RemoveSubPart(this.e3id);
      if (this.e4id > 0)
        this.RemoveSubPart(this.e4id);
      if (this.t1id > 0)
        this.RemoveSubPart(this.t1id);
      if (this.t2id > 0)
        this.RemoveSubPart(this.t2id);
      if (this.t3id > 0)
        this.RemoveSubPart(this.t3id);
      if (this.t4id > 0)
        this.RemoveSubPart(this.t4id);
      if (this.t5id > 0)
        this.RemoveSubPart(this.t5id);
      if (this.e1idb > 0)
        this.RemoveSubPart(this.e1idb);
      if (this.e2idb > 0)
        this.RemoveSubPart(this.e2idb);
      if (this.e3idb > 0)
        this.RemoveSubPart(this.e3idb);
      if (this.e4idb > 0)
        this.RemoveSubPart(this.e4idb);
      if (this.t1idb > 0)
        this.RemoveSubPart(this.t1idb);
      if (this.t2idb > 0)
        this.RemoveSubPart(this.t2idb);
      if (this.t3idb > 0)
        this.RemoveSubPart(this.t3idb);
      if (this.t4idb > 0)
        this.RemoveSubPart(this.t4idb);
      if (this.t5idb > 0)
        this.RemoveSubPart(this.t5idb);
      if (this.text1id > 0)
        this.RemoveSubPart(this.text1id);
      if (this.text2id > 0)
        this.RemoveSubPart(this.text2id);
      if (this.text3id > 0)
        this.RemoveSubPart(this.text3id);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      int num1 = 60;
      if (this.tabnr == 1)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Landscapes", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25), bby: num1, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t1idb = this.AddSubPart(ref tsubpart, val1 + 25, num1 + 70, 140, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Landscapes", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25), bby: num1, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t1id = this.AddSubPart(ref tsubpart, val1 + 25, num1 + 70, 140, 35, 1);
      }
      if (this.tabnr == 2)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Road Types", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25 + 320), bby: num1, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t2idb = this.AddSubPart(ref tsubpart, val1 + 25 + 320, num1 + 70, 140, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Road Types", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25 + 320), bby: num1, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t2id = this.AddSubPart(ref tsubpart, val1 + 25 + 320, num1 + 70, 140, 35, 1);
      }
      if (this.tabnr == 3)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("River Types", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25 + 160), bby: num1, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t3idb = this.AddSubPart(ref tsubpart, val1 + 25 + 160, num1 + 70, 140, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("River Types", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25 + 160), bby: num1, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t3id = this.AddSubPart(ref tsubpart, val1 + 25 + 160, num1 + 70, 140, 35, 1);
      }
      if (this.tabnr == 5)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Loc. Types", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25 + 480), bby: num1, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t5idb = this.AddSubPart(ref tsubpart, val1 + 25 + 480, num1 + 70, 140, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Loc. Types", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25 + 480), bby: num1, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t5id = this.AddSubPart(ref tsubpart, val1 + 25 + 480, num1 + 70, 140, 35, 1);
      }
      if (this.tabnr == 4)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Operations", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25 + 640), bby: num1, tinactive: true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t4idb = this.AddSubPart(ref tsubpart, val1 + 25 + 640, num1 + 70, 140, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Operations", 140, tBackbitmap: (ref this.OwnBitmap), bbx: (val1 + 25 + 640), bby: num1, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        this.t4id = this.AddSubPart(ref tsubpart, val1 + 25 + 640, num1 + 70, 140, 35, 1);
      }
      if (this.tabnr == 1)
        DrawMod.DrawTextColouredMarc(ref objgraphics, "List of landscape types", this.game.MarcFont1, val1 + 25, num1, Color.White);
      if (this.tabnr == 2)
        DrawMod.DrawTextColouredMarc(ref objgraphics, "List of road types", this.game.MarcFont1, val1 + 25, num1, Color.White);
      if (this.tabnr == 3)
        DrawMod.DrawTextColouredMarc(ref objgraphics, "List of river types", this.game.MarcFont1, val1 + 25, num1, Color.White);
      if (this.tabnr == 4)
        DrawMod.DrawTextColouredMarc(ref objgraphics, "Operations", this.game.MarcFont1, val1 + 25, num1, Color.White);
      if (this.tabnr == 5)
        DrawMod.DrawTextColouredMarc(ref objgraphics, "List of location types", this.game.MarcFont1, val1 + 25, num1, Color.White);
      int num2 = num1 + 120;
      if (this.tabnr <= 3 | this.tabnr == 5)
      {
        this.listObj = new ListClass();
        int num3 = -1;
        int tlistselect = -1;
        if (this.tabnr == 1)
        {
          int landscapeTypeCounter = this.game.Data.LandscapeTypeCounter;
          for (int tdata = 0; tdata <= landscapeTypeCounter; ++tdata)
          {
            if (this.land[tdata] > 0)
            {
              ++num3;
              this.listObj.add(this.game.Data.LandscapeTypeObj[tdata].Name, tdata, this.land[tdata].ToString());
              if (this.detailnr == -1)
                this.detailnr = tdata;
              if (this.detailnr == tdata)
                tlistselect = num3;
            }
          }
        }
        if (this.tabnr == 2)
        {
          int roadTypeCounter = this.game.Data.RoadTypeCounter;
          for (int tdata = 0; tdata <= roadTypeCounter; ++tdata)
          {
            if (this.road[tdata] > 0)
            {
              ++num3;
              this.listObj.add(this.game.Data.RoadTypeObj[tdata].Name, tdata, this.road[tdata].ToString());
              if (this.detailnr == -1)
                this.detailnr = tdata;
              if (this.detailnr == tdata)
                tlistselect = num3;
            }
          }
        }
        if (this.tabnr == 3)
        {
          int riverTypeCounter = this.game.Data.RiverTypeCounter;
          for (int tdata = 0; tdata <= riverTypeCounter; ++tdata)
          {
            if (this.river[tdata] > 0)
            {
              ++num3;
              this.listObj.add(this.game.Data.RiverTypeObj[tdata].Name, tdata, this.river[tdata].ToString());
              if (this.detailnr == -1)
                this.detailnr = tdata;
              if (this.detailnr == tdata)
                tlistselect = num3;
            }
          }
        }
        if (this.tabnr == 5)
        {
          int locTypeCounter = this.game.Data.LocTypeCounter;
          for (int tdata = 0; tdata <= locTypeCounter; ++tdata)
          {
            if (this.loctype[tdata] > 0)
            {
              ++num3;
              this.listObj.add(this.game.Data.LocTypeObj[tdata].Name, tdata, this.loctype[tdata].ToString());
              if (this.detailnr == -1)
                this.detailnr = tdata;
              if (this.detailnr == tdata)
                tlistselect = num3;
            }
          }
        }
        SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(this.listObj, 18, 500 + Math.Max(0, val1 - 50), tlistselect, this.game, true, "Checklist", false, tShowPair: true, tValueWidth: ((int) Math.Round(260.0 + (double) val1 * 0.4)), tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (10 + Math.Min(val1, 50)), bby: num2, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
        this.listId = this.AddSubPart(ref tsubpart1, 10 + Math.Min(val1, 50), num2, 540 + Math.Max(0, val1 - 50), 504, 0);
        if (this.detailnr > -1)
        {
          SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Replace", 140, "Click to select what other type to replace it with", ref this.OwnBitmap, val1 + 25 + 550, num2, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.e1id = this.AddSubPart(ref tsubpart2, val1 + 25 + 550, num2 + 50, 140, 35, 1);
        }
        else
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Replace", 140, "Please select an item in the list", ref this.OwnBitmap, val1 + 25 + 550, num2, true, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.e1idb = this.AddSubPart(ref tsubpart3, val1 + 25 + 550, num2 + 50, 140, 35, 1);
        }
      }
      if (this.tabnr != 4)
        return;
      SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Reset Location Type Gfx", 340, "Reset the Landscape Type and Sprite of each Hex with Location to its default", ref this.OwnBitmap, val1 + 25, num2, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.e4id = this.AddSubPart(ref tsubpart4, val1 + 25, num2 + 50, 340, 35, 1);
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
            if (num1 == this.listId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              if (num2 > -1 & this.detailnr != num2)
              {
                this.detailnr = num2;
                this.DoStuff();
              }
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.t1id)
            {
              this.tabnr = 1;
              this.detailnr = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.t2id)
            {
              this.tabnr = 2;
              this.detailnr = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.t3id)
            {
              this.tabnr = 3;
              this.detailnr = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.t4id)
            {
              this.tabnr = 4;
              this.detailnr = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.t5id)
            {
              this.tabnr = 5;
              this.detailnr = -1;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.e1id)
            {
              Form3 form3 = new Form3((Form) this.formref);
              if (this.tabnr == 1)
                form3.Initialize(this.game.Data, 147, this.detailnr, tGame: this.game);
              if (this.tabnr == 2)
                form3.Initialize(this.game.Data, 148, this.detailnr, tGame: this.game);
              if (this.tabnr == 3)
                form3.Initialize(this.game.Data, 149, this.detailnr, tGame: this.game);
              if (this.tabnr == 5)
                form3.Initialize(this.game.Data, 151, this.detailnr, tGame: this.game);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.e4id)
            {
              int mapWidth = this.game.Data.MapObj[0].MapWidth;
              for (int index2 = 0; index2 <= mapWidth; ++index2)
              {
                int mapHeight = this.game.Data.MapObj[0].MapHeight;
                for (int index3 = 0; index3 <= mapHeight; ++index3)
                {
                  int location = this.game.Data.MapObj[0].HexObj[index2, index3].Location;
                  if (location > -1)
                  {
                    int type = this.game.Data.LocObj[location].Type;
                    if (this.game.Data.LocTypeObj[type].OverdrawLTNr > -1)
                    {
                      this.game.Data.MapObj[0].HexObj[index2, index3].LandscapeType = this.game.Data.LocTypeObj[type].OverdrawLTNr;
                      this.game.Data.MapObj[0].HexObj[index2, index3].SpriteNr = this.game.Data.LocTypeObj[type].OverdrawSpriteNr;
                    }
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
