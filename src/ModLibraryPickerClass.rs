// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ModLibraryPickerClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsApplication1
{
  pub class ModLibraryPickerClass : WindowClass
  {
     int cancelid;
     int Info1Id;
     int info2id;
     string ShowString;
     DateTime ShowTime;
     int w;
     int h;
     int CurrentView;
     int detailnr;
     int BNameId;
     int BNameTextId;
     int B1Id;
     int B1TextId;
     int saveid;
     int quitid;
     int B2Id;
     int B2TextId;
     int B3Id;
     int B3TextId;
     int B4Id;
     int B4TextId;
     int B5Id;
     int B5TextId;
     int B6Id;
     int B6TextId;
     int B7Id;
     int B7TextId;
     int B8Id;
     int B8TextId;
     int B9Id;
     int B9TextId;
     int B10Id;
     int B10TextId;
     int B11Id;
     int B11TextId;
     int B12Id;
     int B12TextId;
     int B13Id;
     int B13TextId;
     int B14Id;
     int B14TextId;
     int B15Id;
     int B15TextId;
     int B16Id;
     int B16TextId;
     int slider1id;
     int slider2id;
     int list1Id;
     ListClass list1obj;

    pub ModLibraryPickerClass( GameClass tGame)
      : base( tGame, 1000, 700, 8)
    {
      this.detailnr = -1;
      this.View();
    }

    pub void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.SubPartList[index].DescriptInfo(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
            {
              this.game.EditObj.TipButton = true;
              this.game.EditObj.TipTitle = "";
              this.game.EditObj.TipText = this.SubPartList[index].Descript;
              return;
            }
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; index += 1)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          break;
        }
      }
    }

    pub void View()
    {
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
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
      if (this.B16Id > 0)
        this.RemoveSubPart(this.B16Id);
      if (this.B16TextId > 0)
        this.RemoveSubPart(this.B16TextId);
      if (this.slider1id > 0)
      {
        this.RemoveSubPart(this.slider1id);
        this.slider1id = 0;
      }
      if (this.slider2id > 0)
      {
        this.RemoveSubPart(this.slider2id);
        this.slider2id = 0;
      }
      this.ClearMouse();
      this.NewBackGroundAndClearAll(1000, 700, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      DrawMod.DrawMessFrame( this.OwnBitmap,  graphics, 0, 0, 1000, 700);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      this.list1obj = ListClass::new();
      int num1 = -1;
      int tlistselect = -1;
      int x1 = 25;
      int y1 = 25;
      DrawMod.DrawTextColouredMarc( graphics, "Mod Library Picker", this.game.MarcFont2, x1, y1, Color.White);
      int modlibCounter = this.game.modlib_Counter;
      for (int tdata = 0; tdata <= modlibCounter; tdata += 1)
      {
        num1 += 1;
        if (num1 == this.detailnr)
          tlistselect = num1;
        int nr = this.game.SMALLCHAR1;
        if (this.game.modlib_Flagged[tdata])
          nr = this.game.SMALLCHAR2;
        this.list1obj.add(this.game.modlib_Name[tdata], tdata, tbmp: BitmapStore.GetBitmap(nr));
      }
      int num2 = 25;
      int num3 = 80;
      if (this.list1obj.ListCount == -1)
      {
        DrawMod.DrawBlock( graphics, num2, num3, 450, 504, 0, 0, 0, 128);
        DrawMod.DrawTextColouredMarcCenter( graphics, "No Library Mod files found", this.game.MarcFont4, num2 + 225, num3 + 252, Color.White);
      }
      else if (this.list1Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.list1Id)].Refresh(this.list1obj, tlistselect);
        this.SubPartFlag[this.SubpartNr(this.list1Id)] = true;
      }
      else
      {
        let mut tsubpart: SubPartClass =  new ListSubPartClass(this.list1obj, 20, 450, tlistselect, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: ( this.OwnBitmap), bbx: num2, bby: num3, tMarcStyle: true, overruleFont: ( this.game.MarcFont4), overruleItemSize: 24);
        this.list1Id = this.AddSubPart( tsubpart, num2, num3, 450, 504, 0);
      }
      int x1_1 = 500;
      int y1_1 = 60;
      DrawMod.DrawBlock( graphics, x1_1, y1_1, 455, 550, 0, 0, 0, 128);
      if (this.detailnr > -1)
      {
        int x2 = 525;
        int y2 = 80;
        DrawMod.DrawTextColouredMarc( graphics, "Library name".ToUpper(), this.game.MarcFont5, x2, y2, Color.White);
        DrawMod.DrawTextColouredMarc( graphics, this.game.modlib_Name[this.detailnr], this.game.MarcFont4, x2 - 0, y2 + 20, Color.White);
        int x3 = 775;
        int y3 = 80;
        DrawMod.DrawTextColouredMarc( graphics, "Version".ToUpper(), this.game.MarcFont5, x3, y3, Color.White);
        DrawMod.DrawTextColouredMarc( graphics, this.game.modlib_Version[this.detailnr].ToString(), this.game.MarcFont4, x3 - 0, y3 + 20, Color.White);
        int x4 = 525;
        int y4 = 140;
        DrawMod.DrawTextColouredMarc( graphics, "File name".ToUpper(), this.game.MarcFont5, x4, y4, Color.White);
        DrawMod.DrawTextColouredMarc( graphics, this.game.modlib_Filename[this.detailnr], this.game.MarcFont4, x4 - 0, y4 + 20, Color.White);
        int x5 = 775;
        int y5 = 140;
        DrawMod.DrawTextColouredMarc( graphics, "Designer".ToUpper(), this.game.MarcFont5, x5, y5, Color.White);
        DrawMod.DrawTextColouredMarc( graphics, this.game.modlib_Designer[this.detailnr], this.game.MarcFont4, x5 - 0, y5 + 20, Color.White);
        int x6 = 525;
        int y6 = 200;
        DrawMod.DrawTextColouredMarc( graphics, "Description".ToUpper(), this.game.MarcFont5, x6, y6, Color.White);
        int num4 = 515;
        int num5 = 200;
        let mut tsubpart1: SubPartClass =  new TextAreaClass2(this.game, 430, 15, this.game.MarcFont8, this.game.modlib_Description[this.detailnr], 20,  this.OwnBitmap, num4, num5, tUseEncy: true, tDarkerFrame: true);
        this.B1Id = this.AddSubPart( tsubpart1, num4, num5, 430, 320, 0);
        int num6 = 725;
        int num7 = 565;
        if (!this.game.modlib_Flagged[this.detailnr])
        {
          let mut tsubpart2: SubPartClass =  new MarcRadioPartClass(0, false, "Flag this Mod Library to be used when starting a new game.",  this.OwnBitmap, num6, num7);
          this.B2Id = this.AddSubPart( tsubpart2, num6, num7, 35, 35, 1);
        }
        else
        {
          let mut tsubpart3: SubPartClass =  new MarcRadioPartClass(0, true, "Unflag this Mod Library to be used when starting a new game.",  this.OwnBitmap, num6, num7);
          this.B2Id = this.AddSubPart( tsubpart3, num6, num7, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc( graphics, "Use this Mod Library", this.game.MarcFont4, num6 + 43, num7 + 7, Color.White);
      }
      else
        DrawMod.DrawTextColouredMarcCenter( graphics, "No Mod Library selected, yet...", this.game.MarcFont4, x1_1 + 225, y1_1 + 275, Color.White);
      let mut tsubpart4: SubPartClass =  new TextButtonPartClass("OK", 150, "Click to return to main screen. [ESC]",  this.OwnBitmap, 425, 635, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart( tsubpart4, 425, 635, 150, 40, 1);
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      try
      {
        if (nr == 27 | nr == 32)
        {
          windowReturnClass.AddCommand(6, 0);
          this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
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
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.list1Id)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              this.detailnr = num2;
              this.View();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.cancelid)
            {
              windowReturnClass.AddCommand(6, 0);
              this.game.modlib_savePrefs();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B1Id)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B2Id)
            {
              if (this.detailnr > -1)
              {
                this.game.modlib_Flagged[this.detailnr] = !this.game.modlib_Flagged[this.detailnr];
                this.View();
              }
              this.SubPartFlag[index] = true;
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

    pub HandleMouseUp: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      OrderResult orderResult = OrderResult::new();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
        {
          if (this.SubPartList[index].Scroller)
          {
            int num = this.SubPartID[index];
            if (num == this.slider1id)
            {
              this.game.EditObj.Volume = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = false;
              this.SubPartList[this.SubpartNr(this.slider2id)].Scroller = false;
              SoundMod.ChangeEventSoundBg(this.game.EditObj);
              return windowReturnClass;
            }
            if (num == this.slider2id)
            {
              this.game.EditObj.Volume2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = false;
              this.SubPartList[this.SubpartNr(this.slider1id)].Scroller = false;
              SoundMod.ChangeEventSound(this.game.EditObj);
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
