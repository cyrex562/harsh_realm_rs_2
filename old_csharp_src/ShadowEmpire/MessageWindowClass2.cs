// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MessageWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class MessageWindowClass2 : WindowClass
  {
    private int okid;
    private int tbacknr;
    private int oktextid;
    private int noteid;
    private int note2id;
    private int cloudid;
    private int Pic1Id;
    private int TAid;
    private int FromMessage;

    public MessageWindowClass2(ref GameClass tGame)
      : base(ref tGame, 680, 480, 8)
    {
      this.FromMessage = tGame.EditObj.FromMessage;
      this.ViewMessage();
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
            this.game.EditObj.TipButton = false;
            this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (this.game.EditObj.TipButton)
              return;
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

    public void ViewMessage()
    {
      if (this.okid > 0)
      {
        this.RemoveSubPart(this.okid);
        this.okid = 0;
      }
      if (this.TAid > 0)
      {
        this.RemoveSubPart(this.TAid);
        this.TAid = 0;
      }
      this.NewBackGroundAndClearAll(680, 480, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref g, 0, 0, 680, 480);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      if (this.FromMessage == -1)
        return;
      if (Strings.Len(this.game.Data.RegimeObj[this.game.Data.Turn].MessWav[this.FromMessage]) > 0)
      {
        SoundMod.STopEventWave();
        SoundMod.PlayEventWave(this.game.AppPath + "sound/" + this.game.Data.RegimeObj[this.game.Data.Turn].MessWav[this.FromMessage], ref this.game.EditObj);
      }
      int width1;
      int height1;
      int num1;
      if (this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.FromMessage] > -1)
      {
        int index = this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.FromMessage];
        int nr = index < 10000 ? this.game.Data.EventPicNr[index] : this.game.Data.HistoricalUnitObj[index - 10000].CommanderSpriteID;
        Rectangle rectangle;
        int num2;
        if (nr > -1)
        {
          width1 = BitmapStore.GetWidth(nr);
          height1 = BitmapStore.Getheight(nr);
          if (width1 > 340)
          {
            height1 = (int) Math.Round((double) height1 * (340.0 / (double) width1));
            width1 = (int) Math.Round((double) width1 * (340.0 / (double) width1));
          }
          if (height1 > 150)
          {
            width1 = (int) Math.Round((double) width1 * (150.0 / (double) height1));
            height1 = (int) Math.Round((double) height1 * (150.0 / (double) height1));
          }
          rectangle = new Rectangle((int) Math.Round(180.0 - (double) width1 / 2.0), 15, width1, height1);
          num2 = height1 + 15;
        }
        if (!Information.IsNothing((object) this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.FromMessage]) && this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.FromMessage].Length > 0)
          rectangle.X = 15;
        rectangle.X += 40;
        rectangle.Y += 30;
        num1 = num2 + 30;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.FromMessage] > 10000)
        {
          int his = this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.FromMessage] - 10000;
          DrawMod.DrawOfficer(g, his, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }
        else
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(nr);
          ref Bitmap local2 = ref bitmap;
          int x = rectangle.X;
          int y = rectangle.Y;
          int width2 = rectangle.Width;
          int height2 = rectangle.Height;
          DrawMod.DrawScaled(ref local1, ref local2, x, y, width2, height2);
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, rectangle.X, rectangle.Y, rectangle.Width + 1, rectangle.Height + 1, -1, -1);
        }
      }
      else
        num1 = 15 + 30;
      SizeF sizeF1 = new SizeF();
      if (!Information.IsNothing((object) this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.FromMessage]) && this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.FromMessage].Length > 0 & width1 < 150)
      {
        string str = this.game.Data.RegimeObj[this.game.Data.Turn].MesNote2[this.FromMessage];
        int num3;
        for (SizeF sizeF2 = g.MeasureString(str, this.game.MarcFont7); (double) sizeF2.Width > (double) (620 - width1); sizeF2 = g.MeasureString(str, this.game.MarcFont7))
        {
          str = Strings.Left(str, Strings.Len(str) - 1);
          num3 = 1;
        }
        if (num3 == 1)
          str = Strings.Left(str, Strings.Len(str) - 1) + "...";
        DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont7, 55 + width1 + 15, (int) Math.Round(30.0 + (double) height1 / 4.0), Color.White);
      }
      int trows = (int) Math.Round(Conversion.Int((double) (370 - num1) / 16.0));
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 569, trows, this.game.MarcFont8, this.game.Data.RegimeObj[this.game.Data.Turn].MessString[this.FromMessage], tbackbitmap: (ref this.BackBitmap), bbx: 50, bby: num1, tUseEncy: true);
      this.TAid = this.AddSubPart(ref tsubpart1, 50, num1, 569, 16 * (trows + 2), 0);
      int num4 = 16 * (trows + 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("PRESS ANY KEY", 150, "Click to indicate you have read message.\r\nOr press any key instead.", ref this.OwnBitmap, 270, num1 + num4 + 36, theight: 30, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.okid = this.AddSubPart(ref tsubpart2, 270, num1 + num4 + 46, 150, 30, 1);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (nr == 40)
      {
        this.SubPartList[this.SubpartNr(this.TAid)].ShiftDown();
        this.SubPartFlag[this.SubpartNr(this.TAid)] = true;
        windowReturnClass.SetFlag(true);
      }
      if (nr == 38)
      {
        this.SubPartList[this.SubpartNr(this.TAid)].ShiftUp();
        this.SubPartFlag[this.SubpartNr(this.TAid)] = true;
        windowReturnClass.SetFlag(true);
      }
      if (nr == 37)
      {
        this.SubPartList[this.SubpartNr(this.TAid)].ShiftLeft();
        this.SubPartFlag[this.SubpartNr(this.TAid)] = true;
        windowReturnClass.SetFlag(true);
      }
      if (nr == 39)
      {
        this.SubPartList[this.SubpartNr(this.TAid)].ShiftRight();
        this.SubPartFlag[this.SubpartNr(this.TAid)] = true;
        windowReturnClass.SetFlag(true);
      }
      return windowReturnClass;
    }

    public override WindowReturnClass HandleKeyup(int nr)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        switch (nr)
        {
          case 37:
            return windowReturnClass;
          case 38:
            return windowReturnClass;
          case 39:
            return windowReturnClass;
          case 40:
            return windowReturnClass;
          default:
            if (nr > 0)
            {
              windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okid)] + 1, this.SubPartY[this.SubpartNr(this.okid)] + 1, 1);
              windowReturnClass.SetFlag(true);
              break;
            }
            break;
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
            if (num == this.okid)
            {
              if (this.FromMessage >= this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter)
              {
                SoundMod.STopEventWave();
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              ++this.FromMessage;
              this.ViewMessage();
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
