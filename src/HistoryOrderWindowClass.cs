// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HistoryOrderWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class HistoryOrderWindowClass : WindowClass
  {
    private bool TimerUsed;
    private int w;
    private int h;
    private int CurrentView;
    private int info2id;
    private int exitid;
    private int skipid;
    private int slider1id;
    private int specialid;
    private int autoplayid;
    private HistoryWindowClass2 HisW;

    public HistoryOrderWindowClass(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      ref HistoryWindowClass2 tHisW)
      : base(ref tGame, tGame.ScreenWidth, 90)
    {
      this.NewGfx = true;
      if (!this.game.EditObj.AIMoving)
      {
        this.game.EditObj.RealRound = this.game.Data.Round;
        this.game.EditObj.RealTurn = this.game.Data.Turn;
      }
      this.w = tGame.ScreenWidth;
      this.h = 90;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.HisW = tHisW;
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public override void HandleToolTip(int x, int y)
    {
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "";
            this.game.EditObj.TipText = this.SubPartList[index].Descript;
            return;
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

    public void dostuff()
    {
      this.CurrentView = this.game.EditObj.SetViewMode;
      this.ClearMouse();
      if (this.info2id > 0)
      {
        this.RemoveSubPart(this.info2id);
        this.info2id = 0;
      }
      if (this.exitid > 0)
      {
        this.RemoveSubPart(this.exitid);
        this.exitid = 0;
      }
      if (this.slider1id > 0)
      {
        this.RemoveSubPart(this.slider1id);
        this.slider1id = 0;
      }
      if (this.skipid > 0)
        this.RemoveSubPart(this.skipid);
      if (this.specialid > 0)
        this.RemoveSubPart(this.specialid);
      if (this.autoplayid > 0)
        this.RemoveSubPart(this.autoplayid);
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int num1 = (int) Math.Round((double) this.game.ScreenWidth / 116.0);
      Bitmap bitmap;
      for (int index = 0; index <= num1; ++index)
      {
        ref Graphics local1 = ref Expression;
        bitmap = BitmapStore.GetBitmap(this.game.MARCBUTBARFRAME);
        ref Bitmap local2 = ref bitmap;
        int x = index * 116;
        DrawMod.DrawSimple(ref local1, ref local2, x, 87);
      }
      int num2 = (int) Math.Round((double) (this.game.ScreenWidth - 1152) / 2.0);
      int num3 = -3;
      ref Graphics local3 = ref Expression;
      bitmap = BitmapStore.GetBitmap(this.game.MARCBUTBARHISTORY);
      ref Bitmap local4 = ref bitmap;
      int x1 = num2;
      int y = num3;
      DrawMod.DrawSimple(ref local3, ref local4, x1, y);
      int num4 = 34;
      int num5 = num2 + 40;
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      if (this.game.AIRunning | this.game.se1ThreadRunning)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("AI Playing!", this.game.MarcFont1, 200, 37, false, toutline: true, tMarc: true);
        this.info2id = this.AddSubPart(ref tsubpart, num5 - 15, num4 - 5, 185, 37, 0);
      }
      else if (this.game.AIRunning & !this.game.se1ThreadRunning & this.game.EditObj.AIMoving)
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("AI Finished!", this.game.MarcFont1, 200, 37, false, toutline: true, tMarc: true);
        this.info2id = this.AddSubPart(ref tsubpart, num5 - 15, num4 - 5, 185, 37, 0);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextPartClass("History Log", this.game.MarcFont1, 200, 37, false, toutline: true, tMarc: true);
        this.info2id = this.AddSubPart(ref tsubpart, num5 - 15, num4 - 5, 185, 37, 0);
      }
      if (this.HisW.StartStep > -1 & this.HisW.EndStep > -1)
      {
        SubPartClass tsubpart = (SubPartClass) new NumberSliderSubPartClass2(this.game, "Step", " of " + Conversion.Str((object) Math.Max(Math.Max(0, this.HisW.Curstep), Math.Max(0, this.HisW.EndStep))), 550, 0, Math.Max(0, this.HisW.EndStep), Math.Max(0, this.HisW.Curstep), tbackbitmap: (ref this.OwnBitmap), bbx: (num5 + 170), bby: (num4 - 14), tMarc: true);
        this.slider1id = this.AddSubPart(ref tsubpart, num5 + 170, num4 - 14, 550, 40, 0);
      }
      if (this.HisW.Curstep >= this.HisW.EndStep)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("BACK", 100, "Rewind to first recorded move.", ref this.OwnBitmap, num5 + 690 + 130, num4, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.specialid = this.AddSubPart(ref tsubpart, num5 + 690 + 130, num4, 100, 35, 1);
      }
      else
      {
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("NEXT BATTLE", 120, "Click to fast-forward to the next battle.", ref this.OwnBitmap, num5 + 690 + 130, num4, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.specialid = this.AddSubPart(ref tsubpart1, num5 + 690 + 130, num4, 120, 35, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("NEXT REGIME", 120, "Click to fast-forward to the moves of the next regime.", ref this.OwnBitmap, num5 + 960, num4, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.skipid = this.AddSubPart(ref tsubpart2, num5 + 960, num4, 120, 35, 1);
      }
      if (!this.HisW.AutoPlay)
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("PLAY", 60, "Click to start Autoplay [shortkey P]", ref this.OwnBitmap, num5 + 610 + 130, num4, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.autoplayid = this.AddSubPart(ref tsubpart, num5 + 610 + 130, num4, 60, 35, 1);
      }
      else
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("STOP", 60, "Click to pause Autoplay [shortkey P]", ref this.OwnBitmap, num5 + 610 + 130, num4, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.autoplayid = this.AddSubPart(ref tsubpart, num5 + 610 + 130, num4, 60, 35, 1);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (y > 18 && (double) this.w / 2.0 - 500.0 < (double) x & (double) x < (double) this.w / 2.0 + 500.0)
        windowReturnClass.NoMouseClickBelow = true;
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.skipid)
            {
              this.game.EditObj.TempCoordList = new CoordList();
              if (this.HisW.Curstep == 0 & this.HisW.Curstep < this.HisW.EndStep)
              {
                this.HisW.Forward(1);
                ++this.HisW.Curstep;
              }
              if (this.HisW.lastregime >= -1)
              {
                int lastregime1 = this.HisW.lastregime;
                int num2 = 1;
                while (num2 == 1)
                {
                  num2 = 0;
                  if (this.HisW.Curstep < this.HisW.EndStep)
                  {
                    this.HisW.Forward(1);
                    ++this.HisW.Curstep;
                    num2 = 1;
                    int lastregime2 = this.HisW.lastregime;
                    if (lastregime2 != lastregime1 & lastregime2 != -1)
                      num2 = 0;
                  }
                }
              }
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 80);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 81);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.slider1id)
            {
              int steps = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              if (steps > this.HisW.Curstep)
              {
                this.game.EditObj.TempCoordList = new CoordList();
                this.HisW.Forward(steps - this.HisW.Curstep);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 80);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 81);
                windowReturnClass.AddCommand(4, 9);
                this.HisW.Curstep = steps;
              }
              else if (steps < this.HisW.Curstep)
              {
                this.HisW.StartSit();
                this.HisW.Forward(steps);
                this.game.EditObj.TempCoordList = new CoordList();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 80);
                windowReturnClass.AddCommand(4, 67);
                windowReturnClass.AddCommand(4, 81);
                windowReturnClass.AddCommand(4, 9);
                this.HisW.Curstep = steps;
              }
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.specialid)
            {
              if (this.HisW.Curstep >= this.HisW.EndStep)
              {
                this.HisW.StartSit();
                this.game.EditObj.TempCoordList = new CoordList();
                this.HisW.Curstep = 0;
              }
              else
              {
                do
                {
                  this.HisW.Forward(1);
                  this.game.EditObj.TempCoordList = new CoordList();
                  ++this.HisW.Curstep;
                }
                while (this.game.EditObj.HisAttackType == -1 & this.HisW.Curstep < this.HisW.EndStep);
              }
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 80);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 81);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.exitid)
            {
              if (this.HisW.HumanPlayer > -1)
              {
                if (this.game.Data.UseAI == 0)
                  this.game.AIObj.CloseAI();
                if (this.game.Data.UseAI == 1)
                  this.game.NewAIObj.CloseAI();
                windowReturnClass.SetFlag(true);
                this.game.EditObj.AIMoving = false;
                if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI)
                  this.game.EventRelatedObj.DoCheckEvents(5);
                windowReturnClass.AddCommand(3, 13);
                this.game.EditObj.OrderType = 0;
                this.game.EditObj.TempCoordList = new CoordList();
                return windowReturnClass;
              }
              this.game.EditObj.TempCoordList = new CoordList();
              if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI)
                this.game.EventRelatedObj.DoCheckEvents(5);
              windowReturnClass.AddCommand(3, 11);
              this.game.EditObj.OrderType = 0;
              windowReturnClass.SetFlag(true);
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.autoplayid)
            {
              this.HisW.AutoPlay = !this.HisW.AutoPlay;
              if (this.HisW.AutoPlay & this.HisW.Curstep >= this.HisW.EndStep)
              {
                this.HisW.StartSit();
                this.HisW.Curstep = 0;
              }
              windowReturnClass.AddCommand(4, 80);
              this.dostuff();
              windowReturnClass.SetFlag(true);
            }
            return windowReturnClass;
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
