
// This file has been generated by the GUI designer. Do not modify.
namespace Pulsar4X.GTKForms.Controls
{
	public partial class SystemDisplayGTK
	{
		private global::Gtk.VBox vbox3;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label2;
		private global::Gtk.ComboBox SystemList;
		private global::Gtk.Label label3;
		private global::Gtk.Entry typeEntry;
		private global::Gtk.Label label4;
		private global::Gtk.Entry entry2;
		private global::Gtk.Label label5;
		private global::Gtk.Entry entry4;
		private global::Gtk.Label label6;
		private global::Gtk.Entry idEntry;
		private global::Gtk.Label GtkLabel12;
		private global::Gtk.HBox hbox4;
		private global::Gtk.Frame starsFrame;
		private global::Gtk.Label GtkLabel14;
		private global::Gtk.Frame frame4;
		private global::Gtk.Alignment GtkAlignment3;
		private global::Gtk.Label GtkLabel15;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Frame frame2;
		private global::Gtk.Alignment GtkAlignment1;
		private global::Gtk.Label GtkLabel13;
		private global::Gtk.HButtonBox hbuttonbox3;
		private global::Gtk.Button button1;
		private global::Gtk.Button button2;
		private global::Gtk.Button button3;
		private global::Gtk.Button button4;
		private global::Gtk.Button button5;
		private global::Gtk.Button button6;
		private global::Gtk.Button button7;
		private global::Gtk.Button button8;
		private global::Gtk.Button button9;
		private global::Gtk.Button button10;
		private global::Gtk.Button button11;
		private global::Gtk.Button button12;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Pulsar4X.GTKForms.Controls.SystemDisplayGTK
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Pulsar4X.GTKForms.Controls.SystemDisplayGTK";
			// Container child Pulsar4X.GTKForms.Controls.SystemDisplayGTK.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Name");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.SystemList = global::Gtk.ComboBox.NewText ();
			this.SystemList.WidthRequest = 100;
			this.SystemList.Name = "SystemList";
			this.hbox2.Add (this.SystemList);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.SystemList]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Type");
			this.hbox2.Add (this.label3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label3]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.typeEntry = new global::Gtk.Entry ();
			this.typeEntry.CanFocus = true;
			this.typeEntry.Name = "typeEntry";
			this.typeEntry.IsEditable = false;
			this.typeEntry.InvisibleChar = '●';
			this.hbox2.Add (this.typeEntry);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.typeEntry]));
			w4.Position = 3;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Controlling Empire");
			this.hbox2.Add (this.label4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label4]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.entry2 = new global::Gtk.Entry ();
			this.entry2.CanFocus = true;
			this.entry2.Name = "entry2";
			this.entry2.IsEditable = false;
			this.entry2.InvisibleChar = '●';
			this.hbox2.Add (this.entry2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.entry2]));
			w6.Position = 5;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Discovered");
			this.hbox2.Add (this.label5);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label5]));
			w7.Position = 6;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.entry4 = new global::Gtk.Entry ();
			this.entry4.CanFocus = true;
			this.entry4.Name = "entry4";
			this.entry4.IsEditable = false;
			this.entry4.InvisibleChar = '●';
			this.hbox2.Add (this.entry4);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.entry4]));
			w8.Position = 7;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("ID");
			this.hbox2.Add (this.label6);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label6]));
			w9.Position = 8;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.idEntry = new global::Gtk.Entry ();
			this.idEntry.CanFocus = true;
			this.idEntry.Name = "idEntry";
			this.idEntry.IsEditable = false;
			this.idEntry.WidthChars = 1;
			this.idEntry.MaxLength = 5;
			this.idEntry.InvisibleChar = '●';
			this.hbox2.Add (this.idEntry);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.idEntry]));
			w10.Position = 9;
			this.GtkAlignment.Add (this.hbox2);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel12 = new global::Gtk.Label ();
			this.GtkLabel12.Name = "GtkLabel12";
			this.GtkLabel12.LabelProp = global::Mono.Unix.Catalog.GetString ("General System Info");
			this.GtkLabel12.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel12;
			this.vbox3.Add (this.frame1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame1]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.starsFrame = new global::Gtk.Frame ();
			this.starsFrame.Name = "starsFrame";
			this.starsFrame.ShadowType = ((global::Gtk.ShadowType)(1));
			this.GtkLabel14 = new global::Gtk.Label ();
			this.GtkLabel14.Name = "GtkLabel14";
			this.GtkLabel14.LabelProp = global::Mono.Unix.Catalog.GetString ("Stars");
			this.GtkLabel14.UseMarkup = true;
			this.starsFrame.LabelWidget = this.GtkLabel14;
			this.hbox4.Add (this.starsFrame);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.starsFrame]));
			w14.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.frame4 = new global::Gtk.Frame ();
			this.frame4.Name = "frame4";
			this.frame4.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame4.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment3.Name = "GtkAlignment3";
			this.GtkAlignment3.LeftPadding = ((uint)(12));
			this.frame4.Add (this.GtkAlignment3);
			this.GtkLabel15 = new global::Gtk.Label ();
			this.GtkLabel15.Name = "GtkLabel15";
			this.GtkLabel15.LabelProp = global::Mono.Unix.Catalog.GetString ("Enviromental Tolerances");
			this.GtkLabel15.UseMarkup = true;
			this.frame4.LabelWidget = this.GtkLabel15;
			this.hbox4.Add (this.frame4);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.frame4]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			this.vbox3.Add (this.hbox4);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox4]));
			w17.Position = 1;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Homogeneous = true;
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment1.Name = "GtkAlignment1";
			this.GtkAlignment1.LeftPadding = ((uint)(12));
			this.frame2.Add (this.GtkAlignment1);
			this.GtkLabel13 = new global::Gtk.Label ();
			this.GtkLabel13.Name = "GtkLabel13";
			this.GtkLabel13.LabelProp = global::Mono.Unix.Catalog.GetString ("Colony Cost Factors");
			this.GtkLabel13.UseMarkup = true;
			this.frame2.LabelWidget = this.GtkLabel13;
			this.hbox3.Add (this.frame2);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.frame2]));
			w19.Position = 1;
			this.vbox3.Add (this.hbox3);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox3]));
			w20.Position = 3;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbuttonbox3 = new global::Gtk.HButtonBox ();
			this.hbuttonbox3.Name = "hbuttonbox3";
			this.hbuttonbox3.BorderWidth = ((uint)(6));
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button1 = new global::Gtk.Button ();
			this.button1.CanFocus = true;
			this.button1.Name = "button1";
			this.button1.UseUnderline = true;
			this.button1.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button1);
			global::Gtk.ButtonBox.ButtonBoxChild w21 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button1]));
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button2 = new global::Gtk.Button ();
			this.button2.CanFocus = true;
			this.button2.Name = "button2";
			this.button2.UseUnderline = true;
			this.button2.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button2);
			global::Gtk.ButtonBox.ButtonBoxChild w22 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button2]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button3 = new global::Gtk.Button ();
			this.button3.CanFocus = true;
			this.button3.Name = "button3";
			this.button3.UseUnderline = true;
			this.button3.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button3);
			global::Gtk.ButtonBox.ButtonBoxChild w23 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button3]));
			w23.Position = 2;
			w23.Expand = false;
			w23.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button4 = new global::Gtk.Button ();
			this.button4.CanFocus = true;
			this.button4.Name = "button4";
			this.button4.UseUnderline = true;
			this.button4.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button4);
			global::Gtk.ButtonBox.ButtonBoxChild w24 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button4]));
			w24.Position = 3;
			w24.Expand = false;
			w24.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button5 = new global::Gtk.Button ();
			this.button5.CanFocus = true;
			this.button5.Name = "button5";
			this.button5.UseUnderline = true;
			this.button5.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button5);
			global::Gtk.ButtonBox.ButtonBoxChild w25 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button5]));
			w25.Position = 4;
			w25.Expand = false;
			w25.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button6 = new global::Gtk.Button ();
			this.button6.CanFocus = true;
			this.button6.Name = "button6";
			this.button6.UseUnderline = true;
			this.button6.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button6);
			global::Gtk.ButtonBox.ButtonBoxChild w26 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button6]));
			w26.Position = 5;
			w26.Expand = false;
			w26.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button7 = new global::Gtk.Button ();
			this.button7.CanFocus = true;
			this.button7.Name = "button7";
			this.button7.UseUnderline = true;
			this.button7.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button7);
			global::Gtk.ButtonBox.ButtonBoxChild w27 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button7]));
			w27.Position = 6;
			w27.Expand = false;
			w27.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button8 = new global::Gtk.Button ();
			this.button8.CanFocus = true;
			this.button8.Name = "button8";
			this.button8.UseUnderline = true;
			this.button8.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button8);
			global::Gtk.ButtonBox.ButtonBoxChild w28 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button8]));
			w28.Position = 7;
			w28.Expand = false;
			w28.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button9 = new global::Gtk.Button ();
			this.button9.CanFocus = true;
			this.button9.Name = "button9";
			this.button9.UseUnderline = true;
			this.button9.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button9);
			global::Gtk.ButtonBox.ButtonBoxChild w29 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button9]));
			w29.Position = 8;
			w29.Expand = false;
			w29.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button10 = new global::Gtk.Button ();
			this.button10.CanFocus = true;
			this.button10.Name = "button10";
			this.button10.UseUnderline = true;
			this.button10.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button10);
			global::Gtk.ButtonBox.ButtonBoxChild w30 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button10]));
			w30.Position = 9;
			w30.Expand = false;
			w30.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button11 = new global::Gtk.Button ();
			this.button11.CanFocus = true;
			this.button11.Name = "button11";
			this.button11.UseUnderline = true;
			this.button11.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button11);
			global::Gtk.ButtonBox.ButtonBoxChild w31 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button11]));
			w31.Position = 10;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
			this.button12 = new global::Gtk.Button ();
			this.button12.CanFocus = true;
			this.button12.Name = "button12";
			this.button12.UseUnderline = true;
			this.button12.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.hbuttonbox3.Add (this.button12);
			global::Gtk.ButtonBox.ButtonBoxChild w32 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button12]));
			w32.Position = 11;
			w32.Expand = false;
			w32.Fill = false;
			this.vbox3.Add (this.hbuttonbox3);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbuttonbox3]));
			w33.Position = 4;
			w33.Expand = false;
			w33.Fill = false;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.SystemList.Changed += new global::System.EventHandler (this.SystemSelect);
		}
	}
}
