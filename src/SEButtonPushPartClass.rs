// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEButtonPushPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  pub class SEButtonPushPartClass : SubPartClass
  {
     int iconNr;
     int width;
     int height;
     bool gray;
     bool pushed;

    pub void SubDispose()
    {
    }

    pub SEButtonPushPartClass(
      int ticonnr,
      bool tPushed,
      tDescript: String = "",
      let mut twidth: i32 = 35,
      let mut theight: i32 = 35,
      bool tgrayedOut = false)
      : base(twidth, theight)
    {
      this.width = twidth;
      this.height = theight;
      this.Descript = tDescript;
      this.iconNr = ticonnr;
      this.gray = tgrayedOut;
      this.pushed = tPushed;
    }

    pub Bitmap Paint()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (this.pushed)
      {
         Graphics local1 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ORDERBUTTONPRESSED);
         Bitmap local2 =  bitmap;
        rectangle1 = new Rectangle(14, 0, 16, 38);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
         Graphics local3 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ORDERBUTTONPRESSED);
         Bitmap local4 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 38);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
         Graphics local5 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ORDERBUTTONPRESSED);
         Bitmap local6 =  bitmap;
        rectangle2 = new Rectangle(30, 0, 14, 38);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      }
      else
      {
         Graphics local7 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local8 =  bitmap;
        rectangle2 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
         Graphics local9 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local10 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
         Graphics local11 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTON);
         Bitmap local12 =  bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
      }
      let mut x: i32 =  Math.Round((double) (this.width - 48) / 2.0);
      let mut y: i32 =  Math.Round((double) (this.height - 32) / 2.0);
      if (this.gray)
      {
         Graphics local13 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         Bitmap local14 =  bitmap;
        rectangle2 = new Rectangle(this.iconNr * 42, 0, 42, 32);
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(x, y, 48, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld( local13,  local14, srcrect, destrect, 0.3f, 0.3f, 0.3f, 1f);
      }
      else
      {
         Graphics local15 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         Bitmap local16 =  bitmap;
        rectangle2 = new Rectangle(this.iconNr * 42, 0, 42, 32);
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(x, y, 48, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2( local15,  local16, srcrect, destrect);
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (this.pushed)
      {
         Graphics local1 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ORDERBUTTONPRESSED);
         Bitmap local2 =  bitmap;
        rectangle1 = new Rectangle(14, 0, 16, 38);
        Rectangle srcrect1 = rectangle1;
        rectangle2 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect1 = rectangle2;
        DrawMod.DrawSimplePart2( local1,  local2, srcrect1, destrect1);
         Graphics local3 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ORDERBUTTONPRESSED);
         Bitmap local4 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 38);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2( local3,  local4, srcrect2, destrect2);
         Graphics local5 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ORDERBUTTONPRESSED);
         Bitmap local6 =  bitmap;
        rectangle2 = new Rectangle(30, 0, 14, 38);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2( local5,  local6, srcrect3, destrect3);
      }
      else
      {
         Graphics local7 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
         Bitmap local8 =  bitmap;
        rectangle2 = new Rectangle(14, 0, 7, 35);
        Rectangle srcrect4 = rectangle2;
        rectangle1 = new Rectangle(14, 0, this.width - 28, this.height);
        Rectangle destrect4 = rectangle1;
        DrawMod.DrawSimplePart2( local7,  local8, srcrect4, destrect4);
         Graphics local9 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
         Bitmap local10 =  bitmap;
        rectangle2 = new Rectangle(0, 0, 14, 35);
        Rectangle srcrect5 = rectangle2;
        rectangle1 = new Rectangle(0, 0, 14, this.height);
        Rectangle destrect5 = rectangle1;
        DrawMod.DrawSimplePart2( local9,  local10, srcrect5, destrect5);
         Graphics local11 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ARROWBUTTONHIGH);
         Bitmap local12 =  bitmap;
        rectangle2 = new Rectangle(21, 0, 14, 35);
        Rectangle srcrect6 = rectangle2;
        rectangle1 = new Rectangle(this.width - 14, 0, 14, this.height);
        Rectangle destrect6 = rectangle1;
        DrawMod.DrawSimplePart2( local11,  local12, srcrect6, destrect6);
      }
      let mut x: i32 =  Math.Round((double) (this.width - 48) / 2.0);
      let mut y: i32 =  Math.Round((double) (this.height - 32) / 2.0);
      if (this.gray)
      {
         Graphics local13 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         Bitmap local14 =  bitmap;
        rectangle2 = new Rectangle(this.iconNr * 42, 0, 42, 32);
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(x, y, 48, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2ColouredOld( local13,  local14, srcrect, destrect, 0.3f, 0.3f, 0.3f, 1f);
      }
      else
      {
         Graphics local15 =  Expression;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         Bitmap local16 =  bitmap;
        rectangle2 = new Rectangle(this.iconNr * 42, 32, 42, 32);
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(x, y, 48, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2( local15,  local16, srcrect, destrect);
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
