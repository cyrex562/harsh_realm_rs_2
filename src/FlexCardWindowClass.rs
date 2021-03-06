// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.FlexCardWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class FlexCardWindowClass : WindowClass
  {
     int okid;
     int cancelid;
     int oktextid;
     int Pic1Id;
     int TAid;
     int His;
     int Card;
     int Unr;
     int[] Answer;

    pub FlexCardWindowClass(ref GameClass tGame)
      : base(ref tGame, 400, 400, 8)
    {
      this.Answer = new int[10];
      this.View();
    }

    pub void View()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(400, 400, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 400, 400);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      SizeF sizeF1 = SizeF::new();
      questionText: String = this.game.EditObj.QuestionText;
      let mut questionCard: i32 =  this.game.EditObj.QuestionCard;
      SizeF sizeF2 = graphics.MeasureString(questionText, this.game.MarcFont3);
      DrawMod.DrawTextColouredMarc(ref graphics, questionText, this.game.MarcFont3,  Math.Round(200.0 - (double) sizeF2.Width / 2.0), 20, Color.White);
      ref Graphics local1 = ref graphics;
      Bitmap bitmap = this.game.CustomBitmapObj.DrawActionCardSe1(this.game.Data.Turn, questionCard);
      ref Bitmap local2 = ref bitmap;
      DrawMod.DrawSimple(ref local1, ref local2, 105, 60);
      int[] answer = this.Answer;
      let mut tsubpart: SubPartClass =  new TextButtonPartClass(this.game.EditObj.AnswerText[1], 100, tBackbitmap: (ref this.OwnBitmap), bbx: 150, bby: 340, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      let mut num: i32 =  this.AddSubPart(ref tsubpart, 150, 340, 100, 36, 1);
      answer[1] = num;
      Rectangle trect = Rectangle::new(150, 100, 100, 35);
      this.AddMouse(ref trect, "", this.game.EditObj.AnswerTextMouseOver[1]);
    }

    pub HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
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

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 =  this.SubPartCounter;
        for (let mut index1: i32 =  0; index1 <= subPartCounter; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            let mut answerCount: i32 =  this.game.EditObj.AnswerCount;
            for (let mut index2: i32 =  1; index2 <= answerCount; index2 += 1)
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
