// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.EditOptionsWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;

namespace WindowsApplication1
{
  public class EditOptionsWindowClass : WindowClass
  {
    public int BShowMapId;
    public int BShowMapTextId;
    public int BBackId;
    public int BBackTextId;
    public int BLTId;
    public int BLTTextId;
    public int BEditTextId;
    public int BRoadId;
    public int BRoadTextId;
    public int BHisId;
    public int BHisTextId;
    public int BRiverID;
    public int BRiverTextId;
    public int BBridgeID;
    public int BBridgeTextID;
    public int BRegimeID;
    public int BRegimeTextId;
    public int BSFTypeID;
    public int BSFTypeTextId;
    public int BEditUnitID;
    public int BEditUnitTextId;
    public int bLocTypId;
    public int BLocTypTextId;
    public int BResetPaintId;
    public int BDefaultStringsID;
    public int BDefaultStringsTextId;
    public int BPeopleID;
    public int BPeopleTextId;
    public int BLocationID;
    public int BLocationTextId;
    public int BItemTypeID;
    public int BItemTypeTextId;
    public int BEventTypeID;
    public int BEventTypeTextId;
    public int BConnectionID;
    public int BConnectionTextId;
    public int BActionID;
    public int BActionTextID;
    public int AddMapId;
    public int RemoveMapId;
    public int maploopid;
    private int BDraw2Id;
    private int BDraw2TextId;
    public int BResID;
    public int BResTextId;
    public int BLibId;
    public int BLibTextId;
    public int bStringListId;
    public int bStringListTextId;
    public int opt1id;
    public int opt2id;
    public int opt3id;
    public int opt4id;
    public int opt5id;
    public int opt6id;
    public int pickid;
    private int firstListId;
    private ListClass firstListObj;
    private int medListId;
    private ListClass medListObj;
    private int lastListId;
    private ListClass lastListObj;
    private int MapListId;
    private ListClass MapListObj;
    private int Shortsdesc;
    private int detailnr;
    private bool warningshown;

    public void PopUpRefresh() => this.dostuff();

    public EditOptionsWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, tGame.ScreenWidth, 100, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.domenu();
      this.dostuff();
      this.game.EditObj.inSimpleEditor = false;
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (!this.game.EditObj.warningshown)
      {
        string str = "ADVANCED EDITOR IS STILL IN BETA\r\n" + "Check the matrix forums and save your work often!";
        this.game.EditObj.PopupValue = 10;
        this.game.EditObj.QuestionText = str;
        this.game.EditObj.AnswerCount = 1;
        this.game.EditObj.AnswerText[1] = "Ok";
        this.game.EditObj.warningshown = true;
        windowReturnClass.AddCommand(5, 10);
        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public void domenu()
    {
      SubPartClass tsubpart1 = (SubPartClass) new ButtonPartClass(this.game.BUTTONKILL);
      this.BBackId = this.AddSubPart(ref tsubpart1, 10, 2, 32, 16, 1);
      SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("Main", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BBackTextId = this.AddSubPart(ref tsubpart2, 45, 1, 30, 16, 0);
      SubPartClass tsubpart3 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BShowMapId = this.AddSubPart(ref tsubpart3, 10, 22, 32, 16, 1);
      SubPartClass tsubpart4 = (SubPartClass) new TextPartClass("Map", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BShowMapTextId = this.AddSubPart(ref tsubpart4, 45, 21, 30, 16, 0);
      SubPartClass tsubpart5 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BLTId = this.AddSubPart(ref tsubpart5, 10, 42, 32, 16, 1);
      SubPartClass tsubpart6 = (SubPartClass) new TextPartClass("Land", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BLTTextId = this.AddSubPart(ref tsubpart6, 45, 41, 30, 16, 0);
      SubPartClass tsubpart7 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BRoadId = this.AddSubPart(ref tsubpart7, 10, 62, 32, 16, 1);
      SubPartClass tsubpart8 = (SubPartClass) new TextPartClass("Road", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BRoadTextId = this.AddSubPart(ref tsubpart8, 45, 61, 30, 16, 0);
      SubPartClass tsubpart9 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BRiverID = this.AddSubPart(ref tsubpart9, 85, 2, 32, 16, 1);
      SubPartClass tsubpart10 = (SubPartClass) new TextPartClass("River", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BRiverTextId = this.AddSubPart(ref tsubpart10, 120, 1, 30, 16, 0);
      SubPartClass tsubpart11 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BRegimeID = this.AddSubPart(ref tsubpart11, 85, 22, 32, 16, 1);
      SubPartClass tsubpart12 = (SubPartClass) new TextPartClass("Reg", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BRegimeTextId = this.AddSubPart(ref tsubpart12, 120, 21, 30, 16, 0);
      SubPartClass tsubpart13 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BSFTypeID = this.AddSubPart(ref tsubpart13, 85, 42, 32, 16, 1);
      SubPartClass tsubpart14 = (SubPartClass) new TextPartClass("SFT", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BSFTypeTextId = this.AddSubPart(ref tsubpart14, 120, 41, 30, 16, 0);
      SubPartClass tsubpart15 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BEditUnitID = this.AddSubPart(ref tsubpart15, 85, 62, 32, 16, 1);
      SubPartClass tsubpart16 = (SubPartClass) new TextPartClass("Units", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BEditUnitTextId = this.AddSubPart(ref tsubpart16, 120, 61, 30, 16, 0);
      SubPartClass tsubpart17 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BActionID = this.AddSubPart(ref tsubpart17, 85, 82, 32, 16, 1);
      SubPartClass tsubpart18 = (SubPartClass) new TextPartClass("Cards", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BActionTextID = this.AddSubPart(ref tsubpart18, 120, 81, 30, 16, 0);
      SubPartClass tsubpart19 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BDefaultStringsID = this.AddSubPart(ref tsubpart19, 160, 2, 32, 16, 1);
      SubPartClass tsubpart20 = (SubPartClass) new TextPartClass("Setng", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BDefaultStringsTextId = this.AddSubPart(ref tsubpart20, 195, 1, 30, 16, 0);
      SubPartClass tsubpart21 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.bLocTypId = this.AddSubPart(ref tsubpart21, 160, 22, 32, 16, 1);
      SubPartClass tsubpart22 = (SubPartClass) new TextPartClass("LT", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BLocTypTextId = this.AddSubPart(ref tsubpart22, 195, 21, 30, 16, 0);
      SubPartClass tsubpart23 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BPeopleID = this.AddSubPart(ref tsubpart23, 160, 42, 32, 16, 1);
      SubPartClass tsubpart24 = (SubPartClass) new TextPartClass("Ppl", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BPeopleTextId = this.AddSubPart(ref tsubpart24, 195, 41, 30, 16, 0);
      SubPartClass tsubpart25 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BLocationID = this.AddSubPart(ref tsubpart25, 160, 62, 32, 16, 1);
      SubPartClass tsubpart26 = (SubPartClass) new TextPartClass("Hex", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 40, 16, false);
      this.BLocationTextId = this.AddSubPart(ref tsubpart26, 195, 61, 40, 16, 0);
      SubPartClass tsubpart27 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.bStringListId = this.AddSubPart(ref tsubpart27, 160, 82, 32, 16, 1);
      SubPartClass tsubpart28 = (SubPartClass) new TextPartClass("String", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.bStringListTextId = this.AddSubPart(ref tsubpart28, 195, 81, 30, 16, 0);
      SubPartClass tsubpart29 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BEventTypeID = this.AddSubPart(ref tsubpart29, 235, 2, 32, 16, 1);
      SubPartClass tsubpart30 = (SubPartClass) new TextPartClass("Event", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BEventTypeTextId = this.AddSubPart(ref tsubpart30, 270, 1, 30, 16, 0);
      SubPartClass tsubpart31 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BBridgeID = this.AddSubPart(ref tsubpart31, 235, 42, 32, 16, 1);
      SubPartClass tsubpart32 = (SubPartClass) new TextPartClass("Brdge", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BBridgeTextID = this.AddSubPart(ref tsubpart32, 270, 41, 30, 16, 0);
      SubPartClass tsubpart33 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BHisId = this.AddSubPart(ref tsubpart33, 235, 82, 32, 16, 1);
      SubPartClass tsubpart34 = (SubPartClass) new TextPartClass("His", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BHisTextId = this.AddSubPart(ref tsubpart34, 270, 81, 30, 16, 0);
      SubPartClass tsubpart35 = (SubPartClass) new ButtonPartClass(this.game.BUTTONBLOCK);
      this.BLibId = this.AddSubPart(ref tsubpart35, 310, 2, 32, 16, 1);
      SubPartClass tsubpart36 = (SubPartClass) new TextPartClass("Lib", new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Pixel), 30, 16, false);
      this.BLibTextId = this.AddSubPart(ref tsubpart36, 345, 1, 30, 16, 0);
      int x = 870;
      int y1 = 0;
      SubPartClass tsubpart37 = (SubPartClass) new TextPartClass("SHORTKEYS FOR HIST.UNITS:", this.game.MarcFont10, 180, 15, false);
      this.AddSubPart(ref tsubpart37, x, y1, 180, 15, 1);
      int y2 = y1 + 16;
      SubPartClass tsubpart38 = (SubPartClass) new TextPartClass("HOME = Place instance of a model his", this.game.MarcFont10, 180, 15, false);
      this.AddSubPart(ref tsubpart38, x, y2, 180, 15, 1);
      int y3 = y2 + 13;
      SubPartClass tsubpart39 = (SubPartClass) new TextPartClass("PAGEUP = Place a non-model his", this.game.MarcFont10, 180, 15, false);
      this.AddSubPart(ref tsubpart39, x, y3, 180, 15, 1);
      int y4 = y3 + 13;
      SubPartClass tsubpart40 = (SubPartClass) new TextPartClass("BACK= Remove his-link from unit", this.game.MarcFont10, 180, 15, false);
      this.AddSubPart(ref tsubpart40, x, y4, 180, 15, 1);
      int y5 = y4 + 13;
      SubPartClass tsubpart41 = (SubPartClass) new TextPartClass("D0 = Select type for his of unit", this.game.MarcFont10, 180, 15, false);
      this.AddSubPart(ref tsubpart41, x, y5, 180, 15, 1);
      int y6 = y5 + 13;
      SubPartClass tsubpart42 = (SubPartClass) new TextPartClass("D9 = Select shortname for his of unit", this.game.MarcFont10, 180, 15, false);
      this.AddSubPart(ref tsubpart42, x, y6, 180, 15, 1);
      int y7 = y6 + 13;
      SubPartClass tsubpart43 = (SubPartClass) new TextPartClass("D8 = Select nato for his of unit", this.game.MarcFont10, 180, 15, false);
      this.AddSubPart(ref tsubpart43, x, y7, 180, 15, 1);
    }

    public void dostuff()
    {
      if (this.pickid > 0)
        this.RemoveSubPart(this.pickid);
      if (this.opt1id > 0)
        this.RemoveSubPart(this.opt1id);
      if (this.opt2id > 0)
        this.RemoveSubPart(this.opt2id);
      if (this.opt3id > 0)
        this.RemoveSubPart(this.opt3id);
      if (this.opt4id > 0)
        this.RemoveSubPart(this.opt4id);
      if (this.opt5id > 0)
        this.RemoveSubPart(this.opt5id);
      if (this.opt6id > 0)
        this.RemoveSubPart(this.opt6id);
      if (this.BEditTextId > 0)
        this.RemoveSubPart(this.BEditTextId);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.game.ScreenWidth, 100, -1);
      this.FlagAll();
      this.detailnr = this.game.EditObj.MapSelected;
      bool flag;
      string str;
      string Left1;
      string ttext;
      if (this.game.EditObj.PencilType > 0)
      {
        if (!(this.game.EditObj.PencilType == 3 | this.game.EditObj.PencilType == 10 | this.game.EditObj.PencilType == 1 | this.game.EditObj.PencilType == 9 | this.game.EditObj.PencilType == 11))
          flag = true;
        if (this.game.EditObj.PencilType == 1)
        {
          str = "Landsc# " + Conversion.Str((object) this.game.EditObj.PencilData1) + "," + Conversion.Str((object) this.game.EditObj.PencilData2);
          Left1 = this.game.Data.LandscapeTypeObj[this.game.EditObj.PencilData1].Name;
          ttext = "Left click to draw this landscape+sprite on a hex, right click to only select a hex.";
        }
        else if (this.game.EditObj.PencilType == 10)
        {
          str = "Spec.Lt# " + Conversion.Str((object) this.game.EditObj.PencilData1) + "," + Conversion.Str((object) this.game.EditObj.PencilData2);
          Left1 = this.game.EditObj.PencilData1 <= -1 ? "Remove Special" : this.game.Data.LandscapeTypeObj[this.game.EditObj.PencilData1].Name;
          ttext = "Left click to draw this landscape+sprite a a special on a hex, right click to only select a hex.";
        }
        else if (this.game.EditObj.PencilType == 2)
        {
          str = "Road# " + Conversion.Str((object) this.game.EditObj.PencilData1);
          Left1 = this.game.Data.RoadTypeObj[this.game.EditObj.PencilData1].Name;
          ttext = "First right click to select a hex, then left click on a neighbouring hex to draw a road between them.";
        }
        else if (this.game.EditObj.PencilType == 3)
        {
          str = "Reg# " + Conversion.Str((object) this.game.EditObj.PencilData1);
          Left1 = this.game.EditObj.PencilData1 <= this.game.Data.RegimeCounter ? this.game.Data.RegimeObj[this.game.EditObj.PencilData1].Name : "Neutral Hex";
          ttext = "Left click to draw this regime on a hex, right click just to select a hex, clicking twice results in hex becoming neutral again.";
        }
        else if (this.game.EditObj.PencilType == 4)
        {
          str = "LocTyp# " + Conversion.Str((object) this.game.EditObj.PencilData1);
          Left1 = this.game.Data.LocTypeObj[this.game.EditObj.PencilData1].Name;
          ttext = "Left click on a hex to place a location of this locationtype. Right click is only select.";
        }
        else if (this.game.EditObj.PencilType == 5)
        {
          str = "RiverTyp# " + Conversion.Str((object) this.game.EditObj.PencilData1);
          Left1 = this.game.Data.RiverTypeObj[this.game.EditObj.PencilData1].Name;
          ttext = "First right click to select a hex, then left click on a neighbouring hex to draw a river inbetween them.";
        }
        else if (this.game.EditObj.PencilType == 6)
        {
          str = "Bridge";
          Left1 = "";
          ttext = "First right click to select a hex, then left click on a neighbouring hex to draw a bridge in between them.";
        }
        else if (this.game.EditObj.PencilType == 9)
        {
          str = "Slot# " + Conversion.Str((object) this.game.EditObj.PencilData1) + ", => " + Conversion.Str((object) this.game.EditObj.PencilData2);
          Left1 = "";
          ttext = "Left click to place this value on a hex, right click just to select a hex.";
        }
        else if (this.game.EditObj.PencilType == 11)
        {
          str = "LibVarSlot " + Conversion.Str((object) this.game.EditObj.PencilData1) + ", => " + Conversion.Str((object) this.game.EditObj.PencilData2);
          Left1 = "";
          ttext = "Left click to place this value on a hex, right click just to select a hex.";
        }
        else
        {
          str = "Pointer";
          Left1 = "";
          ttext = "I hope you are having a good day!";
        }
      }
      int x = 735;
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      string Left2 = this.game.EditObj.PencilMode != 0 ? "Fill" : "Draw";
      if (this.game.EditObj.PencilType == 0)
        Left2 = "None";
      ref Graphics local1 = ref graphics;
      Rectangle rectangle1 = new Rectangle(x, 5, 200, 10);
      Rectangle rect1_1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(x, 15, 120, 17);
      Rectangle rect2_1 = rectangle2;
      string txt2_1 = Left2;
      DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "DRAW MODE", rect2_1, txt2_1);
      if (Operators.CompareString(Left2, "None", false) != 0)
      {
        ref Graphics local2 = ref graphics;
        rectangle2 = new Rectangle(x, 35, 200, 10);
        Rectangle rect1_2 = rectangle2;
        rectangle1 = new Rectangle(x, 45, 120, 17);
        Rectangle rect2_2 = rectangle1;
        string txt2_2 = str;
        DrawMod.MakeFullBoxVic2(ref local2, rect1_2, "DRAW TYPE", rect2_2, txt2_2);
        if (Operators.CompareString(Left1, "", false) != 0)
        {
          ref Graphics local3 = ref graphics;
          rectangle2 = new Rectangle(x, 65, 200, 10);
          Rectangle rect1_3 = rectangle2;
          rectangle1 = new Rectangle(x, 75, 120, 17);
          Rectangle rect2_3 = rectangle1;
          string txt2_3 = Left1;
          DrawMod.MakeFullBoxVic2(ref local3, rect1_3, "DRAW TYPE NAME", rect2_3, txt2_3);
        }
        else
        {
          ref Graphics local4 = ref graphics;
          rectangle2 = new Rectangle(x, 65, 200, 10);
          Rectangle rect1_4 = rectangle2;
          rectangle1 = new Rectangle(x, 75, 120, 17);
          Rectangle rect2_4 = rectangle1;
          DrawMod.MakeFullBoxVic2(ref local4, rect1_4, "DRAW TYPE NAME", rect2_4, "");
        }
      }
      else
      {
        ref Graphics local5 = ref graphics;
        rectangle2 = new Rectangle(x, 35, 200, 10);
        Rectangle rect1_5 = rectangle2;
        rectangle1 = new Rectangle(x, 45, 120, 17);
        Rectangle rect2_5 = rectangle1;
        DrawMod.MakeFullBoxVic2(ref local5, rect1_5, "DRAW TYPE", rect2_5, "");
        ref Graphics local6 = ref graphics;
        rectangle2 = new Rectangle(x, 65, 200, 10);
        Rectangle rect1_6 = rectangle2;
        rectangle1 = new Rectangle(x, 75, 120, 17);
        Rectangle rect2_6 = rectangle1;
        DrawMod.MakeFullBoxVic2(ref local6, rect1_6, "DRAW TYPE NAME", rect2_6, "");
      }
      rectangle2 = new Rectangle(x, 0, 120, 100);
      Rectangle trect = rectangle2;
      this.AddMouse(ref trect, "", ttext);
      SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Pick Draw Type", 160, tBackbitmap: (ref this.OwnBitmap), bbx: 535, bby: 5, theight: 30);
      this.pickid = this.AddSubPart(ref tsubpart1, 535, 5, 160, 30, 1);
      if (Operators.CompareString(Left2, "Draw", false) == 0)
      {
        if (!flag)
        {
          SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Go to fill mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: 535, bby: 35, theight: 30);
          this.opt2id = this.AddSubPart(ref tsubpart2, 535, 35, 160, 30, 1);
        }
        else
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Go to fill mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: 535, bby: 35, tinactive: true, theight: 30);
          this.opt4id = this.AddSubPart(ref tsubpart3, 535, 35, 160, 30, 0);
        }
      }
      else if (Operators.CompareString(Left2, "Fill", false) == 0)
      {
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Go to draw mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: 535, bby: 35, theight: 30);
        this.opt1id = this.AddSubPart(ref tsubpart4, 535, 35, 160, 30, 1);
      }
      if (Operators.CompareString(Left2, "None", false) != 0)
      {
        SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("End drawing mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: 535, bby: 65, theight: 30);
        this.opt3id = this.AddSubPart(ref tsubpart5, 535, 65, 160, 30, 1);
      }
      else
      {
        SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass("Go to fill mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: 535, bby: 35, tinactive: true, theight: 30);
        this.opt4id = this.AddSubPart(ref tsubpart6, 535, 35, 160, 30, 1);
        SubPartClass tsubpart7 = (SubPartClass) new TextButtonPartClass("End drawing mode", 160, tBackbitmap: (ref this.OwnBitmap), bbx: 535, bby: 65, tinactive: true, theight: 30);
        this.opt5id = this.AddSubPart(ref tsubpart7, 535, 65, 160, 30, 1);
      }
    }

    public override string WindowDescription(int x, int y)
    {
      if (this.game.SelectX < 0 || this.game.Data.Turn == -1)
        return "";
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
          return this.MouseText[index];
      }
      return "";
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
            int num1 = this.SubPartID[index];
            if (num1 == this.MapListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              if (num2 > -1)
              {
                this.detailnr = num2;
                this.game.EditObj.MapSelected = num2;
                this.game.CornerX = 0;
                this.game.CornerY = 0;
                this.game.SelectX = 0;
                this.game.SelectY = 0;
                this.game.EditObj.UnitSelected = -1;
                this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 20);
                windowReturnClass.AddCommand(4, 18);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.pickid)
            {
              this.game.EditObj.PopupValue = 16;
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.AddCommand(5, 10);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.AddMapId)
            {
              string str1 = Conversions.ToString(Conversion.Val(Interaction.InputBox("Give width of map in hexes (10-200)", "Shadow Empire : Planetary Conquest", "20")));
              int w = Operators.CompareString(Strings.Trim(str1), "", false) == 0 ? 0 : Conversions.ToInteger(str1);
              string str2 = Conversions.ToString(Conversion.Val(Interaction.InputBox("Give height of map in hexes (10-200)", "Shadow Empire : Planetary Conquest", "20")));
              int h = Operators.CompareString(Strings.Trim(str2), "", false) == 0 ? 0 : Conversions.ToInteger(str2);
              if (w < 2 | h < 2 | w > 200 | h > 200)
              {
                int num3 = (int) Interaction.MsgBox((object) "Cannot comply. Width and Height must be between 2 and 200", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              else
              {
                this.game.Data.AddMap(w, h);
                this.game.Data.MapObj[this.game.Data.MapCounter].Name = Interaction.InputBox("Give Name for Map", "Shadow Empire : Planetary Conquest");
                this.game.Data.MapObj[this.game.Data.MapCounter].MapLoop = false;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.maploopid)
              {
                if (this.detailnr > -1)
                {
                  if (Interaction.MsgBox((object) "You want to rename map?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                    this.game.Data.MapObj[this.detailnr].Name = Interaction.InputBox("Give Name for Map", "Shadow Empire : Planetary Conquest");
                  if (Interaction.MsgBox((object) "You want to change looping of the map?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
                    this.game.Data.MapObj[this.detailnr].MapLoop = !this.game.Data.MapObj[this.detailnr].MapLoop;
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.RemoveMapId)
              {
                if (this.detailnr > 0)
                {
                  this.game.Data.RemoveMap(this.detailnr);
                }
                else
                {
                  int num4 = (int) Interaction.MsgBox((object) "Cannot delete. You must keep at least one map.");
                }
                this.game.EditObj.MapSelected = 0;
                this.game.SelectX = 0;
                this.game.SelectY = 0;
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.AddCommand(4, 18);
                windowReturnClass.AddCommand(4, 20);
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Shortsdesc)
              {
                this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BBackId)
              {
                this.game.EditObj.InEditor = false;
                if (this.game.ModIntroType == 0)
                  windowReturnClass.AddCommand(3, 1);
                else
                  windowReturnClass.AddCommand(3, 12);
              }
              else if (num1 == this.BLTId)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 11);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BHisId)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 86);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BRoadId)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 14);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BLibId)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 93);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BConnectionID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 58);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BRegimeID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 15);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.bStringListId)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 60);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BShowMapId)
              {
                this.dostuff();
                if (this.game.EditObj.MiddleWindow)
                {
                  windowReturnClass.AddCommand(1, 4);
                  windowReturnClass.AddCommand(2, 12);
                  windowReturnClass.AddCommand(2, 18);
                  windowReturnClass.AddCommand(2, 20);
                  windowReturnClass.AddCommand(2, 44);
                  this.game.EditObj.MiddleWindow = false;
                }
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BSFTypeID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 16);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BRiverID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 33);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BActionID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 57);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BBridgeID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 34);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BPeopleID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 22);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BEditUnitID)
              {
                if (this.game.SelectX > -1 & this.game.SelectY > -1)
                {
                  windowReturnClass.AddCommand(1, 4);
                  windowReturnClass.AddCommand(2, 17);
                  windowReturnClass.AddCommand(1, 2);
                  windowReturnClass.AddCommand(1, 5);
                  windowReturnClass.AddCommand(1, 7);
                  this.game.EditObj.MiddleWindow = true;
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num5 = (int) Interaction.MsgBox((object) "No Hex has been selected. Order is cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
              }
              else if (num1 == this.BDefaultStringsID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 23);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.bLocTypId)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 21);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BItemTypeID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 24);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BLocationID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 26);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BResID)
              {
                windowReturnClass.AddCommand(1, 4);
                windowReturnClass.AddCommand(2, 37);
                windowReturnClass.AddCommand(1, 2);
                windowReturnClass.AddCommand(1, 5);
                windowReturnClass.AddCommand(1, 7);
                this.game.EditObj.MiddleWindow = true;
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.BEventTypeID)
              {
                windowReturnClass.AddCommand(3, 7);
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.opt1id)
              {
                this.game.EditObj.PencilMode = 0;
                this.dostuff();
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.opt2id)
              {
                this.game.EditObj.PencilMode = 1;
                this.dostuff();
                windowReturnClass.SetFlag(true);
              }
              else if (num1 == this.opt3id)
              {
                this.game.EditObj.PencilType = 0;
                this.game.EditObj.PencilMode = 0;
                this.game.EditObj.PaintShortcut1 = -1;
                this.game.EditObj.PaintShortcut2 = -1;
                this.game.EditObj.PaintShortcut3 = -1;
                this.dostuff();
                windowReturnClass.AddCommand(4, 12);
                windowReturnClass.SetFlag(true);
              }
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
