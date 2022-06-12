﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CreditsInfoWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsApplication1
{
  public class CreditsInfoWindowClass : WindowClass
  {
    private int okid;
    private int cancelid;
    private int oktextid;
    private int Pic1Id;
    private int TAid;
    private int Ta2id;
    private int His;
    private int Card;
    private int Unr;
    private int tx;
    private int ty;
    private int tr;
    private int tw;
    private int th;

    public CreditsInfoWindowClass(ref GameClass tGame)
      : base(ref tGame, 880, 680, 8)
    {
      this.View();
      this.tr = (int) byte.MaxValue;
      this.tx = 0;
      this.ty = 0;
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
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
      for (int index = 0; index <= mouseCounter; ++index)
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

    public void View()
    {
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      if (this.TAid > 0)
        this.RemoveSubPart(this.TAid);
      if (this.Ta2id > 0)
        this.RemoveSubPart(this.Ta2id);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(880, 680, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      g.SmoothingMode = SmoothingMode.HighQuality;
      g.InterpolationMode = InterpolationMode.HighQualityBicubic;
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref g, 0, 0, 880, 680);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      string tText1 = "Designed by Victor Reijkersz" + "\r\n" + "\r\n" + "PROGRAMMING, ARTIFICIAL INTELLIGENCE" + "\r\n" + "Victor Reijkersz" + "\r\n" + "\r\n" + "ARTWORK" + "\r\n" + "Mike Tenebrae, Bernd Brossig, Victor Reijkersz, Frederic Genot and others" + "\r\n" + "\r\n" + "WRITING" + "\r\n" + "Victor Reijkersz" + "\r\n" + "\r\n" + "MUSIC" + "\r\n" + "Tempest for an Angel" + "\r\n" + "\r\n" + "SOUND EFFECTS" + "\r\n" + "Tempest for an Angel, PMSFX, Benjamin D. Halford and others" + "\r\n" + "\r\n" + "SOLDIER VOICES" + "\r\n" + "Georgina Donnalley, CoderVA, Nylithia, Rachel Bell and others" + "\r\n" + "\r\n" + "MANUAL" + "\r\n" + "Victor Reijkersz" + "\r\n" + "\r\n" + "MANUAL POST-RELEASE PROOFREADING" + "\r\n" + "Tom Try" + "\r\n" + "\r\n" + "TESTING AND FEEDBACK" + "\r\n" + "Bavarian Kid, Clux, Soar_Slitherine, Nachtjager, DTurtle, Malevolence, Culthrasa, Jim Winsor, Eric Heiser, Cassini, Benjamin Graham, Andy Brown, Cablenexus, Zakblood, Verde321, Cablenexus, Jnpoint, Gwgardner, JHeinlen, Aristos, Shards, DasTactic, Jakval96, TortugaPower, Pocus, OutOf8, ArditiDagger, Maheb, Dan1911, Wodin, Tufkal2, David Arenz, C.Charles Dunlap, Harry Chrismas, Scott Jackson and many many others!" + "\r\n" + "\r\n";
      string tText2 = "Published by Matrix Games" + "\r\n" + "\r\n" + "CEO" + "\r\n" + "Iain McNeil" + "\r\n" + "\r\n" + "CFO" + "\r\n" + "JD McNeil" + "\r\n" + "\r\n" + "SENIOR PRODUCER" + "\r\n" + "David Sharrock" + "\r\n" + "\r\n" + "PRODUCERS" + "\r\n" + "Tamas Kiss, Bart Schouten, Neil McKenna, Erik Rutins" + "\r\n" + "\r\n" + "TECHNICAL DIRECTOR" + "\r\n" + "Philip Veale" + "\r\n" + "\r\n" + "CREATIVE DIRECTOR" + "\r\n" + "Richard Evans" + "\r\n" + "\r\n" + "MARKETING DIRECTOR " + "\r\n" + "Marco Minoli" + "\r\n" + "\r\n" + "PRODUCT MANAGER" + "\r\n" + "Roberta Migliori, Alberto Casulini, Daniele Meneghini" + "\r\n" + "\r\n" + "SOCIAL MEDIA MANAGER" + "\r\n" + "Bruno Bontempo" + "\r\n" + "\r\n" + "MEDIA RELATIONS" + "\r\n" + "Paolo Paglianti" + "\r\n" + "\r\n" + "PRODUCTION DESIGN" + "\r\n" + "Adriana Bienati" + "\r\n" + "\r\n" + "MARKETING EXECUTIVE" + "\r\n" + "Roberta Migliori" + "\r\n" + "\r\n" + "LEAD ARTIST" + "\r\n" + "Pat Ward" + "\r\n" + "\r\n" + "ARTIST" + "\r\n" + "Koen Bekkema" + "\r\n" + "\r\n" + "MANUAL LAYOUT" + "\r\n" + "Myriam Bell" + "\r\n" + "\r\n" + "PRODUCTION LEAD" + "\r\n" + "Matthew Ravenwood" + "\r\n" + "\r\n" + "PRODUCTION TEAM" + "\r\n" + "Sam O’Neill, Joseph Stephenson" + "\r\n" + "\r\n" + "ADMINISTRATION" + "\r\n" + "Dean Walker" + "\r\n" + "\r\n" + "ADMINISTRATION ASSISTANT" + "\r\n" + "Richard Baker" + "\r\n" + "\r\n" + "CUSTOMER SUPPORT STAFF" + "\r\n" + "Paulo Costa, Joseph Miller" + "\r\n" + "\r\n" + "WEB DEVELOPMENT" + "\r\n" + "Valery Vidershpan, Andrea Nicola, Fernando Turi" + "\r\n" + "\r\n";
      ref Graphics local1 = ref g;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.MGSPLASH);
      ref Bitmap local2 = ref bitmap1;
      DrawMod.DrawScaled(ref local1, ref local2, 595, 30, 130, 130);
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 380, 25, this.game.MarcFont4, tText2, tbackbitmap: (ref this.BackBitmap), bbx: 470, bby: 156, tcenterit: true);
      this.Ta2id = this.AddSubPart(ref tsubpart1, 470, 156, 380, 416, 0);
      ref Graphics local3 = ref g;
      Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.VRSPLASH);
      ref Bitmap local4 = ref bitmap2;
      DrawMod.DrawScaled(ref local3, ref local4, 155, 30, 130, 130);
      SubPartClass tsubpart2 = (SubPartClass) new TextAreaClass2(this.game, 380, 25, this.game.MarcFont4, tText1, tbackbitmap: (ref this.BackBitmap), bbx: 30, bby: 156, tcenterit: true);
      this.TAid = this.AddSubPart(ref tsubpart2, 30, 156, 380, 416, 0);
      SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("OK", 150, "Click to return to main screen. [ESC]", ref this.OwnBitmap, 365, 620, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart3, 365, 620, 150, 40, 1);
    }

    public void View2()
    {
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      this.tx += 101;
      if (this.tx > 870)
      {
        this.tx = 0;
        this.ty += 101;
      }
      if (this.ty > 600)
      {
        this.ty = 0;
        this.tr -= 25;
      }
      if (this.tr < 1)
        this.tr = (int) byte.MaxValue;
      DrawMod.DrawBlock(ref objGraphics, this.tx, this.ty, 100, 100, this.tr, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
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
            int num = this.SubPartID[index];
            if (num == this.TAid)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.Ta2id)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.cancelid)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              windowReturnClass.AddCommand(6, 0);
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
