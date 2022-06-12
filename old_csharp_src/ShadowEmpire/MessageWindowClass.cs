// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.MessageWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class MessageWindowClass : WindowClass
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

    public MessageWindowClass(ref GameClass tGame)
      : base(ref tGame, 810, 610, BackSprite: tGame.BACKGROUND2MARC, tBackSpriteScaled: true)
    {
      this.tbacknr = tGame.BACKGROUND2MARC;
      this.FromMessage = tGame.EditObj.FromMessage;
      this.ViewMessage();
    }

    public MessageWindowClass(ref GameClass tGame, int TempShit)
      : base(ref tGame, 810, 610, 7, tGame.BACKGROUND2MARC, true)
    {
      this.tbacknr = tGame.BACKGROUND2MARC;
      this.FromMessage = tGame.EditObj.FromMessage;
      this.ViewMessage();
    }

    public void ViewMessage()
    {
      if (this.Pic1Id > 0)
        this.RemoveSubPart(this.Pic1Id);
      if (this.okid > 0)
      {
        this.RemoveSubPart(this.okid);
        this.okid = 0;
      }
      if (this.oktextid > 0)
        this.RemoveSubPart(this.oktextid);
      if (this.TAid > 0)
        this.RemoveSubPart(this.TAid);
      if (this.noteid > 0)
        this.RemoveSubPart(this.noteid);
      if (this.note2id > 0)
        this.RemoveSubPart(this.note2id);
      if (this.cloudid > 0)
        this.RemoveSubPart(this.cloudid);
      if (this.game.Data.RegimeObj[this.game.Data.Turn].MesStyle[this.FromMessage] == 1)
        this.NewBackGroundAndClearAll(810, 610, this.game.BACKGROUND2MARC);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      if (Strings.Len(this.game.Data.RegimeObj[this.game.Data.Turn].MessWav[this.FromMessage]) > 0)
      {
        SoundMod.STopEventWave();
        SoundMod.PlayEventWave(this.game.AppPath + "sound/" + this.game.Data.RegimeObj[this.game.Data.Turn].MessWav[this.FromMessage], ref this.game.EditObj);
      }
      int num1;
      if (this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.FromMessage] > -1)
      {
        int index = this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.FromMessage];
        int nr = index < 10000 ? this.game.Data.EventPicNr[index] : this.game.Data.HistoricalUnitObj[index - 10000].CommanderSpriteID;
        if (nr > -1)
        {
          int width1 = BitmapStore.GetWidth(nr);
          int height1 = BitmapStore.Getheight(nr);
          Rectangle rectangle;
          if (this.game.Data.RegimeObj[this.game.Data.Turn].MesStyle[this.FromMessage] == 2)
          {
            if (width1 > 160)
            {
              height1 = (int) Math.Round((double) height1 * (160.0 / (double) width1));
              width1 = (int) Math.Round((double) width1 * (160.0 / (double) width1));
            }
            if (height1 > 200)
            {
              width1 = (int) Math.Round((double) width1 * (200.0 / (double) height1));
              height1 = (int) Math.Round((double) height1 * (200.0 / (double) height1));
            }
            rectangle = new Rectangle(85, 100, width1, height1);
            num1 = height1 + 100 + 20;
          }
          else
          {
            if (width1 > 724)
            {
              height1 = (int) Math.Round((double) height1 * (724.0 / (double) width1));
              width1 = (int) Math.Round((double) width1 * (724.0 / (double) width1));
            }
            if (height1 > 200)
            {
              width1 = (int) Math.Round((double) width1 * (200.0 / (double) height1));
              height1 = (int) Math.Round((double) height1 * (200.0 / (double) height1));
            }
            rectangle = new Rectangle((int) Math.Round(405.0 - (double) width1 / 2.0), 20, width1, height1);
            num1 = height1 + 20 + 20;
          }
          if (this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.FromMessage] >= 10000)
          {
            DrawMod.DrawOfficer(g, this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.FromMessage] - 10000, (int) Math.Round(412.0 - (double) BitmapStore.GetWidth(nr) / 2.0), 70, BitmapStore.GetWidth(nr), BitmapStore.Getheight(nr));
            num1 += 50;
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
          }
        }
      }
      else
        num1 = 60;
      int num2 = (int) Math.Round(Conversion.Int(32.5) - (double) num1 / 16.0);
      DrawMod.DrawPaperSheet(ref g, 55, num1 - 10, 690, 16 * (num2 - 1) + 20);
      SubPartClass tsubpart1 = (SubPartClass) new PaperAreaClass(this.game, 650, num2 - 2, (Font) null, "Description", false, this.game.Data.RegimeObj[this.game.Data.Turn].MessString[this.FromMessage], this.game.VicColor8, tbackbitmap: (ref this.OwnBitmap), bbx: 75, bby: num1);
      this.TAid = this.AddSubPart(ref tsubpart1, 75, num1, 650, 16 * (num2 - 2), 0);
      SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("OK", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 300, bby: 540);
      this.okid = this.AddSubPart(ref tsubpart2, 300, 540, 200, 35, 1);
      if (Information.IsNothing((object) g))
        return;
      g.Dispose();
    }

    public override WindowReturnClass HandleKeyup(int nr)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr > 0)
        {
          windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okid)] + 1, this.SubPartY[this.SubpartNr(this.okid)] + 1, 1);
          windowReturnClass.SetFlag(true);
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
                if (this.game.EditObj.OrderType == 23)
                {
                  this.game.EditObj.PopupValue = 14;
                  windowReturnClass.AddCommand(5, 10);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                windowReturnClass.AddCommand(6, 0);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              ++this.FromMessage;
              if (Strings.Len(DrawMod.TGame.EditObj.CampaignRoomTitle) > 0)
                this.NewBackGroundAndClearAll(810, 610, DrawMod.TGame.BACKGROUND2MARC);
              else
                this.NewBackGroundAndClearAll(810, 610, this.tbacknr);
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
