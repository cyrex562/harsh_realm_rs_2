// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SSEventPicsClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;

namespace WindowsApplication1
{
  public class SSEventPicsClass : WindowClass
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
    private int saveid2;
    private int textId;
    private int text2id;
    private int text3id;
    private int addId;
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
    private int removeId;
    private int loadId;
    private int picId;

    public SSEventPicsClass(ref GameClass tGame)
      : base(ref tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Event Pics")
    {
      this.detailnr = -1;
      this.DoStuff();
    }

    public void PopUpRefresh() => this.DoStuff();

    public void DoStuff()
    {
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      if (this.textId > 0)
      {
        this.RemoveSubPart(this.textId);
        this.textId = 0;
      }
      if (this.text2id > 0)
      {
        this.RemoveSubPart(this.text2id);
        this.text2id = 0;
      }
      if (this.addId > 0)
      {
        this.RemoveSubPart(this.addId);
        this.addId = 0;
      }
      if (this.loadId > 0)
      {
        this.RemoveSubPart(this.loadId);
        this.loadId = 0;
      }
      if (this.removeId > 0)
      {
        this.RemoveSubPart(this.removeId);
        this.removeId = 0;
      }
      if (this.listId > 0)
      {
        this.RemoveSubPart(this.listId);
        this.listId = 0;
      }
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      this.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      int y1 = 60;
      string tText = "Event Pics are images that exist in only 1 size. They are used for example by Stratagems. ";
      DrawMod.DrawTextColouredMarc(ref objgraphics, "Event Pics", this.game.MarcFont1, num1 + 25, y1, Color.White);
      int num2 = y1 + 0;
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 850, 4, this.game.MarcFont3, tText, 27, ref this.OwnBitmap, num1 + 10, num2, true, true);
      this.textId = this.AddSubPart(ref tsubpart1, num1 + 10, num2, 450, 108, 0);
      int y2 = num2 + 70;
      int num3 = y2;
      int x1 = num1 + 25;
      this.listObj = new ListClass();
      int tlistselect1;
      if (this.game.Data.EventPicCounter > -1)
      {
        tlistselect1 = -1;
        int num4 = -1;
        int eventPicCounter = this.game.Data.EventPicCounter;
        for (int tdata = 0; tdata <= eventPicCounter; ++tdata)
        {
          int num5 = 0;
          if (this.game.Data.eventPicLibId[tdata].libSlot == 0)
            num5 = 1;
          if (num5 == 1)
          {
            ++num4;
            this.listObj.add(Conversion.Str((object) this.game.Data.eventPicLibId[tdata].id) + ") " + this.game.Data.EventPicName[tdata], tdata);
            if (this.detailnr == tdata)
              tlistselect1 = num4;
          }
        }
      }
      int num6 = 0;
      if (this.game.ScreenHeight > 800)
        num6 = (int) Math.Round((double) (this.game.ScreenHeight - 800) / 20.0);
      if (this.detailnr > this.game.Data.EventPicCounter)
        this.detailnr = -1;
      if (this.listId > 0)
      {
        this.SubPartList[this.SubpartNr(this.listId)].Refresh(this.listObj, tlistselect1);
        this.SubPartFlag[this.SubpartNr(this.listId)] = true;
      }
      else
      {
        ListClass listObj = this.listObj;
        int tlistsize = 12 + num6;
        int tlistselect2 = tlistselect1;
        GameClass game = this.game;
        ref Bitmap local1 = ref this.OwnBitmap;
        int bbx = x1;
        int bby = y2;
        Font font = (Font) null;
        ref Font local2 = ref font;
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(listObj, tlistsize, 400, tlistselect2, game, tHeader: "Event Pics", tbackbitmap: (ref local1), bbx: bbx, bby: bby, overruleFont: (ref local2), overruleItemSize: 20);
        this.listId = this.AddSubPart(ref tsubpart2, x1, y2, 400, (15 + num6) * 20, 0);
      }
      int num7 = num1 + 480;
      int num8 = num3 + 40;
      SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Add Event Pic", 240, tBackbitmap: (ref this.OwnBitmap), bbx: num7, bby: num8, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.addId = this.AddSubPart(ref tsubpart3, num7, num8, 240, 35, 1);
      if (this.detailnr <= -1)
        return;
      int num9 = num8 + 50;
      SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Remove Event Pic", 240, tBackbitmap: (ref this.OwnBitmap), bbx: num7, bby: num9, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.removeId = this.AddSubPart(ref tsubpart4, num7, num9, 240, 35, 1);
      int num10 = num9 + 50;
      SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Replace Event Pic", 240, tBackbitmap: (ref this.OwnBitmap), bbx: num7, bby: num10, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.loadId = this.AddSubPart(ref tsubpart5, num7, num10, 240, 35, 1);
      int num11 = num10 + 50;
      int nr = this.game.Data.EventPicNr[this.detailnr];
      int num12 = BitmapStore.GetWidth(nr);
      int num13 = BitmapStore.Getheight(nr);
      if (num12 > 500)
      {
        num13 = (int) Math.Round((double) (num13 * 500) / (double) num12);
        num12 = 500;
      }
      ref Graphics local3 = ref objgraphics;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[this.detailnr]);
      ref Bitmap local4 = ref bitmap;
      int x2 = num7;
      int y3 = num11;
      int w = num12;
      int h = num13;
      DrawMod.DrawScaled(ref local3, ref local4, x2, y3, w, h, true);
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
            if (num1 != this.e1id)
            {
              if (num1 == this.listId)
              {
                int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                this.SubPartFlag[index1] = true;
                this.detailnr = num2;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.addId)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Event Picture:", this.game.AppPath + "graphics\\", true);
                if (File.Exists(this.game.AppPath + "graphics/" + filename))
                {
                  this.game.Data.AddEventPic(filename);
                  this.detailnr = this.game.Data.EventPicCounter;
                  this.game.Data.eventPicLibId[this.detailnr].libSlot = 0;
                  int num3 = 0;
                  int num4 = this.detailnr - 1;
                  for (int index2 = 0; index2 <= num4; ++index2)
                  {
                    if (this.game.Data.eventPicLibId[index2].libSlot == 0 && this.game.Data.eventPicLibId[index2].id > num3)
                      num3 = this.game.Data.eventPicLibId[index2].id;
                  }
                  this.game.Data.eventPicLibId[this.detailnr].id = num3 + 1;
                }
                else
                {
                  int num5 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.removeId)
              {
                this.game.Data.RemoveEventPic(this.detailnr);
                this.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.loadId)
              {
                string filename = this.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Event Picture:", this.game.AppPath + "graphics\\", true);
                if (File.Exists(this.game.AppPath + "graphics/" + filename))
                {
                  this.game.Data.EventPicReplaceprite(this.detailnr, filename);
                }
                else
                {
                  int num6 = (int) Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to this.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
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
