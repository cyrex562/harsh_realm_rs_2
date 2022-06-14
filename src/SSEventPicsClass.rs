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
  pub class SSEventPicsClass : WindowClass
  {
     int listId;
     ListClass listObj;
     int loadMapId;
     int setdateid;
     int exportid;
     int setdescriptid;
     int setnameid;
     int setdesignid;
     int loadMapIdB;
     int saveId;
     int newId;
     int saveid2;
     int textId;
     int text2id;
     int text3id;
     int addId;
     int detailnr;
     int currentStep;
     int loadLayer;
     int removeLayer;
     int removeLayerB;
     int rleft;
     int rtop;
     int rbottom;
     int rright;
     int aleft;
     int atop;
     int abottom;
     int aright;
     int e1id;
     int e2id;
     int e3id;
     int removeId;
     int loadId;
     int picId;

    pub SSEventPicsClass( GameClass tGame)
      : base( tGame, tGame.ScreenWidth, tGame.ScreenHeight - 50, 9, tDoBorders: 1, tHeaderString: "Event Pics")
    {
      self.detailnr = -1;
      self.DoStuff();
    }

    pub void PopUpRefresh() => self.DoStuff();

    pub void DoStuff()
    {
      let mut num1: i32 =  Math.Round((double) (self.game.ScreenWidth - 1024) / 2.0);
      if (self.textId > 0)
      {
        self.RemoveSubPart(self.textId);
        self.textId = 0;
      }
      if (self.text2id > 0)
      {
        self.RemoveSubPart(self.text2id);
        self.text2id = 0;
      }
      if (self.addId > 0)
      {
        self.RemoveSubPart(self.addId);
        self.addId = 0;
      }
      if (self.loadId > 0)
      {
        self.RemoveSubPart(self.loadId);
        self.loadId = 0;
      }
      if (self.removeId > 0)
      {
        self.RemoveSubPart(self.removeId);
        self.removeId = 0;
      }
      if (self.listId > 0)
      {
        self.RemoveSubPart(self.listId);
        self.listId = 0;
      }
      Graphics objgraphics = Graphics.FromImage((Image) self.OwnBitmap);
      objgraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objgraphics.TextContrast = 1;
      self.NewBackGroundAndClearAll(DrawMod.TGame.ScreenWidth, DrawMod.TGame.ScreenHeight - 50, -1);
      let mut y1: i32 = 60;
      tText: String = "Event Pics are images that exist in only 1 size. They are used for example by Stratagems. ";
      DrawMod.DrawTextColouredMarc( objgraphics, "Event Pics", self.game.MarcFont1, num1 + 25, y1, Color.White);
      let mut num2: i32 = y1 + 0;
      let mut tsubpart1: SubPartClass =  new TextAreaClass2(self.game, 850, 4, self.game.MarcFont3, tText, 27,  self.OwnBitmap, num1 + 10, num2, true, true);
      self.textId = self.AddSubPart( tsubpart1, num1 + 10, num2, 450, 108, 0);
      let mut y2: i32 = num2 + 70;
      let mut num3: i32 = y2;
      let mut x1: i32 = num1 + 25;
      self.listObj = ListClass::new();
      int tlistselect1;
      if (self.game.Data.EventPicCounter > -1)
      {
        tlistselect1 = -1;
        let mut num4: i32 = -1;
        let mut eventPicCounter: i32 = self.game.Data.EventPicCounter;
        for (let mut tdata: i32 = 0; tdata <= eventPicCounter; tdata += 1)
        {
          let mut num5: i32 = 0;
          if (self.game.Data.eventPicLibId[tdata].libSlot == 0)
            num5 = 1;
          if (num5 == 1)
          {
            num4 += 1;
            self.listObj.add(Conversion.Str((object) self.game.Data.eventPicLibId[tdata].id) + ") " + self.game.Data.EventPicName[tdata], tdata);
            if (self.detailnr == tdata)
              tlistselect1 = num4;
          }
        }
      }
      let mut num6: i32 = 0;
      if (self.game.ScreenHeight > 800)
        num6 =  Math.Round((double) (self.game.ScreenHeight - 800) / 20.0);
      if (self.detailnr > self.game.Data.EventPicCounter)
        self.detailnr = -1;
      if (self.listId > 0)
      {
        self.SubPartList[self.SubpartNr(self.listId)].Refresh(self.listObj, tlistselect1);
        self.SubPartFlag[self.SubpartNr(self.listId)] = true;
      }
      else
      {
        ListClass listObj = self.listObj;
        let mut tlistsize: i32 = 12 + num6;
        let mut tlistselect2: i32 = tlistselect1;
        let mut game: GameClass = self.game;
         Bitmap local1 =  self.OwnBitmap;
        let mut bbx: i32 = x1;
        let mut bby: i32 = y2;
        Font font =  null;
         Font local2 =  font;
        let mut tsubpart2: SubPartClass =  new ListSubPartClass(listObj, tlistsize, 400, tlistselect2, game, tHeader: "Event Pics", tbackbitmap: ( local1), bbx: bbx, bby: bby, overruleFont: ( local2), overruleItemSize: 20);
        self.listId = self.AddSubPart( tsubpart2, x1, y2, 400, (15 + num6) * 20, 0);
      }
      let mut num7: i32 = num1 + 480;
      let mut num8: i32 = num3 + 40;
      let mut tsubpart3: SubPartClass =  new TextButtonPartClass("Add Event Pic", 240, tBackbitmap: ( self.OwnBitmap), bbx: num7, bby: num8, usefont: self.game.MarcFont3, useshadow: true, tMarcStyle: true);
      self.addId = self.AddSubPart( tsubpart3, num7, num8, 240, 35, 1);
      if (self.detailnr <= -1)
        return;
      let mut num9: i32 = num8 + 50;
      let mut tsubpart4: SubPartClass =  new TextButtonPartClass("Remove Event Pic", 240, tBackbitmap: ( self.OwnBitmap), bbx: num7, bby: num9, usefont: self.game.MarcFont3, useshadow: true, tMarcStyle: true);
      self.removeId = self.AddSubPart( tsubpart4, num7, num9, 240, 35, 1);
      let mut num10: i32 = num9 + 50;
      let mut tsubpart5: SubPartClass =  new TextButtonPartClass("Replace Event Pic", 240, tBackbitmap: ( self.OwnBitmap), bbx: num7, bby: num10, usefont: self.game.MarcFont3, useshadow: true, tMarcStyle: true);
      self.loadId = self.AddSubPart( tsubpart5, num7, num10, 240, 35, 1);
      let mut num11: i32 = num10 + 50;
      let mut nr: i32 = self.game.Data.EventPicNr[self.detailnr];
      let mut num12: i32 = BitmapStore.GetWidth(nr);
      let mut num13: i32 = BitmapStore.Getheight(nr);
      if (num12 > 500)
      {
        num13 =  Math.Round((double) (num13 * 500) / (double) num12);
        num12 = 500;
      }
       let mut local3: &Graphics = &objgraphics;
      Bitmap bitmap = BitmapStore.GetBitmap(self.game.Data.EventPicNr[self.detailnr]);
       let mut local4: &Bitmap = &bitmap;
      let mut x2: i32 = num7;
      let mut y3: i32 = num11;
      let mut w: i32 = num12;
      let mut h: i32 = num13;
      DrawMod.DrawScaled( local3,  local4, x2, y3, w, h, true);
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (self.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = self.SubPartCounter;
        for (let mut index1: i32 = 0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > self.SubPartX[index1] & x < self.SubPartX[index1] + self.SubPartW[index1] && y > self.SubPartY[index1] & y < self.SubPartY[index1] + self.SubPartH[index1])
          {
            let mut num1: i32 = self.SubPartID[index1];
            if (num1 != self.e1id)
            {
              if (num1 == self.listId)
              {
                let mut num2: i32 = self.SubPartList[index1].Click(x - self.SubPartX[index1], y - self.SubPartY[index1]);
                self.SubPartFlag[index1] = true;
                self.detailnr = num2;
                self.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == self.addId)
              {
                filename: String = self.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Event Picture:", self.game.AppPath + "graphics\\", true);
                if (File.Exists(self.game.AppPath + "graphics/" + filename))
                {
                  self.game.Data.AddEventPic(filename);
                  self.detailnr = self.game.Data.EventPicCounter;
                  self.game.Data.eventPicLibId[self.detailnr].libSlot = 0;
                  let mut num3: i32 = 0;
                  let mut num4: i32 = self.detailnr - 1;
                  for (let mut index2: i32 = 0; index2 <= num4; index2 += 1)
                  {
                    if (self.game.Data.eventPicLibId[index2].libSlot == 0 && self.game.Data.eventPicLibId[index2].id > num3)
                      num3 = self.game.Data.eventPicLibId[index2].id;
                  }
                  self.game.Data.eventPicLibId[self.detailnr].id = num3 + 1;
                }
                else
                {
                  let mut num5: i32 =  Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to self.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                self.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == self.removeId)
              {
                self.game.Data.RemoveEventPic(self.detailnr);
                self.DoStuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == self.loadId)
              {
                filename: String = self.game.HandyFunctionsObj.LoadSomething("Png|*.png|Bitmaps|*.bmp|Jpegs|*.jpg", "Select File For New Event Picture:", self.game.AppPath + "graphics\\", true);
                if (File.Exists(self.game.AppPath + "graphics/" + filename))
                {
                  self.game.Data.EventPicReplaceprite(self.detailnr, filename);
                }
                else
                {
                  let mut num6: i32 =  Interaction.MsgBox((object) "File does not exist. Operation ordered is canceled due to self.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                self.DoStuff();
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
