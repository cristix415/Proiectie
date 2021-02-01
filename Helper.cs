using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProiectareCantari
{
   public class Helper
    {
        public static void MeasureStringMin(Label lblStrofa, int maxSize)
        {
            SizeF text_size= new SizeF();
            if (lblStrofa.Text.Length > 0)
            {
                // Make a Graphics object to measure the text.
                using (Graphics gr = lblStrofa.CreateGraphics())
                {
                    for (int i = 1; i <= maxSize; i++)
                    {
                        using (var test_font = new Font(lblStrofa.Font.FontFamily, i))
                        {
                            // See how much space the text would
                            // need, specifying a maximum width.
                             text_size =
                                        TextRenderer.MeasureText(
                                            lblStrofa.Text,
                                            test_font,
                                            new Size(lblStrofa.Width, int.MaxValue),
                                            TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

                            try
                            {
                                if (text_size.Height > lblStrofa.Height)
                                {
                                    maxSize = i - 1;
                                    break;
                                }
                            }
                            catch (System.ComponentModel.Win32Exception)
                            {
                                // this sometimes throws a "failure to create window handle" error.
                                // This might happen if the TextBox is invisible and/or
                                // too small to display a toolbar.
                                // do whatever here, add/delete, whatever, maybe set to default font size?
                                maxSize = (int)lblStrofa.Font.Size;
                            }
                        }
                    }
                }
                var mm = maxSize - (maxSize * 20 / 100);
                using (var test_font = new Font(lblStrofa.Font.FontFamily, mm ))
                {
                    SizeF text_sizeNOU =
                            TextRenderer.MeasureText(
                                lblStrofa.Text,
                                test_font,
                                new Size(lblStrofa.Width, int.MaxValue),
                                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                    if (text_size.Height > text_sizeNOU.Height + (text_sizeNOU.Height*30/100))
                        maxSize = mm;

                }

                // Use that font size.
                lblStrofa.Font = new Font(lblStrofa.Font.FontFamily, maxSize);

            }

        }
    }
}
