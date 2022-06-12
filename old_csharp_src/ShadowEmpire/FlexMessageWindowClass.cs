﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.FlexMessageWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class FlexMessageWindowClass : WindowClass
  {
    private int okid;
    private int cancelid;
    private int oktextid;
    private int Pic1Id;
    private int TAid;
    private int His;
    private int Card;
    private int Unr;
    private int[] Answer;

    public FlexMessageWindowClass(ref GameClass tGame)
      : base(ref tGame, 600, 200, 8)
    {
      this.Answer = new int[10];
      this.View();
    }

    public void View()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(600, 200, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 600, 200);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      SizeF sizeF1 = new SizeF();
      string str1 = this.game.EditObj.QuestionText;
      sizeF1 = graphics.MeasureString(str1, this.game.MarcFont4);
      int num1 = -1;
      while (Strings.Len(str1) > 0)
      {
        ++num1;
        int Length = Strings.InStr(str1, ".");
        int num2 = 0;
        if (Length > 0)
          num2 = Strings.InStr(Length + 1, str1, ".");
        string str2;
        if (Length > 0 & num2 > 0)
        {
          str2 = Strings.Left(str1, Length);
          str1 = Strings.Mid(str1, Length + 1);
        }
        else
        {
          str2 = str1;
          str1 = "";
        }
        SizeF sizeF2 = graphics.MeasureString(str2, this.game.MarcFont4);
        DrawMod.DrawTextColouredMarc(ref graphics, str2, this.game.MarcFont4, (int) Math.Round(300.0 - (double) sizeF2.Width / 2.0), 40 + num1 * 20, Color.White);
      }
      if (this.game.EditObj.AnswerCount == 1)
      {
        int[] answer = this.Answer;
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass(this.game.EditObj.AnswerText[1], 100, tBackbitmap: (ref this.OwnBitmap), bbx: 250, bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        int num3 = this.AddSubPart(ref tsubpart, 250, 100, 100, 36, 1);
        answer[1] = num3;
        Rectangle trect = new Rectangle(250, 100, 100, 35);
        this.AddMouse(ref trect, "", this.game.EditObj.AnswerTextMouseOver[1]);
      }
      else if (this.game.EditObj.AnswerCount == 2)
      {
        int[] answer1 = this.Answer;
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass(this.game.EditObj.AnswerText[1], 100, tBackbitmap: (ref this.OwnBitmap), bbx: 175, bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        int num4 = this.AddSubPart(ref tsubpart1, 175, 100, 100, 36, 1);
        answer1[1] = num4;
        Rectangle rectangle = new Rectangle(175, 100, 100, 35);
        Rectangle trect = rectangle;
        this.AddMouse(ref trect, "", this.game.EditObj.AnswerTextMouseOver[1]);
        int[] answer2 = this.Answer;
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass(this.game.EditObj.AnswerText[2], 100, tBackbitmap: (ref this.OwnBitmap), bbx: 325, bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        int num5 = this.AddSubPart(ref tsubpart2, 325, 100, 100, 36, 1);
        answer2[2] = num5;
        rectangle = new Rectangle(325, 100, 100, 35);
        trect = rectangle;
        this.AddMouse(ref trect, "", this.game.EditObj.AnswerTextMouseOver[2]);
      }
      else
      {
        if (this.game.EditObj.AnswerCount != 3)
          return;
        int[] answer3 = this.Answer;
        SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass(this.game.EditObj.AnswerText[1], 166, tBackbitmap: (ref this.OwnBitmap), bbx: 25, bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        int num6 = this.AddSubPart(ref tsubpart3, 25, 100, 166, 36, 1);
        answer3[1] = num6;
        Rectangle rectangle = new Rectangle(25, 100, 166, 36);
        Rectangle trect = rectangle;
        this.AddMouse(ref trect, "", this.game.EditObj.AnswerTextMouseOver[1]);
        int[] answer4 = this.Answer;
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass(this.game.EditObj.AnswerText[2], 166, tBackbitmap: (ref this.OwnBitmap), bbx: 216, bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        int num7 = this.AddSubPart(ref tsubpart4, 216, 100, 166, 36, 1);
        answer4[2] = num7;
        rectangle = new Rectangle(216, 100, 166, 36);
        trect = rectangle;
        this.AddMouse(ref trect, "", this.game.EditObj.AnswerTextMouseOver[2]);
        int[] answer5 = this.Answer;
        SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass(this.game.EditObj.AnswerText[3], 166, tBackbitmap: (ref this.OwnBitmap), bbx: 407, bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
        int num8 = this.AddSubPart(ref tsubpart5, 407, 100, 166, 36, 1);
        answer5[3] = num8;
        rectangle = new Rectangle(407, 100, 166, 36);
        trect = rectangle;
        this.AddMouse(ref trect, "", this.game.EditObj.AnswerTextMouseOver[3]);
      }
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27)
        {
          this.game.EditObj.AnswerChosen = 2;
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        if (nr == 32)
        {
          this.game.EditObj.AnswerChosen = 1;
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
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int answerCount = this.game.EditObj.AnswerCount;
            for (int index2 = 1; index2 <= answerCount; ++index2)
            {
              if (this.Answer[index2] == this.SubPartID[index1])
              {
                windowReturnClass.AddCommand(6, 0);
                this.game.EditObj.AnswerChosen = index2;
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
