using System.Windows.Controls;
using DataLayer.Database;

namespace WPF.Components
{
    /// <summary>
    /// Interaction logic for StudentList.xaml
    /// </summary>
    public partial class StudentList : UserControl
    {
        public StudentList()
        {
            InitializeComponent();

            using (var context = new DatabaseContext())
            {
                var records = context.Users.ToList();
                students.DataContext = records;
            }

        }
    }
}
