// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CombatStatusWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System.Drawing;

namespace WindowsApplication1
{
  public class CombatStatusWindowClass : WindowClass
  {
    private int Info1Id;
    private int info2id;

    public CombatStatusWindowClass(ref GameClass tGame)
      : base(ref tGame, 200, tGame.ScreenHeight)
    {
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff()
    {
      if (this.Info1Id > 0)
        this.RemoveSubPart(this.Info1Id);
      if (this.info2id > 0)
        this.RemoveSubPart(this.info2id);
      SubPartClass tsubpart = (SubPartClass) new TextPartClass("Status", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
      this.Info1Id = this.AddSubPart(ref tsubpart, 10, 2, 200, 20, 0);
      if (this.game.TempCombat.CombatType == 1)
      {
        tsubpart = (SubPartClass) new TextPartClass("Land Attack", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
        this.info2id = this.AddSubPart(ref tsubpart, 10, 42, 200, 20, 0);
      }
      else if (this.game.TempCombat.CombatType == 2)
      {
        tsubpart = (SubPartClass) new TextPartClass("Sea Attack", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
        this.info2id = this.AddSubPart(ref tsubpart, 10, 42, 200, 20, 0);
      }
      else if (this.game.TempCombat.CombatType == 3)
      {
        tsubpart = (SubPartClass) new TextPartClass("Land Art Attack", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
        this.info2id = this.AddSubPart(ref tsubpart, 10, 42, 200, 20, 0);
      }
      else if (this.game.TempCombat.CombatType == 4)
      {
        tsubpart = (SubPartClass) new TextPartClass("Sea Art Attack", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
        this.info2id = this.AddSubPart(ref tsubpart, 10, 42, 200, 20, 0);
      }
      else if (this.game.TempCombat.CombatType == 5)
      {
        tsubpart = (SubPartClass) new TextPartClass("Airstrike", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
        this.info2id = this.AddSubPart(ref tsubpart, 10, 42, 200, 20, 0);
      }
      else if (this.game.TempCombat.CombatType == 6)
      {
        tsubpart = (SubPartClass) new TextPartClass("Bombing Run", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
        this.info2id = this.AddSubPart(ref tsubpart, 10, 42, 200, 20, 0);
      }
      else if (this.game.TempCombat.CombatType == 9)
      {
        tsubpart = (SubPartClass) new TextPartClass("Paradrop", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
        this.info2id = this.AddSubPart(ref tsubpart, 10, 42, 200, 20, 0);
      }
      else if (this.game.TempCombat.CombatType == 10)
      {
        tsubpart = (SubPartClass) new TextPartClass("Amphibious Attack", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
        this.info2id = this.AddSubPart(ref tsubpart, 10, 42, 200, 20, 0);
      }
      else
      {
        if (this.game.TempCombat.CombatType != 11)
          return;
        tsubpart = (SubPartClass) new TextPartClass("Ambush / LandSurprise", new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 200, 20, false);
        this.info2id = this.AddSubPart(ref tsubpart, 10, 42, 200, 20, 0);
      }
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
