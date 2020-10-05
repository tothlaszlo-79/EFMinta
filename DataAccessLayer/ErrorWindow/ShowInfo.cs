using System.Windows.Forms;

namespace DataAccessLayer
{
   public class ShowInfo
    {
        public void ShowMessage(string ErrorInfo)
        {
            MessageBox.Show(ErrorInfo, "Hiba az adatelérésben", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
