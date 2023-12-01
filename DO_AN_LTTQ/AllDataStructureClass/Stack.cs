using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class Stack : DataStructure
    {
        public Stack(string[] input_info)
        {

        }
        public override void ChooseOption(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Draw(PaintEventArgs e)
        {
            
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetEnable()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void GetInformation(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb,ComboBox spd)
        {
            base.GetInformation(dr, c, strb, cs, ts, dt, pb,spd);
        }

        public override void ModifyPanel(Panel interact_panel)
        {
            
        }

        public override void RunAlgorithms()
        {
            throw new NotImplementedException();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override void UpdateDataStructure()
        {
            throw new NotImplementedException();
        }

        public override void UpdateLocation()
        {
            throw new NotImplementedException();
        }
    }
}
