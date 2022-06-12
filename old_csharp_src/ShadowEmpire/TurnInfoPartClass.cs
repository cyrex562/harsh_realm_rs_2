// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TurnInfoPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class TurnInfoPartClass : SubPartClass
  {
    private object OwnBitmapNr;
    private GameClass game;

    public TurnInfoPartClass(GameClass tgame)
      : base(200, 50)
    {
      this.game = tgame;
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int turn = this.game.Data.Turn;
      int round = this.game.Data.Round;
      int red2;
      int green2;
      int blue2;
      if (round > 0)
      {
        int red = this.game.Data.RegimeObj[turn].Red;
        int green = this.game.Data.RegimeObj[turn].Green;
        int blue = this.game.Data.RegimeObj[turn].Blue;
        red2 = this.game.Data.RegimeObj[turn].Red2;
        green2 = this.game.Data.RegimeObj[turn].Green2;
        blue2 = this.game.Data.RegimeObj[turn].Blue2;
        Color c1 = Color.FromArgb((int) byte.MaxValue, red, green, blue);
        Color c2 = Color.FromArgb(150, red, green, blue);
        DrawMod.DrawBlockGradient(ref Expression, 0, 0, 200, 50, c1, c2);
      }
      else
      {
        Color c1 = Color.FromArgb((int) byte.MaxValue, 180, 180, 180);
        Color c2 = Color.FromArgb(150, 90, 90, 90);
        DrawMod.DrawBlockGradient(ref Expression, 0, 0, 200, 50, c1, c2);
      }
      if (round > 0)
      {
        Color c = Color.FromArgb((int) byte.MaxValue, red2, green2, blue2);
        string str;
        if (this.game.Data.AlternateRound == -1)
        {
          str = "Round " + Conversion.Str((object) this.game.Data.Round);
          if (this.game.Data.AlternateRound2 > 0)
          {
            DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1)).AddHours((double) this.game.Data.StartData.Hour);
            TimeSpan timeSpan = new TimeSpan(0, (this.game.Data.Round - 1) * this.game.Data.AlternateRound2, 0, 0);
            dateTime = dateTime.Add(timeSpan);
            str = Strings.Trim(Conversion.Str((object) dateTime.Day)) + "-" + Strings.Trim(Conversion.Str((object) dateTime.Month)) + "-" + Strings.Trim(Conversion.Str((object) dateTime.Year)) + " " + Strings.Trim(Conversion.Str((object) dateTime.Hour)) + ":00";
          }
        }
        else
        {
          DateTime dateTime1 = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
          DateTime dateTime2;
          if (this.game.Data.AlternateRound == 31)
          {
            dateTime2 = dateTime1.AddMonths((this.game.Data.Round - 1) * 1);
          }
          else
          {
            TimeSpan timeSpan = new TimeSpan((this.game.Data.Round - 1) * this.game.Data.AlternateRound, 0, 0, 0);
            dateTime2 = dateTime1.Add(timeSpan);
          }
          str = Strings.Trim(Conversion.Str((object) dateTime2.Day)) + "-" + Strings.Trim(Conversion.Str((object) dateTime2.Month)) + "-" + Strings.Trim(Conversion.Str((object) dateTime2.Year));
        }
        sizeF1 = Expression.MeasureString(str, new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel));
        DrawMod.DrawTextColoured(ref Expression, str, new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 10, 5, c);
        string name = this.game.Data.RegimeObj[this.game.Data.Turn].Name;
        sizeF1 = Expression.MeasureString(name, new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel));
        DrawMod.DrawTextColoured(ref Expression, name, new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 10, 25, c);
        string tstring = "PolPts: " + Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts));
        DrawMod.DrawTextColoured(ref Expression, tstring, new Font("Times New Roman", 11f, FontStyle.Bold, GraphicsUnit.Pixel), 120, 5, c);
      }
      else
      {
        Color c = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        string str = "Editor Mode";
        SizeF sizeF2 = Expression.MeasureString(str, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel));
        DrawMod.DrawTextColoured(ref Expression, str, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), (int) Math.Round(100.0 - (double) sizeF2.Width / 2.0), 5, c);
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.OwnBitmapNr));
      ref Bitmap local2 = ref bitmap;
      DrawMod.Draw(ref local1, ref local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
