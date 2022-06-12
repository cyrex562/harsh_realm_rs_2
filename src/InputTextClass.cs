// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.InputTextClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;

namespace WindowsApplication1
{
  public class InputTextClass : SubPartClass
  {
    private Font OwnFont;
    private string OwnText;
    private int maxchar;
    private bool inactive;
    private bool noSpace;
    private int maxSize;

    public InputTextClass(
      string txt,
      Font f,
      int w,
      int h,
      bool tinactive,
      int tmaxchar,
      bool tnospace = false,
      int tmaxsize = 50)
      : base(w, h)
    {
      this.OwnFont = f;
      this.inactive = tinactive;
      this.maxchar = tmaxchar;
      this.noSpace = tnospace;
      txt = txt.Replace('\b'.ToString(), "");
      this.OwnText = txt;
      this.maxSize = tmaxsize;
      if (this.OwnText.Length <= this.maxSize)
        return;
      this.OwnText = Strings.Left(this.OwnText, this.maxSize);
    }

    public override void Refresh(string s)
    {
      int length = s.Length;
      for (int Start = 1; Start <= length; ++Start)
      {
        char ch = Conversions.ToChar(Strings.Mid(s, Start, 1));
        if (this.OwnText.Length < this.maxchar | ch == '\b')
        {
          if (ch == '\b' & this.OwnText.Length > 0)
            this.OwnText = Strings.Mid(this.OwnText, 1, Strings.Len(this.OwnText) - 1);
          else if (ch != '\b')
            this.OwnText += ch.ToString();
        }
      }
      if (this.OwnText.Length <= this.maxSize)
        return;
      this.OwnText = Strings.Left(this.OwnText, this.maxSize);
    }

    public override string GetText()
    {
      if (this.OwnText.Length > this.maxSize)
        this.OwnText = Strings.Left(this.OwnText, this.maxSize);
      this.OwnText = this.OwnText.Replace('\b'.ToString(), "");
      return this.OwnText;
    }

    public override Bitmap Paint()
    {
      SizeF sizeF = new SizeF();
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.inactive)
        DrawMod.Clear(ref Expression, 80, 80, 80);
      else
        DrawMod.Clear(ref Expression, 0, 0, 0);
      DrawMod.DrawRectangle(ref Expression, 0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height, 200, 200, 200, 200, 2);
      int x;
      int y;
      if (Operators.CompareString(this.Descript, "select", false) == 0)
      {
        DrawMod.DrawRectangle(ref Expression, 2, 2, this.OwnBitmap.Width - 4, this.OwnBitmap.Height - 4, (int) byte.MaxValue, 0, 0, 200, 2);
        DrawMod.DrawTextColouredMarc(ref Expression, this.OwnText + "|", this.OwnFont, x, y, Color.White);
      }
      else if (this.inactive)
        DrawMod.DrawTextColouredMarc(ref Expression, this.OwnText, this.OwnFont, x, y, Color.LightGray);
      else
        DrawMod.DrawTextColouredMarc(ref Expression, this.OwnText, this.OwnFont, x, y, Color.White);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
