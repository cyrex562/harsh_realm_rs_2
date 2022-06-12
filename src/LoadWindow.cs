// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LoadWindow
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class LoadWindow : WindowClass
  {
    private Thread LoadThread;
    private LoadClass load;
    private int cycle;

    public LoadWindow(ref GameClass tGame)
      : base(ref tGame, 400, 240, 8)
    {
      this.game.EditObj.LoadString = "Initializing";
      this.game.EditObj.LoadingResult = LoadType.None;
      this.game.FormRef.Cursor = Cursors.WaitCursor;
      this.game.EditObj.LoadingFinished = false;
      this.load = new LoadClass(ref tGame);
      this.LoadThread = new Thread(new ThreadStart(this.load.Go));
      this.LoadThread.Start();
      this.View();
    }

    public void View()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(400, 240, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 400, 240);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      DrawMod.DrawTextColouredMarcCenter(ref graphics, "LOADING GAME", this.game.MarcFont1, 190, 47, Color.White);
      DrawMod.DrawTextColouredMarcCenter(ref graphics, this.game.EditObj.LoadString, this.game.MarcFont1, 190, (int) sbyte.MaxValue, Color.White);
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.LoadingFinished)
      {
        this.LoadThread.Join();
        this.game.EditObj.LoadingFinished = false;
        this.game.FormRef.Cursor = Cursors.Default;
        windowReturnClass.AddCommand(6, 0);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      ++this.cycle;
      if (this.cycle % 20 == 0)
      {
        this.game.EditObj.LoadString += ".";
        if (this.game.EditObj.LoadString.Length > 40)
          this.game.EditObj.LoadString = Strings.Left(this.game.EditObj.LoadString, 40);
        this.View();
        windowReturnClass.SetFlag(true);
      }
      return windowReturnClass;
    }
  }
}
